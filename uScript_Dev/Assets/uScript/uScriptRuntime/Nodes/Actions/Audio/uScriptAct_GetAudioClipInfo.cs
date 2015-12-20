// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Audio")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns AudioClip properties of the target AudioClip variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get AudioClip Info", "Returns AudioClip properties of the target AudioClip variable.")]
public class uScriptAct_GetAudioClipInfo : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject containing the animtion clip.")]
      AudioClip target,

      [FriendlyName("Length", "The length of the audio clip in seconds.")]
      out float clipLength,

      [FriendlyName("Samples", "The length of the audio clip in samples.")]
      [SocketState(false, false)]
      out float clipSamples,

      [FriendlyName("Channels", "Returns the number of channels the audio clip has. 1 = Mono, 2+ = Stereo.")]
      [SocketState(false, false)]
      out int clipChannels,

      [FriendlyName("Frequency", "The frequency of the audio clip in Hz.")]
      [SocketState(false, false)]
      out float clipFrequency,
      
      [FriendlyName("Is Ready", "Returns true if the audio clip is ready to play. This is primarily used when downloading the audio clip from a web site and returns true when there is enough data downloaded to begin play without interuptions. This always returns true for audio clips not associated with a web stream.")]
      [SocketState(false, false)]
      out bool clipIsReady)
   {
      clipLength = target.length;
      clipSamples = target.samples;
      clipChannels = target.channels;
      clipFrequency = target.frequency;
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
      clipIsReady = target.isReadyToPlay;
#else
        if (target.loadState == AudioDataLoadState.Loaded)
        {
           clipIsReady = true;
        }
        else
        {
           clipIsReady = false;
        }
#endif
   }
}
