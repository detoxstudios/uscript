// uScript Action Node
// (C) 2012 hyenApp LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Game Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event when the graph is Enabled, Disabled, and Destroyed")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Graph Events", "Fires an event when the graph is Enabled, Disabled, and Destroyed.")]
public class uScript_GraphEvents : uScriptLogic 
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   [FriendlyName("On Graph Enable")]
   public event uScriptEventHandler uScriptEnable;

   [FriendlyName("On Graph Disable")]
   public event uScriptEventHandler uScriptDisable;

   [FriendlyName("On Graph Destroy")]
   public event uScriptEventHandler uScriptDestroy;

   public void OnEnable()
   {
      if (null != uScriptEnable) uScriptEnable(this, System.EventArgs.Empty);
   }

   public void OnDisable()
   {
      if (null != uScriptDisable) uScriptDisable(this, System.EventArgs.Empty);
   }
   
   public void OnDestroy()
   {
      if (null != uScriptDestroy) uScriptDestroy(this, System.EventArgs.Empty);
   }
}