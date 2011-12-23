using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Detox.Windows.Forms;
using Detox.Drawing;

using UnityEditor;
using UnityEngine;

namespace Detox.FlowChart
{
   public class FlowChartCtrl : UserControl
   {
      private Hashtable m_Nodes = new Hashtable( );
      private Node m_StartLinkNode = null;
      private Point m_StartMarquee = Point.Empty;

      public const int LinkRenderDepth = 5000;

      public AnchorPoint LinkStartAnchor { get { return m_LinkStartAnchor; } }
      private AnchorPoint m_LinkStartAnchor = new AnchorPoint( );

      public Node LinkStartNode { get { return m_StartLinkNode; } }

      private List<Link> m_Links = new List<Link>( );

      private bool m_NodeMouseTracking = false;
      private bool m_NodeMouseSizing   = false;
      private bool m_AllowPanning = false;

      private Point m_MoveOffset = Point.Empty;
      private Point m_StartMoveLocation   = Point.Empty;
      private Point m_FCMouseDownPoint    = Point.Empty;
      private Point m_MoveBoundariesStart = Point.Empty;

      private float m_PrevZoom = 1.0f;
      
      //we have a separate Zoom we use instead of
      //ZoomScale because we don't want the flowchart itself to zoom
      //we only want to zoom the children
      public float Zoom = 1.0f;
      public Point ZoomPoint 
      {
         set 
         {
            //this changes the top/left location
            //of the graph so it appears the scaling
            //takes place under the mouse cursor instead
            //of at the top left

            if ( m_PrevZoom == Zoom ) return;

            foreach ( Node n in m_Nodes.Values )
            {
               //nodes might need to change shape
               //now that we are changing zoom
               n.PreparePoints( );
            }

            float d = 1.0f - Zoom;
            float p = 1.0f - m_PrevZoom;

            //similar to a perspective divide
            //the zoom affect isn't linear
            //and the location change
            //is on an exponential curve
            float expDivide     = 1.0f / Zoom;
            float prevExpDivide = 1.0f / m_PrevZoom;

            Point zoomPoint = value;

            //back off any applied zoom amount
            //so we move location based off a fresh zoom
            float oldX = Location.X - (zoomPoint.X * p * prevExpDivide);
            float oldY = Location.Y - (zoomPoint.Y * p * prevExpDivide);

            float x = oldX + (zoomPoint.X * d * expDivide);
            float y = oldY + (zoomPoint.Y * d * expDivide);

            m_PrevZoom = Zoom;

            Location.X = (int) x;
            Location.Y = (int) y;
         }
      }

      public bool InMoveMode 
      { 
         get 
         { 
            return ((Control.MouseButtons == MouseButtons.Left && Control.ModifierKeys == Keys.Alt) ||
                    (Control.MouseButtons == MouseButtons.Middle)) &&
                   true == m_AllowPanning;
         } 
      }

      public FlowChartCtrl( )
      {
         InitializeComponent( );
      }

      public bool IsDragging( )
      {
         if ( true == InMoveMode )              return true;
         if ( true == m_NodeMouseTracking )     return true;
         if ( true == m_NodeMouseSizing )       return true;
         if ( Point.Empty != m_StartMarquee )   return true;
            
         return false;
      }

      public Node [] SelectedNodes
      {
         get
         {
            List<Node> nodes = new List<Node>( );

            foreach ( Node node in m_Nodes.Values )
            {
               if ( node.Selected ) nodes.Add( node );
            }

            return nodes.ToArray( );
         }
      }

      public Node [] Nodes
      {
         get
         {
            List<Node> nodes = new List<Node>( );

            foreach ( Node node in m_Nodes.Values )
            {
               nodes.Add( node );
            }

            return nodes.ToArray( );
         }
      }

      public Link [] SelectedLinks
      {
         get
         {
            List<Link> links = new List<Link>( );

            foreach ( Link link in m_Links )
            {
               if ( link.Selected ) links.Add( link );
            }

            return links.ToArray( );
         }
      }

      public Link [] Links
      {
         get
         {
            List<Link> links = new List<Link>( );

            foreach ( Link link in m_Links )
            {
               links.Add( link );
            }

            return links.ToArray( );
         }
      }

      public Node GetNode( Guid guid )
      {
         return (Node) m_Nodes[ guid ];
      }

      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // FlowChartCtrl
         // 
         this.BackColor = Detox.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
         this.DoubleBuffered = true;
         this.Name = "FlowChartCtrl";
         this.Size = new Detox.Drawing.Size(0, 0);
         this.MouseMove += new Detox.Windows.Forms.MouseEventHandler(this.FlowChartCtrl_MouseMove);
         this.MouseDown += new Detox.Windows.Forms.MouseEventHandler(this.FlowChartCtrl_MouseDown);
         this.MouseUp += new Detox.Windows.Forms.MouseEventHandler(this.FlowChartCtrl_MouseUp);
         this.ResumeLayout(false);

         this.Location = new Point(0, 0);
      }

      public delegate void FlowChartNodesModifiedEventHandler(object sender, FlowchartNodesModifiedEventArgs e);
      public event FlowChartNodesModifiedEventHandler NodesModified;

      private void OnNodesModified(Node []nodes)
      {
         if (null != NodesModified) NodesModified(this, new FlowchartNodesModifiedEventArgs(nodes));
      }

      public delegate void FlowChartPointRenderEventHandler(object sender, FlowchartPointRenderEventArgs e);
      public event FlowChartPointRenderEventHandler PointRender;

      public void OnPointRender(Node sender, int index, AnchorPoint point, bool connecting)
      {
         if (null != PointRender) PointRender(sender, new FlowchartPointRenderEventArgs(index, point, connecting));
      }

      public delegate void FlowChartSelectionModifiedEventHandler(object sender, EventArgs e);
      public event FlowChartSelectionModifiedEventHandler SelectionModified;

      public void OnSelectionModified( )
      {
         if (null != SelectionModified) SelectionModified(this, new EventArgs());
         Controls.Sort(CompareNodes);
      }

      public delegate void FlowChartLinkCreatedEventHandler(object sender, FlowchartLinkCreatedEventArgs e);
      public event FlowChartLinkCreatedEventHandler LinkCreated;

      private void OnLinkCreated(Link link)
      {
         if (null != LinkCreated) LinkCreated(this, new FlowchartLinkCreatedEventArgs(link));
      }

      public delegate void FlowChartLocationChangedEventHandler(object sender, EventArgs e);
      public event FlowChartLocationChangedEventHandler LocationChanged;

      private void OnLocationChanged( )
      {
         if (null != LocationChanged) LocationChanged(this, new EventArgs());
      }

      public void Clear( )
      {
         Controls.Clear( );
         m_Links.Clear( );
         m_Nodes.Clear( );
      }

      public void AddNode(Node node)
      {
         node.MouseMove            += FlowChartCtrl_NodeMouseMove;
         node.MouseUp              += FlowChartCtrl_NodeMouseUp;
         node.MouseDown            += FlowChartCtrl_NodeMouseDown;
         node.Modified             += FlowChartCtrl_NodeModified;

         m_Nodes[ node.Guid ] = node;

         node.Parent = this;

         int i = 0;
         for (i = 0; i < Controls.Count; i++)
         {
            Node currentNode = (Node)Controls[i];
            if (currentNode.RenderDepth >= node.RenderDepth) break;
         }
         Controls.Insert( i, node );
      }
      
