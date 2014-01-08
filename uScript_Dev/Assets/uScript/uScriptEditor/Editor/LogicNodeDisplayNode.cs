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
   public partial class LogicNodeDisplayNode : DisplayNode
   {
      public  LogicNode LogicNode
      { get { return (LogicNode) EntityNode; } }

      public LogicNodeDisplayNode(LogicNode logicNode, ScriptEditorCtrl ctrl) : base(logicNode, ctrl)
      {
         InitializeComponent();
         AddEventHandlers( );

          // Logic nodes with no inputs and only event outputs
          // should resemble event nodes
         if (logicNode.Inputs.Length == 0 && 
             logicNode.Outputs.Length == 0 &&
             logicNode.Events.Length > 0)
         {
             NodeStyle = "node_event";
         }

         Location = new Detox.Drawing.Point( logicNode.Position.X, logicNode.Position.Y );
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
            if ( true == parameter.IsHidden( ) ) continue;

            Socket socket = new Socket( );
            socket.Alignment = Socket.Align.Bottom;
            socket.InternalName = parameter.Name;
            socket.FriendlyName = parameter.FriendlyName;
            socket.Input = parameter.Input;
            socket.Output = parameter.Output;
            socket.Type = parameter.Type;

            if ( true == socket.Input && null != m_Ctrl )
            {
               //if it can be expanded or collapsed that means
               //there is nothing attached to it so we can render the default value
               if ( true == m_Ctrl.CanExpandParameter(parameter) ||
                    true == m_Ctrl.CanCollapseParameter(Guid, parameter) )
               {
                  socket.DefaultValue = parameter.Default;
               }
            }

            sockets.Add( socket );
         }

         UpdateSockets( sockets.ToArray() );
      }
   }
}
