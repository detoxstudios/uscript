// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIStyle.cs" company="">
//   
// </copyright>
// <summary>
//   This file contains a collection of custom uScript GUI styles for use with uScriptEditor
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// TODO: Move associated GUIStyle properties from uScriptGUIStyle to a subclass of the type where they are utilizied
public static class uScriptGUIStyle
{
   public static readonly int columnHeaderHeight = 16;

   static uScriptGUIStyle()
   {
      var texturePropertyRowEven = AssetDatabase.LoadAssetAtPath(uScriptGUI.GetSkinnedImagePath("LineItem"), typeof(Texture2D)) as Texture2D;
      var textureUnderline = AssetDatabase.LoadAssetAtPath(uScriptGUI.GetSkinnedImagePath("Underline"), typeof(Texture2D)) as Texture2D;
      var textureWindowMenuContext = AssetDatabase.LoadAssetAtPath(uScriptGUI.GetSkinnedImagePath("MenuContext"), typeof(Texture2D)) as Texture2D;
      var textureWindowMenuDropDown = AssetDatabase.LoadAssetAtPath(uScriptGUI.GetSkinnedImagePath("MenuDropDown"), typeof(Texture2D)) as Texture2D;

      paletteToolbarFoldoutButton = new GUIStyle(EditorStyles.toolbarButton)
      {
         margin = new RectOffset(0, 6, 0, 0),
         padding = new RectOffset(2, 2, 0, 0)
      };

      paletteFoldout = new GUIStyle(EditorStyles.foldout)
      {
         padding = new RectOffset(12, 4, 2, 2),
         margin = new RectOffset(4, 4, 0, 0)
      };

      paletteButton = new GUIStyle(GUI.skin.button)
      {
         alignment = TextAnchor.UpperLeft,
         padding = new RectOffset(4, 4, 2, 2),
         margin = new RectOffset(4, 4, 0, 0),
         active = { textColor = Color.white }
      };

      panelBox = new GUIStyle(GUI.skin.box)
      {
         name = "panelBox",
         padding = new RectOffset(1, 1, 1, 1),
         margin = new RectOffset(0, 0, 0, 0)
      };

      panelHR = new GUIStyle(GUI.skin.box)
      {
         name = "panelHR",
         padding = new RectOffset(1, 1, 1, 1),
         margin = new RectOffset(8, 8, 8, 6),
         border = new RectOffset(0, 0, 1, 1)
      };

      panelTitle = new GUIStyle(EditorStyles.boldLabel) { name = "panelTitle", margin = new RectOffset(4, 4, 0, 0) };

      panelTitleDropDown = new GUIStyle(EditorStyles.toolbarDropDown)
      {
         name = "panelTitleDropDown",
         font = EditorStyles.boldLabel.font,
         margin = new RectOffset(0, 0, 0, 0),
         padding = new RectOffset(6, 12, 1, 3)
      };

      referenceText = new GUIStyle(GUI.skin.label)
      {
         name = "referenceText",
         wordWrap = true,
         stretchWidth = true,
         stretchHeight = true
      };

      columnHeader = new GUIStyle(EditorStyles.toolbarButton)
      {
         name = "columnHeader",
         fontStyle = FontStyle.Bold,
         alignment = TextAnchor.MiddleLeft,
         padding = new RectOffset(5, 8, 0, 0),
         fixedHeight = columnHeaderHeight,
         contentOffset = new Vector2(0, -1)
      };
      columnHeader.normal.background = columnHeader.onNormal.background;

      hDivider = new GUIStyle(GUI.skin.box)
      {
         name = "hDivider",
         margin = new RectOffset(0, 0, 0, 0),
         padding = new RectOffset(0, 0, 0, 0),
         border = new RectOffset(0, 0, 0, 0),
         normal = { background = null }
      };

      vDivider = new GUIStyle(GUI.skin.box)
      {
         name = "vDivider",
         margin = new RectOffset(0, 0, 0, 0),
         padding = new RectOffset(0, 0, 0, 0),
         border = new RectOffset(0, 0, 0, 0),
         normal = { background = null }
      };

      // vScrollbar.name = "vScrollbar";                // DO NOT RENAME
      vScrollbar = new GUIStyle(GUI.skin.verticalScrollbar) { margin = new RectOffset() };

      // hScrollbar.name = "hScrollbar";                // DO NOT RENAME
      hScrollbar = new GUIStyle(GUI.skin.horizontalScrollbar) { margin = new RectOffset() };

      // vColumnScrollbar.name = "vColumnScrollbar";    // DO NOT RENAME
      vColumnScrollbar = new GUIStyle(vScrollbar)
      {
         normal = { background = columnHeader.normal.background },
         overflow = new RectOffset()
      };

      // hColumnScrollbar.name = "hColumnScrollbar";    // DO NOT RENAME
      hColumnScrollbar = new GUIStyle(hScrollbar) { fixedHeight = 0 };

      columnScrollView = new GUIStyle(GUI.skin.box) { name = "columnScrollView", margin = new RectOffset(4, 4, 3, 0) };

      nodeButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft)
      {
         name = "nodeButtonLeft",
         alignment = TextAnchor.UpperLeft,
         padding = new RectOffset(4, 4, 2, 4),
         margin = new RectOffset(4, 0, 0, 0),
         overflow = new RectOffset(0, 0, 0, 2),
         fontSize = 11
      };

