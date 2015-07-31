// uScript Action Node
// (C) 2012 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Outputs each character of a string based on a time delay.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Typewriter", "Outputs each character of a string based on a time delay. Great for emulating a typewriter style output of text for UI.")]
public class uScriptAct_Typewriter : uScriptLogic
{
   //public bool Out { get { return true; } }

   public bool Started { get { return m_Started; } }

   public bool Skipped { get { return m_Skipped; } }

   [FriendlyName("Character Typed")]
   public bool CharTyped { get { return m_CharTyped; } }

   public event System.EventHandler Finished;

   private bool m_Started;
   private float m_DelayTime;
   private float m_SkipDelayTime;
   private string m_TargetString;
   private bool m_Skipped;
   private bool m_CharTyped;
   private string m_CurrentCharacter;
   private string m_OutputString;
   private char[] m_CharacterArray;
   private float m_StartTime;
   private bool m_SkipSocketFired;
   private bool m_Finished;
   private int m_CurrentIndex;
   private bool m_IsRunning;

   public void In(
      [FriendlyName("Target", "The string to be typed.")]
      string targetString,

      [FriendlyName("Delay", "The time delay between characters in the target string.")]
      [DefaultValue(0.2f)]
      float delayTime,

      [FriendlyName("Skip Delay", "The time delay between characters that will be used if the node receives a signal on its Skip input socket. Set to 0 if you want the string to finish typing instantly.")]
      [DefaultValue(0.05f)]
      float skipDelayTime,

      [FriendlyName("Output", "The new string containing the characters from the original target string. This string is updated as each character is 'typed'. Use this variable with the Character Typed output socket to update your UI as each character is added to this string variable.")]
      out string Output,

      [FriendlyName("Current Character", "The current character in the target string that the typewriter is currently on.")]
      [SocketState(false, false)]
      out string currentCharacter
      )
   {
      // Set this to true so that the Started output socket will fire.
      m_Started = true;

      // Reset the following variables to their initial state so they are "clean" each time the In socket if fired:
      m_Skipped = false;
      m_SkipSocketFired = false;
      m_CharTyped = false;
      m_Finished = false;
      m_CurrentIndex = 0;
      m_OutputString = "";
      m_CurrentCharacter = "";
      Output = m_OutputString;
      currentCharacter = m_CurrentCharacter;

      // Initial the following variables with the data provided to the node's vairable sockets:
      m_DelayTime = delayTime;
      m_SkipDelayTime = skipDelayTime;
      m_TargetString = targetString;

      if (m_TargetString.Length > 0)
      {
         m_CharacterArray = m_TargetString.ToCharArray();

         // Set the time delay used by the second character should print through the driven method.
         m_StartTime = Time.time + m_DelayTime;

         // Begin printing out characters if there are more to print:
         m_IsRunning = true;
      }
      else
      {
         // The string was empty, so the node is finished.
         if (Finished != null) Finished(this, new System.EventArgs());
      }

   }


   public void Skip(
      [FriendlyName("Target", "The string to be typed.")]
      string targetString,

      [FriendlyName("Delay", "The time delay between characters in the target string.")]
      [DefaultValue(0.2f)]
      float delayTime,

      [FriendlyName("Skip Delay", "The time delay between characters that will be used if the node receives a signal on its Skip input socket. Set to 0 if you want the string to finish typing instantly.")]
      [DefaultValue(0.05f)]
      float skipDelayTime,

      [FriendlyName("Output", "The new string containing the characters from the orginial target string. This string is updated as each character is 'typed'. Use this variable with the Character Typed output socket to update your UI as each character is added to this string variable.")]
      out string Output,

      [FriendlyName("Current Character", "The current character in the target string that the typewriter is currently on.")]
      [SocketState(false, false)]
      out string currentCharacter
      )
   {
      m_SkipSocketFired = true;
      if (m_IsRunning)
      {
         m_Skipped = true;

         if (skipDelayTime <= 0)
         {
            m_StartTime = Time.time + skipDelayTime;
            Output = targetString;
            currentCharacter = m_CharacterArray[m_CharacterArray.Length - 1].ToString();
         }
         else
         {
            Output = m_OutputString;
            currentCharacter = m_CurrentCharacter;
         }

      }
      else
      {
         Output = targetString;
         currentCharacter = targetString.Substring(targetString.Length - 1, 1);
         m_Skipped = true;
         if (Finished != null) Finished(this, new System.EventArgs());
      }

   }


