using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Get supported resolutions.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Resolutions", "Gets the resolutions supported by the device.")]
public class uScriptAct_GetResolutions : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Resolutions", "The resolutions supported by the device.")]
      out Resolution[] resolutions
      )
   {
      resolutions = Screen.resolutions;
      //Debug.Log("returning " + resolutions.Length);
   }
}
