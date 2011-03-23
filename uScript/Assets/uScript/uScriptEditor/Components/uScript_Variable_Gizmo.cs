using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Variable Reference Gizmo")]
public class uScript_Reference_Variables : MonoBehaviour {

		
	// uScript GUI Options
	void OnDrawGizmos()
	{
		// @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
        Gizmos.DrawIcon(transform.position, "uscript_gizmo_variables.png");

    }
	
	
}
