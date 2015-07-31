// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the number of characters in a string as a float, integer, and string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get String Length", "Returns the number of characters in a string as a float, integer, and string.")]
public class uScriptAct_GetStringLength : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target string to get the length of.")]
      string Target,
      
      [FriendlyName("Result", "The length of the Target string, expressed as an integer.")]
      out int IntValue,

      [FriendlyName("Float Result", "The length of the Target string, expressed as a floating-point number.")]
      [SocketState(false, false)]
      out float FloatValue,

      [FriendlyName("String Result", "The length of the Target string, expressed as a string.")]
      [SocketState(false, false)]
      out string StringValue
      )
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