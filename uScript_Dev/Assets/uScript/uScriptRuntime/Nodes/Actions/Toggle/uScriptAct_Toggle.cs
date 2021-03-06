// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Toggle")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles the active state of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

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
   public void TurnOn(GameObject[] Target, bool IgnoreChildren, [DefaultValue(true)][SocketState(false, false)] bool checkState = true)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            if (IgnoreChildren)
            {
               if (!checkState || false == CheckIfActive(currentTarget))
               {
                  SetActiveState(currentTarget, true, IgnoreChildren);
               }
            }
            else
            {
               if (!checkState || false == CheckIfActive(currentTarget))
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
   public void TurnOff(GameObject[] Target, bool IgnoreChildren, [DefaultValue(true)][SocketState(false, false)] bool checkState = true)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            if (IgnoreChildren)
            {
               if (!checkState || CheckIfActive(currentTarget))
               {
                  SetActiveState(currentTarget, false, IgnoreChildren);
               }
            }
            else
            {
               if (!checkState || CheckIfActive(currentTarget))
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
      [FriendlyName("Target", "The Target GameObject(s) to toggle state on."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Ignore Children", "If True, the state change will not affect the Target's children. However, the children will still not render if their parent has been disabled.")]
      bool IgnoreChildren,

      [FriendlyName("Check State", "If True, the state change will only happen if the current state is the opposite of the desired state. Only applies for TurnOn or TurnOff, not Toggle.")]
      [DefaultValue(true)]
      [SocketState(false, false)]
      bool checkState = true
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
