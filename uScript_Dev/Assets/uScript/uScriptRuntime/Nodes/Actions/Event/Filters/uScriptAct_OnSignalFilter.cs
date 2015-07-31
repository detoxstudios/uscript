// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Events/Filters")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Filters a signal so it only passes after the specified parameters are met.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Signal Filter", "Filters a signal so it only passes after the specified parameters are met.")]
public class uScriptAct_OnSignalFilter : uScriptLogic 
{
   private bool m_Started;
   private int m_SignalsToOpen;
   private int m_SignalsAllowed;

   public bool Signal { get { return m_SignalsToOpen == 0 && (m_SignalsAllowed > 0 || m_SignalsAllowed < 0); } }
   public bool Out { get { return true; } }

   public void Reset(      
      [FriendlyName("Signals Requird To Open")]
      int signalsToOpen,
      [FriendlyName("Signals Allowed to Pass (-1 for always allow)")]
      int signalsAllowed
   )
   {
      m_Started = true;

      // Add one because it gets decremented in the In
      // so if they want 1 signal before it opens we set it to 1 + 1 = 2
      // then on the first signal it'll decrement to 1
      // on the next signal it'll dec to 0 and be allowed... thus one signal before it was allowed to pass
      m_SignalsToOpen = signalsToOpen + 1;
      m_SignalsAllowed = signalsAllowed;
   }

   public void In(
      [FriendlyName("Signals Requird To Open")]
      int signalsToOpen,
      [FriendlyName("Signals Allowed to Pass (-1 for always allow)")]
      int signalsAllowed
   )
   {
      if (false == m_Started)
         Reset(signalsToOpen, signalsAllowed);

      if (m_SignalsToOpen > 0)
         --m_SignalsToOpen;
      else if (m_SignalsAllowed > 0)
         --m_SignalsAllowed;
   }
}