      public void SelectNodes(Guid []guids)
      {
         foreach ( Guid guid in guids )
         {
            if ( m_Nodes.Contains(guid) )
            {
               Node node = m_Nodes[ guid ] as Node;
               node.Selected = true;
            }
         }

         OnSelectionModified( );
      }

      public void ToggleNodes(Guid []guids)
      {
         foreach ( Guid guid in guids )
         {
            if ( m_Nodes.Contains(guid) )
            {
               Node node = m_Nodes[ guid ] as Node;
               node.Selected = !node.Selected;
            }
         }

         OnSelectionModified( );
      }

      public void DeselectAll( )
      {
         foreach ( Node node in Nodes )
         {
            node.Selected = false;
         }

         foreach ( Link link in Links )
         {
            link.Selected = false;
         }

         OnSelectionModified( );
      }

      public void DeleteNode(Guid guid)
      {
         Controls.Remove( (Node) m_Nodes[ guid ] );
         m_Nodes.Remove( guid );
      
         List<Link> links = new List<Link>( m_Links );

         foreach ( Link link in links )
         {
            if ( link.Source.Node.Guid == guid ||
                 link.Destination.Node.Guid == guid )
            {
               m_Links.Remove( link );
            }
         }

         if ( null != m_StartLinkNode && m_StartLinkNode.Guid == guid )
         {
            m_StartLinkNode   = null;
         }
            
         Invalidate( );  // ??
      }

      private bool LinkInRect(Link link, Rectangle rect)
      {
         Point start = new Point( (int) (link.Source.Anchor.X / 100.0f * link.Source.Node.ZoomSize.Width), 
                                  (int) (link.Source.Anchor.Y / 100.0f * link.Source.Node.ZoomSize.Height) );
   
         start  = link.Source.Node.PointToScreen( start );
         start  = this.PointToClient( start );

         Point end = new Point( (int) (link.Destination.Anchor.X / 100.0f * link.Destination.Node.ZoomSize.Width), 
                                (int) (link.Destination.Anchor.Y / 100.0f * link.Destination.Node.ZoomSize.Height) );
   
         end  = link.Destination.Node.PointToScreen( end );
         end  = this.PointToClient( end );
   
         //is starting point within rect
         if ( start.X >= rect.Left && start.X <= rect.Right &&
              start.Y >= rect.Top  && start.Y <= rect.Bottom  )
         {
            return true;
         }

         //is ending point within rect
         if ( end.X >= rect.Left && end.X <= rect.Right &&
              end.Y >= rect.Top  && end.Y <= rect.Bottom  )
         {
            return true;
         }

         return false;
      }

      private bool InLink(Link link, Point position)
      {
         //this hit test assumes the arrow is a straight line
         //(in actuality it's slightly curved w/ bezier rendering)
         //but in my tests so far, this is still accurate enough

         Point start = new Point( (int) (link.Source.Anchor.X / 100.0f * link.Source.Node.ZoomSize.Width), 
                                  (int) (link.Source.Anchor.Y / 100.0f * link.Source.Node.ZoomSize.Height) );
   
         start  = link.Source.Node.PointToScreen( start );
         start  = this.PointToClient( start );
         
         Point end = new Point( (int) (link.Destination.Anchor.X / 100.0f * link.Destination.Node.ZoomSize.Width), 
                                (int) (link.Destination.Anchor.Y / 100.0f * link.Destination.Node.ZoomSize.Height) );
   
         end  = link.Destination.Node.PointToScreen( end );
         end  = this.PointToClient( end );

         //put position in link space
         Point local = new Point( position.X - start.X, position.Y - start.Y );

         //projection position on link ray
         Point delta = new Point( end.X - start.X, end.Y - start.Y );
         
         float magnitude = (float) Math.Sqrt( delta.X * delta.X + delta.Y * delta.Y );
         if ( 0 == magnitude ) return false;

         float rayX = delta.X / magnitude;
         float rayY = delta.Y / magnitude;

         float distance = rayX * local.X + rayY * local.Y;

         //if the point is infront of the start (along the ray)
         //then clamp the line test point to the max distance of our line
         if ( distance > 0 )
         {
            distance = Math.Min( distance, magnitude );
         }
         else
         {
            //the point is behind our start ray, so let our max
            //be the testing amount
            distance = Math.Max( distance, -10 );
         }

         Point projected = new Point( (int) (start.X + distance * rayX), (int) (start.Y + distance * rayY) );

         //delta from position from projected position
         delta = new Point( position.X - projected.X, position.Y - projected.Y );

         //check distance
         distance = delta.X * delta.X + delta.Y * delta.Y;
         distance = (float) Math.Sqrt( distance );

         if ( distance <= 10 )
         {
            return true;
         }

         return false;
      }

      private void FlowChartCtrl_MouseDown(object sender, MouseEventArgs e)
      {
         m_NodeMouseTracking = false;
         if (( e.Button == MouseButtons.Left && Control.ModifierKeys.Contains(Keys.Alt)) || e.Button == MouseButtons.Middle )
         {
            m_AllowPanning = true;
         }
         m_FCMouseDownPoint = Detox.Windows.Forms.Cursor.Position;
         
         if ( e.Button == MouseButtons.Left )
         {
            m_MoveBoundariesStart = Detox.Windows.Forms.Cursor.Position;
         }
      }

      private void FlowChartCtrl_NodeModified(object sender, EventArgs e)
      {
         OnNodesModified( new Node[1] { sender as Node } );
      }

