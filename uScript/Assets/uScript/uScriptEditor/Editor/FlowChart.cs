using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

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
      private bool m_NodeIsMoving = false;

      private Point m_MoveOffset = Point.Empty;
      private Point m_StartMoveLocation = Point.Empty;

      private bool InMoveMode 
      { 
         get 
         { 
            return Control.ModifierKeys == Keys.Control &&
                   Control.MouseButtons == MouseButtons.Left;   
         } 
      }

      public FlowChartCtrl( )
      {
         InitializeComponent( );
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
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
         this.DoubleBuffered = true;
         this.Name = "FlowChartCtrl";
         this.Size = new System.Drawing.Size(4096, 4096);
         this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FlowChartCtrl_MouseMove);
         this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlowChartCtrl_MouseDown);
         this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FlowChartCtrl_MouseUp);
         this.ResumeLayout(false);

         int halfWidth = (int)(uScript.Instance.NodeWindowRect.width / 2.0f);
         int halfHeight = (int)(uScript.Instance.NodeWindowRect.height / 2.0f);
         this.Location = new Point(-2048 + halfWidth, -2048 + halfHeight);

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

      private void OnSelectionModified( )
      {
         if (null != SelectionModified) SelectionModified(this, new EventArgs());
      }

      public delegate void FlowChartLinkCreatedEventHandler(object sender, FlowchartLinkCreatedEventArgs e);
      public event FlowChartLinkCreatedEventHandler LinkCreated;

      private void OnLinkCreated(Link link)
      {
         if (null != LinkCreated) LinkCreated(this, new FlowchartLinkCreatedEventArgs(link));
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
            
         Invalidate( );
      }

      private bool LinkInRect(Link link, Rectangle rect)
      {
         Point start = new Point( (int) (link.Source.Anchor.X / 100.0f * link.Source.Node.Size.Width), 
                                  (int) (link.Source.Anchor.Y / 100.0f * link.Source.Node.Size.Height) );
   
         start  = link.Source.Node.PointToScreen( start );
         start  = this.PointToClient( start );

         Point end = new Point( (int) (link.Destination.Anchor.X / 100.0f * link.Destination.Node.Size.Width), 
                                (int) (link.Destination.Anchor.Y / 100.0f * link.Destination.Node.Size.Height) );
   
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

         Point start = new Point( (int) (link.Source.Anchor.X / 100.0f * link.Source.Node.Size.Width), 
                                  (int) (link.Source.Anchor.Y / 100.0f * link.Source.Node.Size.Height) );
   
         start  = link.Source.Node.PointToScreen( start );
         start  = this.PointToClient( start );
         Point end = new Point( (int) (link.Destination.Anchor.X / 100.0f * link.Destination.Node.Size.Width), 
                                (int) (link.Destination.Anchor.Y / 100.0f * link.Destination.Node.Size.Height) );
   
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
         if ( true == InMoveMode ) 
         {
            Invalidate( );
            return;
         }

         if ( e.Button == MouseButtons.Left )
         {
            m_StartMarquee = new Point( e.X, e.Y );
         }
      }

      private void FlowChartCtrl_NodeModified(object sender, EventArgs e)
      {
         OnNodesModified( new Node[1] { sender as Node } );
      }

      private void FlowChartCtrl_NodeMouseDown(object sender, MouseEventArgs e)
      {
         if ( true == InMoveMode )
         {
            Invalidate( );
            return;
         }

         if ( e.Button == MouseButtons.Left )
         {
            Node node = sender as Node;

            //use the parent's position
            //for mouse coords, if we use our position
            //the mouse is relative to us which throws it off when
            //we move ourselves
            Point position = System.Windows.Forms.Cursor.Position;
            position = node.PointToClient( position );

            AnchorPoint anchorPoint = new AnchorPoint( );
            bool pointSourced = false;               
            if ( true == node.PointInAnchorPoint(position, ref anchorPoint) )
            {
               if ( true == anchorPoint.CanSource )
               {
                  OnAnchorPointActivated( node, anchorPoint );
                  Invalidate( );
                  pointSourced = true;
               }
            }

            if ( false == pointSourced )
            {
               m_NodeMouseTracking = true;
               
               //I want the user to easily click and move a node without having to select it
               //but I also want to move all selected nodes if they click on an already selected node
               //so.. if the node is not previously selected, it's just a quick click to move
               //only that node.  if the node is selected, then i'm assuming they want to move all
               //selected nodes
               if ( false == node.Selected )
               {
                  node.StartNodeMove( );
               }
               else
               {            
                  foreach ( Node selectedNode in SelectedNodes )
                  {
                     selectedNode.StartNodeMove( );
                  }
               }
            }
         }
      }

      //called "NodeMouseMove" because it's a relayed message from
      //the node, which will have the mouse coords in node space
      private void FlowChartCtrl_NodeMouseMove(object sender, MouseEventArgs e)
      {
         if ( false == InMoveMode )
         {
            if ( true == m_NodeMouseTracking )
            {
               Node node = sender as Node;
               
               m_NodeIsMoving = true;

               //see comments in NodeMouseDown for why we have this if/else
               if ( false == node.Selected )
               {
                  node.NodeMove( );
               }
               else
               {
                  foreach ( Node selectedNode in SelectedNodes )
                  {
                     selectedNode.NodeMove( );
                  }
               }
            }
         }
         
         Invalidate( );
      }

      //called "NodeMouseUp" because it's a relayed message from
      //the node, which will have the mouse coords in node space
      private void FlowChartCtrl_NodeMouseUp(object sender, MouseEventArgs e)
      {
         if ( e.Button != MouseButtons.Left ) return;

         List<Node> modifiedNodes = new List<Node>( );
         Link createdLink = null;

         bool selectionSetChanged = false;
   
         //if we were moving the node
         //simply finish moving it, don't unselect anything
         if ( true == m_NodeMouseTracking && true == m_NodeIsMoving )
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
         else
         {
            //if no control key, unselect the rest
            if ( Control.ModifierKeys != Keys.Control )
            {
               foreach (Node node in SelectedNodes)
               {
                  node.Selected = false;
               }

               foreach ( Link link in SelectedLinks )
               {
                  link.Selected = false;
               }
            }

            Node nodeSelected = sender as Node;

            //change selection state
            //(if ctrl key was down it will toggle selection state)
            //(if ctrl key was up it will always have been unselected
            // because of the above code and so this will always select it)
            nodeSelected.Selected = ! nodeSelected.Selected;
            selectionSetChanged = true;
         }

         m_NodeMouseTracking = false;
         m_NodeIsMoving      = false;

         if ( null != m_StartLinkNode )
         {
            Point position = System.Windows.Forms.Cursor.Position;

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
                        //default to start is output and dest is input
                        AnchorPoint sourceAnchor = m_LinkStartAnchor.Output ? m_LinkStartAnchor : hitPoint;
                        AnchorPoint destAnchor   = m_LinkStartAnchor.Output ? hitPoint : m_LinkStartAnchor;

                        Node sourceNode = m_LinkStartAnchor.Output ? m_StartLinkNode : node;
                        Node destNode   = m_LinkStartAnchor.Output ? node : m_StartLinkNode;
   
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

         if ( true == selectionSetChanged )
         {
            OnSelectionModified( );
         }

         Invalidate( );
      }
      
      private void FlowChartCtrl_MouseUp(object sender, MouseEventArgs e)
      {
         if ( e.Button != MouseButtons.Left ) return;

         bool selectionSetModified = false;

         if ( Point.Empty != m_StartMarquee )
         {
            RunMarqueeSelect( );
            //assume the marquee selected or deselected something
            //in the future we should keep track if a selection changed
            selectionSetModified = true;
         }

         Point position = System.Windows.Forms.Cursor.Position;
         position = PointToClient( position );

         foreach ( Link link in m_Links )
         {
            if ( true == InLink(link, position) )
            {
               //change selection state
               //(if ctrl key was down it will toggle selection state)
               //(if ctrl key was up it will always have been unselected
               // because of the above code and so this will always select it)
               link.Selected = ! link.Selected;
               selectionSetModified = true;
            }
         }
         
         m_StartLinkNode = null;
         m_StartMarquee  = Point.Empty;
         
         if ( true == selectionSetModified )
         {
            OnSelectionModified( );
         }

         Invalidate( );
      }

      private void RunMarqueeSelect( )
      {
         Point position = System.Windows.Forms.Cursor.Position;
         position = this.PointToClient( position );

         //if no control key, unselect the rest
         if ( Control.ModifierKeys != Keys.Control )
         {
            foreach (Node node in SelectedNodes)
            {
               node.Selected = false;
            }

            foreach ( Link link in SelectedLinks )
            {
               link.Selected = false;
            }
         }

         int startX = Math.Min( m_StartMarquee.X, position.X );
         int endX   = Math.Max( m_StartMarquee.X, position.X );

         int startY = Math.Min( m_StartMarquee.Y, position.Y );
         int endY   = Math.Max( m_StartMarquee.Y, position.Y );
      
         Rectangle rect = new Rectangle( startX, startY, endX - startX, endY - startY );

         foreach ( Node node in m_Nodes.Values )
         {
            if ( true == node.Bounds.IntersectsWith(rect) )
            {
               node.Selected = true;
            }
         }

         foreach ( Link link in m_Links )
         {
            if ( LinkInRect(link, rect) )
            {
               link.Selected = true;
            }
         }
      }

      private void FlowChartCtrl_MouseMove(object sender, MouseEventArgs e)
      {
         if ( true == InMoveMode )
         {
            Invalidate( );
         }
         else
         {
            if ( null != m_StartLinkNode || Point.Empty != m_StartMarquee )
            {
               if ( Point.Empty != m_StartMarquee )
               {
                  RunMarqueeSelect( );
               }

               Invalidate( );
            }
         }
      }

      private void OnAnchorPointActivated(Node node, AnchorPoint anchorPoint)
      {
         m_StartLinkNode   = node;
         m_LinkStartAnchor = anchorPoint;

         this.Focus( );
      }

      public override void OnPaint(PaintEventArgs e)
      {
         //draw grid if ShowGrid == true
         {
            if ( uScriptConfig.Style.ShowGrid )
            {
               float g;
               
               int vertical   = (int) Math.Floor(uScriptConfig.Style.GridSizeVertical);
               int horizontal = (int) Math.Floor(uScriptConfig.Style.GridSizeHorizontal);
   
               float offsetX = Location.X % vertical;
               float offsetY = Location.Y % horizontal;
   
               offsetX += uScriptConfig.Style.GridSizeVertical   - vertical;
               offsetY += uScriptConfig.Style.GridSizeHorizontal - horizontal;
   
               Vector3 startGrid = new Vector3( offsetX, offsetY );
               Vector3 endGrid   = new Vector3( uScript.Instance.NodeWindowRect.width, offsetY );
               
               int gridMajorLineCount = uScriptConfig.Style.GridMajorLineSpacing;
               for ( g = 0; g < uScript.Instance.NodeWindowRect.height; g += uScriptConfig.Style.GridSizeHorizontal )
               {
                  if ( gridMajorLineCount == uScriptConfig.Style.GridMajorLineSpacing )
                  {
                     Handles.color = uScriptConfig.Style.GridColorMajor;
                     gridMajorLineCount = 0;
                  }
                  else
                  {
                     Handles.color = uScriptConfig.Style.GridColorMinor;
                  }
                  
                  Handles.DrawLine( startGrid, endGrid );
                  
                  startGrid.y += uScriptConfig.Style.GridSizeHorizontal;
                  endGrid.y += uScriptConfig.Style.GridSizeHorizontal;
                  
                  gridMajorLineCount++;
               }
               
               startGrid = new Vector3( offsetX, offsetY );
               endGrid   = new Vector3( offsetX, uScript.Instance.NodeWindowRect.height );
               
               gridMajorLineCount = uScriptConfig.Style.GridMajorLineSpacing;
               for ( g = 0; g < uScript.Instance.NodeWindowRect.width; g += uScriptConfig.Style.GridSizeVertical )
               {
                  if ( gridMajorLineCount == uScriptConfig.Style.GridMajorLineSpacing )
                  {
                     Handles.color = uScriptConfig.Style.GridColorMajor;
                     gridMajorLineCount = 0;
                  }
                  else
                  {
                     Handles.color = uScriptConfig.Style.GridColorMinor;
                  }
                  
                  Handles.DrawLine( startGrid, endGrid );
                  
                  startGrid.x += uScriptConfig.Style.GridSizeVertical;
                  endGrid.x += uScriptConfig.Style.GridSizeVertical;
                  
                  gridMajorLineCount++;
               }

            }
         }


         foreach ( Node node in Nodes )
         {
            node.PreparePoints( e.Graphics );
         }

         if ( true == InMoveMode )
         {
            m_StartMarquee  = Point.Empty;
            m_StartLinkNode = null;

            Point position = System.Windows.Forms.Cursor.Position;

            if ( Point.Empty == m_MoveOffset )
            {
               m_MoveOffset        = System.Windows.Forms.Cursor.Position;
               m_StartMoveLocation = Location;
            }

            position = new Point( position.X - m_MoveOffset.X, position.Y - m_MoveOffset.Y );
            position = new Point( m_StartMoveLocation.X + position.X, m_StartMoveLocation.Y + position.Y );

            //clamp top left
            if ( position.X > 0 ) position.X = 0;
            if ( position.Y > 0 ) position.Y = 0;

            //clamp bottom right
            if ( position.X + Bounds.Width  < Parent.Bounds.Right  ) position.X += Parent.Bounds.Right  - ( position.X + Bounds.Width); 
            if ( position.Y + Bounds.Height < Parent.Bounds.Bottom ) position.Y += Parent.Bounds.Bottom - ( position.Y + Bounds.Height); 

            Location = position;
         }
         else
         {
            m_MoveOffset = Point.Empty;
         }

         Pen pen = new Pen( System.Drawing.Color.Black, uScriptConfig.bezierPenWidth );
         Pen selectedPen = new Pen( System.Drawing.Color.LightYellow, uScriptConfig.bezierPenWidthSelected );

         if (null != m_StartLinkNode)
         {
            PointF position = new PointF(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
            position = this.PointToClient( position );

            PointF start = new PointF( (m_LinkStartAnchor.X / 100.0f * m_StartLinkNode.Size.Width), 
                                       (m_LinkStartAnchor.Y / 100.0f * m_StartLinkNode.Size.Height) );
      
            start  = m_StartLinkNode.PointToScreen( start );
            start  = PointToClient( start );

            start.X += Location.X;
            start.Y += Location.Y;

            PointF end = new PointF(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
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

            Handles.color = new UnityEngine.Color( selectedPen.Color.FR, selectedPen.Color.FG, selectedPen.Color.FB );
            Handles.DrawBezier( new UnityEngine.Vector3(start.X, start.Y, 0), new UnityEngine.Vector3(end.X, end.Y, 0), 
                                new UnityEngine.Vector3(control1.X, control1.Y, 0), new UnityEngine.Vector3(control2.X, control2.Y, 0), 
                                 Handles.color, uScriptConfig.lineTexture, selectedPen.Width );

            //e.Graphics.DrawBezier( selectedPen, start, control1, control2, end );
            UnityEngine.GUI.Box( new UnityEngine.Rect(end.X - uScriptConfig.PointerLineEnd.width / 2, end.Y - uScriptConfig.PointerLineEnd.height / 2, 
                                 uScriptConfig.PointerLineEnd.width, uScriptConfig.PointerLineEnd.height), 
                                 uScriptConfig.PointerLineEnd);
         }

         // render pre-link nodes
         int i;

         for (i = 0; i < Controls.Count; i++)
         {
            Node node = Controls[i] as Node;
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
            PointF start = new PointF( link.Source.Anchor.X / 100.0f * link.Source.Node.Size.Width, 
                                       link.Source.Anchor.Y / 100.0f * link.Source.Node.Size.Height );
      
            start  = link.Source.Node.PointToScreen( start );
            start  = PointToClient( start );

            start.X += Location.X;
            start.Y += Location.Y;

            PointF end = new PointF( link.Destination.Anchor.X / 100.0f * link.Destination.Node.Size.Width, 
                                     link.Destination.Anchor.Y / 100.0f * link.Destination.Node.Size.Height );
      
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

               if (link.Source.Node != null)
               {
                  styleName = link.Source.Node.StyleName;

                  if (!String.IsNullOrEmpty(styleName))
                  {
                     for (int j = 0; j < uScriptConfig.StyleTypes.Length; j++)
                     {
                        if (styleName == uScriptConfig.StyleTypes[j])
                        {
                           index = j;
                           break;
                        }
                     }
                  }
               }

               if (index != -1)
               {
                  Handles.color = uScriptConfig.LineColors[index];
                  lineWidth = uScriptConfig.LineWidths[index];
               }

               Handles.DrawBezier( new UnityEngine.Vector3(start.X, start.Y, 0), new UnityEngine.Vector3(end.X, end.Y, 0), 
                                   new UnityEngine.Vector3(control1.X, control1.Y, 0), new UnityEngine.Vector3(control2.X, control2.Y, 0), 
                                   Handles.color, uScriptConfig.lineTexture, lineWidth );
            }
         }

         int postLinkIndex = i;
         // render unselected post-link nodes
         for (i = postLinkIndex; i < Controls.Count; i++)
         {
            Node node = Controls[i] as Node;
            if (node != null)
            {
               if (!node.Selected)
               {
                  node.OnPaint(e);
               }
            }
         }

         // render selected post-link nodes
         for (i = postLinkIndex; i < Controls.Count; i++)
         {
            Node node = Controls[i] as Node;
            if (node != null)
            {
               if (node.Selected)
               {
                  node.OnPaint(e);
               }
            }
         }

         if ( Point.Empty != m_StartMarquee )
         {
            Point position = System.Windows.Forms.Cursor.Position;
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
      public enum NodeRenderShape
      {
         Box,
         Circle
      }

      public string StyleName = "";

      private NodeRenderShape m_RenderShape = NodeRenderShape.Box;
      public NodeRenderShape RenderShape
      {
         get { return m_RenderShape; }
         set
         {
            m_RenderShape = value;
            Invalidate();
         }
      }

      // render all nodes below link lines by default
      virtual public int RenderDepth { get { return FlowChartCtrl.LinkRenderDepth - 1; } }

      private bool m_Selected = false;
      public bool Selected 
      {
         get { return m_Selected; }
         set 
         { 
            m_Selected = value; 
            Invalidate( );
         }
      }

      public abstract Guid Guid { get; }
      private Point m_MouseOffset;

      private AnchorPoint[] m_AnchorPoints;

      public delegate void ModifiedEventHandler(object sender, EventArgs e);
      public event ModifiedEventHandler Modified;

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

      public virtual void PreparePoints( System.Drawing.Graphics g )
      {
      }

      public bool PointInAnchorPoint( Point point, ref AnchorPoint hitPoint )
      {
         bool found = false;

         System.Drawing.Graphics g = CreateGraphics( );

         if ( m_AnchorPoints == null ) return false;

         foreach ( AnchorPoint ap in m_AnchorPoints )
         {
            //RectangleF rect = ap.Region.GetBounds(g);
            float x = ap.X / 100.0f * Size.Width;
            float y = ap.Y / 100.0f * Size.Height;

            float width  = ap.Width / 100.0f * Size.Width;
            float height = ap.Height / 100.0f * Size.Height;

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
         Point position = System.Windows.Forms.Cursor.Position;
         position = this.Parent.PointToClient( position );

         m_MouseOffset = new System.Drawing.Point(position.X - Location.X, position.Y - Location.Y);
      }

      public void NodeMove( )
      {
         //use the parent's position
         //for mouse coords, if we use our position
         //the mouse is relative to us which throws it off when
         //we move ourselves
         Point position = System.Windows.Forms.Cursor.Position;
         position = this.Parent.PointToClient( position );

         Location = new System.Drawing.Point(position.X - m_MouseOffset.X, position.Y - m_MouseOffset.Y );
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

         switch (m_RenderShape)
         {
            case NodeRenderShape.Circle:
               //e.Graphics.FillCircle(StyleName, location.X + (Size.Width / 2), location.Y + (Size.Width / 2), Size.Width / 2 ); // Not used in uScript?
               break;
            case NodeRenderShape.Box:
            default:
               e.Graphics.FillRectangle(StyleName, new Rectangle(location.X, location.Y, Size.Width, Size.Height), Name);
               break;
         }

         FlowChartCtrl flowChart = Parent as FlowChartCtrl;

         Point position = System.Windows.Forms.Cursor.Position;
         position = PointToClient( position );

         for ( int i = 0; i < AnchorPoints.Length; i++ )
         {
            AnchorPoint point = m_AnchorPoints[ i ];

            bool connecting = false;

            float x = point.X / 100.0f * Size.Width;
            float y = point.Y / 100.0f * Size.Height;

            float diameter = (point.Width / 100.0f * Size.Width);
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
            string originalStyle = point.StyleName;

            flowChart.OnPointRender( this, i, point, connecting );

            //reget point incase the point render modified it
            point = m_AnchorPoints[ i ];

            GUI.Box(new Rect(x + location.X - radius, y + location.Y - radius, diameter, diameter), "", uScriptConfig.Style.Get(point.StyleName));

            //return original style in case it was modified for rendering
            m_AnchorPoints[ i ].StyleName = originalStyle;
         }

         if (Selected || m_RenderShape == NodeRenderShape.Box)
         {
             for (int i = 0; i < TextPoints.Count(); i++)
             {
                 float x = TextPoints[i].X / 100.0f * Size.Width;
                 float y = TextPoints[i].Y / 100.0f * Size.Height;

                 e.Graphics.DrawString(TextPoints[i].Name, TextPoints[i].StyleName, new PointF(x + location.X, y + location.Y));
             }
         }
         else
         {
            for (int i = 0; i < TextPoints.Count(); i++)
            {
               float x = TextPoints[i].X / 100.0f * Size.Width;
               float y = TextPoints[i].Y / 100.0f * Size.Height;

               int length = TextPoints[i].Name.Length;
               e.Graphics.DrawString(TextPoints[i].Name.Substring(0,length < 8?length:8), TextPoints[i].StyleName, new PointF(x + location.X, y + location.Y));
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
