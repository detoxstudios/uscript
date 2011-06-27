// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Checks the distance of two GameObjects against a specified distance and fires the appropriate output.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks the distance of two GameObjects against a specified distance.")]
[NodeDescription("Checks the distance of two GameObjects against a specified distance and fires the appropriate output.\n \nA: First GameObject to compare distance between.\nB: Second GameObject to compare distance between.\nDistance: Distance to compare the distance between A and B with.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Check Distance")]
public class uScriptCon_CheckDistance : uScriptLogic
{
   // @TODO: This node would really benifit by being able to check every tick as part of a master uScript Update() event.

   private bool m_Closer = false;
   private bool m_Further = false;
   private bool m_Equal = false;

   public bool Closer { get { return m_Closer; } }
   public bool Further { get { return m_Further; } }
   public bool Equal { get { return m_Equal; } }

   public void In(GameObject A, GameObject B, float Distance)
   {
      m_Closer = false;
      m_Further = false;
      m_Equal = false;

      if (A != null && B != null)
      {
         float distance = Vector3.Distance(A.transform.position, B.transform.position);
         if (distance < Distance)
         {
            m_Closer = true;
         }
         else if (distance == Distance)
         {
            m_Equal = true;
         }
         else
         {
            m_Further = true;
         }
      }
   }
}