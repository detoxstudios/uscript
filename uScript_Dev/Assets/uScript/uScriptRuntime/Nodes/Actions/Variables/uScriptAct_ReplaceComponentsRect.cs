// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Replaces the value of one or more components of the target variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Components (Rect)", "Updates the components of the Output variable with values from the Input variable and/or the individual component values specified in the node itself. Hook up both the Input and Output socket to the same variable to have it update itself. You may also use different variables for the Input and Output sockets and set all the components to 'Ignore' in order to use one variable's values to update another directly. Lastly, If no Input is provided, '0' will be used by default for any component not specified directly in the node.")]
public class uScriptAct_ReplaceComponentsRect : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Input", "The variable you wish to use to specify any component default values you do not want to change. This This is usually the same variable you also hook up to the Output socket, but does not have to be.")]
      Rect Target,

      [FriendlyName("xMin", "xMin (left) value to use for the Output Rect")]
      float xMin,

      [FriendlyName("Ignore xMin", "If checked, the xMin (left) value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false,false)]
      bool IgnorexMin,

      [FriendlyName("yMin", "yMin (top) value to use for the Output Rect.")]
      float yMin,

      [FriendlyName("Ignore yMin", "If checked, the yMin (top) value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false, false)]
      bool IgnoreyMin,

      [FriendlyName("Width", "Width value to use for the Output Rect.")]
      float Width,

      [FriendlyName("Ignore Width", "If checked, the Width value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false, false)]
      bool IgnoreWidth,

      [FriendlyName("Height", "Height value to use for the Output Rect.")]
      float Height,

      [FriendlyName("Ignore Height", "If checked, the Height value will not be used. Instead the component value from the Input variable will be used.")]
      [DefaultValue(false), SocketState(false, false)]
      bool IgnoreHeight,

      [FriendlyName("Output", "Sets the components of the variable hooked up to this socket with the values provided. Hook this up to the Input socket as well in order to have it update itself with the provided component value(s).")]
      out Rect Output
      )
   {
      // Grab the values from the Target variable:
      float tempxMin = Target.xMin;
      float tempyMin = Target.yMin;
      float tempWidth = Target.width;
      float tempHeight = Target.height;

      if (!IgnorexMin)
      {
         tempxMin = xMin;
      }
      if (!IgnoreyMin)
      {
         tempyMin = yMin;
      }
      if (!IgnoreWidth)
      {
         tempWidth = Width;
      }
      if (!IgnoreHeight)
      {
         tempHeight = Height;
      }

      // Pass the final component values directly out to the Updated variable.
      Output = new Rect(tempxMin, tempyMin, tempWidth, tempHeight);

   }
}
