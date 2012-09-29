// uScript utility class
// (C) 2011 Detox Studios LLC
// Desc: Used for managing the undo system.

using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class uScript_UndoComponent : MonoBehaviour
{
#if UNITY_EDITOR
   [HideInInspector]
   public int UndoNumber = 0;
#endif
}
