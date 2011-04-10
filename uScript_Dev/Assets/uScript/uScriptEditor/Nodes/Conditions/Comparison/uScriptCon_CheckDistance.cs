// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Checks the distance of two GameObjects against a specified distance and fires the appropriate output.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks the distance of two GameObjects against a specified distance.")]
[NodeDescription("Checks the distance of two GameObjects against a specified distance and fires the appropriate output.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Check Distance")]
public class uScriptCon_CheckDistance : uScriptLogic
{

   // @TODO: This node would really benifit by being able to check every tick as part of a master uScript Update() event.

   private bool m_Closer = false;
   private bool m_Further = false;

   public bool Closer { get { return m_Closer; } }
   public bool Further { get { return m_Further; } }

   public void In(GameObject A, GameObject B, float Distance)
   {
      m_Closer = false;
      m_Further = false;

      if (A != null && B != null)
      {

         float myDistance = Vector3.Distance(A.transform.position, B.transform.position);
         if (myDistance <= Distance)
         {
            m_Closer = true;
         }
         else
         {
            m_Further = true;
         }

      }
      
   }
}