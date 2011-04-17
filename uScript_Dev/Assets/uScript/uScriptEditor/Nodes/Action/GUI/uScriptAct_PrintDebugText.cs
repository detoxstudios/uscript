// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a label on the screen. Must be hooked to an OnGUI Event.

using UnityEngine;
using System.Collections;

[NodePath("Action/GUI")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a label on the screen. Must be hooked to an OnGUI Event.")]
[NodeDescription("Shows a label on the screen. Must be hooked to an OnGUI Event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

// @TODO: This node has some hard coded stuff in it until property pull down lists (enums) are working.

[FriendlyName("Print Debug Text")]
public class uScriptAct_PrintDebugText : uScriptLogic
{
   private string m_Text;
   //private float m_X;
   //private float m_Y;
   private float m_Width;
   private float m_Height;
   //private bool m_CenterOnScreen;
   private bool m_DisplayText;
   private GUIStyle m_Style = new GUIStyle();
         


   public bool Out { get { return true; } }

   
   [FriendlyName("Show Text")]
   public void ShowLabel(string Text, [FriendlyName("Font Size")] int FontSize, [FriendlyName("CenterText")] bool CenterText)
   {
      Debug.Log("Show Label fired");
      m_Text = Text;
      //m_X = X;
      //m_Y = Y;
      m_Width = Screen.width - 32f;
      m_Height = Screen.height - 32f;
      //m_CenterOnScreen = CenterText;

      m_Style.fontSize = FontSize;
      m_Style.fontStyle = FontStyle.Bold;

      if (CenterText)
      {
         m_Style.alignment = TextAnchor.UpperCenter;
      }
      else
      {
         m_Style.alignment = TextAnchor.UpperLeft;
      }
      
      m_Style.normal.textColor = UnityEngine.Color.yellow;
      
      m_DisplayText = true;

   }

   [FriendlyName("Hide Text")]
   public void HideLabel(string Text, [FriendlyName("Font Size")] int FontSize, [FriendlyName("CenterText")] bool CenterText)
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
