using System;
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
   public partial class LocalNodeDisplayNode : DisplayNode
   {
      public  LocalNode LocalNode
      { get { return (LocalNode) EntityNode; } }

      override public int RenderDepth { get { return FlowChartCtrl.LinkRenderDepth + 1; } }

      public LocalNodeDisplayNode(LocalNode localNode)
         : base(localNode)
      {
         InitializeComponent();
         AddEventHandlers( );

         Location = new System.Drawing.Point( localNode.Position.X, localNode.Position.Y );
         Name = "";

         PrepareNode( );
      }

      private void PrepareNode( )
      {
         string name = LocalNode.Name.Default;
			
         // Use the variable type name if the variable is empty/null
         if ( "" == LocalNode.Value.Default )
         {
            name = name + "(" + uScriptConfig.Variable.FriendlyName(LocalNode.Value.Type) + ")";
         }
         else
         {
            name = LocalNode.Value.Default;
         }

         if ( false == Selected )
         {
            if ( name.Length > 3 )
            {
               name = name.Substring( 0, 3 ) + "...";
            }
         }

         NodeStyle = "variable_" + uScriptConfig.Variable.FriendlyStyleName(LocalNode.Value.Type);
			
         List<Socket> sockets = new List<Socket>( );
         Socket socket;

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName   = LocalNode.Value.Name;
         socket.FriendlyName   = LocalNode.Value.FriendlyName;
         socket.Input  = LocalNode.Value.Input;
         socket.Output = LocalNode.Value.Output;
         socket.Type   = LocalNode.Value.Type;
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

      protected override Size CalculateSize(Socket []sockets, Graphics g)
      {
         if ( false == Selected ) return new Size(57, 57);

         Size size = base.CalculateSize(sockets, g);
         size.Height = 57;

         return size;
      }

      //overridden so we can expand if we are selected
      public override void OnPaint( PaintEventArgs e )
      {
         PrepareNode( );
         base.OnPaint( e );
      }
   }

   public partial class ExternalConnectionDisplayNode : DisplayNode
   {
      public  ExternalConnection ExternalConnection
      { get { return (ExternalConnection) EntityNode; } }

      public ExternalConnectionDisplayNode(ExternalConnection externalConnection) : base(externalConnection)
      {
         InitializeComponent();
         AddEventHandlers( );

         Location = new System.Drawing.Point( externalConnection.Position.X, externalConnection.Position.Y );
         string name = "";

         if ( "" != externalConnection.Name.Default ) name += "Name: " + externalConnection.Name.Default + "\n";
         Name = name + "(External)";

         List<Socket> sockets = new List<Socket>( );
         Socket socket;

         socket = new Socket( );
         socket.Alignment = Socket.Align.Center;
         socket.InternalName = externalConnection.Connection;
         socket.FriendlyName = externalConnection.Connection;
         socket.Input  = true;
         socket.Output = true;
         socket.Type   = "";
         sockets.Add( socket );

         UpdateSockets( sockets.ToArray( ) );
      }
   }
}
   