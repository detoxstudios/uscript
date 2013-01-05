// uScript Action Node
// (C) 2013 Detox Studios LLC
using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Make a grid of buttons.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_Selection_Grid")]

[FriendlyName("GUILayout Selection Grid", "Make a grid of buttons.")]
public class uScriptAct_GUILayoutSelectionGrid : uScriptLogic
{
   private bool m_Changed = false;

   public bool Out { get { return true; } }

   [FriendlyName("Changed")]
   public bool Changed { get { return m_Changed; } }

   public void In(
      [FriendlyName("Selected", "The index of the selected grid button.")]
      ref int Value,
      
      [FriendlyName("Text List", "An array of strings to show on the grid buttons.")]
      string[] TextList,

      [FriendlyName("Texture List", "An array of textures to show on the grid buttons.")]
      [SocketState(false, false)]
      Texture[] TextureList,

//      [FriendlyName("Tooltip List", "An array of tooltips to show on the grid buttons.")]
//      [SocketState(false, false)]
//      string[] TooltipList,
//
      [FriendlyName("xCount", "How many elements to fit in the horizontal direction. The controls will be scaled to fit unless the style defines a fixedWidth to use.")]
      [DefaultValue(50), SocketState(false, false)]
      int xCount,

      [FriendlyName("Style", "The style to use. If left out, the \"button\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string Style,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options
   )
   {
      List<GUIContent> content = new List<GUIContent>();

      int longestList = Mathf.Max(TextList.Length, TextureList.Length);
//      int longestList = Mathf.Max(TextList.Length, Mathf.Max(TextureList.Length, TooltipList.Length));
      for (int i = 0; i < longestList; i++)
      {
         GUIContent newContent = new GUIContent();

         if (TextList.Length > i)
         {
            newContent.text = TextList[i];
         }

         if (TextureList.Length > i)
         {
            newContent.image = TextureList[i];
         }

//         if (TooltipList.Length > i)
//         {
//            newContent.tooltip = TooltipList[i];
//         }
//
         content.Add(newContent);
      }

      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUI.skin.button : GUI.skin.GetStyle(Style));

      m_Changed = false;
      int value = GUILayout.SelectionGrid(Value, content.ToArray(), xCount, style, Options);

      // changed event
      if (Value != value)
      {
         m_Changed = true;
      }

      Value = value;
   }
}
