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
   public partial class LogicNodeDisplayNode : DisplayNode
   {
      public  LogicNode LogicNode
      { get { return (LogicNode) EntityNode; } }

      public LogicNodeDisplayNode(LogicNode logicNode) : base(logicNode)
      {
         InitializeComponent();
         AddEventHandlers( );

         Location = new System.Drawing.Point( logicNode.Position.X, logicNode.Position.Y );
         Name = logicNode.FriendlyName;
         
         List<Socket> sockets = new List<Socket>( );

         foreach ( Plug input in logicNode.Inputs )
         {
            Socket socket = new Socket( );
            socket.Alignment = Socket.Align.Left;
            socket.InternalName = input.Name;
            socket.FriendlyName = input.FriendlyName;
            socket.Type = "";
            socket.Input = true;
            socket.Output = false;
            sockets.Add( socket );
         }

         foreach ( Plug output in logicNode.Outputs )
         {
            Socket socket = new Socket( );
            socket.Alignment = Socket.Align.Right;
            socket.InternalName = output.Name;
            socket.FriendlyName = output.FriendlyName;
            socket.Type = "";
            socket.Input = false;
            socket.Output = true;
            sockets.Add( socket );
         }

         foreach ( Plug eventName in logicNode.Events )
         {
            Socket socket = new Socket( );
            socket.Alignment = Socket.Align.Right;
            socket.InternalName = eventName.Name;
            socket.FriendlyName = eventName.FriendlyName;
            socket.Input = false;
            socket.Type = "";
            socket.Output = true;
            sockets.Add( socket );
         }

         foreach ( Parameter parameter in logicNode.Parameters )
         {
            Socket socket = new Socket( );
            socket.Alignment = Socket.Align.Bottom;
            socket.InternalName = parameter.Name;
            socket.FriendlyName = parameter.FriendlyName;
            socket.Input = parameter.Input;
            socket.Output = parameter.Output;
            socket.Type = parameter.Type;
            sockets.Add( socket );
         }

         UpdateSockets( sockets.ToArray() );
      }
   }
}
