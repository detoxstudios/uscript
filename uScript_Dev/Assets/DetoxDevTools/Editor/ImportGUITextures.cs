// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImportGUITextures.cs" company="Detox Studios, LLC">
//   Copyright 2010-2014 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ImportGUITextures type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UnityEditor;

using UnityEngine;

internal class ImportGUITextures : AssetPostprocessor
{
   private void OnPreprocessTexture()
   {
      if (!this.assetPath.Contains("_GUI")
         && !this.assetPath.Contains("Editor Default Resources/Icons"))
      {
         return;
      }

      var textureImporter = (TextureImporter)this.assetImporter;
      var textureSettings = new TextureImporterSettings();

      textureImporter.textureType = TextureImporterType.Advanced;
#if UNITY_3_5
         textureImporter.SetPlatformTextureSettings("Standalone", 512, TextureImporterFormat.AutomaticTruecolor, 100);
#else
      textureImporter.SetPlatformTextureSettings("Standalone", 512, TextureImporterFormat.AutomaticTruecolor);
#endif
      textureImporter.npotScale = TextureImporterNPOTScale.None;
      textureImporter.ReadTextureSettings(textureSettings);
      textureSettings.mipmapEnabled = false;
#if UNITY_3_5
         textureSettings.linearTexture = true;
#endif

      textureSettings.aniso = 0;
      textureSettings.filterMode = FilterMode.Point;
      textureSettings.wrapMode = TextureWrapMode.Clamp;
      textureSettings.maxTextureSize = 512;
      textureSettings.textureFormat = TextureImporterFormat.AutomaticTruecolor;

      textureImporter.SetTextureSettings(textureSettings);
   }
}
