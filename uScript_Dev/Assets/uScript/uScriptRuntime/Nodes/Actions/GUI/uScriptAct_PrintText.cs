// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a label on the screen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Print Text", "Shows a label on the screen. This node does NOT need to be hooked up to an OnGUI Events node.")]
public class uScriptAct_PrintText : uScriptLogic
{
   private string m_Text;
   private float m_Width;
   private float m_Height;
   private float m_RemoveTime;
   private bool m_DisplayText;
   private GUIStyle m_Style = new GUIStyle();


   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Out { get { return true; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in HideLabel()
   [FriendlyName("Show Text")]
   public void ShowLabel(string Text, int FontSize, UnityEngine.FontStyle FontStyle, UnityEngine.Color FontColor, UnityEngine.TextAnchor textAnchor, int EdgePadding, float time)
   {
      m_Text = Text;
      m_Width = Screen.width - EdgePadding;
      m_Height = Screen.height - EdgePadding;

      m_Style.fontSize = FontSize;
      m_Style.fontStyle = FontStyle;
      m_Style.alignment = textAnchor;
      m_Style.normal.textColor = FontColor;

      m_DisplayText = true;
      m_RemoveTime = time;
   }

   [FriendlyName("Hide Text")]
   public void HideLabel(
      [FriendlyName("Text", "The text you want to display.")]
      string Text,
      
      [FriendlyName("Font Size", "The size of the font.")]
      [DefaultValue(16), SocketState(false, false)]
      int FontSize,
      
      [FriendlyName("Font Style", "The font style (Normal,Bold, Italic, BoldAndItalic).")]
      [SocketState(false, false)]
      UnityEngine.FontStyle FontStyle,
      
      [FriendlyName("Color", "The color of the font.")]
      [SocketState(false, false)]
      UnityEngine.Color FontColor,
      
      [FriendlyName("Alignment", "The position of the text on the screen.")]
      [SocketState(false, false)]
      UnityEngine.TextAnchor textAnchor,
      
      [FriendlyName("Edge Padding", "The number of pixels tp offset the text from the edge of the screen.")]
      [DefaultValue(8), SocketState(false, false)]
      int EdgePadding,

      [FriendlyName("Remove After", "The amount of time (in seconds) to wait before automatically removing the text.")]
      [DefaultValue(0.0f), SocketState(false, false)]
      float time
      )
   {
      m_DisplayText = false;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
   public void OnGUI()
   {
      if (m_RemoveTime > 0.0f)
      {
         m_RemoveTime -= Time.deltaTime;
         if (m_RemoveTime <= 0.0f)
         {
            m_RemoveTime = 0.0f;
            m_DisplayText = false;
         }
      }

      if (m_DisplayText)
      {
         float halfHeight = m_Height / 2;
         float halfWidth = m_Width / 2;

         GUI.Label(new Rect(Screen.width / 2 - halfWidth, Screen.height / 2 - halfHeight, m_Width, m_Height), m_Text, m_Style);
      }
   }

}