      private void FlowChartCtrl_NodeMouseDown(object sender, MouseEventArgs e)
      {
         if ( e.Button == MouseButtons.Left && false == Control.ModifierKeys.Contains(Keys.Alt) )
         {
            Node node = sender as Node;
            Link clickedLink = null;
            bool linkClicked = node.RenderDepth < FlowChartCtrl.LinkRenderDepth ? MouseOverLink(out clickedLink) : false;
            bool selectionSetModified = false;
    
            if (linkClicked && clickedLink != null)
            {
               //change selection state
               //(if ctrl key was down it will toggle selection state)
               //(if ctrl key was up it will always have been unselected
               // because of the above code and so this will always select it)
               if (!clickedLink.Selected && false == Control.ModifierKeys.Contains(Keys.Shift))
               {
                  // deselect everything else
                  foreach ( Link deselectedLink in Links )
                  {
                     deselectedLink.Selected = false;
                  }

                  foreach ( Node deselectedNode in Nodes )
                  {
                     deselectedNode.Selected = false;
                  }

                  clickedLink.Selected = true;
                  selectionSetModified = true;
               }
               else if ( Control.ModifierKeys.Contains(Keys.Shift) )
               {
                  clickedLink.Selected = !clickedLink.Selected;
                  selectionSetModified = true;
               }
            }
            
            m_MoveBoundariesStart = Detox.Windows.Forms.Cursor.Position;

            //use the parent's position
            //for mouse coords, if we use our position
            //the mouse is relative to us which throws it off when
            //we move ourselves
            Point position = Detox.Windows.Forms.Cursor.Position;
            position = node.PointToClient( position );

            AnchorPoint anchorPoint = new AnchorPoint( );
            bool pointSourced = false; 
            bool selectionSetChanged = false;

            if ( true == node.PointInAnchorPoint(position, ref anchorPoint) )
            {
               if ( true == anchorPoint.CanSource )
               {
                  OnAnchorPointActivated( node, anchorPoint );
                  Invalidate( );  // Socket MouseDown

                  pointSourced = true;
               }
            }
            
            if ( true == selectionSetModified && false == pointSourced ) return;

            if ( false == pointSourced && false == m_NodeMouseTracking )
            {                  
               //change selection state
               if (!node.Selected && false == Control.ModifierKeys.Contains(Keys.Shift))
               {
                  // deselect everything else
                  foreach ( Link deselectedLink in Links )
                  {
                     deselectedLink.Selected = false;
                  }

                  foreach ( Node deselectedNode in Nodes )
                  {
                     deselectedNode.Selected = false;
                  }

                  node.Selected = true;
                  selectionSetChanged = true;
               }
               else if ( Control.ModifierKeys.Contains(Keys.Shift) )
               {
                  node.Selected = !node.Selected;
                  selectionSetChanged = true;
               }
   
               if ( true == node.CanResize )
               {
                  if ( position.X > node.ZoomSize.Width  - uScriptConfig.ResizeTexture.width &&
                       position.Y > node.ZoomSize.Height - uScriptConfig.ResizeTexture.height )
                  {
                     m_NodeMouseSizing = true;
                  }
               }

               if ( false == node.Selected )
               {
                  if ( true == m_NodeMouseSizing )
                  {
                     node.StartNodeResize( );
                  }
               }
               else
               {   
                  if ( true == m_NodeMouseSizing )
                  {
                     foreach ( Node selectedNode in SelectedNodes )
                     {
                        //these are part of a selection group
                        //so they didn't have to pass the initial resize hit test
                        //which means we have no idea if they are authorized to resize or not
                        if ( true == selectedNode.CanResize )
                        {
                           selectedNode.StartNodeResize( );
                        }
                     }
                  }
               }
            }

            if ( false == pointSourced && false == m_NodeMouseSizing )
            {
               m_AllowPanning = true;
            }
            else
            {
               m_AllowPanning = false;
            }

            if ( true == selectionSetChanged )
            {
               OnSelectionModified( );
   
               Invalidate( );  // Node MouseDown
            }
         }
         else if (e.Button == MouseButtons.Middle || (e.Button == MouseButtons.Left && true == Control.ModifierKeys.Contains(Keys.Alt)))
         {
            // allow panning when clicking on a node
            FlowChartCtrl_MouseDown(sender, e);
         }
      }

      //called "NodeMouseMove" because it's a relayed message from
      //the node, which will have the mouse coords in node space
      private void FlowChartCtrl_NodeMouseMove(object sender, MouseEventArgs e)
      {
         if ( e.Button == MouseButtons.Left && false == Control.ModifierKeys.Contains(Keys.Alt) )
         {
            if ( false == InMoveMode && null == m_StartLinkNode )
            {
               if ( false == m_NodeMouseSizing )
               {
                  if ( false == m_NodeMouseTracking )
                  {
                     foreach ( Node selectedNode in SelectedNodes )
                     {
                        selectedNode.StartNodeMove( );
                     }
                  }
                  m_NodeMouseTracking = true;
               }
   
               if ( true == m_NodeMouseTracking )
               {
                  foreach ( Node selectedNode in SelectedNodes )
                  {
                     selectedNode.NodeMove( );
                  }
               }
               else if ( true == m_NodeMouseSizing )
               {
                  Node node = sender as Node;
                  
                  //see comments in NodeMouseDown for why we have this if/else
                  if ( false == node.Selected )
                  {
                     node.NodeResize( );
                  }
                  else
                  {
                     foreach ( Node selectedNode in SelectedNodes )
                     {
                        //these are part of a selection group
                        //so they didn't have to pass the initial resize hit test
                        //which means we have no idea if they are authorized to resize or not
                        if ( selectedNode.CanResize )
                        {
                           selectedNode.NodeResize( );
                        }
                     }
                  }
               }
            }

            // @FIXME : Repaints even when the mouse is stationary
            Invalidate( );  // Node MouseDrag
         }
         else if (e.Button == MouseButtons.Middle || (e.Button == MouseButtons.Left && true == Control.ModifierKeys.Contains(Keys.Alt)))
         {
            // allow panning when clicking on a node
            FlowChartCtrl_MouseMove(sender, e);
         }
      }

      private bool UserProbablyDidntMeanToMoveMouse( )
      {
         int dx = m_FCMouseDownPoint.X - Detox.Windows.Forms.Cursor.Position.X;
         int dy = m_FCMouseDownPoint.Y - Detox.Windows.Forms.Cursor.Position.Y;

         dx = Math.Abs(dx);
         dy = Math.Abs(dy);

         int pixelTolerance = 3;

         return ( dx * dx + dy * dy ) < pixelTolerance * pixelTolerance;
      }


      //called "NodeMouseUp" because it's a relayed message from
      //the node, which will have the mouse coords in node space
      private void FlowChartCtrl_NodeMouseUp(object sender, MouseEventArgs e)
      {
         if ( e.Button == MouseButtons.Left && false == Control.ModifierKeys.Contains(Keys.Alt) )
         {
            List<Node> modifiedNodes = new List<Node>( );
            Link createdLink = null;
   
            //if we were moving the node
            //simply finish moving it, don't unselect anything
            if ( true == m_NodeMouseTracking || true == m_NodeMouseSizing  )
            {
               //see comments in NodeMouseDown for why we have this if/else
               if ( false == ((Node)sender).Selected )
               {
                  modifiedNodes.Add( sender as Node );
               }
               else
               {
                  foreach ( Node node in SelectedNodes )
                  {
                     modifiedNodes.Add( node );
                  }
               }
            }
   
            m_NodeMouseTracking = false;
            m_NodeMouseSizing   = false;
   
            if ( null != m_StartLinkNode )
            {
               Point position = Detox.Windows.Forms.Cursor.Position;
   
               AnchorPoint hitPoint = new AnchorPoint( );
   
               foreach ( Control c in Controls )
               {
                  Node node = c as Node;
   
                  if ( null != node )
                  {
                     Point localPosition = node.PointToClient( position );
                     if ( true == node.PointInAnchorPoint(localPosition, ref hitPoint) )
                     {
                        if ( true == m_LinkStartAnchor.Output && true == hitPoint.Input ||
                             true == m_LinkStartAnchor.Input  && true == hitPoint.Output )
                        {
                           AnchorPoint sourceAnchor, destAnchor;
                           Node sourceNode, destNode;
   
                           //default to start is output and dest is input
                           if ( true == m_LinkStartAnchor.Output && true == hitPoint.Input )
                           {
                              sourceNode   = m_StartLinkNode;
                              destNode     = node;
                              sourceAnchor = m_LinkStartAnchor.Output ? m_LinkStartAnchor : hitPoint;
                              destAnchor   = m_LinkStartAnchor.Output ? hitPoint : m_LinkStartAnchor;
                           }
                           else
                           {
                              sourceNode   = node;
                              destNode     = m_StartLinkNode;
                              sourceAnchor = hitPoint;
                              destAnchor   = m_LinkStartAnchor;
                           }
      
                           bool exists = false;
   
                           //make sure it doesn't already exist
                           foreach ( Link existing in m_Links )
                           {
                              if ( existing.Source.Node             == sourceNode &&
                                   existing.Source.Anchor.Name      == sourceAnchor.Name &&
                                   existing.Destination.Node        == destNode &&
                                   existing.Destination.Anchor.Name == destAnchor.Name )
                              {
                                 exists = true;
                                 break;
                              }
                           }
   
                           if ( false == exists )
                           {
                              Link link = new Link( sourceNode, sourceAnchor.Name, destNode, destAnchor.Name );
                              m_Links.Add( link );
   
                              createdLink = link;
                           }
   
                           break;
                        }
                     }
                  }
               }
            }
   
            m_StartLinkNode = null;
   
            if ( null != createdLink )
            {
               OnLinkCreated( createdLink );
            }
   
            OnNodesModified( modifiedNodes.ToArray( ) );
   
            Invalidate( );  // Node (and link) MouseUp
         }
         else if (e.Button == MouseButtons.Middle || (e.Button == MouseButtons.Left && true == Control.ModifierKeys.Contains(Keys.Alt)))
         {
            // allow panning when clicking on a node
            FlowChartCtrl_MouseUp(sender, e);
         }
      }
      
