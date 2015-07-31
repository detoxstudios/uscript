// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Calculate the size of a some content if it is rendered with this style.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]
[NodeDeprecated()]

[FriendlyName("GUI Calculate Style Size", "Calculate the size of a some content if it is rendered with this style.")]
//              + "  \n\nThis node does not take wordwrapping into account. To do that, you need to determine the allocated width and then use GUI Style CalcHeight to figure out the wordwrapped height.")]
public class uScriptAct_GUIStyleCalcSize : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Text", "The text you want to display.")]
      string text,

      [FriendlyName("Texture", "The background image to use for the label.")]
      [SocketState(false, false)]
      Texture texture,

      [FriendlyName("Style", "The name of a custom GUI style to use when displaying this label.")]
      [DefaultValue(""), SocketState(true, false)]
      string styleName,

      [FriendlyName("Size", "The size (in pixels) needed to display the content with the specified style.")]
      out Vector2 size,

      [FriendlyName("Width", "The width (in pixels) needed to display the content with the specified style.")]
      [SocketState(false, false)]
      out int width,

      [FriendlyName("Height", "The height (in pixels) needed to display the content with the specified style.")]
      [SocketState(false, false)]
      out int height
      )
   {
      GUIStyle style = GUI.skin.GetStyle(styleName);
      // GUIStyle style = GUI.skin.FindStyle(styleName);
      if (style == null)
      {
         Debug.LogError("No style was specified!\n");
         size = Vector2.zero;
         width = 0;
         height = 0;
      }
      else
      {
         GUIContent content = new GUIContent(text, texture);

//         Debug.Log(style.name + ":"
//                   + "\n\t margin: \t\t\t\t" + style.margin
//                   + "\t\t alignment: \t\t\t" + style.alignment
//   
//                   + "\n\t padding: \t\t\t" + style.padding
//                   + "\t\t font: \t\t\t\t\t" + style.font
//   
//                   + "\n\t fixedHeight: \t\t" + style.fixedHeight
//                   + "\t\t\t\t\t\t\t\t\t\t fontSize: \t\t\t" + style.fontSize
//   
//                   + "\n\t fixedWidth: \t\t" + style.fixedWidth
//                   + "\t\t\t\t\t\t\t\t\t\t fontStyle: \t\t\t" + style.fontStyle
//   
//                   + "\n\t stretchHeight: \t" + style.stretchHeight
//                   + "\t\t\t\t\t\t\t\t\t imagePosition: \t" + style.imagePosition
//   
//                   + "\n\t stretchWidth: \t\t" + style.stretchWidth
//                   + "\t\t\t\t\t\t\t\t\t lineHeight: \t\t\t" + style.lineHeight
//   
//                   + "\n\t border: \t\t\t\t" + style.border
//                   + "\t\t wordWrap: \t\t\t" + style.wordWrap
//   
//                   + "\n\t overflow: \t\t\t" + style.overflow
//   
//                   + "\n\t clipping: \t\t\t" + style.clipping
//   
//                   + "\n\t contentOffset: \t" + style.contentOffset
//   
//                   + "\n\t isHeightDependantOnWidth: \t\t\t" + style.isHeightDependantOnWidth
//   
//                   + "\n\t states:\t normal( " + style.normal.background + ", " + style.normal.textColor + " )"
//                   + "\n\t\t\t\t hover( " + style.hover.background + ", " + style.hover.textColor + " )"
//                   + "\n\t\t\t\t active( " + style.active.background + ", " + style.active.textColor + " )"
//                   + "\n\t\t\t\t focused( " + style.focused.background + ", " + style.focused.textColor + " )"
//                   + "\n"
//                  );
//   
//         TextAnchor alignment = style.alignment;
//         style.alignment = TextAnchor.UpperLeft;

         size = style.CalcSize(content);
         width = (int)size.x;
         height = (int)size.y;

//         style.alignment = alignment;
//         Debug.Log("RESULTS: " + size.ToString() + ", W:" + width.ToString() + ", H:" + height.ToString() + "\n");
      }
   }
}
