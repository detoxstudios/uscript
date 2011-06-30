// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a label on the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a label on the screen.")]
[NodeDescription("Shows a label on the screen.\n \nText: The text you want to display. \nFont Size: The size of the font.\nFont Style: The font style (Normal,Bold, Italic, BoldAndItalic).\nColor: The color of the font.\nAlignment: The position of the text on the screen.\nEdge Padding: The number of pixels tp offset the text from the edge of the screen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Print_Text")]

[FriendlyName("Print Text")]
public class uScriptAct_PrintText : uScriptLogic
{
   private string m_Text;
   private float m_Width;
   private float m_Height;
   private bool m_DisplayText;
   private GUIStyle m_Style = new GUIStyle();

   public bool Out { get { return true; } }

   [FriendlyName("Show Text")]
   public void ShowLabel(
      string Text,
      [FriendlyName("Font Size"), DefaultValue(16), SocketState(false, false)] int FontSize,
      [FriendlyName("Font Style"), SocketState(false, false)] UnityEngine.FontStyle FontStyle,
      [FriendlyName("Color"), SocketState(false, false)] UnityEngine.Color FontColor,
      [FriendlyName("Alignment"), SocketState(false, false)] UnityEngine.TextAnchor textAnchor,
      [FriendlyName("Edge Padding"), DefaultValue(8), SocketState(false, false)] int EdgePadding
      )
   {
      m_Text = Text;
      m_Width = Screen.width - EdgePadding;
      m_Height = Screen.height - EdgePadding;

      m_Style.fontSize = FontSize;
      m_Style.fontStyle = FontStyle;

      m_Style.alignment = textAnchor;

      m_Style.normal.textColor = FontColor;

      m_DisplayText = true;
   }

   [FriendlyName("Hide Text")]
   public void HideLabel(
      string Text,
      [FriendlyName("Font Size"), DefaultValue(16), SocketState(false, false)] int FontSize,
      [FriendlyName("Font Style"), SocketState(false, false)] UnityEngine.FontStyle FontStyle,
      [FriendlyName("Color"), SocketState(false, false)] UnityEngine.Color FontColor,
      [FriendlyName("Alignment"), SocketState(false, false)] UnityEngine.TextAnchor textAnchor,
      [FriendlyName("Edge Padding"), DefaultValue(8), SocketState(false, false)] int EdgePadding
      )
   {
      m_DisplayText = false;
   }

   public override void OnGUI()
   {
      if (m_DisplayText)
      {
         float halfHeight = m_Height / 2;
         float halfWidth = m_Width / 2;

         GUI.Label(new Rect(Screen.width / 2 - halfWidth, Screen.height / 2 - halfHeight, m_Width, m_Height), m_Text, m_Style);
      }
   }
}