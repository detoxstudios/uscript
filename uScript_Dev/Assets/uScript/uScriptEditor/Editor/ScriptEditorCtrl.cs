using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection.Emit;

using Detox.FlowChart;
using Detox.Application;

namespace Detox.ScriptEditor
{
   public partial class ScriptEditorCtrl : ToolWindow
   {
      public struct AutoLinkDesc
      {
         public Guid Guid;
         public string Name;
      }

      public delegate void ScriptModifiedEventHandler(object sender, EventArgs e);

      public event ScriptModifiedEventHandler ScriptModified;
      private void OnScriptModified( )
      {
         if (null != ScriptModified) ScriptModified(this, new EventArgs());
      }

      public string ScriptName { get { return m_ScriptEditor.Name; } }

      public bool CanCopy
      {
         get
         {
            return m_FlowChart.SelectedNodes.Length > 0 ||
                   m_FlowChart.SelectedLinks.Length > 0;
         }
      }

      public bool CanPaste
      {
         get
         {
            return GetClipboardData( ) != null;
         }
      }

      public bool CanExpand
      {
         get
         {
            foreach ( Node node in m_FlowChart.SelectedNodes )
            {
               foreach ( Parameter p in ((DisplayNode)node).EntityNode.Parameters )
               {
                  if ( true == CanExpandParameter(p) )
                  {
                     return true;
                  }
               }

               if ( true == CanExpandParameter(((DisplayNode)node).EntityNode.Instance) )
               {
                  return true;
               }
            }

            return false;
         }
      }

      public bool CanCollapse
      {
         get
         {
            foreach ( Node node in m_FlowChart.SelectedNodes )
            {
               foreach ( Parameter p in ((DisplayNode)node).EntityNode.Parameters )
               {
                  if ( true == CanCollapseParameter(node.Guid, p) )
                  {
                     return true;
                  }
               }

               if ( true == CanCollapseParameter(node.Guid, ((DisplayNode)node).EntityNode.Instance) )
               {
                  return true;
               }
            }

            return false;
         }
      }

      private ChangeStack m_ChangeStack = new ChangeStack( );
      
      private PropertyGrid m_PropertyGrid = null;
      public PropertyGrid PropertyGrid { get { return m_PropertyGrid; } }

      private ScriptEditor m_ScriptEditor = null;
      public ScriptEditor ScriptEditor 
      { 
         get { return m_ScriptEditor; } 
      }
		
      public Detox.FlowChart.FlowChartCtrl FlowChart { get { return m_FlowChart; } }
      
      public DisplayNode [] SelectedNodes
      {
         get
         {
            List<DisplayNode> nodes = new List<DisplayNode>( );

            foreach ( Node node in m_FlowChart.SelectedNodes )
            {
               nodes.Add( node as DisplayNode );
            }

            return nodes.ToArray( );
         }
      }

      public bool IsDirty 
      { 
         get { return m_Dirty; } 
         set { m_Dirty = value; }
      }

      private bool m_Dirty = false;
      Point  m_ContextCursor;
      object[] m_ContextObject;

      public Point ContextCursor
      {
         get { return m_ContextCursor; }
         set
         {
            m_ContextCursor = value;
            m_ContextCursor = m_FlowChart.PointToClient( m_ContextCursor );
         }
      }
      
      private bool m_CopiedFromThisLocation = false;

      public ScriptEditorCtrl(ScriptEditor scriptEditor)
      {  
         Initialize(scriptEditor, Point.Empty);
      }
      
      public ScriptEditorCtrl(ScriptEditor scriptEditor, Point location)
      {
         Initialize(scriptEditor, location);
      }
      
      private void Initialize(ScriptEditor scriptEditor, Point location)
      {
         InitializeComponent();
                  
         m_ContextObject = null;
         m_ContextCursor = Point.Empty;

         m_ScriptEditor = scriptEditor;

         m_PropertyGrid = new PropertyGrid( );

         Name    = m_ScriptEditor.Name;
         Text    = m_ScriptEditor.Name;
         TabText = m_ScriptEditor.Name;

         RefreshScript( null, true, location );
      }

      public Node GetPrevNode(Node node) { return GetPrevNode(node, null); }
      public Node GetPrevNode(Node node, Type filterType)
      {
         int i;
         int retIndex = -1;
         for (i = 0; i < m_FlowChart.Nodes.Length; i++)
         {
            if (node == m_FlowChart.Nodes[i] || (node == null && i == 0))
            {
               if (filterType != null)
               {
                  bool found = false;
                  int index = i;
                  if (node == null) index = m_FlowChart.Nodes.Length;
                  do
                  {
                     if (index == 0)
                     {
                        index = m_FlowChart.Nodes.Length - 1;
                     }
                     else
                     {
                        index--;
                     }
   
                     if (filterType.IsAssignableFrom(m_FlowChart.Nodes[index].GetType()))
                     {
                        retIndex = index;
                        found = true;
                     }
                  } while (!found && index != i);
               }
               else
               {
                  if (i == 0)
                  {
                     retIndex = m_FlowChart.Nodes.Length - 1;
                  }
                  else
                  {
                     retIndex = i - 1;
                  }
               }
                  
               break;
            }
         }
         
         if (retIndex == -1)
         {
            return null;
         }
         return m_FlowChart.Nodes[retIndex];
      }

      public Node GetNextNode(Node node) { return GetNextNode(node, null); }
      public Node GetNextNode(Node node, Type filterType)
      {
         int i;
         int retIndex = -1;
         for (i = 0; i < m_FlowChart.Nodes.Length; i++)
         {
            if (node == m_FlowChart.Nodes[i] || (node == null && i == 0))
            {
               if (filterType != null)
               {
                  bool found = false;
                  int index = i;
                  if (node == null) index = 0;
                  do
                  {
                     if (index == m_FlowChart.Nodes.Length - 1)
                     {
                        index = 0;
                     }
                     else
                     {
                        index++;
                     }
   
                     if (filterType.IsAssignableFrom(m_FlowChart.Nodes[index].GetType()))
                     {
                        retIndex = index;
                        found = true;
                     }
                  } while (!found && index != i);
               }
               else
               {
                  if (i == m_FlowChart.Nodes.Length - 1)
                  {
                     retIndex = 0;
                  }
                  else
                  {
                     retIndex = i + 1;
                  }
               }
                  
               break;
            }
         }
         
         if (retIndex == -1)
         {
            return null;
         }
         return m_FlowChart.Nodes[retIndex];
      }

      public Node GetNode(Guid guid)
      {
         return m_FlowChart.GetNode(guid);
      }

      public void CenterOnPoint(Point point)
      {
         // center the canvas viewport on the specified point
         point.X = Math.Min(0, Math.Max(-4096, -point.X + (int)(uScript.Instance.NodeWindowRect.width * 0.5f)));
         point.Y = Math.Min(0, Math.Max(-4096, -point.Y + (int)(uScript.Instance.NodeWindowRect.height * 0.5f) - (int)uScript.Instance.NodeToolbarRect.height));
         m_FlowChart.Location = point;
         m_FlowChart.Invalidate();
      }

      public void CenterOnNode(Node node)
      {
         // center on the center for now - later, we'll calculate zoom amount, etc.
         int halfWidth = (int)(uScript.Instance.NodeWindowRect.width / 2.0f);
         int halfHeight = (int)(uScript.Instance.NodeWindowRect.height / 2.0f);
         Point center = new Point(node.Bounds.Left + node.Bounds.Width / 2, node.Bounds.Top + node.Bounds.Height / 2);
         m_FlowChart.Location = new Point( Math.Min(0, Math.Max(-4096, -center.X + halfWidth)),
                                           Math.Min(0, Math.Max(-4096, -center.Y + halfHeight - (int)uScript.Instance.NodeToolbarRect.height)));
         m_FlowChart.Invalidate();
      }

      public void SelectNode(Guid guid)
      {
         m_FlowChart.SelectNodes(new Guid[] { guid });
      }

      public void ToggleNode(Guid guid)
      {
         m_FlowChart.ToggleNodes(new Guid[] { guid });
      }
      
      public bool IsDragging( )
      {
         return m_FlowChart.IsDragging( );
      }

      public bool CanDragDropOnNode( object o )
      {
         foreach ( Node node in m_FlowChart.Nodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;

            Point point = node.PointToClient( Cursor.Position );

            if ( point.X >= 0 && point.Y >= 0 && 
                 point.X <= node.Size.Width &&
                 point.Y <= node.Size.Height )
            {      
               string type = ScriptEditor.FindNodeType(entityNode);
               Type t = uScript.MasterComponent.GetAssemblyQualifiedType(type);

               if ( typeof(uScriptLogic).IsAssignableFrom(t) )
               {  
                  uScriptLogic logic = UnityEngine.ScriptableObject.CreateInstance( t ) as uScriptLogic;

                  bool result = null != logic.EditorDragDrop( o );
                  UnityEngine.ScriptableObject.DestroyImmediate( logic );

                  return result;
               }
               else if ( true == typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()) )
               {   
                  string destTypeString = null;

                  if ( entityNode.Instance != Parameter.Empty )
                  {
                     if ( entityNode is EntityMethod )
                     {
                        destTypeString = ((EntityMethod)entityNode).ComponentType;
                     }
                     else if ( entityNode is EntityEvent )
                     {
                        destTypeString = ((EntityEvent)entityNode).ComponentType;
                     }
                     else
                     {
                        destTypeString = entityNode.Instance.Type;
                     }
                  }
                  else if ( entityNode is LocalNode )
                  {
                     LocalNode local = (LocalNode) entityNode;
                     destTypeString = local.Value.Type;
                  }

                  if ( null != destTypeString )
                  {
                     destTypeString = destTypeString.Replace( "[]", "" );
                     Type destType = uScript.MasterComponent.GetType(destTypeString);

                     //see if the game object being dragged
                     //has a component type we can use
                     UnityEngine.GameObject gameObject = (UnityEngine.GameObject) o;
                     

                     //see if the game object being dragged
                     //has a component type we can use
                     if ( null != gameObject.GetComponent(destType) )
                     {
                        return true;
                     }

                     //see if the game object being dragged
                     //is the type we can use
                     if ( true == destType.IsAssignableFrom(o.GetType()) )
                     {
                        return true;
                     }
                  }
               }

               //only check the first node we intersect
               return false;
            }
         }

         return false;
      }

