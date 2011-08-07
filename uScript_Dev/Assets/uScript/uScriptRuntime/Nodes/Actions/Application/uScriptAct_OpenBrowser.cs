// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Opens the user's default web browser to the specified URL.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Opens the user's default web browser to the specified URL.")]
[NodeDescription("Opens the user's default web browser to the specified URL.\n\nURL: The web address you wish to open. Example: http://www.yourdomain.com/subdirectory/somepage.html")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Open Browser")]
public class uScriptAct_OpenBrowser : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("URL"), DefaultValue("")] string URL)
   {
      Application.OpenURL(URL);
   }
}