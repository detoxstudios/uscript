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
   public partial class EntityMethodDisplayNode : DisplayNode
   {
      public  EntityMethod EntityMethod
      { get { return (EntityMethod) EntityNode; } }

      public EntityMethodDisplayNode(EntityMethod entityMethod, ScriptEditorCtrl ctrl) : base(entityMethod, ctrl)
      {
         InitializeComponent();
         AddEventHandlers( );

         Location = new Detox.Drawing.Point( entityMethod.Position.X, entityMethod.Position.Y );
         Name = uScriptConfig.Variable.FriendlyName(entityMethod.ComponentType);

         List<Socket> sockets = new List<Socket>( );

         Socket socket;

         if ( true == entityMethod.Instance.IsVisible( ) && false == entityMethod.IsStatic )
         {
            socket = new Socket( );
            socket.Alignment = Socket.Align.Bottom;
            socket.InternalName = entityMethod.Instance.Name;
            socket.FriendlyName = entityMethod.Instance.FriendlyName;
            socket.Type = entityMethod.Instance.Type;
            socket.Input  = true;
            socket.Output = false;

            if ( null != m_Ctrl )
            {
               //if it can be expanded or collapsed that means
               //there is nothing attached to it so we can render the default value
               if ( true == m_Ctrl.CanExpandParameter(entityMethod.Instance) ||
                    true == m_Ctrl.CanCollapseParameter(Guid, entityMethod.Instance) )
               {
                  socket.DefaultValue = entityMethod.Instance.Default;
               }
            }

            sockets.Add( socket );
         }

         foreach ( Parameter parameter in entityMethod.Parameters )
         {
            if ( true == parameter.IsHidden( ) ) continue;

            socket = new Socket( );
            socket.Alignment = Socket.Align.Bottom;
            socket.InternalName = parameter.Name;
            socket.FriendlyName = parameter.FriendlyName;
            socket.Input = parameter.Input;
            socket.Type = parameter.Type;
            socket.Output = parameter.Output;

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

         socket = new Socket( );
         socket.Alignment = Socket.Align.Left;
         socket.InternalName = entityMethod.Input.Name;
         socket.FriendlyName = entityMethod.Input.FriendlyName;
         socket.Input = true;
         socket.Type = "";
         socket.Output = false;
         sockets.Add( socket );
         
         socket = new Socket( );
         socket.Alignment = Socket.Align.Right;
         socket.InternalName = entityMethod.Output.Name;
         socket.FriendlyName = entityMethod.Output.FriendlyName;
         socket.Input = false;
         socket.Type = "";
         socket.Output = true;
         sockets.Add( socket );

         UpdateSockets( sockets.ToArray( ) );
      }
   }
}
