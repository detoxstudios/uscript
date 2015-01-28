// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Preferences.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the Preferences type used to store user settings and preferences in the uScript editor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1107:CodeMustNotContainMultipleStatementsOnOneLine", Justification = "Reviewed. Suppression is OK here.")]
public class Preferences
{
   private Hashtable preferences;

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

   public string ProjectFiles
   {
      get { this.LoadIfRequired(); return UnityEngine.Application.dataPath + (this.preferences["RelativeProjectFiles"] as string); }
      set { this.LoadIfRequired(); this.preferences["RelativeProjectFiles"] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }
   }

   public string UserScripts
   {
      get { this.LoadIfRequired(); return UnityEngine.Application.dataPath + (this.preferences["RelativeUserScripts"] as string); }
      set { this.LoadIfRequired(); this.preferences["RelativeUserScripts"] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }
   }

   public string UserNodes
   {
      get { this.LoadIfRequired(); return UnityEngine.Application.dataPath + (this.preferences["RelativeUserNodes"] as string); }
      set { this.LoadIfRequired(); this.preferences["RelativeUserNodes"] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }
   }

   public string GeneratedScripts
   {
      get { this.LoadIfRequired(); return UnityEngine.Application.dataPath + (this.preferences["RelativeGeneratedScripts"] as string); }
      set { this.LoadIfRequired(); this.preferences["RelativeGeneratedScripts"] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }
   }

   public string NestedScripts
   {
      get { this.LoadIfRequired(); return UnityEngine.Application.dataPath + (this.preferences["RelativeNestedScripts"] as string); }
      set { this.LoadIfRequired(); this.preferences["RelativeNestedScripts"] = uScriptConfig.ConstantPaths.RelativePathInAssets(value); }
   }

