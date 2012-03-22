// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns all the children GameObjects of a parent GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_All_Children")]

[FriendlyName("Get All Children",
              "Returns all the child GameObjects of a parent GameObject.\n\n" +
              "\"Children Found\" will fire if one (or more) child GameObject is found, " +
              "otherwise \"Children Not Found\" will fire.")]
public class uScriptAct_GetAllChildren : uScriptLogic
{
   private bool m_Out = false;
   public bool Out { get { return m_Out; } }

   private bool m_True = false;
   [FriendlyName("Children Found")]
   public bool ChildrenFound { get { return m_True; } }

   [FriendlyName("Children Not Found")]
   public bool ChildrenNotFound { get { return !m_True; } }

   public void In (
      [FriendlyName("Target", "The parent GameObject you wish to search for children GameObjects on.")]
      GameObject Target,

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
         list.AddRange(GetChildren(recursive, Target));

         ChildrenCount = list.Count;
         Children = list.ToArray ();

         // Fire out the correct out socket
         m_True = ChildrenCount > 0;

         if (m_True) FirstChild = Children[0]; else FirstChild = null;
      }
      else
      {
         uScriptDebug.Log ("(Node - Get All Children): The specified Target GameObject could not be found (was null). Did you specify a valid GameObject?", uScriptDebug.Type.Warning);
         FirstChild = null;
         Children = null;
         ChildrenCount = 0;
      }
      
      m_Out = true;
   }

   private GameObject[] GetChildren(bool recursive, GameObject Target)
   {
      List<GameObject> list = new List<GameObject>();

      foreach (Transform child in Target.transform)
      {
         if (recursive)
         {
            list.AddRange(GetChildren(recursive, child.gameObject));
         }
         
         list.Add (child.gameObject);
      }
      
      return list.ToArray();
   }
}
