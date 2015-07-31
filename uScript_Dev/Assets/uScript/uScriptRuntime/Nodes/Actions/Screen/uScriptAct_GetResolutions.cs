using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Get supported resolutions.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

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
