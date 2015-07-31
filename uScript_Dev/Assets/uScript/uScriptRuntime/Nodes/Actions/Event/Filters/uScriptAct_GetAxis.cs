// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Events/Filters")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the value of the virtual axis identified by Axis Name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Axis", "Returns the value of the virtual axis identified by Axis Name. The value will be in the range -1...1 for keyboard and joystick input. If the axis is setup to be delta mouse movement, the mouse delta is multiplied by the axis sensitivity and the range is not -1...1. \n\nFor use with the Input Events event node.")]
public class uScriptAct_GetAxis : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Axis Name")]
      string axisName,

      [FriendlyName("Result", "Returns the value of the virtual axis identified by axisName. Examples - 'Verticle' and 'Mouse X'")]
      out float result,

      [FriendlyName("Raw Result", "Returns the value of the virtual axis identified by axisName with no smoothing filtering applied. Since input is not smoothed, keyboard input will always be either -1, 0 or 1. This is useful if you want to do all smoothing of keyboard input processing yourself.")]
      [SocketState(false, false)]
      out float rawResult
      )
   {
      result = Input.GetAxis(axisName);
      rawResult = Input.GetAxisRaw(axisName);
   }
}