// uScript utility class
// (C) 2011 Detox Studios LLC
// Desc: The master uScript component. This class is also used as a data transport class between the uScript window and the uScriptBackgroundProcess.

//#define FREE_PLE_BUILD

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
   public int    UndoNumber = 0;
#endif

}
