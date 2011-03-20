// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Outputs a string to the debug log. Optionally can add prefix and/or postfix strings.

using UnityEngine;
using System.Collections;

public class uScriptAct_Log : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(object[] Target, string Prefix, string Postfix)
   {
      if (Prefix == "" && Postfix == "")
      {
         foreach (object currentTarget in Target)
         {
            Debug.Log(currentTarget);
         }
      }
      else
      {
         foreach (object currentTarget in Target)
         {
            Debug.Log((Prefix + currentTarget.ToString() + Postfix));
         }
      }

   }
}
