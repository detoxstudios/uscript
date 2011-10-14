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
   public partial class EntityEventDisplayNode : DisplayNode
   {
      public  EntityEvent EntityEvent
      { get { return (EntityEvent) EntityNode; } }

      public EntityEventDisplayNode(EntityEvent entityEvent, ScriptEditorCtrl ctrl) : base(entityEvent, ctrl)
      {
         InitializeComponent();
         AddEventHandlers( );

         NodeStyle = "node_event";
         Location  = new Detox.Drawing.Point( entityEvent.Position.X, entityEvent.Position.Y );
         Name = entityEvent.FriendlyType;
			
         List<Socket> sockets = new List<Socket>( );

         Socket socket;

         if ( true == entityEvent.Instance.IsVisible( ) && false == entityEvent.IsStatic )
         {
            socket = new Socket( );
            socket.Alignment = Socket.Align.Bottom;
            socket.InternalName = entityEvent.Instance.Name;
            socket.FriendlyName = entityEvent.Instance.FriendlyName;
            socket.Type = entityEvent.Instance.Type;
            socket.Input  = true;
            socket.Output = false;

            if ( null != m_Ctrl )
            {
               //if it can be expanded or collapsed that means
               //there is nothing attached to it so we can render the default value
               if ( true == m_Ctrl.CanExpandParameter(entityEvent.Instance) ||
                    true == m_Ctrl.CanCollapseParameter(Guid, entityEvent.Instance) )
               {
                  socket.DefaultValue = entityEvent.Instance.Default;
               }
            }

            sockets.Add( socket );
         }

         foreach ( Parameter parameter in entityEvent.Parameters )
         {
            //nothing from the script can call events
            //so we can't allow on input links to set us
            //which means we should only be exposed in the property grid
            //not as a socket
            if ( true == parameter.Input ) continue;
            if ( true == parameter.IsHidden( ) ) continue;

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