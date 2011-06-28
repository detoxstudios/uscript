// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the children GameObjects of a parent GameObject with the specified tag.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the children GameObjects of a parent GameObject with the specified tag.")]
[NodeDescription("Returns the children GameObjects of a parent GameObject with the specified tag. The \"Children Found\" output socket will be triggered if at least one child GameObject matching the tag is found, otherwise the \"Children Not Found\" output socket will be triggered.\n\nTarget (In): The parent GameObject you wish to search for children GameObjects on.\nTag (In): The tag name of the child GameObject you are looking for.\nSearch Type (In): Use this to specify your search criteria:\n\tMatches - The Tag specified must match exactly that of the child GameObject\n\tInclusive - The Tag specified must be included within the full tag name of the child GameObject\n\tExclusive - The Tag specified must not be found within the full tag name of the child GameObject\nSearch In Children (in): Whether or not to return children of children.\nFirst Child (Out): The first child in the list of Children.\nChildren (Out): Assigns found children GameObjects to the attached variable\nChildren Count (Out): Sets the total number of childrenGameObjects found to the attached variable\n\nOutput Sockets:\nOut: The standard output socket (always fired).\nChildren Found: Fired once if at least on child GameObject is found.\nChildren Not Found: Fired once if no child GameObject is found.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Children By Tag")]
public class uScriptAct_GetChildrenByTag : uScriptLogic
{
   private bool m_Out = false;
   public bool Out { get { return m_Out; } }

   private bool m_True = false;
   [FriendlyName("Children Found")]
   public bool ChildrenFound { get { return m_True; } }

   [FriendlyName("Children Not Found")]
   public bool ChildrenNotFound { get { return !m_True; } }

   public enum SearchType
   {
      Matches,
      Includes,
      Excludes
   }

   public void In (
                   [FriendlyName("Target")] GameObject Target,
                   [FriendlyName("Tag")] string Tag,
                   [FriendlyName("Search Type"), SocketState(false, false)] SearchType SearchMethod,
                   [FriendlyName("Search In Children"), SocketState(false, false), DefaultValue(false)] bool recursive,
                   [FriendlyName("First Child")] out GameObject FirstChild,
                   [FriendlyName("Children")] out GameObject[] Children,
                   [FriendlyName("Children Count"), SocketState(false, false)] out int ChildrenCount
                   )
   {
      m_Out = false;
      m_True = false;
      
      List<GameObject> list = new List<GameObject> ();
      
      if (null != Target)
      {

         foreach (Transform child in Target.transform)
         {
            list.AddRange(GetChildren(recursive, child.gameObject, SearchMethod, Tag));
         }

         ChildrenCount = list.Count;
         Children = list.ToArray ();

         // Fire out the correct out socket
         m_True = ChildrenCount > 0;

         if (m_True) FirstChild = Children[0]; else FirstChild = null;
      }
      else
      {
         uScriptDebug.Log ("(Node - Get Children By Tag): The specified Target GameObject could not be found (was null). Did you specify a valid GameObject?", uScriptDebug.Type.Warning);
         Children = null;
         FirstChild = null;
         ChildrenCount = 0;
      }

      m_Out = true;
   }

   private GameObject[] GetChildren(bool recursive, GameObject Target, SearchType st, string Tag)
   {
      List<GameObject> list = new List<GameObject>();
      
      foreach (Transform child in Target.transform)
      {
         if (recursive)
         {
            list.AddRange(GetChildren(recursive, child.gameObject, st, Tag));
         }
         
         if (st == SearchType.Includes)
         {
            if (child.tag.Contains (Tag))
            {
               GameObject childGO = child.gameObject;
               list.Add (childGO);
            }
            
         }
         else if (st == SearchType.Excludes)
         {
            if (!child.tag.Contains (Tag))
            {
               GameObject childGO = child.gameObject;
               list.Add (childGO);
            }
            
         }
         else
         {
            if (child.tag == Tag)
            {
               GameObject childGO = child.gameObject;
               list.Add (childGO);
            }
         }
      }
      
      return list.ToArray();
   }
}
