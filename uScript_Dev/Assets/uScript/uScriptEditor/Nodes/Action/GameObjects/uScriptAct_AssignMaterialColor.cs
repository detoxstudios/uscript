// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Assigns the Material color of the target GameObject on the specifed material channel.

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Assigns the Material color of the target GameObject on the specifed material channel.")]
[NodeDescription("Assigns the Material color of the target GameObject on the specifed material channel.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Assign Material Color")]
public class uScriptAct_AssignMaterialColor : uScriptLogic
{
   private Material m_NewMaterial;

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("Color")] Color MatColor, [FriendlyName("Material Channel")] int MatChannel)
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