//uScript Generated Code - Build 1.0.3109
//Generated with Debug Info
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Graphs")]
[System.Serializable]
[FriendlyName("", "")]
public class CoinCollection_GameplayGlobals : uScriptLogic
{

   #pragma warning disable 414
   GameObject parentGameObject = null;
   uScript_GUI thisScriptsOnGuiListener = null; 
   bool m_RegisteredForEvents = false;
   delegate void ContinueExecution();
   ContinueExecution m_ContinueExecution;
   bool m_Breakpoint = false;
   const int MaxRelayCallCount = 1000;
   int relayCallCount = 0;
   
   //externally exposed events
   
   //external parameters
   
   //local nodes
   public UnityEngine.AudioClip CoinAudioGold = default(UnityEngine.AudioClip);
   public UnityEngine.AudioClip CoinAudioSilver = default(UnityEngine.AudioClip);
   public System.Int32 CoinPointsGold = (int) 0;
   public System.Int32 CoinPointsSilver = (int) 0;
   public UnityEngine.AudioClip JumpAudio = default(UnityEngine.AudioClip);
   public UnityEngine.GameObject Player = default(UnityEngine.GameObject);
   UnityEngine.GameObject Player_previous = null;
   
   //owner nodes
   
   //logic nodes
   
   //event nodes
   
   //property nodes
   
   //method nodes
   #pragma warning restore 414
   
   //functions to refresh properties from entities
   
   void SyncUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( Player_previous != Player || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         Player_previous = Player;
         
         //setup new listeners
      }
   }
   
   void RegisterForUnityHooks( )
   {
      SyncEventListeners( );
      //if our game object reference was changed then we need to reset event listeners
      if ( Player_previous != Player || false == m_RegisteredForEvents )
      {
         //tear down old listeners
         
         Player_previous = Player;
         
         //setup new listeners
      }
   }
   
   void SyncEventListeners( )
   {
   }
   
   void UnregisterEventListeners( )
   {
   }
   
   public override void SetParent(GameObject g)
   {
      parentGameObject = g;
      
   }
   public void Awake()
   {
      
   }
   
   public void Start()
   {
      SyncUnityHooks( );
      m_RegisteredForEvents = true;
      
   }
   
   public void OnEnable()
   {
      RegisterForUnityHooks( );
      m_RegisteredForEvents = true;
   }
   
   public void OnDisable()
   {
      UnregisterEventListeners( );
      m_RegisteredForEvents = false;
   }
   
   public void Update()
   {
      //reset each Update, and increments each method call
      //if it ever goes above MaxRelayCallCount before being reset
      //then we assume it is stuck in an infinite loop
      if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;
      if ( null != m_ContinueExecution )
      {
         ContinueExecution continueEx = m_ContinueExecution;
         m_ContinueExecution = null;
         m_Breakpoint = false;
         continueEx( );
         return;
      }
      UpdateEditorValues( );
      
      //other scripts might have added GameObjects with event scripts
      //so we need to verify all our event listeners are registered
      SyncEventListeners( );
      
   }
   
   public void OnDestroy()
   {
   }
   
   private void UpdateEditorValues( )
   {
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_GameplayGlobals.uscript:CoinPointsGold", CoinPointsGold);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "7b00964b-7dd5-4cf1-b8cd-f8ef2b1faefe", CoinPointsGold);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_GameplayGlobals.uscript:CoinPointsSilver", CoinPointsSilver);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0da9c077-abc6-4d14-9382-c7f3630aeaa9", CoinPointsSilver);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_GameplayGlobals.uscript:Player", Player);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "adae7537-bc8b-4dd0-8925-fa6c09259945", Player);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_GameplayGlobals.uscript:CoinAudioSilver", CoinAudioSilver);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "0e271efa-0b57-4405-9257-025dc7f927d9", CoinAudioSilver);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_GameplayGlobals.uscript:CoinAudioGold", CoinAudioGold);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "24e869ce-7301-4cbb-ad32-345347eff72e", CoinAudioGold);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "CoinCollection_GameplayGlobals.uscript:JumpAudio", JumpAudio);
      uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( "4f41ff24-b8d0-479c-99fc-d4d3298a8a2e", JumpAudio);
   }
   bool CheckDebugBreak(string guid, string name, ContinueExecution method)
   {
      if (true == m_Breakpoint) return true;
      
      if (true == uScript_MasterComponent.FindBreakpoint(guid))
      {
         if (uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint == guid)
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = "";
         }
         else
         {
            uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = guid;
            UpdateEditorValues( );
            UnityEngine.Debug.Log("uScript BREAK Node:" + name + " ((Time: " + Time.time + "");
            UnityEngine.Debug.Break();
            #if (!UNITY_FLASH)
            m_ContinueExecution = new ContinueExecution(method);
            #endif
            m_Breakpoint = true;
            return true;
         }
      }
      return false;
   }
}
