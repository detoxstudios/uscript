// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the children GameObjects of a parent GameObject with the specified name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Children_By_Name")]

[FriendlyName("Get Children By Name",
              "Searches the target GameObject for children using the specified name.\n\n" +
              "\"Children Found\" will fire if one (or more) child GameObject is found matching " +
              "the search criteria, otherwise \"Children Not Found\" will fire.")]
public class uScriptAct_GetChildrenByName : uScriptLogic
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
      [FriendlyName("Target", "The parent GameObject you wish to search for children GameObjects on.")]
      GameObject Target,
      
      [FriendlyName("Name", "The name of the child GameObject you are looking for.")]
      string Name,

      [FriendlyName("Search Type", "Use this to specify your search criteria:\n\n" +
       "\t- Matches: The Name specified must match exactly that of the child GameObject\n\n" +
       "\t- Inclusive: The Name specified must be included within the full name of the child GameObject\n\n" +
       "\t- Exclusive: The Name specified must not be found within the full name of the child GameObject")]
      [SocketState(false, false)]
      SearchType SearchMethod,

      [FriendlyName("Search In Children", "Whether or not to return children of children.")]
      [SocketState(false, false), DefaultValue(false)]
      bool recursive,

      [FriendlyName("First Child", "The first child in the list of Children.")]
      out GameObject FirstChild,

      [FriendlyName("Children", "Assigns found child GameObjects to the attached variable.")]
      out GameObject[] Children,

      [FriendlyName("Children Count", "Sets the total number of child GameObjects found to the attached variable.")]
      [SocketState(false, false)]
      out int ChildrenCount
      )
	{
		m_Out = false;
		m_True = false;
		
		List<GameObject> list = new List<GameObject> ();
		
		if (null != Target)
		{
         list.AddRange(GetChildren(recursive, Target, SearchMethod, Name));

         ChildrenCount = list.Count;
         Children = list.ToArray ();

         // Fire out the correct out socket
         m_True = ChildrenCount > 0;

         if (m_True) FirstChild = Children[0]; else FirstChild = null;
		}
      else
		{
			uScriptDebug.Log ("(Node - Get Children By Name): The specified Target GameObject could not be found (was null). Did you specify a valid GameObject?", uScriptDebug.Type.Warning);
			Children = null;
         FirstChild = null;
			ChildrenCount = 0;
		}

		m_Out = true;
	}
 
   private GameObject[] GetChildren(bool recursive, GameObject Target, SearchType st, string Name)
   {
      List<GameObject> list = new List<GameObject>();
      
      foreach (Transform child in Target.transform)
      {
         if (recursive)
         {
            list.AddRange(GetChildren(recursive, child.gameObject, st, Name));
         }
         
         if (st == SearchType.Includes)
         {
            if (child.name.Contains (Name))
            {
               GameObject childGO = child.gameObject;
               list.Add (childGO);
            }
         }
         else if (st == SearchType.Excludes)
         {
            if (!child.name.Contains (Name))
            {
               GameObject childGO = child.gameObject;
               list.Add (childGO);
            }
               
         }
         else
         {
            if (child.name == Name)
            {
               GameObject childGO = child.gameObject;
               list.Add (childGO);
            }
         }
      }
      
      return list.ToArray();
   }
}
