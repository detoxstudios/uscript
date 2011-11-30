// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Assigns the Material color of the target GameObject on the specifed material channel.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Assign_Material_Color")]

[FriendlyName("Assign Material Color", "Assigns the Material color of the target GameObject on the specifed material channel.")]
public class uScriptAct_AssignMaterialColor : uScriptLogic
{
   private Material m_NewMaterial;

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to assign the material color to.")]
      GameObject[] Target,

      [FriendlyName("Color", "The material color to assign to the Target object(s).")]
      Color MatColor,
      
      [FriendlyName("Material Channel", "The material channel of the object to assign the material color to.")]
      [SocketState(false, false)]
      int MatChannel
      )
   {
      //Get the Material
      try
      {
         foreach (GameObject tmpGameObject in Target)
         {
            tmpGameObject.renderer.materials[MatChannel].color = MatColor;
         }
      }
      catch (System.Exception e)
      {
         uScriptDebug.Log("(Node = Assign Material Color) Error output: " + e.ToString(), uScriptDebug.Type.Error);
      }
   }
}