using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Detox.ScriptEditor;
using Detox.FlowChart;

//using Detox.Data.Tools;
//using System.Windows.Forms;
//using System.Linq;
//using System.Drawing;




public sealed class uScriptGUIPanelProperty : uScriptGUIPanel
{
   //
   // Singleton pattern
   //
   static readonly uScriptGUIPanelProperty _instance = new uScriptGUIPanelProperty();
   public static uScriptGUIPanelProperty Instance { get { return _instance; } }
   private uScriptGUIPanelProperty() { Init(); }


   //
   // Members specific to this panel class
   //
   Rect _svRect = new Rect();


   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "Properties";
      _size = 500;
      _region = uScriptGUI.Region.Property;
   }

   public void Update()
   {
      //
      // Called whenever member data should be updated
      //
   }

   public override void Draw()
   {
      //
      // Called during OnGUI()
      //

      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;
      ScriptEditorCtrl m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;
      bool m_CanvasDragging = uScriptInstance.m_CanvasDragging;





      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, _options);
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         {
            GUILayout.Label(_name, uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));
//            GUILayout.FlexibleSpace();
         }
         EditorGUILayout.EndHorizontal();


         if (m_CanvasDragging && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            DrawHiddenNotification();
         }
         else
         {
            // Node list
            //
            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true));
            {
               uScriptGUI.BeginColumns("Property", "Value", "Type", _scrollviewOffset, _svRect);
               {
                  m_ScriptEditorCtrl.PropertyGrid.OnPaint();
               }
               uScriptGUI.EndColumns();
            }
            EditorGUILayout.EndScrollView();

            if (Event.current.type == EventType.Repaint)
            {
               _svRect = GUILayoutUtility.GetLastRect();
            }
         }
      }
      EditorGUILayout.EndVertical();

      uScriptGUI.DefineRegion(uScriptGUI.Region.Property);
//      uScriptInstance.SetMouseRegion( uScript.MouseRegion.Properties );//, 1, 3, -4, -3 );
   }

}
