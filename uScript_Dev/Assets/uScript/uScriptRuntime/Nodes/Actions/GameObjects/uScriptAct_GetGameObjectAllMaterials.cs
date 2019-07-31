// uScript Action Node
// (C) 2019 Detox Studios LLC

using System.Collections.Generic;
using UnityEngine;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2019 by Detox Studios LLC")]
[NodeToolTip("Returns a GameObject's materials, material colors, and material names.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get All Materials", "Returns a GameObject's materials, material colors, and material names.")]
public class uScriptAct_GetGameObjectAllMaterials : uScriptLogic
{

    public bool Out { get { return true; } }

    public void In(
      [FriendlyName("Target", "The Target GameObject you wish to get the material information from.")]
      GameObject Target,

       [FriendlyName("Materials", "Returns the materials.")]
      out Material[] targetMaterials,

       [FriendlyName("Colors", "Returns the colors of the material.")]
      [SocketState(false, false)]
      out UnityEngine.Color[] materialColors,

       [FriendlyName("Names", "Returns the names of the material.")]
      [SocketState(false, false)]
      out string[] materialNames
       )
    {

        if (Target != null)
        {
            List<Material> materials = new List<Material>();
            List<Color> colors = new List<Color>();
            List<string> names = new List<string>();
            foreach (Material mat in Target.GetComponent<Renderer>().materials)
            {
                materials.Add(mat);
                names.Add(mat.name);

                if (mat.HasProperty("_Color"))
                    colors.Add(mat.color);
                else
                    colors.Add(UnityEngine.Color.white);
            }
            targetMaterials = materials.ToArray();
            materialColors = colors.ToArray();
            materialNames = names.ToArray();
        }
        else
        {
            uScriptDebug.Log("The specified Target GameObject does not exist.", uScriptDebug.Type.Warning);
            targetMaterials = null;
            materialColors = new Color[] { };
            materialNames = new string[] { };
        }

    }
}
