// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns True or False if collisions are being ignored between Layer A and Layer B.


using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns True or False if collisions are being ignored between Layer A and Layer B.")]
[NodeDescription("Returns True or False if collisions are being ignored between Layer A and Layer B.\n\nLayer A: The first layer.\nLayer B: The second layer.\nResult: True = collisions are being ignored between the layers, False = collisions are NOT being ignored between the layers.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Check Layer Collision")]
public class uScriptAct_CheckLayerCollision : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Layer A")] int LayerA, [FriendlyName("Layer B")] int LayerB, out bool Result)
   {
      if (LayerA < 0) { LayerA = 0; }
      if (LayerA > 31) { LayerA = 31; }
      if (LayerB < 0) { LayerB = 0; }
      if (LayerB > 31) { LayerB = 31; }

      if (LayerA != LayerB)
      {
         Result = Physics.GetIgnoreLayerCollision(LayerA, LayerB);
      }
      else
      {
         Result = false;
      }
   }
}