// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalNodeDisplayNode.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the LocalNodeDisplayNode type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.ScriptEditor
{
   using System;
   using System.Collections.Generic;

   using Detox.Drawing;
   using Detox.Editor;
   using Detox.FlowChart;

   using UnityEngine;

   using Graphics = Detox.Drawing.Graphics;

   public partial class LocalNodeDisplayNode : DisplayNode
   {
      public  LocalNode LocalNode
      { get { return (LocalNode) EntityNode; } }

      override public int RenderDepth { get { return FlowChartCtrl.LinkRenderDepth + 1; } }

      public LocalNodeDisplayNode(LocalNode localNode, ScriptEditorCtrl ctrl)
         : base(localNode, ctrl)
      {
         InitializeComponent();
         AddEventHandlers( );

         Location = new Detox.Drawing.Point( localNode.Position.X, localNode.Position.Y );
         Name = "";

         PrepareNode( );
      }

      public override bool Selected
      {
         set
         {
            if (base.Selected != value)
            {
               base.Selected = value;
               PrepareNode( );
               Invalidate( );  // Node SelectionChanged
            }
         }
      }

      private void PrepareNode( )
      {
         string value = "";

         Name = LocalNode.Name.Default;

         // Use the variable type name if the variable is empty/null
         if ("" == LocalNode.Value.Default)
         {
            var name = uScriptConfig.Variable.FriendlyName(this.LocalNode.Value.Type);
            value = string.Format("({0})", name.ReplaceFirst("UnityEngine.", string.Empty));
         }
         else
         {
            if (this.LocalNode.Value.Type.Contains("Mask"))
            {
               value = uScriptGUI.FormatMaskDisplay(this.LocalNode.Value.Default);
            }
            else
            {
               var valueType = uScript.Instance.GetType(this.LocalNode.Value.Type);
               if (valueType.HasElementType)
               {
                  valueType = valueType.GetElementType();
               }

               if (this.LocalNode.Value.Default.Contains(Data.ScriptEditor.Parameter.ArrayDelimeter.ToString()))
               {
                  var elements = this.LocalNode.Value.Default.Split(Data.ScriptEditor.Parameter.ArrayDelimeter);

                  if (valueType == typeof(GameObject) || typeof(Component).IsAssignableFrom(valueType))
                  {
                     for (var index = 1; index < elements.Length; index++)
                     {
                        var element = System.IO.Path.GetFileName(elements[index]);
                        if (element == string.Empty && valueType != null)
                        {
                           var name = uScriptConfig.Variable.FriendlyName(valueType.ToString());
                           element = string.Format("({0})", name.ReplaceFirst("UnityEngine.", string.Empty));
                        }
                        elements[index] = element;
                     }
                     value = string.Join(string.Format("{0} ", Data.ScriptEditor.Parameter.ArrayDelimeter), elements);
                  }
                  else
                  {
                     //Debug.LogFormat(
                     //   "ArrayDelimeter\n" + "Type: {0}, Default: '{1}' ",
                     //   this.LocalNode.Value.Type,
                     //   this.LocalNode.Value.Default);

                     for (var index = 1; index < elements.Length; index++)
                     {
                        if (valueType != typeof(int) && valueType != typeof(float) && valueType != typeof(string)
                            && valueType != null && valueType.IsEnum == false)
                        {
                           elements[index] = string.Format("({0})", elements[index]);
                        }
                     }

                     value = string.Join(string.Format("{0} ", Data.ScriptEditor.Parameter.ArrayDelimeter), elements);
                  }

               }
               else
               {
                  if (valueType == typeof(GameObject) || typeof(Component).IsAssignableFrom(valueType))
                  {
                     // "/Parent 1/Child A/" will show as "Child A"
                     var element = System.IO.Path.GetFileName(this.LocalNode.Value.Default.TrimEnd('/'));
                     value = element;
                  }
                  else
                  {
                     value = this.LocalNode.Value.Default;
                  }
               }
            }
         }

         if (Preferences.ShouldDrawCollapsedVariable(this.Selected))
         {
            if (value.Length > 3)
            {
               value = value.Substring(0, 3) + "...";
            }
         }

         NodeStyle = "variable_" + uScriptConfig.Variable.FriendlyStyleName(LocalNode.Value.Type);

         List<Socket> sockets = new List<Socket>( );
         Socket socket;

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName   = LocalNode.Value.Name;
         socket.FriendlyName   = "";
         socket.Input  = LocalNode.Value.Input;
         socket.Output = LocalNode.Value.Output;
         socket.Type   = LocalNode.Value.Type;
         sockets.Add( socket );

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName = value;
         socket.FriendlyName = value;
         socket.Input  = false;
         socket.Output = false;
         socket.Type   = "";
         sockets.Add( socket );

         UpdateSockets( sockets.ToArray( ) );
      }

      protected override Size CalculateSize(Socket[] sockets)
      {
         return Preferences.ShouldDrawCollapsedVariable(this.Selected)
                   ? new Size(57, 57)
                   : new Size(System.Math.Max(base.CalculateSize(sockets).Width, 57), 57);
      }
   }

   public partial class ExternalConnectionDisplayNode : DisplayNode
   {
      override public int RenderDepth { get { return FlowChartCtrl.LinkRenderDepth + 1; } }

      public  ExternalConnection ExternalConnection
      { get { return (ExternalConnection) EntityNode; } }

      public ExternalConnectionDisplayNode(ExternalConnection externalConnection, ScriptEditorCtrl ctrl) : base(externalConnection, ctrl)
      {
         InitializeComponent();
         AddEventHandlers( );

         
         NodeStyle = "externalconnection";

         Location = new Detox.Drawing.Point( externalConnection.Position.X, externalConnection.Position.Y );

         Name = "";

         PrepareNode( );
      }

      public override bool Selected
      {
         set
         {
            if (base.Selected != value)
            {
               base.Selected = value;
               PrepareNode( );
               Invalidate( );  // ExternalConnection SelectionChanged
            }
         }
      }

      private void PrepareNode( )
      {
         string name = "(External)";

         if ( "" != ExternalConnection.Name.Default ) name = ExternalConnection.Name.Default;

         if (Preferences.ShouldDrawCollapsedVariable(this.Selected))
         {
            if (name.Length > 3)
            {
               name = name.Substring(0, 3) + "...";
            }
         }

         List<Socket> sockets = new List<Socket>( );
         Socket socket;

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName = ExternalConnection.Connection;
         socket.FriendlyName = ExternalConnection.Connection;
         socket.Input  = true;
         socket.Output = true;
         socket.Type   = "";
         sockets.Add( socket );

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName = name;
         socket.FriendlyName = name;
         socket.Input  = false;
         socket.Output = false;
         socket.Type   = "";
         sockets.Add( socket );

         UpdateSockets( sockets.ToArray( ) );
      }

      protected override Size CalculateSize(Socket[] sockets)
      {
         return Preferences.ShouldDrawCollapsedVariable(this.Selected)
                   ? new Size(61, 59)
                   : new Size(System.Math.Max(base.CalculateSize(sockets).Width, 61), 59);
      }

      protected override void CenterPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints)
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
               SizeF size = Graphics.sMeasureString( FormatName(socket), "socket_text" );

               TextPoint textPoint = new TextPoint( );

               textPoint.Name = FormatName(socket);
               textPoint.X = (Size.Width - uScriptConfig.Style.RightShadow - size.Width) / 2;
               textPoint.Y = (Size.Height - uScriptConfig.Style.BottomShadow - size.Height) / 2;
               textPoint.StyleName = "externalconnection_text";

               if ( textPoint.X < 0 ) textPoint.X = 0;
               if ( textPoint.Y < 0 ) textPoint.Y = 0;

               textPoints.Add( textPoint );
            }
         }
      }
   }

   public partial class OwnerConnectionDisplayNode : DisplayNode
   {
      override public int RenderDepth { get { return FlowChartCtrl.LinkRenderDepth + 1; } }

      public  OwnerConnection OwnerConnection
      { get { return (OwnerConnection) EntityNode; } }

      public OwnerConnectionDisplayNode(OwnerConnection ownerConnection, ScriptEditorCtrl ctrl) : base(ownerConnection, ctrl)
      {
         InitializeComponent();
         AddEventHandlers( );

         NodeStyle = "variable_owner";

         Location = new Detox.Drawing.Point( ownerConnection.Position.X, ownerConnection.Position.Y );

         Name = "";

         PrepareNode( );
      }

      private void PrepareNode( )
      {
         List<Socket> sockets = new List<Socket>( );
         Socket socket;

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName = OwnerConnection.Connection.Name;
         socket.FriendlyName = OwnerConnection.Connection.FriendlyName;
         socket.Input  = OwnerConnection.Connection.Input;
         socket.Output = OwnerConnection.Connection.Output;
         socket.Type   = OwnerConnection.Connection.Type;
         sockets.Add( socket );

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName = "Owner";
         socket.FriendlyName = "Owner";
         socket.Input  = false;
         socket.Output = false;
         socket.Type   = "";
         sockets.Add( socket );

         UpdateSockets( sockets.ToArray( ) );
      }

      protected override Size CalculateSize(Socket []sockets)
      {
         return new Size(57, 57);
      }

      protected override void CenterPoints(Socket []sockets, List<AnchorPoint> points, List<TextPoint> textPoints)
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
}

