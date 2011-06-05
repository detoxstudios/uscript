// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns all the children GameObjects of a parent GameObject.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns all the children GameObjects of a parent GameObject.")]
[NodeDescription("Returns all the children GameObjects of a parent GameObject.\nThe \"Children Found\" output socket will be triggered if at least one child GameObject is found, otherwise the \"Children Not Found\" output socket will be triggered.\n\nVariable Sockets:\nTarget (In): The parent GameObject you wish to search for children GameObjects on.\nChildren (Out): Assigns found children GameObjects to the attached variable\nChildren Count (Out): Sets the total number of childrenGameObjects found to the attached variable\n\nOutput Sockets:\nOut: The standard output socket (always fired).\nChildren Found: Fired once if at least on child GameObject is found.\nChildren Not Found: Fired once if no child GameObject is found.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get All Children")]
public class uScriptAct_GetAllChildren : uScriptLogic
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

   public void In (
                   [FriendlyName("Target")] GameObject Target,
                   [FriendlyName("Children")] out GameObject[] Children,
                   [FriendlyName("Children Count"), SocketState(false, false)] out int ChildrenCount)
   {
      
      m_Out = false;
      m_True = false;
      m_False = false;

      List<GameObject> list = new List<GameObject> ();
      
      if (null != Target) {

         foreach (Transform child in Target.transform)
         {
            GameObject childGO = child.gameObject;
            list.Add (childGO);
         }

         Children = list.ToArray ();
         ChildrenCount = list.Count;

         // Fire out the correct out socket
         if (list.Count > 0)
         {
            m_True = true;
         }
         else
         {
            m_False = true;
         }

      }
      else
      {
         uScriptDebug.Log ("(Node - Get All Children): The specified Target GameObject could not be found (was null). Did you specify a valid GameObject?", uScriptDebug.Type.Warning);
         Children = null;
         ChildrenCount = 0;
      }
      
      m_Out = true;
      
   }
}
