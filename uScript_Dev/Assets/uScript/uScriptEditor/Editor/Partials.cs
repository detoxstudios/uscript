
namespace Detox.ScriptEditor
{
   using System.Windows.Forms;
   using UnityEngine;
   using UnityEditor;

   public partial class EntityMethodDisplayNode
   {
      public void InitializeComponent( )
      {
      }
   }

   public partial class LogicNodeDisplayNode
   {
      public void InitializeComponent( )
      {
      }
   }

   public partial class EntityEventDisplayNode
   {
      public void InitializeComponent( )
      {
      }
   }

   public partial class LocalNodeDisplayNode
   {
      public void InitializeComponent( )
      {
      }
   }

   public partial class ExternalConnectionDisplayNode
   {
      public void InitializeComponent( )
      {
      }
   }

   public partial class ResourceInstanceDisplayNode
   {
      public void InitializeComponent( )
      {
      }
   }

   public partial class EntityPropertyDisplayNode
   {
      public void InitializeComponent( )
      {
      }
   }

   public partial class CommentDisplayNode
   {
      public void InitializeComponent( )
      {
      }
   }

   public partial class GatherTextFrm
   {
      public void InitializeComponent( )
      {
      }
   }

   public partial class ScriptEditorCtrl 
   {
      public ContextMenuStrip ContextMenu { get { return m_ContextMenuStrip; } }

      private ContextMenuStrip m_ContextMenuStrip = new ContextMenuStrip( );
      private Detox.FlowChart.FlowChartCtrl m_FlowChart = new Detox.FlowChart.FlowChartCtrl( );
   
      public void InitializeComponent( )
      {
         m_FlowChart.Parent = this;

         //why so big?  because it's simply virtual coordinates to handle scrolling and we
         //want them to be able to scroll as much as they need
         m_FlowChart.Size = new System.Drawing.Size( System.Int32.MaxValue, System.Int32.MaxValue );

         Controls.Add( m_FlowChart );

      }

      public void BuildContextMenu( )
      {
         m_ContextMenuStrip_Opening( null, null );
      }

      public void GuiPaint( PaintEventArgs e )
      {
         OnPaint( e );
      }
   }
}

