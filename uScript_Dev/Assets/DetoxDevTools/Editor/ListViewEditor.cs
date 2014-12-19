// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewEditor.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ListViewEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Detox.Editor;
using Detox.Editor.GUI;
using UnityEditor;
using UnityEngine;

public class ListViewEditor : EditorWindow
{
   private static ListViewEditor editorWindow;

   public static ListViewEditor Instance
   {
      get
      {
         if (editorWindow == null)
         {
            Init();
         }

         return editorWindow;
      }
   }

   [MenuItem("uScript/Internal/ListView Editor &%l", false, 501)]
   internal static void Init()
   {
      // Get existing open window or if none, make a new one:
      editorWindow = EditorWindow.GetWindow(typeof(ListViewEditor), false, "ListView Editor") as ListViewEditor;
      if (editorWindow != null)
      {
         editorWindow.minSize = new Vector2(300, 0);
      }
   }

   internal void OnGUI()
   {
      // Clear keyboard focus from search panels and other text fields, if necessary
      if (Event.current.type == EventType.MouseUp)
      {
         if (GUIUtility.hotControl != GUIUtility.keyboardControl)
         {
            GUIUtility.keyboardControl = 0;
            editorWindow.Repaint();
         }
      }

      var panel = PanelScript.Instance;
      panel.Draw();

//      int controlID = GUIUtility.GetControlID(FocusType.Keyboard);
//
//      if (Event.current.GetTypeForControl(controlID) == EventType.KeyDown)
//      {
//         switch (Event.current.keyCode)
//         {
//            case KeyCode.KeypadEnter:
//            case KeyCode.UpArrow:
//            case KeyCode.DownArrow:
//            case KeyCode.Return:
//               Debug.Log("BLOCK 1: " + controlID.ToString() + "\n");
//               break;
////               EditorGUILayout.EndHorizontal();
////               return;
//
//            case KeyCode.RightArrow:
//            case KeyCode.LeftArrow:
//               Debug.Log("BLOCK 2: " + controlID.ToString() + "\n");
//               break;
////               if (base.hasSearchFilter)
////               {
////                 break;
////               }
////               EditorGUILayout.EndHorizontal();
////               return;
//         }
//      }

//      if (Event.current.type == EventType.Used)
//      {
//         Event e = Event.current;
//
////         Debug.Log(e.ToString());
////         Debug.Log("EVENT: " + Event.current.type.ToString() + "\n");
//
////         Debug.Log("hotControl: " + GUIUtility.hotControl.ToString() + ", keyboardControl: " + GUIUtility.keyboardControl.ToString() + "\n");
//      }
   }

   internal void OnProjectChange()
   {
      PanelScript.Instance.OnProjectChange();
   }
}
