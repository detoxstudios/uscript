// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScriptEditorCtrl.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ScriptEditorCtrl type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.ScriptEditor
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.ComponentModel;
   using System.Linq;

   using Detox.Application;
   using Detox.Drawing;
   using Detox.Editor;
   using Detox.FlowChart;
   using Detox.Windows.Forms;

   using Cursor = Detox.Windows.Forms.Cursor;
   using Graphics = Detox.Drawing.Graphics;
   using Object = System.Object;

   public partial class ScriptEditorCtrl : ToolWindow
   {
      private bool shouldParseClipboardData;

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

      private string m_ClipboardText = null;
      
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

      public bool CodeIsStale
      {
         get { return m_ScriptEditor.GeneratedCodeIsStale; }
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
          
          Profile p = new Profile ("Init");

         m_ContextObject = null;
         m_ContextCursor = Point.Empty;

         m_ScriptEditor = scriptEditor;

         m_PropertyGrid = new PropertyGrid( );

         Name    = m_ScriptEditor.Name;
         Text    = m_ScriptEditor.Name;
         TabText = m_ScriptEditor.Name;

         RebuildScript( null, true, location );
      
          p.End();

         this.shouldParseClipboardData = true; // check the clipboard for uScript data in uScript.OnGUI()
      }

      public void UpdateObjectReferences( )
      {
         Profile block1 = new Profile ("Block1");

         EntityNode []nodes = m_ScriptEditor.EntityNodes;

         foreach ( EntityNode node in nodes )
         {
            if ( node is LinkNode ) continue;

            Parameter p = node.Instance;
            
            if ( p != Parameter.Empty )
            {
               Type type = uScript.Instance.GetType( p.Type.Replace("[]", "") );

               if ( typeof(UnityEngine.GameObject).IsAssignableFrom(type) )
               {
                  string name = p.Default;

                  //if we have a reference, look up the latest name
                  if ( p.ReferenceGuid != null )
                  {
                     p.Default = uScript.MasterComponent.GetGameObject( name, p.ReferenceGuid );
                  }

                  //name hasn't changed which means 1 of 3 things...
                  //1 - the name hasn't changed, so it's fine if we update the guid to the same guid
                  //2 - the reference guid was never valid so this will force a valid reference
                  //3 - the reference guid is no longer valid and this will clear it
                  if ( name == p.Default )
                  {
                     //if we didn't have a reference, see if one is now available
                     p.ReferenceGuid = uScript.MasterComponent.GetGameObjectGuid( name );
                  }
               }

               node.Instance = p;
            }

             block1.End();

            Profile block2 = new Profile ("Block2");

            List<Parameter> parameters = new List<Parameter>( );

            foreach ( Parameter parameter in node.Parameters )
            {
               p = parameter;

                Profile profType = new Profile ("Gettype");
                Type type = uScript.Instance.GetType( p.Type.Replace("[]", "") );
                profType.End();

                Profile profAssign = new Profile ("Assign");
               if ( typeof(UnityEngine.GameObject).IsAssignableFrom(type) )
               {
                  //if we have a reference, look up the latest name
                  if ( p.ReferenceGuid != null )
                  {
                     Profile ggoProf = new Profile ("GetGameObject");
                     p.Default = uScript.MasterComponent.GetGameObject( p.Default, p.ReferenceGuid );
                    ggoProf.End();
                  }
                  else
                  {
                     Profile ggoProf = new Profile ("GetGameObjectGuid");
                     //if we didn't have a reference, see if one is now available
                     p.ReferenceGuid = uScript.MasterComponent.GetGameObjectGuid( p.Default );
                    ggoProf.End();
                  }
               }
                profAssign.End();

               parameters.Add( p );
            }

            //restore node parameters
            node.Parameters = parameters.ToArray( );
         
            Profile profAdd = new Profile ("AddNode");
            m_ScriptEditor.AddNode( node, false );
            profAdd.End();
         
             block2.End();
         }

         m_ScriptEditor.VerifyAllLinks( );
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

      public Node GetNextDeprecatedNode(Node node)
      {
         int i;
         int retIndex = -1;
         
         Node[] nodes = m_FlowChart.Nodes;

         for (i = 0; i < nodes.Length; i++)
         {
            if (node == nodes[i] || (node == null && i == 0))
            {
               bool found = false;
               int index = (node == null ? 0 : i);

               do
               {
                  if (index == nodes.Length - 1)
                  {
                     index = 0;
                  }
                  else
                  {
                     index++;
                  }

                  if (((DisplayNode)nodes[index]).Deprecated)
                  {
                     retIndex = index;
                     found = true;
                  }
               } while (!found && index != i);
               
               break;
            }
         }
         
         if (retIndex == -1)
         {
             return null;
         }
         return nodes[retIndex];
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
         point.X = Math.Min(0, Math.Max(-System.UInt16.MaxValue, -point.X + (int)(uScript.Instance.NodeWindowRect.width * 0.5f)));
         point.Y = Math.Min(0, Math.Max(-System.UInt16.MaxValue, -point.Y + (int)(uScript.Instance.NodeWindowRect.height * 0.5f) - (int)uScript.Instance.NodeToolbarRect.height));
         m_FlowChart.Location = point;
         m_FlowChart.Invalidate( );  // CenterOnPoint
      }

      public void CenterOnNode(Node node)
      {
         // center on the center for now - later, we'll calculate zoom amount, etc.
         int halfWidth = (int)(uScript.Instance.NodeWindowRect.width / 2.0f);
         int halfHeight = (int)(uScript.Instance.NodeWindowRect.height / 2.0f);
         Point center = new Point(node.Bounds.Left + node.Bounds.Width / 2, node.Bounds.Top + node.Bounds.Height / 2);
         m_FlowChart.Location = new Point( Math.Min(0, Math.Max(-System.UInt16.MaxValue, -center.X + halfWidth)),
                                           Math.Min(0, Math.Max(-System.UInt16.MaxValue, -center.Y + halfHeight - (int)uScript.Instance.NodeToolbarRect.height)));
         m_FlowChart.Invalidate( );  // CenterOnNode
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

            Point point = node.PointToClient( Cursor.ScaledPosition );

            if ( point.X >= 0 && point.Y >= 0 && 
                 point.X <= node.Size.Width &&
                 point.Y <= node.Size.Height )
            {      
               string type = ScriptEditor.FindNodeType(entityNode);
               Type t = uScript.GetAssemblyQualifiedType(type);

               if ( typeof(uScriptLogic).IsAssignableFrom(t) )
               {  
                  uScriptLogic logic = Activator.CreateInstance( t ) as uScriptLogic;//UnityEngine.ScriptableObject.CreateInstance( t ) as uScriptLogic;

                  bool result = null != logic.EditorDragDrop( o );
                  
                  logic = null;
                  //UnityEngine.ScriptableObject.DestroyImmediate( logic );

                  return result;
               }
               else if ( true == typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()) )
               {   
                  string destTypeString = null;

                  if ( entityNode.Instance != Parameter.Empty && entityNode.Instance.Input == true )
                  {
                     if ( entityNode is EntityMethod )
                     {
                        destTypeString = ((EntityMethod)entityNode).ComponentType;
                     }
                     else if ( entityNode is EntityEvent )
                     {
                        destTypeString = ((EntityEvent)entityNode).ComponentType;
                     }
                     else if ( entityNode is EntityProperty )
                     {
                        destTypeString = ((EntityProperty)entityNode).ComponentType;
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
                     Type destType = uScript.Instance.GetType(destTypeString);

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

            Point point = node.PointToClient( Cursor.ScaledPosition );

            if ( point.X >= 0 && point.Y >= 0 && 
                 point.X <= node.Size.Width &&
                 point.Y <= node.Size.Height )
            {
               string type = ScriptEditor.FindNodeType(entityNode);
               Type t = uScript.GetAssemblyQualifiedType(type);

               if ( typeof(uScriptLogic).IsAssignableFrom(t) )
               {  
                  uScriptLogic logic = Activator.CreateInstance( t ) as uScriptLogic;//UnityEngine.ScriptableObject.CreateInstance( t ) as uScriptLogic;
                  Hashtable hash = logic.EditorDragDrop( o );
               
                  EntityNode oldNode = entityNode.Copy( true );

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
                        parameters[i].DefaultAsObject = asset as string;                  
                     }
                  }

                  logic = null;//UnityEngine.ScriptableObject.DestroyImmediate( logic );

                  entityNode.Parameters = parameters;

                  m_ScriptEditor.AddNode( entityNode );

                  uScript.Instance.RegisterUndo( new Patch.EntityNode("Drag Drop", oldNode, entityNode) );

                  PatchDisplay( new Patch.EntityNode("Drag Drop", oldNode, entityNode) );
                  //RebuildScript( null );

                  m_Dirty = true;                  

                  return true;
               }
               else if ( true == typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType( )) )
               {
                  string destTypeString = null;

                  if ( entityNode.Instance != Parameter.Empty && entityNode.Instance.Input == true )
                  {
                     if ( entityNode is EntityMethod )
                     {
                        destTypeString = ((EntityMethod)entityNode).ComponentType;
                     }
                     else if ( entityNode is EntityEvent )
                     {
                        destTypeString = ((EntityEvent)entityNode).ComponentType;
                     }
                     else if ( entityNode is EntityProperty )
                     {
                        destTypeString = ((EntityProperty)entityNode).ComponentType;
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
                     Type destType = uScript.Instance.GetType(destTypeString);

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
                        EntityNode oldNode = entityNode.Copy( true );

                        if ( entityNode.Instance != Parameter.Empty && entityNode.Instance.Input == true )
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

                        m_ScriptEditor.AddNode( entityNode );   

                        uScript.Instance.RegisterUndo( new Patch.EntityNode("Drag Drop", oldNode, entityNode) );
                        PatchDisplay( new Patch.EntityNode("Drag Drop", oldNode, entityNode) );

                        m_Dirty = true;

                        //RebuildScript( null );
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
            Point point = node.PointToClient( Cursor.ScaledPosition );

            if ( point.X >= 0 && point.Y >= 0 && 
                 point.X <= node.Size.Width &&
                 point.Y <= node.Size.Height )
            {               
               return false;
            }
         }

         // are we a game object?
#if UNITY_3_5
         return typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()) && ((UnityEngine.GameObject)o).active;
#else
         return typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()) && ((UnityEngine.GameObject)o).activeSelf;
#endif
      }
      
      public bool DoDragDropContextMenu( object[] objects )
      {
         //no nodes were intersected so allow context menu
         m_ContextObject = objects;
         m_ContextCursor = Detox.Windows.Forms.Cursor.ScaledPosition;
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
//               UnityEngine.Debug.Log("Loop INSIDE: " + component.GetType().ToString() + "\n");
            }

            typeHash[ gameObject.GetType().ToString() ] = true;
//            UnityEngine.Debug.Log("Loop AFTER: " + gameObject.GetType().ToString() + "\n");
         }

//         string type         = typeof(UnityEngine.GameObject).ToString();
//         string friendlyName = uScriptConfig.Variable.FriendlyName(type);
//
//         ToolStripMenuItem friendlyMenu = null;
//
//         friendlyMenu        = GetMenu(addMenu, "Place Variable: " + friendlyName + " (???)");
//         friendlyMenu.Tag    = new LocalNode( "", type, "" );
//
//         //add a separator
//         friendlyMenu = GetMenu(addMenu, "<hr>");


         BuildAddMenu( addMenu, typeHash );
         
         m_ContextMenuStrip.Items.AddRange( addMenu.DropDownItems.ToArray( ) );

         return true;
      }

      public void CopyToClipboard(bool shouldParseClipboardData = false)
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
         scriptEditor.Write( null, stream );

         string base64 = Convert.ToBase64String( stream.GetBuffer( ) );
         base64 = "[SCRIPTEDITOR]" + base64;

         UnityEditor.EditorGUIUtility.systemCopyBuffer = base64;
         
         m_CopiedFromThisLocation = true;

         OnScriptModified( );

         this.shouldParseClipboardData = shouldParseClipboardData;
      }

      public void PasteFromClipboard( Point cursorPoint )
      {
         string text = GetClipboardData( );
         if ( null == text ) return;

         byte[] binary = Convert.FromBase64String( text );

         ScriptEditor scriptEditor = new ScriptEditor( "", ScriptEditor.EntityDescs, ScriptEditor.LogicNodes );
         if ( true == scriptEditor.Read( null, new System.IO.MemoryStream(binary)) )
         {
            List<Guid> guidsToSelect = new List<Guid>( );

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

            Patch.Batch batchPatch = new Patch.Batch( "Paste" );

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

               Patch.EntityNode patchNode = new Detox.Patch.EntityNode( "", null, clone.Copy(true) );
               batchPatch.Add( patchNode );

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

               Patch.EntityNode patchNode = new Detox.Patch.EntityNode( "", null, clone.Copy(true) );
               batchPatch.Add( patchNode );

               m_ScriptEditor.AddNode( clone );
               guidsToSelect.Add( clone.Guid );
               m_Dirty = true;
            }
    
            m_FlowChart.DeselectAll();
            uScript.Instance.RegisterUndo( batchPatch );
            PatchDisplay( batchPatch, guidsToSelect );

            //RebuildScript( guidsToSelect );
            m_FlowChart.OnSelectionModified();
         }
      }

      //use cached copy we got from OnGUI call
      private string GetClipboardData( )
      {
         return m_ClipboardText;
      }

      //has to be called manually from OnGUI rather than
      //on demand
      public void ParseClipboardData( )
      {
         if (this.shouldParseClipboardData == false)
         {
            return;
         }

         m_ClipboardText = null;
         
         try
         {
            if ( null == UnityEditor.EditorGUIUtility.systemCopyBuffer ) return;

            if ( false == UnityEditor.EditorGUIUtility.systemCopyBuffer.StartsWith("[SCRIPTEDITOR]") )  return;

            this.shouldParseClipboardData = false;

            m_ClipboardText = UnityEditor.EditorGUIUtility.systemCopyBuffer.Substring( "[SCRIPTEDITOR]".Length );
            //UnityEngine.Debug.Log("Successful copy");
         }
         catch (Exception)
         {
         }
      }

      public void ExpandNode(Node node)
      {
         ExpandNodes( new Node[] { node } );
      }

      public void ExpandAllNodes()
      {
         ExpandNodes( null );
      }

      public void ExpandSelectedNodes()
      {
         ExpandNodes( m_FlowChart.SelectedNodes );
      }

      private void ExpandNodes( Node [] nodes )
      {
         if ( null == nodes ) nodes = m_FlowChart.Nodes;

         Patch.Batch batchPatch = new Patch.Batch( "Expand Nodes" );

         foreach ( Node node in nodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;
            List<Parameter> parameters = new List<Parameter>( );

            EntityNode oldNode = entityNode.Copy( true );

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
         
            Patch.EntityNode patchNode = new Detox.Patch.EntityNode( "", oldNode, entityNode.Copy(true) );
            batchPatch.Add( patchNode );
         }

         uScript.Instance.RegisterUndo( batchPatch );
         PatchDisplay( batchPatch );

         //RebuildScript( null );
      }

      public void CollapseNode(Node node)
      {
         CollapseNodes( new Node[] { node } );
      }

      public void CollapseAllNodes()
      {
         CollapseNodes( null );
      }

      public void CollapseSelectedNodes()
      {
         CollapseNodes( m_FlowChart.SelectedNodes );
      }

      private void CollapseNodes( Node [] nodes )
      {
         if ( null == nodes ) nodes = m_FlowChart.Nodes;
         
         Patch.Batch batchPatch = new Patch.Batch( "Collapse Nodes" );

         foreach ( Node node in nodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;
            EntityNode oldNode = entityNode.Copy( true );

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

            Patch.EntityNode patchNode = new Detox.Patch.EntityNode( "", oldNode, entityNode.Copy(true) );
            batchPatch.Add( patchNode );
         }

         uScript.Instance.RegisterUndo( batchPatch );
         PatchDisplay( batchPatch );
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
         CopyToClipboard(true);
      }

      private void m_MenuPaste_Click(object sender, EventArgs e)
      {
         PasteFromClipboard( ContextCursor );
      }

      private void m_MenuExpand_Click(object sender, EventArgs e)
      {
         ExpandSelectedNodes();
      }

      private void m_MenuCollapse_Click(object sender, EventArgs e)
      {
         CollapseSelectedNodes();
      }

      private void m_MenuExpandAll_Click(object sender, EventArgs e)
      {
         ExpandAllNodes();
      }

      private void m_MenuCollapseAll_Click(object sender, EventArgs e)
      {
         CollapseSelectedNodes();
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
            else if ( node is EntityMethod )
            {
               EntityMethod m = (EntityMethod) node;
               linkTo = m.Instance;
            }
            else if ( node is EntityProperty )
            {
               EntityProperty p = (EntityProperty) node;
               linkTo = p.Instance;
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
            Patch.Batch batchPatch = new Detox.Patch.Batch( "Add Linked Variable" );

            Point point = m_FlowChart.PointToClient( Cursor.ScaledPosition );

            List<Guid> guidsToSelect = new List<Guid>();

            LocalNode localNode = new LocalNode( "", linkTo.AutoLinkType, "" );
            localNode.Position = point;
            guidsToSelect.Add( localNode.Guid );

            m_ScriptEditor.AddNode( localNode );
            batchPatch.Add( new Detox.Patch.EntityNode("", null, localNode) );

            LinkNode linkNode = new LinkNode( localNode.Guid, localNode.Value.Name, node.Guid, linkTo.Name );

            string reason;

            //if we can't link from->to try linking the other way (to->from)
            if ( false == m_ScriptEditor.VerifyLink(linkNode, out reason) )
            {
               linkNode = new LinkNode( node.Guid, linkTo.Name, localNode.Guid, localNode.Value.Name );
            }

            if ( false == m_ScriptEditor.VerifyLink(linkNode, out reason) )
            {
               linkNode = new LinkNode( node.Guid, linkTo.Name, localNode.Guid, localNode.Value.Name );
            }

            m_ScriptEditor.AddNode( linkNode );

            if ( null != m_ScriptEditor.GetNode(linkNode.Guid) )
            {
               batchPatch.Add( new Detox.Patch.EntityNode("", null, linkNode) );
            }

            m_Dirty = true;

            uScript.Instance.RegisterUndo( batchPatch );
            PatchDisplay( batchPatch, guidsToSelect, true );
         }
      }

      public void UpdateRemoteValues( )
      {
         if ( false == m_ScriptEditor.SavedForDebugging ) return;

         Patch.Batch batchPatch = new Detox.Patch.Batch( "Runtime Debugging" );

         foreach ( LocalNode localNode in m_ScriptEditor.UniqueLocals )
         {
            object value = uScript.MasterComponent.GetNodeValue( m_ScriptEditor.Name + ":" + localNode.Name.Default );
            if ( null == value ) value = uScript.MasterComponent.GetNodeValue( localNode.Guid.ToString( ) );
            
            if ( null != value && localNode.Value.DefaultAsObject != value )
            {
               LocalNode clone = localNode;

               Parameter p = clone.Value;

               p.DefaultAsObject = value;
               clone.Value = p;

               m_ScriptEditor.AddNode( clone );
               batchPatch.Add( new Patch.EntityNode("", localNode, clone) );
            }
         }
         foreach ( EntityProperty propertyNode in m_ScriptEditor.Properties )
         {
            object value = uScript.MasterComponent.GetNodeValue( propertyNode.Guid.ToString( ) );
            
            if ( null != value && propertyNode.Parameter.DefaultAsObject != value )
            {
               EntityProperty clone = propertyNode;

               Parameter p = clone.Parameter;

               p.DefaultAsObject = value;
               clone.Parameter = p;

               m_ScriptEditor.AddNode( clone );
               batchPatch.Add( new Patch.EntityNode("", propertyNode, clone) );
            }
         }

         PatchDisplay( batchPatch );

         //we do not patch the undo stack/cache because when unity stops running
         //the undo stack/cache is used to reset us to the default state
         //theoretically this doesn't matter because when Unity stops playing
         //it restores our cache to the previous state anyway
      }
      
