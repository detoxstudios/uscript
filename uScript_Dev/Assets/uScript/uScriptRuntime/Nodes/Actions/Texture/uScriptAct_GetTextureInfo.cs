// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Texture")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Gets information about the target Texture2D variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Texture2D Info", "Gets information about the target Texture2D variable. See Unity's documentation on Texture2D for more information.")]
public class uScriptAct_GetTextureInfo : uScriptLogic
{

   public bool Out { get { return true; } }
	

   // Parameter Attributes are applied below in Stop()
   public void In(
		[FriendlyName("Target", "The target Texture2D variable.")]
		Texture2D target,
		[FriendlyName("Width", "The width of the texture as an int variable.")]
		out int width,
		[FriendlyName("Height", "The height of the texture as an int variable.")]
		out int height,
		[FriendlyName("Size", "The size of the texture as a Vector2 variable (width, height).")]
		[SocketState(false, false)]
		out Vector2 size,
		[FriendlyName("Filter Mode", "The current filter mode of the texture.")]
		[SocketState(false, false)]
		out UnityEngine.FilterMode filterMode,
		[FriendlyName("Anisotropic Level", "The current anisotropic filtering level of the texture.")]
		[SocketState(false, false)]
		out int anisoLevel,
		[FriendlyName("Wrap Mode", "The current wrap mode setting of the texture (Repeat or Clamp).")]
		[SocketState(false, false)]
		out UnityEngine.TextureWrapMode wrapMode,
		[FriendlyName("Mip Map Bias", "The current mip map bias of the texture.")]
		[SocketState(false, false)]
		out float mipMapBias,
		[FriendlyName("Texture Name", "The current name of the Texture2D as a string variable.")]
		[SocketState(false, false)]
		out string name
		)
   {
		if (null != target)
		{
			size = new Vector2(target.width, target.height);
			width = target.width;
			height = target.height;
			filterMode = target.filterMode;
			anisoLevel = target.anisoLevel;
			wrapMode = target.wrapMode;
			mipMapBias = target.mipMapBias;
			name = target.name;
		}
		else
		{
			size = new Vector2(0, 0);
			width = 0;
			height = 0;
			filterMode = UnityEngine.FilterMode.Point;
			anisoLevel = 0;
			wrapMode = UnityEngine.TextureWrapMode.Clamp;
			mipMapBias = 0f;
			name = "null";
		}
   }
	
}
