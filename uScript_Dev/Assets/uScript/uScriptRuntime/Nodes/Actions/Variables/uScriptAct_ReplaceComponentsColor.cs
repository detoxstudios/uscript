// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Replaces the value of one or more components of the target variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Components (Color)", "Updates the components of the Output variable with values from the Input variable and/or the individual component values specified in the node itself. Hook up both the Input and Output socket to the same variable to have it update itself. You may also use different variables for the Input and Output sockets and set all the components to 'Ignore' in order to use one variable's values to update another directly. Lastly, If no Input is provided, '0' will be used by default for any component not specified directly in the node.")]
public class uScriptAct_ReplaceComponentsColor : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Input", "The variable you wish to use to specify any component default values you do not want to change. This This is usually the same variable you also hook up to the Output socket, but does not have to be.")]
      Color Target,

      [FriendlyName("Red", "Red value to use for the Output Color")]
      float Red,

      [FriendlyName("Ignore Red", "If checked, the Red value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false,false)]
      bool IgnoreRed,

      [FriendlyName("Green", "Green value to use for the Output Color.")]
      float Green,

      [FriendlyName("Ignore Green", "If checked, the Green value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false, false)]
      bool IgnoreGreen,

      [FriendlyName("Blue", "Blue value to use for the Output Color.")]
      float Blue,

      [FriendlyName("Ignore Blue", "If checked, the Blue value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false, false)]
      bool IgnoreBlue,

      [FriendlyName("Alpha", "Alpha value to use for the Output Color.")]
      float Alpha,

      [FriendlyName("Ignore Alpha", "If checked, the Alpha value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false, false)]
      bool IgnoreAlpha,

      [FriendlyName("Output", "Sets the components of the variable hooked up to this socket with the values provided. Hook this up to the Input socket as well in order to have it update itself with the provided component value(s).")]
      out Color Output
      )
   {
      // Grab the values from the Target variable:
      float tempRed = Target.r;
      float tempGreen = Target.g;
      float tempBlue = Target.b;
      float tempAlpha = Target.a;

      if (!IgnoreRed)
      {
         tempRed = Red;
      }
      if (!IgnoreGreen)
      {
         tempGreen = Green;
      }
      if (!IgnoreBlue)
      {
         tempBlue = Blue;
      }
      if (!IgnoreAlpha)
      {
         tempAlpha = Alpha;
      }

      // Pass the final component values directly out to the Updated variable.
      Output = new Color(tempRed, tempGreen, tempBlue, tempAlpha);

   }
}
