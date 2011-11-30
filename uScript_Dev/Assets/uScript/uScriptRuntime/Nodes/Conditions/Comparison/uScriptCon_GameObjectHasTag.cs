// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a GameObject has the specified tag(s).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GameObject_Has_Tag")]

[FriendlyName("GameObject Has Tag", "Checks to see if a GameObject has the specified tag(s).")]
public class uScriptCon_GameObjectHasTag : uScriptLogic
{
   private bool m_TagsMatched = false;
 
   [FriendlyName("Has Tag")]
   public bool HasTags { get { return m_TagsMatched; } }
   [FriendlyName("Does Not Have Tag")]
   public bool MissingTags { get { return !m_TagsMatched; } }

   public void In(
      [FriendlyName("GameObject", "The GameObject to check.")]
      GameObject GameObject,
      
      [FriendlyName("Tag", "The tag to check for. Can attach multiple to check for multiple tags.")]
      string[] Tag
      )
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