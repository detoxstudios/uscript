// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Opens the user's default web browser to the specified URL.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Open Browser", "Opens the user's default web browser to the specified URL.")]
public class uScriptAct_OpenBrowser : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("URL", "The web address you wish to open. Example: http://www.yourdomain.com/subdirectory/somepage.html")]
      [DefaultValue("")]
      string URL
      )
   {
      Application.OpenURL(URL);
   }
}
