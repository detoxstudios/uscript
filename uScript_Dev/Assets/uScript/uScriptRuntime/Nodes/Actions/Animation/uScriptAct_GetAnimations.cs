// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Get the list of animation names on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Animations", "Get the list of animation names on the target GameObject.")]
public class uScriptAct_GetAnimations : uScriptLogic
{
   private string[] m_Animations;
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target GameObject with the animations.")]
      GameObject Target,

      [FriendlyName("Filter", "(optional) A string used to filter the returned animations to ones that contain this string.")]
      [SocketState(false, false)]
      string Filter,

      [FriendlyName("Animations", "The list of animations as a String List variable.")]
      out string[] Animations
      )
   {
		
		Animation anims = (Animation)Target.GetComponent("Animation");
		
		int animationCount = 0;
		
		if (anims != null)
		{
		   // Get the array size
		   if(Filter == "")
		   {
		      m_Animations = new string[anims.GetClipCount()];
		   }
		   else
		   {
				foreach (AnimationState anim in anims)
			   {
					 if(anim.name.Contains(Filter))
					 {
						animationCount++;
					 }
			   }
				m_Animations = new string[animationCount];
		   }
			
			
			// build array output
			int counter = 0;
			foreach (AnimationState anim in anims)
			{
				if (Filter != "")
				{
					if(anim.name.Contains(Filter))
					{
						m_Animations[counter] = anim.name;
						counter++;
					}
				}
				else
				{	m_Animations[counter] = anim.name;
					counter++;
				}
			}
			
			Animations = m_Animations;
		}
		else
		{
			m_Animations = new string[1];
			m_Animations[0] = "";
			Animations = m_Animations;
		}
		
   }


}