// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Make a grid of buttons.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Text_Area")]

[FriendlyName("GUI Selection Grid", "Make a grid of buttons.")]
public class uScriptAct_GUISelectionGrid : uScriptLogic
{
/*
   TODO: Add support for passing Texture[] and GUIContent[] to the buttons
*/
   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }
   private bool m_Changed = false;

   public void In(
      [FriendlyName("Selected", "The index of the selected grid button.")]
      ref int Value,
      
      [FriendlyName("Position", "Rectangle on the screen to use for the grid.")]
      Rect Position,

      [FriendlyName("Text Content", "An array of strings to show on the grid buttons.")]
      string[] Content,

      [FriendlyName("xCount", "How many elements to fit in the horizontal direction. The controls will be scaled to fit unless the style defines a fixedWidth to use.")]
      [DefaultValue(50)]
      int xCount,
      
      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this text aera.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
      )
   {
      int value;
      m_Changed = false;

      if (string.IsNullOrEmpty(guiStyle))
      {
         value = GUI.SelectionGrid(Position, Value, Content, xCount);
      }
      else
      {
         value = GUI.SelectionGrid(Position, Value, Content, xCount, GUI.skin.GetStyle(guiStyle));
      }

      // changed event
      if (Value != value)
      {
         m_Changed = true;
      }

      Value = value;
   }
}
