// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares the unique InstanceID of the attached GameObject variables and outputs accordingly.
//       Optionally you can compare by a GameObject's tag.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Compares the unique InstanceID of the attached GameObject variables and outputs accordingly.")]
[NodeDescription("Compares the unique InstanceID of the attached GameObject variables and outputs accordingly. Optionally you can compare by a GameObject's tag.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Compare GameObjects")]
public class uScriptCon_CompareGameObjects : uScriptLogic
{
   private bool compareSame = false;
   private bool compareDifferent = false;

   public bool Same { get { return compareSame; } }
   public bool Different { get { return compareDifferent; } }

   public void In(GameObject A, GameObject B, [FriendlyName("Compare By Tag"), SocketState(false, false)] bool CompareByTag)
   {

      compareSame = false;
      compareDifferent = false;

      if (!CompareByTag)
      {
         int GameObjectA = A.GetInstanceID();
         int GameObjectB = B.GetInstanceID();

         if (GameObjectA == GameObjectB)
         {
            compareSame = true;
         }
         else
         {
            compareDifferent = true;
         }

      }
      else
      {

         string GameObjectA = A.tag;
         string GameObjectB = B.tag;

         if (GameObjectA == GameObjectB)
         {
            compareSame = true;
         }
         else
         {
            compareDifferent = true;
         }

      }

   }
}