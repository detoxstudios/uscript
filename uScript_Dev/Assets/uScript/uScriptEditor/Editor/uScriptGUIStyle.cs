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
   static string _currentSkin = string.Empty;
   static bool _stylesInitialized = false;

   private static GUIStyle _paletteToolbarButton;
   public static GUIStyle paletteToolbarButton { get { return _paletteToolbarButton; } }

   private static GUIStyle _paletteFoldout;
   public static GUIStyle paletteFoldout { get { return _paletteFoldout; } }

   private static GUIStyle _paletteButton;
   public static GUIStyle paletteButton { get { return _paletteButton; } }

   private static GUIStyle _panelBox;
   public static GUIStyle panelBox { get { return _panelBox; } }

   private static GUIStyle _panelHR;
   public static GUIStyle panelHR { get { return _panelHR; } }

   private static GUIStyle _panelTitle;
   public static GUIStyle panelTitle { get { return _panelTitle; } }

   private static GUIStyle _panelTitleDropDown;
   public static GUIStyle panelTitleDropDown { get { return _panelTitleDropDown; } }

   private static GUIStyle _referenceText;
   public static GUIStyle referenceText { get { return _referenceText; } }

   private static GUIStyle _columnHeader;
   public static GUIStyle columnHeader { get { return _columnHeader; } }

   public static readonly int columnHeaderHeight = 16;

   private static GUIStyle _hDivider;
   public static GUIStyle hDivider { get { return _hDivider; } }

   private static GUIStyle _vDivider;
   public static GUIStyle vDivider { get { return _vDivider; } }

   private static GUIStyle _vScrollbar;
   public static GUIStyle vScrollbar { get { return _vScrollbar; } }

   private static GUIStyle _hScrollbar;
   public static GUIStyle hScrollbar { get { return _hScrollbar; } }

   private static GUIStyle _vColumnScrollbar;
   public static GUIStyle vColumnScrollbar { get { return _vColumnScrollbar; } }

   private static GUIStyle _hColumnScrollbar;
   public static GUIStyle hColumnScrollbar { get { return _hColumnScrollbar; } }

   private static GUIStyle _columnScrollView;
   public static GUIStyle columnScrollView { get { return _columnScrollView; } }

   private static GUIStyle _nodeButtonLeft;
   public static GUIStyle nodeButtonLeft { get { return _nodeButtonLeft; } }

   private static GUIStyle _nodeButtonMiddle;
   public static GUIStyle nodeButtonMiddle { get { return _nodeButtonMiddle; } }

   private static GUIStyle _nodeButtonRight;
   public static GUIStyle nodeButtonRight { get { return _nodeButtonRight; } }

   private static GUIStyle _contextMenu;
   public static GUIStyle ContextMenu { get { return _contextMenu; } }

   private static GUIStyle _menuDropDownWindow;
   public static GUIStyle menuDropDownWindow { get { return _menuDropDownWindow; } }

   private static GUIStyle _menuDropDownButton;
   public static GUIStyle menuDropDownButton { get { return _menuDropDownButton; } }

   private static GUIStyle _menuContextWindow;
   public static GUIStyle menuContextWindow { get { return _menuContextWindow; } }

   private static GUIStyle _menuContextButton;
   public static GUIStyle menuContextButton { get { return _menuContextButton; } }

   private static GUIStyle _panelMessage;
   public static GUIStyle panelMessage { get { return _panelMessage; } }

   private static GUIStyle _panelMessageBold;
   public static GUIStyle panelMessageBold { get { return _panelMessageBold; } }

   private static GUIStyle _panelMessageError;
   public static GUIStyle panelMessageError { get { return _panelMessageError; } }

   private static GUIStyle _underline;
   public static GUIStyle underline { get { return _underline; } }

   private static GUIStyle _referenceName;
   public static GUIStyle referenceName { get { return _referenceName; } }

   private static GUIStyle _referenceInfo;
   public static GUIStyle referenceInfo { get { return _referenceInfo; } }

   private static GUIStyle _referenceDesc;
   public static GUIStyle referenceDesc { get { return _referenceDesc; } }




   static Texture2D _texture_windowMenuDropDown = null;
   static Texture2D _texture_windowMenuContext = null;

   static Texture2D _texture_underline = null;




   public static void Init()
   {
      if (_currentSkin != GUI.skin.name)
      {
         // the skin has been changed
         _currentSkin = GUI.skin.name;

         // reload all custom GUI textures to match the new skin
         string skinPath = "Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/" + _currentSkin + "_";
         _texture_windowMenuDropDown = AssetDatabase.LoadAssetAtPath(skinPath + "MenuDropDown.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _texture_windowMenuContext = AssetDatabase.LoadAssetAtPath(skinPath + "MenuContext.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _texture_underline = AssetDatabase.LoadAssetAtPath(skinPath + "Underline.png", typeof(UnityEngine.Texture2D)) as Texture2D;
      }
      else if (_stylesInitialized)
      {
         // The styles have already been initialized
         return;
      }

      _stylesInitialized = true;

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
      _panelBox.name = "panelBox";
      _panelBox.padding = new RectOffset(1, 1, 1, 1);
      _panelBox.margin = new RectOffset(0, 0, 0, 0);

      _panelHR = new GUIStyle(GUI.skin.box);
      _panelHR.name = "panelHR";
      _panelHR.padding = new RectOffset(1, 1, 1, 1);
      _panelHR.margin = new RectOffset(8, 8, 8, 6);
      _panelHR.border = new RectOffset(0, 0, 1, 1);

      _panelTitle = new GUIStyle(EditorStyles.boldLabel);
      _panelTitle.name = "panelTitle";
      _panelTitle.margin = new RectOffset(4, 4, 0, 0);

      _panelTitleDropDown = new GUIStyle(EditorStyles.toolbarDropDown);
      _panelTitleDropDown.name = "panelTitleDropDown";
      _panelTitleDropDown.font = EditorStyles.boldLabel.font;
      _panelTitleDropDown.padding = new RectOffset(6, 12, 1, 3);

      _referenceText = new GUIStyle(GUI.skin.label);
      _referenceText.name = "referenceText";
      _referenceText.wordWrap = true;
      _referenceText.stretchWidth = true;
      _referenceText.stretchHeight = true;

      _columnHeader = new GUIStyle(EditorStyles.toolbarButton);
      _columnHeader.name = "columnHeader";
      _columnHeader.normal.background = _columnHeader.onNormal.background;
      _columnHeader.fontStyle = FontStyle.Bold;
      _columnHeader.alignment = TextAnchor.MiddleLeft;
      _columnHeader.padding = new RectOffset(5, 8, 0, 0);
      _columnHeader.fixedHeight = columnHeaderHeight;
      _columnHeader.contentOffset = new Vector2(0, -1);

      _hDivider = new GUIStyle(GUI.skin.box);
      _hDivider.name = "hDivider";
      _hDivider.margin = new RectOffset(0, 0, 0, 0);
      _hDivider.padding = new RectOffset(0, 0, 0, 0);
      _hDivider.border = new RectOffset(0, 0, 0, 0);
      _hDivider.normal.background = null;

      _vDivider = new GUIStyle(GUI.skin.box);
      _vDivider.name = "vDivider";
      _vDivider.margin = new RectOffset(0, 0, 0, 0);
      _vDivider.padding = new RectOffset(0, 0, 0, 0);
      _vDivider.border = new RectOffset(0, 0, 0, 0);
      _vDivider.normal.background = null;

      _vScrollbar = new GUIStyle(GUI.skin.verticalScrollbar);
      // _vScrollbar.name = "vScrollbar";                // DO NOT RENAME
      _vScrollbar.margin = new RectOffset();

      _hScrollbar = new GUIStyle(GUI.skin.horizontalScrollbar);
      // _hScrollbar.name = "hScrollbar";                // DO NOT RENAME
      _hScrollbar.margin = new RectOffset();

      _vColumnScrollbar = new GUIStyle(_vScrollbar);
      // _vColumnScrollbar.name = "vColumnScrollbar";    // DO NOT RENAME
      _vColumnScrollbar.normal.background = _columnHeader.normal.background;
      _vColumnScrollbar.overflow = new RectOffset();

      _hColumnScrollbar = new GUIStyle(_hScrollbar);
      // _hColumnScrollbar.name = "hColumnScrollbar";    // DO NOT RENAME
      _hColumnScrollbar.fixedHeight = 0;

      _columnScrollView = new GUIStyle(GUI.skin.box);
      _columnScrollView.name = "columnScrollView";
      _columnScrollView.margin = new RectOffset(4, 4, 3, 0);

      _nodeButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft);
      _nodeButtonLeft.name = "nodeButtonLeft";
      _nodeButtonLeft.alignment = TextAnchor.UpperLeft;
      _nodeButtonLeft.padding = new RectOffset( 4, 4, 2, 4 );
      _nodeButtonLeft.margin = new RectOffset( 4, 0, 0, 0 );
      _nodeButtonLeft.overflow = new RectOffset( 0, 0, 0, 2 );
      _nodeButtonLeft.fontSize = 11;

      _nodeButtonMiddle = new GUIStyle(EditorStyles.miniButtonMid);
      _nodeButtonMiddle.name = "nodeButtonMiddle";
      _nodeButtonMiddle.alignment = TextAnchor.MiddleCenter;
      _nodeButtonMiddle.padding = new RectOffset( 0, 0, 2, 4 );
      _nodeButtonMiddle.margin = new RectOffset( 0, 0, 0, 0 );
      _nodeButtonMiddle.overflow = new RectOffset( 0, 0, 0, 2 );
      _nodeButtonMiddle.fontSize = 11;
      _nodeButtonMiddle.fixedHeight = 18;
      _nodeButtonMiddle.contentOffset = new Vector2(0, 1);

      _nodeButtonRight = new GUIStyle(EditorStyles.miniButtonRight);
      _nodeButtonRight.name = "nodeButtonRight";
      _nodeButtonRight.alignment = TextAnchor.UpperCenter;
      _nodeButtonRight.padding = new RectOffset( 0, 0, 2, 4 );
      _nodeButtonRight.margin = new RectOffset( 0, 4, 0, 0 );
      _nodeButtonRight.overflow = new RectOffset( 0, 0, 0, 2 );
      _nodeButtonRight.fontSize = 11;
      _nodeButtonRight.fixedHeight = 19;
      _nodeButtonRight.contentOffset = new Vector2(-1, 1);

      _contextMenu = new GUIStyle(EditorStyles.toolbarButton);

      _menuDropDownWindow = new GUIStyle(GUI.skin.window);
      _menuDropDownWindow.normal.background = _texture_windowMenuDropDown;
      _menuDropDownWindow.onNormal.background = _texture_windowMenuDropDown;
      _menuDropDownWindow.border = new RectOffset(10, 10, 4, 10);
      _menuDropDownWindow.padding = new RectOffset(0, 0, 0, 4);
      _menuDropDownWindow.overflow = new RectOffset(6, 6, 0, 6);
      _menuDropDownWindow.contentOffset = Vector2.zero;

      _menuDropDownButton = new GUIStyle(EditorStyles.largeLabel);
      _menuDropDownButton.name = "menuDropDownButton";
      _menuDropDownButton.active.background = EditorStyles.toolbarButton.onActive.background;
      _menuDropDownButton.hover.background = EditorStyles.toolbarButton.onNormal.background;
      _menuDropDownButton.border = EditorStyles.toolbarButton.border;
      _menuDropDownButton.margin = new RectOffset();
      _menuDropDownButton.padding = new RectOffset(8, 8, 4, 4);

      _menuContextWindow = new GUIStyle(GUI.skin.window);
      _menuContextWindow.normal.background = _texture_windowMenuContext;
      _menuContextWindow.onNormal.background = _texture_windowMenuContext;
      _menuContextWindow.border = new RectOffset(10, 10, 10, 10);
      _menuContextWindow.padding = new RectOffset(0, 0, 4, 4);
      _menuContextWindow.overflow = new RectOffset(6, 6, 6, 6);
      _menuContextWindow.contentOffset = Vector2.zero;

      _menuContextButton = new GUIStyle(EditorStyles.largeLabel);
      _menuContextButton.name = "menuDropDownButton";
      _menuContextButton.active.background = EditorStyles.toolbarButton.onActive.background;
      _menuContextButton.hover.background = EditorStyles.toolbarButton.onNormal.background;
      _menuContextButton.border = EditorStyles.toolbarButton.border;
      _menuContextButton.margin = new RectOffset();
      _menuContextButton.padding = new RectOffset(8, 8, 4, 4);

      _panelMessage = new GUIStyle(GUI.skin.label);
      _panelMessage.wordWrap = true;
      _panelMessage.padding = new RectOffset(16, 16, 16, 16);

      _panelMessageBold = new GUIStyle(EditorStyles.boldLabel);
      _panelMessageBold.alignment = TextAnchor.MiddleCenter;
      _panelMessageBold.wordWrap = true;
      _panelMessageBold.padding = new RectOffset(16, 16, 16, 16);

      _panelMessageError = new GUIStyle(GUI.skin.box);
      _panelMessageError.normal.textColor = EditorStyles.boldLabel.normal.textColor;
      _panelMessageError.font = EditorStyles.boldLabel.font;
      _panelMessageError.wordWrap = true;
      _panelMessageError.stretchWidth = true;

      _underline = new GUIStyle(EditorStyles.boldLabel);
      _underline.normal.background = _texture_underline;
      _underline.border = new RectOffset(0, 0, 0, 2);
      _underline.padding = new RectOffset(0, 0, 2, 2);

      _referenceName = new GUIStyle(EditorStyles.boldLabel);
      _referenceName.name = "referenceName";
      _referenceName.normal.background = _texture_underline;
      _referenceName.border = new RectOffset(0, 0, 0, 2);
      _referenceName.padding = new RectOffset(0, 0, 2, 2);

      _referenceInfo = new GUIStyle(EditorStyles.miniLabel);
      _referenceInfo.name = "referenceInfo";
      _referenceInfo.alignment = TextAnchor.LowerRight;
      _referenceInfo.padding = new RectOffset(0, 0, 3, 2);

      _referenceDesc = new GUIStyle(EditorStyles.label);
      _referenceDesc.name = "referenceDesc";
      _referenceDesc.padding = new RectOffset(0, 0, 0, 3);
      _referenceDesc.stretchHeight = false;
      _referenceDesc.stretchWidth = true;
      _referenceDesc.wordWrap = true;

//      uScriptGUIStyle.Information(underline);
   }


   static public void Information(GUIStyle style)
   {
      Debug.Log(style.name + ":"
                + "\n\t margin: \t\t\t\t" + style.margin
                + "\t\t alignment: \t\t\t" + style.alignment

                + "\n\t padding: \t\t\t" + style.padding
                + "\t\t font: \t\t\t\t\t" + style.font

                + "\n\t fixedHeight: \t\t" + style.fixedHeight
                + "\t\t\t\t\t\t\t\t\t\t fontSize: \t\t\t" + style.fontSize

                + "\n\t fixedWidth: \t\t" + style.fixedWidth
                + "\t\t\t\t\t\t\t\t\t\t fontStyle: \t\t\t" + style.fontStyle

                + "\n\t stretchHeight: \t" + style.stretchHeight
                + "\t\t\t\t\t\t\t\t\t imagePosition: \t" + style.imagePosition

                + "\n\t stretchWidth: \t\t" + style.stretchWidth
                + "\t\t\t\t\t\t\t\t\t lineHeight: \t\t\t" + style.lineHeight

                + "\n\t border: \t\t\t\t" + style.border
                + "\t\t wordWrap: \t\t\t" + style.wordWrap

                + "\n\t overflow: \t\t\t" + style.overflow
                + "\n\t clipping: \t\t\t" + style.clipping
                + "\n\t contentOffset: \t" + style.contentOffset

                + "\n\t isHeightDependantOnWidth: \t\t\t" + style.isHeightDependantOnWidth
                + "\n"
               );
   }

}
