// uScript Action Node
// (C) 2020 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2020 by Detox Studios LLC")]
[NodeToolTip("Sets the position (Vector3) of a Transform as world or local coordinates.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Position (Transform)", "Sets the position (Vector3) of a Transform as world or local coordinates.")]
public class uScriptAct_SetTransformPosition : uScriptLogic
{

    public bool Out { get { return true; } }

    public void In(
      [FriendlyName("Target", "The Target Transform(s) to set the position of."), AutoLinkType(typeof(Transform))]
      Transform[] Target,

      [FriendlyName("Position", "The position to set the Target GameObjects to. If \"As Offset\" is enabled, this value will be used as an offest from the target's current position.")]
      Vector3 Position,

      [FriendlyName("As Offset", "Whether or not to use Position as an offset from the Target GameObjects' position(s).")]
      [SocketState(false, false)]
      bool AsOffset,

      [FriendlyName("As Local", "Whether or not to set the local (instead of world) position(s) of the Target GameObjects'.")]
      [SocketState(false, false)]
      [DefaultValue(false)]
      bool AsLocal
      )
    {
       foreach (Transform currentTarget in Target)
       {
          if (currentTarget != null)
          {
             if (AsOffset)
             {
                if (AsLocal)
                {
                   currentTarget.localPosition += Position;
                }
                else
                {
                   currentTarget.position += Position;
                }
             }
             else
             {
                if (AsLocal)
                {
                   currentTarget.localPosition = Position;
                }
                else
                {
                   currentTarget.position = Position;
                }
             }
          }
       }
    }
}
