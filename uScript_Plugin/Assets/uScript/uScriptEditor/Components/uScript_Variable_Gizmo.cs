using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Variable Reference Gizmo")]
public class uScript_Variable_Gizmo : MonoBehaviour {

		
	// uScript GUI Options
	void OnDrawGizmos()
	{
		if ( this.name != uScriptConfig.MasterObjectName )
		{
			// @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
	        Gizmos.DrawIcon(transform.position, "uscript_gizmo_variables.png");
		}

    }
	
	
}
