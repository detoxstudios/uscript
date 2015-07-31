// uScript Action Node
// (C) 2014 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Flips the target GameObject(s) 180 degrees on the specified axis.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Flip", "Flips the target GameObject(s) 180 degrees on the specified axis. Especially useful for sprites.")]
public class uScriptAct_Flip : uScriptLogic
{
   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The Target GameObject(s) to rotate."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Axis", "The axis to rotate around (X, Y, or Z).")]
      string Axis,

      [FriendlyName("Space", "The coordinate space the flip should happen in (Local or World).")]
      Space FlipSpace
   )
   {
      float x_Degrees = 0f;
      float y_Degrees = 0f;
      float z_Degrees = 0f;

      if ("x" == Axis || "X" == Axis)
         x_Degrees = 180f;
      else if ("y" == Axis || "Y" == Axis)
         y_Degrees = 180f;
      else if ("z" == Axis || "Z" == Axis)
         z_Degrees = 180f;
      else
         uScriptDebug.Log("[Flip node error] - You have not specified a valid axis for the flip (X, Y, or Z).", uScriptDebug.Type.Error);
      

      
      foreach (GameObject obj in Target)
      {
         if (null != obj)
         {
            obj.transform.Rotate(x_Degrees, y_Degrees, z_Degrees, FlipSpace);
         }
         else
         {
            uScriptDebug.Log("[Flip node warning] - The target specified was null. This means there was not a valid GameObject assigned to the Target when the node executed.", uScriptDebug.Type.Warning);
         }

      }
      

   }
   
}