using UnityEngine;
using System.Collections;
using UnityEditor;


class ImportGUITextures : AssetPostprocessor
{
   void OnPreprocessTexture()
   {

      if (assetPath.Contains("_GUI"))
      {
         TextureImporter textureImporter = (TextureImporter)assetImporter;
         TextureImporterSettings textureSettings = new TextureImporterSettings();

         textureImporter.textureType = TextureImporterType.Advanced;
         textureImporter.SetPlatformTextureSettings("Standalone", 512, TextureImporterFormat.AutomaticTruecolor, 100);
         textureImporter.npotScale = TextureImporterNPOTScale.None;
         textureImporter.ReadTextureSettings(textureSettings);
         textureSettings.mipmapEnabled = false;
         textureSettings.linearTexture = true;

         textureSettings.aniso = 0;
         textureSettings.filterMode = FilterMode.Point;
         textureSettings.wrapMode = TextureWrapMode.Clamp;
         textureSettings.maxTextureSize = 512;
         textureSettings.textureFormat = TextureImporterFormat.AutomaticTruecolor;




         textureImporter.SetTextureSettings(textureSettings);

      }

   }

}
