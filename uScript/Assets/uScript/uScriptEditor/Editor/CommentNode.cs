using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Detox.FlowChart;
using UnityEngine;

namespace Detox.ScriptEditor
{
   public partial class CommentDisplayNode : DisplayNode
   {
      public  CommentNode Comment
      { get { return (CommentNode) EntityNode; } }

      override public int RenderDepth { get { return 0; } }

      public CommentDisplayNode(CommentNode comment) : base(comment)
      {
         InitializeComponent();
         AddEventHandlers( );

         CanResize = true;
         NodeStyle = "comment";
   
         Location = new System.Drawing.Point( comment.Position.X, comment.Position.Y );

         Name = comment.TitleText.Default;

         List<Socket> sockets = new List<Socket>( );
         Socket socket;

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName = "";
         socket.FriendlyName = comment.BodyText.Default;
         socket.Input  = false;
         socket.Output = false;
         socket.Type   = "";
         sockets.Add( socket );

         UpdateSockets( sockets.ToArray( ) );
      }

      protected override Size CalculateSize(Socket []sockets, System.Drawing.Graphics g)
      {
         Size size = base.CalculateSize(sockets, g);
         
         CommentNode clone = Comment;
         Parameter p = clone.Size;

         try
         {
            int []intArray = (int[]) Comment.Size.DefaultAsObject;

            int width  = intArray[0];
            int height = intArray.Length > 1 ? intArray[1] : 0;

            if ( width  > 0 ) size.Width = width;
            if ( height > 0 ) size.Height = height;
         
            if ( size.Width  < uScriptConfig.MinResizeX ) size.Width = uScriptConfig.MinResizeX;
            if ( size.Height < uScriptConfig.MinResizeY ) size.Height = uScriptConfig.MinResizeY;

            p.DefaultAsObject = new int[2] { size.Width, size.Height };
            clone.Size = p;
            UpdateNode( clone );

            return size;
         }
         catch
         {}

         try
         {
            string []intArray = Comment.Size.Default.Split( ',' );

            int width  = Int32.Parse(intArray[0]);
            int height = intArray.Length > 1 ? Int32.Parse(intArray[1]) : 0;

            if ( width  > 0 ) size.Width = width;
            if ( height > 0 ) size.Height = height;
 
            if ( size.Width  < uScriptConfig.MinResizeX ) size.Width = uScriptConfig.MinResizeX;
            if ( size.Height < uScriptConfig.MinResizeY ) size.Height = uScriptConfig.MinResizeY;

            p.DefaultAsObject = new int[2] { size.Width, size.Height };
            clone.Size = p;
            UpdateNode( clone );

            return size;
         }
         catch
         {}

         if ( size.Width  < uScriptConfig.MinResizeX ) size.Width = uScriptConfig.MinResizeX;
         if ( size.Height < uScriptConfig.MinResizeY ) size.Height = uScriptConfig.MinResizeY;

         p.DefaultAsObject = new int[2] { size.Width, size.Height };
         clone.Size = p;
         UpdateNode( clone );

         return size;
      }

      protected override void CenterPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints, System.Drawing.Graphics g)
      {
         foreach ( Socket socket in sockets )
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
               TextPoint textPoint = new TextPoint( );

               textPoint.Name = FormatName(socket);
               textPoint.X = 0;
               textPoint.Y = 0;
               textPoint.StyleName = "comment_body_text";

               if ( textPoint.X < 0 ) textPoint.X = 0;
               if ( textPoint.Y < 0 ) textPoint.Y = 0;

               textPoints.Add( textPoint );
            }
         }
      }

   }
}