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

}
