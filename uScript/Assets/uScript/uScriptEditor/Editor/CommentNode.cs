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

         int newLine = 0;

         string formatComment = "";

         foreach ( char c in comment.BodyText.Default )
         {
            if ( newLine > 64 && c == ' ' )
            {
               formatComment += "\n";
               newLine = 0;
            }
            else
            {
               formatComment += c;
            }

            newLine++;
         }

		 Name += "\n" + formatComment;

         UpdateSockets( new Socket[]{} );
      }

      protected override Size CalculateSize(Socket []sockets, System.Drawing.Graphics g)
      {
         Size size = base.CalculateSize(sockets, g);
         
         try
         {
            int []intArray = (int[]) Comment.Size.DefaultAsObject;

            int width  = intArray[0];
            int height = intArray.Length > 1 ? intArray[1] : 0;

            if ( width  > 0 ) size.Width = width;
            if ( height > 0 ) size.Height = height;
         
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
 
            return size;
         }
         catch
         {}

         return size;
      }
   }
}