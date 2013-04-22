// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios, LLC" file="GenericMenuTestEditor.cs">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Editor window for testing the performance of GenericMenu initialization.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;

using UnityEditor;

using UnityEngine;

public class GenericMenuTestEditor : EditorWindow
{
   private static GenericMenuTestEditor window;

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
         if (window == null)
         {
            Init();
         }

         return window;
      }
   }

   [MenuItem("Test/GenericMenu Test Editor")]
   private static void Init()
   {
      // Get existing open window or if none, make a new one:
      window = GetWindow(typeof(GenericMenuTestEditor), false, "Menu Test") as GenericMenuTestEditor;
      if (window != null)
      {
         window.minSize = new Vector2(320, 240);
      }
   }

   private static void GenericMenuCallback(object obj)
   {
      Debug.Log(string.Format("CLICKED: {0}\n", obj));
   }

   private void OnGUI()
   {
      if (this.clickZoneStyle == null)
      {
         this.clickZoneStyle = new GUIStyle(GUI.skin.box)
         {
            margin = new RectOffset(16, 16, 16, 16),
            normal = { textColor = EditorStyles.label.normal.textColor },
            fontStyle = FontStyle.Bold
         };
      }

      this.menuSizeA = EditorGUILayout.IntSlider("Size of Menu A", this.menuSizeA, 1, 20);
      this.menuSizeB = EditorGUILayout.IntSlider("Size of Menu B", this.menuSizeB, 1, 20);
      this.menuSizeC = EditorGUILayout.IntSlider("Size of Menu C", this.menuSizeC, 1, 20);
      
      this.shouldRebuildMenu = EditorGUILayout.Toggle("Rebuild menu each time", this.shouldRebuildMenu);

      var totalMenuSize = this.menuSizeA * this.menuSizeB * this.menuSizeC;

      GUILayout.Label(string.Format("The context menu will contain {0} items", totalMenuSize.ToString(CultureInfo.InvariantCulture)));

      GUILayout.Box(
         "\nRight-click here to\nopen the context menu".ToUpper(),
         this.clickZoneStyle,
         GUILayout.ExpandWidth(true),
         GUILayout.ExpandHeight(true));

      if (Event.current.type != EventType.Layout)
      {
         var rect = GUILayoutUtility.GetLastRect();
         
         if (Event.current.type == EventType.ContextClick && rect.Contains(Event.current.mousePosition))
         {
            GUIUtility.keyboardControl = 0;
            
            if (this.shouldRebuildMenu || this.genericMenu == null || this.genericMenu.GetItemCount() != totalMenuSize)
            {
               this.BuildMenu();
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

               this.genericMenu.AddItem(new GUIContent(text), false, GenericMenuCallback, text);
            }
         }
      }
      
      Debug.Log(string.Format("New GenericMenu contains {0} items.\n", this.genericMenu.GetItemCount().ToString(CultureInfo.InvariantCulture)));
   }
}
