// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Toggle")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles the active state of a component on the Target GameObjects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Toggle_Component")]

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
                  if ( currentTarget.collider != null )
                  {
                     currentTarget.collider.enabled = true;
                  }
#endif
               }
               else if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer")
               {
                  if ( currentTarget.renderer != null )
                  {
                     currentTarget.renderer.enabled = true;
                  }
               }
               else
               {
#if !UNITY_FLASH
                  Component comp = currentTarget.GetComponent(currentComponentName);
                  if (comp != null)
                  {
                     if (typeof(Behaviour).IsAssignableFrom(comp.GetType()))
                     {
                        ((Behaviour)comp).enabled = true;
                     }
                     else if (typeof(ParticleEmitter).IsAssignableFrom(comp.GetType()))
                     {
                        ((ParticleEmitter)comp).enabled = true;
                     }
							else if (typeof(LineRenderer).IsAssignableFrom(comp.GetType()))
                     {
                        ((LineRenderer)comp).enabled = true;
                     }
                  }
#endif
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
                  if ( currentTarget.collider != null )
                  {
                     currentTarget.collider.enabled = false;
                  }
#endif
               }
               else if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer")
               {
                  if ( currentTarget.renderer != null )
                  {
                     currentTarget.renderer.enabled = false;
                  }
               }
               else
               {
#if !UNITY_FLASH
                  Component comp = currentTarget.GetComponent(currentComponentName);
                  if (comp != null)
                  {
                     if (typeof(Behaviour).IsAssignableFrom(comp.GetType()))
                     {
                        ((Behaviour)comp).enabled = false;
                     }
                     else if (typeof(ParticleEmitter).IsAssignableFrom(comp.GetType()))
                     {
                        ((ParticleEmitter)comp).enabled = false;
                     }
					 else if (typeof(LineRenderer).IsAssignableFrom(comp.GetType()))
                     {
                        ((LineRenderer)comp).enabled = false;
                     }
                  }
#endif
               }
            }
         }
      }

      if ( null != OffOut ) OffOut(this, new System.EventArgs());
   }

   [FriendlyName("Toggle")]
   public void Toggle(
      [FriendlyName("Target", "The Target GameObject(s) to toggle component state on.")]
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
#endif
               }
               else if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer")
               {
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
               }
               else
               {
#if !UNITY_FLASH
                  Component comp = currentTarget.GetComponent(currentComponentName);
                  if (comp != null)
                  {
                     if (typeof(Behaviour).IsAssignableFrom(comp.GetType()))
                     {
                        if ( ((Behaviour)comp).enabled )
                        {
                           ((Behaviour)comp).enabled = false;
                           turnedOff = true;
                        }
                        else
                        {
                           ((Behaviour)comp).enabled = true;
                           turnedOn = true;
                        }
                     }
                     else if (typeof(ParticleEmitter).IsAssignableFrom(comp.GetType()))
                     {
                        if ( ((ParticleEmitter)comp).enabled )
                        {
                           ((ParticleEmitter)comp).enabled = false;
                           turnedOff = true;
                        }
                        else
                        {
                           ((ParticleEmitter)comp).enabled = true;
                           turnedOn = true;
                        }
                     }
					 else if (typeof(LineRenderer).IsAssignableFrom(comp.GetType()))
                     {
                        if ( ((LineRenderer)comp).enabled )
                        {
                           ((LineRenderer)comp).enabled = false;
                           turnedOff = true;
                        }
                        else
                        {
                           ((LineRenderer)comp).enabled = true;
                           turnedOn = true;
                        }
                     }
                  }
#endif
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
}
