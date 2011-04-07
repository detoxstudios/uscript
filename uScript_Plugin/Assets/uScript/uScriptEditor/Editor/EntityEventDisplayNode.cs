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
   public partial class EntityEventDisplayNode : DisplayNode
   {
      public  EntityEvent EntityEvent
      { get { return (EntityEvent) EntityNode; } }

      public EntityEventDisplayNode(EntityEvent entityEvent) : base(entityEvent)
      {
         InitializeComponent();
         AddEventHandlers( );

         NodeStyle = "node_event";
         Location  = new System.Drawing.Point( entityEvent.Position.X, entityEvent.Position.Y );
         Name = entityEvent.Instance.FriendlyName;
			
         List<Socket> sockets = new List<Socket>( );

         Socket socket;

         foreach ( Parameter parameter in entityEvent.Parameters )
         {
            //nothing from the script can call events
            //so we can't allow on input links to set us
            //which means we should only be exposed in the property grid
            //not as a socket
            if ( true == parameter.Input ) continue;
            
            socket = new Socket( );
            socket.Alignment = Socket.Align.Bottom;
            socket.InternalName = parameter.Name;
            socket.FriendlyName = parameter.FriendlyName;
            socket.Input = parameter.Input;
            socket.Type = parameter.Type;
            socket.Output = parameter.Output;
            sockets.Add( socket );
         }

         foreach ( Plug output in entityEvent.Outputs )
         {
            socket = new Socket( );
            socket.Alignment = Socket.Align.Right;
            socket.InternalName = output.Name;
            socket.FriendlyName = output.FriendlyName;
            socket.Input = false;
            socket.Type = "";
            socket.Output = true;
            sockets.Add( socket );
         }

         UpdateSockets( sockets.ToArray( ) );
      }
   }
}