      private void FlowChartCtrl_MouseUp(object sender, MouseEventArgs e)
      {      
         if ( e.Button != MouseButtons.Left && e.Button != MouseButtons.Middle ) return;

         bool selectionSetModified = false;

         if ( Point.Empty != m_StartMarquee )
         {
            RunMarqueeSelect( );
            //assume the marquee selected or deselected something
            //in the future we should keep track if a selection changed
            selectionSetModified = true;
         }

         //if we were moving the node
         //simply finish moving it, don't unselect anything
         if ( true == m_NodeMouseTracking || true == m_NodeMouseSizing )
         {
            List<Node> modifiedNodes = new List<Node>( );

            foreach ( Node node in SelectedNodes )
            {
               modifiedNodes.Add( node );
            }

            OnNodesModified( modifiedNodes.ToArray( ) );

         }
         else if ( Point.Empty == m_StartMarquee )
         {
            Link clickedLink = null;
            bool linkClicked = MouseOverLink(out clickedLink);
    
            if (linkClicked && clickedLink != null)
            {
               //change selection state
               //(if ctrl key was down it will toggle selection state)
               //(if ctrl key was up it will always have been unselected
               // because of the above code and so this will always select it)
               if (!clickedLink.Selected && false == Control.ModifierKeys.Contains(Keys.Shift))
               {
                  // deselect everything else
                  foreach ( Link deselectedLink in Links )
                  {
                     deselectedLink.Selected = false;
                  }

                  foreach ( Node deselectedNode in Nodes )
                  {
                     deselectedNode.Selected = false;
                  }

                  clickedLink.Selected = true;
                  selectionSetModified = true;
               }
               else if ( Control.ModifierKeys.Contains(Keys.Shift) )
               {
                  clickedLink.Selected = !clickedLink.Selected;
                  selectionSetModified = true;
               }
            }
            
            //they let up the mouse without moving the canvas
            //and they weren't marquee selecting
            //so deselect everything
            if ( false == Control.ModifierKeys.Contains(Keys.Shift) )
            {
               if ( false == selectionSetModified && Point.Empty == m_StartMarquee && !linkClicked )
               {
                  if ( true == UserProbablyDidntMeanToMoveMouse( ) )
                  {
                     foreach ( Node node in SelectedNodes )
                     {
                        node.Selected = false;
                     }
   
                     foreach ( Link link in SelectedLinks )
                     {
                        link.Selected = false;
                     }
   
                     selectionSetModified = true;
                  }
               }
            }
         }

         m_NodeMouseTracking = false;
         m_StartLinkNode = null;
         m_StartMarquee  = Point.Empty;
         m_MoveOffset = Point.Empty;

         if ( true == selectionSetModified )
         {
            OnSelectionModified( );
         }

         Invalidate( );  // Canvas MouseUp
      }
      
      private bool MouseOverLink(out Link retLink)
      {
         Point position = PointToClient( Detox.Windows.Forms.Cursor.Position );
         retLink = null;

         foreach ( Link link in m_Links )
         {
            if ( true == InLink(link, position) )
            {
               retLink = link;
               return true;
            }
         }

         return false;
      }

      private void RunMarqueeSelect( )
      {
         Point position = Detox.Windows.Forms.Cursor.Position;
         position = this.PointToClient( position );

         int startX = Math.Min( m_StartMarquee.X, position.X );
         int endX   = Math.Max( m_StartMarquee.X, position.X );

         int startY = Math.Min( m_StartMarquee.Y, position.Y );
         int endY   = Math.Max( m_StartMarquee.Y, position.Y );
      
         Rectangle rect = new Rectangle( startX, startY, endX - startX, endY - startY );

         // If no control or shift key, unselect the rest
         if ( false == Control.ModifierKeys.Contains(Keys.Control) && false == Control.ModifierKeys.Contains(Keys.Shift) )
         {
            foreach (Node node in SelectedNodes)
            {
               // Only deselect if it's not in the rect to prevent repaints
               node.Selected = node.IntersectsWith(rect);
            }

            foreach ( Link link in SelectedLinks )
            {
               // Only deselect if it's not in the rect to prevent repaints
               link.Selected = LinkInRect(link, rect);
            }
         }

         foreach ( Node node in m_Nodes.Values )
         {
            if ( true == node.IntersectsWith(rect) )
            {  // Intersects
               if (true == Control.ModifierKeys.Contains(Keys.Control))
               {
                  node.Selected = false;
               }
               else
               {
                  node.Selected = true;
               }
            }
         }

         foreach ( Link link in m_Links )
         {
            if ( LinkInRect(link, rect) )
            {
               if (true == Control.ModifierKeys.Contains(Keys.Control))
               {
                  link.Selected = false;
               }
               else
               {
                  link.Selected = true;
               }
            }
         }
      }

      private void FlowChartCtrl_MouseMove(object sender, MouseEventArgs e)
      {
         if ( true == InMoveMode )
         {
            OnLocationChanged( );
            // @FIXME : Repaints even when the mouse is stationary
            Invalidate( );  // Canvas MouseDrag
         }
         else
         {
            if ( e.Button == MouseButtons.Left && Point.Empty == m_StartMarquee && !UserProbablyDidntMeanToMoveMouse() )
            {
               m_StartMarquee = new Point(e.X, e.Y);
            }

            if ( null != m_StartLinkNode || Point.Empty != m_StartMarquee )
            {
               if ( Point.Empty != m_StartMarquee )
               {
                  RunMarqueeSelect( );
               }

               // @FIXME : Repaints even when the mouse is stationary
               Invalidate( );  // Marquee MouseDrag
            }
            else if ( true == m_NodeMouseTracking )
            {
               foreach ( Node selectedNode in SelectedNodes )
               {
                  selectedNode.NodeMove( );
               }

               Invalidate( );  // ??
            }
         }
      }

