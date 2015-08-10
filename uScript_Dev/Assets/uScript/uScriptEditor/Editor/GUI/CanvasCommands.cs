// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CanvasCommands.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the CanvasCommands type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System;
   using System.Collections.Generic;

   using Detox.Windows.Forms;

   using UnityEditor;

   using UnityEngine;

   public static class CanvasCommands
   {
      private static readonly Dictionary<int, Action> Commands = new Dictionary<int, Action>();

      static CanvasCommands()
      {
         Add(Keys.None, KeyCode.F1, Command.OpenWebDocumentation);
         Add(Keys.None, KeyCode.Backspace, Command.DeleteSelectedNodes);
         Add(Keys.None, KeyCode.Delete, Command.DeleteSelectedNodes);
         Add(Keys.None, KeyCode.Greater, Command.ExpandSelectedNodes);
         Add(Keys.None, KeyCode.Less, Command.CollapseSelectedNodes);
         Add(Keys.None, KeyCode.Escape, Command.DeselectAll);
         Add(Keys.None, KeyCode.Home, Command.LocateGraphOrigin);
         Add(Keys.None, KeyCode.LeftBracket, Command.LocatePreviousEvent);
         Add(Keys.None, KeyCode.RightBracket, Command.LocateNextEvent);
         Add(Keys.None, KeyCode.BackQuote, Command.TogglePanels);
         Add(Keys.None, KeyCode.Backslash, Command.TogglePanels);
         Add(Keys.None, KeyCode.Minus, Command.ZoomOut);
         Add(Keys.None, KeyCode.KeypadMinus, Command.ZoomOut);
         Add(Keys.None, KeyCode.Equals, Command.ZoomIn);
         Add(Keys.None, KeyCode.Plus, Command.ZoomIn);
         Add(Keys.None, KeyCode.KeypadPlus, Command.ZoomIn);
         Add(Keys.None, KeyCode.Alpha0, Command.ZoomReset);

         Add(Keys.Control, KeyCode.F, Command.OpenFileMenu);
         Add(Keys.Control, KeyCode.G, Command.ToggleGrid);
         Add(Keys.Control, KeyCode.H, Command.LocateGraphOrigin);
         Add(Keys.Control, KeyCode.W, Command.CloseEditorWindow);

         Add(Keys.Alt, KeyCode.Greater, Command.ExpandAllNodes);
         Add(Keys.Alt, KeyCode.Less, Command.CollapseAllNodes);
         Add(Keys.Alt, KeyCode.End, Command.SnapSelectedNodesToGrid);
         Add(Keys.Alt, KeyCode.A, Command.SaveGraphAs);
         Add(Keys.Alt, KeyCode.D, Command.SaveGraphDebug);
         Add(Keys.Alt, KeyCode.E, Command.ExportGraphToImage);
         Add(Keys.Alt, KeyCode.F, Command.OpenFileMenu);
         Add(Keys.Alt, KeyCode.G, Command.ToggleGridSnapping);
         Add(Keys.Alt, KeyCode.N, Command.NewGraph);
         Add(Keys.Alt, KeyCode.O, Command.OpenGraph);
         Add(Keys.Alt, KeyCode.Q, Command.SaveGraphQuick);
         Add(Keys.Alt, KeyCode.R, Command.SaveGraphRelease);
         Add(Keys.Alt, KeyCode.S, Command.SaveGraph);

         Add(Keys.Shift, KeyCode.Period, Command.ExpandSelectedNodes);
         Add(Keys.Shift, KeyCode.Comma, Command.CollapseSelectedNodes);
         Add(Keys.Shift, KeyCode.BackQuote, Command.TogglePanels);
         Add(Keys.Shift, KeyCode.Minus, Command.ZoomOut);
         Add(Keys.Shift, KeyCode.Equals, Command.ZoomIn);

         Add(Keys.AltShift, KeyCode.Period, Command.ExpandAllNodes);
         Add(Keys.AltShift, KeyCode.Comma, Command.CollapseAllNodes);

         Add(KeyCode.S, MouseButtons.Left, Command.PlaceOnCanvasString);
         Add(KeyCode.V, MouseButtons.Left, Command.PlaceOnCanvasVector3);
         Add(KeyCode.I, MouseButtons.Left, Command.PlaceOnCanvasInt);
         Add(KeyCode.F, MouseButtons.Left, Command.PlaceOnCanvasFloat);
         Add(KeyCode.B, MouseButtons.Left, Command.PlaceOnCanvasBool);
         Add(KeyCode.G, MouseButtons.Left, Command.PlaceOnCanvasGameObject);
         Add(KeyCode.O, MouseButtons.Left, Command.PlaceOnCanvasOwnerConnection);
         Add(KeyCode.C, MouseButtons.Left, Command.PlaceOnCanvasComment);
         Add(KeyCode.E, MouseButtons.Left, Command.PlaceOnCanvasExternalConnection);
         Add(KeyCode.L, MouseButtons.Left, Command.PlaceOnCanvasLog);
         Add(KeyCode.Alpha1, MouseButtons.Left, Command.PlaceOnCanvasFavorite1);
         Add(KeyCode.Alpha2, MouseButtons.Left, Command.PlaceOnCanvasFavorite2);
         Add(KeyCode.Alpha3, MouseButtons.Left, Command.PlaceOnCanvasFavorite3);
         Add(KeyCode.Alpha4, MouseButtons.Left, Command.PlaceOnCanvasFavorite4);
         Add(KeyCode.Alpha5, MouseButtons.Left, Command.PlaceOnCanvasFavorite5);
         Add(KeyCode.Alpha6, MouseButtons.Left, Command.PlaceOnCanvasFavorite6);
         Add(KeyCode.Alpha7, MouseButtons.Left, Command.PlaceOnCanvasFavorite7);
         Add(KeyCode.Alpha8, MouseButtons.Left, Command.PlaceOnCanvasFavorite8);
         Add(KeyCode.Alpha9, MouseButtons.Left, Command.PlaceOnCanvasFavorite9);
      }

      /// <summary>
      /// Add a command the user can invoke via the keyboard.
      /// </summary>
      /// <param name="modifiers">The modifier value.</param>
      /// <param name="keyCode">The key code.</param>
      /// <param name="action">The action should be a static method, not an instance method.</param>
      public static void Add(int modifiers, KeyCode keyCode, Action action)
      {
         Add(modifiers, keyCode, MouseButtons.None, action);
      }

      /// <summary>
      /// Add a command the user can invoke via the keyboard and mouse.
      /// </summary>
      /// <param name="keyCode">The key code.</param>
      /// <param name="button">The mouse button value.</param>
      /// <param name="action">The action should be a static method, not an instance method.</param>
      public static void Add(KeyCode keyCode, int button, Action action)
      {
         Add(Keys.None, keyCode, button, action);
      }

      /// <summary>
      /// Add a command the user can invoke via the keyboard and mouse.
      /// </summary>
      /// <param name="modifiers">The modifier value.</param>
      /// <param name="keyCode">The key code.</param>
      /// <param name="button">The mouse button value.</param>
      /// <param name="action">The action should be a static method, not an instance method.</param>
      public static void Add(int modifiers, KeyCode keyCode, int button, Action action)
      {
         var hashCode = GetHashCode(modifiers, keyCode, button);
         if (Commands.ContainsKey(hashCode))
         {
            uScriptDebug.Log("Canvas command is already defined.", uScriptDebug.Type.Error);
         }
         else
         {
            Commands.Add(hashCode, action);
         }
      }

      public static bool Contains(
         int modifiers = Keys.None,
         KeyCode keyCode = KeyCode.None,
         int button = MouseButtons.None)
      {
         if (button == MouseButtons.Any)
         {
            return Commands.ContainsKey(GetHashCode(modifiers, keyCode))
                   || Commands.ContainsKey(GetHashCode(modifiers, keyCode, MouseButtons.Left))
                   || Commands.ContainsKey(GetHashCode(modifiers, keyCode, MouseButtons.Middle))
                   || Commands.ContainsKey(GetHashCode(modifiers, keyCode, MouseButtons.Right));
         }

         return Commands.ContainsKey(GetHashCode(modifiers, keyCode, button));
      }

      public static bool Invoke(
         int modifiers = Keys.None,
         KeyCode keyCode = KeyCode.None,
         int button = MouseButtons.None)
      {
         Action action;
         if (Commands.TryGetValue(GetHashCode(modifiers, keyCode, button), out action))
         {
            action();
            return true;
         }

         return false;
      }

      /// <summary>
      /// Try to get the action associated with the specified combination of user input.
      /// </summary>
      /// <param name="action">The action, if found.</param>
      /// <param name="modifiers">The modifier value (Keys constant).</param>
      /// <param name="keyCode">The KeyCode value.</param>
      /// <param name="button">The button value (MouseButtons constant).</param>
      /// <returns>Returns True when the action is found, otherwise False.</returns>
      public static bool TryGetAction(
         out Action action,
         int modifiers = Keys.None,
         KeyCode keyCode = KeyCode.None,
         int button = MouseButtons.None)
      {
         return Commands.TryGetValue(GetHashCode(modifiers, keyCode, button), out action);
      }

      private static int GetHashCode(
         int modifiers = Keys.None,
         KeyCode keyCode = KeyCode.None,
         int button = MouseButtons.None)
      {
         // keycode:       [9 bits]   0-509 (as of Unity 5.1)
         // MouseButtons:  [3 bits]   0, 1 (left), 2 (middle), 4 (right)
         // Keys:          [3 bits]   0, 1 (ctrl), 2 (alt), 3, 4 (shift), 5, 6, 7
         return (button << 16) + (modifiers << 12) + (int)keyCode;
      }

      public static class Command
      {
         public static void CloseEditorWindow()
         {
            uScript.CloseEditorWindow();
         }

         public static void CollapseAllNodes()
         {
            uScript.Instance.ScriptEditorCtrl.CollapseAllNodes();
         }

         public static void CollapseSelectedNodes()
         {
            uScript.Instance.ScriptEditorCtrl.CollapseSelectedNodes();
         }

         public static void DeleteSelectedNodes()
         {
            uScript.Instance.ScriptEditorCtrl.DeleteSelectedNodes();
         }

         public static void DeselectAll()
         {
            uScript.Instance.ScriptEditorCtrl.DeselectAll();
         }

         public static void ExpandAllNodes()
         {
            uScript.Instance.ScriptEditorCtrl.ExpandAllNodes();
         }

         public static void ExpandSelectedNodes()
         {
            uScript.Instance.ScriptEditorCtrl.ExpandSelectedNodes();
         }

         public static void ExportGraphToImage()
         {
            uScript.FileMenuItem_ExportPNG();
         }

         public static void LocateGraphOrigin()
         {
            uScript.CommandCanvasLocateOrigin();
         }

         public static void LocateNextEvent()
         {
            uScript.Instance.CommandCanvasLocateNextEvent();
         }

         public static void LocatePreviousEvent()
         {
            uScript.Instance.CommandCanvasLocatePreviousEvent();
         }

         public static void NewGraph()
         {
            uScript.FileMenuItem_New();
         }

         public static void OpenFileMenu()
         {
            // TODO: Open the file menu here
            //this.ContextMenuFile(toolbarRect);
         }

         public static void OpenGraph()
         {
            uScript.FileMenuItem_Open();
         }

         public static void OpenWebDocumentation()
         {
            Help.BrowseURL("http://docs.uscript.net/");
         }

         public static void PlaceOnCanvasBool()
         {
            uScript.Instance.PlaceNodeOnCanvas("bool", true);
         }

         public static void PlaceOnCanvasComment()
         {
            uScript.Instance.PlaceNodeOnCanvas("CommentNode", true);
         }

         public static void PlaceOnCanvasExternalConnection()
         {
            uScript.Instance.PlaceNodeOnCanvas("ExternalConnection", true);
         }

         public static void PlaceOnCanvasFavorite1()
         {
            uScript.Instance.PlaceNodeOnCanvas(uScript.Preferences.FavoriteNode1, true);
         }

         public static void PlaceOnCanvasFavorite2()
         {
            uScript.Instance.PlaceNodeOnCanvas(uScript.Preferences.FavoriteNode2, true);
         }

         public static void PlaceOnCanvasFavorite3()
         {
            uScript.Instance.PlaceNodeOnCanvas(uScript.Preferences.FavoriteNode3, true);
         }

         public static void PlaceOnCanvasFavorite4()
         {
            uScript.Instance.PlaceNodeOnCanvas(uScript.Preferences.FavoriteNode4, true);
         }

         public static void PlaceOnCanvasFavorite5()
         {
            uScript.Instance.PlaceNodeOnCanvas(uScript.Preferences.FavoriteNode5, true);
         }

         public static void PlaceOnCanvasFavorite6()
         {
            uScript.Instance.PlaceNodeOnCanvas(uScript.Preferences.FavoriteNode6, true);
         }

         public static void PlaceOnCanvasFavorite7()
         {
            uScript.Instance.PlaceNodeOnCanvas(uScript.Preferences.FavoriteNode7, true);
         }

         public static void PlaceOnCanvasFavorite8()
         {
            uScript.Instance.PlaceNodeOnCanvas(uScript.Preferences.FavoriteNode8, true);
         }

         public static void PlaceOnCanvasFavorite9()
         {
            uScript.Instance.PlaceNodeOnCanvas(uScript.Preferences.FavoriteNode9, true);
         }

         public static void PlaceOnCanvasFloat()
         {
            uScript.Instance.PlaceNodeOnCanvas("float", true);
         }

         public static void PlaceOnCanvasGameObject()
         {
            uScript.Instance.PlaceNodeOnCanvas("UnityEngine.GameObject", true);
         }

         public static void PlaceOnCanvasInt()
         {
            uScript.Instance.PlaceNodeOnCanvas("int", true);
         }

         public static void PlaceOnCanvasLog()
         {
            uScript.Instance.PlaceNodeOnCanvas("uScriptAct_Log", true);
         }

         public static void PlaceOnCanvasOwnerConnection()
         {
            uScript.Instance.PlaceNodeOnCanvas("OwnerConnection", true);
         }

         public static void PlaceOnCanvasString()
         {
            uScript.Instance.PlaceNodeOnCanvas("string", true);
         }

         public static void PlaceOnCanvasVector3()
         {
            uScript.Instance.PlaceNodeOnCanvas("UnityEngine.Vector3", true);
         }

         public static void SaveGraph()
         {
            uScript.FileMenuItem_Save();
         }

         public static void SaveGraphAs()
         {
            uScript.FileMenuItem_SaveAs();
         }

         public static void SaveGraphDebug()
         {
            uScript.FileMenuItem_DebugSave();
         }

         public static void SaveGraphQuick()
         {
            uScript.FileMenuItem_QuickSave();
         }

         public static void SaveGraphRelease()
         {
            uScript.FileMenuItem_ReleaseSave();
         }

         public static void SnapSelectedNodesToGrid()
         {
            uScript.Instance.ScriptEditorCtrl.FlowChart.SnapSelectedNodesToGrid();
         }

         public static void ToggleGrid()
         {
            uScript.CommandViewMenuGrid();
         }

         public static void ToggleGridSnapping()
         {
            uScript.CommandViewMenuSnap();
         }

         public static void TogglePanels()
         {
            uScript.Instance.CommandCanvasShowPanels();
         }

         public static void ZoomIn()
         {
            uScript.Instance.CommandCanvasZoomIn();
         }

         public static void ZoomOut()
         {
            uScript.Instance.CommandCanvasZoomOut();
         }

         public static void ZoomReset()
         {
            uScript.Instance.CommandCanvasZoomReset();
         }
      }
   }
}
