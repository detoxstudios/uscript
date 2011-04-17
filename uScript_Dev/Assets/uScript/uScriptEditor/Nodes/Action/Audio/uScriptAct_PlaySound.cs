// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Plays the specified AudioClip on the target GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Action/Audio")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Plays the specified AudioClip on the target GameObject.")]
[NodeDescription("Plays the specified AudioClip on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Play Sound")]
public class uScriptAct_PlaySound : uScriptLogic
{
   private AudioSource m_AudioSource;
   private AudioClip m_AudioClip;

   public bool Out { get { return true; } }

   public event System.EventHandler Finished;

   public void Play([FriendlyName("File Name")] string FileName, [FriendlyName("Resource Path")] string ResourcePath, [FriendlyName("Target")] GameObject Target, [FriendlyName("Volume")] float Volume, [FriendlyName("Loop")] bool Loop)
   {

      //Debug.Log("Resource Path = " + ResourcePath);

      // Build final ResourcePath string
      if (ResourcePath != "")
      {
         // Make sure all the slashes are correct
         if (ResourcePath.Contains("\\"))
         {
            ResourcePath = ResourcePath.Replace("\\", "/");
         }

         // Prune any begining or ending slashes
         if (ResourcePath.StartsWith("/") || ResourcePath.StartsWith(@"\"))
         {
            ResourcePath = ResourcePath.Remove(0, 1);
         }
         if (ResourcePath.EndsWith("/") || ResourcePath.EndsWith(@"\"))
         {
            int stringLength = ResourcePath.Length - 1;
            ResourcePath = ResourcePath.Remove(stringLength, 1);
         }

         //prune Assets text if user added it
         if (ResourcePath.StartsWith("Assets") || ResourcePath.StartsWith("assets"))
         {
            ResourcePath = ResourcePath.Remove(0, 6);
         }

         //prune Resources text if user added it
         if (ResourcePath.StartsWith("Resources") || ResourcePath.StartsWith("resources"))
         {
            ResourcePath = ResourcePath.Remove(0, 9);
         }


      }

      // Build final PrefabName string
      if (FileName != "")
      {
         // Make sure all the slashes are correct
         if (FileName.Contains("\\"))
         {
            FileName = FileName.Replace("\\", "/");
         }

         // Prune any begining or ending slashes
         if (FileName.StartsWith("/") || FileName.StartsWith(@"\"))
         {
            FileName = FileName.Remove(0, 1);
         }
         if (FileName.EndsWith("/") || FileName.EndsWith(@"\"))
         {
            int stringLength = FileName.Length - 1;
            FileName = FileName.Remove(stringLength, 1);
         }


         FileName = System.IO.Path.GetFileNameWithoutExtension(FileName);


      }

      // Build final fullPath
      string fullPath = "";

      if (ResourcePath != "")
      {
         fullPath = ResourcePath + "/" + FileName;
      }
      else
      {
         // Must be in the root of Resources
         fullPath = FileName;
      }

      // Build the AudioClip
      try
      {
         //Debug.Log("Full Path = " + fullPath);
         m_AudioClip = Resources.Load(fullPath, typeof(AudioClip)) as AudioClip;
         //uScriptDebug.Log("AudioClip = " + m_AudioClip);
      }
      catch (System.Exception e)
      {
         uScriptDebug.Log(e.ToString(), uScriptDebug.Type.Error);
      }



      //Debug.Log("AudioClip = " + m_AudioClip.ToString());
      if (m_AudioClip != null && Target != null)
      {
         //uScriptDebug.Log("NOT NULL!");

         m_AudioSource = (AudioSource)Target.AddComponent(typeof(AudioSource)); ;

         m_AudioSource.clip = m_AudioClip;
         m_AudioSource.volume = Volume;
         m_AudioSource.loop = Loop;

         m_AudioSource.Play();

      }

      //Debug.Log("Target = " + Target.ToString());
      


   }

   public void Stop([FriendlyName("File Name")] string FileName, [FriendlyName("Resource Path")] string ResourcePath, [FriendlyName("Target")] GameObject Target, [FriendlyName("Volume")] float Volume, [FriendlyName("Loop")] bool Loop)
   {

      m_AudioSource.Stop();

   }

   public override void Update()
   {
      // Called every tick
      if (m_AudioSource != null)
      {
         if (m_AudioSource.isPlaying == false)
         {
            if (Finished != null)
            {
               Finished(this, new System.EventArgs());
            }


            Destroy(m_AudioSource);
         }

      }

   }






}