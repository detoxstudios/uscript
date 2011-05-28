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

   private static GUIStyle _panelTitleDropDown;
   public static GUIStyle panelTitleDropDown { get { return _panelTitleDropDown; } }

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

   private static GUIStyle _nodeButtonLeft;
   public static GUIStyle nodeButtonLeft { get { return _nodeButtonLeft; } }

   private static GUIStyle _nodeButtonMiddle;
   public static GUIStyle nodeButtonMiddle { get { return _nodeButtonMiddle; } }

   private static GUIStyle _nodeButtonRight;
   public static GUIStyle nodeButtonRight { get { return _nodeButtonRight; } }

   private static GUIStyle _contextMenu;
   public static GUIStyle ContextMenu { get { return _contextMenu; } }

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

      /* Debug.Log("BUTTON:"
                + "\n\t name: \t\t\t\t" + _paletteButton.name
                + "\n\t alignment: \t\t\t" + _paletteButton.alignment
                + "\n\t border: \t\t\t\t" + _paletteButton.border
                + "\n\t clipping: \t\t\t" + _paletteButton.clipping
                + "\n\t contentOffset: \t" + _paletteButton.contentOffset
                + "\n\t fixedHeight: \t\t" + _paletteButton.fixedHeight
                + "\n\t font: \t\t\t\t\t" + _paletteButton.font
                + "\n\t fontSize: \t\t\t" + _paletteButton.fontSize
                + "\n\t imagePosition: \t" + _paletteButton.imagePosition
                + "\n\t lineHeight: \t\t\t" + _paletteButton.lineHeight
                + "\n\t margin: \t\t\t\t" + _paletteButton.margin
                + "\n\t overflow: \t\t\t" + _paletteButton.overflow
                + "\n\t padding: \t\t\t" + _paletteButton.padding
                + "\n\t stretchHeight: \t" + _paletteButton.stretchHeight
                + "\n\t stretchWidth: \t\t" + _paletteButton.stretchWidth
                + "\n\t wordWrap: \t\t\t" + _paletteButton.wordWrap
                ); */

      _panelBox = new GUIStyle(GUI.skin.box);
      _panelBox.padding = new RectOffset(1, 1, 1, 1);
      _panelBox.margin = new RectOffset(0, 0, 0, 0);

      _panelTitle = new GUIStyle(EditorStyles.boldLabel);
      _panelTitle.margin = new RectOffset(4, 4, 0, 0);

      _panelTitleDropDown = new GUIStyle(EditorStyles.toolbarDropDown);
      _panelTitleDropDown.font = EditorStyles.boldLabel.font;
      _panelTitleDropDown.padding = new RectOffset(6, 12, 1, 3);

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

      _nodeButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft);
      _nodeButtonLeft.alignment = TextAnchor.UpperLeft;
      _nodeButtonLeft.padding = new RectOffset( 4, 4, 2, 4 );
      _nodeButtonLeft.margin = new RectOffset( 4, 0, 0, 0 );
      _nodeButtonLeft.overflow = new RectOffset( 0, 0, 0, 2 );
      _nodeButtonLeft.fontSize = 11;

      _nodeButtonMiddle = new GUIStyle(EditorStyles.miniButtonMid);
      _nodeButtonMiddle.alignment = TextAnchor.UpperCenter;
      _nodeButtonMiddle.padding = new RectOffset( 0, 0, 2, 4 );
      _nodeButtonMiddle.margin = new RectOffset( );
      _nodeButtonMiddle.overflow = new RectOffset( 0, 0, 0, 2 );
      _nodeButtonMiddle.fontSize = 11;

      _nodeButtonRight = new GUIStyle(EditorStyles.miniButtonRight);
      _nodeButtonRight.alignment = TextAnchor.UpperCenter;
      _nodeButtonRight.fixedHeight = 19;
      _nodeButtonRight.padding = new RectOffset( 0, 0, 2, 4 );
      _nodeButtonRight.contentOffset = new Vector2(-1, 3);
      _nodeButtonRight.margin = new RectOffset( 0, 4, 0, 0 );
      _nodeButtonRight.overflow = new RectOffset( 0, 0, 0, 2 );
      _nodeButtonRight.fontSize = 11;

      _contextMenu = new GUIStyle(EditorStyles.toolbarButton);
   }
}
