// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Replaces the value of one or more components of the target variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Components (Vector2)", "Updates the components of the Output variable with values from the Input variable and/or the individual component values specified in the node itself. Hook up both the Input and Output socket to the same variable to have it update itself. You may also use different variables for the Input and Output sockets and set all the components to 'Ignore' in order to use one variable's values to update another directly. Lastly, If no Input is provided, '0' will be used by default for any component not specified directly in the node.")]
public class uScriptAct_ReplaceComponentsVector2 : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Input", "The variable you wish to use to specify any component default values you do not want to change. This This is usually the same variable you also hook up to the Output socket, but does not have to be.")]
      Vector2 Target,

      [FriendlyName("X", "X value to use for the Output Vector")]
      float X,

      [FriendlyName("Ignore X", "If checked, the X value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false,false)]
      bool IgnoreX,

      [FriendlyName("Y", "Y value to use for the Output Vector.")]
      float Y,

      [FriendlyName("Ignore Y", "If checked, the Y value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false, false)]
      bool IgnoreY,

      [FriendlyName("Output", "Sets the components of the variable hooked up to this socket with the values provided. Hook this up to the Input socket as well in order to have it update itself with the provided component value(s).")]
      out Vector2 Output
      )
   {
      // Grab the values from the Target variable:
      float tempX = Target.x;
      float tempY = Target.y;

      if (!IgnoreX)
      {
         tempX = X;
      }
      if (!IgnoreY)
      {
         tempY = Y;
      }

      // Pass the final component values directly out to the Updated variable.
      Output = new Vector2(tempX, tempY);

   }
}
