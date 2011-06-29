﻿
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

   public partial class OwnerConnectionDisplayNode
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

         int maxValue = System.UInt16.MaxValue;

         //why so big?  because it's simply virtual coordinates to handle scrolling and we
         //want them to be able to scroll as much as they need
         m_FlowChart.Size     = new System.Drawing.Size( maxValue, maxValue );
         m_FlowChart.Location = new System.Drawing.Point(-maxValue / 2, -maxValue / 2);

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

