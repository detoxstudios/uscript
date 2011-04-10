// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Template node script (not for actual use in uScript Editor).
//       This example takes in a GameObject (someObject) and assigns its name to a
//       string variable (outGameObjectName).

using UnityEngine;
using System.Collections;

public class uScriptAct_Template : uScriptLogic
{
	private bool outputOne = false;
	private bool outputTwo = false;
    	
   // Node outputs are defined here
   public bool OutputOne { get { return outputOne; } }
   public bool OutputTwo { get { return outputTwo; } }

   // Do node logic here. This has one variable input and one variable output.
   public void Input(GameObject someObject, out string outGameObjectName)
   {
   	  // Reset outputs to false before running logic
   	  outputOne = false;
   	  outputTwo = false;

      // Simple logic to decide which output to send the signal to.      
      if( someObject != null )
      {
      	// Stuff the GameObject's name into the output string variable.
      	outGameObjectName = someObject.name;
      	outputOne = true;
      }
      else
      {
      	outGameObjectName = "";
      	outputTwo = true;
      }     
   }
} 