// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows a GUIButton on the screen and allows responses when held down, released, and clicked.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Button", "Shows a GUIButton on the screen and allows responses when held down, released, and clicked.")]
public class uScriptAct_GUIButton : uScriptLogic
{
   private class Identifier
   {
      public Identifier(int _id) { id = _id; wasDown = false; }

      public bool   wasDown;
      public int id;
   }

   private System.Collections.Generic.List<Identifier> m_Identifiers = new System.Collections.Generic.List<Identifier>( );

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("Button Down")]
   public event uScriptEventHandler OnButtonDown;
 
   [FriendlyName("Button Held")]
   public event uScriptEventHandler OnButtonHeld;
 
   [FriendlyName("Button Up")]
   public event uScriptEventHandler OnButtonUp;
 
   [FriendlyName("Button Clicked")]
   public event uScriptEventHandler OnButtonClicked;

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Text", "The text you want to display on the button.")]
      string Text,
      
      [FriendlyName("Unique Identifier", "A unique identifier if the same node is used to represent multiple buttons.")]
      [DefaultValue(0), SocketState(false, false)]
      int identifier,
      
      [FriendlyName("Position", "The position and size of the button.")]
      Rect Position,
      
      [FriendlyName("Texture", "The background image to use for the button.")]
      Texture2D Texture,
      
      [FriendlyName("Tool Tip", "The tool tip to display when the button is being hovered over.")]
      [DefaultValue(""), SocketState(false, false)]
      string ToolTip,
      
      [FriendlyName("GUI Style", "The name of a custom GUI style to use when displaying this button.")]
      [DefaultValue(""), SocketState(false, false)]
      string guiStyle
      )
   {
      Identifier myIdentifier = null;

      foreach ( Identifier id in m_Identifiers )
      {
         if ( id.id == identifier )
         {
            myIdentifier = id;
         }
      }

      if ( myIdentifier == null ) 
      {
         myIdentifier = new Identifier(identifier);
         m_Identifiers.Add( myIdentifier );
      }

      GUIContent content = new GUIContent(Text, Texture, ToolTip);
      bool buttonDown = false;
      
      if (string.IsNullOrEmpty(guiStyle))
      {
         buttonDown = GUI.RepeatButton(Position, content);
      }
      else
      {
         buttonDown = GUI.RepeatButton(Position, content, GUI.skin.GetStyle(guiStyle));
      }
         
      if (Event.current.type == EventType.Repaint || Event.current.isMouse)
      {
         //save state now just incase events cause recursive logic
         bool wasDown = myIdentifier.wasDown;

         myIdentifier.wasDown = buttonDown;

         // down event
         if (!wasDown && buttonDown && OnButtonDown != null) OnButtonDown( this, new System.EventArgs() );

         // held event
         if (wasDown && buttonDown && OnButtonHeld != null) OnButtonHeld( this, new System.EventArgs() );

         // up/clicked event
         if (wasDown && !buttonDown)
         {
            if (OnButtonUp != null) OnButtonUp( this, new System.EventArgs() );
            if (OnButtonClicked != null) OnButtonClicked( this, new System.EventArgs() );
         }         
      }
   }
}
