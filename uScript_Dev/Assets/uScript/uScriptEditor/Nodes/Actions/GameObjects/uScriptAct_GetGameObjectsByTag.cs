// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the GameObjects in the scene with the specified tag.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the GameObjects in the scene with the specified tag.")]
[NodeDescription("Returns the GameObjects in the scene with the specified tag. The \"GameObjects Found\" output socket will be triggered if at least one child GameObject matching the tag is found, otherwise the \"GameObjects Not Found\" output socket will be triggered.\n\nTag (In): The tag name of the GameObjects you are looking for.\nFirst GameObject (Out): The first GameObject in the list of GameObjects.\nGameObjects (Out): Assigns found GameObjects to the attached variable\nGameObject Count (Out): Sets the total number of GameObjects found to the attached variable\n\nOutput Sockets:\nOut: The standard output socket (always fired).\nGameObjects Found: Fired once if at least on GameObject is found.\nGameObjects Not Found: Fired once if no GameObject is found.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Find GameObjects By Tag")]
public class uScriptAct_FindGameObjectsByTag : uScriptLogic
{
   private bool m_Out = false;
   public bool Out { get { return m_Out; } }

   private bool m_True = false;
   [FriendlyName("GameObjects Found")]
   public bool ChildrenFound { get { return m_True; } }

   [FriendlyName("GameObjects Not Found")]
   public bool ChildrenNotFound { get { return !m_True; } }

   public void In (
                   [FriendlyName("Tag")] string Tag,
                   [FriendlyName("First GameObject")] out GameObject FirstChild,
                   [FriendlyName("GameObjects")] out GameObject[] Children,
                   [FriendlyName("GameObject Count"), SocketState(false, false)] out int ChildrenCount
                   )
   {
      m_Out = false;
      
      Children = GameObject.FindGameObjectsWithTag(Tag);
      FirstChild = Children[0];
      ChildrenCount = Children.Length;

      // Fire out the correct true/false out socket
      m_True = ChildrenCount > 0;

      m_Out = true;
   }
}
