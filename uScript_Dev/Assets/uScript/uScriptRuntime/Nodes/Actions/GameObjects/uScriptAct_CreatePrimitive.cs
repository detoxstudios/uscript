// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Creates a GameObject with a primitive mesh renderer and appropriate collider.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Create_Primitive_GameObject")]

[FriendlyName("Create Primitive GameObject", "Creates a GameObject with a primitive mesh renderer and appropriate collider.")]
public class uScriptAct_CreatePrimitive : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Name", "The name of the new GameObject.")]
      string Name,

      [FriendlyName("Primitive", "The type of primitive mesh for the GameObject.")]
      [SocketState(false, false)]
      PrimitiveType Primitive,

      [FriendlyName("Location", "The location to place the new GameObject.")]
      Vector3 Location,

      [FriendlyName("GameObject", "The newly created GameObject")]
      out GameObject NewGameObject
      )
   {

      NewGameObject = GameObject.CreatePrimitive(Primitive);

      if ("" != Name)
      {
         NewGameObject.name = Name;
      }

      NewGameObject.transform.position = Location;

   }
}