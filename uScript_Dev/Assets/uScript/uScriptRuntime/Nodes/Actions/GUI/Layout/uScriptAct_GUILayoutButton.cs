// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Shows a GUI Button on the screen using Unity's automatic layout system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUILayout Button", "Shows a GUI Button on the screen using Unity's automatic layout system. The button will trigger events when Clicked, but also on Down, Held, and Up events.")]
public class uScriptAct_GUILayoutButton : uScriptLogic
{
   private class Identifier
   {
      public int id;
      public bool wasDown;

      public Identifier(int id)
      {
         this.id = id;
         this.wasDown = false;
      }
   }

   private System.Collections.Generic.List<Identifier> m_Identifiers = new System.Collections.Generic.List<Identifier>();

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("Button Clicked")]
   public event uScriptEventHandler OnButtonClicked;
   [FriendlyName("Button Down")]
   public event uScriptEventHandler OnButtonDown;
   [FriendlyName("Button Held")]
   public event uScriptEventHandler OnButtonHeld;
   [FriendlyName("Button Up")]
   public event uScriptEventHandler OnButtonUp;

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Text", "Text to display on the button.")]
      string Text,

      [FriendlyName("Texture", "Texture to display on the button.")]
      [SocketState(false, false)]
      Texture Texture,

      [FriendlyName("Tooltip", "The tooltip associated with this control.")]
      [DefaultValue(""), SocketState(false, false)]
      string Tooltip,

      [FriendlyName("Style", "The style to use. If left out, the \"button\" style from the current GUISkin is used.")]
      [DefaultValue(""), SocketState(false, false)]
      string Style,

      [FriendlyName("Options", "An optional list of layout parameters.  Any values passed in here will override settings defined by the style.")]
      [SocketState(false, false)]
      GUILayoutOption[] Options,

      [FriendlyName("Unique Identifier", "If the same node is used to represent multiple buttons, specify a unique identifier.")]
      [DefaultValue(0), SocketState(false, false)]
      int identifier
      )
   {
      Identifier myIdentifier = null;

      foreach (Identifier id in m_Identifiers)
      {
         if (id.id == identifier)
         {
            myIdentifier = id;
         }
      }

      if (myIdentifier == null)
      {
         myIdentifier = new Identifier(identifier);
         m_Identifiers.Add(myIdentifier);
      }

      GUIContent content = new GUIContent(Text, Texture, Tooltip);
      GUIStyle style = (string.IsNullOrEmpty(Style) ? GUI.skin.button : GUI.skin.GetStyle(Style));

      bool buttonDown = false;

      buttonDown = GUILayout.RepeatButton(content, style, Options);

      if (Event.current.type == EventType.Repaint || Event.current.isMouse)
      {
         //save state now just incase events cause recursive logic
         bool wasDown = myIdentifier.wasDown;

         myIdentifier.wasDown = buttonDown;

         // down event
         if (!wasDown && buttonDown && OnButtonDown != null)
            OnButtonDown(this, new System.EventArgs());

         // held event
         if (wasDown && buttonDown && OnButtonHeld != null)
            OnButtonHeld(this, new System.EventArgs());

         // up/clicked event
         if (wasDown && !buttonDown)
         {
            if (OnButtonUp != null)
               OnButtonUp(this, new System.EventArgs());
            if (OnButtonClicked != null)
               OnButtonClicked(this, new System.EventArgs());
         }
      }
   }
}
