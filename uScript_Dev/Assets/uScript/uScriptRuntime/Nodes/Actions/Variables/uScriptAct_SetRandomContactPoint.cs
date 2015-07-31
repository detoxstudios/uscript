// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/ContactPoint")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a ContactPoint variable from a set of choices.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random ContactPoint", "Randomly sets the value of a ContactPoint variable from a set of choices.")]
public class uScriptAct_SetRandomContactPoint : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("ContactPoint", "The ContactPoint to randomly choose from. Connect a ContactPoint List or individual ContactPoint variables to this socket."),
      AutoLinkType(typeof(ContactPoint))]
      ContactPoint[] ObjectSet,

      [FriendlyName("Target ContactPoint", "The ContactPoint value that gets set.")]
      out ContactPoint Target
      )
   {
      if (ObjectSet == null)
      {
         Target = new ContactPoint();
         return;
      }

      int index = Random.Range(0, ObjectSet.Length);
      Target = ObjectSet[index];
   }
}