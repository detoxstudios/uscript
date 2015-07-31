// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the layer for the target GameObjects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Layer", "Sets the layer for the target GameObjects.")]
public class uScriptAct_SetLayer : uScriptLogic
{
   private bool m_ApplyToChildren;
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) you wish to set the layer for."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Layer", "The Layer you wish to set the Target(s) to.")]
      LayerMask Layer,

      [FriendlyName("Apply To Children", "Specify if the Layer should also be assigned to any children GameObjects of the Target if found.")]
      [SocketState(false, false), DefaultValue(true)]
      bool ApplyToChildren
      )
   {
      m_ApplyToChildren = ApplyToChildren;

      int index = 0;

      for (index = 0; index < 32; index++)
      {
         if (((Layer.value >> index) & 0x1) != 0) break;
      }

      foreach (GameObject obj in Target)
      {
         Transform objTrans = obj.transform;
         SetGameObjectLayer(objTrans, index);
      }

   }


   private void SetGameObjectLayer(Transform obj, int newLayer)
   {
      obj.gameObject.layer = newLayer;

      if (m_ApplyToChildren)
      {
         foreach (Transform child in obj)
         {
            SetGameObjectLayer(child, newLayer);
         }
      }
   }

}
