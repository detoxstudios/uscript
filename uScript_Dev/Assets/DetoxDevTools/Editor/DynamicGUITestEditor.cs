// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicGUITestEditor.cs" company="Detox Studios, LLC">
//   Copyright 2010-2014 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the DynamicGUITestEditor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.DetoxDevTools.Editor
{
   using System.Globalization;

   using Detox.Editor;

   using UnityEditor;

   using UnityEngine;

   public class DynamicGUITestEditor : EditorWindow
   {
      private static DynamicGUITestEditor panel;

      private readonly string[] gridOptions = { "A", "B", "C", "D" };
      private int gridIndex;

      private int intField = 42;
      private float floatField = Mathf.PI;
      private string textField = "TEXT";
      private Color colorField = Color.blue;

      [MenuItem("uScript/Internal/Test Windows/Dynamic GUI Text Editor &%g", false, 300)]
      private static void Init()
      {
         panel = (DynamicGUITestEditor)GetWindow(typeof(DynamicGUITestEditor), true, "Dynamic GUI Test Editor");
         var panelSize = new Vector2(256, 224);
         panel.minSize = panelSize;
         panel.maxSize = panelSize;
      }

      private void OnGUI()
      {
         EditorGUILayout.BeginVertical();
         {
            this.gridIndex = GUILayout.SelectionGrid(this.gridIndex, this.gridOptions, 4);
      
            EditorGUILayout.Separator();

            EditorGUILayout.LabelField("Name of focused control:", "\"" + GUI.GetNameOfFocusedControl() + "\"");
            EditorGUILayout.LabelField("keyboardControl:", GUIUtility.keyboardControl.ToString(CultureInfo.InvariantCulture));
            EditorGUILayout.LabelField("hotControl:", GUIUtility.hotControl.ToString(CultureInfo.InvariantCulture));
      
            EditorGUILayout.Separator();
         
            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
               switch (this.gridIndex)
               {
                  case 0:
                     this.intField = EditorGUILayout.IntField(this.ControlName("IntField"), this.intField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_00"), this.textField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_01"), this.textField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_02"), this.textField);
                     break;

                  case 1:
                     this.floatField = EditorGUILayout.FloatField(this.ControlName("FloatField"), this.floatField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_03"), this.textField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_04"), this.textField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_05"), this.textField);
                     break;

                  case 2:
                     this.colorField = EditorGUILayout.ColorField(this.ControlName("ColorField"), this.colorField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_06"), this.textField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_07"), this.textField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_08"), this.textField);
                     break;

                  case 3:
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_09"), this.textField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_0A"), this.textField);
                     this.textField = EditorGUILayout.TextField(this.ControlName("TextField_0B"), this.textField);
                     GUILayout.Space(19);
                     break;
               }
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Separator();
         
            if (GUILayout.Button("keyboardControl = 0"))
            {
               GUIUtility.keyboardControl = 0;
            }
         }

         EditorGUILayout.EndVertical();
      }
               
      private string ControlName(string controlName)
      {
         var result = string.Format("{0}_{1}", this.gridOptions[this.gridIndex], controlName);
         GUI.SetNextControlName(result);
         return result;
      }
   }
}
