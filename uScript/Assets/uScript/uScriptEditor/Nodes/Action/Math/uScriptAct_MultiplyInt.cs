// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Multiplies two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Multiplies two integer variables together and returns the result.")]
[NodeDescription("Multiplies two integer variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Multiply Int")]
public class uScriptAct_MultiplyInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int A, int B, [FriendlyName("Result")] out int IntResult, [FriendlyName("Float Result")] out float FloatResult)
   {

      int m_Total = A * B;
      IntResult = m_Total;
      FloatResult = System.Convert.ToSingle(m_Total);

   }
}