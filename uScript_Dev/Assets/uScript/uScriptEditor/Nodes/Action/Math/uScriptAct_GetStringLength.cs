// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the number of characters in a string as a float, integer, and string.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the number of characters in a string as a float, integer, and string.")]
[NodeDescription("Returns the number of characters in a string as a float, integer, and string.\n \nTarget: The Target string to get the length of.\nInt Value (out): The length of the Target string, expressed as an integer.\nFloat Value (out): The length of the Target string, expressed as a floating point number.\nString Value (out): The length of the Target string, expressed as a string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get String Length")]
public class uScriptAct_GetStringLength : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(string Target, [FriendlyName("Int Value")] out int IntValue, [FriendlyName("Float Value")] out float FloatValue, [FriendlyName("String Value")] out string StringValue)
   {
      int countInt;
      float countFloat;
      string countString;

      if (!string.IsNullOrEmpty(Target))
      {
         countInt = Target.Length;
         countFloat = System.Convert.ToSingle(Target.Length);
         countString = Target.Length.ToString();
      }
      else
      {
         countInt = 0;
         countFloat = 0F;
         countString = "0";  
      }

      IntValue = countInt;
      FloatValue = countFloat;
      StringValue = countString;
   }
}