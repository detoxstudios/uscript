using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Detox.ScriptEditor;
using Detox.FlowChart;

//using Detox.Data.Tools;
//using Detox.Windows.Forms;
//using System.Linq;
//using Detox.Drawing;




public sealed class uScriptGUIPanelProperty : uScriptGUIPanel
{
   //
   // Singleton pattern
   //
   static readonly uScriptGUIPanelProperty _instance = new uScriptGUIPanelProperty();
   public static uScriptGUIPanelProperty Instance { get { return _instance; } }
   private uScriptGUIPanelProperty() { Init(); }

   private int _selectedNodeCount = 0;

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
//      _size = 500;
//      _region = uScriptGUI.Region.Property;
   }

   public void Update()
   {
      //
      // Called whenever member data should be updated
      //
   }


//   AssetType assetType = AssetType.TextAsset;
//   string assetPath = string.Empty;
//   string resourcePath = string.Empty;

//   bool tmpBool = false;
//   int[] tmpArray = new int[]{};


   public override void Draw()
   {
      //
      // Called during OnGUI()
      //

      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;
      ScriptEditorCtrl m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;

      _selectedNodeCount = uScript.Instance.ScriptEditorCtrl.SelectedNodes.Length;

//      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, _options);
      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, GUILayout.Width(uScriptGUI.panelPropertiesWidth));
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label(_name, uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));
         }
         EditorGUILayout.EndHorizontal();

         if (uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            DrawHiddenNotification();
         }
         else if (_selectedNodeCount > uScript.Preferences.PropertyPanelNodeLimit)
         {
            DrawExcessiveNodesNotification();
         }
         else
         {
            // Node list
            //
            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
               uScriptGUI.BeginColumns("Property", "Value", "Type", _scrollviewOffset, _svRect);
               {
//                  resourcePath = uScriptGUI.ResourcePathField(resourcePath, ref tmpBool, false, false);
//                  assetPath = uScriptGUI.AssetPathField(assetType, assetPath, ref tmpBool, false, false);

//                  tmpArray = uScriptGUI.ArrayFoldout<int>("Int Array", tmpArray, ref tmpBool, false, false);
//                  uScriptGUI.Separator();

                  if (m_ScriptEditorCtrl != null) m_ScriptEditorCtrl.PropertyGrid.OnPaint();
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

      if (Event.current.type == EventType.Repaint)
      {
         _rect = GUILayoutUtility.GetLastRect();
      }

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Property);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Properties);
   }

   private void DrawExcessiveNodesNotification()
   {
      int limit = uScript.Preferences.PropertyPanelNodeLimit;

      string message = "The " + _name + " panel is configured to show the properties of ";
      if (limit == 1)
      {
         message += "a single selected node";
      }
      else
      {
         message += "no more than " + limit.ToString() + " selected nodes";
      }
      message += ", but there are currently " + _selectedNodeCount.ToString() + " nodes selected."
         + "\n\nThe limit can be modified via the Preferences panel, although increasing the limit "
         + "may adversely affect performance.";

      EditorGUILayout.BeginScrollView(Vector2.zero, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
      {
         GUILayout.Label(message, uScriptGUIStyle.panelMessage);
      }
      EditorGUILayout.EndScrollView();
   }

}