   public bool AutoExpandToolbox
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["AutoExpandToolbox"]; }
      set { this.LoadIfRequired(); this.preferences["AutoExpandToolbox"] = value; }
   }

   public bool DrawPanelsOnUpdate
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["DrawPanelsOnUpdate"]; }
      set { this.LoadIfRequired(); this.preferences["DrawPanelsOnUpdate"] = value; }
   }

   public int MaximumNodeRecursionCount
   {
      get { this.LoadIfRequired(); return (int)this.preferences["MaximumNodeRecursionCount"]; }
      set { this.LoadIfRequired(); this.preferences["MaximumNodeRecursionCount"] = value; }
   }

   public SaveMethodType SaveMethod
   {
      get { this.LoadIfRequired(); return (SaveMethodType)this.preferences["SaveMethod"]; }
      set { this.LoadIfRequired(); this.preferences["SaveMethod"] = value; }
   }

   public MenuLocationType MenuLocation
   {
      get { this.LoadIfRequired(); return (MenuLocationType)this.preferences["MenuLocation"]; }
      set { this.LoadIfRequired(); this.preferences["MenuLocation"] = value; }
   }

   public bool ShowGrid
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["ShowGrid"]; }
      set { this.LoadIfRequired(); this.preferences["ShowGrid"] = value; }
   }

   public bool Profiling
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["Profiling"]; }
      set { this.LoadIfRequired(); this.preferences["Profiling"] = value; }
   }

   public float ProfileMin
   {
      get { this.LoadIfRequired(); return (float)this.preferences["ProfileMin"]; }
      set { this.LoadIfRequired(); this.preferences["ProfileMin"] = value; }
   }

   public int GridSize
   {
      get { this.LoadIfRequired(); return (int)this.preferences["GridSize"]; }
      set { this.LoadIfRequired(); this.preferences["GridSize"] = value; }
   }

   public int GridSubdivisions
   {
      get { this.LoadIfRequired(); return (int)this.preferences["GridSubdivisions"]; }
      set { this.LoadIfRequired(); this.preferences["GridSubdivisions"] = value; }
   }

   public UnityEngine.Color GridColorMajor
   {
      get { this.LoadIfRequired(); return (UnityEngine.Color)this.preferences["GridColorMajor"]; }
      set { this.LoadIfRequired(); this.preferences["GridColorMajor"] = value; }
   }

   public UnityEngine.Color GridColorMinor
   {
      get { this.LoadIfRequired(); return (UnityEngine.Color)this.preferences["GridColorMinor"]; }
      set { this.LoadIfRequired(); this.preferences["GridColorMinor"] = value; }
   }

   public DoubleClickBehaviorType DoubleClickBehavior
   {
      get { this.LoadIfRequired(); return (DoubleClickBehaviorType)this.preferences["DoubleClickBehavior"]; }
      set { this.LoadIfRequired(); this.preferences["DoubleClickBehavior"] = value; }
   }

   public VariableExpansionType VariableExpansion
   {
      get { this.LoadIfRequired(); return (VariableExpansionType)this.preferences["VariableExpansion"]; }
      set { this.LoadIfRequired(); this.preferences["VariableExpansion"] = value; }
   }

   public bool GridSnap
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["GridSnap"]; }
      set { this.LoadIfRequired(); this.preferences["GridSnap"] = value; }
   }

   public bool ShowAtStartup
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["ShowAtStartup"]; }
      set { this.LoadIfRequired(); this.preferences["ShowAtStartup"] = value; }
   }

   public bool ShowAllHotkeys
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["ShowAllHotkeys"]; }
      set { this.LoadIfRequired(); this.preferences["ShowAllHotkeys"] = value; }
   }

   public bool LeftMouseButtonPrimary
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["LeftMouseButtonPrimary"]; }
      set { this.LoadIfRequired(); this.preferences["LeftMouseButtonPrimary"] = value; }
   }

   public bool CheckForUpdate
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["CheckForUpdate"]; }
      set { this.LoadIfRequired(); this.preferences["CheckForUpdate"] = value; }
   }

   public int LastUpdateCheck
   {
      get { this.LoadIfRequired(); return (int)this.preferences["LastUpdateCheck"]; }
      set { this.LoadIfRequired(); this.preferences["LastUpdateCheck"] = value; }
   }

   public string IgnoreUpdateBuild
   {
      get { this.LoadIfRequired(); return this.preferences["IgnoreUpdateBuild"] as string; }
      set { this.LoadIfRequired(); this.preferences["IgnoreUpdateBuild"] = value; }
   }

   public int PropertyPanelNodeLimit
   {
      get { this.LoadIfRequired(); return (int)this.preferences["PropertyPanelNodeLimit"]; }
      set { this.LoadIfRequired(); this.preferences["PropertyPanelNodeLimit"] = value; }
   }

   public bool ExpandFavoritePanel
   {
      get { this.LoadIfRequired(); return (bool)this.preferences["ExpandFavoritePanel"]; }
      set { this.LoadIfRequired(); this.preferences["ExpandFavoritePanel"] = value; }
   }

   public string ProjectGraphListFilter
   {
      get { this.LoadIfRequired(); return this.preferences["ProjectGraphListFilter"] as string; }
      set { this.LoadIfRequired(); this.preferences["ProjectGraphListFilter"] = value; }
   }

   public int ProjectGraphListOffset
   {
      get { this.LoadIfRequired(); return (int)this.preferences["ProjectGraphListOffset"]; }
      set { this.LoadIfRequired(); this.preferences["ProjectGraphListOffset"] = value; }
   }

   public string FavoriteNode1
   {
      get { this.LoadIfRequired(); return this.preferences["FavoriteNode1"] as string; }
      set { this.LoadIfRequired(); this.preferences["FavoriteNode1"] = value; }
   }

   public string FavoriteNode2
   {
      get { this.LoadIfRequired(); return this.preferences["FavoriteNode2"] as string; }
      set { this.LoadIfRequired(); this.preferences["FavoriteNode2"] = value; }
   }

   public string FavoriteNode3
   {
      get { this.LoadIfRequired(); return this.preferences["FavoriteNode3"] as string; }
      set { this.LoadIfRequired(); this.preferences["FavoriteNode3"] = value; }
   }

   public string FavoriteNode4
   {
      get { this.LoadIfRequired(); return this.preferences["FavoriteNode4"] as string; }
      set { this.LoadIfRequired(); this.preferences["FavoriteNode4"] = value; }
   }

   public string FavoriteNode5
   {
      get { this.LoadIfRequired(); return this.preferences["FavoriteNode5"] as string; }
      set { this.LoadIfRequired(); this.preferences["FavoriteNode5"] = value; }
   }

   public string FavoriteNode6
   {
      get { this.LoadIfRequired(); return this.preferences["FavoriteNode6"] as string; }
      set { this.LoadIfRequired(); this.preferences["FavoriteNode6"] = value; }
   }

   public string FavoriteNode7
   {
      get { this.LoadIfRequired(); return this.preferences["FavoriteNode7"] as string; }
      set { this.LoadIfRequired(); this.preferences["FavoriteNode7"] = value; }
   }

   public string FavoriteNode8
   {
      get { this.LoadIfRequired(); return this.preferences["FavoriteNode8"] as string; }
      set { this.LoadIfRequired(); this.preferences["FavoriteNode8"] = value; }
   }

   public string FavoriteNode9
   {
      get { this.LoadIfRequired(); return this.preferences["FavoriteNode9"] as string; }
      set { this.LoadIfRequired(); this.preferences["FavoriteNode9"] = value; }
   }

   public string[] FavoriteNodes
   {
      get
      {
         return new[]
                {
                   this.FavoriteNode1, this.FavoriteNode2, this.FavoriteNode3, this.FavoriteNode4, this.FavoriteNode5,
                   this.FavoriteNode6, this.FavoriteNode7, this.FavoriteNode8, this.FavoriteNode9
                };
      }
   }

   public string GraphListFolderStates
   {
      get { this.LoadIfRequired(); return this.preferences["GraphListFolderStates"] as string; }
      set { this.LoadIfRequired(); this.preferences["GraphListFolderStates"] = value; }
   }

	public bool ShowHierarchyIcon
	{
		get { this.LoadIfRequired(); return (bool)this.preferences["ShowHierarchyIcon"]; }
		set { this.LoadIfRequired(); this.preferences["ShowHierarchyIcon"] = value; }
	}

   public string GetFavoriteNode(int number)
   {
      if (number < 1 || number > 9)
      {
         uScriptDebug.Log("An invalid Favorite number was specified: " + number, uScriptDebug.Type.Error);
         return string.Empty;
      }

      return this.preferences["FavoriteNode" + number] as string;
   }

   public void UpdateFavoriteNode(int number, string value)
   {
      if (number < 1 || number > 9)
      {
         uScriptDebug.Log("An invalid Favorite number was specified: " + number, uScriptDebug.Type.Error);
         return;
      }

      this.preferences["FavoriteNode" + number] = value;
      this.Save();
   }

   public void SwapFavoriteNodes(int number1, int number2)
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

      var original = this.preferences["FavoriteNode" + number1] as string;
      this.preferences["FavoriteNode" + number1] = this.preferences["FavoriteNode" + number2];
      this.preferences["FavoriteNode" + number2] = original;
      this.Save();
   }

   public void Revert()
   {
      //clear out the hash table
      //to force the defaults to load
      this.preferences.Clear();

      this.LoadDefaultsIfRequired();
   }

   public void Load()
   {
      var hashtable = uScript.GetSetting("Preferences") as Hashtable ?? new Hashtable();

      this.preferences = new Hashtable(hashtable);

      this.LoadDefaultsIfRequired();
   }

   public void Save()
   {
      this.LoadIfRequired();

      uScript.SetSetting("Preferences", new Hashtable(this.preferences));
   }

   [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1025:CodeMustNotContainMultipleWhitespaceInARow", Justification = "Reviewed. Suppression is OK here.")]
   [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1503:CurlyBracketsMustNotBeOmitted", Justification = "Reviewed. Suppression is OK here.")]
   private void LoadDefaultsIfRequired()
   {
      this.SetDefault("AutoExpandToolbox", true);
      this.SetDefault("DrawPanelsOnUpdate", false);
      this.SetDefault("ShowGrid", uScriptConfig.Style.ShowGrid);
      this.SetDefault("GridSize", uScriptConfig.Style.GridSize);
      this.SetDefault("GridSubdivisions", uScriptConfig.Style.GridSubdivisions);
      this.SetDefault("GridColorMajor", uScriptConfig.Style.GridColorMajor);
      this.SetDefault("GridColorMinor", uScriptConfig.Style.GridColorMinor);
      this.SetDefault("DoubleClickBehavior", DoubleClickBehaviorType.PingSource);
      this.SetDefault("VariableExpansion", VariableExpansionType.Dynamic);
      this.SetDefault("GridSnap", false);
      this.SetDefault("ShowAtStartup", true);
      this.SetDefault("ShowAllHotkeys", false);
      this.SetDefault("LeftMouseButtonPrimary", true);
      this.SetDefault("CheckForUpdate", true);
      this.SetDefault("LastUpdateCheck", 0);
      this.SetDefault("IgnoreUpdateBuild", string.Empty);

      this.SetDefault("RelativeProjectFiles", uScriptConfig.ConstantPaths.RelativePathInAssets(UnityEngine.Application.dataPath + "/uScriptProjectFiles"));
      this.SetDefault("RelativeUserScripts", uScriptConfig.ConstantPaths.RelativePathInAssets(this.ProjectFiles + "/uScripts"));
      this.SetDefault("RelativeUserNodes", uScriptConfig.ConstantPaths.RelativePathInAssets(this.ProjectFiles + "/Nodes"));
      this.SetDefault("RelativeNestedScripts", uScriptConfig.ConstantPaths.RelativePathInAssets(this.UserScripts + "/_GeneratedCode"));
      this.SetDefault("RelativeGeneratedScripts", uScriptConfig.ConstantPaths.RelativePathInAssets(this.UserScripts + "/_GeneratedCode"));
      this.SetDefault("MaximumNodeRecursionCount", 1000);
      this.SetDefault("SaveMethod", 1); // 0:Quick, 1:Debug, 2:Release
      this.SetDefault("MenuLocation", 1); // 0:Default, 1:Tools, 2:Window  // TODO: Default to 0 in a new project
      this.SetDefault("ProfileMin", 1f);
      this.SetDefault("Profiling", false);
      this.SetDefault("PropertyPanelNodeLimit", 1);

      this.SetDefault("ExpandFavoritePanel", true);

      this.SetDefault("ProjectGraphListFilter", string.Empty);
      this.SetDefault("ProjectGraphListOffset", 0);

      this.SetDefault("FavoriteNode1", string.Empty);
      this.SetDefault("FavoriteNode2", string.Empty);
      this.SetDefault("FavoriteNode3", string.Empty);
      this.SetDefault("FavoriteNode4", string.Empty);
      this.SetDefault("FavoriteNode5", string.Empty);
      this.SetDefault("FavoriteNode6", string.Empty);
      this.SetDefault("FavoriteNode7", string.Empty);
      this.SetDefault("FavoriteNode8", string.Empty);
      this.SetDefault("FavoriteNode9", string.Empty);

      this.SetDefault("GraphListFolderStates", string.Empty);

      this.SetDefault("ShowHierarchyIcon", true);
   }

   private void LoadIfRequired()
   {
      if (null == this.preferences)
      {
         this.Load();
      }
   }

   private void SetDefault(string key, object value)
   {
      if (this.preferences.ContainsKey(key) == false)
      {
         this.preferences.Add(key, value);
      }
   }
}