      private void MoveBoundaries( )
      {
         const float maxMoveRate = 4.0f;
         const float moveStart   = 100.0f;

         PointF location;

         //cursor is already in NodeWindowRect space
         //no need to subtract coordinates
         location.X = Detox.Windows.Forms.Cursor.Position.X;
         location.Y = Detox.Windows.Forms.Cursor.Position.Y;

         float width  = uScript.Instance.NodeWindowRect.xMax - uScript.Instance.NodeWindowRect.xMin;
         float height = uScript.Instance.NodeWindowRect.yMax - uScript.Instance.NodeWindowRect.yMin;

         if ( location.X < moveStart && location.X < m_MoveBoundariesStart.X )
         {
            float v = 1.0f - (location.X / moveStart);
            Location.X += (int) (v * v * v * maxMoveRate);
         }
         else if ( location.X > width - moveStart && location.X > m_MoveBoundariesStart.X )
         {
            float v = 1.0f - (width - location.X) / moveStart;
            Location.X -= (int) (v * v * v * maxMoveRate);
         }

         if ( location.Y < moveStart && location.Y < m_MoveBoundariesStart.Y )
         {
            float v = 1.0f - (location.Y / moveStart);
            Location.Y += (int) (v * v * v * maxMoveRate);
         }
         else if( location.Y > height - moveStart && location.Y > m_MoveBoundariesStart.Y )
         {
            float v = 1.0f - (height - location.Y) / moveStart;
            Location.Y -= (int) (v * v * v * maxMoveRate);
         }

         //keeps it clamped
         MoveWithCursor( );
      }

      private void OnAnchorPointActivated(Node node, AnchorPoint anchorPoint)
      {
         m_StartLinkNode   = node;
         m_LinkStartAnchor = anchorPoint;

         this.Focus( );
      }

      public void MoveWithCursor( float movementScale )
      {
         Point position = Detox.Windows.Forms.Cursor.Position;

         if ( Point.Empty == m_MoveOffset )
         {
            m_MoveOffset        = Detox.Windows.Forms.Cursor.Position;
            m_StartMoveLocation = Location;
         }

         position = new Point( (int) (movementScale * (position.X - m_MoveOffset.X)), (int) (movementScale * (position.Y - m_MoveOffset.Y)) );
         position = new Point( m_StartMoveLocation.X + position.X, m_StartMoveLocation.Y + position.Y );

         //clamp top left
         if ( position.X > 0 ) position.X = 0;
         if ( position.Y > 0 ) position.Y = 0;

         //clamp bottom right
         if ( position.X + Bounds.Width  < Parent.Bounds.Right  ) position.X += Parent.Bounds.Right  - ( position.X + Bounds.Width); 
         if ( position.Y + Bounds.Height < Parent.Bounds.Bottom ) position.Y += Parent.Bounds.Bottom - ( position.Y + Bounds.Height); 

         Location = position;
      }

      public void JumpToPoint( Point point )
      {
         Point position = point;

         //clamp top left
         if ( position.X > 0 ) position.X = 0;
         if ( position.Y > 0 ) position.Y = 0;

         //clamp bottom right
         if ( position.X + Bounds.Width  < Parent.Bounds.Right  ) position.X += Parent.Bounds.Right  - ( position.X + Bounds.Width); 
         if ( position.Y + Bounds.Height < Parent.Bounds.Bottom ) position.Y += Parent.Bounds.Bottom - ( position.Y + Bounds.Height); 

         Location = position;
      }

      private void MoveWithCursor( )
      {
         MoveWithCursor( 1.0f / Zoom );
      }

