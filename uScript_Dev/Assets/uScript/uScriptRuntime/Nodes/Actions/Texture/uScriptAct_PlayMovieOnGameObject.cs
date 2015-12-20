// uScript Action Node
// (C) 2010 Detox Studios LLC

#if (UNITY_ANDROID || UNITY_IPHONE || UNITY_FLASH || UNITY_PS4)

   // This node is not supported on these platforms at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Texture")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Plays the MovieTexture assigned to the material of the Target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Play Movie On GameObject", "Plays the MovieTexture assigned to the material of the Target GameObject(s). The Finished socket will fire once ALL movies have finished playing (or when stopped)." +
	"\n\nNote 1: If you wish to hear the movie's audio, you will need to put an AudioSource component on the target GameObject and have the movie's AudioClip assigned to it. Also, because Unity makes the AudioClip a 3D sound, you may need to adjust the AudioSource component's Volume Rolloff settings to hear the sound as desired." +
	"\n\nNote 2: All instances of a GameObject with the same material will play their movie textures.")]
public class uScriptAct_PlayMovieOnGameObject : uScriptLogic
{
   private List<MovieTexture> m_TargetMovies = new List<MovieTexture>( );
	
   private bool m_paused;
	
	private int m_ReadyCount;

   public bool Out { get { return true; } }
	
   public event System.EventHandler Paused;
	
   public event System.EventHandler Finished;

   // Parameter Attributes are applied below in Stop()
   public void Play(GameObject[] Targets, bool loop, bool isReady)
   {
		m_paused = false;
		
		if (isReady)
		{
			while ( m_ReadyCount < Targets.Length )
			{
				m_ReadyCount = 0;
				foreach (GameObject target in Targets)
				{
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
					MovieTexture mov = (MovieTexture)target.renderer.material.mainTexture;
#else
               MovieTexture mov = (MovieTexture)target.GetComponent<Renderer>().material.mainTexture;
#endif
					if ( mov.isReadyToPlay )
					{
						m_ReadyCount++;
					}
				}
			}
		}
		
		
      if ( Targets.Length > 0 )
      {
		 m_TargetMovies.Clear();
			
         for (int i = 0; i < Targets.Length; i++)
         {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
            MovieTexture mov = (MovieTexture)Targets[i].renderer.material.mainTexture;
#else
            MovieTexture mov = (MovieTexture)Targets[i].GetComponent<Renderer>().material.mainTexture;
#endif
				
				if ( mov.isReadyToPlay )
				{
					mov.loop = loop;

            		mov.Play();

            		m_TargetMovies.Add( mov );
				}
         }
      }
   }
	
   public void Pause( GameObject[] Targets, bool loop, bool isReady )
   {
      if (null != m_TargetMovies)
      {
		 m_paused = true;
         foreach (MovieTexture mov in m_TargetMovies)
         {
            mov.Pause();
         }
      }
	  m_paused = true;
	  if (Paused != null) Paused(this, new System.EventArgs());
   }

   public void Stop(
      [FriendlyName("Target", "The GameObject(s) with the material containing the movie texture."), AutoLinkType(typeof(GameObject))]
      GameObject[] Targets,

      [FriendlyName("Loop", "Whether or not to loop the movie.")]
      [SocketState(false, false)]
      bool loop,
		
	  [FriendlyName("Wait Until Ready", "If checked, the node will wait until all specified movie textures are loaded and ready to play. By default (unchecked) the node will skip any movie textures not yet ready to play.")]
      [SocketState(false, false)]
      bool isReady
   )
   {
	  m_paused = false;
		
      if (null != m_TargetMovies)
      {
         foreach (MovieTexture mov in m_TargetMovies)
         {
            mov.Stop();
         }
      }
   }

   public void Update()
   {
      if (0 == m_TargetMovies.Count) return;

      int i;

      for (i = 0; i < m_TargetMovies.Count; i++)
      {
         if (false == m_TargetMovies[i].isPlaying && false == m_paused)
         {

            m_TargetMovies.RemoveAt( i );

            --i;
         }
      }

      if ( 0 == m_TargetMovies.Count )
      {
         if (Finished != null) Finished(this, new System.EventArgs());
      }
   }

#if UNITY_EDITOR
   public override Hashtable EditorDragDrop( object o )
   {
      if ( typeof(UnityEngine.GameObject).IsAssignableFrom(o.GetType()) )
      {
         GameObject go = (GameObject) o;

         Hashtable hashtable = new Hashtable( );
         hashtable[ "Target" ] = go.name;

         return hashtable;
      }

      return null;
   }
#endif

}

#endif
