// uScript Condition Node
// (C) 2010 Detox Studios LLC
// Desc: Fires the appropriate output link depending on the comparison of the attached bool variable.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires the appropriate output link depending on the comparison of the attached bool variable.")]
[NodeDescription("Fires the appropriate output link depending on the comparison of the attached bool variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Compare Bool")]
public class uScriptCon_CompareBool : uScriptLogic
{
   private bool compareTrue = false;
   private bool compareFalse = false;

   public bool True { get { return compareTrue; } }
   public bool False { get { return compareFalse; } }

   public void In(bool Bool)
   {
      compareTrue = false;
      compareFalse = false;

      if (Bool)
      {
         compareTrue = true;
      }
      else
      {
         compareFalse = true;
      }
      
   }

}
