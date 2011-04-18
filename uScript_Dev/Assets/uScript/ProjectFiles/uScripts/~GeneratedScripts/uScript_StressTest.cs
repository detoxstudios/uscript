using UnityEngine;
using System.Collections;

public class uScript_StressTest : uScriptCode
{
   #pragma warning disable 414
   SubSeq_uScript_StressTest uScript; 
   #pragma warning restore 414
   
   void Awake( )
   {
      uScript = ScriptableObject.CreateInstance(typeof(SubSeq_uScript_StressTest)) as SubSeq_uScript_StressTest;
   }
   void Update( )
   {
      uScript.Update( );
   }
   void LateUpdate( )
   {
      uScript.LateUpdate( );
   }
   void FixedUpdate( )
   {
      uScript.FixedUpdate( );
   }
   void OnGUI( )
   {
      uScript.OnGUI( );
   }
}
