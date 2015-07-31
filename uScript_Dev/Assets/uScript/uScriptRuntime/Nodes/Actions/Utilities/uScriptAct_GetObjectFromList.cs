// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Utilities")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Gets an object from a list of objects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Object From List", "Gets the object at the specified index from a list of objcts.")]
public class uScriptAct_GetObjectFromList : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("List", "The object list.")]
      object [] list,
      
      [FriendlyName("Index", "The target object index.")]
      int index,

      [FriendlyName("Object", "The object.")]
      out object item
      )
   {
      // TODO: There is no range checking here.
      item = list[ index ];
   }
}