#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
      private void m_MenuAddBreakpoint_Click(object sender, EventArgs e)
      {
         foreach ( DisplayNode node in SelectedNodes )
         {
            if ( node is EntityEventDisplayNode || node is LogicNodeDisplayNode ||
                 node is EntityMethodDisplayNode )
            {
               uScript.MasterComponent.AddBreakpoint( node.Guid.ToString( ) );
            }
         }
      }
#endif
      
      private void m_MenuRemoveBreakpoint_Click(object sender, EventArgs e)
      {
         foreach ( DisplayNode node in SelectedNodes )
         {
            if ( node is EntityEventDisplayNode || node is LogicNodeDisplayNode ||
                 node is EntityMethodDisplayNode )
            {
               uScript.MasterComponent.RemoveBreakpoint( node.Guid.ToString( ) );
            }
         }
      }

      private void m_MenuAddNode_Click(object sender, EventArgs e)
      {
         MenuItem item = sender as MenuItem;
         EntityNode entityNode;
         Point offset = new Point(0, 0);
         List<Guid> guidsToSelect = new List<Guid>();

         Patch.Batch batchPatch = new Patch.Batch( "Add" );

         if ( null != m_ContextObject && typeof(Object[]).IsAssignableFrom(m_ContextObject.GetType()) )
         {
            foreach (object obj in m_ContextObject)
            {
               entityNode = (EntityNode) ((EntityNode) item.Tag).Copy( false );
      
               entityNode.Position = new Point( m_ContextCursor.X + offset.X, m_ContextCursor.Y + offset.Y );
               object contextObject = obj;
      
               if ( null != contextObject && typeof(UnityEngine.Object).IsAssignableFrom(contextObject.GetType()) )
               {
                  if ( entityNode.Instance != Parameter.Empty && entityNode.Instance.Input == true )
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
               batchPatch.Add( new Patch.EntityNode( "", null, entityNode.Copy(true)) );
               guidsToSelect.Add( entityNode.Guid );

               m_Dirty = true;
               
               offset.X += 10;
               offset.Y += 10;
            }
            
            m_ContextObject = null;
         }
         else
         {
            entityNode = (EntityNode) ((EntityNode) item.Tag).Copy( false );
   
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

            guidsToSelect.Add( entityNode.Guid );
            m_ScriptEditor.AddNode( entityNode );
            batchPatch.Add( new Patch.EntityNode( "", null, entityNode.Copy(true)) );
            
            m_Dirty = true;
         }

         if ( true == batchPatch.HasPatches )
         {
            uScript.Instance.RegisterUndo( batchPatch );
            PatchDisplay( batchPatch, guidsToSelect, true );

            //RebuildScript( null );
         }
      }

      public void m_MenuUpgradeNode_Click(object sender, EventArgs e)
      {
         UpgradeDeprecatedNodes(SelectedNodes);
      }
  
      public void UpgradeDeprecatedNodes(DisplayNode[] nodes)
      {
         Patch.Batch batchPatch = new Detox.Patch.Batch( "Upgrade Node" );

         int countTotal = 0;
         int countFixed = 0;

         foreach ( DisplayNode node in nodes )
         {
            if ( true == node.Deprecated )
            {
               countTotal++;
               
               if ( true == m_ScriptEditor.CanUpgradeNode(node.EntityNode) )
               {
                  countFixed++;
                  
                  EntityNode oldNode = node.EntityNode.Copy( true );

                  m_ScriptEditor.UpgradeNode( node.EntityNode );

                  EntityNode newNode = m_ScriptEditor.GetNode( oldNode.Guid );

                  if ( newNode != null )
                  {
                     batchPatch.Add( new Patch.EntityNode("", oldNode, newNode) );
                  }
               }
            }
         }

         uScript.Instance.RegisterUndo( batchPatch );
         PatchDisplay( batchPatch );

         string result = countFixed.ToString() + (countFixed == 1 ? " node was" : " nodes were") + " successfully upgraded.";
         int countRemaining = countTotal - countFixed;
         if (countRemaining > 0)
         {
            result += "\n" + countRemaining.ToString() + (countRemaining == 1 ? " node" : " nodes") + " could not be upgraded and must be manually replaced.";
         }
         uScriptDebug.Log(result, (countRemaining > 0 ? uScriptDebug.Type.Warning : uScriptDebug.Type.Message));
         
         //RebuildScript( null );
      }

      public void m_MenuDeleteMissingNode_Click(object sender, EventArgs e)
      {
         Patch.Batch batchPatch = new Detox.Patch.Batch( "Delete Missing Node" );

         foreach ( DisplayNode node in SelectedNodes )
         {
            if ( true == node.Deprecated )
            {
               if ( false == m_ScriptEditor.CanUpgradeNode(node.EntityNode) )
               {
                  //links will be removed when we remove the node
                  //so apply patches for each one so they'll come back
                  //during the undo
                  BatchPatchLinks( batchPatch, node.EntityNode.Guid );

                  batchPatch.Add( new Patch.EntityNode("", node.EntityNode, null) );
                  
                  m_ScriptEditor.RemoveNode( node.EntityNode );
               }
            }
         }

         uScript.Instance.RegisterUndo( batchPatch );
         PatchDisplay( batchPatch );

         //RebuildScript( null );
      }

      private void BatchPatchLinks(Patch.Batch batchPatch, Guid guid)
      {
         LinkNode []links = m_ScriptEditor.GetLinksByDestination( guid, null );

         foreach ( LinkNode link in links )
         {
            batchPatch.Add( new Patch.EntityNode("", link, null) );
         }

         links = m_ScriptEditor.GetLinksBySource( guid, null );

         foreach ( LinkNode link in links )
         {
            batchPatch.Add( new Patch.EntityNode("", link, null) );
         }
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
            List<Guid> guidsToSelect = new List<Guid>();

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
            guidsToSelect.Add( listNode.Guid );
         
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

            Patch.Batch patchBatch = new Detox.Patch.Batch( "Create List" );

            //remove all existing nodes, which means the links go away too
            foreach ( LocalNode local in locals )
            {
               //links will be removed when we remove the node
               //so apply patches for each one so they'll come back
               //during the undo
               BatchPatchLinks( patchBatch, local.Guid );
               patchBatch.Add( new Patch.EntityNode("", local, null) );

               m_ScriptEditor.RemoveNode( local );
            }

            patchBatch.Add( new Patch.EntityNode("", null, listNode) );
            m_ScriptEditor.AddNode( listNode );

            //now relink to our single node
            foreach ( object o in connectToMe.Values )
            {
               LinkNode link = (LinkNode) o;

               LinkNode newLink = new LinkNode( link.Source.Guid, link.Source.Anchor, listNode.Guid, listNode.Value.Name );

               patchBatch.Add( new Patch.EntityNode("", null, newLink) );
               m_ScriptEditor.AddNode( newLink );
            }
            foreach ( object o in connectFromMe.Values )
            {
               LinkNode link = (LinkNode) o;

               LinkNode newLink = new LinkNode( listNode.Guid, listNode.Value.Name, link.Destination.Guid, link.Destination.Anchor );

               patchBatch.Add( new Patch.EntityNode("", null, newLink) );
               m_ScriptEditor.AddNode( newLink );
            }

            uScript.Instance.RegisterUndo( patchBatch );
            PatchDisplay( patchBatch, guidsToSelect, true );
            //RebuildScript( null );
         }
      }
      
      public EntityNode GetLogicNode(String type)
      {
         foreach ( LogicNode node in m_ScriptEditor.LogicNodes )
         {
            if (node.Type == type) return node.Copy( false );
         }
         
         return null;
      }

      public EntityNode GetEventNode(string type)
      {
         foreach (EntityDesc entityDesc in m_ScriptEditor.EntityDescs)
         {
            if (entityDesc.Type == type)
            {
               foreach (EntityEvent entityEvent in entityDesc.Events)
               {
                  if (entityEvent.ComponentType == type) return entityEvent.Copy( false );
               }
            }
         }
         return null;
      }

      public EntityNode GetMethodNode(string type, string method)
      {
         foreach (EntityDesc entityDesc in m_ScriptEditor.EntityDescs)
         {
            if (entityDesc.Type == type)
            {
               foreach (EntityMethod entityMethod in entityDesc.Methods)
               {
                  if (entityMethod.Input.Name == method) return entityMethod.Copy( false );
               }
            }
         }
         return null;
      }

      public void AddVariableNode(EntityNode entityNode)
      {
         entityNode.Position = new Point( m_ContextCursor.X, m_ContextCursor.Y );
         if ( "" != uScript.Instance.AutoAssignInstance(entityNode) )
         {
            Parameter instance = entityNode.Instance;
            instance.Default = uScript.Instance.AutoAssignInstance(entityNode);
            entityNode.Instance = instance;
         }
         
         m_ScriptEditor.AddNode( entityNode );
         m_Dirty = true;

         Patch.EntityNode patchNode = new Detox.Patch.EntityNode("Add", null, entityNode);
         uScript.Instance.RegisterUndo( patchNode );
         List<Guid> guidsToSelect = new List<Guid>();
         guidsToSelect.Add( entityNode.Guid );
         PatchDisplay( patchNode, guidsToSelect );
         
         //RebuildScript( null );
      }

      public void SelectAllNodes()
      {
         m_FlowChart.SelectNodes(this.m_ScriptEditor.EntityNodes.Select(node => node.Guid).ToArray());
      }

      public void SelectAllNodesWithinArea(Rectangle rectangle)
      {
         var scriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;

         m_FlowChart.SelectNodes(
            (from node in this.m_ScriptEditor.EntityNodes
             let n = scriptEditorCtrl.GetNode(node.Guid)
             where rectangle.Contains(n.Bounds)
             select node.Guid).ToArray());
      }

      public void SelectAllLinks()
      {
         foreach (var link in m_FlowChart.Links)
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
         Detox.FlowChart.Node [] nodes = m_FlowChart.SelectedNodes;

         Patch.Batch batch = new Detox.Patch.Batch( "Delete" );

         foreach ( Detox.FlowChart.Node node in nodes )
         {
            //links will be removed when we remove the node
            //so apply patches for each one so they'll come back
            //during the undo
            BatchPatchLinks( batch, ((DisplayNode)node).EntityNode.Guid );

            m_ScriptEditor.RemoveNode( ((DisplayNode)node).EntityNode );
            batch.Add( new Patch.EntityNode("", ((DisplayNode)node).EntityNode, null) );
            m_Dirty = true;
         }

         Link [] links = m_FlowChart.SelectedLinks;

         foreach ( Link link in links )
         {
            //it might not exist if it was removed
            //due to a node it linked to being deleted
            if ( null != m_ScriptEditor.GetNode(((LinkNode)link.Tag).Guid) )
            {
               m_ScriptEditor.RemoveNode( ((LinkNode)link.Tag) );
               batch.Add( new Patch.EntityNode("", ((LinkNode)link.Tag), null) );
               m_Dirty = true;
            }
         }

         uScript.Instance.RegisterUndo( batch );
         PatchDisplay( batch );

         //RebuildScript( null );
      }

      private void m_MenuDeleteNode_Click(object sender, EventArgs e)
      {
         DeleteSelectedNodes( );
      }

      public void PatchDisplay( Patch.PatchData patch )
      {
         PatchDisplay( patch, null, false );
      }

      private void PatchDisplay( Patch.PatchData patch, List<Guid> guidsToSelect )
      {
         PatchDisplay( patch, guidsToSelect, false );
      }

      private void PatchDisplay( Patch.PatchData patch, List<Guid> guidsToSelect, bool deselectAll )
      {
         RemoveEventHandlers( );

         patch.Apply( this );
   
         if ( deselectAll )
         {
            m_FlowChart.DeselectAll();
         }
         
         if ( null != guidsToSelect )
         {
            m_FlowChart.SelectNodes( guidsToSelect.ToArray( ) );
         }

         FlowchartSelectionModified( null, null );

         OnScriptModified();

         AddEventHandlers( );
      }

      public void UnpatchDisplay( Patch.PatchData patch )
      {
         RemoveEventHandlers( );

         patch.Remove( this );

         FlowchartSelectionModified( null, null );

         OnScriptModified();

         AddEventHandlers( );
      }

      public void UpdateNodeDisplay( Guid nodeGuid )
      {
         DisplayNode node = (DisplayNode) m_FlowChart.GetNode( nodeGuid );
         EntityNode entityNode = m_ScriptEditor.GetNode( nodeGuid );

         bool selected = null != node ? node.Selected : false;

         if ( entityNode is CommentNode )
         {
            node = new CommentDisplayNode( (CommentNode) entityNode, this );
         }
         else if ( entityNode is EntityEvent )
         {
            node = new EntityEventDisplayNode( (EntityEvent) entityNode, this );
         }
         else if ( entityNode is EntityMethod )
         {
            node = new EntityMethodDisplayNode( (EntityMethod) entityNode, this );
         }
         else if ( entityNode is EntityProperty )
         {
            node = new EntityPropertyDisplayNode( (EntityProperty) entityNode, this );
         }
         else if ( entityNode is LocalNode )
         {
            node = new LocalNodeDisplayNode( (LocalNode) entityNode, this );
         }
         else if ( entityNode is LogicNode )
         {
            node = new LogicNodeDisplayNode( (LogicNode) entityNode, this );
         }
         else if ( entityNode is ExternalConnection )
         {
            node = new ExternalConnectionDisplayNode( (ExternalConnection) entityNode, this );
         }
         else if ( entityNode is OwnerConnection )
         {
            node = new OwnerConnectionDisplayNode( (OwnerConnection) entityNode, this );
         }

         if ( node != null )
         {
            node.Selected = selected;
            m_FlowChart.AddNode( node );
         }
         else if ( entityNode is LinkNode )
         {
            LinkNode link = (LinkNode) entityNode;

            Detox.FlowChart.Link chartLink = new Detox.FlowChart.Link( );
            chartLink.Tag = link;

            chartLink.Source.Node   = m_FlowChart.GetNode( link.Source.Guid );
            chartLink.Source.AnchorName = link.Source.Anchor;

            chartLink.Destination.Node   = m_FlowChart.GetNode( link.Destination.Guid );
            chartLink.Destination.AnchorName = link.Destination.Anchor;

            m_FlowChart.AddLink( chartLink );

            //refresh the nodes it was linked too so they
            //correctly render their socket text
            UpdateNodeDisplay( chartLink.Source.Node.Guid );
            UpdateNodeDisplay( chartLink.Destination.Node.Guid );
         }
      }

      public void RemoveNodeDisplay( Guid nodeGuid )
      {
         Node node = m_FlowChart.GetNode( nodeGuid );

         //if no node, it must be a link
         if ( null == node )
         {
            Link [] links = m_FlowChart.Links;

            foreach ( Link link in links )
            {
               if ( ((EntityNode)link.Tag).Guid == nodeGuid )
               {
                  m_FlowChart.DeleteLink( link.Source.Node.Guid, link.Source.AnchorName, link.Destination.Node.Guid, link.Destination.AnchorName );

                  //refresh the nodes it was linked too so they
                  //correctly render their socket text
                  UpdateNodeDisplay( link.Source.Node.Guid );
                  UpdateNodeDisplay( link.Destination.Node.Guid );
                  
                  break;
               }
            }
         }
         else
         {
            m_FlowChart.DeleteNode( nodeGuid );
         }
      }

      private void RebuildScript( List<Guid> guidsToSelect )
      {
         RebuildScript(guidsToSelect, false, Point.Empty);
      }

      public void RebuildScript( List<Guid> guidsToSelect, bool zoomExtents )
      {
         RebuildScript(guidsToSelect, zoomExtents, Point.Empty);
      }

      public void RebuildScript( List<Guid> guidsToSelect, bool zoomExtents, Point location )
      {
         Profile p = new Profile ("Rebuild Script");

         Profile block1 = new Profile ("Block 1");

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

         m_FlowChart.Clear( );

         UpdateObjectReferences( );

         List<LinkNode> links = new List<LinkNode>( );

         block1.End();
         
         Profile profBuildingNodes = new Profile ("Building Nodes");
        
         foreach ( EntityNode entityNode in m_ScriptEditor.EntityNodes )
         {
            DisplayNode node = null;

            if ( entityNode is LinkNode )
            {
               links.Add( (LinkNode) entityNode );
            }
            else if ( entityNode is CommentNode )
            {
               node = new CommentDisplayNode( (CommentNode) entityNode, this );
            }
            else if ( entityNode is EntityEvent )
            {
               node = new EntityEventDisplayNode( (EntityEvent) entityNode, this );
            }
            else if ( entityNode is EntityMethod )
            {
               node = new EntityMethodDisplayNode( (EntityMethod) entityNode, this );
            }
            else if ( entityNode is EntityProperty )
            {
               node = new EntityPropertyDisplayNode( (EntityProperty) entityNode, this );
            }
            else if ( entityNode is LocalNode )
            {
               node = new LocalNodeDisplayNode( (LocalNode) entityNode, this );
            }
            else if ( entityNode is LogicNode )
            {
               node = new LogicNodeDisplayNode( (LogicNode) entityNode, this );
            }
            else if ( entityNode is ExternalConnection )
            {
               node = new ExternalConnectionDisplayNode( (ExternalConnection) entityNode, this );
            }
            else if ( entityNode is OwnerConnection )
            {
               node = new OwnerConnectionDisplayNode( (OwnerConnection) entityNode, this );
            }

            if ( node != null )
            {
               if ( m_ScriptEditor.IsNodeInstanceDeprecated(entityNode) ) node.Deprecate( );
            
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
         }

         profBuildingNodes.End();


         Profile profBuildingLinks = new Profile ("Building Links");

         foreach ( LinkNode link in links )
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
      
         if (m_FlowChart.Nodes.Length > 0)
         {
            if (location != Point.Empty)
            {
               m_FlowChart.Location = location;
            }
            else if (zoomExtents)
            {
               //bounding box width
               float nodeWidth = (maxX - minX) * m_FlowChart.Zoom;
               float nodeHeight = (maxY - minY) * m_FlowChart.Zoom;

               //bounding box left/top with scale taken into account (scale would move the top left in or out)
               float nodeX = minX + ((maxX - minX) - nodeWidth) / 2.0f;
               float nodeY = minY + ((maxY - minY) - nodeHeight) / 2.0f;

               //deltaX, deltaY required for the bounding box to be centered in the canvas
               float deltaX = (uScript.Instance.NodeWindowRect.width / m_FlowChart.Zoom - nodeWidth) / 2.0f;
               float deltaY = (uScript.Instance.NodeWindowRect.height / m_FlowChart.Zoom - nodeHeight) / 2.0f;

               //move the canvas so it sits at the delta gap away from the bounding box
               float x = -(nodeX - deltaX);
               float y = -(nodeY - deltaY) - uScript.Instance.NodeToolbarRect.height;

               m_FlowChart.Location = new Point((int) x, (int) y);
            }
         }

         profBuildingLinks.End();

        Profile block2 = new Profile ("Block2");


         //m_FlowChart.Invalidate( );  // RefreshScript - Replaces the three calls above


         FlowchartSelectionModified( null, null );

         OnScriptModified();

         AddEventHandlers( );

         block2.End();

         p.End( );
      }

      private void FlowchartNodesModified(object sender, FlowchartNodesModifiedEventArgs e)
      {
         RemoveEventHandlers( );

            Patch.Batch batch = new Detox.Patch.Batch( "Node Modified" );

            foreach ( FlowChart.Node node in e.Nodes )
            {
               EntityNode entityNode = ((DisplayNode)node).EntityNode;
               EntityNode oldNode = entityNode.Copy(true);

               entityNode.Position = ((DisplayNode)node).Location;

               if ( entityNode is CommentNode )
               {
                  CommentNode clone = (CommentNode) entityNode;
                  
                  Parameter width = clone.Width;
                  Parameter height = clone.Height;

                  width.DefaultAsObject = node.Size.Width;
                  height.DefaultAsObject = node.Size.Height;
                  clone.Width = width;
                  clone.Height = height;

                  entityNode = clone;
               }

               m_ScriptEditor.AddNode( entityNode );
               
               if ( false == oldNode.Equals(entityNode) )
               {
                  batch.Add( new Patch.EntityNode("", oldNode, entityNode) );
               }
            }
         
         AddEventHandlers( );

         if ( true == batch.HasPatches )
         {
            m_Dirty = true;
            uScript.Instance.RegisterUndo( batch );
            PatchDisplay( batch );
         }
      }

      private void FlowchartSelectionModified(object sender, EventArgs e)
      {
         List<PropertyGridParameters> gridParameters = new List<PropertyGridParameters>( );

         foreach ( Node node in m_FlowChart.SelectedNodes )
         {
            // TODO: Auto-populate property grid parameters
            //          Instead of parsing the node, the display node type should be
            //          aware of what it wants to send to the property grid
            //          and could fill the parameters itself
            EntityNode entityNode = ((DisplayNode)node).EntityNode;

            string name = node.Name;

            if (node is EntityPropertyDisplayNode)
            {
               name = "Instance Property";
            }
            else if (node is LocalNodeDisplayNode)
            {
               name = ((LocalNodeDisplayNode)node).LocalNode.Value.Type; // get FriendlyName
               name = uScriptConfig.Variable.FriendlyName(name).Replace("UnityEngine.", string.Empty);
            }
            else if (node is OwnerConnectionDisplayNode)
            {
               name = "Owner GameObject";
            }
            
            PropertyGridParameters parameters = new PropertyGridParameters( name, entityNode, this ); 
            parameters.AddParameters( "Parameters", entityNode.Parameters );
            parameters.AddParameters( "Comment", new Parameter[] {entityNode.ShowComment, entityNode.Comment} );
            parameters.AddParameters( "Instance",new Parameter[] {entityNode.Instance} );

            if (entityNode is LogicNode)
            {
               parameters.AddParameters( "Inspector Name",new Parameter[] {((LogicNode)entityNode).InspectorName} );
            }

            gridParameters.Add( parameters );
         }

         if ( 0 == m_FlowChart.SelectedNodes.Length )
         {
            PropertyGridParameters parameters = new PropertyGridParameters( System.IO.Path.GetFileNameWithoutExtension(Name) + " Properties", null, this ); 
            parameters.AddParameters( "FriendlyName", new Parameter[] {m_ScriptEditor.FriendlyName} );
            parameters.AddParameters( "Description",  new Parameter[] {m_ScriptEditor.Description} );

            gridParameters.Add( parameters );
         }

         m_PropertyGrid.SelectedObjects = gridParameters.ToArray( );

         OnScriptModified( );
      }

      void m_PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
      {  
         RemoveEventHandlers( );

         Patch.Batch patchBatch = new Detox.Patch.Batch( "Property Changed" );
         
         bool globalModified = false;

         foreach ( object o in m_PropertyGrid.SelectedObjects )
         {
            bool changed = false;

            PropertyGridParameters p = (PropertyGridParameters) o;

            if ( null != p.EntityNode )
            {
               EntityNode entityNode  = p.EntityNode;
               EntityNode oldNode = entityNode.Copy( true );

               entityNode.Parameters  = p.GetParameters( "Parameters" );
               entityNode.ShowComment = p.GetParameters( "Comment" ) [ 0 ];
               entityNode.Comment     = p.GetParameters( "Comment" ) [ 1 ];
               entityNode.Instance    = p.GetParameters( "Instance" )[ 0 ];

               if (entityNode is LogicNode)
               {
                  LogicNode logicNode = (LogicNode) entityNode;
                  logicNode.InspectorName = p.GetParameters( "Inspector Name" )[ 0 ];
                  
                  entityNode = logicNode;
               }
               else if (entityNode is LocalNode)
               {
                  LocalNode localNode = (LocalNode) entityNode;
                  if ( localNode.Externaled.Default == "true" &&
                       localNode.Name.Default == ""
                     )
                  {
                     Parameter clonedExternal = localNode.Externaled;
                     clonedExternal.Default = "false";
                     
                     localNode.Externaled = clonedExternal;
                     entityNode = localNode;

                     //the old node might equal the new node
                     //but we still changed
                     //from the value in the property grid
                     changed = true;

                     //status updates aren't working and we have to get the build done
                     //so i'm forcing a log warning
                     uScriptDebug.Log( "For a variable to be made public, it must have a name.", uScriptDebug.Type.Warning );
                  }
                  else if (localNode.Name.Default != "")
                  {
                     globalModified = true;

                     if ( localNode.HideInInspector.Default == "true" &&
                         localNode.Externaled.Default == "false"
                         )
                     {
                        Parameter clonedHidden = localNode.HideInInspector;
                        clonedHidden.Default = "false";
                        
                        localNode.HideInInspector = clonedHidden;
                        entityNode = localNode;
                        
                        //the old node might equal the new node
                        //but we still changed
                        //from the value in the property grid
                        changed = true;
                        
                        //status updates aren't working and we have to get the build done
                        //so i'm forcing a log warning
                        uScriptDebug.Log( "For a variable to be hidden in the inspector, it must have a name and be made public.", uScriptDebug.Type.Warning );
                     }
                  }
               }
               else if (entityNode is ExternalConnection)
               {
                  globalModified = true;
               }

               List<EntityNode> oldGlobals = new List<EntityNode>( );

               //if a global was modified
               //it's going to modify all the other sync'ed values
               //so grab them first to add them to the undo stack
               if (true == globalModified)
               {
                  if (entityNode is LocalNode)
                  {
                     foreach (LocalNode local in m_ScriptEditor.Locals)
                     {
                        if (local.Guid == entityNode.Guid) continue;

                        if (local.Name.Default == ((LocalNode)entityNode).Name.Default)
                        {
                           if (local.Value.Type == ((LocalNode)entityNode).Value.Type)
                           {
                               oldGlobals.Add(local);
                           }
                           else
                           {
                               Parameter name = ((LocalNode)entityNode).Name;
                               name.Default = "";

                               LocalNode ln = (LocalNode) entityNode;
                               ln.Name = name;
                               
                               entityNode = ln;

                               uScriptDebug.Log( "Nodes with different types cannot share the same global name.", uScriptDebug.Type.Warning );
                           }
                        }
                     }
                  }
                  else if (entityNode is ExternalConnection)
                  {
                     foreach (ExternalConnection external in m_ScriptEditor.Externals)
                     {
                        if (external.Guid == entityNode.Guid) continue;

                        if (external.Name.Default == ((ExternalConnection)entityNode).Name.Default)
                        {
                           oldGlobals.Add(external);
                        }
                     }
                  }
               }
               
               m_ScriptEditor.AddNode( entityNode );

               if ( true == changed || false == oldNode.Equals(entityNode) )
               {
                  Patch.EntityNode undoParameter = new Patch.EntityNode( "Node Modified", oldNode, entityNode );
                  patchBatch.Add( undoParameter );

                  if (true == globalModified)
                  {
                     foreach (EntityNode oldGlobal in oldGlobals)
                     {
                        EntityNode newGlobal = m_ScriptEditor.GetNode(oldGlobal.Guid);

                        Patch.EntityNode globalUpdated = new Patch.EntityNode( "", oldGlobal, newGlobal );
                        patchBatch.Add( globalUpdated );
                     }
                  }
               }
            }
            else
            {
               ScriptEditor oldScript = m_ScriptEditor.Copy( );

               m_ScriptEditor.FriendlyName = p.GetParameters( "FriendlyName" )[ 0 ];
               m_ScriptEditor.Description  = p.GetParameters( "Description" )[ 0 ];

               Patch.ScriptEditorDesc undoParameter = new Patch.ScriptEditorDesc( "Script Modified", oldScript, m_ScriptEditor );
               patchBatch.Add( undoParameter );
            }
         }

         AddEventHandlers( );

         if ( true == patchBatch.HasPatches )
         {
            m_Dirty = true;

            uScript.Instance.RegisterUndo( patchBatch );
            PatchDisplay( patchBatch );
         }
      }

      private void FlowchartLinkCreated(object sender, FlowchartLinkCreatedEventArgs e)
      {
         RemoveEventHandlers( );

            LinkNode link = new LinkNode( e.Link.Source.Node.Guid, e.Link.Source.Anchor.Name, e.Link.Destination.Node.Guid, e.Link.Destination.Anchor.Name );
            m_ScriptEditor.AddNode( link );

         AddEventHandlers( );
         
         //remove it and then if it's successfully created the batch display patching will place it
         m_FlowChart.DeleteLink( link.Source.Guid, link.Source.Anchor, link.Destination.Guid, link.Destination.Anchor );

         //was it successful?
         if ( null != m_ScriptEditor.GetNode(link.Guid) )
         {
            m_Dirty = true;

            Patch.Batch batch = new Detox.Patch.Batch( "Link Created" );
            Patch.EntityNode patchNode;

            patchNode = new Detox.Patch.EntityNode("", null, link);
            batch.Add( patchNode );

            uScript.Instance.RegisterUndo( batch );
            PatchDisplay( batch );
         }         
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
            LinkNode linkNode;

            if ( true == m_FlowChart.LinkStartAnchor.Output && true == e.Point.Input )
            {
               linkNode = new LinkNode( m_FlowChart.LinkStartNode.Guid, m_FlowChart.LinkStartAnchor.Name, 
                                        node.Guid, e.Point.Name );
            }
            else
            {
               linkNode = new LinkNode( node.Guid, e.Point.Name,
                                       m_FlowChart.LinkStartNode.Guid, m_FlowChart.LinkStartAnchor.Name );
            }


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
         foreach ( ToolStripItem item in menu.DropDownItems )
         {
            if ( item.Text == name ) 
            {
               if ( item is ToolStripMenuItem )
               {
                  return (ToolStripMenuItem) item;
               }
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

      //cache add menu so we don't have to query all the types each time the context menu should be shown
      private ToolStripMenuItem m_AddMenu = null;

      private void m_ContextMenuStrip_Opening(object sender, CancelEventArgs args)
      {
         m_ContextObject = null;
         m_ContextCursor = Detox.Windows.Forms.Cursor.ScaledPosition;
         m_ContextCursor = m_FlowChart.PointToClient( m_ContextCursor );

         m_ContextMenuStrip.Items.Clear( );

         ToolStripMenuItem copyMenu     = new ToolStripMenuItem();
         ToolStripMenuItem pasteMenu    = new ToolStripMenuItem();
         ToolStripMenuItem collapseMenu = new ToolStripMenuItem();
         ToolStripMenuItem expandMenu   = new ToolStripMenuItem();
         ToolStripMenuItem collapseAll  = new ToolStripMenuItem();
         ToolStripMenuItem expandAll    = new ToolStripMenuItem();
         ToolStripMenuItem selectActive = new ToolStripMenuItem();

         ToolStripMenuItem upgradeNode       = new ToolStripMenuItem();
         ToolStripMenuItem deleteMissingNode = new ToolStripMenuItem();

         bool buildAddMenu = false;

         if ( null == m_AddMenu )
         {
            buildAddMenu = true;
            m_AddMenu = new ToolStripMenuItem( );
         }

         m_ContextMenuStrip.Items.Add( m_AddMenu );
         
         m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );

         expandAll.Name = "m_ExpandAllMenu";
         expandAll.Size = new Detox.Drawing.Size(152, 22);
         expandAll.Text = "Expand All";
         expandAll.Click += new System.EventHandler(m_MenuExpandAll_Click);

         m_ContextMenuStrip.Items.Add( expandAll );

         collapseAll.Name = "m_CollapseAllMenu";
         collapseAll.Size = new Detox.Drawing.Size(152, 22);
         collapseAll.Text = "Collapse All";
         collapseAll.Click += new System.EventHandler(m_MenuCollapseAll_Click);

         m_ContextMenuStrip.Items.Add( collapseAll );

         if ( CanExpand || CanCollapse )
         {
            m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );

            if ( CanExpand )
            {
               expandMenu.Name = "m_ExpandMenu";
               expandMenu.Size = new Detox.Drawing.Size(152, 22);
               expandMenu.Text = "E&xpand Selection";
               expandMenu.Click += new System.EventHandler(m_MenuExpand_Click);

               m_ContextMenuStrip.Items.Add( expandMenu );
            }

            if ( CanCollapse )
            {
               collapseMenu.Name = "m_CollapseMenu";
               collapseMenu.Size = new Detox.Drawing.Size(152, 22);
               collapseMenu.Text = "Co&llapse Selection";
               collapseMenu.Click += new System.EventHandler(m_MenuCollapse_Click);

               m_ContextMenuStrip.Items.Add( collapseMenu );
            }
         }

         if ( CanCopy || CanPaste )
         {
            m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );

            if ( CanCopy )
            {
               copyMenu.Name = "m_Copy";
               copyMenu.Size = new Detox.Drawing.Size(152, 22);
               copyMenu.Text = "Copy";
               copyMenu.Click += new System.EventHandler(m_MenuCopy_Click);

               m_ContextMenuStrip.Items.Add( copyMenu );
            }

            if ( CanPaste )
            {
               pasteMenu.Name = "m_Paste";
               pasteMenu.Size = new Detox.Drawing.Size(152, 22);
               pasteMenu.Text = "Paste";
               pasteMenu.Click += new System.EventHandler(m_MenuPaste_Click);

               m_ContextMenuStrip.Items.Add( pasteMenu );
            }
         }

         if ( ScriptEditor.SavedForDebugging )
         {
            bool hasBreakpoint = false;
            bool needsBreakpoint = false;

            foreach ( DisplayNode n in this.SelectedNodes )
            {
               if ( n is EntityEventDisplayNode || n is LogicNodeDisplayNode ||
                    n is EntityMethodDisplayNode )
               {
                  if ( true == uScript.MasterComponent.HasBreakpoint(n.Guid.ToString()) )
                  {
                     hasBreakpoint = true;
                  }
                  else
                  {
#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
                     needsBreakpoint = true;
#else
                     needsBreakpoint = false;
#endif
                  }
               }

               if ( true == hasBreakpoint && true == needsBreakpoint ) break;
            }

            if ( true == hasBreakpoint || true == needsBreakpoint )
            {
               m_ContextMenuStrip.Items.Add(new ToolStripSeparator());

               ToolStripMenuItem item;

#if !(DETOX_STORE_BASIC || UNITY_STORE_BASIC)
               if ( true == needsBreakpoint )
               {
                  item = new ToolStripMenuItem( );

                  item.Name = "m_AddBreakpoint";
                  item.Text = "Add Breakpoint";
                  item.Click += new System.EventHandler(m_MenuAddBreakpoint_Click);
                  
                  m_ContextMenuStrip.Items.Add( item );
               }
#endif
               if ( true == hasBreakpoint )
               {
                  item = new ToolStripMenuItem( );

                  item.Name = "m_RemoveBreakpoint";
                  item.Text = "Remove Breakpoint";
                  item.Click += new System.EventHandler(m_MenuRemoveBreakpoint_Click);
                  
                  m_ContextMenuStrip.Items.Add( item );
               }
            }

         }
         else
         {
            m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );
            m_ContextMenuStrip.Items.Add( new ToolStripMenuItem( "No Debug Info" ) );
         }


         if ( m_FlowChart.SelectedNodes.Length > 0 || m_FlowChart.SelectedLinks.Length > 0 )
         {
            m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );

            ToolStripMenuItem delete = new ToolStripMenuItem( "Delete Selected" );
            delete.Click += new System.EventHandler(m_MenuDeleteNode_Click);

            m_ContextMenuStrip.Items.Add( delete );
         }


         if ( true == buildAddMenu )
         {
            Profile buildAddProfile = new Profile ("BuildAddMenu");

            m_AddMenu.Name = "m_Add";
            m_AddMenu.Size = new Detox.Drawing.Size(152, 22);
            m_AddMenu.Text = "Add";

            ToolStripMenuItem comment  = new ToolStripMenuItem();
            ToolStripMenuItem external = new ToolStripMenuItem();

            comment.Name = "m_AddComment";
            comment.Size = new Detox.Drawing.Size(152, 22);
            comment.Text = "Comment";
            comment.Click += new System.EventHandler(m_MenuAddNode_Click);
            comment.Tag  = new CommentNode( "" );

            external.Name = "m_AddExternal";
            external.Size = new Detox.Drawing.Size(152, 22);
            external.Text = "External Connection";
            external.Click += new System.EventHandler(m_MenuAddNode_Click);
            external.Tag  = new ExternalConnection( Guid.NewGuid( ) );

            m_AddMenu.DropDownItems.Add( comment );
            m_AddMenu.DropDownItems.Add( external );

            BuildAddMenu( m_AddMenu, null );

            buildAddProfile.End();
         }


         //see if we can create an automatic link for the user
         foreach ( Node node in m_FlowChart.Nodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;
            if ( entityNode is LocalNode ) continue;

            Point position = Detox.Windows.Forms.Cursor.ScaledPosition;
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
                  createLink.Size   = new Detox.Drawing.Size(152, 22);
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
                  objectList.Size = new Detox.Drawing.Size(152, 22);
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
               selectActive.Size = new Detox.Drawing.Size(152, 22);
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
            
            int canUpgrade = 0;

            foreach ( DisplayNode node in SelectedNodes )
            {
               if ( true == node.Deprecated )
               {
                  if ( true == m_ScriptEditor.CanUpgradeNode(node.EntityNode) )
                  {
                     canUpgrade++;
                     if ( canUpgrade > 1 ) break;
                  }
               }
            }

            if ( canUpgrade > 0 )
            {
               upgradeNode.Name = "m_UpgradeNode";
               upgradeNode.Size = new Detox.Drawing.Size(152, 22);
               upgradeNode.Click += new System.EventHandler(m_MenuUpgradeNode_Click);

               if ( canUpgrade > 1 )
               {
                  upgradeNode.Text = "Upgrade Nodes";
               }
               else
               {
                  upgradeNode.Text = "Upgrade Node";
               }

               m_ContextMenuStrip.Items.Add( upgradeNode );
            }

            int canDeleteMissing = 0;

            foreach ( DisplayNode node in SelectedNodes )
            {
               if ( true == node.Deprecated )
               {
                  if ( false == m_ScriptEditor.CanUpgradeNode(node.EntityNode) )
                  {
                     canDeleteMissing++;
                     if ( canDeleteMissing > 1 ) break;
                  }
               }
            }

            if ( canDeleteMissing > 0 )
            {
               deleteMissingNode.Name = "m_DeleteMissingNode";
               deleteMissingNode.Size = new Detox.Drawing.Size(152, 22);
               deleteMissingNode.Click += new System.EventHandler(m_MenuDeleteMissingNode_Click);

               if ( canDeleteMissing > 1 )
               {
                  deleteMissingNode.Text = "Delete Missing Nodes";
               }
               else
               {
                  deleteMissingNode.Text = "Delete Missing Node";
               }

               m_ContextMenuStrip.Items.Add( deleteMissingNode );
            }
         }
      }

      private void BuildAddMenu(ToolStripMenuItem addMenu, Hashtable typeHash)
      {
         #if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene);
         #else
            UnityEngine.SceneManagement.Scene scene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();
            string sceneName = scene.name;
         #endif

         string sceneMenu = (typeHash == null
                             ? "Reflected (" + sceneName + ")"
                             : "Place <other>");

         //
         // Submenu items: Events
         //
         foreach ( EntityDesc desc in m_ScriptEditor.EntityDescs )
         {
            //if we care about types, and this type isn't registered, ignore it
            if ( null != typeHash && false == typeHash.Contains(desc.Type) ) continue;

            if ( desc.Events.Length > 0 )
            {   
               string categoryName = uScript.FindNodePath(sceneMenu + "/Events", desc.Type);

               ToolStripMenuItem friendlyMenu = GetMenu( addMenu, categoryName );

               Hashtable signatures = new Hashtable( );

               foreach ( EntityEvent e in desc.Events )
               {
                  if ( true == uScript.IsNodeTypeDeprecated(e) ) continue;

                  //guaranteed always at least one output from the reflection code
                  if ( false == signatures.Contains(e.FriendlyType) )
                  {
                     signatures[ e.FriendlyType ] = new List<EntityEvent>( );
                  }

                  List<EntityEvent> eventList = signatures[ e.FriendlyType ] as List<EntityEvent>;

                  eventList.Add( e );
               }

               foreach ( Object o in signatures.Values )
               {
                  List<EntityEvent> events = o as List<EntityEvent>;

                  if ( events.Count > 1 )
                  {
                     ToolStripMenuItem subMenu = new ToolStripMenuItem( events[0].FriendlyType );
                     friendlyMenu.DropDownItems.Add( subMenu );

                     foreach ( EntityEvent m in events )
                     {
                        ToolStripItem item = new ToolStripItem(m.FriendlyType + GetMethodSignature(m));
                        item.Tag = m;
                        subMenu.DropDownItems.Add( item );

                        item.Click += new System.EventHandler(m_MenuAddNode_Click);
                     }
                  }
                  else
                  {
                     ToolStripItem item = new ToolStripItem( events[0].FriendlyType );
                     friendlyMenu.DropDownItems.Add( item );
                     item.Tag = events[0];

                     item.Click += new System.EventHandler(m_MenuAddNode_Click);
                  }
               }
            }

            //
            // Submenu items: Actions
            //
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
                        ToolStripItem item = new ToolStripItem( m.Input.FriendlyName + GetMethodSignature(m) );
                        subMenu.DropDownItems.Add( item );
                        item.Tag = m;

                        item.Click += new System.EventHandler(m_MenuAddNode_Click);
                     }
                  }
                  else
                  {
                     ToolStripItem item = new ToolStripItem( methods[ 0 ].Input.FriendlyName );
                     friendlyMenu.DropDownItems.Add( item );
                     item.Tag = methods[0];

                     item.Click += new System.EventHandler(m_MenuAddNode_Click);
                  }
               }
            }

            //
            // Submenu items: Properties
            //
            if ( desc.Properties.Length > 0 )
            {
               string categoryName = uScript.FindNodePropertiesPath(sceneMenu + "/Properties/" + desc.Type, desc.Type);

               foreach ( EntityProperty e in desc.Properties )
               {
                  if ( true == uScript.IsNodeTypeDeprecated(e) ) continue;

                  var uScriptType = uScript.Instance.GetType(e.ComponentType);
                  if (uScriptType != null)
                  {
                     if (typeof(uScriptEvent).IsAssignableFrom(uScriptType)) continue;
                  }

                  ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName );

                  ToolStripItem item = new ToolStripItem( e.Parameter.FriendlyName );
                  friendlyMenu.DropDownItems.Add( item );
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

            string categoryName = uScript.FindNodePath(sceneMenu + "/Actions", node.Type);

            string friendlyName = node.FriendlyName;
            ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName);

            friendlyMenu.Tag = node;
            friendlyMenu.Click += new System.EventHandler(m_MenuAddNode_Click);
         }

         //
         // Variables
         //
         foreach ( string type in m_ScriptEditor.Types )
         {
            //if we care about types, and this type isn't registered, ignore it
            if ( null != typeHash && false == typeHash.Contains(type) ) continue;

            //don't show uscript logic nodes as variables
            Type t = uScript.Instance.GetType( type );
            if ( null != t && typeof(uScriptLogic).IsAssignableFrom(t) || typeof(uScriptEvent).IsAssignableFrom(t) ) continue;

            string friendlyName = uScriptConfig.Variable.FriendlyName(type);
            string categoryName = uScriptConfig.Variable.Category(type);

            if ("" == categoryName)
            {
               categoryName = sceneMenu + "/Variables";
            }
            else if (typeHash != null)
            {
               categoryName = string.Empty;
            }

            ToolStripMenuItem friendlyMenu = null;
            
            if ( null == typeHash )
            {
               friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName );
            }
            else
            {
               if (categoryName == string.Empty)
               {
                  friendlyMenu = GetMenu(addMenu, "Place Variable: " + friendlyName.Replace("UnityEngine.", string.Empty));
               }
               else
               {
                  friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName.Replace("UnityEngine.", string.Empty));
               }
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

      private static int MenuSorter(ToolStripItem t1, ToolStripItem t2)
      {
         bool subItems1 = t1.Text.Length > 0 && t1.Text[ t1.Text.Length - 1 ] == '.';
         bool subItems2 = t2.Text.Length > 0 && t2.Text[ t2.Text.Length - 1 ] == '.';

         if ( subItems1 == subItems2 )
         {
            return String.Compare( t1.Text, t2.Text ); 
         }

         //sub items for 1 so this comes second
         if ( true == subItems1 ) return -1;

         //sub items for 2 so this comes second
         return 1;
      }

      private void ReformatMenu(ToolStripMenuItem item)
      {
         if ( null == item ) return;
         
         if ( item.DropDownItems.Count > 0 )
         {
            item.Text += "...";
         }

         foreach ( ToolStripItem subItem in item.DropDownItems )
         {
            ReformatMenu( subItem as ToolStripMenuItem );
         }

         item.DropDownItems.Sort( MenuSorter );
      }

      private ContextMenuStrip PruneReflection(ContextMenuStrip contextMenuStrip)
      {
         if ( null == contextMenuStrip ) return null;

         ContextMenuStrip newContextStrip = new ContextMenuStrip();

         foreach ( ToolStripItem item in contextMenuStrip.Items )
         {
            ToolStripItem newItem = null;

            if ( item is ToolStripMenuItem )
            {
               // create a new copy to hold only the children we want
               ToolStripMenuItem newItems = new ToolStripMenuItem(item);

               foreach ( ToolStripItem subItem in ((ToolStripMenuItem)item).DropDownItems )
               {
                  if ( subItem.Text.StartsWith("Reflected") )
                     continue;

                  newItems.DropDownItems.Add( subItem );
               }

               newItem = newItems;
            }
            else if ( item is ToolStripSeparator )
               newItem = new ToolStripSeparator( );
            else if ( item is ToolStripItem )
               newItem = item;
            else
               throw new Exception("Unrecognized ToolStripItem Type: " + item.GetType() );
            
            newContextStrip.Items.Add( newItem );
         }

         return newContextStrip;
      }

      public static string GetTypeAlias(string type)
      {
         string[] tokens = type.Split('[');

         switch (tokens[0])
         {
            case "System.Byte":     tokens[0] = "byte";     break;
            case "System.SByte":    tokens[0] = "sbyte";    break;
            case "System.Int16":    tokens[0] = "short";    break;
            case "System.UInt16":   tokens[0] = "ushort";   break;
            case "System.Int32":    tokens[0] = "int";      break;
            case "System.UInt32":   tokens[0] = "uint";     break;
            case "System.Int64":    tokens[0] = "long";     break;
            case "System.UInt64":   tokens[0] = "ulong";    break;
            case "System.Single":   tokens[0] = "float";    break;
            case "System.Double":   tokens[0] = "double";   break;
            case "System.Decimal":  tokens[0] = "decimal";  break;
            case "System.Boolean":  tokens[0] = "bool";     break;
            case "System.Char":     tokens[0] = "char";     break;
            case "System.String":   tokens[0] = "string";   break;
         }

         return String.Join("[", tokens);
      }

      public static string GetMethodSignature(EntityNode node)
      {
         if (node is EntityMethod)
         {
            int parameterCount = node.Parameters.Length;

            if (parameterCount == 0)
            {
               return string.Empty;
            }

            string sig = "(";

            for (int i = 0; i < parameterCount; i++)
            {
               Parameter p = node.Parameters[i];

               // last parameter is the return type
               if (i == parameterCount - 1 && p.Output && p.Name == "Return")
               {
                  sig += ") : " + GetTypeAlias(p.Type);
                  return sig;
               }
               else
               {
                  if (i > 0)
                  {
                     sig += ", ";
                  }

//                  sig += p.Name + " : ";

                  if ( true == p.Input && true == p.Output )
                  {
                     sig += "ref ";
                  }
                  else if ( true == p.Output )
                  {
                     sig += "out ";
                  }

                  sig += GetTypeAlias(p.Type);
               }
            }

            sig += ")";

            return sig;
         }
         else if (node is EntityEvent)
         {
            //guaranteed from reflection code to have at least one output
            return "(" + ((EntityEvent)node).Outputs[0].FriendlyName + ")";
         }

         return "";
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
         public string DefaultValue;
         public Align  Alignment;
      }

      protected string NodeStyle = "node_default";
      protected ScriptEditorCtrl m_Ctrl = null;

      override public bool Selected 
      {
         set 
         {
            if (m_Selected != value)
            {
               m_Selected = value;

               UpdateStyleName();

               base.Selected = value;
            }
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
         m_EntityNode = node.Copy( true );

         UpdateStyleName(); 
      }

      public DisplayNode()
      { 
         UpdateStyleName(); 
      }

      public DisplayNode(EntityNode entityNode, ScriptEditorCtrl ctrl)
      {
         m_EntityNode = entityNode;
         m_Ctrl       = ctrl;
         
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
               textPoint.X = xStart + uScriptConfig.Style.PointSize + uScriptConfig.Style.IoSocketLabelHorizontalOffset;
               textPoint.Y = (y - (textLength.Height / 2 + uScriptConfig.Style.IoSocketLabelVerticalOffset));
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
               textPoint.X =  (xStart - (uScriptConfig.Style.PointSize + textLength.Width)) - uScriptConfig.Style.IoSocketLabelHorizontalOffset;
               textPoint.Y =  (y - (textLength.Height / 2)) - uScriptConfig.Style.IoSocketLabelVerticalOffset;
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
         
         float charLength = Graphics.sMeasureString( "W", "value_text" ).Width;

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
               
               string text;

               // Draw the socket value label under the socket
               if ( null != socket.DefaultValue )
               {
                  int charsForLabel = (int)(((xStep + textLength.Width) * 1.75f) / charLength);
                  charsForLabel = Math.Max( 3, charsForLabel );

                  if (socket.Type.Contains("Mask"))
                  {
                     text = uScriptGUI.FormatMaskDisplay(socket.DefaultValue);
                  }
                  else
                  {
                     text = Parameter.FormatArrayString( socket.DefaultValue );
                  }

                  if ( text.Length > charsForLabel ) text = text.Substring( 0, charsForLabel - 3 ) + "...";

                  SizeF valueLength = Graphics.sMeasureString( text, "value_text" );

                  textPoint.Name = text;
                  textPoint.X = (x + xOffset + ((textLength.Width - valueLength.Width) / 2)) - uScriptConfig.Style.SocketValueTextHorizontalOffset;
                  textPoint.Y = Size.Height + uScriptConfig.Style.SocketValueTextVerticalOffset + valueLength.Height / 2;
                  textPoint.StyleName = "value_text";
                  textPoints.Add( textPoint );              
               }

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
                  // Update the name before calculating the size, because we'll use it for the calculation
                  TextPoint textPoint = new TextPoint( );
                  textPoint.Name = Parameter.FormatArrayString( FormatName(socket) );

                  SizeF size = Graphics.sMeasureString( textPoint.Name, "socket_text" );

                  textPoint.X = (Size.Width  - uScriptConfig.Style.RightShadow - size.Width) / 2;
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

      public void RefreshPoints( )
      {
         PreparePoints( );
      }
      
      protected void UpdateStyleName()
      {
         UnselectedStyleName = NodeStyle;
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
            
            e.Graphics.FillRectangle("title_comment", new Rectangle(location.X, location.Y, Size.Width, Size.Height), comment, this);
         }

         base.OnPaint( e );

         if ( this is EntityEventDisplayNode || this is LogicNodeDisplayNode ||
              this is EntityMethodDisplayNode )
         {
            if ( true == m_Ctrl.ScriptEditor.SavedForDebugging &&
                 true == uScript.MasterComponent.HasBreakpoint(Guid.ToString()) )
            {
               PaintBreakpoint( );
            }
            else
            {
               m_CenteredOnBP = false;
            }
         }
      }
  
      private bool m_CenteredOnBP = false;
      protected void PaintBreakpoint( )
      {
         UnityEngine.Color color = UnityEditor.Handles.color;
         UnityEditor.Handles.color = UnityEngine.Color.red;

         float radius = 8;

         if ( uScript.MasterComponent.CurrentBreakpoint == Guid.ToString() )
         {
            UnityEditor.Handles.color = UnityEngine.Color.yellow;
            radius = 16;
            if ( !m_CenteredOnBP )
            {
               m_Ctrl.CenterOnNode( this );
            }
            m_CenteredOnBP = true;
         }

         //radius *= ZoomScale;

         PointF location = new PointF( Location.X + Parent.Location.X + radius / 2, Location.Y + Parent.Location.Y + radius / 2);
         //location.X *= ZoomScale;
         //location.Y *= ZoomScale;

         UnityEditor.Handles.DrawSolidDisc(new UnityEngine.Vector3(location.X, location.Y, 0), new UnityEngine.Vector3(0, 0, -1), radius);
      
         UnityEditor.Handles.color = color;
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
