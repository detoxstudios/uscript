// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the active AudioListener to the one on the specified GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Action/Audio")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Sets the active AudioListener to the one on the specified GameObject.")]
[NodeDescription("Sets the active AudioListener to the one on the specified GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Active Audio Listener")]
public class uScriptAct_SetActiveAudioListener : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Target)
   {
		AudioListener targetListener;
		targetListener = Target.GetComponent<AudioListener>();
					
		if ( targetListener != null)
		{
			try
			{
				AudioListener[] listenerList = FindObjectsOfType(typeof(AudioListener)) as AudioListener[];
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