      nodeButtonMiddle = new GUIStyle(EditorStyles.miniButtonMid)
      {
         name = "nodeButtonMiddle",
         alignment = TextAnchor.MiddleCenter,
         padding = new RectOffset(0, 0, 2, 4),
         margin = new RectOffset(0, 0, 0, 0),
         overflow = new RectOffset(0, 0, 0, 2),
         fontSize = 11,
         fixedHeight = 18,
         contentOffset = new Vector2(0, 1)
      };

      nodeButtonRight = new GUIStyle(EditorStyles.miniButtonRight)
      {
         name = "nodeButtonRight",
         alignment = TextAnchor.UpperCenter,
         padding = new RectOffset(0, 0, 2, 4),
         margin = new RectOffset(0, 4, 0, 0),
         overflow = new RectOffset(0, 0, 0, 2),
         fontSize = 11,
         fixedHeight = 19,
         contentOffset = new Vector2(-1, 1)
      };

      favoriteButtonFoldout = new GUIStyle(EditorStyles.toolbarButton)
      {
         name = "uScript_favoriteButtonFoldout",
         margin = new RectOffset(0, 0, 0, 0),
         padding = new RectOffset(2, 2, 0, 0)
      };

      favoriteButtonName = new GUIStyle("ButtonRight")
      {
         name = "uScript_favoriteButtonName",
         alignment = TextAnchor.MiddleLeft,
         contentOffset = new Vector2(0, -1),
         margin = new RectOffset(0, 4, 0, 0),
         overflow = new RectOffset(0, 0, 1, 1),
         padding = new RectOffset(6, 6, 2, 2)
      };

      favoriteButtonNumber = new GUIStyle("ButtonLeft")
      {
         name = "uScript_favoriteButtonNumber",
         alignment = TextAnchor.MiddleLeft,
         fontStyle = FontStyle.Bold,
         overflow = new RectOffset(0, 0, 1, 1),
         margin = new RectOffset(4, 0, 0, 0),
         padding = new RectOffset(7, 6, 1, 3)
      };

      favoriteButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft)
      {
         name = "uScript_favoriteButtonLeft",
         margin = new RectOffset(4, 0, 1, 1),
         padding = new RectOffset(4, 4, 2, 2)
      };

      favoriteButtonMiddle = new GUIStyle(EditorStyles.miniButtonMid)
      {
         name = "uScript_favoriteButtonMiddle",
         margin = new RectOffset(0, 0, 1, 1),
         padding = new RectOffset(4, 4, 2, 2)
      };

      favoriteButtonRight = new GUIStyle(EditorStyles.miniButtonRight)
      {
         name = "uScript_favoriteButtonRight",
         margin = new RectOffset(0, 4, 1, 1),
         padding = new RectOffset(4, 4, 2, 2)
      };

      contextMenu = new GUIStyle(EditorStyles.toolbarButton);

      menuDropDownWindow = new GUIStyle(GUI.skin.window)
      {
         normal = { background = textureWindowMenuDropDown },
         onNormal = { background = textureWindowMenuDropDown },
         border = new RectOffset(10, 10, 4, 10),
         padding = new RectOffset(0, 0, 0, 4),
         overflow = new RectOffset(6, 6, 0, 6),
         contentOffset = Vector2.zero
      };

      menuDropDownButton = new GUIStyle(EditorStyles.largeLabel)
      {
         name = "menuDropDownButton",
         active = { background = EditorStyles.toolbarButton.onActive.background },
         hover = { background = EditorStyles.toolbarButton.onNormal.background },
         border = EditorStyles.toolbarButton.border,
         margin = new RectOffset(),
         padding = new RectOffset(8, 8, 4, 4)
      };

      menuDropDownButtonShortcut = new GUIStyle(EditorStyles.largeLabel)
      {
         name = "menuDropDownButtonShortcut",
         fontStyle = FontStyle.Bold,
         margin = new RectOffset(),
         padding = new RectOffset()
      };

      menuContextWindow = new GUIStyle(GUI.skin.window)
      {
         normal = { background = textureWindowMenuContext },
         onNormal = { background = textureWindowMenuContext },
         border = new RectOffset(10, 10, 10, 10),
         padding = new RectOffset(0, 0, 4, 4),
         overflow = new RectOffset(6, 6, 6, 6),
         contentOffset = Vector2.zero
      };

      menuContextButton = new GUIStyle(EditorStyles.largeLabel)
      {
         name = "menuDropDownButton",
         active = { background = EditorStyles.toolbarButton.onActive.background },
         hover = { background = EditorStyles.toolbarButton.onNormal.background },
         border = EditorStyles.toolbarButton.border,
         margin = new RectOffset(),
         padding = new RectOffset(8, 8, 4, 4)
      };

      outline = new GUIStyle(GUI.skin.box)
      {
         name = "uScript_outline",
         margin = new RectOffset(),
         padding = new RectOffset(),
         stretchHeight = false,
         stretchWidth = false
      };

      panelMessage = new GUIStyle(GUI.skin.label) { wordWrap = true, padding = new RectOffset(16, 16, 16, 16) };

      panelMessageBold = new GUIStyle(EditorStyles.boldLabel)
      {
         alignment = TextAnchor.MiddleCenter,
         wordWrap = true,
         padding = new RectOffset(16, 16, 16, 16)
      };

      panelMessageError = new GUIStyle(GUI.skin.box)
      {
         normal = { textColor = EditorStyles.boldLabel.normal.textColor },
         font = EditorStyles.boldLabel.font,
         wordWrap = true,
         stretchWidth = true
      };

      underline = new GUIStyle(EditorStyles.boldLabel)
      {
         normal = { background = textureUnderline },
         border = new RectOffset(0, 0, 0, 2),
         padding = new RectOffset(0, 0, 2, 2)
      };

      referenceButtonIcon = new GUIStyle(EditorStyles.miniButton)
      {
         name = "uScript_referenceButtonIcon",
         alignment = TextAnchor.MiddleCenter,
         imagePosition = ImagePosition.ImageOnly,
         padding = new RectOffset(),
         margin = new RectOffset(4, 4, 0, 0),
         fixedHeight = 20,
         fixedWidth = 20
      };

      referenceButtonText = new GUIStyle(EditorStyles.miniButton)
      {
         name = "uScript_referenceButtonText",
         alignment = TextAnchor.MiddleCenter,
         padding = new RectOffset(3, 6, 2, 4),
         margin = new RectOffset(4, 4, 0, 0),
         fontSize = 11,
         fixedHeight = 20
      };

      referenceDetailBox = new GUIStyle(GUI.skin.box)
      {
         name = "uScript_referenceDetailBox",
         margin = new RectOffset(24, 24, 16, 16),
         padding = new RectOffset(4, 4, 4, 4)
      };

      referenceDetailTitle = new GUIStyle(EditorStyles.boldLabel)
      {
         name = "uScript_referenceDetailTitle",
         margin = new RectOffset(),
         padding = new RectOffset(2, 2, 2, 3),
         stretchWidth = false
      };

      referenceDetailLabel = new GUIStyle(EditorStyles.boldLabel)
      {
         name = "uScript_referenceDetailLabel",
         margin = new RectOffset(),
         padding = new RectOffset(2, 2, 2, 3),
         stretchWidth = false
      };

      referenceDetailValue = new GUIStyle(referenceDetailLabel)
      {
         name = "uScript_referenceDetailValue",
         alignment = TextAnchor.MiddleRight,
         margin = new RectOffset(12, 0, 0, 0)
      };

      referenceDetailAlertLabel = new GUIStyle(EditorStyles.boldLabel)
      {
         name = "uScript_referenceDetailAlertLabel",
         margin = new RectOffset(),
         padding = new RectOffset(2, 2, 2, 3),
         normal = { textColor = Color.red },
         wordWrap = true
      };

      referenceDetailAlertValue = new GUIStyle(referenceDetailAlertLabel)
      {
         name = "uScript_referenceDetailAlertValue",
         alignment = TextAnchor.MiddleRight,
         margin = new RectOffset(12, 0, 0, 0)
      };

      referenceName = new GUIStyle(EditorStyles.boldLabel)
      {
         name = "referenceName",
         normal = { background = textureUnderline },
         border = new RectOffset(0, 0, 0, 2),
         padding = new RectOffset(0, 0, 2, 2)
      };

      referenceInfo = new GUIStyle(EditorStyles.miniLabel)
      {
         name = "uScript_referenceInfo",
         alignment = TextAnchor.LowerRight,
         padding = new RectOffset(0, 0, 3, 2)
      };

      referenceDesc = new GUIStyle(EditorStyles.label)
      {
         name = "referenceDesc",
         padding = new RectOffset(0, 0, 0, 3),
         stretchHeight = false,
         stretchWidth = true,
         wordWrap = true
      };

      propertyButtonLeft = new GUIStyle("ButtonLeft")
      {
         name = "uScript_propertyButtonLeft",
         fixedHeight = 20,
         fixedWidth = 20,
         fontStyle = FontStyle.Bold,
         margin = new RectOffset(4, 0, 0, 0)
      };

      propertyButtonMiddleDeprecated = new GUIStyle("ButtonMid")
      {
         name = "uScript_propertyButtonMiddleDeprecated",
         fixedHeight = 20,
         fontStyle = FontStyle.Bold,
         margin = new RectOffset()
      };

      propertyButtonMiddleFavorite = new GUIStyle(propertyButtonMiddleDeprecated)
      {
         name = "uScript_propertyButtonMiddleFavorite",
         alignment = TextAnchor.MiddleLeft,
         contentOffset = new Vector2(6, 0),
         fixedWidth = 30,
         padding = new RectOffset(12, 6, 2, 3)
      };

      propertyButtonMiddleFavoriteStar = new GUIStyle(EditorStyles.largeLabel)
      {
         name = "uScript_propertyButtonMiddleFavoriteStar",
         padding = new RectOffset(4, 4, 0, 0),
         fontSize = 15
      };

      propertyButtonMiddleName = new GUIStyle(propertyButtonMiddleDeprecated)
      {
         name = "uScript_propertyButtonMiddleName",
         alignment = TextAnchor.MiddleLeft,
         fixedWidth = 0,
         contentOffset = Vector2.zero
      };

      propertyButtonRightSearch = new GUIStyle("ButtonRight")
      {
         name = "uScript_propertyButtonRightSearch",
         fixedHeight = 20,
         fixedWidth = 20,
         fontStyle = FontStyle.Bold,
         margin = new RectOffset(0, 4, 0, 0),
         padding = new RectOffset()
      };

      propertyButtonRightName = new GUIStyle(propertyButtonRightSearch)
      {
         name = "uScript_propertyButtonRightName",
         alignment = TextAnchor.MiddleLeft,
         fixedWidth = 0,
         padding = ((GUIStyle)"ButtonRight").padding
      };

      propertyTextField = new GUIStyle(EditorStyles.textField) { margin = new RectOffset(4, 4, 2, 2) };

      propertyBoolField = new GUIStyle(EditorStyles.toggle) { margin = new RectOffset(4, 4, 1, 1) };

      propertyArrayIconButton = new GUIStyle(EditorStyles.miniButton)
      {
         margin = new RectOffset(4, 4, 2, 2),
         padding = new RectOffset(3, 3, 2, 2),
         stretchWidth = false
      };

      propertyArrayTextButton = new GUIStyle(EditorStyles.miniButton)
      {
         fontStyle = FontStyle.Bold,
         padding = new RectOffset(0, 2, 1, 1),
         contentOffset = new Vector2(0, 1),
         alignment = TextAnchor.UpperCenter
      };

      propertyRowOdd = new GUIStyle(GUIStyle.none) { fixedHeight = 20 };

      propertyRowEven = new GUIStyle(propertyRowOdd) { normal = { background = texturePropertyRowEven } };

      scriptRowOdd = new GUIStyle(GUIStyle.none) { fixedHeight = 17 };

      scriptRowEven = new GUIStyle(scriptRowOdd) { normal = { background = texturePropertyRowEven } };

      listRow = new GUIStyle(GUIStyle.none) { onNormal = { background = texturePropertyRowEven } };

      toolbarLabel = new GUIStyle(EditorStyles.label)
      {
         padding = new RectOffset(4, 4, 2, 2),
         margin = new RectOffset()
      };
   }

   public static GUIStyle paletteToolbarFoldoutButton { get; private set; }

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

   public static GUIStyle favoriteButtonFoldout { get; private set; }

   public static GUIStyle favoriteButtonNumber { get; private set; }

   public static GUIStyle favoriteButtonName { get; private set; }

   public static GUIStyle favoriteButtonLeft { get; private set; }

   public static GUIStyle favoriteButtonMiddle { get; private set; }

   public static GUIStyle favoriteButtonRight { get; private set; }

   public static GUIStyle nodeButtonLeft { get; private set; }

   public static GUIStyle nodeButtonMiddle { get; private set; }

   public static GUIStyle nodeButtonRight { get; private set; }

   public static GUIStyle contextMenu { get; private set; }

   public static GUIStyle menuDropDownWindow { get; private set; }

   public static GUIStyle menuDropDownButton { get; private set; }

   public static GUIStyle menuDropDownButtonShortcut { get; private set; }

   public static GUIStyle menuContextWindow { get; private set; }

   public static GUIStyle menuContextButton { get; private set; }

   public static GUIStyle outline { get; private set; }

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

   public static GUIStyle referenceInfo { get; private set; }

   public static GUIStyle referenceName { get; private set; }

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

   public static void Init()
   {
   }

   public static void CustomSkinStyles(EditorSkin editorSkin)
   {
      var skin = EditorGUIUtility.GetBuiltinSkin(editorSkin);
      var result = "These are the custom styles defined in the skin (" + skin.name + "):\n";

      for (var i = 0; i < skin.customStyles.Length; i++)
      {
         result += "\t" + i.ToString("000") + ": \"" + skin.customStyles[i].name + "\"\n";
      }

      Debug.Log(result);

      // "PaneOptions"
      // "AnimationEventTooltip"
      // "DropDownButton"
      // "SearchTextField"
      // "ToolbarSearchTextField"
   }

   public static void Information(GUIStyle style)
   {
      Information(style, 5);
   }

   public static void Information(GUIStyle style, int columns)
   {
      if (style == null)
      {
         return;
      }

      columns = Mathf.Max(1, Mathf.Min(5, columns));

      var items = new List<StyleInformationItem>();

      switch (columns)
      {
         case 2:
            // Items are laid out in two columns
            items.Add(new StyleInformationItem("margin", style.margin));
            items.Add(new StyleInformationItem("font", style.font));

            // --
            items.Add(new StyleInformationItem("padding", style.padding));
            items.Add(new StyleInformationItem("fontSize", style.fontSize));

            // --
            items.Add(new StyleInformationItem("fixedHeight", style.fixedHeight));
            items.Add(new StyleInformationItem("fontStyle", style.fontStyle));

            // --
            items.Add(new StyleInformationItem("fixedWidth", style.fixedWidth));
            items.Add(new StyleInformationItem("lineHeight", style.lineHeight));

            // --
            items.Add(new StyleInformationItem("stretchHeight", style.stretchHeight));
            items.Add(new StyleInformationItem("wordWrap", style.wordWrap));

            // --
            items.Add(new StyleInformationItem("stretchWidth", style.stretchWidth));
            items.Add(new StyleInformationItem("alignment", style.alignment));

            // --
            items.Add(new StyleInformationItem("clipping", style.clipping));
            items.Add(new StyleInformationItem("imagePosition", style.imagePosition));

            // --
            items.Add(new StyleInformationItem("overflow", style.overflow));
            items.Add(new StyleInformationItem("border", style.border));

            // --
            items.Add(new StyleInformationItem("contentOffset", style.contentOffset));
            break;
         case 3:
            items.Add(new StyleInformationItem("fixedHeight", style.fixedHeight));
            items.Add(new StyleInformationItem("margin", style.margin));
            items.Add(new StyleInformationItem("font", style.font));

            // --
            items.Add(new StyleInformationItem("fixedWidth", style.fixedWidth));
            items.Add(new StyleInformationItem("padding", style.padding));
            items.Add(new StyleInformationItem("fontSize", style.fontSize));

            // --
            items.Add(new StyleInformationItem("stretchHeight", style.stretchHeight));
            items.Add(new StyleInformationItem("border", style.border));
            items.Add(new StyleInformationItem("fontStyle", style.fontStyle));

            // --
            items.Add(new StyleInformationItem("stretchWidth", style.stretchWidth));
            items.Add(new StyleInformationItem("overflow", style.overflow));
            items.Add(new StyleInformationItem("alignment", style.alignment));

            // --
            items.Add(new StyleInformationItem("contentOffset", style.contentOffset));
            items.Add(new StyleInformationItem("wordWrap", style.wordWrap));
            items.Add(new StyleInformationItem("imagePosition", style.imagePosition));

            // --
            items.Add(new StyleInformationItem(string.Empty, string.Empty));
            items.Add(new StyleInformationItem("clipping", style.clipping));
            items.Add(new StyleInformationItem("lineHeight", style.lineHeight));
            break;
         case 4:
            items.Add(new StyleInformationItem("fixedHeight", style.fixedHeight));
            items.Add(new StyleInformationItem("margin", style.margin));
            items.Add(new StyleInformationItem("alignment", style.alignment));
            items.Add(new StyleInformationItem("font", style.font));

            // --
            items.Add(new StyleInformationItem("fixedWidth", style.fixedWidth));
            items.Add(new StyleInformationItem("padding", style.padding));
            items.Add(new StyleInformationItem("imagePosition", style.imagePosition));
            items.Add(new StyleInformationItem("fontSize", style.fontSize));

            // --
            items.Add(new StyleInformationItem("stretchHeight", style.stretchHeight));
            items.Add(new StyleInformationItem("border", style.border));
            items.Add(new StyleInformationItem("wordWrap", style.wordWrap));
            items.Add(new StyleInformationItem("fontStyle", style.fontStyle));

            // --
            items.Add(new StyleInformationItem("stretchWidth", style.stretchWidth));
            items.Add(new StyleInformationItem("overflow", style.overflow));
            items.Add(new StyleInformationItem("clipping", style.clipping));
            items.Add(new StyleInformationItem("lineHeight", style.lineHeight));

            // --
            items.Add(new StyleInformationItem("contentOffset", style.contentOffset));
            break;
         case 5:
            items.Add(new StyleInformationItem("fixedHeight", style.fixedHeight));
            items.Add(new StyleInformationItem("margin", style.margin));
            items.Add(new StyleInformationItem("alignment", style.alignment));
            items.Add(new StyleInformationItem("font", style.font));
            items.Add(new StyleInformationItem("contentOffset", style.contentOffset));

            // --
            items.Add(new StyleInformationItem("fixedWidth", style.fixedWidth));
            items.Add(new StyleInformationItem("padding", style.padding));
            items.Add(new StyleInformationItem("imagePosition", style.imagePosition));
            items.Add(new StyleInformationItem("fontSize", style.fontSize));
            items.Add(new StyleInformationItem(string.Empty, string.Empty));

            // --
            items.Add(new StyleInformationItem("stretchHeight", style.stretchHeight));
            items.Add(new StyleInformationItem("border", style.border));
            items.Add(new StyleInformationItem("wordWrap", style.wordWrap));
            items.Add(new StyleInformationItem("fontStyle", style.fontStyle));
            items.Add(new StyleInformationItem(string.Empty, string.Empty));

            // --
            items.Add(new StyleInformationItem("stretchWidth", style.stretchWidth + "\t"));
            items.Add(new StyleInformationItem("overflow", style.overflow));
            items.Add(new StyleInformationItem("clipping", style.clipping));
            items.Add(new StyleInformationItem("lineHeight", style.lineHeight));
            break;
         default:
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
            break;
      }

      var result = "Style Information: \"" + style.name + "\":";

      var columnLabelWidths = new int[columns];
      var columnValueWidths = new int[columns];

      var tabWidth = new GUIStyle().CalcSize(new GUIContent("\t")).x;

      var index = 0;
      foreach (var item in items)
      {
         var column = index++ % columns;
         columnLabelWidths[column] = Mathf.Max(columnLabelWidths[column], item.LabelWidth);
         columnValueWidths[column] = Mathf.Max(columnValueWidths[column], item.ValueWidth);
      }

      index = 0;
      foreach (var item in items)
      {
         var column = index++ % columns;

         if (column == 0)
         {
            result += "\n\t";
         }

         result += item.Label + new string('\t', Mathf.CeilToInt((columnLabelWidths[column] - item.LabelWidth) / tabWidth));
         result += item.Value + new string('\t', Mathf.CeilToInt((columnValueWidths[column] - item.ValueWidth) / tabWidth));
      }

      Debug.Log(result
                + "\n\t isHeightDependantOnWidth: \t\t\t" + style.isHeightDependantOnWidth
                + "\n\t states:\t normal( " + style.normal.background + ", " + style.normal.textColor + " )"
                + "\n\t\t\t\t hover( " + style.hover.background + ", " + style.hover.textColor + " )"
                + "\n\t\t\t\t active( " + style.active.background + ", " + style.active.textColor + " )"
                + "\n\t\t\t\t focused( " + style.focused.background + ", " + style.focused.textColor + " )" + "\n");
   }

   private class StyleInformationItem
   {
      public StyleInformationItem(string name, object value)
      {
         this.Label = string.IsNullOrEmpty(name) ? name : name + ": \t";
         this.Value = value + "\t\t";

         var style = GUIStyle.none;

         this.LabelWidth = (int)style.CalcSize(new GUIContent(this.Label)).x;
         this.ValueWidth = (int)style.CalcSize(new GUIContent(this.Value)).x;
      }

      public string Label { get; private set; }

      public string Value { get; private set; }

      public int LabelWidth { get; private set; }

      public int ValueWidth { get; private set; }
   }
}
