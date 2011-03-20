using UnityEngine;
using System.Collections;
using UnityEditor;


class ImportGUITextures : AssetPostprocessor
{
    void OnPreprocessTexture()
	{
		
        if (assetPath.Contains("_GUI")) {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
			TextureImporterSettings textureSettings = new TextureImporterSettings();
			
			textureImporter.SetPlatformTextureSettings("Standalone", 512, TextureImporterFormat.AutomaticTruecolor);
			textureImporter.npotScale = TextureImporterNPOTScale.None;
			textureImporter.ReadTextureSettings(textureSettings);
            textureSettings.wrapMode = TextureWrapMode.Clamp;
            textureImporter.SetTextureSettings(textureSettings);

        }
        
    }
	
}
