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
[NodeDescription("Returns the children GameObjects of a parent GameObject with the specified tag. The \"Children Found\" output socket will be triggered if at least one child GameObject matching the tag is found, otherwise the \"Children Not Found\" output socket will be triggered.\n\nTarget (In): The parent GameObject you wish to search for children GameObjects on.\nTag (In): The tag name of the child GameObject you are looking for.\nSearch Type (In): Use this to specify your search criteria:\n\tMatches - The Tag specified must match exactly that of the child GameObject\n\tInclusive - The Tag specified must be included within the full tag name of the child GameObject\n\tExclusive - The Tag specified must not be found within the full tag name of the child GameObject\nChildren (Out): Assigns found children GameObjects to the attached variable\nChildren Count (Out): Sets the total number of childrenGameObjects found to the attached variable\n\nOutput Sockets:\nOut: The standard output socket (always fired).\nChildren Found: Fired once if at least on child GameObject is found.\nChildren Not Found: Fired once if no child GameObject is found.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get Children By Tag")]
public class uScriptAct_GetChildrenByTag : uScriptLogic
{

   // @TODO: How do we let the user hook up either a GameObject or a GameObject List to the out socket? Righ now it can only be a GameObject List.
   // @TODO: What should we do if no child GameObjects were found? Just return null?

   private bool m_Out = false;
   public bool Out { get { return m_Out; } }

   private bool m_True = false;
   [FriendlyName("Children Found")]
   public bool ChildrenFound { get { return m_True; } }

   private bool m_False = false;
   [FriendlyName("Children Not Found")]
   public bool ChildrenNotFound { get { return m_False; } }

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
                   [FriendlyName("Children")] out GameObject[] Children,
                   [FriendlyName("Children Count"), SocketState(false, false)] out int ChildrenCount
                   )
   {
      
      m_Out = false;
      m_True = false;
      m_False = false;
      
      bool foundChildren = false;
      
      List<GameObject> list = new List<GameObject> ();
      int totalChildren = 0;
      SearchType st = SearchMethod;
      
      if (null != Target)
      {

         foreach (Transform child in Target.transform)
         {
            if (st == SearchType.Includes)
            {
               if (child.tag.Contains (Tag))
               {
                  GameObject childGO = child.gameObject;
                  list.Add (childGO);
                  totalChildren++;
                  foundChildren = true;
               }
               
            }
            else if (st == SearchType.Excludes)
            {
               if (!child.tag.Contains (Tag))
               {
                  GameObject childGO = child.gameObject;
                  list.Add (childGO);
                  totalChildren++;
                  foundChildren = true;
               }
               
            }
            else
            {
               if (child.tag == Tag)
               {
                  GameObject childGO = child.gameObject;
                  list.Add (childGO);
                  totalChildren++;
                  foundChildren = true;
               }
            }
         }

         Children = list.ToArray ();
         ChildrenCount = totalChildren;

      // Fire out the correct true/false out socket
         if (foundChildren) {
            m_True = true;
         } else {
            m_False = true;
         }

      }
      else
      {
         uScriptDebug.Log ("(Node - Get Children By Tag): The specified Target GameObject could not be found (was null). Did you specify a valid GameObject?", uScriptDebug.Type.Warning);
         Children = null;
         ChildrenCount = 0;
      }

      m_Out = true;
      
   }
}
