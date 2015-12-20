// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Assigns the Material color of the target GameObject on the specifed material channel.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Assign Material Color", "Assigns the Material color of the target GameObject on the specifed material channel.")]
public class uScriptAct_AssignMaterialColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) to assign the material color to."), AutoLinkType(typeof(GameObject))]
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
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
            tmpGameObject.renderer.materials[MatChannel].color = MatColor;
#else
            tmpGameObject.GetComponent<Renderer>().materials[MatChannel].color = MatColor;
#endif
         }
      }
      catch (System.Exception e)
      {
         uScriptDebug.Log("(Node = Assign Material Color) Error output: " + e.ToString(), uScriptDebug.Type.Error);
      }
   }
}