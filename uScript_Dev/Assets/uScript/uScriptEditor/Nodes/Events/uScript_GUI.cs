// uScript uScript_GUI.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires GUI-related events.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Event Components/GUI")]
[NodeAutoAssignMasterInstance(true)]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Game Events")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires GUI-related events.")]
[NodeDescription("Fires GUI-related events.\n \nGUI Changed: Whether or not one of the GUI controls currently displayed had its content data changed. NOTE: This is not control-specific, it is global.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Events")]
public class uScript_GUI : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, GUIEventArgs args);

   public class GUIEventArgs : System.EventArgs
   {
      private bool m_GUIChanged;

      [FriendlyName("GUI Changed")]
      public bool GUIChanged { get { return m_GUIChanged; } }

      public GUIEventArgs(bool guiChanged)
      {
         m_GUIChanged = guiChanged;
      }
   }

   [FriendlyName("On GUI")]
   public event uScriptEventHandler OnGui;
   
   void OnGUI()
   {
      if ( OnGui != null ) OnGui(this, new GUIEventArgs(GUI.changed));
   }
}
