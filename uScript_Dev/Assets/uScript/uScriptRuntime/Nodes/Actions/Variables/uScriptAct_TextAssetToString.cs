// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/TextAsset")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Converts a TextAsset into a string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("TextAsset To String", "Converts a TextAsset into a string. It will also return the name of the TextAsset.")]
public class uScriptAct_TextAssetToString : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      TextAsset Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out string Target,
	  
	  [FriendlyName("Name", "The name of the TextAsset."), SocketState(false, false)]
      out string FileName
      )
   {
       Target = Value.text;
	   FileName = Value.name;
   }
}
