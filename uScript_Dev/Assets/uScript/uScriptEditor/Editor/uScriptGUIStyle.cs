using UnityEngine;
using UnityEditor;
//using System.Collections;
//using System.Collections.Generic;

//
// This file contains a collection of custom uScript GUI styles for use with uScriptEditor
// _______________________________________________________________________________________
//

public static class uScriptGUIStyle
{
   private static GUIStyle _paletteToolbarButton;
   public static GUIStyle paletteToolbarButton { get { return _paletteToolbarButton; } }

   private static GUIStyle _paletteFoldout;
   public static GUIStyle paletteFoldout { get { return _paletteFoldout; } }

   private static GUIStyle _paletteButton;
   public static GUIStyle paletteButton { get { return _paletteButton; } }

   private static GUIStyle _panelBox;
   public static GUIStyle panelBox { get { return _panelBox; } }

   private static GUIStyle _panelTitle;
   public static GUIStyle panelTitle { get { return _panelTitle; } }

   private static GUIStyle _referenceText;
   public static GUIStyle referenceText { get { return _referenceText; } }

   private static GUIStyle _hDivider;
   public static GUIStyle hDivider { get { return _hDivider; } }

   private static GUIStyle _vDivider;
   public static GUIStyle vDivider { get { return _vDivider; } }

   private static GUIStyle _vScrollbar;
   public static GUIStyle vScrollbar { get { return _vScrollbar; } }

   private static GUIStyle _hScrollbar;
   public static GUIStyle hScrollbar { get { return _hScrollbar; } }


   public static void Init()
   {
      if (panelTitle != null)
      {
         // The styles have already been initialized
         return;
      }

//      uScriptDebug.Log("Initalizing uScriptStyles", uScriptDebug.Type.Debug);

      _paletteToolbarButton = new GUIStyle(EditorStyles.toolbarButton);
      _paletteToolbarButton.margin = new RectOffset(12, 6, 0, 0);

      _paletteFoldout = new GUIStyle(EditorStyles.foldout);
      _paletteFoldout.padding = new RectOffset(12, 4, 2, 2);
      _paletteFoldout.margin = new RectOffset(4, 4, 0, 0);

      _paletteButton = new GUIStyle(GUI.skin.button);
      _paletteButton.alignment = TextAnchor.UpperLeft;
      _paletteButton.padding = new RectOffset( 4, 4, 2, 2 );
      _paletteButton.margin = new RectOffset( 4, 4, 0, 0 );
      _paletteButton.active.textColor = UnityEngine.Color.white;

      _panelBox = new GUIStyle(GUI.skin.box);
      _panelBox.padding = new RectOffset(1, 1, 1, 1);
      _panelBox.margin = new RectOffset(0, 0, 0, 0);

      _panelTitle = new GUIStyle(EditorStyles.boldLabel);
      _panelTitle.margin = new RectOffset(4, 4, 0, 0);

      _referenceText = new GUIStyle(GUI.skin.label);
      _referenceText.wordWrap = true;
      _referenceText.stretchWidth = true;

      _hDivider = new GUIStyle(GUI.skin.box);
      _hDivider.margin = new RectOffset(0, 0, 0, 0);
      _hDivider.padding = new RectOffset(0, 0, 0, 0);
      _hDivider.border = new RectOffset(0, 0, 0, 0);
      _hDivider.normal.background = null;

      _vDivider = new GUIStyle(GUI.skin.box);
      _vDivider.margin = new RectOffset(0, 0, 0, 0);
      _vDivider.padding = new RectOffset(0, 0, 0, 0);
      _vDivider.border = new RectOffset(0, 0, 0, 0);
      _vDivider.normal.background = null;

      _vScrollbar = new GUIStyle(GUI.skin.verticalScrollbar);
      _vScrollbar.margin = new RectOffset();

      _hScrollbar = new GUIStyle(GUI.skin.horizontalScrollbar);
      _hScrollbar.margin = new RectOffset();
   }
}
