// uScript Action Node
// (C) 2010 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Bool")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a boolean to the defined value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Bool")]

[FriendlyName("Set Bool", "Sets a boolean to the defined value.")]
public class uScriptAct_SetBool : uScriptLogic
{
	// ================================================================================
	//    Output Sockets
	// ================================================================================
	//
	public bool Out { get { return true; } }
	
	private bool _setTrue = false;

	[FriendlyName("Set True", "Fired only if the variable was set to true.")]
	public bool SetTrue { get { return _setTrue; } }
	
	private bool _setFalse = false;

	[FriendlyName("Set False", "Fired only if the variable was set to false.")]
	public bool SetFalse { get { return _setFalse; } }


	// ================================================================================
	//    Input Sockets and Node Parameters
	// ================================================================================
	//
	// Parameter Attributes are applied below in False()
	public void True (out bool Target)
	{
		_setFalse = false;
		_setTrue = false;
		
		Target = true;
		_setTrue = true;
		
	}

	public void False (
      [FriendlyName("Target", "The value that has been set for this variable.")]
      out bool Target
      )
	{
		_setFalse = false;
		_setTrue = false;
		
		Target = false;
		_setFalse = true;
	}


	// ================================================================================
	//    Miscellaneous Node Functionality
	// ================================================================================
	//
}
