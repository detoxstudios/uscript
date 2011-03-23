// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Global (assign to uScripts master GameObject)")]

[NodePath("Events")]
public class uScript_Global : MonoBehaviour
{
    public event uScriptEventHandler GameStart;
    public event uScriptEventHandler KeyPress;

    void Start()
    {
        uScript_EventHandler.DoEvent(this, GameStart, new object[] { });
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            uScript_EventHandler.DoEvent(this, KeyPress, new object[] { });
        }
    }
	
	// uScript GUI Options
	void OnDrawGizmos()
	{
		// @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
        Gizmos.DrawIcon(transform.position, "uscript_gizmo_master.png");

    }

}
