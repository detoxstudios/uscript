// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the layer for the target GameObjects.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the layer for the target GameObjects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_GameObject_By_Name")]

[FriendlyName("Set Layer", "Sets the layer for the target GameObjects.")]
public class uScriptAct_SetLayer : uScriptLogic
{
   private bool m_ApplyToChildren;
	public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) you wish to set the layer for.")]
      GameObject[] Target,

      [FriendlyName("Layer", "The Layer you wish to set the Target(s) to.")]
      LayerMask Layer,

      [FriendlyName("Apply To Children", "Specify if the Layer should also be assigned to any children GameObjects of the Target if found.")]
      [SocketState(false, false), DefaultValue(true)]
      bool ApplyToChildren
      )
   {
		m_ApplyToChildren = ApplyToChildren;
		
      foreach (GameObject obj in Target)
	  {
			Transform objTrans = obj.transform;
	     SetGameObjectLayer(objTrans, Layer.value);
	  }
		
   }
	
	
   private void SetGameObjectLayer(Transform obj, int newLayer)
   {
      obj.gameObject.layer = newLayer;
		
		if(m_ApplyToChildren)
		{
			foreach(Transform child in obj)
			{
				SetGameObjectLayer(child, newLayer);
			}
		}
   }
	
}





/*
	function SetLayerRecursively( obj : GameObject, newLayer : int  )
{
	obj.layer = newLayer;
	
	for( var child : Transform in obj.transform )
	{
		SetLayerRecursively( child.gameObject, newLayer );
	}
}
	
	*/
