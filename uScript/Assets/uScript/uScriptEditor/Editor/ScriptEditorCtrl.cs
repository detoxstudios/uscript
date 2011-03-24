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
      object m_ContextObject;

      public ScriptEditorCtrl(ScriptEditor scriptEditor)
      {  
         InitializeComponent();
                  
         m_ContextObject = null;
         m_ContextCursor = Point.Empty;

         m_ScriptEditor = scriptEditor;

         m_PropertyGrid = new PropertyGrid( );

         Name    = m_ScriptEditor.Name;
         Text    = m_ScriptEditor.Name;
         TabText = m_ScriptEditor.Name;

         RefreshScript( null, true );
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

      public bool CanDragDrop( object o )
      {
         foreach ( Node node in m_FlowChart.Nodes )
         {
            EntityNode entityNode = ((DisplayNode)node).EntityNode;

            Point point = node.PointToClient( Cursor.Position );

            if ( point.X >= 0 && point.Y >= 0 && 
                 point.X <= node.Size.Width &&
                 point.Y <= node.Size.Height )
            {               
               if ( true == typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()) )
               {   
                  string destTypeString = null;

                  if ( entityNode.Instance != Parameter.Empty )
                  {
                     destTypeString = entityNode.Instance.Type;
                  }
                  else if ( entityNode is LocalNode )
                  {
                     LocalNode local = (LocalNode) entityNode;
                     destTypeString = local.Value.Type;
                  }

                  if ( null != destTypeString )
                  {
                     destTypeString = destTypeString.Replace( "[]", "" );

                     //see if the game object being dragged
                     //has a component type we can use
                     UnityEngine.GameObject gameObject = (UnityEngine.GameObject) o;
                     
                     //see if the game object being dragged
                     //has a component type we can use
                     if ( null != gameObject.GetComponent(destTypeString) )
                     {
                        return true;
                     }

                     Type destType = uScript.Instance.GetType(destTypeString);

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

         //no nodes were intersected so allow context menu
         if ( true == typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()) )
         {
            return true;
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
               if ( true == typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType( )) )
               {
                  string destTypeString = null;

                  if ( entityNode.Instance != Parameter.Empty )
                  {
                     destTypeString = entityNode.Instance.Type;
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

                     string name = null;

                     //see if the game object being dragged
                     //has a component type we can use
                     UnityEngine.GameObject gameObject = (UnityEngine.GameObject) o;
                     
                     //see if the game object being dragged
                     //has a component type we can use
                     if ( null != gameObject.GetComponent(destTypeString) )
                     {
                        name = ((UnityEngine.Object)o).name;
                     }

                     Type destType = uScript.Instance.GetType(destTypeString);

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

      public bool DoDragDropContextMenu( object o )
      {
         //no nodes were intersected so allow context menu
         if ( true == typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()) )
         {
            m_ContextObject = o;
            m_ContextCursor = System.Windows.Forms.Cursor.Position;
            m_ContextCursor = m_FlowChart.PointToClient( m_ContextCursor );

            m_ContextMenuStrip.Items.Clear( );

            ToolStripMenuItem addMenu = new ToolStripMenuItem();
            addMenu.Text = "Add";

            Hashtable typeHash = new Hashtable( );

            UnityEngine.GameObject gameObject = (UnityEngine.GameObject) o;
            
            foreach ( UnityEngine.Component component in gameObject.GetComponents(typeof(UnityEngine.Component)) )
            {
               typeHash[ component.GetType().ToString() ] = true;
            }
            
            BuildAddMenu( addMenu, typeHash );

            m_ContextMenuStrip.Items.AddRange( addMenu.DropDownItems.Items.ToArray( ) );

            return true;
         }

         return false;
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

      public void PasteFromClipboard( )
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
               clone.Position = new Point( clone.Position.X + 10, clone.Position.Y + 10 );
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
         PasteFromClipboard( );
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

            LocalNode localNode = new LocalNode( "", linkTo.Type.Replace("[]", ""), "" );
            localNode.Position = point;

            m_ScriptEditor.AddNode( localNode );

            LinkNode linkNode = new LinkNode( localNode.Guid, localNode.Value.Name, node.Guid, linkTo.Name );
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
         EntityNode entityNode = (EntityNode) ((EntityNode) item.Tag).Copy( );

         entityNode.Position = new Point( m_ContextCursor.X, m_ContextCursor.Y );

         if ( null != m_ContextObject && typeof(UnityEngine.Object).IsAssignableFrom(m_ContextObject.GetType()) )
         {
            if ( entityNode.Instance != Parameter.Empty )
            {
               Parameter instance = entityNode.Instance;
               instance.Default = ((UnityEngine.Object)m_ContextObject).name;
               entityNode.Instance = instance;
            }
            else if ( entityNode is LocalNode )
            {
               LocalNode local = (LocalNode) entityNode;

               Parameter value = local.Value;
               value.Default = ((UnityEngine.Object)m_ContextObject).name;
               local.Value = value;
            
               entityNode = local;
            }
         }

         m_ScriptEditor.AddNode( entityNode );
         m_Dirty = true;

         m_ChangeStack.AddChange( new ChangeStack.Change("Add", oldEditor, m_ScriptEditor.Copy( )) );

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

      private void m_MenuDeleteNode_Click(object sender, EventArgs e)
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

      private void RefreshScript( List<Guid> guidsToSelect )
      {
         RefreshScript(guidsToSelect, false);
      }

      private void RefreshScript( List<Guid> guidsToSelect, bool zoomExtents )
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

         // zoom extents
         if (zoomExtents && m_FlowChart.Nodes.Length > 0)
         {
            // center on the center for now - later, we'll calculate zoom amount, etc.
            int halfWidth = (int)(uScript.Instance.NodeWindowRect.width / 2.0f);
            int halfHeight = (int)(uScript.Instance.NodeWindowRect.height / 2.0f);
            Point center = new Point((int)(minX + (maxX - minX) / 2.0f), (int)(minY + (maxY - minY) / 2.0f));
            m_FlowChart.Location = new Point(Math.Min(0, Math.Max(-4096, -center.X + halfWidth)), Math.Min(0, Math.Max(-4096, -center.Y + halfHeight - (int)uScript.Instance.NodeToolbarRect.height)));
            m_FlowChart.Invalidate();
         }

         OnScriptModified();

         AddEventHandlers( );
      
         foreach ( LocalNode node in m_ScriptEditor.Locals )
         {
            if ( uScriptConfig.Variable.FriendlyName(node.Value.Type) == "GameObject" )
            {
               uScript.Instance.AttachVariableScript(node.Value.Default);
            }
         }
      }

      private void FlowchartNodesModified(object sender, FlowchartNodesModifiedEventArgs e)
      {
         ScriptEditor oldEditor = m_ScriptEditor.Copy( );

         RemoveEventHandlers( );

            foreach ( FlowChart.Node node in e.Nodes )
            {
               EntityNode entityNode = ((DisplayNode)node).EntityNode;
               entityNode.Position = ((DisplayNode)node).Location;

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

            PropertyGridParameters parameters = new PropertyGridParameters( node.Name, entityNode ); 
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
               if ( false == uScript.Instance.AttachEventScript(entityNode.Instance.Type, entityNode.Instance.Default) )
               {
                  //couldn't attach an appropriate script for this game object
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
            if ( true == m_ScriptEditor.VerifyLink(linkNode) )
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
            if ( item.Text == name ) return (ToolStripMenuItem) item;
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
         foreach ( EntityDesc desc in m_ScriptEditor.EntityDescs )
         {
               //if we care about types, and this type isn't registered, ignore it
            if ( null != typeHash && false == typeHash.Contains(desc.Type) ) continue;

            if ( desc.Events.Length > 0 )
            {   
               string categoryName = uScript.FindNodePath("Advanced/Events", desc.Type);

               string friendlyName = uScriptConfig.Variable.FriendlyName(desc.Type);
               ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName);

               foreach ( EntityEvent e in desc.Events )
               {
                  ToolStripItem item = friendlyMenu.DropDownItems.Add( e.Output.FriendlyName + BuildSignature(e) );
                  item.Tag = e;

                  item.Click += new System.EventHandler(m_MenuAddNode_Click);
               }
            }

            if ( desc.Methods.Length > 0 )
            {
               string categoryName = uScript.FindNodePath("Advanced/Actions", desc.Type);

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
               string categoryName = uScript.FindNodePath("Advanced/Properties", desc.Type);

               string friendlyName = uScriptConfig.Variable.FriendlyName(desc.Type);
               ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName);

               foreach ( EntityProperty e in desc.Properties )
               {
                  ToolStripItem item = friendlyMenu.DropDownItems.Add( e.Parameter.Name );
                  item.Tag = e;

                  item.Click += new System.EventHandler(m_MenuAddNode_Click);
               }
            }
         }

         foreach ( LogicNode node in m_ScriptEditor.LogicNodes )
         {
            //if we care about types, and this type isn't registered, ignore it
            if ( null != typeHash && false == typeHash.Contains(node.Type) ) continue;

            string categoryName = uScript.FindNodePath("Advanced/Logic", node.Type);

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
            if ("" == categoryName) categoryName = "Advanced/Variables";

            string friendlyName = uScriptConfig.Variable.FriendlyName(type);
            ToolStripMenuItem friendlyMenu = GetMenu(addMenu, categoryName + "/" + friendlyName);

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

      private bool m_DirtySockets = false;

      private EntityNode m_EntityNode;
      public EntityNode EntityNode { get { return m_EntityNode; } }

      Socket [] m_Sockets = new Socket[ 0 ];

      public override Guid Guid { get { return m_EntityNode.Guid; } }

      protected void UpdateNode(EntityNode node)
      {
         m_EntityNode = node;
      }

      public DisplayNode()
      {}

      public DisplayNode(EntityNode entityNode)
      {
         m_EntityNode = entityNode;
      }

      int topPointsExtraPad = 0;

      protected string FormatName(Socket socket)
      {
         return socket.FriendlyName;
      }

      protected virtual void LeftPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints, Graphics g)
      {
         SizeF titleLength = null == g ? new SizeF(uScriptConfig.Style.PointPad, uScriptConfig.Style.PointPad) : g.MeasureString( Name, NodeStyle );

         float xStart= uScriptConfig.Style.LeftPad;
         float yStep = uScriptConfig.Style.PointSize + uScriptConfig.Style.PointPad;

         float y = (uScriptConfig.Style.TopPad + uScriptConfig.Style.TitleTopBottomPad + titleLength.Height) + topPointsExtraPad;

         foreach ( Socket socket in sockets )
         {
            if ( socket.Alignment == Socket.Align.Left )
            {
               SizeF textLength = null == g ? new SizeF(uScriptConfig.Style.PointSize, uScriptConfig.Style.PointSize) : g.MeasureString( FormatName(socket), "socket_text" );

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
               textPoint.X = xStart + uScriptConfig.Style.PointSize;
               textPoint.Y = (y - (textLength.Height / 2));
               textPoint.StyleName = "socket_text";
               textPoints.Add( textPoint );
            
               y += (yStep + textLength.Height);
            }
         }
      }

      protected virtual void RightPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints, Graphics g)
      {
         SizeF titleLength = null == g ? new SizeF(uScriptConfig.Style.PointPad, uScriptConfig.Style.PointPad) : g.MeasureString( Name, NodeStyle );

         float xStart = Size.Width - uScriptConfig.Style.RightPad;
         float yStep  = uScriptConfig.Style.PointSize + uScriptConfig.Style.PointPad;

         float y = (uScriptConfig.Style.TopPad + uScriptConfig.Style.TitleTopBottomPad + titleLength.Height) + topPointsExtraPad;

         foreach ( Socket socket in sockets )
         {
            if ( socket.Alignment == Socket.Align.Right )
            {
               SizeF textLength = null == g ? new SizeF(uScriptConfig.Style.PointSize, uScriptConfig.Style.PointSize) : g.MeasureString( FormatName(socket), "socket_text" );

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
               textPoint.X =  (xStart - (uScriptConfig.Style.PointSize + textLength.Width));
               textPoint.Y =  (y - (textLength.Height / 2));
               textPoint.StyleName = "socket_text";
               textPoints.Add( textPoint );
            
               y += (yStep + textLength.Height);
            }
         }
      }

      protected virtual void BottomPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints, Graphics g)
      {
         float yStart = Size.Height - uScriptConfig.Style.BottomPad;
        
         float totalTextWidth = 0;
         float xStep = uScriptConfig.Style.PointPad + uScriptConfig.Style.PointSize + uScriptConfig.Style.PointPad;

         foreach ( Socket socket in sockets )
         {
            if ( socket.Alignment == Socket.Align.Bottom )
            {
               SizeF textLength = null == g ? new SizeF(uScriptConfig.Style.PointSize, uScriptConfig.Style.PointSize) : g.MeasureString( FormatName(socket), "socket_text" );

               totalTextWidth += xStep;
               totalTextWidth += textLength.Width;
            }
         }

         //now we know the total text width, we can figure out where to start it
         float x = (Size.Width - uScriptConfig.Style.RightShadow - totalTextWidth) / 2;
         
         //starting offset to draw the point and text for each x position
         //point pad preceeding the x and half the point size
         float xOffset = uScriptConfig.Style.PointPad + uScriptConfig.Style.PointSize / 2;

         foreach ( Socket socket in sockets )
         {
            if ( socket.Alignment == Socket.Align.Bottom )
            {
               AnchorPoint point = new AnchorPoint( );
               TextPoint textPoint = new TextPoint( );

               SizeF textLength = null == g ? new SizeF(uScriptConfig.Style.PointSize, uScriptConfig.Style.PointSize) : g.MeasureString( FormatName(socket), "socket_text" );

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
               textPoint.Y = (yStart - uScriptConfig.Style.PointSize - textLength.Height);
               textPoint.StyleName = "socket_text";
               textPoints.Add( textPoint );
            
               x += (xStep + textLength.Width);
            }
         }
      }

      protected virtual void CenterPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints, Graphics g)
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
                  float height = null == g ? uScriptConfig.Style.PointSize : g.MeasureString( FormatName(socket), "socket_text" ).Height;

                  float y = (Size.Height - uScriptConfig.Style.BottomShadow - height) /  2;

                  string [] subString = FormatName(socket).Split( '\n' );

                  foreach ( string s in subString )
                  {
                     TextPoint textPoint = new TextPoint( );

                     string style = "socket_text";

                     if ( s == subString[0] && subString.Length > 1 )
                     {
                        style = "socket_text_bold";
                     }

                     SizeF textLength = null == g ? new SizeF(uScriptConfig.Style.PointSize, uScriptConfig.Style.PointSize) : g.MeasureString( s, style );

                     textPoint.Name = s;
                     textPoint.X = (Size.Width - uScriptConfig.Style.RightShadow - textLength.Width) / 2;
                     textPoint.Y = y;
                     textPoint.StyleName = style;
                     
                     y += textLength.Height;

                     textPoints.Add( textPoint );
                  }
               }
            }
         }
      }

      protected void UpdateSockets(Socket []sockets)
      {  
         AnchorPoints = new AnchorPoint[0];
         TextPoints   = new TextPoint  [0];
         
         m_Sockets = sockets;
         PreparePoints( null );

         m_DirtySockets = true;
      }

      public override void OnPaint( PaintEventArgs e )
      {
         if ( false == Selected ) StyleName = NodeStyle;
         else 
         {
            string []subString = NodeStyle.Split( '_' );
            
            if ( subString[0] == "comment" ) subString[0] = "node";
            StyleName = subString[0] + "_selected";
  
         }

         if ( true == m_DirtySockets )
         {
            PreparePoints( e.Graphics );
            m_DirtySockets = false;
         }

         base.OnPaint( e );
      }

      protected virtual Size CalculateSize(Socket []sockets, Graphics g)
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

         foreach ( Socket socket in sockets )
         {
            SizeF textLength = null == g ? new SizeF(uScriptConfig.Style.PointPad, uScriptConfig.Style.PointPad) : g.MeasureString( FormatName(socket), "socket_text" );
            
            if ( socket.Alignment == Socket.Align.Bottom )
            {
               requiredWidth += uScriptConfig.Style.PointPad + uScriptConfig.Style.PointSize + uScriptConfig.Style.PointPad;
               requiredWidth += textLength.Width;
            }
            else if ( socket.Alignment == Socket.Align.Left )
            {
               maxLeftAlignedText = Math.Max( maxLeftAlignedText, textLength.Width + uScriptConfig.Style.PointSize + uScriptConfig.Style.PointPad );
               leftRequiredHeight += (uScriptConfig.Style.PointPad + uScriptConfig.Style.PointSize + textLength.Height);
            }
            else if ( socket.Alignment == Socket.Align.Right )
            {
               maxRightAlignedText = Math.Max( maxRightAlignedText, textLength.Width + uScriptConfig.Style.PointSize + uScriptConfig.Style.PointPad );
               rightRequiredHeight += (uScriptConfig.Style.PointPad + uScriptConfig.Style.PointSize + textLength.Height);
            }
            else if ( socket.Alignment == Socket.Align.Center )
            {
               maxCenterAlignedText = Math.Max( maxCenterAlignedText, textLength.Width );
               centerRequiredHeight = Math.Max( centerRequiredHeight, textLength.Height );
            }
         }

         //centered text should have extra title padding
         maxCenterAlignedText += uScriptConfig.Style.TitleLeftRightPad + uScriptConfig.Style.TitleLeftRightPad;

         requiredHeight = Math.Max( leftRequiredHeight, rightRequiredHeight );
         requiredHeight = Math.Max( requiredHeight, topRequiredHeight );
         requiredHeight = Math.Max( requiredHeight, centerRequiredHeight );

         requiredWidth  = Math.Max( requiredWidth, maxLeftAlignedText + maxRightAlignedText );
         requiredWidth  = Math.Max( requiredWidth, maxCenterAlignedText );

         SizeF titleLength = null == g ? new SizeF(uScriptConfig.Style.PointPad, uScriptConfig.Style.PointPad) : g.MeasureString( Name, NodeStyle );
         requiredHeight += uScriptConfig.Style.TopPad + uScriptConfig.Style.BottomPad;
         requiredHeight += (titleLength.Height + uScriptConfig.Style.TitleTopBottomPad);

         requiredWidth = Math.Max( requiredWidth, (titleLength.Width + uScriptConfig.Style.TitleLeftRightPad + uScriptConfig.Style.TitleLeftRightPad ) );
         requiredWidth += uScriptConfig.Style.LeftPad + uScriptConfig.Style.RightPad; 

         return new Size( (int) requiredWidth, (int) requiredHeight );
      }

      public override void PreparePoints( Graphics g )
      {
         List<AnchorPoint> points   = new List<AnchorPoint>( );
         List<TextPoint> textPoints = new List<TextPoint>( );

         Size = CalculateSize( m_Sockets, g );

         LeftPoints  ( m_Sockets, points, textPoints, g );
         RightPoints ( m_Sockets, points, textPoints, g );
         BottomPoints( m_Sockets, points, textPoints, g );
         CenterPoints( m_Sockets, points, textPoints, g );

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

         foreach ( Parameter ep in desc.EditableParameters )
         {
            p.Add( ep );
         }

         foreach ( Parameter ep in desc.ReadOnlyParameters )
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
               foreach ( Parameter property in desc.EditableParameters )
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
               newDesc.ReadOnlyParameters = desc.ReadOnlyParameters;

               int count = desc.EditableParameters.Length;

               List<Parameter> parameters = new List<Parameter>( );

               for ( int i = 0; i < count; i++ )
               {
                  parameters.Add( value[ index ] );
                  index++;
               }

               newDesc.EditableParameters = parameters.ToArray( );
               newDescs[ newDesc.Key ] = newDesc;
            }

            m_ParameterDescs = newDescs;
         }
      }

      private struct ParameterDesc
      {
         public Parameter[] EditableParameters;
         public Parameter[] ReadOnlyParameters;
         public string Key;
      }

      private Dictionary<string, ParameterDesc> m_ParameterDescs = new Dictionary<string,ParameterDesc>( );

      public void AddParameters( string key, Parameter[] parameters )
      {
         List<Parameter> editableParams = new List<Parameter>( );
         List<Parameter> readOnlyParams = new List<Parameter>( );

         if ( null != parameters )
         {
            foreach ( Parameter p in parameters )
            {
               if ( true == p.Input )
               {
                  editableParams.Add( p );
               }
               else
               {
                  readOnlyParams.Add( p );
               }
            }
         }

         ParameterDesc desc = new ParameterDesc( );
         desc.EditableParameters = editableParams.ToArray( );
         desc.ReadOnlyParameters = readOnlyParams.ToArray( );
         desc.Key = key;

         m_ParameterDescs[ key ] = desc;
      }
   }
}

