// uScript Action Node
// (C) 2011 Detox Studios LLC
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Variables/Lists/GameObject")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Modify a list by specifying a specific slot number (index) in the list.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Modify List By Index (GameObject)", "Modify a list by specifying a specific slot number (index) in the list.")]
public class uScriptAct_ModifyListByIndexGameObject : uScriptLogic
{
	// ================================================================================
	//    Output Sockets
	// ================================================================================
	//
	public bool Out { get { return true; } }
    

	// ================================================================================
	//    Input Sockets and Node Parameters
	// ================================================================================

	[FriendlyName("Insert Into List", "Inserts an item into the list at the specified index.")]
	public void InsertIntoList (ref GameObject[] GameObjectList, int Index, GameObject[] Target, out int ListCount)
	{
		List<GameObject> list = new List<GameObject> (GameObjectList);
		
		if (Index < 0) {
			Index = 0;
		}
		
		if (list.Count == 0) {
			foreach (GameObject go in Target) {
				list.Add (go);
			}
			
		} else {
			if (Index + 1 >= list.Count) {	
				foreach (GameObject go in Target) {
					list.Add (go);
				}
				
			} else {
			
				foreach (GameObject go in Target) {
					list.Insert (Index, go);
				}

			}
		}
		
		GameObjectList = list.ToArray ();
		ListCount = GameObjectList.Length;
      
	}	
	
	// Parameter Attributes are applied below in EmptyList()
	[FriendlyName("Remove From List", "Removes an item from the list at the specified index.")]
	public void RemoveFromList (
	  [FriendlyName("List", "The list to modify.")]
      ref GameObject[] GameObjectList,
		
		[FriendlyName("Index", "The index number where you wish to perform the modification. If the number is larger than the elements contained in the list, the action will be performed on the largest valid index number of the list. Negative values are automatically converted to 0.")]
	  int Index,

      [FriendlyName("Insert Target", "The Target variable(s) to add or remove from the list. This socket is ignored when using the Remove From List input socket.")]
      GameObject[] Target,
	
      [FriendlyName("List Size", "The remaining number of items in the list after the modification has taken place.")]
      out int ListCount
      )
	{
		List<GameObject> list = new List<GameObject> (GameObjectList);
		
		if (Index < 0) {
			Index = 0;
		}
		
		if (list.Count > 0) {
		
			if (Index >= list.Count) {
				list.RemoveAt (list.Count - 1);
			} else {
				list.RemoveAt (Index);
			}
		}
      
		GameObjectList = list.ToArray ();
		ListCount = GameObjectList.Length;
	}


	// ================================================================================
	//    Miscellaneous Node Functionality
	// ================================================================================
	//
}
