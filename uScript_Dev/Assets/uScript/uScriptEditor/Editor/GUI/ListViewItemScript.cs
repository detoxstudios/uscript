// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewItemScript.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ListViewItem_Script type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using UnityEditor;

   using UnityEngine;

   public class ListViewItemScript : ListViewItem
   {
      // === Constants ==================================================================

      // === Fields =====================================================================

      // === Constructors ===============================================================

      public ListViewItemScript(ListView listView, string path)
         : base(listView, path)
      {
         this.SourceState = 0;
         this.SceneName = string.Empty;
         this.FriendlyName = string.Empty;
      }

      // === Finalizers =================================================================

      // === Delegates ==================================================================

      // === Events =====================================================================

      // === Enums ======================================================================

      public enum State
      {
         Missing,
         Stale,
         Debug,
         Release
      }
      // === Interfaces =================================================================

      // === Properties =================================================================

      public string FriendlyName { get; set; }

      public string SceneName { get; set; }

      public State SourceState { get; set; }



      // === Indexers ===================================================================

      // === Methods ====================================================================

      public override void Draw(ref Rect itemRowRect)
      {
         var e = Event.current;
         var isRepaint = e.type == EventType.Repaint;

         // Draw row background (alternate and selected)
         if (isRepaint)
         {
            if (this.Selected)
            {
               Style.Row.Draw(this.Position, GUIContent.none, false, false, true, this.ListView.HasFocus);
            }
         }













         //var rect = new Rect(itemRowRect);
         //itemRowRect.height = this.Height;

         //Debug.Log("ITEM:\t" + this.Path + "\n\t\t\t" + this.FriendlyName + ", " + this.SceneName + ", " + this.SourceState + ", " + itemRowRect + "\n");


         // All row drawing should take place there, including the foldouts, selected highlights, and column cells.
         // Mouse input related to row selection and GUI buttons should be handled there as well.


         var rect = new Rect(itemRowRect);
         itemRowRect.height += this.Height;


         //         this.height = (int)this.style.label.fixedHeight;

         //Debug.Log("Default ListViewItem renderer: " + itemRowRect.ToString() + "\n"
         //            + "ROW: " + this._listView.ItemRow.ToString() + ", RECT: " + itemRowRect.ToString() + "\n");


         //if (this.HasVisibleChildren)
         //{
         //   //Debug.Log("PARENT: " + this.Name + "\n");

         //   //// foldout toggle
         //   //rect.x = 2 + (this.Depth * indentWidth);
         //   //rect.y--;
         //   //rect.width = indentWidth;

         //   //this.Expanded = GUI.Toggle(rect, this.Expanded, GUIContent.none, Style.Foldout);

         //   //rect.x = this.Depth * indentWidth;
         //   //rect.y++;
         //   //rect.width = this.Position.width;

         //   //if (isRepaint)
         //   //{
         //   //   Style.Row.Draw(rect, this.Name, false, false, false, false);
         //   //}

         //   var rectToggle = this.Position;
         //   rectToggle.xMin = 2 + (this.Depth * indentWidth);
         //   rectToggle.width = 20;

         //   rectToggle.x += 20;

         //   this.Expanded = GUI.Toggle(rectToggle, this.Expanded, GUIContent.none, Style.Foldout);

         //   var rectRow = this.Position;

         //   if (e.type == EventType.MouseDown)
         //   {
         //      this.ClickCount = Event.current.clickCount;
         //   }

         //   if (GUI.Button(rectRow, Ellipsis.Compact(this.Name, Style.Row, rectRow, Ellipsis.Format.Middle), GUI.skin.label))
         //   {
         //      this.ListView.HandleMouseInput(this);
         //   }



         //   //var rectToggle = this.Position;
         //   //rectToggle.xMin = 2 + (this.Depth * indentWidth);
         //   //rectToggle.width = 20;

         //   //rect

         //   //this.Expanded = GUI.Toggle(rectToggle, this.Expanded, GUIContent.none, Style.Foldout);

         //   //var r2 = this.Position;
         //   //r2.xMin = rect.xMax;

         //   //if (e.type == EventType.MouseDown)
         //   //{
         //   //   this.ClickCount = Event.current.clickCount;
         //   //}

         //   //if (GUI.Button(r2, Ellipsis.Compact(this.Name, Style.Row, r2, Ellipsis.Format.Middle), GUI.skin.label))
         //   //{
         //   //   this.ListView.HandleMouseInput(this);
         //   //}
         //}
         //else
         //{
         //   rect = this.Position;
         //   rect.xMin = this.Depth * indentWidth;

         //   //Style.Row.Draw(rect, Ellipsis.Compact(this.Name, Style.Row, rect, Ellipsis.Format.Middle), false, false, false, false);
         //   //if (GUI.Button(rect, Ellipsis.Compact(this.Name, Style.Row, rect, Ellipsis.Format.Middle)))
         //   //{
         //   //   Debug.Log("PRESSED: " + this.Name + "\n");
         //   //}

         //   if (e.type == EventType.MouseDown)
         //   {
         //      this.ClickCount = Event.current.clickCount;
         //   }

         //   if (GUI.Button(rect, Ellipsis.Compact(this.Name, Style.Row, rect, Ellipsis.Format.Middle), GUI.skin.label))
         //   {
         //      this.ListView.HandleMouseInput(this);
         //   }

         //   //GUI.changed = false;
         //   //GUI.Toggle(
         //   //   rect,
         //   //   this.Selected,
         //   //   Ellipsis.Compact(this.Name, Style.Row, rect, Ellipsis.Format.Middle),
         //   //   GUI.skin.label);
         //   //if (GUI.changed)
         //   //{
         //   //   GUI.changed = false;

         //   //   this.ListView.HandleMouseInput(this);
         //   //}
         //}

         ////uScriptGUI.DebugBox(this.Position, Color.blue, this.Name);











         // Draw column cells in the order of the columns
         rect = this.Position;

         var isMouseOverRow = this.Position.Contains(e.mousePosition);
         //var isAltKeyDown = e.modifiers == EventModifiers.Alt;
         var isAltKeyDown = e.alt;

         //if (isMouseOverRow)
         //{
         //   Debug.Log("OVER ROW: " + this.Name + ", ALT: " + isAltKeyDown + "\n");
         //}

         foreach (var column in this.ListView.Columns)
         {
            rect.width = column.Width;

            switch (column.ID)
            {
               case "graph":
                  this.DrawColumnGraph(rect);
                  break;

               case "scene":
                  this.DrawColumnScene(rect);
                  break;

               case "state":
                  this.DrawColumnState(rect);
                  break;

               default:
                  Debug.Log("Unhandled column: " + column.ID + "\n");
                  break;
            }

            rect.x += rect.width;
         }

         // Handle cell input
         //    Click
         //    ContextClick

         // Handle row input
         //    Click
         if (e.type == EventType.MouseDown && e.button == 0 && this.Position.Contains(e.mousePosition))
         {
            this.ListView.HandleMouseInput(this);
            //Debug.Log("ROW CLICKED: " + this.Name + "\n");
            //e.Use();
         }

         //    ContextClick
         //    Keyboard
      }

      private static void CommandSceneLocate(string scenePath)
      {
         uScriptGUI.PingProjectScene(scenePath);
      }

      private void CommandDirectoryLocate(string directory)
      {
         // Foldout paths duplicate the folder name at the end, so remove it (e.g., "foo/bar/bar" -> "foo/bar")
         uScriptGUI.PingProjectGraph(directory.Substring(0, directory.LastIndexOf("/", System.StringComparison.Ordinal)));
      }

      private void CommandScriptLocate(string scriptPath)
      {
         uScriptGUI.PingProjectGraph(scriptPath);
      }

      private void CommandSourceLocate(string scriptName)
      {
         if (uScriptGUI.PingProjectScript(scriptName) == false)
         {
            this.SourceState = State.Missing;
         }
         else if (this.SourceState == State.Missing)
         {
            this.SourceState = uScript.Instance.IsStale(scriptName)
               ? State.Stale
               : uScript.Instance.HasDebugCode(scriptName)
                  ? State.Debug
                  : State.Release;
         }
      }

      private void DrawColumnGraph(Rect rect)
      {
         var e = Event.current;
         var indentWidth = Style.Foldout.padding.left;

         if (this.HasVisibleChildren)
         {
            var rectToggle = rect;
            rectToggle.xMin = 2 + (this.Depth * indentWidth);
            rectToggle.width = 20;

            this.Expanded = GUI.Toggle(rectToggle, this.Expanded, GUIContent.none, Style.Foldout);

            // TODO: If there columns cannot be reordered, and this column is first, let's use the full width for the foldouts
            rect.xMin = rectToggle.xMax;

            if (e.type == EventType.MouseDown)
            {
               this.ClickCount = Event.current.clickCount;
            }

            if (e.modifiers == EventModifiers.Alt)
            {
               if (GUI.Button(rect, Ellipsis.Compact(this.Name, Style.Label, rect, Ellipsis.Format.Middle), Style.Label))
               {
                  this.CommandDirectoryLocate(this.Path);
               }
            }
            else
            {
               GUI.Label(rect, Ellipsis.Compact(this.Name, Style.Label, rect, Ellipsis.Format.Middle), Style.Label);
            }
         }
         else
         {
            rect.xMin = 2 + (this.Depth * indentWidth);

            //if (GUI.Button(rect, column.ID))
            //{
            //   Debug.Log("CELL Clicked: " + column.ID + "\n");
            //}

            //rect = this.Position;
            //rect.xMin = this.Depth * indentWidth;

            //Style.Row.Draw(rect, Ellipsis.Compact(this.Name, Style.Row, rect, Ellipsis.Format.Middle), false, false, false, false);
            //if (GUI.Button(rect, Ellipsis.Compact(this.Name, Style.Row, rect, Ellipsis.Format.Middle)))
            //{
            //   Debug.Log("PRESSED: " + this.Name + "\n");
            //}

            if (e.type == EventType.MouseDown)
            {
               this.ClickCount = Event.current.clickCount;
            }

            // TODO: Only use FriendlyName if the user-specified option is enabled
            var graphName = string.IsNullOrEmpty(this.FriendlyName) ? this.Name : this.FriendlyName;

            if (e.modifiers == EventModifiers.Alt)
            {
               if (GUI.Button(rect, Ellipsis.Compact(graphName, Style.Label, rect, Ellipsis.Format.Middle), Style.Label))
               {
                  this.CommandScriptLocate(this.Path);
               }
            }
            else
            {
               GUI.Label(rect, Ellipsis.Compact(graphName, Style.Label, rect, Ellipsis.Format.Middle), Style.Label);
            }
         }
      }

      private void DrawColumnScene(Rect rect)
      {
         if (this.HasVisibleChildren || string.IsNullOrEmpty(this.SceneName))
         {
            return;
         }

         var e = Event.current;

         if (e.type == EventType.MouseDown)
         {
            this.ClickCount = Event.current.clickCount;
         }

         if (e.modifiers == EventModifiers.Alt)
         {
            if (GUI.Button(rect, Ellipsis.Compact(this.SceneName, Style.Label, rect, Ellipsis.Format.Middle), Style.Label))
            {
               CommandSceneLocate(this.SceneName);
            }
         }
         else
         {
            GUI.Label(rect, Ellipsis.Compact(this.SceneName, Style.Label, rect, Ellipsis.Format.Middle), Style.Label);
         }
      }

      private void DrawColumnState(Rect rect)
      {
         if (this.HasVisibleChildren)
         {
            return;
         }

         var e = Event.current;

         if (e.type == EventType.MouseDown)
         {
            this.ClickCount = Event.current.clickCount;
         }

         var stateButtonContent = this.SourceState == State.Missing
                                     ? PanelScript.SourceStateContent.Missing
                                     : (this.SourceState == State.Stale
                                           ? PanelScript.SourceStateContent.Stale
                                           : (this.SourceState == State.Debug
                                                 ? PanelScript.SourceStateContent.Debug
                                                 : PanelScript.SourceStateContent.Release));

         rect.width = stateButtonContent.image.width + 2;
         rect.height = stateButtonContent.image.height + 2;

         if (e.modifiers == EventModifiers.Alt)
         {
            if (GUI.Button(rect, stateButtonContent, Style.StatusIcon))
            {
               this.CommandSourceLocate(this.Name);
            }
         }
         else
         {
            GUI.Label(rect, stateButtonContent, Style.StatusIcon);
         }
      }

      // === Structs ====================================================================

      // === Classes ====================================================================

      private static class Content
      {
         static Content()
         {
            NoScene = new GUIContent("This script is not attached to any scene.  It may be used with Prefabs or as a Nested Script.");

            WrongScene = new GUIContent("This uScript file was previously attached to a different Unity Scene.  "
               + "It may not be compatible with the current Unity Scene, and may not run correctly, if edited while this scene is open.");

            IconScript = uScriptGUI.GetTexture("iconScriptFile01");
            IconScriptNested = uScriptGUI.GetTexture("iconScriptFile02");

            IconSourceDebug = uScriptGUI.GetTexture("iconScriptStatusDebug");
            IconSourceMissing = uScriptGUI.GetTexture("iconScriptStatusMissing");
            IconSourceRelease = uScriptGUI.GetTexture("iconScriptStatusRelease");
            IconSourceUnknown = uScriptGUI.GetTexture("iconScriptStatusUnknown");

            IconUnityScene = uScriptGUI.GetSkinnedTexture("UnityScene");
         }

         public static Texture2D IconScript { get; private set; }

         public static Texture2D IconScriptNested { get; private set; }

         public static Texture2D IconSourceDebug { get; private set; }

         public static Texture2D IconSourceMissing { get; private set; }

         public static Texture2D IconSourceRelease { get; private set; }

         public static Texture2D IconSourceUnknown { get; private set; }

         public static Texture2D IconUnityScene { get; private set; }

         public static GUIContent NoScene { get; private set; }

         public static GUIContent WrongScene { get; private set; }
      }

      private static class Style
      {
         static Style()
         {
            StatusIcon = new GUIStyle
            {
               border = new RectOffset(6, 6, 4, 4),
               padding = new RectOffset(1, 1, 1, 1),
               active = { background = GUI.skin.button.active.background }
            };

            Foldout = new GUIStyle("IN Foldout");

            Row = new GUIStyle("PR Row") { contentOffset = new Vector2(0, -1) };

            Label = new GUIStyle(EditorStyles.label)
            {
               border = new RectOffset(6, 6, 4, 4),
               active = { background = GUI.skin.button.active.background }
            };
         }

         public static GUIStyle Label { get; private set; }

         public static GUIStyle StatusIcon { get; private set; }

         public static GUIStyle Foldout { get; private set; }

         public static GUIStyle Row { get; private set; }
      }


      // ================================================================================
      // ================================================================================
      // ================================================================================

      //GUIStyle rowStyle = (this.selected ? Style.Row : (this.listView.ItemRow % 2 == 0 ? this.style.rowEven : this.style.rowOdd));

         //if (isRepaint)
         //{
         //   // Draw row background
         //   GUIStyle rowStyle = (this.selected ? Style.Row : (this.listView.ItemRow % 2 == 0 ? this.style.rowEven : this.style.rowOdd));

         //   // isHover, isActive, on, hasKeyboardFocus
         //   //    GREY (on)
         //   //    BLUE (on, hasKeyboardFocus)
         //   //    RING (isHover, isActive)
         //   rowStyle.Draw(this.rowRect, GUIContent.none, false, false, true, this.listView.HasFocus);
         //}

   }
}
