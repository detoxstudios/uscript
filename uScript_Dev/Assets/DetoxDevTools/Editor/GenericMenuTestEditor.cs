//using Detox.Drawing;
using Detox.Editor.GUI;
//using Detox.FlowChart;
using Detox.ScriptEditor;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using System.Reflection;

using UnityEngine;
using UnityEditor;

public class GenericMenuTestEditor : EditorWindow
{
   private static GenericMenuTestEditor _window;

   private GenericMenu genericMenu;
   
   private int menuSizeA = 10;
   private int menuSizeB = 10;
   private int menuSizeC = 15;
   
   private bool shouldRebuildMenu;

   private GUIStyle clickZoneStyle;

   public static GenericMenuTestEditor Instance
   {
      get
      {
         if (_window == null)
         {
            Init();
         }
         return _window;
      }
   }

   [MenuItem ("Test/GenericMenu Test Editor")]
   static void Init()
   {
      // Get existing open window or if none, make a new one:
      _window = EditorWindow.GetWindow(typeof(GenericMenuTestEditor), false, "Menu Test") as GenericMenuTestEditor;
      _window.minSize = new Vector2(320, 240);
   }
 
   void OnGUI()
   {
      if (this.clickZoneStyle == null)
      {
         this.clickZoneStyle = new GUIStyle(GUI.skin.box);
         this.clickZoneStyle.margin = new RectOffset(16, 16, 16, 16);
      }

      this.menuSizeA = EditorGUILayout.IntSlider("Size of Menu A", this.menuSizeA, 1, 20);
      this.menuSizeB = EditorGUILayout.IntSlider("Size of Menu B", this.menuSizeB, 1, 20);
      this.menuSizeC = EditorGUILayout.IntSlider("Size of Menu C", this.menuSizeC, 1, 20);
      
      this.shouldRebuildMenu = EditorGUILayout.Toggle("Rebuild menu each time", this.shouldRebuildMenu);

      var totalMenuSize = this.menuSizeA * this.menuSizeB * this.menuSizeC;
      GUILayout.Label("The context menu will contain " + totalMenuSize.ToString() + " items");
      
      GUILayout.Box("Right-click here to open the context menu".ToUpper(),
         this.clickZoneStyle, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
      
      if (Event.current.type != EventType.Layout)
      {
         Rect rect = GUILayoutUtility.GetLastRect();
         
         if (Event.current.type == EventType.ContextClick && rect.Contains(Event.current.mousePosition))
         {
            GUIUtility.keyboardControl = 0;
            
            if (this.shouldRebuildMenu || this.genericMenu == null || this.genericMenu.GetItemCount() != totalMenuSize)
            {
               BuildMenu();
            }
            
            this.genericMenu.ShowAsContext();
         }
      }
   }
   
   private void BuildMenu()
   {
      this.genericMenu = new GenericMenu();
  
      for (var menuA = 0; menuA < this.menuSizeA; menuA++)
      {
         for (var menuB = 0; menuB < this.menuSizeB; menuB++)
         {
            for (var menuC = 0; menuC < this.menuSizeC; menuC++)
            {
               var itemA = "a" + menuA.ToString("00");
               var itemB = "b" + menuB.ToString("00");
               var itemC = "c" + menuC.ToString("00");
               var text = string.Format("ITEM {0}/ITEM {1}/ITEM {2}", itemA, itemB, itemC);

               this.genericMenu.AddItem(new GUIContent(text), false, this.GenericMenuCallback, text);
            }
         }
      }
      
      Debug.Log("New GenericMenu contains " + this.genericMenu.GetItemCount().ToString() + " items.\n");
   }
 
   private void GenericMenuCallback(object obj)
   {
      Debug.Log("CLICKED: " + obj.ToString() + "\n");
   }
   
}
