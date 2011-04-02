// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Multiplies two float variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Multiplies two float variables together and returns the result.")]
[NodeDescription("Multiplies two float variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Multiply Float")]
public class uScriptAct_MultiplyFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float A, float B, [FriendlyName("Result")] out float FloatResult, [FriendlyName("Int Result")] out int IntResult)
   {

      float m_Total = A * B;
      FloatResult = m_Total;
      IntResult = System.Convert.ToInt32(m_Total);

   }
}