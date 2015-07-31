// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if a GameObject has the specified tag(s).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GameObject Has Tag", "Checks to see if a GameObject has the specified tag(s).")]
public class uScriptCon_GameObjectHasTag : uScriptLogic
{
   private bool m_AllTagsMatched = false;
   private bool m_NoTagsMatched  = true;
 
   [FriendlyName("Has All Tags")]
   public bool HasAllTags { get { return m_AllTagsMatched; } }
   [FriendlyName("Has At Least One Tag")]
   public bool HasTag { get { return !m_NoTagsMatched; } }
   [FriendlyName("Does Not Have Tags")]
   public bool MissingTags { get { return m_NoTagsMatched; } }

   public void In(
      [FriendlyName("GameObject", "The GameObject to check.")]
      GameObject GameObject,
      
      [FriendlyName("Tag", "The tag to check for. Can attach multiple to check for multiple tags.")]
      string[] Tag
      )
   {
      m_AllTagsMatched = true;
      m_NoTagsMatched  = true;

      foreach(string tag in Tag)
      {
         if (!GameObject.CompareTag(tag))
         {
            m_AllTagsMatched = false;
         }
         else
         {
            m_NoTagsMatched = false;
         }
      }
   }
}