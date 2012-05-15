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
               if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer")
               {
                  if ( currentTarget.renderer != null )
                  {
                     currentTarget.renderer.enabled = true;
                  }
               }
               else
               {
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
                  }
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
               if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer")
               {
                  if ( currentTarget.renderer != null )
                  {
                     currentTarget.renderer.enabled = false;
                  }
               }
               else
               {
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
                  }
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
               if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer")
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
                  }
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
