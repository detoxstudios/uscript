// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Preferences.cs" company="Detox Studios LLC">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the Preferences type used to store user settings and preferences in the uScript editor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using System.Diagnostics.CodeAnalysis;
   using UnityEditor;

   [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1107:CodeMustNotContainMultipleStatementsOnOneLine", Justification = "Reviewed. Suppression is OK here.")]
   public static class Preferences
   {
      public enum DoubleClickBehaviorType
      {
         PingSource,
         OpenSource,
         LoadGraphPingSource,
         LoadGraphOpenSource
      }

      public enum MenuLocationType
      {
         Default,
         Tools,
         Window,
         Custom
      }

      public enum SaveMethodType
      {
         Quick,
         Debug,
         Release
      }

      public enum VariableExpansionType
      {
         AlwaysExpanded,
         AlwaysCollapsed,
         Dynamic
      }

      public static string ProjectFiles
      {
         get { return UnityEngine.Application.dataPath + EditorPrefs.GetString("DetoxStudios.uScript.RelativeProjectFiles"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.RelativeProjectFiles", uScriptConfig.ConstantPaths.RelativePathInAssets(value)); }
      }

      public static string UserScripts
      {
         get { return UnityEngine.Application.dataPath + EditorPrefs.GetString("DetoxStudios.uScript.RelativeUserScripts"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.RelativeUserScripts", uScriptConfig.ConstantPaths.RelativePathInAssets(value)); }
      }

      public static string UserNodes
      {
         get { return UnityEngine.Application.dataPath + EditorPrefs.GetString("DetoxStudios.uScript.RelativeUserNodes"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.RelativeUserNodes", uScriptConfig.ConstantPaths.RelativePathInAssets(value)); }
      }

      public static string GeneratedScripts
      {
         get { return UnityEngine.Application.dataPath + EditorPrefs.GetString("DetoxStudios.uScript.RelativeGeneratedScripts"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.RelativeGeneratedScripts", uScriptConfig.ConstantPaths.RelativePathInAssets(value)); }
      }

      public static string NestedScripts
      {
         get { return UnityEngine.Application.dataPath + EditorPrefs.GetString("DetoxStudios.uScript.RelativeNestedScripts"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.RelativeNestedScripts", uScriptConfig.ConstantPaths.RelativePathInAssets(value)); }
      }

      public static bool AutoExpandToolbox
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.AutoExpandToolbox"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.AutoExpandToolbox", value); }
      }

      public static bool AutoUpdateReflection
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.AutoUpdateReflection"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.AutoUpdateReflection", value); }
      }

      public static bool DrawPanelsOnUpdate
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.DrawPanelsOnUpdate"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.DrawPanelsOnUpdate", value); }
      }

      public static int MaximumNodeRecursionCount
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.MaximumNodeRecursionCount"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.MaximumNodeRecursionCount", value); }
      }

      public static int MultilineHeight
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.MultilineHeight"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.MultilineHeight", value); }
      }

      public static SaveMethodType SaveMethod
      {
         get { return (SaveMethodType)System.Enum.Parse(typeof(SaveMethodType), EditorPrefs.GetString("DetoxStudios.uScript.SaveMethod")); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.SaveMethod", value.ToString()); }
      }

      public static MenuLocationType MenuLocation
      {
         get { return (MenuLocationType)System.Enum.Parse(typeof(MenuLocationType), EditorPrefs.GetString("DetoxStudios.uScript.MenuLocation")); }
         set
         {
            if (value != Preferences.MenuLocation)
            {
               GUI.MenuLocation.Change(value);
            }
            EditorPrefs.SetString("DetoxStudios.uScript.MenuLocation", value.ToString());
         }
      }

      public static bool ShowGrid
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.ShowGrid"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.ShowGrid", value); }
      }

      public static bool Profiling
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.Profiling"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.Profiling", value); }
      }

      public static float ProfileMin
      {
         get { return EditorPrefs.GetFloat("DetoxStudios.uScript.ProfileMin"); }
         set { EditorPrefs.SetFloat("DetoxStudios.uScript.ProfileMin", value); }
      }

      public static int GridSize
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.GridSize"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.GridSize", value); }
      }

      public static int GridSubdivisions
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.GridSubdivisions"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.GridSubdivisions", value); }
      }

      public static UnityEngine.Color GridColorMajor
      {
         get
         {
            UnityEngine.Color c;
            c.r = EditorPrefs.GetFloat("DetoxStudios.uScript.GridColorMajor.r");
            c.g = EditorPrefs.GetFloat("DetoxStudios.uScript.GridColorMajor.g");
            c.b = EditorPrefs.GetFloat("DetoxStudios.uScript.GridColorMajor.b");
            c.a = EditorPrefs.GetFloat("DetoxStudios.uScript.GridColorMajor.a");
            return c;
         }
         set
         {
            EditorPrefs.SetFloat("DetoxStudios.uScript.GridColorMajor.r", value.r);
            EditorPrefs.SetFloat("DetoxStudios.uScript.GridColorMajor.g", value.g);
            EditorPrefs.SetFloat("DetoxStudios.uScript.GridColorMajor.b", value.b);
            EditorPrefs.SetFloat("DetoxStudios.uScript.GridColorMajor.a", value.a);
         }
      }

      public static UnityEngine.Color GridColorMinor
      {
         get
         {
            UnityEngine.Color c;
            c.r = EditorPrefs.GetFloat("DetoxStudios.uScript.GridColorMinor.r");
            c.g = EditorPrefs.GetFloat("DetoxStudios.uScript.GridColorMinor.g");
            c.b = EditorPrefs.GetFloat("DetoxStudios.uScript.GridColorMinor.b");
            c.a = EditorPrefs.GetFloat("DetoxStudios.uScript.GridColorMinor.a");
            return c;
         }
         set
         {
            EditorPrefs.SetFloat("DetoxStudios.uScript.GridColorMinor.r", value.r);
            EditorPrefs.SetFloat("DetoxStudios.uScript.GridColorMinor.g", value.g);
            EditorPrefs.SetFloat("DetoxStudios.uScript.GridColorMinor.b", value.b);
            EditorPrefs.SetFloat("DetoxStudios.uScript.GridColorMinor.a", value.a);
         }
      }

      public static DoubleClickBehaviorType DoubleClickBehavior
      {
         get { return (DoubleClickBehaviorType)System.Enum.Parse(typeof(DoubleClickBehaviorType), EditorPrefs.GetString("DetoxStudios.uScript.DoubleClickBehavior")); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.DoubleClickBehavior", value.ToString()); }
      }

      public static VariableExpansionType VariableExpansion
      {
         get { return (VariableExpansionType)System.Enum.Parse(typeof(VariableExpansionType), EditorPrefs.GetString("DetoxStudios.uScript.VariableExpansion")); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.VariableExpansion", value.ToString()); }
      }

      public static bool GridSnap
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.GridSnap"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.GridSnap", value); }
      }

      public static bool ShowAtStartup
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.ShowAtStartup"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.ShowAtStartup", value); }
      }

      public static bool ShowAllHotkeys
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.ShowAllHotkeys"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.ShowAllHotkeys", value); }
      }

      public static bool LeftMouseButtonPrimary
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.LeftMouseButtonPrimary"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.LeftMouseButtonPrimary", value); }
      }

      public static bool CheckForUpdate
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.CheckForUpdate"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.CheckForUpdate", value); }
      }

      public static int LastPromotionCheck
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.LastPromotionCheck"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.LastPromotionCheck", value); }
      }

      public static string IgnorePromotions
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.IgnorePromotions"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.IgnorePromotions", value); }
      }

      public static int LastUpdateCheck
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.LastUpdateCheck"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.LastUpdateCheck", value); }
      }

      public static string IgnoreUpdateBuild
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.IgnoreUpdateBuild"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.IgnoreUpdateBuild", value); }
      }

      public static int PropertyPanelNodeLimit
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.PropertyPanelNodeLimit"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.PropertyPanelNodeLimit", value); }
      }

      public static float LineWidthMultiplier
      {
         get { return EditorPrefs.GetFloat("DetoxStudios.uScript.LineWidthMultiplier"); }
         set { EditorPrefs.SetFloat("DetoxStudios.uScript.LineWidthMultiplier", value); }
      }

      public static float LineSelectionTolerance
      {
         get { return EditorPrefs.GetFloat("DetoxStudios.uScript.LineSelectionTolerance"); }
         set { EditorPrefs.SetFloat("DetoxStudios.uScript.LineSelectionTolerance", value); }
      }

      public static bool EnableSceneWarning
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.EnableSceneWarning"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.EnableSceneWarning", value); }
      }

      public static bool EnableAttachOnSavePrompt
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.EnableAttachOnSavePrompt"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.EnableAttachOnSavePrompt", value); }
      }

      public static bool EnableContentsFieldSearch
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.EnableContentsFieldSearch"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.EnableContentsFieldSearch", value); }
      }

      public static bool AllowSaveInPlayMode
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.AllowSaveInPlayMode"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.AllowSaveInPlayMode", value); }
      }

      public static bool EnableVersionControle
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.EnableVersionControle"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.EnableVersionControle", value); }
      }

      public static bool ExpandFavoritePanel
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.ExpandFavoritePanel"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.ExpandFavoritePanel", value); }
      }

      public static string ProjectGraphListFilter
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.ProjectGraphListFilter"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.ProjectGraphListFilter", value); }
      }

      public static int ProjectGraphListOffset
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.ProjectGraphListOffset"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.ProjectGraphListOffset", value); }
      }

      public static string FavoriteNode1
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode1"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode1", value); }
      }

      public static string FavoriteNode2
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode2"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode2", value); }
      }

      public static string FavoriteNode3
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode3"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode3", value); }
      }

      public static string FavoriteNode4
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode4"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode4", value); }
      }

      public static string FavoriteNode5
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode5"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode5", value); }
      }

      public static string FavoriteNode6
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode6"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode6", value); }
      }

      public static string FavoriteNode7
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode7"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode7", value); }
      }

      public static string FavoriteNode8
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode8"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode8", value); }
      }

      public static string FavoriteNode9
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode9"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode9", value); }
      }

      public static string[] FavoriteNodes
      {
         get
         {
            return new[]
                      {
                         FavoriteNode1, FavoriteNode2, FavoriteNode3, FavoriteNode4, FavoriteNode5,
                         FavoriteNode6, FavoriteNode7, FavoriteNode8, FavoriteNode9
                      };
         }
      }

      public static string GraphListFolderStates
      {
         get { return EditorPrefs.GetString("DetoxStudios.uScript.GraphListFolderStates"); }
         set { EditorPrefs.SetString("DetoxStudios.uScript.GraphListFolderStates", value); }
      }

      public static bool RefreshOnHierarchyChange
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.RefreshOnHierarchyChange"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.RefreshOnHierarchyChange", value); }
      }

      public static bool ShowHierarchyIcon
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.ShowHierarchyIcon"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.ShowHierarchyIcon", value); }
      }

      public static bool PaletteVisible
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.PaletteVisible"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.PaletteVisible", value); }
      }

      public static bool ReferenceVisible
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.ReferenceVisible"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.ReferenceVisible", value); }
      }

      public static bool ScriptsVisible
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.ScriptsVisible"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.ScriptsVisible", value); }
      }

      public static bool PropertiesVisible
      {
         get { return EditorPrefs.GetBool("DetoxStudios.uScript.PropertiesVisible"); }
         set { EditorPrefs.SetBool("DetoxStudios.uScript.PropertiesVisible", value); }
      }

      public static int PanelLeftWidth
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.PanelLeftWidth"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.PanelLeftWidth", value); }
      }

      public static int PanelPropertiesHeight
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.PanelPropertiesHeight"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.PanelPropertiesHeight", value); }
      }

      public static int PanelPropertiesWidth
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.PanelPropertiesWidth"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.PanelPropertiesWidth", value); }
      }

      public static int PanelScriptsWidth
      {
         get { return EditorPrefs.GetInt("DetoxStudios.uScript.PanelScriptsWidth"); }
         set { EditorPrefs.SetInt("DetoxStudios.uScript.PanelScriptsWidth", value); }
      }

      public static bool ShouldDrawCollapsedVariable(bool selected)
      {
         return VariableExpansion != VariableExpansionType.AlwaysExpanded
                && (VariableExpansion == VariableExpansionType.AlwaysCollapsed
                    || selected == false);
      }

      public static string GetFavoriteNode(int number)
      {
         if (number < 1 || number > 9)
         {
            uScriptDebug.Log("An invalid Favorite number was specified: " + number, uScriptDebug.Type.Error);
            return string.Empty;
         }

         return EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode" + number);
      }

      public static void UpdateFavoriteNode(int number, string value)
      {
         if (number < 1 || number > 9)
         {
            uScriptDebug.Log("An invalid Favorite number was specified: " + number, uScriptDebug.Type.Error);
            return;
         }

         EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode" + number, value);
      }

      public static void SwapFavoriteNodes(int number1, int number2)
      {
         if (number1 < 1 || number1 > 9)
         {
            uScriptDebug.Log("An invalid Favorite number was specified: " + number1, uScriptDebug.Type.Error);
            return;
         }

         if (number2 < 1 || number2 > 9)
         {
            uScriptDebug.Log("An invalid Favorite number was specified: " + number2, uScriptDebug.Type.Error);
            return;
         }

         var original = EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode" + number1);
         EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode" + number1, EditorPrefs.GetString("DetoxStudios.uScript.FavoriteNode" + number2));
         EditorPrefs.SetString("DetoxStudios.uScript.FavoriteNode" + number2, original);
      }

      public static bool GetBool(string key, bool defaultValue)
      {
         if (!EditorPrefs.HasKey(key) && !EditorPrefs.HasKey(GetNewKey(key))) return defaultValue;
         return EditorPrefs.GetBool(GetNewKey(key));
      }

      public static float GetFloat(string key, float defaultValue)
      {
         if (!EditorPrefs.HasKey(key) && !EditorPrefs.HasKey(GetNewKey(key))) return defaultValue;
         return EditorPrefs.GetFloat(GetNewKey(key));
      }

      public static int GetInt(string key, int defaultValue)
      {
         if (!EditorPrefs.HasKey(key) && !EditorPrefs.HasKey(GetNewKey(key))) return defaultValue;
         return EditorPrefs.GetInt(GetNewKey(key));
      }

      public static string GetString(string key, string defaultValue)
      {
         if (!EditorPrefs.HasKey(key) && !EditorPrefs.HasKey(GetNewKey(key))) return defaultValue;
         return EditorPrefs.GetString(GetNewKey(key));
      }

      public static void SetBool(string key, bool value)
      {
         EditorPrefs.SetBool(GetNewKey(key), value);
      }

      public static void SetFloat(string key, float value)
      {
         EditorPrefs.SetFloat(GetNewKey(key), value);
      }

      public static void SetInt(string key, int value)
      {
         EditorPrefs.SetInt(GetNewKey(key), value);
      }

      public static void SetString(string key, string value)
      {
         EditorPrefs.SetString(GetNewKey(key), value);
      }

      public static void Revert()
      {
         // force save defaults
         LoadDefaultsIfRequired(true);
      }

      private static string GetNewKey(string key)
      {
         if (!key.Contains("DetoxStudios.uScript."))
         {
            string newKey = "DetoxStudios.";

            if (key.Contains("uScript\\"))
            {
               newKey += key.Replace("uScript\\", "uScript.");
            }
            else
            {
               newKey += "uScript." + key;
            }

            return newKey;
         }

         return key;
      }

      public static void SavePreference(string key, object value)
      {
         string newKey = GetNewKey(key);

         if (value.GetType() == typeof(float))
         {
            EditorPrefs.SetFloat(newKey, (float)value);
         }
         else if (value.GetType() == typeof(int))
         {
            EditorPrefs.SetInt(newKey, (int)value);
         }
         else if (value.GetType() == typeof(bool))
         {
            EditorPrefs.SetBool(newKey, (bool)value);
         }
         else if (value.GetType() == typeof(string))
         {
            EditorPrefs.SetString(newKey, (string)value);
         }
         else if (value.GetType() == typeof(UnityEngine.Color))
         {
            UnityEngine.Color c = (UnityEngine.Color)value;
            EditorPrefs.SetFloat(newKey + ".r", c.r);
            EditorPrefs.SetFloat(newKey + ".g", c.g);
            EditorPrefs.SetFloat(newKey + ".b", c.b);
            EditorPrefs.SetFloat(newKey + ".a", c.a);
         }
         else
         {
            EditorPrefs.SetString(newKey, value.ToString());
         }
      }

      [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1025:CodeMustNotContainMultipleWhitespaceInARow", Justification = "Reviewed. Suppression is OK here.")]
      [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1503:CurlyBracketsMustNotBeOmitted", Justification = "Reviewed. Suppression is OK here.")]
      public static void LoadDefaultsIfRequired(bool force = false)
      {
         SetDefault("AutoExpandToolbox", true, force);
         SetDefault("AutoUpdateReflection", false, force);
         SetDefault("DrawPanelsOnUpdate", false, force);
         SetDefault("ShowGrid", uScriptConfig.Style.ShowGrid, force);
         SetDefault("GridSize", uScriptConfig.Style.GridSize, force);
         SetDefault("GridSubdivisions", uScriptConfig.Style.GridSubdivisions, force);
         SetDefault("GridColorMajor", uScriptConfig.Style.GridColorMajor, force);
         SetDefault("GridColorMinor", uScriptConfig.Style.GridColorMinor, force);
         SetDefault("DoubleClickBehavior", DoubleClickBehaviorType.PingSource.ToString(), force);
         SetDefault("VariableExpansion", VariableExpansionType.Dynamic.ToString(), force);
         SetDefault("GridSnap", false, force);
         SetDefault("ShowAtStartup", true, force);
         SetDefault("ShowAllHotkeys", false, force);
         SetDefault("LeftMouseButtonPrimary", true, force);
         SetDefault("CheckForUpdate", true, force);
         SetDefault("LastPromotionCheck", 0, force);
         SetDefault("IgnorePromotions", string.Empty, force);
         SetDefault("LastUpdateCheck", 0, force);  
         SetDefault("IgnoreUpdateBuild", string.Empty, force);

         SetDefault("RelativeProjectFiles", uScriptConfig.ConstantPaths.RelativePathInAssets(UnityEngine.Application.dataPath + "/uScriptProjectFiles"), force);
         SetDefault("RelativeUserScripts", uScriptConfig.ConstantPaths.RelativePathInAssets(ProjectFiles + "/uScripts"), force);
         SetDefault("RelativeUserNodes", uScriptConfig.ConstantPaths.RelativePathInAssets(ProjectFiles + "/Nodes"), force);
         SetDefault("RelativeNestedScripts", uScriptConfig.ConstantPaths.RelativePathInAssets(UserScripts + "/_GeneratedCode"), force);
         SetDefault("RelativeGeneratedScripts", uScriptConfig.ConstantPaths.RelativePathInAssets(UserScripts + "/_GeneratedCode"), force);
         SetDefault("MaximumNodeRecursionCount", 1000, force);
         SetDefault("MultilineHeight", 3, force);
         SetDefault("SaveMethod", SaveMethodType.Debug.ToString(), force);
         SetDefault("MenuLocation", MenuLocationType.Tools.ToString(), force);
         SetDefault("ProfileMin", 1f, force);
         SetDefault("Profiling", false, force);
         SetDefault("PropertyPanelNodeLimit", 1, force);

         SetDefault("ExpandFavoritePanel", true, force);

         SetDefault("ProjectGraphListFilter", string.Empty, force);
         SetDefault("ProjectGraphListOffset", 0, force);

         SetDefault("FavoriteNode1", string.Empty, force);
         SetDefault("FavoriteNode2", string.Empty, force);
         SetDefault("FavoriteNode3", string.Empty, force);
         SetDefault("FavoriteNode4", string.Empty, force);
         SetDefault("FavoriteNode5", string.Empty, force);
         SetDefault("FavoriteNode6", string.Empty, force);
         SetDefault("FavoriteNode7", string.Empty, force);
         SetDefault("FavoriteNode8", string.Empty, force);
         SetDefault("FavoriteNode9", string.Empty, force);

         SetDefault("GraphListFolderStates", string.Empty, force);

         SetDefault("RefreshOnHierarchyChange", true, force);

         SetDefault("ShowHierarchyIcon", true, force);
         SetDefault("LineWidthMultiplier", 1.0f, force);
         SetDefault("LineSelectionTolerance", 8.0f, force);
         SetDefault("EnableSceneWarning", true, force);
         SetDefault("EnableAttachOnSavePrompt", true, force);
         SetDefault("EnableContentsFieldSearch", true, force);
         SetDefault("AllowSaveInPlayMode", false, force);
         SetDefault("EnableVersionControl", true, force);

         SetDefault("PaletteVisible", true, force);
         SetDefault("ReferenceVisible", true, force);
         SetDefault("ScriptsVisible", true, force);
         SetDefault("PropertiesVisible", true, force);
         SetDefault("PanelLeftWidth", 265, force);
         SetDefault("PanelPropertiesHeight", 250, force);
         SetDefault("PanelPropertiesWidth", 500, force);
         SetDefault("PanelScriptsWidth", 300, force);
      }

      private static void SetDefault(string key, object value, bool force)
      {
         if (force || EditorPrefs.HasKey(GetNewKey(key)) == false)
         {
            SavePreference(key, value);
         }
      }
   }
}
