// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Creates a GameObject with a primitive mesh renderer and appropriate collider.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Create Primitive", "Creates a GameObject with a primitive mesh renderer and appropriate collider.")]
public class uScriptAct_CreatePrimitive : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Name", "The name of the new GameObject."), DefaultValue("Primitive")]
      string Name,

      [FriendlyName("Primitive", "The type of primitive mesh for the GameObject."), DefaultValue(PrimitiveType.Cube)]
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