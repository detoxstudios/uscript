// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the number of characters in a string as a float, integer, and string.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Returns the number of characters in a string as a float, integer, and string.")]
[NodeDescription("Returns the number of characters in a string as a float, integer, and string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get String Length")]
public class uScriptAct_GetStringLength : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(string Target, [FriendlyName("Int Value")] out int IntValue, [FriendlyName("Float Value")] out float FloatValue, [FriendlyName("String Value")] out string StringValue)
   {

      int m_CountInt;
      float m_CountFloat;
      string m_CountString;

      if (Target != "")
      {
         m_CountInt = Target.Length;
         m_CountFloat = System.Convert.ToSingle(Target.Length);
         m_CountString = Target.Length.ToString();
      }
      else
      {
         m_CountInt = 0;
         m_CountFloat = 0F;
         m_CountString = "0";  
      }

      IntValue = m_CountInt;
      FloatValue = m_CountFloat;
      StringValue = m_CountString;
      
   }
}