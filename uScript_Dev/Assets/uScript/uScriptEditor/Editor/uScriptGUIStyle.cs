// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIStyle.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptGUIStyle type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Detox.Editor;

using UnityEditor;
using UnityEngine;

// TODO: Move associated GUIStyle properties from uScriptGUIStyle to a subclass of the type where they are utilizied
public static class uScriptGUIStyle
{
   public static readonly int ColumnHeaderHeight = 16;

   static uScriptGUIStyle()
   {
      var texturePropertyRowEven = uScriptGUI.GetSkinnedTexture("LineItem");
      var textureUnderline = uScriptGUI.GetSkinnedTexture("Underline");
      var textureWindowMenuContext = uScriptGUI.GetSkinnedTexture("MenuContext");

      PaletteToolbarFoldoutButton = new GUIStyle(EditorStyles.toolbarButton)
      {
         margin = new RectOffset(0, 6, 0, 0),
         padding = new RectOffset(2, 2, 0, 0)
      };

      PaletteFoldout = new GUIStyle(EditorStyles.foldout)
      {
         padding = new RectOffset(12, 4, 2, 2),
         margin = new RectOffset(4, 4, 0, 0)
      };

      PaletteButton = new GUIStyle(GUI.skin.button)
      {
         alignment = TextAnchor.UpperLeft,
         padding = new RectOffset(4, 4, 2, 2),
         margin = new RectOffset(4, 4, 0, 0),
         active = { textColor = Color.white }
      };

      PanelBox = new GUIStyle(GUI.skin.box)
      {
         name = "panelBox",
         padding = new RectOffset(1, 1, 1, 1),
         margin = new RectOffset(0, 0, 0, 0)
      };

      PanelHR = new GUIStyle(GUI.skin.box)
      {
         name = "panelHR",
         padding = new RectOffset(1, 1, 1, 1),
         margin = new RectOffset(8, 8, 8, 6),
         border = new RectOffset(0, 0, 1, 1)
      };

      PanelTitle = new GUIStyle(EditorStyles.boldLabel) { name = "panelTitle", margin = new RectOffset(4, 4, 0, 0) };

      PanelTitleDropDown = new GUIStyle(EditorStyles.toolbarDropDown)
      {
         name = "panelTitleDropDown",
         font = EditorStyles.boldLabel.font,
         margin = new RectOffset(0, 0, 0, 0),
         padding = new RectOffset(6, 12, 1, 3)
      };

      ReferenceText = new GUIStyle(GUI.skin.label)
      {
         name = "referenceText",
         wordWrap = true,
         stretchWidth = true,
         stretchHeight = true
      };

      ColumnHeader = new GUIStyle(EditorStyles.toolbarButton)
      {
         name = "columnHeader",
         fontStyle = FontStyle.Bold,
         alignment = TextAnchor.MiddleLeft,
         padding = new RectOffset(5, 8, 0, 0),
         fixedHeight = ColumnHeaderHeight,
         contentOffset = new Vector2(0, -1)
      };
      ColumnHeader.normal.background = ColumnHeader.onNormal.background;

      HorizontalDivider = new GUIStyle(GUI.skin.box)
      {
         name = "hDivider",
         margin = new RectOffset(0, 0, 0, 0),
         padding = new RectOffset(0, 0, 0, 0),
         border = new RectOffset(0, 0, 0, 0),
         normal = { background = null }
      };

      VerticalDivider = new GUIStyle(GUI.skin.box)
      {
         name = "vDivider",
         margin = new RectOffset(0, 0, 0, 0),
         padding = new RectOffset(0, 0, 0, 0),
         border = new RectOffset(0, 0, 0, 0),
         normal = { background = null }
      };

      // vScrollbar.name = "vScrollbar";                // DO NOT RENAME
      VerticalScrollbar = new GUIStyle(GUI.skin.verticalScrollbar) { margin = new RectOffset() };

      // hScrollbar.name = "hScrollbar";                // DO NOT RENAME
      HorizontalScrollbar = new GUIStyle(GUI.skin.horizontalScrollbar) { margin = new RectOffset() };

      // vColumnScrollbar.name = "vColumnScrollbar";    // DO NOT RENAME
      VerticalColumnScrollbar = new GUIStyle(VerticalScrollbar)
      {
         normal = { background = ColumnHeader.normal.background },
         overflow = new RectOffset()
      };

      // hColumnScrollbar.name = "hColumnScrollbar";    // DO NOT RENAME
      HorizontalColumnScrollbar = new GUIStyle(HorizontalScrollbar) { fixedHeight = 0 };

      ColumnScrollView = new GUIStyle(GUI.skin.box) { name = "columnScrollView", margin = new RectOffset(4, 4, 3, 0) };

      NodeButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft)
      {
         name = "nodeButtonLeft",
         alignment = TextAnchor.UpperLeft,
         padding = new RectOffset(4, 4, 2, 4),
         margin = new RectOffset(4, 0, 0, 0),
         overflow = new RectOffset(0, 0, 0, 2),
         fontSize = 11
      };

