// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Checks to see if a GameObject has the specified tag(s).

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a GameObject has the specified tag(s).")]
[NodeDescription("Checks to see if a GameObject has the specified tag(s).\n \nGameObject: The GameObject to check.\nTag: The tag to check for. Can attach multiple to check for multiple tags.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("GameObject Has Tag")]
public class uScriptCon_GameObjectHasTag : uScriptLogic
{
   private bool m_TagsMatched = false;
 
   [FriendlyName("Has Tag")]
   public bool HasTags { get { return m_TagsMatched; } }
   [FriendlyName("Does Not Have Tag")]
   public bool MissingTags { get { return !m_TagsMatched; } }

   public void In(GameObject GameObject, string []Tag)
   {
      foreach(string tag in Tag)
      {
         if (!GameObject.CompareTag(tag))
         {
            m_TagsMatched = false;
            return;
         }
      }
      
      m_TagsMatched = true;
   }
}