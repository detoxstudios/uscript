using UnityEngine;
using UnityEditor;
using Detox.ScriptEditor;
using Detox.Data.Tools;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Detox.FlowChart;


public class uScriptDebugInspector : EditorWindow
{
   static private uScriptDebugInspector s_Instance = null;
   static public uScriptDebugInspector Instance { get { if ( null == s_Instance ) Init( ); return s_Instance; } }

   //
   // Editor Window Initialization
   //
   [UnityEditor.MenuItem ("Tools/Detox Studios/uScript Debugger")]
   static void Init ()
   {
      s_Instance = (uScriptDebugInspector) EditorWindow.GetWindow(typeof(uScriptDebugInspector), false, "uScript Debugger");
   }



   // Unity Methods
   //
   void Awake()
   {
//      dt = 0;
   }


//   float dt;
   void Update()
   {
//      dt += Time.deltaTime;
//
//      if (dt > 0.4f)
//      {
         this.Repaint();
//      }
   }


   Vector2 _sv = Vector2.zero;

   bool _boolWindow = true;
   bool _boolMouse = true;
   bool _boolContainers = true;

   bool _boolPanels = true;
   bool _boolPanelCanvas = false;
   bool _boolPanelContent = false;
   bool _boolPanelPalette = false;
   bool _boolPanelProperty = false;
   bool _boolPanelReference = false;
   bool _boolPanelScript = false;




   void OnGUI()
   {
      EditorGUI.indentLevel = 0;
      uScript u = uScript.Instance;

      EditorGUIUtility.LookLikeInspector();

      _sv = EditorGUILayout.BeginScrollView(_sv);
      {
         _boolWindow = EditorGUILayout.Foldout(_boolWindow, "Window");
         if (_boolWindow)
         {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Rect", u.position.x + ",\t" + u.position.y + ", \t" + u.position.width + ",\t" + u.position.height);
            EditorGUI.indentLevel--;
         }

         _boolMouse = EditorGUILayout.Foldout(_boolMouse, "Mouse");
         if (_boolMouse)
         {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Event", Event.current.mousePosition.x + ",\t" + Event.current.mousePosition.y + " (" + Event.current.delta + ")");
            EditorGUILayout.LabelField("MouseMoveArgs X, Y (Button)", u.m_MouseMoveArgs.X + ",\t" + u.m_MouseMoveArgs.Y + " (" + u.m_MouseMoveArgs.Button + ")");
            EditorGUILayout.LabelField("lastMouseX, Y", uScript.lastMouseX + ",\t" + uScript.lastMouseY);
            EditorGUILayout.LabelField("deltaX, Y", uScript.deltaX + ",\t" + uScript.deltaY);
            EditorGUI.indentLevel--;
         }

         _boolContainers = EditorGUILayout.Foldout(_boolContainers, "Containers");
         if (_boolContainers)
         {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Bottom Height", uScriptGUI.ContainerBottomHeight + ",\t" + uScriptGUI._containerBottomHeight);
            EditorGUILayout.LabelField("Center Height", uScriptGUI.ContainerCenterHeight + ",\t" + uScriptGUI._containerCenterHeight);
            EditorGUILayout.LabelField("Left Width", uScriptGUI.ContainerLeftWidth + ",\t" + uScriptGUI._containerLeftWidth);
            EditorGUILayout.LabelField("Right Width", uScriptGUI.ContainerRightWidth + ",\t" + uScriptGUI._containerRightWidth);
            EditorGUI.indentLevel--;
         }

         _boolPanels = EditorGUILayout.Foldout(_boolPanels, "Panels");
         if (_boolPanels)
         {
            EditorGUI.indentLevel++;

            _boolPanelCanvas = EditorGUILayout.Foldout(_boolPanelCanvas, "Canvas");
            if (_boolPanelCanvas)
            {
               DrawPanelDetails(uScriptGUIPanelCanvas.Instance);
            }
   
            _boolPanelContent = EditorGUILayout.Foldout(_boolPanelContent, "Content");
            if (_boolPanelContent)
            {
               DrawPanelDetails(uScriptGUIPanelContent.Instance);
            }

            _boolPanelPalette = EditorGUILayout.Foldout(_boolPanelPalette, "Palette");
            if (_boolPanelPalette)
            {
               DrawPanelDetails(uScriptGUIPanelPalette.Instance);
            }
   
            _boolPanelProperty = EditorGUILayout.Foldout(_boolPanelProperty, "Property");
            if (_boolPanelProperty)
            {
               DrawPanelDetails(uScriptGUIPanelProperty.Instance);
            }
   
            _boolPanelReference = EditorGUILayout.Foldout(_boolPanelReference, "Reference");
            if (_boolPanelReference)
            {
               DrawPanelDetails(uScriptGUIPanelReference.Instance);
            }
   
            _boolPanelScript = EditorGUILayout.Foldout(_boolPanelScript, "uScript");
            if (_boolPanelScript)
            {
               DrawPanelDetails(uScriptGUIPanelScript.Instance);
            }
   
            EditorGUI.indentLevel--;
         }
   
         EditorGUILayout.Space();
      }
      EditorGUILayout.EndScrollView();
   }

   void DrawPanelDetails(uScriptGUIPanel panel)
   {
      EditorGUI.indentLevel++;
      EditorGUILayout.LabelField("Size", panel.Size + " (" + panel.PanelOrientation + ")");
      EditorGUILayout.LabelField("Rect", panel.Rect.x + ",\t" + panel.Rect.y + ",\t" + panel.Rect.width + ",\t" + panel.Rect.height);
      EditorGUI.indentLevel--;
   }
}
