// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires out the correct out socket based on the active state of the specified Component.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Is Component Active", "Fires out the correct out socket based on the active state of the specified Component. If the specified Component is not on the Target, the 'Not Found' out socket will fire.")]
public class uScriptAct_IsComponentActive : uScriptLogic
{
   private bool m_IsActive;
   private bool m_IsNotActive;
   private bool m_NotFound;

   public bool Out { get { return true; } }
   
   public bool Active   { get { return m_IsActive; } }
   public bool Inactive { get { return m_IsNotActive; } }
   [FriendlyName("Not Found")]
   public bool NotFound { get { return m_NotFound; } }

   public void In(
      [FriendlyName("Target", "GameObject which contains the component.")]
      GameObject Target,

      [FriendlyName("Component Name", "Component type which to check. Please provide the actualy Unity name for the component.")]
      string component
      )
   {
      m_IsActive = false;
      m_IsNotActive = false;
      m_NotFound = false;
      component = component.ToLower(); // Convert everything to lowercase so casing doesn't matter.

      if (null != Target)
      {
         // Get the list of all the active components on the Target, and populate a list with their names
         Component[] _comps = Target.GetComponents(typeof(Component));

         List<string> _compNameList = new List<string>();
         foreach (Component tmpComp in _comps)
         {
            _compNameList.Add(tmpComp.GetType().ToString().Replace("UnityEngine.", "").ToLower());
         }

         // Check to see if the component is on the Target
         if (!_compNameList.Contains(component))
         {
            m_NotFound = true;
         }
         else
         {
            // Component was found, now let's see if it is active or not and fire out the correct out socket
            bool _isActive = false;
            int _compIndex = _compNameList.FindIndex(pred => pred.Contains(component));

            if (typeof(Behaviour).IsAssignableFrom(_comps[_compIndex].GetType()))
            {
               _isActive = ((Behaviour)_comps[_compIndex]).enabled;
            }

            if (_isActive)
            {
               m_IsActive = true;
            }
            else
            {
               m_IsNotActive = true;
            }
         }
      }
      else
      {
         uScriptDebug.Log("The Target specified was NULL. Components could not be checked.", uScriptDebug.Type.Warning);
      }
   }
}

#endif
