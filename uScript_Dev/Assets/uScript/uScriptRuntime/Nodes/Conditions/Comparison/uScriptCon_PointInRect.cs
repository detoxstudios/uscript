// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if the Target Vector2 is within a Rect.")]
[NodeAuthor("Detox Studios LLC. Original node by SvdV on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Point In Rect", "Checks to see if the Target Vector2 is within a Rect.")]
public class uScriptCon_PointInRect : uScriptLogic
{
   private bool m_InRect = false;

   public bool True { get { return m_InRect; } }
   public bool False { get { return !m_InRect; } }

   public void In(
      [FriendlyName("Target", "The target Vector2 variable to compare against the rect.")] Vector2 Target,
      [FriendlyName("Test", "The Rect to test Target against.")] Rect Test)
   {
      m_InRect = Test.Contains( Target );
   }
}