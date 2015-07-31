// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks the distance of two GameObjects against a specified distance.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Check Distance", "Checks the distance of two GameObjects against a specified distance and fires the appropriate output.")]
public class uScriptCon_CheckDistance : uScriptLogic
{
   private bool m_Closer = false;
   private bool m_Further = false;
   private bool m_Equal = false;

   public bool Closer { get { return m_Closer; } }
   public bool Further { get { return m_Further; } }
   public bool Equal { get { return m_Equal; } }

   public void In(
                  [FriendlyName("A", "First GameObject.")]
                  GameObject A,

                  [FriendlyName("B", "Second GameObject.")]
                  GameObject B,

                  [FriendlyName("Distance", "The distance value for the test.")]
                  float Distance
                  )
   {
      m_Closer = false;
      m_Further = false;
      m_Equal = false;

      if (A != null && B != null)
      {
		 float sqrMag = (A.transform.position - B.transform.position).sqrMagnitude;
         if (sqrMag < Distance*Distance)
         {
            m_Closer = true;
         }
         else if (sqrMag == Distance*Distance)
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