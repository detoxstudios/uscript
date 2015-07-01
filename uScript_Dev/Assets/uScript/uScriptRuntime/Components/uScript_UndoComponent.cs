// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios, LLC" file="uScript_UndoComponent.cs">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UnityEditor;

using UnityEngine;

[ExecuteInEditMode]
public class uScript_UndoComponent : MonoBehaviour
{
   internal void Update()
   {
      Debug.Log(
         string.Format(
            "The deprecated uScript Undo component was removed from the \"{0}\" GameObject. Please re-save your scene.\n",
            this.gameObject.name));
      DestroyImmediate(this);
      EditorApplication.MarkSceneDirty();
   }
}