      NodeButtonMiddle = new GUIStyle(EditorStyles.miniButtonMid)
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

      NodeButtonRight = new GUIStyle(EditorStyles.miniButtonRight)
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

      FavoriteButtonFoldout = new GUIStyle(EditorStyles.toolbarButton)
      {
         name = "uScript_favoriteButtonFoldout",
         margin = new RectOffset(0, 0, 0, 0),
         padding = new RectOffset(2, 2, 0, 0)
      };

      FavoriteButtonName = new GUIStyle("ButtonRight")
      {
         name = "uScript_favoriteButtonName",
         alignment = TextAnchor.MiddleLeft,
         contentOffset = new Vector2(0, -1),
         margin = new RectOffset(0, 4, 0, 0),
         overflow = new RectOffset(0, 0, 1, 1),
         padding = new RectOffset(6, 6, 2, 2)
      };

      FavoriteButtonNumber = new GUIStyle("ButtonLeft")
      {
         name = "uScript_favoriteButtonNumber",
         alignment = TextAnchor.MiddleLeft,
         fontStyle = FontStyle.Bold,
         overflow = new RectOffset(0, 0, 1, 1),
         margin = new RectOffset(4, 0, 0, 0),
         padding = new RectOffset(7, 6, 1, 3)
      };

      FavoriteButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft)
      {
         name = "uScript_favoriteButtonLeft",
         margin = new RectOffset(4, 0, 1, 1),
         padding = new RectOffset(4, 4, 2, 2)
      };

      FavoriteButtonMiddle = new GUIStyle(EditorStyles.miniButtonMid)
      {
         name = "uScript_favoriteButtonMiddle",
         margin = new RectOffset(0, 0, 1, 1),
         padding = new RectOffset(4, 4, 2, 2)
      };

      FavoriteButtonRight = new GUIStyle(EditorStyles.miniButtonRight)
      {
         name = "uScript_favoriteButtonRight",
         margin = new RectOffset(0, 4, 1, 1),
         padding = new RectOffset(4, 4, 2, 2)
      };

      ContextMenu = new GUIStyle(EditorStyles.toolbarButton);

      MenuDropDownButtonShortcut = new GUIStyle(EditorStyles.largeLabel)
      {
         name = "menuDropDownButtonShortcut",
         fontStyle = FontStyle.Bold,
         margin = new RectOffset(),
         padding = new RectOffset()
      };

      MenuContextWindow = new GUIStyle(GUI.skin.window)
      {
         normal = { background = textureWindowMenuContext },
         onNormal = { background = textureWindowMenuContext },
         border = new RectOffset(10, 10, 10, 10),
         padding = new RectOffset(0, 0, 4, 4),
         overflow = new RectOffset(6, 6, 6, 6),
         contentOffset = Vector2.zero
      };

      MenuContextButton = new GUIStyle(EditorStyles.largeLabel)
      {
         name = "menuDropDownButton",
         active = { background = EditorStyles.toolbarButton.onActive.background },
         hover = { background = EditorStyles.toolbarButton.onNormal.background },
         border = EditorStyles.toolbarButton.border,
         margin = new RectOffset(),
         padding = new RectOffset(8, 8, 4, 4)
      };

      Outline = new GUIStyle(GUI.skin.box)
      {
         name = "uScript_outline",
         margin = new RectOffset(),
         padding = new RectOffset(),
         stretchHeight = false,
         stretchWidth = false
      };

      PanelMessage = new GUIStyle(GUI.skin.label) { wordWrap = true, padding = new RectOffset(16, 16, 16, 16) };

      PanelMessageBold = new GUIStyle(EditorStyles.boldLabel)
      {
         alignment = TextAnchor.MiddleCenter,
         wordWrap = true,
         padding = new RectOffset(16, 16, 16, 16)
      };

      PanelMessageError = new GUIStyle(GUI.skin.box)
      {
         normal = { textColor = EditorStyles.boldLabel.normal.textColor },
         font = EditorStyles.boldLabel.font,
         wordWrap = true,
         stretchWidth = true
      };

      Underline = new GUIStyle(EditorStyles.boldLabel)
      {
         normal = { background = textureUnderline },
         border = new RectOffset(0, 0, 0, 2),
         padding = new RectOffset(0, 0, 2, 2)
      };

      ReferenceButtonIcon = new GUIStyle(EditorStyles.miniButton)
      {
         name = "uScript_referenceButtonIcon",
         alignment = TextAnchor.MiddleCenter,
         imagePosition = ImagePosition.ImageOnly,
         padding = new RectOffset(),
         margin = new RectOffset(4, 4, 0, 0),
         fixedHeight = 20,
         fixedWidth = 20
      };

      ReferenceButtonText = new GUIStyle(EditorStyles.miniButton)
      {
         name = "uScript_referenceButtonText",
         alignment = TextAnchor.MiddleCenter,
         padding = new RectOffset(3, 6, 2, 4),
         margin = new RectOffset(4, 4, 0, 0),
         fontSize = 11,
         fixedHeight = 20
      };

      ReferenceDetailBox = new GUIStyle(GUI.skin.box)
      {
         name = "uScript_referenceDetailBox",
         margin = new RectOffset(24, 24, 16, 16),
         padding = new RectOffset(4, 4, 4, 4)
      };

      ReferenceDetailTitle = new GUIStyle(EditorStyles.boldLabel)
      {
         name = "uScript_referenceDetailTitle",
         margin = new RectOffset(),
         padding = new RectOffset(2, 2, 2, 3),
         stretchWidth = false
      };

      ReferenceDetailLabel = new GUIStyle(EditorStyles.boldLabel)
      {
         name = "uScript_referenceDetailLabel",
         margin = new RectOffset(),
         padding = new RectOffset(2, 2, 2, 3),
         stretchWidth = false
      };

      ReferenceDetailValue = new GUIStyle(ReferenceDetailLabel)
      {
         name = "uScript_referenceDetailValue",
         alignment = TextAnchor.MiddleRight,
         margin = new RectOffset(12, 0, 0, 0)
      };

      ReferenceDetailAlertLabel = new GUIStyle(EditorStyles.boldLabel)
      {
         name = "uScript_referenceDetailAlertLabel",
         margin = new RectOffset(),
         padding = new RectOffset(2, 2, 2, 3),
         normal = { textColor = Color.red },
         wordWrap = true
      };

      ReferenceDetailAlertValue = new GUIStyle(ReferenceDetailAlertLabel)
      {
         name = "uScript_referenceDetailAlertValue",
         alignment = TextAnchor.MiddleRight,
         margin = new RectOffset(12, 0, 0, 0)
      };

      ReferenceName = new GUIStyle(EditorStyles.boldLabel)
      {
         name = "referenceName",
         normal = { background = textureUnderline },
         border = new RectOffset(0, 0, 0, 2),
         padding = new RectOffset(0, 0, 2, 2)
      };

      ReferenceInfo = new GUIStyle(EditorStyles.miniLabel)
      {
         name = "uScript_referenceInfo",
         alignment = TextAnchor.LowerRight,
         padding = new RectOffset(0, 0, 3, 2)
      };

      ReferenceDesc = new GUIStyle(EditorStyles.label)
      {
         name = "referenceDesc",
         padding = new RectOffset(0, 0, 0, 3),
         stretchHeight = false,
         stretchWidth = true,
         wordWrap = true
      };

      PropertyButtonLeft = new GUIStyle("ButtonLeft")
      {
         name = "uScript_propertyButtonLeft",
         fixedHeight = 20,
         fixedWidth = 20,
         fontStyle = FontStyle.Bold,
         margin = new RectOffset(4, 0, 0, 0)
      };

      PropertyButtonMiddleDeprecated = new GUIStyle("ButtonMid")
      {
         name = "uScript_propertyButtonMiddleDeprecated",
         fixedHeight = 20,
         fontStyle = FontStyle.Bold,
         margin = new RectOffset()
      };

      PropertyButtonMiddleFavorite = new GUIStyle(PropertyButtonMiddleDeprecated)
      {
         name = "uScript_propertyButtonMiddleFavorite",
         alignment = TextAnchor.MiddleLeft,
         contentOffset = new Vector2(6, 0),
         fixedWidth = 30,
         padding = new RectOffset(12, 6, 2, 3)
      };

      PropertyButtonMiddleFavoriteStar = new GUIStyle(EditorStyles.largeLabel)
      {
         name = "uScript_propertyButtonMiddleFavoriteStar",
         padding = new RectOffset(4, 4, 0, 0),
         fontSize = 15
      };

      PropertyButtonMiddleName = new GUIStyle(PropertyButtonMiddleDeprecated)
      {
         name = "uScript_propertyButtonMiddleName",
         alignment = TextAnchor.MiddleLeft,
         fixedWidth = 0,
         contentOffset = Vector2.zero
      };

      PropertyButtonRightSearch = new GUIStyle("ButtonRight")
      {
         name = "uScript_propertyButtonRightSearch",
         fixedHeight = 20,
         fixedWidth = 20,
         fontStyle = FontStyle.Bold,
         margin = new RectOffset(0, 4, 0, 0),
         padding = new RectOffset()
      };

      PropertyButtonRightName = new GUIStyle(PropertyButtonRightSearch)
      {
         name = "uScript_propertyButtonRightName",
         alignment = TextAnchor.MiddleLeft,
         fixedWidth = 0,
         padding = ((GUIStyle)"ButtonRight").padding
      };

      PropertyTextArea = new GUIStyle(EditorStyles.textField) { margin = new RectOffset(4, 4, 2, 2), wordWrap = true };

      PropertyTextField = new GUIStyle(EditorStyles.textField) { margin = new RectOffset(4, 4, 2, 2) };

      PropertyBoolField = new GUIStyle(EditorStyles.toggle) { margin = new RectOffset(4, 4, 1, 1) };

      PropertyArrayIconButton = new GUIStyle(EditorStyles.miniButton)
      {
         margin = new RectOffset(4, 4, 2, 2),
         padding = new RectOffset(3, 3, 2, 2),
         stretchWidth = false
      };

      PropertyArrayTextButton = new GUIStyle(EditorStyles.miniButton)
      {
         fontStyle = FontStyle.Bold,
         padding = new RectOffset(0, 2, 1, 1),
         contentOffset = new Vector2(0, 1),
         alignment = TextAnchor.UpperCenter
      };

      PropertyRowOdd = new GUIStyle(GUIStyle.none) { fixedHeight = 20 };

      PropertyRowEven = new GUIStyle(PropertyRowOdd) { normal = { background = texturePropertyRowEven } };

      ScriptRowOdd = new GUIStyle(GUIStyle.none) { fixedHeight = 17 };

      ScriptRowEven = new GUIStyle(ScriptRowOdd) { normal = { background = texturePropertyRowEven } };

      ListRow = new GUIStyle(GUIStyle.none) { onNormal = { background = texturePropertyRowEven } };

      ToolbarLabel = new GUIStyle(EditorStyles.label)
      {
         padding = new RectOffset(4, 4, 2, 2),
         margin = new RectOffset()
      };
   }

   public static GUIStyle PaletteToolbarFoldoutButton { get; private set; }

   public static GUIStyle PaletteFoldout { get; private set; }

   public static GUIStyle PaletteButton { get; private set; }

   public static GUIStyle PanelBox { get; private set; }

   public static GUIStyle PanelHR { get; private set; }

   public static GUIStyle PanelTitle { get; private set; }

   public static GUIStyle PanelTitleDropDown { get; private set; }

   public static GUIStyle ReferenceText { get; private set; }

   public static GUIStyle ColumnHeader { get; private set; }

   public static GUIStyle HorizontalDivider { get; private set; }

   public static GUIStyle VerticalDivider { get; private set; }

   public static GUIStyle VerticalScrollbar { get; private set; }

   public static GUIStyle HorizontalScrollbar { get; private set; }

   public static GUIStyle VerticalColumnScrollbar { get; private set; }

   public static GUIStyle HorizontalColumnScrollbar { get; private set; }

   public static GUIStyle ColumnScrollView { get; private set; }

   public static GUIStyle FavoriteButtonFoldout { get; private set; }

   public static GUIStyle FavoriteButtonNumber { get; private set; }

   public static GUIStyle FavoriteButtonName { get; private set; }

   public static GUIStyle FavoriteButtonLeft { get; private set; }

   public static GUIStyle FavoriteButtonMiddle { get; private set; }

   public static GUIStyle FavoriteButtonRight { get; private set; }

   public static GUIStyle NodeButtonLeft { get; private set; }

   public static GUIStyle NodeButtonMiddle { get; private set; }

   public static GUIStyle NodeButtonRight { get; private set; }

   public static GUIStyle ContextMenu { get; private set; }

   public static GUIStyle MenuDropDownButtonShortcut { get; private set; }

   public static GUIStyle MenuContextWindow { get; private set; }

   public static GUIStyle MenuContextButton { get; private set; }

   public static GUIStyle Outline { get; private set; }

   public static GUIStyle PanelMessage { get; private set; }

   public static GUIStyle PanelMessageBold { get; private set; }

   public static GUIStyle PanelMessageError { get; private set; }

   public static GUIStyle PropertyButtonLeft { get; private set; }

   public static GUIStyle PropertyButtonMiddleDeprecated { get; private set; }

   public static GUIStyle PropertyButtonMiddleFavorite { get; private set; }

   public static GUIStyle PropertyButtonMiddleFavoriteStar { get; private set; }

   public static GUIStyle PropertyButtonMiddleName { get; private set; }

   public static GUIStyle PropertyButtonRightSearch { get; private set; }

   public static GUIStyle PropertyButtonRightName { get; private set; }

   public static GUIStyle PropertyArrayIconButton { get; private set; }

   public static GUIStyle PropertyArrayTextButton { get; private set; }

   public static GUIStyle PropertyBoolField { get; private set; }

   public static GUIStyle PropertyRowOdd { get; private set; }

   public static GUIStyle PropertyRowEven { get; private set; }

   public static GUIStyle PropertyTextArea { get; private set; }

   public static GUIStyle PropertyTextField { get; private set; }

   public static GUIStyle ReferenceInfo { get; private set; }

   public static GUIStyle ReferenceName { get; private set; }

   public static GUIStyle ReferenceDesc { get; private set; }

   public static GUIStyle ReferenceButtonIcon { get; private set; }

   public static GUIStyle ReferenceButtonText { get; private set; }

   public static GUIStyle ReferenceDetailBox { get; private set; }

   public static GUIStyle ReferenceDetailTitle { get; private set; }

   public static GUIStyle ReferenceDetailLabel { get; private set; }

   public static GUIStyle ReferenceDetailValue { get; private set; }

   public static GUIStyle ReferenceDetailAlertLabel { get; private set; }

   public static GUIStyle ReferenceDetailAlertValue { get; private set; }

   public static GUIStyle ScriptRowOdd { get; private set; }

   public static GUIStyle ScriptRowEven { get; private set; }

   public static GUIStyle ListRow { get; private set; }

   public static GUIStyle ToolbarLabel { get; private set; }

   public static GUIStyle Underline { get; private set; }

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
