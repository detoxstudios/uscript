// uScript uScript_GUI.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodeAutoAssignMasterInstance(true)]

[NodePath("Events/Game Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires GUI-related events.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Events", "Fires GUI-related events.")]
public class uScript_GUI : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, GUIEventArgs args);

   public class GUIEventArgs : System.EventArgs
   {
      private bool m_GUIChanged;
      private string m_FocusedControl;

      [FriendlyName("GUI Changed", "Returns True when any active GUI control has its content data changed. NOTE: This is not control-specific, it is global.")]
      [SocketState(false, false)]
      public bool GUIChanged { get { return m_GUIChanged; } }

      [FriendlyName("Focused Control", "Returns the GUI control that has focus.")]
      [SocketState(false, false)]
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
