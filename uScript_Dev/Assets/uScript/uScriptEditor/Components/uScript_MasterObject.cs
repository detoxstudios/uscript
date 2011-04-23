using UnityEngine;
using System.Collections;

public class uScript_MasterObject : MonoBehaviour
{
   
   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      Gizmos.DrawIcon(transform.position, "uscript_gizmo_master.png");
   }
   
}
