// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Get the list of animation names on the target GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Get the list of animation names on the target GameObject.")]
[NodeDescription("Get the list of animation names on the target GameObject.\n \nTarget: The Target GameObject with the animations.\nFilter: An optional string used to filter the returned animations to ones that contain this string.\nAnimations (out): The list of animations as a String List variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Animations")]
public class uScriptAct_GetAnimations : uScriptLogic
{
   private string[] m_Animations;
   public bool Out { get { return true; } }

   public void In(
      GameObject Target,
      [FriendlyName("Filter"), SocketState(false, false)] string Filter,
      [FriendlyName("Animations")] out string[] Animations
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
		}
		
		Animations = m_Animations;
		
   }


}