// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Toggle")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles the active state of a component on the Target GameObjects.")]
/* M */[NodeDescription("Toggles the active state of a component on the Target GameObjects. Ignores GameObjects missing the specified component.\n \nTarget: The Target GameObject(s) to toggle component state on.\nComponent Name: The name of the component to toggle.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Toggle_Component")]

[FriendlyName("Toggle Component")]
public class uScriptAct_ToggleComponent : uScriptLogic
{
   [FriendlyName("Out (Turn On)")]
   public event System.EventHandler OnOut;

   [FriendlyName("Out (Turn Off)")]
   public event System.EventHandler OffOut;

   [FriendlyName("Out (Toggle)")]
   public event System.EventHandler ToggleOut;

   public bool Out { get { return true; } }

   [FriendlyName("Turn On")]
   public void TurnOn( GameObject[] Target, [FriendlyName("Component Name")] string[] ComponentName )
   {
      foreach ( GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
					if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer")
					{
						currentTarget.renderer.enabled = true;
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

      OnOut(this, new System.EventArgs());
   }

   [FriendlyName("Turn Off")]
   public void TurnOff(GameObject[] Target, [FriendlyName("Component Name")] string[] ComponentName)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
					if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer")
					{
						currentTarget.renderer.enabled = false;
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

      OffOut(this, new System.EventArgs());
   }

   [FriendlyName("Toggle")]
   public void Toggle(GameObject[] Target, [FriendlyName("Component Name")] string[] ComponentName)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
					if (currentComponentName.ToLower() == "meshrenderer" || currentComponentName.ToLower() == "renderer")
					{
						if (currentTarget.renderer.enabled)
						{
							currentTarget.renderer.enabled = false;
						}
						else
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
		                     if ( ((Behaviour)comp).enabled )
		                     {
		                        ((Behaviour)comp).enabled = false;
		                     }
		                     else
		                     {
		                        ((Behaviour)comp).enabled = true;
		                     }
		                  }
		                  else if (typeof(ParticleEmitter).IsAssignableFrom(comp.GetType()))
		                  {
		                     if ( ((ParticleEmitter)comp).enabled )
		                     {
		                        ((ParticleEmitter)comp).enabled = false;
		                     }
		                     else
		                     {
		                        ((ParticleEmitter)comp).enabled = true;
		                     }
		                  }
		               }
					}
               
            }
         }
      }

      ToggleOut(this, new System.EventArgs());
   }
}
