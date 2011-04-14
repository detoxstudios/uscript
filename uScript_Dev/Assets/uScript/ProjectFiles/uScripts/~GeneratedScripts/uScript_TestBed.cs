using UnityEngine;
using System.Collections;

public class uScript_TestBed : uScriptCode
{
   #pragma warning disable 414
   SubSeq_uScript_TestBed uScript; 
   #pragma warning restore 414
   
   void Awake( )
   {
      uScript = ScriptableObject.CreateInstance(typeof(SubSeq_uScript_TestBed)) as SubSeq_uScript_TestBed;
   }
}
