// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Audio")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Sets the active AudioListener to the one on the specified GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Active Audio Listener", "Sets the active AudioListener to the one on the specified GameObject.")]
public class uScriptAct_SetActiveAudioListener : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject to use as the new AudioListener.")]
      GameObject Target
      )
   {
		AudioListener targetListener;
		targetListener = Target.GetComponent<AudioListener>();
					
		if ( targetListener != null)
		{
			try
			{
				AudioListener[] listenerList = ScriptableObject.FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
				foreach (AudioListener tmpListener in listenerList)
				{
					tmpListener.enabled = false;
				}
				
				targetListener.enabled = true;						
			}
			catch (System.Exception e)
			{
				uScriptDebug.Log( ( e.ToString()), uScriptDebug.Type.Error );
			}
      
		}
   }
}