      public bool DoDragDrop( object o )
      {
         foreach ( Node node in m_FlowChart.Nodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;

            Point point = node.PointToClient( Cursor.Position );

            if ( point.X >= 0 && point.Y >= 0 && 
                 point.X <= node.Size.Width &&
                 point.Y <= node.Size.Height )
            {
               string type = ScriptEditor.FindNodeType(entityNode);
               Type t = uScript.MasterComponent.GetAssemblyQualifiedType(type);

               if ( typeof(uScriptLogic).IsAssignableFrom(t) )
               {  
                  uScriptLogic logic = UnityEngine.ScriptableObject.CreateInstance( t ) as uScriptLogic;
                  Hashtable hash = logic.EditorDragDrop( o );
               
                  Parameter [] parameters = entityNode.Parameters;

                  for ( int i = 0; i < parameters.Length; i++ )
                  {
                     object asset = null;

                     if ( hash.Contains(parameters[i].FriendlyName) )
                     {
                        asset = hash[ parameters[i].FriendlyName ];
                     }
                     else if ( hash.Contains(parameters[i].Name) )
                     {
                        asset = hash[ parameters[i].Name ];
                     }

                     if ( null != asset )
                     {
                        string key = "";
                        Type parameterType = uScript.MasterComponent.GetType(parameters[i].Type);

                        if ( uScriptConfig.ShouldAutoPackage(parameterType) )
                        {
                           //we have to package now because the returned parameter is just the string representation
                           //and it won't always be able to reference back to the actual object
                           key = uScript.PackageAsset( asset, parameterType );
                        }
                        else
                        {
                           key = asset as string;
                        }
                        
                        parameters[i].DefaultAsObject = key;                  
                     }
                  }

                  UnityEngine.ScriptableObject.DestroyImmediate( logic );

                  entityNode.Parameters = parameters;
                  RefreshScript( null );
                  return true;
               }
               else if ( true == typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType( )) )
               {
                  string destTypeString = null;

                  if ( entityNode.Instance != Parameter.Empty )
                  {
                     if ( entityNode is EntityMethod )
                     {
                        destTypeString = ((EntityMethod)entityNode).ComponentType;
                     }
                     else if ( entityNode is EntityEvent )
                     {
                        destTypeString = ((EntityEvent)entityNode).ComponentType;
                     }
                     else
                     {
                        destTypeString = entityNode.Instance.Type;
                     }
                  }
                  else if ( entityNode is LocalNode )
                  {
                     LocalNode local = (LocalNode) entityNode;
                     destTypeString = local.Value.Type;
                  }

                  if ( null != destTypeString )
                  {
                     bool isArray = destTypeString.Contains( "[]" );
                     destTypeString = destTypeString.Replace( "[]", "" );
                     Type destType = uScript.MasterComponent.GetType(destTypeString);

                     string name = null;

                     //see if the game object being dragged
                     //has a component type we can use
                     UnityEngine.GameObject gameObject = (UnityEngine.GameObject) o;
                     
                     //see if the game object being dragged
                     //has a component type we can use
                     if ( null != gameObject.GetComponent(destType) )
                     {
                        name = ((UnityEngine.Object)o).name;
                     }

                     //see if the game object being dragged
                     //is the type we can use
                     if ( true == destType.IsAssignableFrom(o.GetType()) )
                     {
                        name = ((UnityEngine.Object)o).name;
                     }

                     if ( null != name )
                     {
                        if ( entityNode.Instance != Parameter.Empty )
                        {
                           Parameter instance = entityNode.Instance;
                           instance.Default = ((UnityEngine.Object)o).name;
                           entityNode.Instance = instance;
                        }
                        else if ( entityNode is LocalNode )
                        {
                           LocalNode localNode = (LocalNode) entityNode;

                           Parameter value = localNode.Value;

                           if ( true == isArray && value.Default.Length >= 1 )
                           {
                              string [] existing = value.Default.Split( ',' );
                              
                              //if we find it already exists in the list, just return
                              //there is nothing else to do here
                              foreach ( string s in existing )
                              {
                                 if ( s == name ) return true;
                              }

                              value.Default = value.Default + ", " + name;
                           }
                           else
                           {
                              value.Default = name;
                           }

                           localNode.Value = value;

                           entityNode = localNode;
                        }

                        ScriptEditor oldEditor = m_ScriptEditor.Copy( );

                           m_ScriptEditor.AddNode( entityNode );   

                        m_ChangeStack.AddChange( new ChangeStack.Change("DragDrop", oldEditor, m_ScriptEditor.Copy( )) );

                        RefreshScript( null );
                        return true;
                     }
                  }
               }

               //only check the first node we intersect
               return false;
            }
         }

