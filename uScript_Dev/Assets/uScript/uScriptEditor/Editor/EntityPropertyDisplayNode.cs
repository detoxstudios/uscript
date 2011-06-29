﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Detox.FlowChart;

namespace Detox.ScriptEditor
{
   public partial class EntityPropertyDisplayNode : DisplayNode
   {
      public  EntityProperty EntityProperty
      { get { return (EntityProperty) EntityNode; } }

      override public int RenderDepth { get { return FlowChartCtrl.LinkRenderDepth + 1; } }

      public string DisplayName
      {
         get
         {
            string name = "";

            name = EntityProperty.Instance.Default;
            if ( "" == name ) name = "(" + uScriptConfig.Variable.FriendlyName(EntityProperty.Instance.Type) + ")";

            name += "\n";
            name += EntityProperty.Parameter.FriendlyName;

            return name;
         }
      }

      public string DisplayValue
      {
         get
         {
            return EntityProperty.Parameter.Default;
         }
      }


      public EntityPropertyDisplayNode(EntityProperty entityProperty)
         : base(entityProperty)
      {
         InitializeComponent();
         AddEventHandlers( );

         Location = new System.Drawing.Point( entityProperty.Position.X, entityProperty.Position.Y );
         Name = "";

         NodeStyle = "property_" + uScriptConfig.Variable.FriendlyStyleName(entityProperty.Parameter.Type);

         List<Socket> sockets = new List<Socket>( );
         Socket socket;

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName = entityProperty.Parameter.Name;
         socket.FriendlyName = entityProperty.Parameter.FriendlyName;
         socket.Input  = true;
         socket.Output = true;
         socket.Type   = entityProperty.Parameter.Type;
         sockets.Add( socket );

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName = DisplayName + "\n" + DisplayValue + "\n";
         socket.FriendlyName = DisplayName + "\n" + DisplayValue + "\n";
         socket.Input  = false;
         socket.Output = false;
         socket.Type   = "";
         sockets.Add( socket );

         UpdateSockets( sockets.ToArray( ) );
      }

      //overridden so we can bold our title
      protected override void CenterPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints)
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
                  float height = 0;
                  string [] subString = FormatName(socket).Split( '\n' );

                  foreach ( string s in subString )
                  {
                     string style = "socket_text";

                     if ( s == subString[0] && subString.Length > 1 )
                     {
                        style = "socket_text_bold";
                     }

                     height += Graphics.sMeasureString( s, style ).Height;
                  }

                  float y = (Size.Height - uScriptConfig.Style.BottomShadow - height) /  2;

                  foreach ( string s in subString )
                  {
                     TextPoint textPoint = new TextPoint( );

                     string style = "socket_text";

                     if ( s == subString[0] && subString.Length > 1 )
                     {
                        style = "socket_text_bold";
                     }

                     SizeF textLength = Graphics.sMeasureString( s, style );

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
   }
}
