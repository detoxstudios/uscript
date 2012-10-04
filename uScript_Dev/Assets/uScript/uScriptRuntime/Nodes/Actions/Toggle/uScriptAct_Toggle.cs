// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Toggle")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles the active state of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Toggle")]

[FriendlyName("Toggle", "Toggles the active state of a GameObject.")]
public class uScriptAct_Toggle : uScriptLogic
{
   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   [FriendlyName("Turned On")]
   public event System.EventHandler OnOut;

   [FriendlyName("Turned Off")]
   public event System.EventHandler OffOut;

   [FriendlyName("Toggled")]
   public event System.EventHandler ToggleOut;

   public bool Out { get { return true; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Toggle()
   [FriendlyName("Turn On")]
   public void TurnOn(GameObject[] Target, bool IgnoreChildren)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            if (IgnoreChildren)
            {
               if (false == CheckIfActive(currentTarget))
               {
                  SetActiveState(currentTarget, true, IgnoreChildren);
               }
            }
            else
            {
               if (false == CheckIfActive(currentTarget))
               {
                  SetActiveState(currentTarget, true, IgnoreChildren);
               }
            }
         }
      }

      if (null != OnOut) OnOut(this, new System.EventArgs());
   }

   // Parameter Attributes are applied below in Toggle()
   [FriendlyName("Turn Off")]
   public void TurnOff(GameObject[] Target, bool IgnoreChildren)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            if (IgnoreChildren)
            {
               if (CheckIfActive(currentTarget))
               {
                  SetActiveState(currentTarget, false, IgnoreChildren);
               }
            }
            else
            {
               if (CheckIfActive(currentTarget))
               {
                  SetActiveState(currentTarget, false, IgnoreChildren);
               }
            }
         }
      }

      if (null != OffOut) OffOut(this, new System.EventArgs());
   }

   [FriendlyName("Toggle")]
   public void Toggle(
      [FriendlyName("Target", "The Target GameObject(s) to toggle state on.")]
      GameObject[] Target,

      [FriendlyName("Ignore Children", "If True, the state change will not affect the Target's children. However, the children will still not render if their parent has been disabled.")]
      [SocketState(false, false)]
      bool IgnoreChildren
      )
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            if (IgnoreChildren)
            {
               if (CheckIfActive(currentTarget))
               {
                  SetActiveState(currentTarget, false, IgnoreChildren);
               }
               else
               {
                  SetActiveState(currentTarget, true, IgnoreChildren);
               }
            }
            else
            {
               if (CheckIfActive(currentTarget))
               {
                  SetActiveState(currentTarget, false, IgnoreChildren);
               }
               else
               {
                  SetActiveState(currentTarget, true, IgnoreChildren);
               }
            }
         }
      }

      if (null != ToggleOut) ToggleOut(this, new System.EventArgs());
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //

   private bool CheckIfActive(GameObject go)
   {
#if UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_3_6
      return go.active;
#else
      return go.activeInHierarchy;
#endif
   }


   private void SetActiveState(GameObject go, bool State, bool IgnoreChildren)
   {
#if UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_3_6
      if (IgnoreChildren)
      {
         go.active = State;
      }
      else
      {
         go.SetActiveRecursively(State);
      }
#else
      if (IgnoreChildren)
      {
         go.SetActive(State);
      }
      else
      {
         SetAllChildren(go, State);
      }
#endif
   }

   private void SetAllChildren(GameObject go, bool State)
   {
#if UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_3_6

#else
      foreach (Transform child in go.transform)
      {
         child.gameObject.SetActive(State);
         SetAllChildren(child.gameObject, State);
      }
      go.SetActive(State);
#endif
   }
}
