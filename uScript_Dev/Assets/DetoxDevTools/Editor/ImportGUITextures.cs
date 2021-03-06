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

#if UNITY_5_5_OR_NEWER
      textureImporter.textureType = TextureImporterType.Default;
#else
      textureImporter.textureType = TextureImporterType.Advanced;
#endif
      textureImporter.SetPlatformTextureSettings("Standalone", 512, TextureImporterFormat.AutomaticTruecolor);
      textureImporter.npotScale = TextureImporterNPOTScale.None;
      textureImporter.ReadTextureSettings(textureSettings);
      textureSettings.mipmapEnabled = false;

      textureSettings.aniso = 0;
      textureSettings.filterMode = this.assetPath.Contains("Bilinear") ? FilterMode.Bilinear : FilterMode.Point;
      textureSettings.wrapMode = TextureWrapMode.Clamp;
      textureSettings.maxTextureSize = 512;
      textureSettings.textureFormat = TextureImporterFormat.AutomaticTruecolor;

      textureImporter.SetTextureSettings(textureSettings);
   }
}
