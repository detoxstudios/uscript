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

      public bool CanUndo { get { return m_ChangeStack.HasUndos; } }
      public bool CanRedo { get { return m_ChangeStack.HasRedos; } }

      public string UndoMessage { get { return m_ChangeStack.UndoMessage; } }
      public string RedoMessage { get { return m_ChangeStack.RedoMessage; } }

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

      private ChangeStack m_ChangeStack = new ChangeStack( );
      
      private PropertyGrid m_PropertyGrid = null;
      public PropertyGrid PropertyGrid { get { return m_PropertyGrid; } }

      private ScriptEditor m_ScriptEditor = null;
      public ScriptEditor ScriptEditor { get { return m_ScriptEditor; } }
		
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
         set { m_Dirty = false; }
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

      private void UndoChange(object sender, ChangeStack.ChangeEventArgs args)
      {
         m_ScriptEditor = args.ChangedObject as ScriptEditor;
         RefreshScript( null );
      }

      private void RedoChange(object sender, ChangeStack.ChangeEventArgs args)
      {
         m_ScriptEditor = args.ChangedObject as ScriptEditor;
         RefreshScript( null );
      }

      public void Undo( )
      {
         m_ChangeStack.Undo( );
      }

      public void Redo( )
      {
         m_ChangeStack.Redo( );
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
               string type = uScript.FindNodeType(entityNode);
               Type t = uScript.Instance.GetAssemblyQualifiedType(type);

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

            Point point = node.PointToClient( Cursor.Position );

            if ( point.X >= 0 && point.Y >= 0 && 
                 point.X <= node.Size.Width &&
                 point.Y <= node.Size.Height )
            {
               string type = uScript.FindNodeType(entityNode);
               Type t = uScript.Instance.GetAssemblyQualifiedType(type);

               if ( typeof(uScriptLogic).IsAssignableFrom(t) )
               {  
                  uScriptLogic logic = UnityEngine.ScriptableObject.CreateInstance( t ) as uScriptLogic;
                  Hashtable hash = logic.EditorDragDrop( o );
               
                  Parameter [] parameters = entityNode.Parameters;

                  for ( int i = 0; i < parameters.Length; i++ )
                  {
                     if ( hash.Contains(parameters[i].FriendlyName) )
                     {
                        parameters[i].Default = hash[ parameters[i].FriendlyName ].ToString();
                     }
                     else if ( hash.Contains(parameters[i].Name) )
                     {
                        parameters[i].Default = hash[ parameters[i].Name ].ToString();
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
				
			Point basePoint = Point.Empty;
			if (cursorPoint != Point.Empty)
			{
			   // if executed from the context menu, calculate a base point for this script chunk
			   float left = float.MaxValue, top = float.MaxValue;
			   foreach ( EntityNode entityNode in scriptEditor.EntityNodes )
			   {
                  if ( typeof(LinkNode).IsAssignableFrom(entityNode.GetType()) ) continue;
			      if (entityNode.Position.X < left) left = entityNode.Position.X;
			      if (entityNode.Position.Y < top)  top  = entityNode.Position.Y;
			   }
			   basePoint = new Point( (int)left, (int)top );
			}

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
			   if (basePoint == Point.Empty)
			   {
	              clone.Position = new Point( clone.Position.X + 10, clone.Position.Y + 10 );
			   }
			   else
			   {
				  Point diff = new Point( clone.Position.X - basePoint.X, clone.Position.Y - basePoint.Y );
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

      private void m_MenuUndo_Click(object sender, EventArgs e)
      {
         Undo( );
      }
      
      private void m_MenuRedo_Click(object sender, EventArgs e)
      {
         Redo( );
      }

      private void m_MenuCopy_Click(object sender, EventArgs e)
      {
         CopyToClipboard( );
      }

      private void m_MenuPaste_Click(object sender, EventArgs e)
      {
         PasteFromClipboard( ContextCursor );
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

                     string type = entityNode.Instance.Type;

                     if ( entityNode is EntityMethod )
                     {
                        type = ((EntityMethod)entityNode).ComponentType;
                     }
                     else if ( entityNode is EntityEvent )
                     {
                        type = ((EntityEvent)entityNode).ComponentType;
                     }

                     uScript.Instance.AttachEventScript(type, entityNode.Instance.Default);
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
         
               string type = entityNode.Instance.Type;

               if ( entityNode is EntityMethod )
               {
                  type = ((EntityMethod)entityNode).ComponentType;
               }
               else if ( entityNode is EntityEvent )
               {
                  type = ((EntityEvent)entityNode).ComponentType;
               }

               uScript.Instance.AttachEventScript(type, entityNode.Instance.Default);
            }

            m_ScriptEditor.AddNode( entityNode );
            m_Dirty = true;
         }

         m_ChangeStack.AddChange( new ChangeStack.Change("Add", oldEditor, m_ScriptEditor.Copy( )) );

         RefreshScript( null );
      }

      private void m_MenuUpgradeNode_Click(object sender, EventArgs e)
      {
         foreach ( DisplayNode node in SelectedNodes )
         {
            m_ScriptEditor.UpgradeNode( node.EntityNode );
         }

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
            
            if ( m_ScriptEditor.IsDeprecated(commentNode) ) node.Deprecate( );
         
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
                     
            if ( m_ScriptEditor.IsDeprecated(entityEvent) ) node.Deprecate( );

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

            if ( m_ScriptEditor.IsDeprecated(entityMethod) ) node.Deprecate( );

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

            if ( m_ScriptEditor.IsDeprecated(entityProperty) ) node.Deprecate( );

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

            if ( m_ScriptEditor.IsDeprecated(localNode) ) node.Deprecate( );

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

            if ( m_ScriptEditor.IsDeprecated(logicNode) ) node.Deprecate( );

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

            if ( m_ScriptEditor.IsDeprecated(external) ) node.Deprecate( );

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

            PropertyGridParameters parameters = new PropertyGridParameters( name, entityNode ); 
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

            //special case to add required scripts to gameobjects
            if ( entityNode is EntityEvent )
            {
               uScript.AttachError error = uScript.Instance.AttachEventScript(((EntityEvent)entityNode).ComponentType, entityNode.Instance.Default);
               if ( error == uScript.AttachError.MissingComponent )
               {
                  //couldn't attach an appropriate script for this game object
                  //because it was missing a key component
                  //so refresh the property grid
                  Parameter instance = entityNode.Instance;
                  instance.Default = "";

                  entityNode.Instance = instance;

                  FlowchartSelectionModified( null, null );
               }
            }

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

      private void RemoveEventHandlers( )
      {
         m_FlowChart.NodesModified     -= FlowchartNodesModified;
         m_FlowChart.SelectionModified -= FlowchartSelectionModified;
         m_FlowChart.LinkCreated       -= FlowchartLinkCreated;
         m_FlowChart.PointRender       -= FlowchartPointRender;

         m_ChangeStack.UndoChange -= UndoChange;
         m_ChangeStack.RedoChange -= RedoChange;

         m_PropertyGrid.PropertyValueChanged -= new PropertyValueChangedEventHandler(m_PropertyGrid_PropertyValueChanged);
      }

      public void AddEventHandlers( )
      {
         m_FlowChart.NodesModified     += FlowchartNodesModified;
         m_FlowChart.SelectionModified += FlowchartSelectionModified;
         m_FlowChart.LinkCreated       += FlowchartLinkCreated;
         m_FlowChart.PointRender       += FlowchartPointRender;

         m_ChangeStack.UndoChange += UndoChange;
         m_ChangeStack.RedoChange += RedoChange;

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

         ToolStripMenuItem addMenu  = new ToolStripMenuItem();
         ToolStripMenuItem copyMenu = new ToolStripMenuItem();
         ToolStripMenuItem pasteMenu= new ToolStripMenuItem();
         ToolStripMenuItem undoMenu = new ToolStripMenuItem();
         ToolStripMenuItem redoMenu = new ToolStripMenuItem();
         ToolStripMenuItem upgradeNode = new ToolStripMenuItem();

         m_ContextMenuStrip.Items.Add( addMenu );
         
         if ( m_FlowChart.SelectedNodes.Length > 0 || m_FlowChart.SelectedLinks.Length > 0 )
         {
            ToolStripMenuItem delete = new ToolStripMenuItem( "Delete Selected" );
            delete.Click += new System.EventHandler(m_MenuDeleteNode_Click);

            m_ContextMenuStrip.Items.Add( delete );
         }

         m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );
         
         if ( CanUndo )
         {
            undoMenu.Name = "m_UndoMenu";
            undoMenu.Size = new System.Drawing.Size(152, 22);
            undoMenu.Text = "&Undo " + m_ChangeStack.UndoMessage;
            undoMenu.Click += new System.EventHandler(m_MenuUndo_Click);

            m_ContextMenuStrip.Items.Add( undoMenu );
         }

         if ( CanRedo )
         {
            redoMenu.Name = "m_RedoMenu";
            redoMenu.Size = new System.Drawing.Size(152, 22);
            redoMenu.Text = "&Redo " + m_ChangeStack.RedoMessage;
            redoMenu.Click += new System.EventHandler(m_MenuRedo_Click);

            m_ContextMenuStrip.Items.Add( redoMenu );
         }

         if ( CanUndo || CanRedo )
         {
            m_ContextMenuStrip.Items.Add( new ToolStripSeparator( ) );
         }

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

               if ( hitPoint.Name == entityNode.Instance.Name )
               {
                  allowLink = true;
               }
               else
               {
                  foreach ( Parameter p in entityNode.Parameters )
                  {
                     if ( p.Name == hitPoint.Name )
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

               if ( true == node.Deprecated )
               {
                  upgradeNode.Name = "m_UpgradeNode";
                  upgradeNode.Size = new System.Drawing.Size(152, 22);
                  upgradeNode.Text = "Upgrade Node";
                  upgradeNode.Click += new System.EventHandler(m_MenuUpgradeNode_Click);

                  m_ContextMenuStrip.Items.Add( upgradeNode );
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
                  ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName );

                  ToolStripItem item = friendlyMenu.DropDownItems.Add( e.Parameter.FriendlyName );
                  item.Tag = e;

                  item.Click += new System.EventHandler(m_MenuAddNode_Click);
               }
            }
         }

         foreach ( LogicNode node in m_ScriptEditor.LogicNodes )
         {
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
      public class ChangeEventArgs : EventArgs
      {
         public Object ChangedObject;
      
         public ChangeEventArgs(object o)
         {
            ChangedObject = o;
         }
      }

      public delegate void ChangeEventHandler(object sender, ChangeEventArgs e);

      public event ChangeEventHandler UndoChange;
      private void OnUndoChange(Object changedObject)
      {
         if (null != UndoChange) UndoChange(this, new ChangeEventArgs(changedObject));
      }

      public event ChangeEventHandler RedoChange;
      private void OnRedoChange(Object changedObject)
      {
         if (null != RedoChange) RedoChange(this, new ChangeEventArgs(changedObject));
      }

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

      private List<Change> m_Stack = new List<Change>( );

      private int m_Undo = -1;
      private int m_Redo = 0;

      public bool HasUndos { get { return m_Undo > -1; } }
      public bool HasRedos { get { return m_Redo < m_Stack.Count; } }
   
      public string UndoMessage 
      { 
         get 
         { 
            if ( false == HasUndos ) return "";
            return m_Stack[ m_Undo ].Name;
         }
      }

      public string RedoMessage 
      { 
         get 
         { 
            if ( false == HasRedos ) return "";
            return m_Stack[ m_Redo ].Name;
         }
      }

      private bool m_LockChanges = false;

      public void AddChange(Change change)
      {
         if ( true == m_LockChanges ) return;

         if ( m_Undo >= 0 )
         {
            //remove everything after us in the stack
            //because this change starts a new branch
            m_Stack.RemoveRange( m_Undo + 1, m_Stack.Count - (m_Undo + 1) );
         }

         m_Undo = m_Stack.Count( );

         m_Stack.Add( change );

         m_Redo = m_Stack.Count;
      }

      public void Undo( )
      {
         m_LockChanges = true;

         if ( m_Undo > -1 && m_Undo < m_Stack.Count )
         {
            m_Redo = m_Undo;
            
            Change change = m_Stack[ m_Undo ];
            --m_Undo;

            OnUndoChange( change.OldObject );
         }

         m_LockChanges = false;
      }

      public void Redo( )
      {
         m_LockChanges = true;

         if ( m_Redo > -1 && m_Redo < m_Stack.Count )
         {
            m_Undo = m_Redo;

            Change change = m_Stack[ m_Redo ];
            ++m_Redo;

            OnRedoChange( change.NewObject );
         }

         m_LockChanges = false;
      }
   };

   public class PropertyGridParameters
   {
      public EntityNode EntityNode;
      public string     Description;

      public PropertyGridParameters( string description, EntityNode node ) { Description = description; EntityNode = node; }

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

