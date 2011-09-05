// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Filters the OnKeyPress event to a specific key when the key is pressed down, being held, or released.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Events/Filters")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Filters the Input Event using the specified axis name from Unity's Input Manager array.")]
[NodeDescription("Filters the Input Event using the specified axis name from Unity's Input Manager array.  " +
                 "You can added your own input names by modifying the array at \"Project Settings\" > \"Input\"." +
                 "\n\nAxis Name: The axis name to monitor.  " +
                 "Default names include: \"Horizontal\", \"Vertical\", \"Fire1\", \"Fire2\", \"Fire3\", \"Jump\", \"Mouse X\", \"Mouse Y\", \"Mouse ScrollWheel\", \"Window Shake X\", and \"Window Shake Y\"." +
                 "\n\nAxis Value (out): The current value of the specified axis."
                 )]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Managed_Input_Events_Filter")]

[FriendlyName("Managed Input Events Filter")]
public class uScriptAct_OnManagedInputEventFilter : uScriptLogic
{
   private string m_name = string.Empty;
   private float m_value = 0;

   public bool m_InputEQOne = false;
   public bool m_InputGTZero = false;
   public bool m_InputEQZero = false;
   public bool m_InputLTZero = false;
   public bool m_InputEQNOne = false;

   [FriendlyName("Equals 1")]
   public bool InputEQOne { get { return m_InputEQOne; } }

   [FriendlyName("Between 0 and 1")]
   public bool InputGTZero { get { return m_InputGTZero; } }

   [FriendlyName("Equals 0")]
   public bool InputEQZero { get { return m_InputEQZero; } }

   [FriendlyName("Between 0 and -1")]
   public bool InputLTZero { get { return m_InputLTZero; } }

   [FriendlyName("Equals -1")]
   public bool InputEQNOne { get { return m_InputEQNOne; } }

   public void In([FriendlyName("Axis Name")] string name,
                  [FriendlyName("Axis Value")] out float value)
   {
      m_name = name;
      value = m_value;
   }

   [Driven]
   public bool DoUpdate(out float value)
   {
      if (string.IsNullOrEmpty(m_name) == false)
      {
         m_value = Input.GetAxis(m_name);
         value = m_value;
         return true;
      }

      value = 0;
      return false;
   }

   public void Update()
   {
      if (string.IsNullOrEmpty(m_name) == false)
      {
         m_value = Input.GetAxis(m_name);

         m_InputEQOne = m_value == 1;
         m_InputGTZero = m_value > 0 && m_value < 1;
         m_InputEQZero = m_value == 0;
         m_InputLTZero = m_value > -1 && m_value < 0;
         m_InputEQNOne = m_value == -1;
      }
   }
}