      public override void OnPaint(PaintEventArgs e)
      {
         // Abort if the NodeWindowRect hasn't been initialized yet
         if (uScript.Instance.NodeWindowRect == new Rect())
         {
            return;
         }

         if ( true == InMoveMode && m_StartMarquee == Point.Empty )
         {
            m_StartLinkNode = null;

            MoveWithCursor( );
         }
         else
         {
            m_MoveOffset = Point.Empty;

            //even if not in move mode, if the mouse is down
            //then force a move when they are near boundaries
            if (  Control.MouseButtons == MouseButtons.Left )
            {
               MoveBoundaries( );
            }
         }

         // This is the viewport Rect
         //Rectangle visibleRect = new Rectangle(-Location.X, -Location.Y, (int)uScript.Instance.NodeWindowRect.width, (int)uScript.Instance.NodeWindowRect.height);
         Rectangle visibleRect = new Rectangle(0,0, (int)uScript.Instance.NodeWindowRect.width, (int)uScript.Instance.NodeWindowRect.height);

         if ( 1.0f == Zoom && uScript.Preferences.ShowGrid == true )
         {
            float g;
    
            float gridSizeVertical   = uScript.Preferences.GridSizeVertical;
            float gridSizeHorizontal = uScript.Preferences.GridSizeHorizontal;
            int vertical   = (int) Math.Floor(gridSizeVertical);
            int horizontal = (int) Math.Floor(gridSizeHorizontal);

            float offsetX = Location.X % vertical;
            float offsetY = Location.Y % horizontal;
            int gridMajorLineSpacing = (int)uScript.Preferences.GridMajorLineSpacing;

            int majorGridPixelOffset = Location.Y % (horizontal * gridMajorLineSpacing);
            int majorGridSpacing = majorGridPixelOffset / horizontal;

            offsetX += gridSizeVertical   - vertical;
            offsetY += gridSizeHorizontal - horizontal;

            Vector3 startGrid = new Vector3( offsetX, offsetY );
            Vector3 endGrid   = new Vector3( uScript.Instance.NodeWindowRect.width, offsetY );

            //finally flip it because our location we modded with will be negative
            int gridMajorLineCount = - majorGridSpacing;

            for ( g = 0; g < uScript.Instance.NodeWindowRect.height; g += gridSizeHorizontal )
            {
               if ( gridMajorLineCount == gridMajorLineSpacing )
               {
                  Handles.color = uScript.Preferences.GridColorMajor;
                  gridMajorLineCount = 0;
               }
               else
               {
                  Handles.color = uScript.Preferences.GridColorMinor;
               }

               Handles.DrawLine( startGrid, endGrid );

               startGrid.y += gridSizeHorizontal;
               endGrid.y += gridSizeHorizontal;

               gridMajorLineCount++;
            }

            startGrid = new Vector3( offsetX, offsetY );
            endGrid   = new Vector3( offsetX, uScript.Instance.NodeWindowRect.height );

            majorGridPixelOffset = Location.X % (vertical * gridMajorLineSpacing);
            majorGridSpacing = majorGridPixelOffset / vertical;

            //finally flip it because our location we modded with will be negative
            gridMajorLineCount = - majorGridSpacing;

            for ( g = 0; g < uScript.Instance.NodeWindowRect.width; g += uScript.Preferences.GridSizeVertical )
            {
               if ( gridMajorLineCount == gridMajorLineSpacing )
               {
                  Handles.color = uScript.Preferences.GridColorMajor;
                  gridMajorLineCount = 0;
               }
               else
               {
                  Handles.color = uScript.Preferences.GridColorMinor;
               }

               Handles.DrawLine( startGrid, endGrid );

               startGrid.x += gridSizeVertical;
               endGrid.x += gridSizeVertical;

               gridMajorLineCount++;
            }
         }

         Pen pen = new Pen( Detox.Drawing.Color.Black, uScriptConfig.bezierPenWidth );
         Pen selectedPen = new Pen( Detox.Drawing.Color.LightYellow, uScriptConfig.bezierPenWidthSelected );

         if (null != m_StartLinkNode)
         {
            PointF position = new PointF(Detox.Windows.Forms.Cursor.Position.X, Detox.Windows.Forms.Cursor.Position.Y);
            position = this.PointToClient( position );

            PointF start = new PointF( (m_LinkStartAnchor.X / 100.0f * m_StartLinkNode.Size.Width), 
                                       (m_LinkStartAnchor.Y / 100.0f * m_StartLinkNode.Size.Height) );
      
            start  = m_StartLinkNode.PointToScreen( start );
            start  = PointToClient( start );

            start.X += Location.X;
            start.Y += Location.Y;

            PointF end = new PointF(Detox.Windows.Forms.Cursor.Position.X, Detox.Windows.Forms.Cursor.Position.Y);
            end = PointToClient( end );

            end.X += Location.X;
            end.Y += Location.Y;
            
            //control point 1
            //is 25% of the X length and only 10% of the Y length
            PointF control1 = new PointF( 
               (start.X + (end.X - start.X) * .25f), 
               (start.Y + (end.Y - start.Y) * .10f) ); 

            //control point 2
            //is 75% of the X length and 90% of the Y length
            PointF control2 = new PointF( 
               (start.X + (end.X - start.X) * .75f), 
               (start.Y + (end.Y - start.Y) * .90f) ); 

            // New socket links
            Handles.color = new UnityEngine.Color( selectedPen.Color.FR, selectedPen.Color.FG, selectedPen.Color.FB );
            Handles.DrawBezier( new UnityEngine.Vector3(start.X, start.Y, 0), new UnityEngine.Vector3(end.X, end.Y, 0),
                                new UnityEngine.Vector3(control1.X, control1.Y, 0), new UnityEngine.Vector3(control2.X, control2.Y, 0),
                                 Handles.color, uScriptConfig.lineTexture, selectedPen.Width );
            // The end of the new socket link
            UnityEngine.GUI.Box( new UnityEngine.Rect(end.X - uScriptConfig.PointerLineEnd.width / 2, end.Y - uScriptConfig.PointerLineEnd.height / 2,
                                 uScriptConfig.PointerLineEnd.width, uScriptConfig.PointerLineEnd.height), 
                                 uScriptConfig.PointerLineEnd);
         }
         
         int i;
         List<Control> visibleList = new List<Control>();
         // pare down list to only visible nodes
         for (i = 0; i < Controls.Count; i++)
         {
            Node node = Controls[i] as Node;
            node.ZoomScale = Zoom;
            if (node.IsVisible(visibleRect))
            {
               visibleList.Add(node);
            }
         }
         
         // render pre-link nodes
         for (i = 0; i < visibleList.Count; i++)
         {
            Node node = visibleList[i] as Node;
            if (node != null)
            {
               if (node.RenderDepth >= LinkRenderDepth)
               {
                  break;
               }

               node.OnPaint(e);
            }
         }

         // render links
         foreach (Link link in m_Links)
         {
            PointF start = new PointF( link.Source.Anchor.X / 100.0f * link.Source.Node.ZoomSize.Width, 
                                       link.Source.Anchor.Y / 100.0f * link.Source.Node.ZoomSize.Height );
      
            start  = link.Source.Node.PointToScreen( start );
            start  = PointToClient( start );

            start.X += Location.X;
            start.Y += Location.Y;

            PointF end = new PointF( link.Destination.Anchor.X / 100.0f * link.Destination.Node.ZoomSize.Width, 
                                     link.Destination.Anchor.Y / 100.0f * link.Destination.Node.ZoomSize.Height );
      
            end  = link.Destination.Node.PointToScreen( end );
            end  = PointToClient( end );

            end.X += Location.X;
            end.Y += Location.Y;
            
            //control point 1
            //is 25% of the X length and only 10% of the Y length
            PointF control1 = new PointF( 
               (start.X + (end.X - start.X) * .25f), 
               (start.Y + (end.Y - start.Y) * .10f) ); 

            //control point 2
            //is 75% of the X length and 90% of the Y length
            PointF control2 = new PointF( 
               (start.X + (end.X - start.X) * .75f), 
               (start.Y + (end.Y - start.Y) * .90f) ); 

            if ( true == link.Selected )
            {
               Handles.color = new UnityEngine.Color( selectedPen.Color.FR, selectedPen.Color.FG, selectedPen.Color.FB );
               Handles.DrawBezier( new UnityEngine.Vector3(start.X, start.Y, 0), new UnityEngine.Vector3(end.X, end.Y, 0), 
                                   new UnityEngine.Vector3(control1.X, control1.Y, 0), new UnityEngine.Vector3(control2.X, control2.Y, 0), 
                                    Handles.color, uScriptConfig.lineTexture, selectedPen.Width );
            }
            else
            {
               int index = -1;
               string styleName = "";
               float lineWidth = pen.Width;
               Handles.color = new UnityEngine.Color(pen.Color.FR, pen.Color.FG, pen.Color.FB);
               bool oneNodeIsVariable = false;

               if (link.Source.Node != null || link.Destination.Node != null)
               {
                  // check source node type first
                  styleName = link.Source.Node.UnselectedStyleName;
                  
                  if (!String.IsNullOrEmpty(styleName))
                  {
                     oneNodeIsVariable = styleName.Contains("variable") || styleName.Contains("property");
                     for (int j = 0; j < uScriptConfig.VariableStyleTypes.Length; j++)
                     {
                        if (styleName == uScriptConfig.VariableStyleTypes[j] || styleName == uScriptConfig.PropertyStyleTypes[j])
                        {
                           index = j;
                           break;
                        }
                     }
                  }
						
                  if (index == -1)
                  {
                     // didn't find source node style, try the destination
                     styleName = link.Destination.Node.UnselectedStyleName;
                     
                     if (!String.IsNullOrEmpty(styleName))
                     {
                        oneNodeIsVariable = oneNodeIsVariable || styleName.Contains("variable") || styleName.Contains("property");
                        for (int j = 0; j < uScriptConfig.VariableStyleTypes.Length; j++)
                        {
                           if (styleName == uScriptConfig.VariableStyleTypes[j] || styleName == uScriptConfig.PropertyStyleTypes[j])
                           {
                              index = j;
                              break;
                           }
                        }
                     }
                  }
               }

               if (index != -1)
               {
                  Handles.color = uScriptConfig.LineColors[index];
                  lineWidth = uScriptConfig.LineWidths[index];
               }
               else if (oneNodeIsVariable)
               {
                  Handles.color = uScriptConfig.LineColors[0];
                  lineWidth = uScriptConfig.LineWidths[0];
               }

               Handles.DrawBezier( new UnityEngine.Vector3(start.X, start.Y, 0), new UnityEngine.Vector3(end.X, end.Y, 0), 
                                   new UnityEngine.Vector3(control1.X, control1.Y, 0), new UnityEngine.Vector3(control2.X, control2.Y, 0), 
                                   Handles.color, uScriptConfig.lineTexture, lineWidth );
            }
         }

         int postLinkIndex = i;
         // render post-link nodes
         for (i = postLinkIndex; i < visibleList.Count; i++)
         {
            Node node = visibleList[i] as Node;
            if (node != null)
            {
               node.ZoomScale = Zoom;
               node.OnPaint(e);
            }
         }

         if ( Point.Empty != m_StartMarquee )
         {
            Point position = Detox.Windows.Forms.Cursor.Position;
            position = this.PointToClient( position );

            int startX = Math.Min( m_StartMarquee.X, position.X );
            int endX   = Math.Max( m_StartMarquee.X, position.X );

            int startY = Math.Min( m_StartMarquee.Y, position.Y );
            int endY   = Math.Max( m_StartMarquee.Y, position.Y );

            startX += Location.X;
            startY += Location.Y;

            endX += Location.X;
            endY += Location.Y;
               
            e.Graphics.DrawRectangle( pen, startX, startY, endX - startX, endY - startY );
         }


         selectedPen.Dispose();
         pen.Dispose( );
      }

