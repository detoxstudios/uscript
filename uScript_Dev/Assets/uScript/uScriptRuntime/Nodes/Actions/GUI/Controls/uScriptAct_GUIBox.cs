// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIBox on the screen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Box")]

[FriendlyName("GUI Box", "Shows a GUIBox on the screen.")]
public class uScriptAct_GUIBox : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Text", "The text you want to display.")]
      string Text,
      
      [FriendlyName("Position", "The position and size of the label.")]
      Rect Position,
      
      [FriendlyName("Texture", "The background image to use for the label.")]
      Texture2D Texture,
      
      [FriendlyName("Tool Tip", "The tool tip to display when the label is being hovered over.")]
      [DefaultValue(""), SocketState(false, false)]
      string ToolTip,
      
      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this box.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
      )
   {
      GUIContent content = new GUIContent(Text, Texture, ToolTip);

      if (string.IsNullOrEmpty(guiStyle))
      {
         GUI.Box(Position, content);
      }
      else
      {
         GUI.Box(Position, content, GUI.skin.GetStyle(guiStyle));
      }
   }
}
