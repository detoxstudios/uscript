// uScript Action Node
// (C) 2012 Detox Studios LLC
#if UNITY_3_4 || UNITY_3_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Quality Settings")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the Anti-aliasing on the current Quality Settings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Anti-aliasing", "Sets the Anti-aliasing on the current Quality Settings.")]
public class uScriptAct_QualitySettingsSetAntiAliasing : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Value", "The value to set on this quality setting. The Anti-aliasing filter can be set to either 0, 2, 4 or 8. This coresponds to the number of multisamples used per pixel.")] int Value)
   {
      bool goodValue = false;

      if (Value == 0)
      {
         goodValue = true;
      }
      else if (Value == 2)
      {
         goodValue = true;
      }
      else if (Value == 4)
      {
         goodValue = true;
      }
      else if (Value == 8)
      {
         goodValue = true;
      }
      else
      {
      }

      if (goodValue)
      {
         QualitySettings.antiAliasing = Value;
      }
      
   }
}
#endif