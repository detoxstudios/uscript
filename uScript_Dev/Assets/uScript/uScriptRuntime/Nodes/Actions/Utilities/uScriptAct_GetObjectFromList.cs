// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Utilities")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Gets an object from a list of objects.")]
[NodeDescription("Gets the object at the specified index from a list of objcts.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Object_From_List")]

[FriendlyName("Get Object From List")]
public class uScriptAct_GetObjectFromList : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("List")] object [] list, [FriendlyName("Index")] int index, [FriendlyName("Object")] out object item)
   {
      item = list[ index ];
   }
}