   [Driven]
   public bool Driven(out string Output, out string currentCharacter)
   {
      // Set this to false so the Started output socket only fires the one time.
      m_Started = false;
      m_Skipped = false;

      // Make sure this is always false except when a new character has been typed in the logic below.
      m_CharTyped = false;

      // Set this to true later if we skip and the time is 0 (instant):
      bool _instantSkip = false;

      // Only run the driven logic if the node is in its running mode.
      if (m_IsRunning)
      {
         // Do the following logic if we are not done typeing the characters:
         if (!m_Finished)
         {
            // Do this logic if the node was not told to skip to the end:
            if (!m_SkipSocketFired)
            {
               // Print the first character right away, then start the delays:
               if (m_CurrentIndex == 0)
               {
                  m_CurrentCharacter = m_CharacterArray[0].ToString();
                  m_OutputString = m_CurrentCharacter;
                  m_CurrentIndex = m_CurrentIndex + 1;
                  m_CharTyped = true;

                  // End the whole thing if there was only 1 character in the target string:
                  if (m_CharacterArray.Length == 1)
                  {
                     m_Finished = true;
                  }
                  else
                  {
                     m_StartTime = Time.time + m_DelayTime;
                  }

               }

               // Logic for second character on (if more than 1 character was in the string):
               if (Time.time > m_StartTime && !m_Finished)
               {
                  m_CurrentCharacter = m_CharacterArray[m_CurrentIndex].ToString();
                  m_CurrentIndex = m_CurrentIndex + 1;

                  m_OutputString = m_OutputString + m_CurrentCharacter;

                  m_CharTyped = true;


                  if (m_CurrentIndex == m_CharacterArray.Length)
                  {
                     m_Finished = true;
                  }
                  else
                  {
                     m_StartTime = Time.time + m_DelayTime;
                  }
               }
            }
            else
            {
               // The node was told to skip through the rest of the characters:
               if (m_SkipDelayTime > 0)
               {
                  // Print the first character right away, then start the delays:
                  if (m_CurrentIndex == 0)
                  {
                     m_CurrentCharacter = m_CharacterArray[0].ToString();
                     m_OutputString = m_CurrentCharacter;
                     m_CurrentIndex = m_CurrentIndex + 1;
                     m_CharTyped = true;

                     // End the whole thing if there was only 1 character in the target string:
                     if (m_CharacterArray.Length == 1)
                     {
                        m_Finished = true;
                     }
                     else
                     {
                        m_StartTime = Time.time + m_SkipDelayTime;
                     }

                  }

                  // Logic for second character on (if more than 1 character was in the string):
                  if (Time.time > m_StartTime && !m_Finished)
                  {
                     m_CurrentCharacter = m_CharacterArray[m_CurrentIndex].ToString();
                     m_CurrentIndex = m_CurrentIndex + 1;

                     m_OutputString = m_OutputString + m_CurrentCharacter;

                     m_CharTyped = true;


                     if (m_CurrentIndex == m_CharacterArray.Length)
                     {
                        m_Finished = true;
                     }
                     else
                     {
                        m_StartTime = Time.time + m_SkipDelayTime;
                     }
                  }


               }
               else
               {
                  _instantSkip = true;
                  m_Finished = true;
               }

            }

         }
         else
         {
            // Time to shut this driven method down and fire the Finished output socket:
            m_IsRunning = false;
            if (Finished != null) Finished(this, new System.EventArgs());
         }
      }

      // Determine what the output variables should be set to based on if instant skipping happened or not:
      if (_instantSkip)
      {
         Output = m_TargetString;
         currentCharacter = m_CharacterArray[m_CharacterArray.Length - 1].ToString();
         m_CharTyped = true;
      }
      else
      {
         Output = m_OutputString;
         currentCharacter = m_CurrentCharacter;
      }

      return m_IsRunning;
   }

}