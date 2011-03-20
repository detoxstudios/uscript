// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Global (assign to uScripts master GameObject)")]
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

}
