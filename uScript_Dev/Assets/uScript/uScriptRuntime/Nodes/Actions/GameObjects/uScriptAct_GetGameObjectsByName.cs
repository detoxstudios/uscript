// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Returns the GameObjects in the scene with the specified name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get GameObjects By Name",
              "Returns the GameObjects in the scene with the specified name." +
              "\n\nThe \"Found\" output socket will be triggered if a GameObject matching the name is found, otherwise the \"Not Found\" output socket will be triggered." +
              "\n\nWARNING: For performance reasons, this should not be executed every frame. Also, if you know there will only be one result, you should use Get GameObject By Name.")]
public class uScriptAct_GetGameObjectsByName : uScriptLogic
{
   private bool m_Out = false;
   public bool Out { get { return m_Out; } }
   private bool m_True = false;

   [FriendlyName("Found")]
   public bool GameObjectsFound { get { return m_True; } }

   [FriendlyName("Not Found")]
   public bool GameObjectsNotFound { get { return !m_True; } }

   public void In(
      [FriendlyName("Name", "The name of the GameObject(s) you are looking for.")]
      string Name,

      [FriendlyName("GameObjects", "Assigns found GameObjects to the attached variable.")]
      out GameObject[] gameObjects
      )
   {
      m_Out = false;

      List<GameObject> list = new List<GameObject> ();
      GameObject[] gos = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
      // loop through all game objects looking for Name objects
      foreach (GameObject go in gos) 
      {
         if (go && go.name == Name) 
         {
            list.Add(go);
         }
      }   
      gameObjects = list.ToArray();

      // Fire out the correct out socket
      m_True = gameObjects != null && gameObjects.Length > 0;

      m_Out = true;
   }
}
