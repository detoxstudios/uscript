// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Toggle")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles the active state of a component on the Target GameObjects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Toggle Component", "Toggles the active state of a component on the Target GameObjects. Ignores GameObjects missing the specified component.")]
public class uScriptAct_ToggleComponent : uScriptLogic
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

   private bool turnedOn = false;
   private bool turnedOff = false;

   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Toggle()
   [FriendlyName("Turn On")]
   public void TurnOn(GameObject[] Target, string[] ComponentName)
   {
      foreach ( GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
               if (currentComponentName.ToLower() == "collider" )
               {
#if !UNITY_3_2 && !UNITY_3_3
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
                  if ( currentTarget.collider != null )
                  {
                     currentTarget.collider.enabled = true;
                  }
#else
                  if (currentTarget.GetComponent<Collider>() != null)
                  {
                     currentTarget.GetComponent<Collider>().enabled = true;
                  }
#endif
#endif
               }
               else if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer" || currentComponentName.ToLower() == "skinnedmeshrenderer" )
               {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
                  if ( currentTarget.renderer != null )
                  {
                     currentTarget.renderer.enabled = true;
                  }
#else
                  if (currentTarget.GetComponent<Renderer>() != null)
                  {
                     currentTarget.GetComponent<Renderer>().enabled = true;
                  }
#endif
               }
               else
               {
                  EnableThis(currentTarget.GetComponent(currentComponentName), true);
               }
            }
         }
      }

      if ( null != OnOut ) OnOut(this, new System.EventArgs());
   }

   // Parameter Attributes are applied below in Toggle()
   [FriendlyName("Turn Off")]
   public void TurnOff(GameObject[] Target, string[] ComponentName)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
               if (currentComponentName.ToLower() == "collider" )
               {
#if !UNITY_3_2 && !UNITY_3_3
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
                  if ( currentTarget.collider != null )
                  {
                     currentTarget.collider.enabled = false;
                  }
#else
                  if (currentTarget.GetComponent<Collider>() != null)
                  {
                     currentTarget.GetComponent<Collider>().enabled = false;
                  }
#endif
#endif
               }
               else if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer" || currentComponentName.ToLower() == "skinnedmeshrenderer" )
               {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
                  if ( currentTarget.renderer != null )
                  {
                     currentTarget.renderer.enabled = false;
                  }
#else
                  if (currentTarget.GetComponent<Renderer>() != null)
                  {
                     currentTarget.GetComponent<Renderer>().enabled = false;
                  }
#endif
               }
               else
               {
                  EnableThis(currentTarget.GetComponent(currentComponentName), false);
               }
            }
         }
      }

      if ( null != OffOut ) OffOut(this, new System.EventArgs());
   }

   [FriendlyName("Toggle")]
   public void Toggle(
      [FriendlyName("Target", "The Target GameObject(s) to toggle component state on."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Component Name", "The name of the component to toggle.")]
      string[] ComponentName
      )
   {
      turnedOn = false;
      turnedOff = false;

      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
               if (currentComponentName.ToLower() == "collider" )
               {
#if !UNITY_3_2 && !UNITY_3_3
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
                  if ( currentTarget.collider != null )
                  {
                     if (currentTarget.collider.enabled)
                     {
                        currentTarget.collider.enabled = false;
                        turnedOff = true;
                     }
                     else
                     {
                        currentTarget.collider.enabled = true;
                        turnedOn = true;
                     }
                  }
#else
                  if (currentTarget.GetComponent<Collider>() != null)
                  {
                     if (currentTarget.GetComponent<Collider>().enabled)
                     {
                        currentTarget.GetComponent<Collider>().enabled = false;
                        turnedOff = true;
                     }
                     else
                     {
                        currentTarget.GetComponent<Collider>().enabled = true;
                        turnedOn = true;
                     }
                  }
#endif
#endif
               }
               else if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer" || currentComponentName.ToLower() == "skinnedmeshrenderer" )
               {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
                  if ( currentTarget.renderer != null )
                  {
                     if (currentTarget.renderer.enabled)
                     {
                        currentTarget.renderer.enabled = false;
                        turnedOff = true;
                     }
                     else
                     {
                        currentTarget.renderer.enabled = true;
                        turnedOn = true;
                     }
                  }
#else
                  if (currentTarget.GetComponent<Renderer>() != null)
                  {
                     if (currentTarget.GetComponent<Renderer>().enabled)
                     {
                        currentTarget.GetComponent<Renderer>().enabled = false;
                        turnedOff = true;
                     }
                     else
                     {
                        currentTarget.GetComponent<Renderer>().enabled = true;
                        turnedOn = true;
                     }
                  }
#endif
               }
               else
               {
                  turnedOn = ToggleThis(currentTarget.GetComponent(currentComponentName)); 
                  turnedOff = ! turnedOn;
               }
            }
         }
      }

      if ( null != ToggleOut ) ToggleOut(this, new System.EventArgs());

      if ( turnedOn && null != OnOut ) OnOut(this, new System.EventArgs());
      if ( turnedOff && null != OffOut ) OffOut(this, new System.EventArgs());
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
   private void EnableThis(Component comp, bool enable)
   {
      Behaviour b = comp as Behaviour;
      if (b != null)
      {
         b.enabled = enable;
         return;
      }

      ParticleEmitter pe = comp as ParticleEmitter;
      if (pe != null)
      {
         pe.enabled = enable;
         return;
      }

      LineRenderer le = comp as LineRenderer;
      if (le != null)
      {
         le.enabled = enable;
         return;
      }
   }

   private bool ToggleThis(Component comp)
   {
      Behaviour b = comp as Behaviour;
      if (b != null)
      {
         b.enabled = ! b.enabled;
         return b.enabled;
      }

      ParticleEmitter pe = comp as ParticleEmitter;
      if (pe != null)
      {
         pe.enabled = ! pe.enabled;
         return pe.enabled;
      }

      LineRenderer le = comp as LineRenderer;
      if (le != null)
      {
         le.enabled = ! le.enabled;
         return le.enabled;
      }

      return false;
   }                   
}
