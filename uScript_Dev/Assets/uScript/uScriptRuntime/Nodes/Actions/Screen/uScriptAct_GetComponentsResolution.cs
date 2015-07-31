// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Resolution")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Resolution.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Components (Resolution)", "Gets the components of a Resolution.")]
public class uScriptAct_GetComponentsResolution : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Input Resolution", "The input resolution to get components of.")]
      Resolution InputResolution,
      
      [FriendlyName("Width", "The width of the Resolution.")]
      out int width,
      
      [FriendlyName("Height", "The height of the Resolution.")]
      out int height,
      
      [FriendlyName("Refresh Rate", "The refresh rate of the Resolution.")]
      out int refreshRate
      )
   {
      width = InputResolution.width;
      height = InputResolution.height;
      refreshRate = InputResolution.refreshRate;
   }
}
