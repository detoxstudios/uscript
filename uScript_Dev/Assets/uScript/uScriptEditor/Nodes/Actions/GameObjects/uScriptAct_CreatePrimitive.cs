   // uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Creates a GameObject with a primitive mesh renderer and appropriate collider.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Creates a GameObject with a primitive mesh renderer and appropriate collider.")]
[NodeDescription("Creates a GameObject with a primitive mesh renderer and appropriate collider.\n \nName: The name of the new GameObject.\nPrimitive: The type of primitive mesh for the GameObject.\nLocation: The location to place the new GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Create Primitive GameObject")]
public class uScriptAct_CreatePrimitive : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(string Name, [SocketState(false, false)] PrimitiveType Primitive, Vector3 Location, [FriendlyName("GameObject")] out GameObject NewGameObject)
   {

      NewGameObject = GameObject.CreatePrimitive(Primitive);

      if ("" != Name)
      {
         NewGameObject.name = Name;
      }

      NewGameObject.transform.position = Location;

   }
}