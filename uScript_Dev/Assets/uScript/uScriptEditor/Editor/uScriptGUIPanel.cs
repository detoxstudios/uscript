using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Detox.ScriptEditor;
using Detox.FlowChart;


public abstract class uScriptGUIPanel
{
/*
      // every panel has the following
      //
      uScriptGUI.PanelType _type;

//      string _title;

      protected Rect _panelPosition;

      protected Rect _toolbarPosition;
      protected List<ControlData> _toolbarControls;

      protected Rect _scrollviewPosition;
      Vector2 _scrollviewOffset;

      Rect _contentPosition;
      List<ControlData> _contentControls;

      public uScriptGUI.PanelType Type { get { return _type; } }

//      public string Title { get { return _title; } }

      public Rect PanelPosition { get { return _panelPosition; } }
      public Rect ToolbarPosition { get { return _toolbarPosition; } }
      public Rect ScrollviewPosition { get { return _scrollviewPosition; } }
      public Vector2 ScrollviewOffset { get { return _scrollviewOffset; } set { _scrollviewOffset = value; } }
      public Rect ContentPosition { get { return _contentPosition; } set { _contentPosition = value; } }


//      public int Width { get { return (int)_position.width; } }
//
//      public int Height { get { return (int)_position.height; } }

      protected List<ControlData> ToolbarControls { get { return _toolbarControls; } }
      protected List<ControlData> ContentControls { get { return _contentControls; } }



      public uScriptGUIPanel(uScriptGUI.PanelType type)
      {
         _type = type;

      //temp
      Rect position = new Rect();
         _panelPosition = position;

         _toolbarPosition = new Rect(1, 1, position.width-2, 40);
         _toolbarControls = new List<ControlData>();

         _scrollviewPosition = new Rect(_toolbarPosition.x,
                                        _toolbarPosition.y + _toolbarPosition.height,
                                        _toolbarPosition.width,
                                        _panelPosition.height - _toolbarPosition.y - _toolbarPosition.height - 1);
         _scrollviewOffset = Vector2.zero;

         _contentPosition = new Rect();
         _contentControls = new List<ControlData>();
      }

//      public int ResizeWidthByDelta(int delta) { return ResizeWidth(Width + delta); }
//      public int ResizeWidth(int width)
//      {
//         return -1;
//      }
//
//      public int ResizeHeightByDelta(int delta) { return ResizeHeight(Height + delta); }
//      public int ResizeHeight(int height)
//      {
//         return -1;
//      }

   protected class ControlData
   {
      public string type;
      public string name;
      public Rect rect;
      public GUIContent content;
//      public Object param;

      public ControlData(string type, string name, Rect rect, GUIContent content)
      {
         this.type = type;
         this.name = name;
         this.rect = rect;
         this.content = content;
      }
   }


   public abstract void Init();

   public abstract void Update();

*/





   //
   // Members common to all panels
   //
   protected string _name;
   protected Vector2 _scrollviewOffset;

//   protected uScriptGUI.Region _region;
//   public uScriptGUI.Region Region { get { return _region; } }

   protected Rect _rect;
   
//   protected int _size;
//   public int Size
//   {
//      get { return _size; }
//      set
//      {
//         if (_size != value)
//         {
//            _size = value;
//            // @TODO - Save the new value in preferences
//            UpdatePanelLayoutOptions();
//         }
//      }
//   }


   protected GUILayoutOption[] _options = new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) };

//   private uScriptGUI.FixedPanelSize _orientation = uScriptGUI.FixedPanelSize.None;
//   public uScriptGUI.FixedPanelSize PanelOrientation
//   {
//      get { return _orientation; }
//      set
//      {
//         if (_orientation != value)
//         {
//            _orientation = value;
//            UpdatePanelLayoutOptions();
//         }
//      }
//   }

//   private void UpdatePanelLayoutOptions()
//   {
//      switch (_orientation)
//      {
//         case uScriptGUI.FixedPanelSize.Horizontal:
//            _options = new GUILayoutOption[] { GUILayout.MaxWidth(_size), GUILayout.ExpandWidth(true) };
//            break;
//         case uScriptGUI.FixedPanelSize.Vertical:
//            _options = new GUILayoutOption[] { GUILayout.MaxHeight(_size), GUILayout.ExpandHeight(true) };
//            break;
//         default:
//            _options = new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) };
//            break;
//      }
//   }


   //
   // Methods common to all panels
   //
   public abstract void Draw();

   protected void DrawHiddenNotification()
   {
      // Hide the panels while the canvas is moving
      string message =
         "The " + _name + " panel is not drawn while the canvas is updated.\n\nThe drawing can be enabled via the Preferences panel, although canvas performance may be affected.";

      GUIStyle style = new GUIStyle(GUI.skin.label);
      style.wordWrap = true;
      style.padding = new RectOffset(16, 16, 16, 16);

      EditorGUILayout.BeginScrollView(Vector2.zero, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
      {
         GUILayout.Label(message, style);
      }
      EditorGUILayout.EndScrollView();
   }

//   protected void SetPanelOptions(uScriptGUI.FixedPanelSize orientation)
//   {
//   }

}
