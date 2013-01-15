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

   public static GUIStyle paletteToolbarButton { get; private set; }

   public static GUIStyle paletteFoldout { get; private set; }

   public static GUIStyle paletteButton { get; private set; }

   public static GUIStyle panelBox { get; private set; }

   public static GUIStyle panelHR { get; private set; }

   public static GUIStyle panelTitle { get; private set; }

   public static GUIStyle panelTitleDropDown { get; private set; }

   public static GUIStyle referenceText { get; private set; }

   public static GUIStyle columnHeader { get; private set; }

   public static GUIStyle hDivider { get; private set; }

   public static GUIStyle vDivider { get; private set; }

   public static GUIStyle vScrollbar { get; private set; }

   public static GUIStyle hScrollbar { get; private set; }

   public static GUIStyle vColumnScrollbar { get; private set; }

   public static GUIStyle hColumnScrollbar { get; private set; }

   public static GUIStyle columnScrollView { get; private set; }

   public static GUIStyle nodeButtonFavoriteNumber { get; private set; }

   public static GUIStyle nodeButtonFavoriteName { get; private set; }

   public static GUIStyle nodeButtonLeft { get; private set; }

   public static GUIStyle nodeButtonMiddle { get; private set; }

   public static GUIStyle nodeButtonRight { get; private set; }

   public static GUIStyle contextMenu { get; private set; }

   public static GUIStyle menuDropDownWindow { get; private set; }

   public static GUIStyle menuDropDownButton { get; private set; }

   public static GUIStyle menuDropDownButtonShortcut { get; private set; }

   public static GUIStyle menuContextWindow { get; private set; }

   public static GUIStyle menuContextButton { get; private set; }

   public static GUIStyle panelMessage { get; private set; }

   public static GUIStyle panelMessageBold { get; private set; }

   public static GUIStyle panelMessageError { get; private set; }

   public static GUIStyle propertyButtonLeft { get; private set; }

   public static GUIStyle propertyButtonMiddleDeprecated { get; private set; }

   public static GUIStyle propertyButtonMiddleFavorite { get; private set; }

   public static GUIStyle propertyButtonMiddleFavoriteStar { get; private set; }

   public static GUIStyle propertyButtonMiddleName { get; private set; }

   public static GUIStyle propertyButtonRightSearch { get; private set; }

   public static GUIStyle propertyButtonRightName { get; private set; }

   public static GUIStyle propertyArrayIconButton { get; private set; }

   public static GUIStyle propertyArrayTextButton { get; private set; }

   public static GUIStyle propertyBoolField { get; private set; }

   public static GUIStyle propertyRowOdd { get; private set; }

   public static GUIStyle propertyRowEven { get; private set; }

   public static GUIStyle propertyTextField { get; private set; }

   public static GUIStyle referenceName { get; private set; }

   public static GUIStyle referenceInfo { get; private set; }

   public static GUIStyle referenceDesc { get; private set; }

   public static GUIStyle referenceButtonIcon { get; private set; }

   public static GUIStyle referenceButtonText { get; private set; }

   public static GUIStyle referenceDetailBox { get; private set; }

   public static GUIStyle referenceDetailTitle { get; private set; }

   public static GUIStyle referenceDetailLabel { get; private set; }

   public static GUIStyle referenceDetailValue { get; private set; }

   public static GUIStyle referenceDetailAlertLabel { get; private set; }

   public static GUIStyle referenceDetailAlertValue { get; private set; }

   public static GUIStyle scriptRowOdd { get; private set; }

   public static GUIStyle scriptRowEven { get; private set; }

   public static GUIStyle listRow { get; private set; }

   public static GUIStyle toolbarLabel { get; private set; }

   public static GUIStyle underline { get; private set; }

   public static readonly int columnHeaderHeight = 16;
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

      paletteToolbarButton = new GUIStyle(EditorStyles.toolbarButton);
      paletteToolbarButton.margin = new RectOffset(12, 6, 0, 0);

      paletteFoldout = new GUIStyle(EditorStyles.foldout);
      paletteFoldout.padding = new RectOffset(12, 4, 2, 2);
      paletteFoldout.margin = new RectOffset(4, 4, 0, 0);

      paletteButton = new GUIStyle(GUI.skin.button);
      paletteButton.alignment = TextAnchor.UpperLeft;
      paletteButton.padding = new RectOffset(4, 4, 2, 2);
      paletteButton.margin = new RectOffset(4, 4, 0, 0);
      paletteButton.active.textColor = UnityEngine.Color.white;

      panelBox = new GUIStyle(GUI.skin.box);
      panelBox.name = "panelBox";
      panelBox.padding = new RectOffset(1, 1, 1, 1);
      panelBox.margin = new RectOffset(0, 0, 0, 0);

      panelHR = new GUIStyle(GUI.skin.box);
      panelHR.name = "panelHR";
      panelHR.padding = new RectOffset(1, 1, 1, 1);
      panelHR.margin = new RectOffset(8, 8, 8, 6);
      panelHR.border = new RectOffset(0, 0, 1, 1);

      panelTitle = new GUIStyle(EditorStyles.boldLabel);
      panelTitle.name = "panelTitle";
      panelTitle.margin = new RectOffset(4, 4, 0, 0);

      panelTitleDropDown = new GUIStyle(EditorStyles.toolbarDropDown);
      panelTitleDropDown.name = "panelTitleDropDown";
      panelTitleDropDown.font = EditorStyles.boldLabel.font;
      panelTitleDropDown.padding = new RectOffset(6, 12, 1, 3);

      referenceText = new GUIStyle(GUI.skin.label);
      referenceText.name = "referenceText";
      referenceText.wordWrap = true;
      referenceText.stretchWidth = true;
      referenceText.stretchHeight = true;

      columnHeader = new GUIStyle(EditorStyles.toolbarButton);
      columnHeader.name = "columnHeader";
      columnHeader.normal.background = columnHeader.onNormal.background;
      columnHeader.fontStyle = FontStyle.Bold;
      columnHeader.alignment = TextAnchor.MiddleLeft;
      columnHeader.padding = new RectOffset(5, 8, 0, 0);
      columnHeader.fixedHeight = columnHeaderHeight;
      columnHeader.contentOffset = new Vector2(0, -1);

      hDivider = new GUIStyle(GUI.skin.box);
      hDivider.name = "hDivider";
      hDivider.margin = new RectOffset(0, 0, 0, 0);
      hDivider.padding = new RectOffset(0, 0, 0, 0);
      hDivider.border = new RectOffset(0, 0, 0, 0);
      hDivider.normal.background = null;

      vDivider = new GUIStyle(GUI.skin.box);
      vDivider.name = "vDivider";
      vDivider.margin = new RectOffset(0, 0, 0, 0);
      vDivider.padding = new RectOffset(0, 0, 0, 0);
      vDivider.border = new RectOffset(0, 0, 0, 0);
      vDivider.normal.background = null;

      vScrollbar = new GUIStyle(GUI.skin.verticalScrollbar);
      // vScrollbar.name = "vScrollbar";                // DO NOT RENAME
      vScrollbar.margin = new RectOffset();

      hScrollbar = new GUIStyle(GUI.skin.horizontalScrollbar);
      // hScrollbar.name = "hScrollbar";                // DO NOT RENAME
      hScrollbar.margin = new RectOffset();

      vColumnScrollbar = new GUIStyle(vScrollbar);
      // vColumnScrollbar.name = "vColumnScrollbar";    // DO NOT RENAME
      vColumnScrollbar.normal.background = columnHeader.normal.background;
      vColumnScrollbar.overflow = new RectOffset();

      hColumnScrollbar = new GUIStyle(hScrollbar);
      // hColumnScrollbar.name = "hColumnScrollbar";    // DO NOT RENAME
      hColumnScrollbar.fixedHeight = 0;

      columnScrollView = new GUIStyle(GUI.skin.box);
      columnScrollView.name = "columnScrollView";
      columnScrollView.margin = new RectOffset(4, 4, 3, 0);

      nodeButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft);
      nodeButtonLeft.name = "nodeButtonLeft";
      nodeButtonLeft.alignment = TextAnchor.UpperLeft;
      nodeButtonLeft.padding = new RectOffset(4, 4, 2, 4);
      nodeButtonLeft.margin = new RectOffset(4, 0, 0, 0);
      nodeButtonLeft.overflow = new RectOffset(0, 0, 0, 2);
      nodeButtonLeft.fontSize = 11;

      nodeButtonMiddle = new GUIStyle(EditorStyles.miniButtonMid);
      nodeButtonMiddle.name = "nodeButtonMiddle";
      nodeButtonMiddle.alignment = TextAnchor.MiddleCenter;
      nodeButtonMiddle.padding = new RectOffset(0, 0, 2, 4);
      nodeButtonMiddle.margin = new RectOffset(0, 0, 0, 0);
      nodeButtonMiddle.overflow = new RectOffset(0, 0, 0, 2);
      nodeButtonMiddle.fontSize = 11;
      nodeButtonMiddle.fixedHeight = 18;
      nodeButtonMiddle.contentOffset = new Vector2(0, 1);

      nodeButtonRight = new GUIStyle(EditorStyles.miniButtonRight);
      nodeButtonRight.name = "nodeButtonRight";
      nodeButtonRight.alignment = TextAnchor.UpperCenter;
      nodeButtonRight.padding = new RectOffset(0, 0, 2, 4);
      nodeButtonRight.margin = new RectOffset(0, 4, 0, 0);
      nodeButtonRight.overflow = new RectOffset(0, 0, 0, 2);
      nodeButtonRight.fontSize = 11;
      nodeButtonRight.fixedHeight = 19;
      nodeButtonRight.contentOffset = new Vector2(-1, 1);

      nodeButtonFavoriteNumber = new GUIStyle("ButtonLeft");
      nodeButtonFavoriteNumber.name = "uScript_nodeButtonFavoriteNumber";
      nodeButtonFavoriteNumber.fixedWidth = 20;
      nodeButtonFavoriteNumber.fontStyle = FontStyle.Bold;
      nodeButtonFavoriteNumber.overflow = new RectOffset(0, 0, 1, 1);
      nodeButtonFavoriteNumber.margin = new RectOffset(4, 0, 0, 0);

      nodeButtonFavoriteName = new GUIStyle("ButtonRight");
      nodeButtonFavoriteName.name = "uScript_nodeButtonFavoriteName";
      nodeButtonFavoriteName.alignment = TextAnchor.MiddleLeft;
      nodeButtonFavoriteName.contentOffset = new Vector2(0, -1);
      nodeButtonFavoriteName.margin = new RectOffset(0, 4, 0, 0);
      nodeButtonFavoriteName.overflow = new RectOffset(0, 0, 1, 1);
      nodeButtonFavoriteName.padding = new RectOffset(6, 6, 2, 2);

      contextMenu = new GUIStyle(EditorStyles.toolbarButton);

      menuDropDownWindow = new GUIStyle(GUI.skin.window);
      menuDropDownWindow.normal.background = _texture_windowMenuDropDown;
      menuDropDownWindow.onNormal.background = _texture_windowMenuDropDown;
      menuDropDownWindow.border = new RectOffset(10, 10, 4, 10);
      menuDropDownWindow.padding = new RectOffset(0, 0, 0, 4);
      menuDropDownWindow.overflow = new RectOffset(6, 6, 0, 6);
      menuDropDownWindow.contentOffset = Vector2.zero;

      menuDropDownButton = new GUIStyle(EditorStyles.largeLabel);
      menuDropDownButton.name = "menuDropDownButton";
      menuDropDownButton.active.background = EditorStyles.toolbarButton.onActive.background;
      menuDropDownButton.hover.background = EditorStyles.toolbarButton.onNormal.background;
      menuDropDownButton.border = EditorStyles.toolbarButton.border;
      menuDropDownButton.margin = new RectOffset();
      menuDropDownButton.padding = new RectOffset(8, 8, 4, 4);

      menuDropDownButtonShortcut = new GUIStyle(EditorStyles.largeLabel);
      menuDropDownButtonShortcut.name = "menuDropDownButtonShortcut";
      menuDropDownButtonShortcut.fontStyle = FontStyle.Bold;
      menuDropDownButtonShortcut.margin = new RectOffset();
      menuDropDownButtonShortcut.padding = new RectOffset();

      menuContextWindow = new GUIStyle(GUI.skin.window);
      menuContextWindow.normal.background = _texture_windowMenuContext;
      menuContextWindow.onNormal.background = _texture_windowMenuContext;
      menuContextWindow.border = new RectOffset(10, 10, 10, 10);
      menuContextWindow.padding = new RectOffset(0, 0, 4, 4);
      menuContextWindow.overflow = new RectOffset(6, 6, 6, 6);
      menuContextWindow.contentOffset = Vector2.zero;

      menuContextButton = new GUIStyle(EditorStyles.largeLabel);
      menuContextButton.name = "menuDropDownButton";
      menuContextButton.active.background = EditorStyles.toolbarButton.onActive.background;
      menuContextButton.hover.background = EditorStyles.toolbarButton.onNormal.background;
      menuContextButton.border = EditorStyles.toolbarButton.border;
      menuContextButton.margin = new RectOffset();
      menuContextButton.padding = new RectOffset(8, 8, 4, 4);

      panelMessage = new GUIStyle(GUI.skin.label);
      panelMessage.wordWrap = true;
      panelMessage.padding = new RectOffset(16, 16, 16, 16);

      panelMessageBold = new GUIStyle(EditorStyles.boldLabel);
      panelMessageBold.alignment = TextAnchor.MiddleCenter;
      panelMessageBold.wordWrap = true;
      panelMessageBold.padding = new RectOffset(16, 16, 16, 16);

      panelMessageError = new GUIStyle(GUI.skin.box);
      panelMessageError.normal.textColor = EditorStyles.boldLabel.normal.textColor;
      panelMessageError.font = EditorStyles.boldLabel.font;
      panelMessageError.wordWrap = true;
      panelMessageError.stretchWidth = true;

      underline = new GUIStyle(EditorStyles.boldLabel);
      underline.normal.background = _texture_underline;
      underline.border = new RectOffset(0, 0, 0, 2);
      underline.padding = new RectOffset(0, 0, 2, 2);

      referenceButtonIcon = new GUIStyle(EditorStyles.miniButton);
      referenceButtonIcon.name = "uScript_referenceButtonIcon";
      referenceButtonIcon.alignment = TextAnchor.MiddleCenter;
      referenceButtonIcon.imagePosition = ImagePosition.ImageOnly;
      referenceButtonIcon.padding = new RectOffset();
      referenceButtonIcon.margin = new RectOffset(4, 4, 0, 0);
      referenceButtonIcon.fixedHeight = 20;
      referenceButtonIcon.fixedWidth = 20;

      referenceButtonText = new GUIStyle(EditorStyles.miniButton);
      referenceButtonText.name = "uScript_referenceButtonText";
      referenceButtonText.alignment = TextAnchor.MiddleCenter;
      referenceButtonText.padding = new RectOffset(3, 6, 2, 4);
      referenceButtonText.margin = new RectOffset(4, 4, 0, 0);
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



      referenceName = new GUIStyle(EditorStyles.boldLabel);
      referenceName.name = "referenceName";
      referenceName.normal.background = _texture_underline;
      referenceName.border = new RectOffset(0, 0, 0, 2);
      referenceName.padding = new RectOffset(0, 0, 2, 2);

      referenceInfo = new GUIStyle(EditorStyles.miniLabel);
      referenceInfo.name = "referenceInfo";
      referenceInfo.alignment = TextAnchor.LowerRight;
      referenceInfo.padding = new RectOffset(0, 0, 3, 2);

      referenceDesc = new GUIStyle(EditorStyles.label);
      referenceDesc.name = "referenceDesc";
      referenceDesc.padding = new RectOffset(0, 0, 0, 3);
      referenceDesc.stretchHeight = false;
      referenceDesc.stretchWidth = true;
      referenceDesc.wordWrap = true;

      propertyButtonLeft = new GUIStyle("ButtonLeft");
      propertyButtonLeft.name = "uScript_propertyButtonLeft";
      propertyButtonLeft.fixedHeight = 20;
      propertyButtonLeft.fixedWidth = 20;
      propertyButtonLeft.fontStyle = FontStyle.Bold;
      propertyButtonLeft.margin = new RectOffset(4, 0, 0, 0);

      propertyButtonMiddleDeprecated = new GUIStyle("ButtonMid");
      propertyButtonMiddleDeprecated.name = "uScript_propertyButtonMiddleDeprecated";
      propertyButtonMiddleDeprecated.fixedHeight = 20;
      propertyButtonMiddleDeprecated.fontStyle = FontStyle.Bold;
      propertyButtonMiddleDeprecated.margin = new RectOffset();

      propertyButtonMiddleFavorite = new GUIStyle(propertyButtonMiddleDeprecated);
      propertyButtonMiddleFavorite.name = "uScript_propertyButtonMiddleFavorite";
      propertyButtonMiddleFavorite.contentOffset = new Vector2(6, 0);
      propertyButtonMiddleFavorite.fixedWidth = 30;

      propertyButtonMiddleFavoriteStar = new GUIStyle(EditorStyles.largeLabel);
      propertyButtonMiddleFavoriteStar.name = "uScript_propertyButtonMiddleFavoriteStar";
      propertyButtonMiddleFavoriteStar.padding = new RectOffset(4, 4, 0, 0);
      propertyButtonMiddleFavoriteStar.fontSize = 15;

      propertyButtonMiddleName = new GUIStyle(propertyButtonMiddleDeprecated);
      propertyButtonMiddleName.name = "uScript_propertyButtonMiddleName";
      propertyButtonMiddleName.alignment = TextAnchor.MiddleLeft;
      propertyButtonMiddleName.fixedWidth = 0;
      propertyButtonMiddleName.contentOffset = Vector2.zero;

      propertyButtonRightSearch = new GUIStyle("ButtonRight");
      propertyButtonRightSearch.name = "uScript_propertyButtonRightSearch";
      propertyButtonRightSearch.fixedHeight = 20;
      propertyButtonRightSearch.fixedWidth = 20;
      propertyButtonRightSearch.fontStyle = FontStyle.Bold;
      propertyButtonRightSearch.margin = new RectOffset(0, 4, 0, 0);
      propertyButtonRightSearch.padding = new RectOffset();

      propertyButtonRightName = new GUIStyle(propertyButtonRightSearch);
      propertyButtonRightName.name = "uScript_propertyButtonRightName";
      propertyButtonRightName.alignment = TextAnchor.MiddleLeft;
      propertyButtonRightName.fixedWidth = 0;
      propertyButtonRightName.padding = ((GUIStyle)"ButtonRight").padding;

      propertyTextField = new GUIStyle(EditorStyles.textField);
      propertyTextField.margin = new RectOffset(4, 4, 2, 2);

      propertyBoolField = new GUIStyle(EditorStyles.toggle);
      propertyBoolField.margin = new RectOffset(4, 4, 1, 1);

      propertyArrayIconButton = new GUIStyle(EditorStyles.miniButton);
      propertyArrayIconButton.margin = new RectOffset(4, 4, 2, 2);
      propertyArrayIconButton.padding = new RectOffset(3, 3, 2, 2);
      propertyArrayIconButton.stretchWidth = false;

      propertyArrayTextButton = new GUIStyle(EditorStyles.miniButton);
      propertyArrayTextButton.fontStyle = FontStyle.Bold;
      propertyArrayTextButton.padding = new RectOffset(0, 2, 1, 1);
      propertyArrayTextButton.contentOffset = new Vector2(0, 1);
      propertyArrayTextButton.alignment = TextAnchor.UpperCenter;

      propertyRowOdd = new GUIStyle(GUIStyle.none);
      propertyRowOdd.fixedHeight = 20;

      propertyRowEven = new GUIStyle(propertyRowOdd);
      propertyRowEven.normal.background = _texture_propertyRowEven;

      scriptRowOdd = new GUIStyle(GUIStyle.none);
      scriptRowOdd.fixedHeight = 17;

      scriptRowEven = new GUIStyle(scriptRowOdd);
      scriptRowEven.normal.background = _texture_propertyRowEven;

      listRow = new GUIStyle(GUIStyle.none);
      listRow.onNormal.background = _texture_propertyRowEven;

      toolbarLabel = new GUIStyle(EditorStyles.label);
      toolbarLabel.padding = new RectOffset(4, 4, 2, 2);
      toolbarLabel.margin = new RectOffset();
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