      public void AddLink(Link link)
      {
         m_Links.Add( link );
      }
      
      private static int CompareNodes(Control c1, Control c2)
      {
         Node n1 = c1 as Node;
         Node n2 = c2 as Node;
         
         // comments should always go to the back
         if (n1.StyleName.Contains("comment"))
         {
            if (n2.StyleName.Contains("comment"))
            {
               return 0;
            }
            else
            {
               return -1;
            }
         }
         else if (n2.StyleName.Contains("comment"))
         {
            return 1;
         }

         // selected nodes should always render last
         if (n1.Selected)
         {
            if (n2.Selected)
            {
               return 0;
            }
            else
            {
               return 1;
            }
         }
         else if (n2.Selected)
         {
            return -1;
         }
         
         // if neither node is selected, use render depth
         if (n1.RenderDepth < n2.RenderDepth)
         {
            return -1;
         }
         else if (n1.RenderDepth > n2.RenderDepth)
         {
            return 1;
         }
         
         return 0;
      }
   }

   public class Link
   {
      public class Connection
      {
         public Node   Node;
         public string AnchorName;

         public AnchorPoint Anchor { get { return Node.GetAnchorPoint(AnchorName); } }
      }

      public Connection Source;
      public Connection Destination;
      public object     Tag;
      public Guid       Guid = Guid.NewGuid( );
      public bool       Selected = false;

      public Link()
      {
         Source      = new Connection( );
         Destination = new Connection( );
      
         Tag = null;
      }

      public Link(Node start, string startAnchor, Node end, string endAnchor)
      {
         Source      = new Connection( );
         Destination = new Connection( );

         Source.Node        = start;
         Source.AnchorName  = startAnchor;
         Destination.Node   = end;
         Destination.AnchorName = endAnchor;
      
         Tag = null;
      }
   }

   public struct AnchorPoint
   {
      public string Name;
      public string StyleName;

      public float X;
      public float Y;
      public float Width;
      public float Height;
      public bool Input;
      public bool Output;
      public bool CanSource;
      public Region Region;
   }
         
   public struct TextPoint
   {
      public string StyleName;
      public string Name;
      public float X;
      public float Y;
   }

   public class AnchorPointActivatedEventArgs : EventArgs
   {
      public AnchorPoint AnchorPoint;

      public AnchorPointActivatedEventArgs(AnchorPoint point)
      {
         AnchorPoint = point;
      }
   }

   public abstract class Node : UserControl
   {
      public bool IsCircleWhenZoomed = false;

      public string StyleName = "";
      public string UnselectedStyleName = "";

      // render all nodes below link lines by default
      virtual public int RenderDepth { get { return FlowChartCtrl.LinkRenderDepth - 1; } }

      public bool CanResize = false;

      protected bool m_Selected = false;
      virtual public bool Selected 
      {
         get { return m_Selected; }
         set 
         {
            if (m_Selected != value)
            {
               m_Selected = value;
               Invalidate( ); // Node (base) SelectionChanged - This may not be needed
            }
         }
      }

      public abstract Guid Guid { get; }
      private Point m_MouseOffset;
      private Size  m_ResizeOffset;

      private AnchorPoint[] m_AnchorPoints;

      public delegate void ModifiedEventHandler(object sender, EventArgs e);
      public event ModifiedEventHandler Modified;

      public bool IntersectsWith(Rectangle rectangle)
      {
         Point p = new Point( (int) ((Location.X + Parent.Location.X) * ZoomScale),
                              (int) ((Location.Y + Parent.Location.Y) * ZoomScale));

         p = Parent.PointToClient( p );

         Rectangle b = new Rectangle( p.X, p.Y, ZoomSize.Width, ZoomSize.Height );

         if ( b.Right  < rectangle.Left )   return false;
         if ( b.Left   > rectangle.Right )  return false;
         if ( b.Bottom < rectangle.Top )    return false;
         if ( b.Top    > rectangle.Bottom ) return false;

         return true;
      }

      public void OnModified( )
      {
         if (null != Modified) Modified(this, new EventArgs());
      }

      public void AddEventHandlers( )
      {
      }

      public void RemoveEventHandlers( )
      {
      }

      public virtual void PreparePoints( )
      {
      }
		
      public virtual bool IsVisible( Rectangle visibleRect )
      {
         Point location = PointToScreen( new Point(0,0) );

         float leftSide  = location.X;
         float rightSide = location.X + ZoomSize.Width;

         if (rightSide < visibleRect.X || leftSide > visibleRect.Right) 
         {
            return false;
         }
         
         float topSide = location.Y;
         float bottomSide = location.Y + ZoomSize.Height;
         
         if (bottomSide < visibleRect.Y || topSide > visibleRect.Bottom )
         {
            return false;
         }
         
         return true;
      }

      public bool PointInAnchorPoint( Point point, ref AnchorPoint hitPoint )
      {
         bool found = false;

         Detox.Drawing.Graphics g = CreateGraphics( );

         if ( m_AnchorPoints == null ) return false;

         foreach ( AnchorPoint ap in m_AnchorPoints )
         {
            //RectangleF rect = ap.Region.GetBounds(g);
            float x = ap.X / 100.0f * ZoomSize.Width;
            float y = ap.Y / 100.0f * ZoomSize.Height;

            float width  = ap.Width / 100.0f * ZoomSize.Width;
            float height = ap.Height / 100.0f * ZoomSize.Height;

            if ( point.X >= x - width  / 2 && point.X <= x + width / 2 &&
                 point.Y >= y - height / 2 && point.Y <= y + height / 2 )
            {
               hitPoint = ap;
               found    = true;
               break;
            }
         }

         g.Dispose( );

         return found;
      }

      public void StartNodeMove( )
      {
         Point position = Detox.Windows.Forms.Cursor.Position;
         position = this.Parent.PointToClient( position );

         Point p = PointToScreen( new Point(0, 0) );
         p = this.Parent.PointToClient( p );
         
         m_MouseOffset = new Detox.Drawing.Point( (int) ((position.X - p.X)), (int) ((position.Y - p.Y)));
      }

      public void StartNodeResize( )
      {
         m_MouseOffset  = Detox.Windows.Forms.Cursor.Position;
         m_ResizeOffset = ZoomSize;
      }

      public void NodeMove( )
      {
         //use the parent's position
         //for mouse coords, if we use our position
         //the mouse is relative to us which throws it off when
         //we move ourselves
         Point position = Detox.Windows.Forms.Cursor.Position;
         position = this.Parent.PointToClient( position );

         Point p = new Detox.Drawing.Point( (int) ((position.X - m_MouseOffset.X)), (int) ((position.Y - m_MouseOffset.Y)) );

         p = this.Parent.PointToScreen( p );

         //accounting for zoom factor must take place in screen space
         p.X = (int) (p.X / ZoomScale);
         p.Y = (int) (p.Y / ZoomScale);
         
         p = this.Parent.PointToClient( p );
   
         Location = p;
      }

      public void NodeResize( )
      {
         //use the parent's position
         //for mouse coords, if we use our position
         //the mouse is relative to us which throws it off when
         //we move ourselves
         Point position = Detox.Windows.Forms.Cursor.Position;

         Size = new Detox.Drawing.Size(m_ResizeOffset.Width + position.X - m_MouseOffset.X, m_ResizeOffset.Height + position.Y - m_MouseOffset.Y );
         
         if ( Size.Width  < uScriptConfig.MinResizeX  ) Size.Width = uScriptConfig.MinResizeX;
         if ( Size.Height < uScriptConfig.MinResizeY )  Size.Height = uScriptConfig.MinResizeY;
      }

      public AnchorPoint GetAnchorPoint(string name)
      {
         foreach (AnchorPoint anchorPoint in m_AnchorPoints)
         {
            if ( name == anchorPoint.Name ) return anchorPoint;
         }

         return new AnchorPoint( );
      }

      public AnchorPoint[] AnchorPoints
      {
         get { return m_AnchorPoints; }
         set { m_AnchorPoints = value; }
      }

      protected TextPoint [] TextPoints 
      { 
         get { return m_TextPoints; } 
         set { m_TextPoints = value; }
      }

      private TextPoint [] m_TextPoints = new TextPoint[ 0 ];

      public override void OnPaint(PaintEventArgs e)
      {         
         base.OnPaint(e);

         Point location = new Point( Location.X + Parent.Location.X, Location.Y + Parent.Location.Y );

         Rectangle nodeRect = new Rectangle( );
         nodeRect.X      = (int) (location.X * ZoomScale);
         nodeRect.Y      = (int) (location.Y * ZoomScale);
         nodeRect.Width  = (int) (ZoomSize.Width);
         nodeRect.Height = (int) (ZoomSize.Height);

         // Draw the node
         if ( 1.0f != ZoomScale )
         {
            if ( true == IsCircleWhenZoomed )
            {
               UnityEngine.Color color = Handles.color;

               Handles.color = uScriptConfig.GetStyleColor(StyleName);

               Handles.DrawSolidDisc(new Vector3(nodeRect.X + nodeRect.Width / 2, nodeRect.Y + nodeRect.Height / 2, 0), new Vector3(0, 0, -1), nodeRect.Width / 2.0f);
            
               Handles.color = color;
            }
            else
            {
               e.Graphics.FillRectangle(StyleName, nodeRect, Name, this);
            }
         }
         else
         {
            e.Graphics.FillRectangle(StyleName, nodeRect, Name, this);
   
            FlowChartCtrl flowChart = Parent as FlowChartCtrl;

            Point position = Detox.Windows.Forms.Cursor.Position;
            position = PointToClient( position );

            
            for ( int i = 0; i < AnchorPoints.Length; i++ )
            {
               AnchorPoint point = m_AnchorPoints[ i ];

               bool connecting = false;

               float x = point.X / 100.0f * ZoomSize.Width;
               float y = point.Y / 100.0f * ZoomSize.Height;

               float diameter = (point.Width / 100.0f * ZoomSize.Width);
               float radius   = (diameter / 2.0f + 0.5f);

               if ( true == flowChart.LinkStartAnchor.Output && true == point.Input ||
                    true == flowChart.LinkStartAnchor.Input  && true == point.Output )
               {
                  if ( position.X >= x - radius && position.X <= x + radius &&
                       position.Y >= y - radius && position.Y <= y + radius )
                  {
                     connecting = true;
                  }
               }

               if ( false == connecting )
               {
                  if ( null != flowChart.LinkStartNode )
                  {
                     connecting = flowChart.LinkStartNode == this &&
                                  flowChart.LinkStartAnchor.Name == point.Name;
                  }
               }

               //save original style in case it'll be modified for rendering
               AnchorPoint originalPoint = point;

               flowChart.OnPointRender( this, i, point, connecting );

               //reget point incase the point render modified it
               point = m_AnchorPoints[ i ];

               // Sockets
               GUI.Box(new Rect(x + location.X - radius, y + location.Y - radius, diameter, diameter), "", uScriptConfig.Style.Get(point.StyleName));

               //return original style in case it was modified for rendering
               m_AnchorPoints[ i ] = originalPoint;
            }

            for (int i = 0; i < TextPoints.Count(); i++)
            {
               float x = TextPoints[i].X / 100.0f * ZoomSize.Width;
               float y = TextPoints[i].Y / 100.0f * ZoomSize.Height;

               //trapperm...
               //we do Size.Height + 14 because we want some text to be able to hang off of the
               //bottom of the node.  In a perfect world we would require a rect in the TextPoint struct
               //but I think that is too big of a chance for Retail Beta
               if ( ((Detox.ScriptEditor.DisplayNode)this).EntityNode is Detox.ScriptEditor.CommentNode )
               {
                  Detox.ScriptEditor.CommentNode comment = (Detox.ScriptEditor.CommentNode) ((Detox.ScriptEditor.DisplayNode)this).EntityNode;

                  GUIStyle commentStyle = uScriptConfig.Style.Get(TextPoints[i].StyleName);
                  commentStyle.normal.textColor = (UnityEngine.Color) comment.BodyTextColor.DefaultAsObject;
               }
               
               GUI.Label( new Rect(x + location.X, y + location.Y, ZoomSize.Width - x, (ZoomSize.Height + 14) - y), TextPoints[i].Name, uScriptConfig.Style.Get(TextPoints[i].StyleName) );
            }

            if ( CanResize )
            {
               Rect rect = new Rect( location.X + ZoomSize.Width - uScriptConfig.ResizeTexture.width, location.Y + ZoomSize.Height - uScriptConfig.ResizeTexture.height, uScriptConfig.ResizeTexture.width, uScriptConfig.ResizeTexture.height );
               GUI.DrawTexture( rect, uScriptConfig.ResizeTexture );
            }
         }
      }
   }

   public class FlowchartNodesModifiedEventArgs : EventArgs
   {
      private Node[] m_Nodes;
      public  Node[] Nodes 
      { get { return m_Nodes; } }

      public FlowchartNodesModifiedEventArgs(Node []nodes)
      {
         m_Nodes = nodes;
      }
   }

   public class FlowchartPointRenderEventArgs : EventArgs
   {
      public int  Index;
      public bool Connecting;

      public AnchorPoint Point;

      public FlowchartPointRenderEventArgs(int index, AnchorPoint point, bool connecting)
      {
         Index = index;
         Point = point;
         Connecting = connecting;
      }
   }

   public class FlowchartLinkCreatedEventArgs : EventArgs
   {
      private Link m_Link;
      public  Link Link 
      { get { return m_Link; } }

      public FlowchartLinkCreatedEventArgs(Link link)
      {
         m_Link = link;
      }
   }
}