         return false;
      }

      public bool CanDragDropContextMenu( object o )
      {
         // first check to make sure we're not over a node
         foreach ( Node node in m_FlowChart.Nodes )
         {
            Point point = node.PointToClient( Cursor.Position );

            if ( point.X >= 0 && point.Y >= 0 && 
                 point.X <= node.Size.Width &&
                 point.Y <= node.Size.Height )
            {               
               return false;
            }
         }

         // are we a game object?
         return typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType());
      }
      
      public bool DoDragDropContextMenu( object[] objects )
      {
         //no nodes were intersected so allow context menu
         m_ContextObject = objects;
         m_ContextCursor = System.Windows.Forms.Cursor.Position;
         m_ContextCursor = m_FlowChart.PointToClient( m_ContextCursor );

         m_ContextMenuStrip.Items.Clear( );

         ToolStripMenuItem addMenu = new ToolStripMenuItem();
         addMenu.Text = "Add";

         Hashtable typeHash = new Hashtable( );
 
         foreach (object obj in objects )
         {
            UnityEngine.GameObject gameObject = obj as UnityEngine.GameObject;
            
            foreach ( UnityEngine.Component component in gameObject.GetComponents(typeof(UnityEngine.Component)) )
            {
               typeHash[ component.GetType().ToString() ] = true;
            }

            typeHash[ gameObject.GetType().ToString() ] = true;
         }
   
         string type         = typeof(UnityEngine.GameObject).ToString();
         string friendlyName = uScriptConfig.Variable.FriendlyName(type);

         ToolStripMenuItem friendlyMenu = null;
         
         friendlyMenu        = GetMenu(addMenu, "Place " + friendlyName + " Variable");
         friendlyMenu.Tag    = new LocalNode( "", type, "" );
         
         //add a separator
         friendlyMenu = GetMenu(addMenu, "<hr>");

         BuildAddMenu( addMenu, typeHash );

         m_ContextMenuStrip.Items.AddRange( addMenu.DropDownItems.Items.ToArray( ) );

         return true;
      }

      public void CopyToClipboard( )
      {
         List<EntityNode> entityNodes = new List<EntityNode>( );

         Detox.FlowChart.Node [] nodes = m_FlowChart.SelectedNodes;

         foreach ( Detox.FlowChart.Node node in nodes )
         {
            entityNodes.Add( ((DisplayNode)node).EntityNode );
         }

         Link [] links = m_FlowChart.SelectedLinks;

         foreach ( Link link in links )
         {
            entityNodes.Add( ((LinkNode)link.Tag) );
         }

         ScriptEditor scriptEditor = new ScriptEditor( "", ScriptEditor.EntityDescs, ScriptEditor.LogicNodes );

         foreach ( EntityNode node in entityNodes )
         {
            scriptEditor.AddNode( node );
         }

         System.IO.MemoryStream stream = new System.IO.MemoryStream( );
         scriptEditor.Write( stream );

         string base64 = Convert.ToBase64String( stream.GetBuffer( ) );
         base64 = "[SCRIPTEDITOR]" + base64;

         UnityEditor.EditorGUIUtility.systemCopyBuffer = base64;
         
         m_CopiedFromThisLocation = true;

         OnScriptModified( );
      }

      public void PasteFromClipboard( Point cursorPoint )
      {
         string text = GetClipboardData( );
         if ( null == text ) return;

         byte[] binary = Convert.FromBase64String( text );

         ScriptEditor scriptEditor = new ScriptEditor( "", ScriptEditor.EntityDescs, ScriptEditor.LogicNodes );
         if ( true == scriptEditor.Read( new System.IO.MemoryStream(binary)) )
         {
            List<Guid> guidsToSelect = new List<Guid>( );

            ScriptEditor oldEditor = m_ScriptEditor.Copy( );

            Hashtable remappedGuid = new Hashtable( );
				
			   // calculate a base point for this script chunk
			   float left = float.MaxValue, top = float.MaxValue, right = float.MinValue, bottom = float.MinValue;
			   foreach ( EntityNode entityNode in scriptEditor.EntityNodes )
			   {
               if ( typeof(LinkNode).IsAssignableFrom(entityNode.GetType()) ) continue;
			      if (entityNode.Position.X < left)   left = entityNode.Position.X;
			      if (entityNode.Position.Y < top)    top  = entityNode.Position.Y;
               if (entityNode.Position.X > right)  right = entityNode.Position.X;
               if (entityNode.Position.Y > bottom) bottom  = entityNode.Position.Y;
			   }
            Rectangle baseRect = new Rectangle( (int)left, (int)top, (int)(right - left), (int)(bottom - top) );

            foreach ( EntityNode entityNode in scriptEditor.EntityNodes )
            {
               //create a new guid for each old guid
               remappedGuid[ entityNode.Guid ] = Guid.NewGuid( );

               //skip links, we'll add after we can remap the source/dest guids
               if ( typeof(LinkNode).IsAssignableFrom(entityNode.GetType()) ) continue;

               //change node's guid so it doesn't conflict
               //from a previous paste or existing node
               EntityNode clone = entityNode;
               clone.Guid = (Guid) remappedGuid[ entityNode.Guid ];
   			   if (cursorPoint == Point.Empty)
   			   {
                  if (m_CopiedFromThisLocation)
                  {
                     // this paste was copied and then pasted without moving the graph or 
                     // opening a new one, offset it from the original position
                     clone.Position = new Point( clone.Position.X + 10, clone.Position.Y + 10 );
                  }
                  else
                  {
                     // this paste was copied from a location that may not be visible 
                     // anymore or might be in another graph, paste to center of canvas
                     int halfWidth = (int)(uScript.Instance.NodeWindowRect.width / 2.0f);
                     int halfHeight = (int)(uScript.Instance.NodeWindowRect.height / 2.0f);
                     Point centerView = new Point((int)(-m_FlowChart.Location.X + halfWidth), (int)(-m_FlowChart.Location.Y + halfHeight));
                     Point diff = new Point( clone.Position.X - baseRect.X, clone.Position.Y - baseRect.Y );
                     clone.Position = new Point( centerView.X - (int)(baseRect.Width / 2.0f) + diff.X, centerView.Y - (int)(baseRect.Height / 2.0f) + diff.Y);
                  }
   			   }
   			   else
   			   {
                  Point diff = new Point( clone.Position.X - baseRect.X, clone.Position.Y - baseRect.Y );
                  clone.Position = new Point( cursorPoint.X + diff.X, cursorPoint.Y + diff.Y );
   			   }
               m_ScriptEditor.AddNode( clone );
               guidsToSelect.Add( clone.Guid );
               m_Dirty = true;
            }

            foreach ( LinkNode link in scriptEditor.Links )
            {
               LinkNode clone = link;

               //use old guids to lookup the remapped guids
               //but ignore links of the source or destination didn't come across
               if ( false == remappedGuid.Contains(link.Source.Guid) ) continue;
               if ( false == remappedGuid.Contains(link.Destination.Guid) ) continue;

               clone.Source.Guid      = (Guid) remappedGuid[ link.Source.Guid ];
               clone.Destination.Guid = (Guid) remappedGuid[ link.Destination.Guid ];
               clone.Guid             = (Guid) remappedGuid[ link.Guid ];

               m_ScriptEditor.AddNode( clone );
               guidsToSelect.Add( clone.Guid );
               m_Dirty = true;
            }

            m_ChangeStack.AddChange( new ChangeStack.Change("Paste", oldEditor, m_ScriptEditor.Copy( )) );

            RefreshScript( guidsToSelect );
         }
      }

      private string GetClipboardData( )
      {
         string text = UnityEditor.EditorGUIUtility.systemCopyBuffer;
         if ( null == text ) return null;

         if ( false == text.StartsWith("[SCRIPTEDITOR]") ) return null;
         return text.Substring( "[SCRIPTEDITOR]".Length );
      }

      private void ExpandNodes( Node [] nodes )
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );

         if ( null == nodes ) nodes = m_FlowChart.Nodes;

         foreach ( Node node in nodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;
            List<Parameter> parameters = new List<Parameter>( );

            foreach ( Parameter p in entityNode.Parameters )
            {
               if ( true == CanExpandParameter(p) )
               {
                  Parameter clone = p;
                  clone.State &= ~Parameter.VisibleState.Hidden;
                  clone.State |= Parameter.VisibleState.Visible;

                  parameters.Add(clone);
               }
               else
               {
                  parameters.Add(p);
               }
            }

            if ( true == CanExpandParameter(entityNode.Instance) )
            {
               Parameter clone = entityNode.Instance;
               clone.State &= ~Parameter.VisibleState.Hidden;
               clone.State |= Parameter.VisibleState.Visible;

               entityNode.Instance = clone;
            }

            entityNode.Parameters = parameters.ToArray( );

            m_ScriptEditor.AddNode( entityNode );
         }

         m_ChangeStack.AddChange( new ChangeStack.Change("Expand Nodes", oldEditor, m_ScriptEditor.Copy( )) );

         RefreshScript( null );
      }

      private void CollapseNodes( Node [] nodes )
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );

         if ( null == nodes ) nodes = m_FlowChart.Nodes;
         
         foreach ( Node node in nodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;

            List<Parameter> parameters = new List<Parameter>( );

            foreach ( Parameter p in entityNode.Parameters )
            {
               if ( true == CanCollapseParameter(node.Guid, p) )
               {
                  Parameter clone = p;
                  clone.State &= ~Parameter.VisibleState.Visible;
                  clone.State |= Parameter.VisibleState.Hidden;

                  parameters.Add(clone);
               }
               else
               {
                  parameters.Add( p );
               }
            }

            if ( true == CanCollapseParameter(node.Guid, entityNode.Instance) )
            {
               Parameter clone = entityNode.Instance;
               clone.State &= ~Parameter.VisibleState.Visible;
               clone.State |= Parameter.VisibleState.Hidden;

               entityNode.Instance = clone;
            }

            entityNode.Parameters = parameters.ToArray( );

            m_ScriptEditor.AddNode( entityNode );
         }

         m_ChangeStack.AddChange( new ChangeStack.Change("Collapse Nodes", oldEditor, m_ScriptEditor.Copy( )) );

         RefreshScript( null );
      }
      
      public bool CanCollapseParameter(Guid guid, Parameter p)
      {
         if ( true == p.IsVisible( ) && false == p.IsLocked( ) )
         {
            if ( true == p.Input )
            {
               if ( m_ScriptEditor.GetLinksByDestination(guid, p.Name).Length > 0 )
               {
                  return false;
               }
            }
            if ( true == p.Output )
            {
               if ( m_ScriptEditor.GetLinksBySource(guid, p.Name).Length > 0 )
               {
                  return false;
               }
            }

            return true;
         }

         return false;
      }

      public bool CanExpandParameter(Parameter p)
      {
         if ( true == p.IsHidden( ) && false == p.IsLocked( ) )
         {
            return true;
         }

         return false;
      }

      private void m_MenuCopy_Click(object sender, EventArgs e)
      {
         CopyToClipboard( );
      }

      private void m_MenuPaste_Click(object sender, EventArgs e)
      {
         PasteFromClipboard( ContextCursor );
      }

      private void m_MenuExpand_Click(object sender, EventArgs e)
      {
         ExpandNodes( m_FlowChart.SelectedNodes );
      }

      private void m_MenuCollapse_Click(object sender, EventArgs e)
      {
         CollapseNodes( m_FlowChart.SelectedNodes );
      }

      private void m_MenuExpandAll_Click(object sender, EventArgs e)
      {
         ExpandNodes( null );
      }

      private void m_MenuCollapseAll_Click(object sender, EventArgs e)
      {
         CollapseNodes( null );
      }

      private void m_MenuSelectActive_Click(object sender, EventArgs e)
      {
         List<UnityEngine.GameObject> gameObjects = new List<UnityEngine.GameObject>( );

         foreach ( DisplayNode node in SelectedNodes )
         {
            if ( node.EntityNode is LocalNode )
            {
               UnityEngine.GameObject gameObject = UnityEngine.GameObject.Find(((LocalNode)node.EntityNode).Value.Default);
               if ( null != gameObject ) gameObjects.Add( gameObject );
            }

            if ( node.EntityNode is EntityEvent || node.EntityNode is EntityMethod )
            {
               UnityEngine.GameObject gameObject = UnityEngine.GameObject.Find(node.EntityNode.Instance.Default);
               if ( null != gameObject ) gameObjects.Add( gameObject );
            }
         }

         if ( gameObjects.Count > 0 )
         {
            //use the first one as the active one (i think this is where the camera is panned to)
            UnityEditor.Selection.activeGameObject = gameObjects[0];
         }

         //but make sure everything is selected
         UnityEditor.Selection.objects = gameObjects.ToArray( );
      }
   
      private void m_MenuAddLinkedVariable_Click(object sender, EventArgs e)
      {         
         MenuItem item = sender as MenuItem;
         AutoLinkDesc autoDesc = (AutoLinkDesc) item.Tag;

         EntityNode node = m_ScriptEditor.GetNode( autoDesc.Guid );

         Parameter linkTo = new Parameter( );

         if ( autoDesc.Name == "Instance" )
         {
            if ( node is EntityEvent )
            {
               EntityEvent entityEvent = (EntityEvent) node;
               linkTo = entityEvent.Instance;
            }
            if ( node is EntityMethod )
            {
               EntityMethod m = (EntityMethod) node;
               linkTo = m.Instance;
            }
         }
         else
         {
            foreach ( Parameter p in node.Parameters )
            {            
               if ( p.Name == autoDesc.Name )
               {
                  linkTo = p;
                  break;
               }
            }
         }

         if ( linkTo != new Parameter( ) )
         {
            ScriptEditor oldEditor = m_ScriptEditor.Copy( );
   
            Point point = m_FlowChart.PointToClient( Cursor.Position );

            LocalNode localNode;
            
            //if it's in input link we just want a single variable
            //not an array hooked up to it
            if ( true == linkTo.Input )
            {
               localNode = new LocalNode( "", linkTo.Type.Replace("[]", ""), "" );
            }
            else
            {
               //if it's an output link then need to use the exact link type
               localNode = new LocalNode( "", linkTo.Type, "" );               
            }
            localNode.Position = point;

            m_ScriptEditor.AddNode( localNode );

            LinkNode linkNode;

            linkNode = new LinkNode( localNode.Guid, localNode.Value.Name, node.Guid, linkTo.Name );

            string reason;

            //if we can't like from->to try linking the other way (to->from)
            if ( false == m_ScriptEditor.VerifyLink(linkNode, out reason) )
            {
               linkNode = new LinkNode( node.Guid, linkTo.Name, localNode.Guid, localNode.Value.Name );
            }

            if ( false == m_ScriptEditor.VerifyLink(linkNode, out reason) )
            {
               linkNode = new LinkNode( node.Guid, linkTo.Name, localNode.Guid, localNode.Value.Name );
            }

            m_ScriptEditor.AddNode( linkNode );

            m_Dirty = true;
            m_ChangeStack.AddChange( new ChangeStack.Change("Add", oldEditor, m_ScriptEditor.Copy( )) );

            RefreshScript( null );
         }
      }
   
      private void m_MenuAddNode_Click(object sender, EventArgs e)
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );

         MenuItem item = sender as MenuItem;
         EntityNode entityNode;
         Point offset = new Point(0, 0);
         if ( null != m_ContextObject && typeof(Object[]).IsAssignableFrom(m_ContextObject.GetType()) )
         {
            foreach (object obj in m_ContextObject)
            {
               entityNode = (EntityNode) ((EntityNode) item.Tag).Copy( );
      
               entityNode.Position = new Point( m_ContextCursor.X + offset.X, m_ContextCursor.Y + offset.Y );
               object contextObject = obj;
      
               if ( null != contextObject && typeof(UnityEngine.Object).IsAssignableFrom(contextObject.GetType()) )
               {
                  if ( entityNode.Instance != Parameter.Empty )
                  {
                     Parameter instance = entityNode.Instance;
                     instance.Default = ((UnityEngine.Object)contextObject).name;
                     entityNode.Instance = instance;
                  }
                  else if ( entityNode is LocalNode )
                  {
                     LocalNode local = (LocalNode) entityNode;
      
                     Parameter value = local.Value;
                     value.Default = ((UnityEngine.Object)contextObject).name;
                     local.Value = value;
                  
                     entityNode = local;
                  }
               }
               else
               {
                  if ( "" != uScript.Instance.AutoAssignInstance(entityNode) )
                  {
                     Parameter instance = entityNode.Instance;
                     instance.Default = uScript.Instance.AutoAssignInstance(entityNode);
                     entityNode.Instance = instance;
                  }
               }
      
               m_ScriptEditor.AddNode( entityNode );
               m_Dirty = true;
               
               offset.X += 10;
               offset.Y += 10;
            }
				
            m_ContextObject = null;
         }
         else
         {
            entityNode = (EntityNode) ((EntityNode) item.Tag).Copy( );
   
            entityNode.Position = new Point( m_ContextCursor.X, m_ContextCursor.Y );
            if ( "" != uScript.Instance.AutoAssignInstance(entityNode) )
            {
               Parameter instance = entityNode.Instance;
               instance.Default = uScript.Instance.AutoAssignInstance(entityNode);
            
               entityNode.Instance = instance;
            }

            //create a default unique name for the entity node
            //leaving it blank will cause it to get new internal names
            //based on its guid every time the script is loaded
            //so links won't be maintained
            if ( entityNode is ExternalConnection )
            {
               int i = 1;
               bool uniqueName = false;

               string name = "";
               
               while ( false == uniqueName )
               {
                  name = "External_" + i;

                  uniqueName = true;
                  
                  if ( m_ScriptEditor.Externals.Length > 0 )
                  {
                     foreach ( ExternalConnection external in m_ScriptEditor.Externals )
                     {
                        if ( external.Name.Default == name )
                        {
                           uniqueName = false;
                           break;
                        }
                     }
                  }

                  i++;
               }

               ExternalConnection clone = (ExternalConnection) entityNode;
               Parameter clonedParameter = clone.Name;
               clonedParameter.Default = name;

               clone.Name = clonedParameter;
               entityNode = clone;
            }


            m_ScriptEditor.AddNode( entityNode );
            m_Dirty = true;
         }

         m_ChangeStack.AddChange( new ChangeStack.Change("Add", oldEditor, m_ScriptEditor.Copy( )) );

         RefreshScript( null );
      }

      private void m_MenuUpgradeNode_Click(object sender, EventArgs e)
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );

         foreach ( DisplayNode node in SelectedNodes )
         {
            m_ScriptEditor.UpgradeNode( node.EntityNode );
         }

         m_ChangeStack.AddChange( new ChangeStack.Change("Upgrade Node", oldEditor, m_ScriptEditor.Copy( )) );

         RefreshScript( null );
      }

      private void m_MenuCreateList_Click(object sender, EventArgs e)
      {
         List<LocalNode> locals = new List<LocalNode>( );
         Hashtable guidHash = new Hashtable( );

         foreach ( DisplayNode node in SelectedNodes )
         {
            if ( node.EntityNode is LocalNode )
            {
               guidHash[ node.EntityNode.Guid ] = node.EntityNode;
               locals.Add( (LocalNode) node.EntityNode );
            }
         }

         if ( locals.Count > 0 )
         {
            int i;

            //figure out if all the selected nodes are the same type
            string type = locals[ 0 ].Value.Type.Replace( "[]", "" );

            for ( i = 0; i < locals.Count; i++ )
            {
               if ( type != locals[i].Value.Type.Replace("[]", "") ) break;
            }

            //all types are the same
            if ( i == locals.Count )
            {
               type = type + "[]";  
            }
            else
            {
               //default to base object type
               type = typeof(System.Object[]).ToString( );
            }

            LocalNode listNode = new LocalNode( "", type, "" );

            string instances = "";

            foreach ( LocalNode local in locals )
            {
               instances += local.Value.Default + ", ";
            }

            Parameter value = listNode.Value;
            value.Default = instances.Substring( 0, instances.Length - 2 );
            listNode.Value = value;

            listNode.Position = new Point( m_ContextCursor.X, m_ContextCursor.Y );
         
            //find everyone connected to us
            //and everyone we are connected to
            Hashtable connectToMe   = new Hashtable( );
            Hashtable connectFromMe = new Hashtable( );

            foreach ( LinkNode link in m_ScriptEditor.Links )
            {
               //does this link start at one of our selected nodes
               if ( guidHash.Contains(link.Source.Guid) && 
                    //and we haven't already tracked where it links to
                    //because now that we are becoming one node, we only need
                    //one of each destination instances
                    false == connectFromMe.Contains(link.Destination.Guid) )
               {
                  connectFromMe[ link.Destination.Guid ] = link;
               }
               else if ( guidHash.Contains(link.Destination.Guid) &&
                    //and we haven't already tracked where it links from
                    //because now that we are becoming one node, we only need
                    //one of each source instances
                    false == connectToMe.Contains(link.Source.Guid) )
               {
                  connectToMe[ link.Source.Guid ] = link;
               }
            }  

            ScriptEditor oldEditor = m_ScriptEditor.Copy( );

            //remove all existing nodes, which means the links go away too
            foreach ( LocalNode local in locals )
            {
               m_ScriptEditor.RemoveNode( local );
            }

            m_ScriptEditor.AddNode( listNode );

            //now relink to our single node
            foreach ( object o in connectToMe.Values )
            {
               LinkNode link = (LinkNode) o;

               LinkNode newLink = new LinkNode( link.Source.Guid, link.Source.Anchor, listNode.Guid, listNode.Value.Name );
               m_ScriptEditor.AddNode( newLink );
            }
            foreach ( object o in connectFromMe.Values )
            {
               LinkNode link = (LinkNode) o;

               LinkNode newLink = new LinkNode( listNode.Guid, listNode.Value.Name, link.Destination.Guid, link.Destination.Anchor );
               m_ScriptEditor.AddNode( newLink );
            }

            m_ChangeStack.AddChange( new ChangeStack.Change("Create List", oldEditor, m_ScriptEditor.Copy( )) );
            RefreshScript( null );
         }
      }
      
      public EntityNode GetLogicNode(String type)
      {
         foreach ( LogicNode node in m_ScriptEditor.LogicNodes )
         {
            if (node.Type == type) return node.Copy();
         }
         
         return null;
      }

      public void AddVariableNode(EntityNode entityNode)
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );
         
         entityNode.Position = new Point( m_ContextCursor.X, m_ContextCursor.Y );
         if ( "" != uScript.Instance.AutoAssignInstance(entityNode) )
         {
            Parameter instance = entityNode.Instance;
            instance.Default = uScript.Instance.AutoAssignInstance(entityNode);
            entityNode.Instance = instance;
         }
         
         m_ScriptEditor.AddNode( entityNode );
         m_Dirty = true;

         m_ChangeStack.AddChange( new ChangeStack.Change("Add", oldEditor, m_ScriptEditor.Copy( )) );

         RefreshScript( null );
      }

      public void SelectAllNodes()
      {
         List<Guid> guids = new List<Guid>( );

         foreach ( EntityNode node in m_ScriptEditor.EntityNodes )
         {
            guids.Add( node.Guid );
         }

         m_FlowChart.SelectNodes( guids.ToArray( ) );
      }
      
      public void SelectAllLinks()
      {
         foreach ( Link link in m_FlowChart.Links )
         {
            link.Selected = true;
         }
      }

      public void DeselectAll()
      {
         m_FlowChart.DeselectAll( );
      }

      public void DeleteSelectedNodes( )
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );

         Detox.FlowChart.Node [] nodes = m_FlowChart.SelectedNodes;

         foreach ( Detox.FlowChart.Node node in nodes )
         {
            m_ScriptEditor.RemoveNode( ((DisplayNode)node).EntityNode );
            m_Dirty = true;
         }

         Link [] links = m_FlowChart.SelectedLinks;

         foreach ( Link link in links )
         {
            m_ScriptEditor.RemoveNode( ((LinkNode)link.Tag) );
            m_Dirty = true;
         }

         m_ChangeStack.AddChange( new ChangeStack.Change("Delete", oldEditor, m_ScriptEditor.Copy( )) );

         RefreshScript( null );
      }

      private void m_MenuDeleteNode_Click(object sender, EventArgs e)
      {
         DeleteSelectedNodes( );
      }

      private void RefreshScript( List<Guid> guidsToSelect )
      {
         RefreshScript(guidsToSelect, false, Point.Empty);
      }

      public void RefreshScript( List<Guid> guidsToSelect, bool zoomExtents )
      {
         RefreshScript(guidsToSelect, zoomExtents, Point.Empty);
      }

      public void RefreshScript( List<Guid> guidsToSelect, bool zoomExtents, Point location )
      {
         RemoveEventHandlers( );

         float minX = Single.MaxValue, maxX = Single.MinValue, minY = Single.MaxValue, maxY = Single.MinValue;

         if (null == guidsToSelect)
         {
            guidsToSelect = new List<Guid>( );

            foreach ( FlowChart.Node selectedNode in m_FlowChart.SelectedNodes )
            {
               guidsToSelect.Add( selectedNode.Guid );
            }

            foreach ( FlowChart.Link selectedLink in m_FlowChart.SelectedLinks )
            {
               guidsToSelect.Add( ((EntityNode)selectedLink.Tag).Guid );
            }
         }

         m_FlowChart.SuspendLayout( );
         m_FlowChart.Clear( );

         foreach ( CommentNode commentNode in m_ScriptEditor.Comments )
         {
            CommentDisplayNode node = new CommentDisplayNode( commentNode );
            
            if ( m_ScriptEditor.IsNodeInstanceDeprecated(commentNode) ) node.Deprecate( );
         
            if ( guidsToSelect.Contains(node.Guid) )
            {
               node.Selected = true;
            }

            m_FlowChart.AddNode( node );

            if (node.Location.X < minX) minX = node.Location.X;
            if (node.Location.X + node.Size.Width > maxX) maxX = node.Location.X;
            if (node.Location.Y < minY) minY = node.Location.Y;
            if (node.Location.Y + node.Size.Height > maxY) maxY = node.Location.Y;
         }

         foreach ( EntityEvent entityEvent in m_ScriptEditor.Events )
         {
            EntityEventDisplayNode node = new EntityEventDisplayNode( entityEvent );
                     
            if ( m_ScriptEditor.IsNodeInstanceDeprecated(entityEvent) ) node.Deprecate( );

            if ( guidsToSelect.Contains(node.Guid) )
            {
               node.Selected = true;
            }

            m_FlowChart.AddNode( node );

            if (node.Location.X < minX) minX = node.Location.X;
            if (node.Location.X + node.Size.Width > maxX) maxX = node.Location.X;
            if (node.Location.Y < minY) minY = node.Location.Y;
            if (node.Location.Y + node.Size.Height > maxY) maxY = node.Location.Y;
         }

         foreach ( EntityMethod entityMethod in m_ScriptEditor.Methods )
         {
            EntityMethodDisplayNode node = new EntityMethodDisplayNode( entityMethod );

            if ( m_ScriptEditor.IsNodeInstanceDeprecated(entityMethod) ) node.Deprecate( );

            if ( guidsToSelect.Contains(node.Guid) )
            {
               node.Selected = true;
            }
         
            m_FlowChart.AddNode( node );

            if (node.Location.X < minX) minX = node.Location.X;
            if (node.Location.X + node.Size.Width > maxX) maxX = node.Location.X;
            if (node.Location.Y < minY) minY = node.Location.Y;
            if (node.Location.Y + node.Size.Height > maxY) maxY = node.Location.Y;
         }

         foreach ( EntityProperty entityProperty in m_ScriptEditor.Properties )
         {
            EntityPropertyDisplayNode node = new EntityPropertyDisplayNode( entityProperty );

            if ( m_ScriptEditor.IsNodeInstanceDeprecated(entityProperty) ) node.Deprecate( );

            if ( guidsToSelect.Contains(node.Guid) )
            {
               node.Selected = true;
            }
         
            m_FlowChart.AddNode( node );

            if (node.Location.X < minX) minX = node.Location.X;
            if (node.Location.X + node.Size.Width > maxX) maxX = node.Location.X;
            if (node.Location.Y < minY) minY = node.Location.Y;
            if (node.Location.Y + node.Size.Height > maxY) maxY = node.Location.Y;
         }

         foreach ( LocalNode localNode in m_ScriptEditor.Locals )
         {
            LocalNodeDisplayNode node = new LocalNodeDisplayNode( localNode );

            if ( m_ScriptEditor.IsNodeInstanceDeprecated(localNode) ) node.Deprecate( );

            if ( guidsToSelect.Contains(node.Guid) )
            {
               node.Selected = true;
            }
         
            m_FlowChart.AddNode( node );

            if (node.Location.X < minX) minX = node.Location.X;
            if (node.Location.X + node.Size.Width > maxX) maxX = node.Location.X;
            if (node.Location.Y < minY) minY = node.Location.Y;
            if (node.Location.Y + node.Size.Height > maxY) maxY = node.Location.Y;
         }

         foreach ( LogicNode logicNode in m_ScriptEditor.Logics )
         {
            LogicNodeDisplayNode node = new LogicNodeDisplayNode( logicNode );

            if ( m_ScriptEditor.IsNodeInstanceDeprecated(logicNode) ) node.Deprecate( );

            if ( guidsToSelect.Contains(node.Guid) )
            {
               node.Selected = true;
            }
         
            m_FlowChart.AddNode( node );

            if (node.Location.X < minX) minX = node.Location.X;
            if (node.Location.X + node.Size.Width > maxX) maxX = node.Location.X;
            if (node.Location.Y < minY) minY = node.Location.Y;
            if (node.Location.Y + node.Size.Height > maxY) maxY = node.Location.Y;
         }

         foreach ( ExternalConnection external in m_ScriptEditor.Externals )
         {
            ExternalConnectionDisplayNode node = new ExternalConnectionDisplayNode( external );

            if ( m_ScriptEditor.IsNodeInstanceDeprecated(external) ) node.Deprecate( );

            if ( guidsToSelect.Contains(node.Guid) )
            {
               node.Selected = true;
            }
         
            m_FlowChart.AddNode( node );

            if (node.Location.X < minX) minX = node.Location.X;
            if (node.Location.X + node.Size.Width > maxX) maxX = node.Location.X;
            if (node.Location.Y < minY) minY = node.Location.Y;
            if (node.Location.Y + node.Size.Height > maxY) maxY = node.Location.Y;
         }

         foreach ( OwnerConnection owner in m_ScriptEditor.Owners )
         {
            OwnerConnectionDisplayNode node = new OwnerConnectionDisplayNode( owner );

            if ( m_ScriptEditor.IsNodeInstanceDeprecated(owner) ) node.Deprecate( );

            if ( guidsToSelect.Contains(node.Guid) )
            {
               node.Selected = true;
            }
         
            m_FlowChart.AddNode( node );

            if (node.Location.X < minX) minX = node.Location.X;
            if (node.Location.X + node.Size.Width > maxX) maxX = node.Location.X;
            if (node.Location.Y < minY) minY = node.Location.Y;
            if (node.Location.Y + node.Size.Height > maxY) maxY = node.Location.Y;
         }

         foreach ( LinkNode link in m_ScriptEditor.Links )
         {
            Detox.FlowChart.Link chartLink = new Detox.FlowChart.Link( );
            chartLink.Tag = link;

            chartLink.Source.Node   = m_FlowChart.GetNode( link.Source.Guid );
            chartLink.Source.AnchorName = link.Source.Anchor;

            chartLink.Destination.Node   = m_FlowChart.GetNode( link.Destination.Guid );
            chartLink.Destination.AnchorName = link.Destination.Anchor;

            m_FlowChart.AddLink( chartLink );

            if ( guidsToSelect.Contains(link.Guid) )
            {
               chartLink.Selected = true;
            }
         }

         m_FlowChart.ResumeLayout( );
         m_FlowChart.Invalidate( );
			
         if (m_FlowChart.Nodes.Length > 0)
         {
            if (location != Point.Empty)
            {
               m_FlowChart.Location = location;
               m_FlowChart.Invalidate();
            }
            else if (zoomExtents)
            {
               // center on the center for now - later, we'll calculate zoom amount, etc.
               int halfWidth = (int)(uScript.Instance.NodeWindowRect.width / 2.0f);
               int halfHeight = (int)(uScript.Instance.NodeWindowRect.height / 2.0f);
               Point center = new Point((int)(minX + (maxX - minX) / 2.0f), (int)(minY + (maxY - minY) / 2.0f));
               m_FlowChart.Location = new Point(Math.Min(0, Math.Max(-4096, -center.X + halfWidth)), Math.Min(0, Math.Max(-4096, -center.Y + halfHeight - (int)uScript.Instance.NodeToolbarRect.height)));
               m_FlowChart.Invalidate();
            }
         }

         FlowchartSelectionModified( null, null );

         OnScriptModified();

         AddEventHandlers( );
      }

      private void FlowchartNodesModified(object sender, FlowchartNodesModifiedEventArgs e)
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );

         RemoveEventHandlers( );

            foreach ( FlowChart.Node node in e.Nodes )
            {
               EntityNode entityNode = ((DisplayNode)node).EntityNode;
               entityNode.Position = ((DisplayNode)node).Location;

               if ( entityNode is CommentNode )
               {
                  CommentNode clone = (CommentNode) entityNode;
                  
                  Parameter size = clone.Size;

                  size.DefaultAsObject = node.Size.Width + "," + node.Size.Height;
                  clone.Size = size;

                  entityNode = clone;
               }

               m_ScriptEditor.AddNode( entityNode );
            }
         
            m_Dirty = true;

         AddEventHandlers( );

         if ( false == oldEditor.Equals(m_ScriptEditor) )
         {
            m_ChangeStack.AddChange( new ChangeStack.Change("Node Modified", oldEditor, m_ScriptEditor.Copy( )) );
            RefreshScript( null );
         }
      }

      private void FlowchartSelectionModified(object sender, EventArgs e)
      {
         List<PropertyGridParameters> gridParameters = new List<PropertyGridParameters>( );

         foreach ( Node node in m_FlowChart.SelectedNodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;

            string name = node.Name;
            if ( ((DisplayNode)node).Deprecated ) name += " ***DEPRECATED, MUST BE REPLACED***";

            PropertyGridParameters parameters = new PropertyGridParameters( name, entityNode, this ); 
            parameters.AddParameters( "Parameters", entityNode.Parameters );
            parameters.AddParameters( "Comment", new Parameter[] {entityNode.ShowComment, entityNode.Comment} );
            parameters.AddParameters( "Instance",new Parameter[] {entityNode.Instance} );

            gridParameters.Add( parameters );
         }

         m_PropertyGrid.SelectedObjects = gridParameters.ToArray( );

         OnScriptModified( );
      }

      void m_PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );
         
         RemoveEventHandlers( );

         foreach ( object o in m_PropertyGrid.SelectedObjects )
         {
            PropertyGridParameters p = (PropertyGridParameters) o;

            EntityNode entityNode  = p.EntityNode;            
            entityNode.Parameters  = p.GetParameters( "Parameters" );
            entityNode.ShowComment = p.GetParameters( "Comment" ) [ 0 ];
            entityNode.Comment     = p.GetParameters( "Comment" ) [ 1 ];
            entityNode.Instance    = p.GetParameters( "Instance" )[ 0 ];

            m_ScriptEditor.AddNode( entityNode );
         }

         AddEventHandlers( );

         if ( false == oldEditor.Equals(m_ScriptEditor) )
         {
            m_ChangeStack.AddChange( new ChangeStack.Change("Node Modified", oldEditor, m_ScriptEditor.Copy( )) );
            RefreshScript( null );
         }
      }

      private void FlowchartLinkCreated(object sender, FlowchartLinkCreatedEventArgs e)
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );

         RemoveEventHandlers( );

            LinkNode link = new LinkNode( e.Link.Source.Node.Guid, e.Link.Source.Anchor.Name, e.Link.Destination.Node.Guid, e.Link.Destination.Anchor.Name );
            m_ScriptEditor.AddNode( link );
            m_Dirty = true;

         AddEventHandlers( );

         m_ChangeStack.AddChange( new ChangeStack.Change("Link Created", oldEditor, m_ScriptEditor.Copy( )) );

         RefreshScript( null );
      }

      private void FlowchartPointRender(object sender, FlowchartPointRenderEventArgs e)
      {
         Node node = sender as Node;

         //the point rendering is the source connection
         if ( e.Connecting && node == m_FlowChart.LinkStartNode )
         {
            e.Point.StyleName += "_connecting";
            node.AnchorPoints[ e.Index ] = e.Point;
            return;
         }

         //see if the point rendering is the potential destination connection
         if ( e.Connecting && null != m_FlowChart.LinkStartNode )
         {
            LinkNode linkNode = new LinkNode( m_FlowChart.LinkStartNode.Guid, m_FlowChart.LinkStartAnchor.Name, 
                                              node.Guid, e.Point.Name );

            //if it's allowed to connect then update the style
            string reason;

            if ( true == m_ScriptEditor.VerifyLink(linkNode, out reason) )
            {
               e.Point.StyleName += "_connecting";
               node.AnchorPoints[ e.Index ] = e.Point;            
               return;
            }
         }

         //everything else failed - so just render selected if we are selected
         if ( node.Selected )
         {
            e.Point.StyleName += "_selected";
            node.AnchorPoints[ e.Index ] = e.Point;
         }
      }

      private void FlowchartLocationChanged(object sender, EventArgs e)
      {
         m_CopiedFromThisLocation = false;
      }
      
      private void RemoveEventHandlers( )
      {
         m_FlowChart.NodesModified     -= FlowchartNodesModified;
         m_FlowChart.SelectionModified -= FlowchartSelectionModified;
         m_FlowChart.LinkCreated       -= FlowchartLinkCreated;
         m_FlowChart.PointRender       -= FlowchartPointRender;
         m_FlowChart.LocationChanged   -= FlowchartLocationChanged;

         m_PropertyGrid.PropertyValueChanged -= new PropertyValueChangedEventHandler(m_PropertyGrid_PropertyValueChanged);
      }

      public void AddEventHandlers( )
      {
         m_FlowChart.NodesModified     += FlowchartNodesModified;
         m_FlowChart.SelectionModified += FlowchartSelectionModified;
         m_FlowChart.LinkCreated       += FlowchartLinkCreated;
         m_FlowChart.PointRender       += FlowchartPointRender;
         m_FlowChart.LocationChanged   += FlowchartLocationChanged;

         m_PropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(m_PropertyGrid_PropertyValueChanged);
      }

      private ToolStripMenuItem GetItem(ToolStripMenuItem menu, string name)
      {
         foreach ( ToolStripItem item in menu.DropDownItems.Items )
         {
            if ( item.Text == name ) 
            {
               return (ToolStripMenuItem) item;
            }
         }

         return null;
      }

      private ToolStripMenuItem GetMenu(ToolStripMenuItem menu, string path)
      {
         string []keys = path.Split( '/' );

         ToolStripMenuItem subMenu = menu;
         
         foreach ( string key in keys )
         {
            if ( null == GetItem(subMenu, key) )
            {
               subMenu.DropDownItems.Add( new ToolStripMenuItem(key) );
            } 

            subMenu = GetItem(subMenu, key);
         }

         return subMenu;
      }

      private void m_ContextMenuStrip_Opening(object sender, CancelEventArgs args)
      {
         m_ContextObject = null;
         m_ContextCursor = System.Windows.Forms.Cursor.Position;
         m_ContextCursor = m_FlowChart.PointToClient( m_ContextCursor );

         m_ContextMenuStrip.Items.Clear( );

         ToolStripMenuItem addMenu      = new ToolStripMenuItem();
         ToolStripMenuItem copyMenu     = new ToolStripMenuItem();
         ToolStripMenuItem pasteMenu    = new ToolStripMenuItem();
         ToolStripMenuItem upgradeNode  = new ToolStripMenuItem();
         ToolStripMenuItem collapseMenu = new ToolStripMenuItem();
         ToolStripMenuItem expandMenu   = new ToolStripMenuItem();
         ToolStripMenuItem collapseAll  = new ToolStripMenuItem();
         ToolStripMenuItem expandAll    = new ToolStripMenuItem();
         ToolStripMenuItem selectActive = new ToolStripMenuItem();

         m_ContextMenuStrip.Items.Add( addMenu );
         
         if ( m_FlowChart.SelectedNodes.Length > 0 || m_FlowChart.SelectedLinks.Length > 0 )
         {
            ToolStripMenuItem delete = new ToolStripMenuItem( "Delete Selected" );
            delete.Click += new System.EventHandler(m_MenuDeleteNode_Click);

            m_ContextMenuStrip.Items.Add( delete );
         }

         m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );
         
         if ( CanCopy )
         {
            copyMenu.Name = "m_Copy";
            copyMenu.Size = new System.Drawing.Size(152, 22);
            copyMenu.Text = "Copy";
            copyMenu.Click += new System.EventHandler(m_MenuCopy_Click);

            m_ContextMenuStrip.Items.Add( copyMenu );
         }
         
         if ( CanPaste )
         {
            pasteMenu.Name = "m_Paste";
            pasteMenu.Size = new System.Drawing.Size(152, 22);
            pasteMenu.Text = "Paste";
            pasteMenu.Click += new System.EventHandler(m_MenuPaste_Click);

            m_ContextMenuStrip.Items.Add( pasteMenu );
         }

         if ( CanCopy || CanPaste )
         {
            m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );
         }

         if ( CanExpand )
         {
            expandMenu.Name = "m_ExpandMenu";
            expandMenu.Size = new System.Drawing.Size(152, 22);
            expandMenu.Text = "E&xpand Selection";
            expandMenu.Click += new System.EventHandler(m_MenuExpand_Click);

            m_ContextMenuStrip.Items.Add( expandMenu );
         }

         if ( CanCollapse )
         {
            collapseMenu.Name = "m_CollapseMenu";
            collapseMenu.Size = new System.Drawing.Size(152, 22);
            collapseMenu.Text = "Co&llapse Selection";
            collapseMenu.Click += new System.EventHandler(m_MenuCollapse_Click);

            m_ContextMenuStrip.Items.Add( collapseMenu );
         }

         if ( CanExpand || CanCollapse )
         {
            m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );
         }

         expandAll.Name = "m_ExpandAllMenu";
         expandAll.Size = new System.Drawing.Size(152, 22);
         expandAll.Text = "Expand All";
         expandAll.Click += new System.EventHandler(m_MenuExpandAll_Click);

         m_ContextMenuStrip.Items.Add( expandAll );

         collapseAll.Name = "m_CollapseAllMenu";
         collapseAll.Size = new System.Drawing.Size(152, 22);
         collapseAll.Text = "Collapse All";
         collapseAll.Click += new System.EventHandler(m_MenuCollapseAll_Click);

         m_ContextMenuStrip.Items.Add( collapseAll );
         
         m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );


         addMenu.Name = "m_Add";
         addMenu.Size = new System.Drawing.Size(152, 22);
         addMenu.Text = "Add";

         BuildAddMenu( addMenu, null );

         //see if we can create an automatic link for the user
         foreach ( Node node in m_FlowChart.Nodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;
            if ( entityNode is LocalNode ) continue;

            Point position = System.Windows.Forms.Cursor.Position;
            position = node.PointToClient( position );

            AnchorPoint hitPoint = new AnchorPoint( );

            if ( node.PointInAnchorPoint(position, ref hitPoint) )
            {
               bool allowLink = false;

               if ( hitPoint.Name == entityNode.Instance.Name &&
                    hitPoint.CanSource )
               {
                  allowLink = true;
               }
               else
               {
                  foreach ( Parameter p in entityNode.Parameters )
                  {
                     if ( p.Name == hitPoint.Name &&
                          hitPoint.CanSource )
                     {
                        allowLink = true;
                        break;
                     }
                  }
               }

               if ( true == allowLink )
               {
                  ToolStripMenuItem createLink = new ToolStripMenuItem( "Create Linked Variable" );
                  
                  AutoLinkDesc autoLink;
                  autoLink.Guid = entityNode.Guid;
                  autoLink.Name = hitPoint.Name;

                  createLink.Name   = "m_TypedLocalNode";
                  createLink.Size   = new System.Drawing.Size(152, 22);
                  createLink.Text   = "Create Linked Variable";
                  createLink.Tag    = autoLink;
                  createLink.Click += new System.EventHandler(m_MenuAddLinkedVariable_Click);

                  m_ContextMenuStrip.Items.Add( createLink );
               }

               break;
            }
         }

         if ( SelectedNodes.Length > 0 )
         {  
            foreach ( DisplayNode node in SelectedNodes )
            {
               if ( node.EntityNode is LocalNode ) 
               {
                  ToolStripMenuItem objectList = new ToolStripMenuItem();

                  objectList.Name = "m_ObjectList";
                  objectList.Size = new System.Drawing.Size(152, 22);
                  objectList.Text = "&Create List";
                  objectList.Click += new System.EventHandler(m_MenuCreateList_Click);

                  m_ContextMenuStrip.Items.Add( objectList );
                  break;
               }
            }

            int allowSelectActive = 0;

            foreach ( DisplayNode node in SelectedNodes )
            {
               if ( node.EntityNode is LocalNode )
               {
                  if ( null != UnityEngine.GameObject.Find(((LocalNode)node.EntityNode).Value.Default) )
                  {
                     ++allowSelectActive;
                     if ( allowSelectActive > 1 ) break;
                  }
               }

               if ( node.EntityNode is EntityEvent || node.EntityNode is EntityMethod )
               {
                  if ( null != UnityEngine.GameObject.Find(node.EntityNode.Instance.Default) )
                  {
                     ++allowSelectActive;
                     if ( allowSelectActive > 1 ) break;
                  }
               }
            }

            if ( allowSelectActive > 0 )
            {
               selectActive.Name = "m_SelectActive";
               selectActive.Size = new System.Drawing.Size(152, 22);
               selectActive.Click += new System.EventHandler(m_MenuSelectActive_Click);

               if ( 1 == allowSelectActive )
               {
                  selectActive.Text = "Select GameObject in Viewport";
               }
               else
               {
                  selectActive.Text = "Select GameObjects in Viewport";
               }

               m_ContextMenuStrip.Items.Add( selectActive );
            }
            
            foreach ( DisplayNode node in SelectedNodes )
            {
               if ( true == node.Deprecated )
               {
                  upgradeNode.Name = "m_UpgradeNode";
                  upgradeNode.Size = new System.Drawing.Size(152, 22);
                  upgradeNode.Text = "Upgrade Node";
                  upgradeNode.Click += new System.EventHandler(m_MenuUpgradeNode_Click);

                  m_ContextMenuStrip.Items.Add( upgradeNode );
                  break;
               }
            }
         }

         ToolStripMenuItem comment  = new ToolStripMenuItem();
         ToolStripMenuItem external = new ToolStripMenuItem();

         comment.Name = "m_AddComment";
         comment.Size = new System.Drawing.Size(152, 22);
         comment.Text = "&Comment";
         comment.Click += new System.EventHandler(m_MenuAddNode_Click);
         comment.Tag  = new CommentNode( "" );

         external.Name = "m_AddExternal";
         external.Size = new System.Drawing.Size(152, 22);
         external.Text = "&External Connection";
         external.Click += new System.EventHandler(m_MenuAddNode_Click);
         external.Tag  = new ExternalConnection( Guid.NewGuid( ) );

         addMenu.DropDownItems.Add( comment );
         addMenu.DropDownItems.Add( external );
      }

      private void BuildAddMenu(ToolStripMenuItem addMenu, Hashtable typeHash)
      {
         string sceneMenu = "Scene (" + System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene) + ")";

         foreach ( EntityDesc desc in m_ScriptEditor.EntityDescs )
         {
               //if we care about types, and this type isn't registered, ignore it
            if ( null != typeHash && false == typeHash.Contains(desc.Type) ) continue;

            if ( desc.Events.Length > 0 )
            {   
               string categoryName = uScript.FindNodePath(sceneMenu + "/Events", desc.Type);

               ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName );

               foreach ( EntityEvent e in desc.Events )
               {
                  if ( true == uScript.IsNodeTypeDeprecated(e) ) continue;

                  ToolStripItem item = friendlyMenu.DropDownItems.Add( e.FriendlyType );
                  item.Tag = e;

                  item.Click += new System.EventHandler(m_MenuAddNode_Click);
               }
            }

            if ( desc.Methods.Length > 0 )
            {
               string categoryName = uScript.FindNodePath(sceneMenu + "/Actions", desc.Type);

               string friendlyName = uScriptConfig.Variable.FriendlyName(desc.Type);
               ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName);

               Hashtable signatures = new Hashtable( );

               foreach ( EntityMethod e in desc.Methods )
               {
                  if ( true == uScript.IsNodeTypeDeprecated(e) ) continue;

                  if ( false == signatures.Contains(e.Input.FriendlyName) ) 
                  {
                     signatures[ e.Input.FriendlyName ] = new List<EntityMethod>( );
                  }

                  List<EntityMethod> methodList = signatures[ e.Input.FriendlyName ] as List<EntityMethod>;

                  methodList.Add( e );
               }

               foreach ( Object o in signatures.Values )
               {
                  List<EntityMethod> methods = o as List<EntityMethod>;

                  if ( methods.Count > 1 )
                  {
                     ToolStripMenuItem subMenu = new ToolStripMenuItem( methods[0].Input.FriendlyName );
                     friendlyMenu.DropDownItems.Add( subMenu );

                     foreach ( EntityMethod m in methods )
                     {
                        ToolStripItem item = subMenu.DropDownItems.Add( m.Input.FriendlyName + BuildSignature(m)  );
                        item.Tag = m;

                        item.Click += new System.EventHandler(m_MenuAddNode_Click);
                     }
                  }
                  else
                  {
                     ToolStripItem item = friendlyMenu.DropDownItems.Add( methods[ 0 ].Input.FriendlyName + BuildSignature(methods[0]) );
                     item.Tag = methods[0];

                     item.Click += new System.EventHandler(m_MenuAddNode_Click);
                  }
               }
            }

            if ( desc.Properties.Length > 0 )
            {
               string categoryName = uScript.FindNodePropertiesPath(sceneMenu + "/Properties/" + desc.Type, desc.Type);

               foreach ( EntityProperty e in desc.Properties )
               {
                  if ( true == uScript.IsNodeTypeDeprecated(e) ) continue;

                  ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName );

                  ToolStripItem item = friendlyMenu.DropDownItems.Add( e.Parameter.FriendlyName );
                  item.Tag = e;

                  item.Click += new System.EventHandler(m_MenuAddNode_Click);
               }
            }
         }

         foreach ( LogicNode node in m_ScriptEditor.LogicNodes )
         {
            if ( true == uScript.IsNodeTypeDeprecated(node) ) continue;

            //if we care about types, and this type isn't registered, ignore it
            if ( null != typeHash && false == typeHash.Contains(node.Type) ) continue;

            string categoryName = uScript.FindNodePath(sceneMenu + "/Logic", node.Type);

            string friendlyName = node.FriendlyName;
            ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName);

            friendlyMenu.Tag = node;
            friendlyMenu.Click += new System.EventHandler(m_MenuAddNode_Click);
         }

         foreach ( string type in m_ScriptEditor.Types )
         {
            //if we care about types, and this type isn't registered, ignore it
            if ( null != typeHash && false == typeHash.Contains(type) ) continue;

            string categoryName = uScriptConfig.Variable.Category(type);
            if ("" == categoryName) categoryName = sceneMenu + "/Variables";

            string friendlyName = uScriptConfig.Variable.FriendlyName(type);

            ToolStripMenuItem friendlyMenu = null;
            
            if ( null == typeHash )
            {
               friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName );
            }
            else
            {
               friendlyMenu = GetMenu(addMenu, "Place " + friendlyName + " Variable");
            }

            friendlyMenu.Tag = new LocalNode( "", type, "" );
            friendlyMenu.Click += new System.EventHandler(m_MenuAddNode_Click);
         }

         if ( null == typeHash )
         {
            string categoryName = "Variables";
            string friendlyName = "Owner GameObject";

            ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName );

            friendlyMenu.Tag = new OwnerConnection( Guid.NewGuid( ) );
            friendlyMenu.Click += new System.EventHandler(m_MenuAddNode_Click);
         }
         
         ReformatMenu( addMenu );
      }

      private void ReformatMenu(ToolStripMenuItem item)
      {
         if ( null == item ) return;
         
         if ( item.DropDownItems.Items.Count > 0 )
         {
            item.Text += "...";
         }

         foreach ( ToolStripItem subItem in item.DropDownItems.Items )
         {
            ReformatMenu( subItem as ToolStripMenuItem );
         }
      }

      private string BuildSignature(EntityNode node)
      {
         if ( 0 == node.Parameters.Length ) return "";

         string sig = "(";
         
         foreach ( Parameter p in node.Parameters )
         {
            sig += "[";
            if ( true == p.Input && true == p.Output )
            {
               sig += "in/out";
            }
            else if ( true == p.Input )
            {
               sig += "in";
            }
            else if ( true == p.Output )
            {
               sig += "out";
            }

            sig += "]" + p.Name + ", ";
         }

         if ( node.Parameters.Length > 0 )
         {
            sig = sig.Substring( 0, sig.Length - 2 );
         }

         sig += ")";
      
         return sig;
      }
   }

   public class DisplayNode : Detox.FlowChart.Node
   {
      protected struct Socket
      {
         public enum Align
         {
            Invalid = -1,
            Bottom, Left, Right, Center
         }
			
         public bool   Input;
         public bool   Output;
         public string InternalName;
         public string FriendlyName;
         public string Type;
         public Align  Alignment;
      }

      protected string NodeStyle = "node_default";

      override public bool Selected 
      {
         set 
         { 
            m_Selected = value; 
    
            UpdateStyleName();
   
            base.Selected = value;
         }
      }

      private bool m_Deprecated = false;

      public bool Deprecated { get { return m_Deprecated; } }
      public void Deprecate( )
      {
         m_Deprecated = true;

         UpdateStyleName();
      }

      private EntityNode m_EntityNode;
      public EntityNode EntityNode { get { return m_EntityNode; } }

      Socket [] m_Sockets = new Socket[ 0 ];

      public override Guid Guid { get { return m_EntityNode.Guid; } }

      protected void UpdateNode(EntityNode node)
      {
         m_EntityNode = node;

         UpdateStyleName(); 
      }

      public DisplayNode()
      { 
         UpdateStyleName(); 
      }

      public DisplayNode(EntityNode entityNode)
      {
         m_EntityNode = entityNode;
         
         UpdateStyleName();
      }

      protected string FormatName(Socket socket)
      {
         return socket.FriendlyName;
      }

      protected virtual void LeftPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints)
      {
         SizeF titleLength = Graphics.sMeasureString( Name, NodeStyle );

         float xStart= uScriptConfig.Style.LeftPad;
         float yStep = uScriptConfig.Style.PointSize + uScriptConfig.Style.BottomSocketLabelGapSize;

         float y = (uScriptConfig.Style.TopPad + uScriptConfig.Style.TitleTopBottomPad + titleLength.Height);

         foreach ( Socket socket in sockets )
         {
            if ( socket.Alignment == Socket.Align.Left )
            {
               SizeF textLength = Graphics.sMeasureString( FormatName(socket), "socket_text" );

               AnchorPoint point = new AnchorPoint( );
               TextPoint textPoint = new TextPoint( );

               point.Name   = socket.InternalName;
               point.X      = xStart;
               point.Y      = y;
               point.Width  = uScriptConfig.Style.PointSize;
               point.Height = uScriptConfig.Style.PointSize;
               point.Input  = socket.Input;
               point.Output = socket.Output;
               point.CanSource = true;
               point.StyleName = NodeStyle + "_socket_io";

               points.Add( point );

               textPoint.Name = FormatName(socket);
               textPoint.X = xStart + uScriptConfig.Style.PointSize + uScriptConfig.Style.IOSocketLabelHorizontalOffset;
               textPoint.Y = (y - (textLength.Height / 2 + uScriptConfig.Style.IOSocketLabelVerticalOffset));
               textPoint.StyleName = "socket_text";
               textPoints.Add( textPoint );
            
               y += (yStep + textLength.Height);
            }
         }
      }

      protected virtual void RightPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints)
      {
         SizeF titleLength = Graphics.sMeasureString( Name, NodeStyle );

         float xStart = Size.Width - uScriptConfig.Style.RightPad;
         float yStep  = uScriptConfig.Style.PointSize + uScriptConfig.Style.BottomSocketLabelGapSize;

         float y = (uScriptConfig.Style.TopPad + uScriptConfig.Style.TitleTopBottomPad + titleLength.Height);

         foreach ( Socket socket in sockets )
         {
            if ( socket.Alignment == Socket.Align.Right )
            {
               SizeF textLength = Graphics.sMeasureString( FormatName(socket), "socket_text" );

               AnchorPoint point = new AnchorPoint( );
               TextPoint textPoint = new TextPoint( );

               point.Name = socket.InternalName;
               point.X      = xStart;
               point.Y      = y;
               point.Width  = uScriptConfig.Style.PointSize;
               point.Height = uScriptConfig.Style.PointSize;
               point.Input  = socket.Input;
               point.Output = socket.Output;
               point.CanSource = true;
               point.StyleName = NodeStyle + "_socket_io";               

               points.Add( point );

               textPoint.Name = FormatName(socket);
               textPoint.X =  (xStart - (uScriptConfig.Style.PointSize + textLength.Width)) - uScriptConfig.Style.IOSocketLabelHorizontalOffset;
               textPoint.Y =  (y - (textLength.Height / 2)) - uScriptConfig.Style.IOSocketLabelVerticalOffset;
               textPoint.StyleName = "socket_text";
               textPoints.Add( textPoint );
            
               y += (yStep + textLength.Height);
            }
         }
      }

      protected virtual void BottomPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints)
      {
         float yStart = Size.Height - uScriptConfig.Style.BottomPad;
        
         float totalTextWidth = 0;
         float xStep = uScriptConfig.Style.BottomSocketLabelGapSize + uScriptConfig.Style.PointSize + uScriptConfig.Style.BottomSocketLabelGapSize;

         foreach ( Socket socket in sockets )
         {
            if ( socket.Alignment == Socket.Align.Bottom )
            {
               SizeF textLength = Graphics.sMeasureString( FormatName(socket), "socket_text" );

               totalTextWidth += xStep;
               totalTextWidth += textLength.Width;
            }
         }

         //now we know the total text width, we can figure out where to start it
         float x = (Size.Width - uScriptConfig.Style.RightShadow - totalTextWidth) / 2;
         
         //starting offset to draw the point and text for each x position
         //point pad preceeding the x and half the point size
         float xOffset = uScriptConfig.Style.BottomSocketLabelGapSize + uScriptConfig.Style.PointSize / 2;

         foreach ( Socket socket in sockets )
         {
            if ( socket.Alignment == Socket.Align.Bottom )
            {
               AnchorPoint point = new AnchorPoint( );
               TextPoint textPoint = new TextPoint( );

               SizeF textLength = Graphics.sMeasureString( FormatName(socket), "socket_text" );

               string additionalFlag = "";
               float y = yStart;

               if ( socket.Output == true && socket.Input == false ) 
               {
                  additionalFlag = "out_";
                  y += uScriptConfig.Style.OutputOnlyPointOffset;
               }

               point.Name = socket.InternalName;
               point.X      = x + textLength.Width / 2 + xOffset;
               point.Y      = y;
               point.Width  = uScriptConfig.Style.PointSize;
               point.Height = uScriptConfig.Style.PointSize;
               point.CanSource = true;
               point.Input  = socket.Input;
               point.Output = socket.Output;

               string style = NodeStyle;
               point.StyleName = style + "_socket_" + additionalFlag + "variable_" +
                                 uScriptConfig.Variable.FriendlyStyleName(socket.Type);
               
               points.Add( point );

               textPoint.Name = FormatName(socket);
               textPoint.X = x + xOffset;
               textPoint.Y = (yStart - uScriptConfig.Style.PointSize - textLength.Height + uScriptConfig.Style.BottomSocketLabelGap);
               textPoint.StyleName = "socket_text";
               textPoints.Add( textPoint );
            
               x += (xStep + textLength.Width);
            }
         }
      }

      protected virtual void CenterPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints)
      {
         foreach ( Socket socket in sockets )
         {
            if ( socket.Alignment == Socket.Align.Center )
            {
               if ( socket.Input == true || socket.Output == true )
               {
                  AnchorPoint point = new AnchorPoint( );
                  point.Name   = socket.InternalName;
                  point.X      = Size.Width / 2;
                  point.Y      = Size.Height / 2;

                  point.Width  = Size.Width;
                  point.Height = Size.Height;
                  
                  point.Input  = socket.Input;
                  point.Output = socket.Output;
                  point.CanSource = false;
                  point.StyleName = "clear_socket";
                  points.Add( point );
               }

               if ( socket.Input == false && socket.Output == false )
               {
                  SizeF size = Graphics.sMeasureString( FormatName(socket), "socket_text" );

                  TextPoint textPoint = new TextPoint( );

                  textPoint.Name = FormatName(socket);
                  textPoint.X = (Size.Width - uScriptConfig.Style.RightShadow - size.Width) / 2;
                  textPoint.Y = (Size.Height - uScriptConfig.Style.BottomShadow - size.Height) / 2;
                  textPoint.StyleName = "socket_text";

                  if ( textPoint.X < 0 ) textPoint.X = 0;
                  if ( textPoint.Y < 0 ) textPoint.Y = 0;

                  textPoints.Add( textPoint );
               }
            }
         }
      }

      protected void UpdateSockets(Socket []sockets)
      {  
         AnchorPoints = new AnchorPoint[0];
         TextPoints   = new TextPoint  [0];
         
         m_Sockets = sockets;

         PreparePoints( );
      }
      
      protected void UpdateStyleName()
      {
         if ( false == Selected ) StyleName = NodeStyle;
         else 
         {
            string []subString = NodeStyle.Split( '_' );
            StyleName = subString[0] + "_selected";
         }

         if ( true == m_Deprecated )
         {
            StyleName = "node_deprecated";
         }
      }

      public override void OnPaint( PaintEventArgs e )
      {
         UpdateStyleName();   // remove this later when we figure out why removing it doesn't initialize StyleName correctly
   
         if (m_EntityNode.Comment != Parameter.Empty && !String.IsNullOrEmpty(m_EntityNode.Comment.Default))
         {
            String comment = m_EntityNode.Comment.Default;
            Point location = new Point( Location.X + Parent.Location.X, Location.Y + Parent.Location.Y );
         
            e.Graphics.FillRectangle("title_comment", new Rectangle(location.X, location.Y, Size.Width, Size.Height), comment);
         }

         base.OnPaint( e );
      }

      protected virtual Size CalculateSize(Socket []sockets)
      {
         float requiredWidth  = 0;
         float requiredHeight = 0;
         float leftRequiredHeight  = 0;
         float rightRequiredHeight = 0;
         float centerRequiredHeight= 0;
         float topRequiredHeight   = 0;
         float maxLeftAlignedText  = 0;
         float maxRightAlignedText = 0;
         float maxCenterAlignedText = 0;

         bool hasBottomSockets = false;

         foreach ( Socket socket in sockets )
         {
            SizeF textLength = Graphics.sMeasureString( FormatName(socket), "socket_text" );
            
            if ( socket.Alignment == Socket.Align.Bottom ) // Used for Action Node bottom socket left/right border spacing.
            {
               requiredWidth += uScriptConfig.Style.BottomSocketLabelGapSize + uScriptConfig.Style.PointSize + uScriptConfig.Style.BottomSocketLabelGapSize + uScriptConfig.Style.BottomSocketBorderAdjustmentPad;
               requiredWidth += textLength.Width;
               
               hasBottomSockets = true;
            }
            else if ( socket.Alignment == Socket.Align.Left ) // Used for Action Nodes
            {
               maxLeftAlignedText = Math.Max( maxLeftAlignedText, textLength.Width + uScriptConfig.Style.PointSize + uScriptConfig.Style.BottomSocketLabelGapSize );
               leftRequiredHeight += (uScriptConfig.Style.SideSocketToBottomSocketPad + textLength.Height );
            }
            else if ( socket.Alignment == Socket.Align.Right ) // Used for Event Nodes
            {
               maxRightAlignedText = Math.Max( maxRightAlignedText, textLength.Width + uScriptConfig.Style.PointSize + uScriptConfig.Style.BottomSocketLabelGapSize );
               rightRequiredHeight += (uScriptConfig.Style.SideSocketToBottomSocketPad + textLength.Height );
            }
            else if ( socket.Alignment == Socket.Align.Center )  // Used for properties
            {
               maxCenterAlignedText = Math.Max( maxCenterAlignedText, textLength.Width );
               centerRequiredHeight = Math.Max( centerRequiredHeight, textLength.Height );
            }
         }
         
         //UnityEngine.Debug.Log( "reqwidth " + g + " = " + requiredWidth );

         
         // Add in PointSize after the foreach (we only want to add this once, not once for each socket).
         leftRequiredHeight = leftRequiredHeight + uScriptConfig.Style.PointSize;
         rightRequiredHeight = rightRequiredHeight + uScriptConfig.Style.PointSize;

         //centered text should have extra title padding
         maxCenterAlignedText += uScriptConfig.Style.TitleLeftRightPad + uScriptConfig.Style.TitleLeftRightPad;

         requiredHeight = Math.Max( leftRequiredHeight, rightRequiredHeight );
         requiredHeight = Math.Max( requiredHeight, topRequiredHeight );
         requiredHeight = Math.Max( requiredHeight, centerRequiredHeight );

         requiredWidth  = Math.Max( requiredWidth, maxLeftAlignedText + maxRightAlignedText );
         requiredWidth  = Math.Max( requiredWidth, maxCenterAlignedText );

         SizeF titleLength = Graphics.sMeasureString( Name, NodeStyle );
         
         if ( true == hasBottomSockets )
         {
            requiredHeight += uScriptConfig.Style.BottomPad;
            requiredHeight += uScriptConfig.Style.TitleTopBottomPad;
         }

         requiredHeight += titleLength.Height + uScriptConfig.Style.TopPad;

         requiredWidth = Math.Max( requiredWidth, (titleLength.Width + uScriptConfig.Style.TitleLeftRightPad + uScriptConfig.Style.TitleLeftRightPad ) );
         requiredWidth += uScriptConfig.Style.LeftPad + uScriptConfig.Style.RightPad; 

         return new Size( (int) requiredWidth, (int) requiredHeight );
      }

      public override void PreparePoints( )
      {
         List<AnchorPoint> points   = new List<AnchorPoint>( );
         List<TextPoint> textPoints = new List<TextPoint>( );

         Size = CalculateSize( m_Sockets );

         LeftPoints  ( m_Sockets, points, textPoints );
         RightPoints ( m_Sockets, points, textPoints );
         BottomPoints( m_Sockets, points, textPoints );
         CenterPoints( m_Sockets, points, textPoints );

         List<TextPoint> finalText     = new List<TextPoint>  ( );
         List<AnchorPoint> finalAnchor = new List<AnchorPoint>( );

         foreach ( TextPoint textPoint in textPoints.ToArray( ) )
         {
            TextPoint clone = textPoint;
            clone.X = (clone.X / (float) Size.Width  * 100.0f);
            clone.Y = (clone.Y / (float) Size.Height * 100.0f);
         
            finalText.Add( clone );
         }

         foreach ( AnchorPoint anchorPoint in points.ToArray( ) )
         {
            AnchorPoint clone = anchorPoint;
            clone.X = (clone.X / (float) Size.Width  * 100.0f);
            clone.Y = (clone.Y / (float) Size.Height * 100.0f);
            clone.Width  = (clone.Width  / (float) Size.Width  * 100.0f);
            clone.Height = (clone.Height / (float) Size.Height * 100.0f);

            finalAnchor.Add( clone );
         }

         TextPoints   = finalText.ToArray( );
         AnchorPoints = finalAnchor.ToArray( );
      }
   }

   public class ChangeStack
   {
      public struct Change
      {
         public Object OldObject;
         public Object NewObject;
         public string Name;

         public Change(string name, Object oldObject, Object newObject)
         {
            OldObject = oldObject;
            NewObject = newObject;
            Name      = name;
         }
      }

      public void AddChange(Change change)
      {
         uScript.Instance.RegisterUndo( change.Name, ((ScriptEditor)change.OldObject), ((ScriptEditor)change.NewObject) );
      }
   };

   public class PropertyGridParameters
   {
      public EntityNode       EntityNode;
      public string           Description;
      public ScriptEditorCtrl ScriptEditorCtrl;

      public PropertyGridParameters( string description, EntityNode node, ScriptEditorCtrl scriptCtrl ) 
      { 
         Description      = description; 
         EntityNode       = node; 
         ScriptEditorCtrl = scriptCtrl;      
      }

      public Parameter[] GetParameters( string key )
      {
         ParameterDesc desc = m_ParameterDescs[ key ];

         List<Parameter> p = new List<Parameter>( );

         foreach ( Parameter ep in desc.Parameters )
         {
            p.Add( ep );
         }

         return p.ToArray( );
      }

      public Parameter[] Parameters
      {
         get
         {
            List<Parameter> parameters = new List<Parameter>( );

            foreach ( ParameterDesc desc in m_ParameterDescs.Values )
            {
               foreach ( Parameter property in desc.Parameters )
               {
                  parameters.Add( property );
               }
            }

            return parameters.ToArray( );
         }
         set
         {
            int index = 0;

            Dictionary<string, ParameterDesc> newDescs = new Dictionary<string,ParameterDesc>( );

            foreach ( ParameterDesc desc in m_ParameterDescs.Values )
            {
               ParameterDesc newDesc = new ParameterDesc( );
               
               newDesc.Key = desc.Key;

               int count = desc.Parameters.Length;

               List<Parameter> parameters = new List<Parameter>( );

               for ( int i = 0; i < count; i++ )
               {
                  parameters.Add( value[ index ] );
                  index++;
               }

               newDesc.Parameters = parameters.ToArray( );
               newDescs[ newDesc.Key ] = newDesc;
            }

            m_ParameterDescs = newDescs;
         }
      }

      private struct ParameterDesc
      {
         public Parameter[] Parameters;
         public string Key;
      }

      private Dictionary<string, ParameterDesc> m_ParameterDescs = new Dictionary<string,ParameterDesc>( );

      public void AddParameters( string key, Parameter[] parameters )
      {
         ParameterDesc desc = new ParameterDesc( );
         desc.Parameters = new Parameter[ parameters.Length ];
         
         parameters.CopyTo( desc.Parameters, 0 );
         desc.Key = key;

         m_ParameterDescs[ key ] = desc;
      }
   }
}

