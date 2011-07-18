// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Concatenates two objects as a string for output.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Concatenates two objects as a string for output.")]
[NodeDescription("Concatenates two objects as a string for output.\n \nA: Objects to be concatenated with B as a string. If there is more than 1 object, they will all be concatenated together as strings before being concatenated with B.\nB: Objects to be concatenated with A as a string. If there is more than 1 object, they will all be concatenated together as strings before being concatenated with A.\nSeparator: String to use as a seaparator between each concatenated string. If there are multiple objects attached to either A or B, this separator will also be inserted between each of those as they are concatenated.\nResult (out): Resulting concatenated string.\n\nNote: This node will strip leading and trailing whitespace from the input strings. use the Seperator to add a space between strings.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Concatenate")]

[FriendlyName("Concatenate")]
public class uScriptAct_Concatenate : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(object[] A, object[] B, [SocketState(false, false)] string Separator, out string Result)
   {
      string aTotal = A[0].ToString();
      string bTotal = B[0].ToString();
      int i;

      for (i = 1; i < A.Length; i++)
      {
         aTotal += Separator + A[i].ToString();
      }

      for (i = 1; i < B.Length; i++)
      {
         bTotal += Separator + B[i].ToString();
      }

      Result = aTotal + Separator + bTotal;
   }
}
