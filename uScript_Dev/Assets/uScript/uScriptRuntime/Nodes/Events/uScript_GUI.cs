// uScript uScript_GUI.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires GUI-related events.

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Game Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires GUI-related events.")]
[NodeDescription("Fires GUI-related events.\n \nGUI Changed: Whether or not one of the GUI controls currently displayed had its content data changed. NOTE: This is not control-specific, it is global.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Events")]

[FriendlyName("GUI Events")]
public class uScript_GUI : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, GUIEventArgs args);

   public class GUIEventArgs : System.EventArgs
   {
      private bool m_GUIChanged;
      private string m_FocusedControl;

      [FriendlyName("GUI Changed")]
      public bool GUIChanged { get { return m_GUIChanged; } }

      [FriendlyName("Focused Control")]
      public string FocusedControl { get { return m_FocusedControl; } }

      public GUIEventArgs(bool guiChanged, string focusedControl)
      {
         m_GUIChanged = guiChanged;
         m_FocusedControl = focusedControl;
      }
   }

   [FriendlyName("On GUI")]
   public event uScriptEventHandler OnGui;
   
   void OnGUI()
   {
      if ( OnGui != null ) OnGui(this, new GUIEventArgs(GUI.changed, GUI.GetNameOfFocusedControl()));
   }
}
