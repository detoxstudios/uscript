// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewItemScript.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ListViewItem_Script type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System;

   using UnityEditor;

   using UnityEngine;

   public class ListViewItemScript : ListViewItem
   {
      public ListViewItemScript(ListView listView, string itemPath)
         : base(listView, itemPath)
      {
         // TODO: Consider using a GraphInfo here instead of a path
      }

      public string FriendlyName
      {
         get
         {
            return uScriptBackgroundProcess.GraphInfoList[this.ItemName].GraphName ?? this.ItemName;
         }
      }

      public string GraphName
      {
         get
         {
            return this.ItemName;
         }
      }

      public string GraphPath
      {
         get
         {
#if (UNITY_4_5 || UNITY_4_6 || UNITY_5_0 || UNITY_5_1)
            return uScript.GetGraphPath(this.ItemName);
#else
            return uScript.Preferences.UserScripts + "/" + this.ItemPath;
#endif
         }
      }

      public string SceneName
      {
         get
         {
            GraphInfo gi;
            if (uScriptBackgroundProcess.GraphInfoList.TryGetValue(this.ItemName, out gi)) return gi.SceneName;

            return string.Empty;
         }
      }

      public string ScenePath { get; set; }

      public GraphInfo.State SourceState
      {
         get
         {
            GraphInfo gi;
            if (uScriptBackgroundProcess.GraphInfoList.TryGetValue(this.ItemName, out gi)) return gi.SourceState;

            return GraphInfo.State.Missing;
         }
      }

      // GraphID     - <path>/<name>
      // GraphName   - <name>
      // GraphPath   - <path>/<name>.<extension>

      public override void Draw(ref Rect itemRowRect)
      {
         var e = Event.current;
         var isRepaint = e.type == EventType.Repaint;

         // Draw row background (alternate and selected)
         if (isRepaint)
         {
            // TODO: See if we can get alternate row colors while retaining the focus state colors

            //if (this.Selected)
            //{
            //   Style.RowEven.Draw(this.Position, GUIContent.none, false, false, true, false);
            //   //Style.RowEven.Draw(this.Position, GUIContent.none, false, false, true, this.ListView.HasFocus);
            //   //Debug.Log("FOCUS\n");
            //}
            //else
            //{
            //   Debug.Log("NO FOCUS\n");
            //}

            DrawRowBackground(this.ListView, this.Position, this.Selected);
         }

         //var rect = new Rect(itemRowRect);
         //itemRowRect.height = this.Height;

         // All row drawing should take place there, including the foldouts, selected highlights, and column cells.
         // Mouse input related to row selection and GUI buttons should be handled there as well.

         Rect rect;
         itemRowRect.height += this.Height;

         // Context menu must go before any buttons that will appear in the region
         if (e.type == EventType.ContextClick || (e.type == EventType.MouseUp && e.button == 1))
         {
            var mousePosition = new Vector2(e.mousePosition.x, e.mousePosition.y);

            rect = this.Position;
            rect.yMin = Math.Max(rect.yMin, this.ListView.ListOffset.y);
            rect.yMax = Math.Min(rect.yMax, this.ListView.ListOffset.y + this.ListView.ListPosition.height);

            if (rect.Contains(mousePosition))
            {
               //Debug.Log("CLICK POINT:\t" + mousePosition + "\t\tITEM: " + this.Position.yMin + "-" + (this.Position.yMax - 1) + ", " + this.ItemName + "\n" + "ACTUAL:\t\t\t" + e.mousePosition + "\t\tSCROLLVIEW: " + this.ListView.ListOffset);
               this.ContextMenuCreate(new Rect(e.mousePosition.x, e.mousePosition.y, 0, 0));
            }
         }

         ////uScriptGUI.DebugBox(this.Position, Color.blue, this.ItemName);

         // Draw column cells in the order of the columns
         rect = this.Position;

         //var isMouseOverRow = this.Position.Contains(e.mousePosition);
         //var isAltKeyDown = e.modifiers == EventModifiers.Alt;
         //var isAltKeyDown = e.alt;

         //if (isMouseOverRow)
         //{
         //   Debug.Log("OVER ROW: " + this.ItemName + ", ALT: " + isAltKeyDown + "\n");
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
         }

         //    ContextClick
         //    Keyboard
      }

      private static void DrawRowBackground(ListView listView, Rect position, bool selected)
      {
         //this.ListView.ItemRowEven = !this.ListView.ItemRowEven;
         var style = listView.ItemRowEven ? Style.RowEven : Style.RowOdd;

         // position, isHover, isActive, on, hasKeyboardFocus
         style.Draw(position, false, false, selected, listView.HasFocus);
      }

      private void CommandDirectoryCollapse()
      {
         this.ListView.CollapseFolder(this);
      }

      private void CommandDirectoryCollapseAll()
      {
         this.ListView.CollapseAllFolders();
      }

      private void CommandDirectoryExpand()
      {
         this.ListView.ExpandFolder(this);
      }

      private void CommandDirectoryExpandAll()
      {
         this.ListView.ExpandAllFolders();
      }

      private void CommandDirectoryLocate()
      {
#if (UNITY_4_5 || UNITY_4_6 || UNITY_5_0 || UNITY_5_1)
         uScriptGUI.PingProjectGraph(this.GraphPath);
#else
         var directoryPath = uScript.Preferences.UserScripts + "/";

         // Foldout paths duplicate the folder name at the end, so remove it (e.g., "foo/bar/bar" -> "foo/bar")
         directoryPath += this.ItemPath.Substring(0, this.ItemPath.LastIndexOf("/", StringComparison.Ordinal));

         uScriptGUI.PingProjectGraph(directoryPath);
#endif
      }

      private void CommandGraphLoad()
      {
         uScript.Instance.OpenGraph(this.GraphPath, false);
      }

      private void CommandGraphLocate()
      {
         uScriptGUI.PingProjectGraph(this.GraphPath);
      }

      private void CommandSceneLocate()
      {
         uScriptGUI.PingProjectScene(this.SceneName);
      }

      private void CommandSourceLocate()
      {
         // TODO: Update the source state
         uScriptGUI.PingProjectScript(this.ItemName);
      }

      private void ContextMenuCreate(Rect rect)
      {
         var menu = new GenericMenu();

         if (this.HasChildren)
         {
            if (this.ListView.IsFolderExpanded(this))
            {
               menu.AddItem(Content.CollapseFolder, true, this.CommandDirectoryCollapse);
            }
            else
            {
               menu.AddItem(Content.ExpandFolder, true, this.CommandDirectoryExpand);
            }

            menu.AddSeparator(string.Empty);

            menu.AddItem(Content.LocateFolder, false, this.CommandDirectoryLocate);
         }
         else
         {
            // GRAPH
            var currentGraph = System.IO.Path.GetFileNameWithoutExtension(uScript.Instance.ScriptEditorCtrl.ScriptName) == this.ItemName;
            if (currentGraph)
            {
               // TODO: Consider adding Save commands for the current graph
               if (uScript.Instance.ScriptEditorCtrl.IsDirty)
               {
                  menu.AddItem(Content.ReloadGraph, true, this.CommandGraphLoad);
               }
               else
               {
                  menu.AddDisabledItem(Content.ReloadGraph);
               }
            }
            else
            {
               menu.AddItem(Content.LoadGraph, true, this.CommandGraphLoad);
            }

            menu.AddSeparator(string.Empty);

            menu.AddItem(Content.LocateGraph, false, this.CommandGraphLocate);

            if (string.IsNullOrEmpty(this.SceneName))
            {
               menu.AddDisabledItem(Content.LocateScene);
            }
            else
            {
               menu.AddItem(Content.LocateScene, false, this.CommandSceneLocate);
            }

            if (this.SourceState == GraphInfo.State.Missing)
            {
               menu.AddDisabledItem(Content.LocateSource);

               menu.AddSeparator(string.Empty);

               menu.AddDisabledItem(Content.RemoveSource);
            }
            else
            {
               menu.AddItem(Content.LocateSource, false, this.CommandSourceLocate);

               menu.AddSeparator(string.Empty);

               menu.AddItem(Content.RemoveSource, false, this.CommandSourceRemove);
            }
         }

         menu.AddSeparator(string.Empty);

         menu.AddItem(Content.ExpandAllFolders, false, this.CommandDirectoryExpandAll);
         menu.AddItem(Content.CollapseAllFolders, false, this.CommandDirectoryCollapseAll);

         if (rect.width > 0)
         {
            menu.DropDown(rect);
         }
         else
         {
            menu.ShowAsContext();
         }

         Event.current.Use();
      }

      private void DrawColumnGraph(Rect rect)
      {
         var e = Event.current;
         var indentWidth = Style.Foldout.padding.left;

         var labelStyle = PanelScript.ShowLabelIcons
            ? this.Selected ? Style.IconLabelSelected : Style.IconLabel
            : this.Selected ? Style.TextLabelSelected : Style.TextLabel;

         if (this.HasVisibleChildren)
         {
            var rectToggle = rect;
            rectToggle.xMin += 2 + (this.Depth * indentWidth);
            rectToggle.width = 12;

            var originalState = this.ListView.IsFolderExpanded(this);
            if (originalState != GUI.Toggle(rectToggle, originalState, GUIContent.none, Style.Foldout))
            {
               this.ListView.ToggleFolder(this);
            }

            // TODO: If there columns cannot be reordered, and this column is first, let's use the full width for the foldouts
            rect.xMin = rectToggle.xMax;

            if (e.type == EventType.MouseDown)
            {
               this.ClickCount = Event.current.clickCount;
            }

            if (e.modifiers == EventModifiers.Alt)
            {
               if (GUI.Button(rect, Ellipsis.Compact(this.ItemName, labelStyle, rect, Ellipsis.Format.Middle), labelStyle))
               {
                  this.CommandDirectoryLocate();
               }
            }
            else
            {
               GUI.Label(rect, Ellipsis.Compact(this.ItemName, labelStyle, rect, Ellipsis.Format.Middle), labelStyle);
            }
         }
         else
         {
            rect.xMin += 2 + (this.Depth * indentWidth) + 12;

            if (e.type == EventType.MouseDown)
            {
               this.ClickCount = Event.current.clickCount;
            }

            // TODO: Only use FriendlyName if the user-specified option is enabled
            var graphName = PanelScript.ShowFriendlyNames ? this.FriendlyName : this.ItemName;

            if (e.modifiers == EventModifiers.Alt)
            {
               if (GUI.Button(rect, Ellipsis.Compact(graphName, labelStyle, rect, Ellipsis.Format.Middle), labelStyle))
               {
                  this.CommandGraphLocate();
               }
            }
            else
            {
               GUI.Label(rect, Ellipsis.Compact(graphName, labelStyle, rect, Ellipsis.Format.Middle), labelStyle);
            }
         }

         if (PanelScript.ShowLabelIcons)
         {
            var icon = this.HasChildren ? Content.IconFolder : Content.IconScript;

            rect.width = 16;
            rect.height = 16;

            GUI.Label(rect, icon, GUIStyle.none);
         }
      }

      private void DrawColumnScene(Rect rect)
      {
         if (this.HasVisibleChildren || string.IsNullOrEmpty(this.SceneName))
         {
            return;
         }

         var e = Event.current;
         var labelStyle = this.Selected ? Style.TextLabelSelected : Style.TextLabel;

         if (e.type == EventType.MouseDown)
         {
            this.ClickCount = Event.current.clickCount;
         }

         if (e.modifiers == EventModifiers.Alt)
         {
            if (GUI.Button(rect, Ellipsis.Compact(this.SceneName, labelStyle, rect, Ellipsis.Format.Middle), labelStyle))
            {
               this.CommandSceneLocate();
            }
         }
         else
         {
            GUI.Label(rect, Ellipsis.Compact(this.SceneName, labelStyle, rect, Ellipsis.Format.Middle), labelStyle);
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

         var stateButtonContent = this.SourceState == GraphInfo.State.Missing
                                     ? PanelScript.SourceStateContent.Missing
                                     : (this.SourceState == GraphInfo.State.Stale
                                           ? PanelScript.SourceStateContent.Stale
                                           : (this.SourceState == GraphInfo.State.Debug
                                                 ? PanelScript.SourceStateContent.Debug
                                                 : PanelScript.SourceStateContent.Release));

         rect.width = stateButtonContent.image.width + 2;
         rect.height = stateButtonContent.image.height + 1;

         if (e.modifiers == EventModifiers.Alt)
         {
            if (GUI.Button(rect, stateButtonContent, Style.StatusIcon))
            {
               this.CommandSourceLocate();
            }
         }
         else
         {
            GUI.Label(rect, stateButtonContent, Style.StatusIcon);
         }
      }

      private void CommandSourceRemove()
      {
         // TODO: Update the source state
         AssetDatabase.StartAssetEditing();
         uScript.Instance.RebuildScript(this.GraphPath, true);
         AssetDatabase.StopAssetEditing();
         AssetDatabase.Refresh();
      }

      // === Structures =================================================================

      // === Classes ====================================================================

      private static class Content
      {
         static Content()
         {
            CollapseAllFolders = new GUIContent("Collapse All Folders");
            CollapseFolder = new GUIContent("Collapse Folder");
            ExpandAllFolders = new GUIContent("Expand All Folders");
            ExpandFolder = new GUIContent("Expand Folder");
            LoadGraph = new GUIContent("Load Graph");
            LocateFolder = new GUIContent("Locate Folder");
            LocateGraph = new GUIContent("Locate Graph");
            LocateScene = new GUIContent("Locate Scene");
            LocateSource = new GUIContent("Locate Source");
            ReloadGraph = new GUIContent("Reload Graph");
            RemoveSource = new GUIContent("Remove Source");

            // Attempt to get the built-in folder icon
#if UNITY_3_5
            IconFolder = EditorGUIUtility.FindTexture("_Folder");
#else
            IconFolder = EditorGUIUtility.FindTexture("Folder Icon");
#endif
            IconScript = uScriptGUI.GetTexture("iconScriptFile01");
         }

         public static GUIContent CollapseFolder { get; private set; }

         public static GUIContent CollapseAllFolders { get; private set; }

         public static GUIContent ExpandFolder { get; private set; }

         public static GUIContent ExpandAllFolders { get; private set; }

         public static GUIContent LoadGraph { get; private set; }

         public static GUIContent LocateFolder { get; private set; }

         public static GUIContent LocateGraph { get; private set; }

         public static GUIContent LocateScene { get; private set; }

         public static GUIContent LocateSource { get; private set; }

         public static GUIContent ReloadGraph { get; private set; }

         public static GUIContent RemoveSource { get; private set; }

         public static Texture2D IconFolder { get; private set; }

         public static Texture2D IconScript { get; private set; }
      }

      private static class Style
      {
         static Style()
         {
            StatusIcon = new GUIStyle
            {
               border = new RectOffset(6, 6, 4, 4),
               padding = new RectOffset(1, 1, 0, 1),
               active = { background = GUI.skin.button.active.background }
            };

            Foldout = new GUIStyle("IN Foldout");

            // The "CN EntryBackEven" and "CN EntryBackOdd" styles have alternate backgrounds, but no lost-focus state
            // Some older version of Unity < 4.2 used a different style name for the Project window rows
            GUIStyle labelStyle = GUI.skin.FindStyle("PR Label");
            if (labelStyle == null)
            {
               labelStyle = "PR Row";
            }

            RowEven = new GUIStyle(labelStyle) { contentOffset = new Vector2(0, -1) };
            RowOdd = new GUIStyle(labelStyle) { contentOffset = new Vector2(0, -1) };

            TextLabel = new GUIStyle(EditorStyles.label)
            {
               border = new RectOffset(6, 6, 4, 4),
               overflow = new RectOffset(0, 0, 0, 1),
               active = { background = GUI.skin.button.active.background }
            };

            TextLabelSelected = new GUIStyle(TextLabel) { normal = { textColor = Color.white } };

            IconLabel = new GUIStyle(TextLabel) { padding = new RectOffset(18, 4, 1, 0), };

            IconLabelSelected = new GUIStyle(IconLabel) { normal = { textColor = Color.white } };
         }

         public static GUIStyle IconLabel { get; private set; }

         public static GUIStyle IconLabelSelected { get; private set; }

         public static GUIStyle TextLabel { get; private set; }

         public static GUIStyle TextLabelSelected { get; private set; }

         public static GUIStyle StatusIcon { get; private set; }

         public static GUIStyle Foldout { get; private set; }

         public static GUIStyle RowEven { get; private set; }

         public static GUIStyle RowOdd { get; private set; }
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
