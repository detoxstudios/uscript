// uScript Action Node
// (C) 2014 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Returns the sibling GameObjects of a GameObject with the specified tag.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Siblings By Tag",
              "Searches the target GameObject's parent for siblings using the specified tag.\n\n" +
              "\"Siblings Found\" will fire if one (or more) sibling GameObject is found matching " +
              "the search criteria, otherwise \"Siblings Not Found\" will fire.")]
public class uScriptAct_GetSiblingsByTag : uScriptLogic
{
   private bool m_Out = false;
   public bool Out { get { return m_Out; } }

   private bool m_True = false;
   [FriendlyName("Siblings Found")]
   public bool SiblingsFound { get { return m_True; } }

   [FriendlyName("Siblings Not Found")]
   public bool SiblingsNotFound { get { return !m_True; } }

   public enum SearchType
   {
      Matches,
      Includes,
      Excludes
   }

   public void In (
      [FriendlyName("Target", "The GameObject you wish to search for sibling GameObjects on.")]
      GameObject Target,
      
      [FriendlyName("Tag", "The tag name of the sibling GameObject you are looking for.")]
      string Tag,
      
      [FriendlyName("Search Type", "Use this to specify your search criteria:\n\n" +
       "\t- Matches: The Tag specified must match exactly that of the sibling GameObject\n\n" +
       "\t- Inclusive: The Tag specified must be included within the full tag name of the sibling GameObject\n\n" +
       "\t- Exclusive: The Tag specified must not be found within the full tag name of the sibling GameObject")]
      [SocketState(false, false)]
      SearchType SearchMethod,
      
      [FriendlyName("First Sibling", "The first sibling in the list of siblings.")]
      out GameObject FirstSibling,
      
      [FriendlyName("Siblings", "Assigns found sibling GameObjects to the attached variable.")]
      out GameObject[] Siblings,
      
      [FriendlyName("Sibling Count", "Sets the total number of sibling GameObjects found to the attached variable.")]
      [SocketState(false, false)]
      out int SiblingCount
      )
   {
      m_Out = false;
      m_True = false;
      
      List<GameObject> list = new List<GameObject> ();
      
      if (null != Target)
      {
         list.AddRange(GetSiblings(Target, SearchMethod, Tag));

         SiblingCount = list.Count;
         Siblings = list.ToArray ();

         // Fire out the correct out socket
         m_True = SiblingCount > 0;

         if (m_True) FirstSibling = Siblings[0]; else FirstSibling = null;
      }
      else
      {
         uScriptDebug.Log ("(Node - Get Siblings By Tag): The specified Target GameObject could not be found (was null). Did you specify a valid GameObject?", uScriptDebug.Type.Warning);
         Siblings = null;
         FirstSibling = null;
         SiblingCount = 0;
      }

      m_Out = true;
   }

   private GameObject[] GetSiblings(GameObject Target, SearchType st, string Tag)
   {
      List<GameObject> list = new List<GameObject>();
      
      foreach (Transform child in Target.transform.parent)
      {
         if (st == SearchType.Includes)
         {
            if (child.tag.Contains (Tag) && child != Target.transform)
            {
               GameObject siblingGO = child.gameObject;
               list.Add (siblingGO);
            }
            
         }
         else if (st == SearchType.Excludes)
         {
            if (!child.tag.Contains (Tag))
            {
               GameObject siblingGO = child.gameObject;
               list.Add (siblingGO);
            }
            
         }
         else
         {
            if (child.tag == Tag && child != Target.transform)
            {
               GameObject siblingGO = child.gameObject;
               list.Add (siblingGO);
            }
         }
      }
      
      return list.ToArray();
   }
}
