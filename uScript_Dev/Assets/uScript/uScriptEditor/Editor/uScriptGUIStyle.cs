using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

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

   public static GUIStyle menuDropDownButtonShortcut { get; private set; }

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
   
   public static GUIStyle referenceButtonIcon { get; private set; }
   public static GUIStyle referenceButtonText { get; private set; }
 
   public static GUIStyle referenceDetailBox { get; private set; }
   public static GUIStyle referenceDetailTitle { get; private set; }
   public static GUIStyle referenceDetailLabel { get; private set; }
   public static GUIStyle referenceDetailValue { get; private set; }
   public static GUIStyle referenceDetailAlertLabel { get; private set; }
   public static GUIStyle referenceDetailAlertValue { get; private set; }
   
   private static GUIStyle _propertyRowOdd;
   public static GUIStyle propertyRowOdd { get { return _propertyRowOdd; } }

   private static GUIStyle _propertyRowEven;
   public static GUIStyle propertyRowEven { get { return _propertyRowEven; } }

   private static GUIStyle _propertyTextField;
   public static GUIStyle propertyTextField { get { return _propertyTextField; } }

   private static GUIStyle _propertyBoolField;
   public static GUIStyle propertyBoolField { get { return _propertyBoolField; } }

   private static GUIStyle _propertyArrayIconButton;
   public static GUIStyle propertyArrayIconButton { get { return _propertyArrayIconButton; } }

   private static GUIStyle _propertyArrayTextButton;
   public static GUIStyle propertyArrayTextButton { get { return _propertyArrayTextButton; } }

   private static GUIStyle _scriptRowOdd;
   public static GUIStyle scriptRowOdd { get { return _scriptRowOdd; } }

   private static GUIStyle _scriptRowEven;
   public static GUIStyle scriptRowEven { get { return _scriptRowEven; } }

   private static GUIStyle _listRow;
   public static GUIStyle listRow { get { return _listRow; } }

   private static GUIStyle _toolbarLabel;
   public static GUIStyle toolbarLabel { get { return _toolbarLabel; } }

   static Texture2D _texture_propertyRowEven = null;

   static Texture2D _texture_windowMenuDropDown = null;
   static Texture2D _texture_windowMenuContext = null;

   static Texture2D _texture_underline = null;




   public static void Init()
   {
      if (_stylesInitialized && _currentSkin == GUI.skin.name)
      {
         // The styles have already been initialized
         return;
      }

      if (_currentSkin != GUI.skin.name)
      {
         // the skin has been changed
         _currentSkin = GUI.skin.name;

         // the skin names were different in pre-3.5 Unity builds, so override if necessary
         if (_currentSkin == "SceneGUISkin")
         {
            _currentSkin = "DarkSkin";
         }
         else if (_currentSkin == "InspectorGUISkin")
         {
            _currentSkin = "LightSkin";
         }

         // reload all custom GUI textures to match the new skin
         string skinPath = "Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/" + _currentSkin + "_";
         _texture_windowMenuDropDown = AssetDatabase.LoadAssetAtPath(skinPath + "MenuDropDown.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _texture_windowMenuContext = AssetDatabase.LoadAssetAtPath(skinPath + "MenuContext.png", typeof(UnityEngine.Texture2D)) as UnityEngine.Texture2D;
         _texture_underline = AssetDatabase.LoadAssetAtPath(skinPath + "Underline.png", typeof(UnityEngine.Texture2D)) as Texture2D;
         _texture_propertyRowEven = AssetDatabase.LoadAssetAtPath(skinPath + "LineItem.png", typeof(UnityEngine.Texture2D)) as Texture2D;

         // update the current skin again to replace any overridden skin name from pre-3.5 Unity builds.
         _currentSkin = GUI.skin.name;
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

      menuDropDownButtonShortcut = new GUIStyle(EditorStyles.largeLabel);
      menuDropDownButtonShortcut.name = "menuDropDownButtonShortcut";
      menuDropDownButtonShortcut.fontStyle = FontStyle.Bold;
      menuDropDownButtonShortcut.margin = new RectOffset();
      menuDropDownButtonShortcut.padding = new RectOffset();

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

      referenceButtonIcon = new GUIStyle(EditorStyles.miniButton);
      referenceButtonIcon.name = "uScript_referenceButtonIcon";
      referenceButtonIcon.alignment = TextAnchor.MiddleCenter;
      referenceButtonIcon.imagePosition = ImagePosition.ImageOnly;
      referenceButtonIcon.padding = new RectOffset();
      referenceButtonIcon.margin = new RectOffset( 4, 4, 0, 0 );
      referenceButtonIcon.fixedHeight = 20;
      referenceButtonIcon.fixedWidth = 20;

      referenceButtonText = new GUIStyle(EditorStyles.miniButton);
      referenceButtonText.name = "uScript_referenceButtonText";
      referenceButtonText.alignment = TextAnchor.MiddleCenter;
      referenceButtonText.padding = new RectOffset( 3, 6, 2, 4 );
      referenceButtonText.margin = new RectOffset( 4, 4, 0, 0 );
      referenceButtonText.fontSize = 11;
      referenceButtonText.fixedHeight = 20;
  
      referenceDetailBox = new GUIStyle(GUI.skin.box);
      referenceDetailBox.name = "uScript_referenceDetailBox";
      referenceDetailBox.margin = new RectOffset(24, 24, 16, 16);
      referenceDetailBox.padding = new RectOffset(4, 4, 4, 4);

      referenceDetailTitle = new GUIStyle(EditorStyles.boldLabel);
      referenceDetailTitle.name = "uScript_referenceDetailTitle";
      referenceDetailTitle.margin = EditorStyles.label.margin;
      referenceDetailTitle.margin = new RectOffset(0, 12, 0, 0);
      referenceDetailTitle.padding = new RectOffset(2, 2, 2, 3);
      referenceDetailTitle.stretchWidth = false;
//      referenceDetailTitle.normal.background = GUI.skin.box.normal.background;
//      referenceDetailTitle.border = GUI.skin.box.border;

      referenceDetailLabel = new GUIStyle(EditorStyles.boldLabel);
      referenceDetailLabel.name = "uScript_referenceDetailLabel";
      referenceDetailLabel.margin = new RectOffset();
      referenceDetailLabel.padding = new RectOffset(2, 2, 2, 3);
      referenceDetailLabel.stretchWidth = false;
//      referenceDetailLabel.normal.background = GUI.skin.box.normal.background;
//      referenceDetailLabel.border = GUI.skin.box.border;

      referenceDetailValue = new GUIStyle(referenceDetailLabel);
      referenceDetailValue.name = "uScript_referenceDetailValue";
      referenceDetailValue.alignment = TextAnchor.MiddleRight;

      referenceDetailAlertLabel = new GUIStyle(EditorStyles.boldLabel);
      referenceDetailAlertLabel.name = "uScript_referenceDetailAlertLabel";
      referenceDetailAlertLabel.margin = new RectOffset();
      referenceDetailAlertLabel.padding = new RectOffset(2, 2, 2, 3);
      referenceDetailAlertLabel.normal.textColor = Color.red;
      referenceDetailAlertLabel.wordWrap = true;
//      referenceDetailAlertLabel.normal.background = GUI.skin.box.normal.background;
//      referenceDetailAlertLabel.border = GUI.skin.box.border;

      referenceDetailAlertValue = new GUIStyle(referenceDetailAlertLabel);
      referenceDetailAlertValue.name = "uScript_referenceDetailAlertValue";
      referenceDetailAlertValue.alignment = TextAnchor.MiddleRight;

      
      
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

      _propertyTextField = new GUIStyle(EditorStyles.textField);
      _propertyTextField.margin = new RectOffset(4, 4, 2, 2);

      _propertyBoolField = new GUIStyle(EditorStyles.toggle);
      _propertyBoolField.margin = new RectOffset(4, 4, 1, 1);

      _propertyArrayIconButton = new GUIStyle(EditorStyles.miniButton);
      _propertyArrayIconButton.margin = new RectOffset(4, 4, 2, 2);
      _propertyArrayIconButton.padding = new RectOffset(3, 3, 2, 2);
      _propertyArrayIconButton.stretchWidth = false;

      _propertyArrayTextButton = new GUIStyle(EditorStyles.miniButton);
      _propertyArrayTextButton.fontStyle = FontStyle.Bold;
      _propertyArrayTextButton.padding = new RectOffset(0, 2, 1, 1);
      _propertyArrayTextButton.contentOffset = new Vector2(0, 1);
      _propertyArrayTextButton.alignment = TextAnchor.UpperCenter;

      _propertyRowOdd = new GUIStyle(GUIStyle.none);
      _propertyRowOdd.fixedHeight = 20;

      _propertyRowEven = new GUIStyle(_propertyRowOdd);
      _propertyRowEven.normal.background = _texture_propertyRowEven;

      _scriptRowOdd = new GUIStyle(GUIStyle.none);
      _scriptRowOdd.fixedHeight = 17;

      _scriptRowEven = new GUIStyle(_scriptRowOdd);
      _scriptRowEven.normal.background = _texture_propertyRowEven;

      _listRow = new GUIStyle(GUIStyle.none);
      _listRow.onNormal.background = _texture_propertyRowEven;

      _toolbarLabel = new GUIStyle(EditorStyles.label);
      _toolbarLabel.padding = new RectOffset(4, 4, 2, 2);
      _toolbarLabel.margin = new RectOffset();
   }

   static public void CustomSkinStyles()
   {
      string result = "These are the custom styles defined in the current skin (" + GUI.skin.name + "):\n";
      for (int i = 0; i < GUI.skin.customStyles.Length; i++)
      {
         result += "\t" + i.ToString("000") + ": \"" + GUI.skin.customStyles[i].name + "\"\n";
      }
      Debug.Log(result);
   }

   private class StyleInformationItem
   {
      public string Label { get; private set; }
      public string Value { get; private set; }

      public int LabelWidth { get; private set; }
      public int ValueWidth { get; private set; }

      public StyleInformationItem(string name, object value)
      {
         Label = (string.IsNullOrEmpty(name) ? name : name + ": \t");
         Value = value.ToString() + "\t\t";

         GUIStyle style = GUIStyle.none;

         LabelWidth = (int)style.CalcSize(new GUIContent(Label)).x;
         ValueWidth = (int)style.CalcSize(new GUIContent(Value)).x;
      }
   }



   static public void Information(GUIStyle style, int columns)
   {
      if (style == null)
      {
         return;
      }

      columns = Mathf.Max(1, Mathf.Min(5, columns));

      List<StyleInformationItem> items = new List<StyleInformationItem>();

      if (columns == 2)
      {
         items.Add(new StyleInformationItem("margin", style.margin));
         items.Add(new StyleInformationItem("font", style.font));

         items.Add(new StyleInformationItem("padding", style.padding));
         items.Add(new StyleInformationItem("fontSize", style.fontSize));

         items.Add(new StyleInformationItem("fixedHeight", style.fixedHeight));
         items.Add(new StyleInformationItem("fontStyle", style.fontStyle));

         items.Add(new StyleInformationItem("fixedWidth", style.fixedWidth));
         items.Add(new StyleInformationItem("lineHeight", style.lineHeight));

         items.Add(new StyleInformationItem("stretchHeight", style.stretchHeight));
         items.Add(new StyleInformationItem("wordWrap", style.wordWrap));

         items.Add(new StyleInformationItem("stretchWidth", style.stretchWidth));
         items.Add(new StyleInformationItem("alignment", style.alignment));

         items.Add(new StyleInformationItem("clipping", style.clipping));
         items.Add(new StyleInformationItem("imagePosition", style.imagePosition));

         items.Add(new StyleInformationItem("overflow", style.overflow));
         items.Add(new StyleInformationItem("border", style.border));

         items.Add(new StyleInformationItem("contentOffset", style.contentOffset));
      }
      else if (columns == 3)
      {
         items.Add(new StyleInformationItem("fixedHeight", style.fixedHeight));
         items.Add(new StyleInformationItem("margin", style.margin));
         items.Add(new StyleInformationItem("font", style.font));

         items.Add(new StyleInformationItem("fixedWidth", style.fixedWidth));
         items.Add(new StyleInformationItem("padding", style.padding));
         items.Add(new StyleInformationItem("fontSize", style.fontSize));

         items.Add(new StyleInformationItem("stretchHeight", style.stretchHeight));
         items.Add(new StyleInformationItem("border", style.border));
         items.Add(new StyleInformationItem("fontStyle", style.fontStyle));

         items.Add(new StyleInformationItem("stretchWidth", style.stretchWidth));
         items.Add(new StyleInformationItem("overflow", style.overflow));
         items.Add(new StyleInformationItem("alignment", style.alignment));

         items.Add(new StyleInformationItem("contentOffset", style.contentOffset));
         items.Add(new StyleInformationItem("wordWrap", style.wordWrap));
         items.Add(new StyleInformationItem("imagePosition", style.imagePosition));

         items.Add(new StyleInformationItem(string.Empty, string.Empty));
         items.Add(new StyleInformationItem("clipping", style.clipping));
         items.Add(new StyleInformationItem("lineHeight", style.lineHeight));
      }
      else if (columns == 4)
      {
         items.Add(new StyleInformationItem("fixedHeight", style.fixedHeight));
         items.Add(new StyleInformationItem("margin", style.margin));
         items.Add(new StyleInformationItem("alignment", style.alignment));
         items.Add(new StyleInformationItem("font", style.font));

         items.Add(new StyleInformationItem("fixedWidth", style.fixedWidth));
         items.Add(new StyleInformationItem("padding", style.padding));
         items.Add(new StyleInformationItem("imagePosition", style.imagePosition));
         items.Add(new StyleInformationItem("fontSize", style.fontSize));

         items.Add(new StyleInformationItem("stretchHeight", style.stretchHeight));
         items.Add(new StyleInformationItem("border", style.border));
         items.Add(new StyleInformationItem("wordWrap", style.wordWrap));
         items.Add(new StyleInformationItem("fontStyle", style.fontStyle));

         items.Add(new StyleInformationItem("stretchWidth", style.stretchWidth));
         items.Add(new StyleInformationItem("overflow", style.overflow));
         items.Add(new StyleInformationItem("clipping", style.clipping));
         items.Add(new StyleInformationItem("lineHeight", style.lineHeight));

         items.Add(new StyleInformationItem("contentOffset", style.contentOffset));
      }
      else if (columns == 5)
      {
         items.Add(new StyleInformationItem("fixedHeight", style.fixedHeight));
         items.Add(new StyleInformationItem("margin", style.margin));
         items.Add(new StyleInformationItem("alignment", style.alignment));
         items.Add(new StyleInformationItem("font", style.font));
         items.Add(new StyleInformationItem("contentOffset", style.contentOffset));

         items.Add(new StyleInformationItem("fixedWidth", style.fixedWidth));
         items.Add(new StyleInformationItem("padding", style.padding));
         items.Add(new StyleInformationItem("imagePosition", style.imagePosition));
         items.Add(new StyleInformationItem("fontSize", style.fontSize));
         items.Add(new StyleInformationItem(string.Empty, string.Empty));

         items.Add(new StyleInformationItem("stretchHeight", style.stretchHeight));
         items.Add(new StyleInformationItem("border", style.border));
         items.Add(new StyleInformationItem("wordWrap", style.wordWrap));
         items.Add(new StyleInformationItem("fontStyle", style.fontStyle));
         items.Add(new StyleInformationItem(string.Empty, string.Empty));

         items.Add(new StyleInformationItem("stretchWidth", style.stretchWidth + "\t"));
         items.Add(new StyleInformationItem("overflow", style.overflow));
         items.Add(new StyleInformationItem("clipping", style.clipping));
         items.Add(new StyleInformationItem("lineHeight", style.lineHeight));
      }
      else
      {
         items.Add(new StyleInformationItem("margin", style.margin));
         items.Add(new StyleInformationItem("padding", style.padding));
         items.Add(new StyleInformationItem("fixedHeight", style.fixedHeight));
         items.Add(new StyleInformationItem("fixedWidth", style.fixedWidth));
         items.Add(new StyleInformationItem("stretchHeight", style.stretchHeight));
         items.Add(new StyleInformationItem("stretchWidth", style.stretchWidth));
         items.Add(new StyleInformationItem("font", style.font));
         items.Add(new StyleInformationItem("fontSize", style.fontSize));
         items.Add(new StyleInformationItem("fontStyle", style.fontStyle));
         items.Add(new StyleInformationItem("lineHeight", style.lineHeight));
         items.Add(new StyleInformationItem("alignment", style.alignment));
         items.Add(new StyleInformationItem("border", style.border));
         items.Add(new StyleInformationItem("clipping", style.clipping));
         items.Add(new StyleInformationItem("contentOffset", style.contentOffset));
         items.Add(new StyleInformationItem("imagePosition", style.imagePosition));
         items.Add(new StyleInformationItem("overflow", style.overflow));
         items.Add(new StyleInformationItem("wordWrap", style.wordWrap));
      }

      string result = "Style Information: \"" + style.name + "\":";

      int[] columnLabelWidth = new int[columns];
      int[] columnValueWidth = new int[columns];

      float tabWidth = new GUIStyle().CalcSize(new GUIContent("\t")).x;

      int index = 0;
      foreach (StyleInformationItem item in items)
      {
         int column = index++ % columns;
         columnLabelWidth[column] = Mathf.Max(columnLabelWidth[column], item.LabelWidth);
         columnValueWidth[column] = Mathf.Max(columnValueWidth[column], item.ValueWidth);
      }

      index = 0;
      foreach (StyleInformationItem item in items)
      {
         int column = index++ % columns;

         if (column == 0)
         {
            result += "\n\t";
         }

         result += item.Label + new string('\t', Mathf.CeilToInt((columnLabelWidth[column] - item.LabelWidth) / tabWidth));
         result += item.Value + new string('\t', Mathf.CeilToInt((columnValueWidth[column] - item.ValueWidth) / tabWidth));
      }

      Debug.Log(result
                + "\n\t isHeightDependantOnWidth: \t\t\t" + style.isHeightDependantOnWidth

                + "\n\t states:\t normal( " + style.normal.background + ", " + style.normal.textColor + " )"
                + "\n\t\t\t\t hover( " + style.hover.background + ", " + style.hover.textColor + " )"
                + "\n\t\t\t\t active( " + style.active.background + ", " + style.active.textColor + " )"
                + "\n\t\t\t\t focused( " + style.focused.background + ", " + style.focused.textColor + " )"
                + "\n"
               );
   }
}
