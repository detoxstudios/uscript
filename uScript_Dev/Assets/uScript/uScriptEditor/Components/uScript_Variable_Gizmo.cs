using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Variable Reference Gizmo")]
public class uScript_Variable_Gizmo : MonoBehaviour {

#if UNITY_EDITOR	
	// uScript GUI Options
	void OnDrawGizmos()
	{
		if ( this.name != uScriptRuntimeConfig.MasterObjectName )
		{
			// @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
	        Gizmos.DrawIcon(transform.position, "uscript_gizmo_variables.png");
		}

    }
#endif
	
}
