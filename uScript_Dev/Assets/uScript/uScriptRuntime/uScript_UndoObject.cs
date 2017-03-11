// uScript utility class
// (C) 2011 Detox Studios LLC
// Desc: Used for managing the undo system.

using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class uScript_UndoObject : ScriptableObject
{
#if UNITY_EDITOR
   public int UndoNumber = 0;
#endif
}
