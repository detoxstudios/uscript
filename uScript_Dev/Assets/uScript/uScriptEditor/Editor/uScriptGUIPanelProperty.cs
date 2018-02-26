// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIPanelProperty.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptGUIPanelProperty type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Detox.Editor;

using UnityEditor;

using UnityEngine;

public sealed class uScriptGUIPanelProperty : uScriptGUIPanel
{
   private static readonly uScriptGUIPanelProperty PanelInstance = new uScriptGUIPanelProperty();

   private int selectedNodeCount;

   private uScriptGUIPanelProperty()
   {
      InUScriptPanel = true;
      this.Init();
   }

   public static uScriptGUIPanelProperty Instance
   {
      get
      {
         return PanelInstance;
      }
   }

   public Rect Rect { get; private set; }

   public Rect ScrollviewRect { get; private set; }

   public override void Draw()
   {
      var uScriptInstance = uScript.Instance;

      this.selectedNodeCount = uScript.Instance.ScriptEditorCtrl.SelectedNodes.Length;

      Rect rect;
      if (InUScriptPanel && !uScriptInstance.IsOnlyBottomPanelVisible(GetType().ToString()))
      {
         rect = EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox, GUILayout.Width(uScriptGUI.PanelPropertiesWidth));
      }
      else
      {
         rect = EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox, GUILayout.ExpandWidth(true));
      }
      {
         if (Math.Abs(rect.width) > 0 && Math.Abs(rect.width - uScriptGUI.PanelPropertiesWidth) > 0)
         {
            // if we didn't get the width we requested, we must have hit a limit, stop dragging and reset the width
            uScriptGUI.PanelPropertiesWidth = (int)rect.width;
            uScript.Instance.MouseDownRegion = uScript.MouseRegion.Canvas;
            uScript.Instance.ForceReleaseMouse();
         }

         if (InUScriptPanel) this.DrawToolbar();
         this.DrawProperties();
      }

      EditorGUILayout.EndVertical();

      if (Event.current.type == EventType.Repaint)
      {
         this.Rect = GUILayoutUtility.GetLastRect();
      }

      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Properties);
   }

   private void DrawToolbar()
   {
      EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
      {
         GUILayout.Label(this.Name, uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));
         if (InUScriptPanel)
         {
            if (GUILayout.Button(Content.ButtonPopout, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(Content.ButtonPopout).x)))
            {
               if (uScript.GetUScriptGUIPanelWindow<uScriptGUIPanelProperty>() == null) uScript.OpenPopOutWindow(this);
               uScript.Instance.CommandCanvasShowPropertiesPanel();
            }
            if (GUILayout.Button(Content.ButtonClose, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(Content.ButtonClose).x)))
            {
               uScript.Instance.CommandCanvasShowPropertiesPanel();
            }
         }
      }

      EditorGUILayout.EndHorizontal();
   }

   private void DrawProperties()
   {
      if (uScript.Instance.wasCanvasDragged && Preferences.DrawPanelsOnUpdate == false)
      {
         this.DrawHiddenNotification();
      }
      else if (this.selectedNodeCount > Preferences.PropertyPanelNodeLimit)
      {
         this.DrawExcessiveNodesNotification();
      }
      else
      {
         this.ScrollviewOffset = EditorGUILayout.BeginScrollView(
            this.ScrollviewOffset,
            false,
            false,
            uScriptGUIStyle.HorizontalScrollbar,
            uScriptGUIStyle.VerticalScrollbar,
            "scrollview");
         {
            if (uScript.Instance.ScriptEditorCtrl != null)
            {
               uScript.Instance.ScriptEditorCtrl.PropertyGrid.OnPaint(new Detox.Drawing.PointF(this.ScrollviewOffset.x, this.ScrollviewOffset.y), 
                                                                      new Detox.Drawing.RectangleF(this.ScrollviewRect.x, this.ScrollviewRect.y, this.ScrollviewRect.width, this.ScrollviewRect.height));
            }
         }

         EditorGUILayout.EndScrollView();

         if (Event.current.type == EventType.Repaint)
         {
            this.ScrollviewRect = GUILayoutUtility.GetLastRect();
         }
      }
   }

   private void DrawExcessiveNodesNotification()
   {
      var limit = Preferences.PropertyPanelNodeLimit;
      var message =
         string.Format(
            "The {0} panel is configured to show the properties of {1}, but there are currently {2} nodes selected.\n\n"
            + "The limit can be modified via the Preferences panel, although increasing the limit may adversely affect performance.",
            this.Name,
            limit == 1 ? "a single selected node" : string.Format("no more than {0} selected nodes", limit),
            this.selectedNodeCount);

      EditorGUILayout.BeginScrollView(Vector2.zero, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, "scrollview");
      {
         GUILayout.Label(message, uScriptGUIStyle.PanelMessage);
      }

      EditorGUILayout.EndScrollView();
   }

   private void Init()
   {
      this.Name = "Properties";
   }

   private static class Content
   {
      static Content()
      {
         ButtonPopout = new GUIContent
         {
            image = uScriptGUI.GetSkinnedTexture("iconPopout"),
            tooltip = "Open a standalone window with this panel's contents within it."
         };

         ButtonClose = new GUIContent
         {
            image = uScriptGUI.GetSkinnedTexture("iconMiniDelete"),
            tooltip = "Close this panel."
         };
      }

      public static GUIContent ButtonPopout { get; private set; }
      public static GUIContent ButtonClose { get; private set; }
   }
}
