using System;
using System.Collections.Generic;
using System.ComponentModel;
using Detox.Drawing;
using Detox.Data;
using System.Linq;
using System.Text;
using Detox.Windows.Forms;

using Detox.FlowChart;

namespace Detox.ScriptEditor
{
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

         IsCircleWhenZoomed = true;
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
         if ( "" == LocalNode.Value.Default )
         {
            value = "(" + uScriptConfig.Variable.FriendlyName(LocalNode.Value.Type) + ")";
         }
         else
         {
            value = LocalNode.Value.Default;
         }

         if ( (false == Selected || uScript.Preferences.VariableExpansion == Preferences.VariableExpansionType.AlwaysCollapsed) && uScript.Preferences.VariableExpansion != Preferences.VariableExpansionType.AlwaysExpanded )
         {
            if ( value.Length > 3 )
            {
               value = value.Substring( 0, 3 ) + "...";
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

      protected override Size CalculateSize(Socket []sockets)
      {
         if ( (false == Selected || uScript.Preferences.VariableExpansion == Preferences.VariableExpansionType.AlwaysCollapsed) && 
              uScript.Preferences.VariableExpansion != Preferences.VariableExpansionType.AlwaysExpanded ) 
         {
            return new Size(57, 57);
         }

         if ( true == this.m_Ctrl.FlowChart.Zoom < 1.0f )
         {
            return new Size(57, 57);
         }

         Size size = base.CalculateSize(sockets);
         if (size.Width < 57) size.Width = 57;

         size.Height = 57;

         return size;
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

         IsCircleWhenZoomed = true;
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

         if ((false == Selected || uScript.Preferences.VariableExpansion == Preferences.VariableExpansionType.AlwaysCollapsed) && uScript.Preferences.VariableExpansion != Preferences.VariableExpansionType.AlwaysExpanded)
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

      protected override Size CalculateSize(Socket []sockets)
      {
         if ( (false == Selected || uScript.Preferences.VariableExpansion == Preferences.VariableExpansionType.AlwaysCollapsed) && 
               uScript.Preferences.VariableExpansion != Preferences.VariableExpansionType.AlwaysExpanded ) return new Size(61, 59);

         if ( true == this.m_Ctrl.FlowChart.Zoom < 1.0f )
         {
            return new Size(61, 59);
         }

         Size size = base.CalculateSize(sockets);
         if (size.Width < 61) size.Width = 61;

         size.Height = 59;

         return size;
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

         IsCircleWhenZoomed = true;
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
   