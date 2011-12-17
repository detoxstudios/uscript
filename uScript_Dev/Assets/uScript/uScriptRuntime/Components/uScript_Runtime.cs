// uScript utility file
// (C) 2011 Detox Studios LLC
// Desc: Contains classes referenced by uScript generated code which needs to be included in a dll to be linked with users' games.

using System;
using System.Collections;
using UnityEngine;

// The list of asset types supported by the AssetBrowserWindow class
public enum AssetType
{
   Invalid = -1,
   AnimationClip,
   AudioClip,
   Cubemap,
   Flare,
   Font,
   GUISkin,
   Material,
   Mesh,
   MovieTexture,
   PhysicMaterial,
   Prefab,
   RenderTexture,
   Shader,
   TextAsset,
   Texture2D

//    Procedural Material Assets
}

public interface uScriptIUnityVersion
{
	float Version { get; }
}

public class uScriptRuntimeConfig
{
	public static string MasterObjectName = "_uScript";
}

[AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class DefaultValue : Attribute
{
   public object Default;

   public DefaultValue(object o) { Default = o; }

   public DefaultValue(Type t, float[] f)
   {
      // Custom handlers for specific Unity data types
      if (t == typeof(Rect) && f.Length == 4)         Default = new Rect(f[0], f[1], f[2], f[3]);

      else if (t == typeof(Color) && f.Length == 3)   Default = new Color(f[0], f[1], f[2]);
      else if (t == typeof(Color) && f.Length == 4)   Default = new Color(f[0], f[1], f[2], f[3]);

      else if (t == typeof(Vector2) && f.Length == 2) Default = new Vector2(f[0], f[1]);

      else if (t == typeof(Vector3) && f.Length == 2) Default = new Vector3(f[0], f[1]);
      else if (t == typeof(Vector3) && f.Length == 3) Default = new Vector3(f[0], f[1], f[2]);

      else if (t == typeof(Vector4) && f.Length == 2) Default = new Vector4(f[0], f[1]);
      else if (t == typeof(Vector4) && f.Length == 3) Default = new Vector4(f[0], f[1], f[2]);
      else if (t == typeof(Vector4) && f.Length == 4) Default = new Vector4(f[0], f[1], f[2], f[3]);

      else
         Debug.LogError("Unhandled DefaultValue type and float[] length pair:\n\t" + t.ToString() + " cannot have " + f.Length.ToString() + " parameters or the type isn't yet supported.\n");
   }
}

[AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter | AttributeTargets.Property)]
public class SocketState : Attribute
{
   public bool Visible = false;
   public bool Locked  = false;

   public SocketState(bool visible, bool locked) 
   {
      Visible = visible;
      Locked  = locked;
   }
}

[AttributeUsage(AttributeTargets.Parameter)]
public class AssetPathField : Attribute
{
   public AssetType AssetType = AssetType.Invalid;

   public AssetPathField(AssetType assetType) 
   {
      AssetType = assetType;
   }
}

[AttributeUsage(AttributeTargets.Parameter)]
public class RequiresLink : Attribute
{
   public RequiresLink() 
   {
   }
}

[AttributeUsage(AttributeTargets.All)]
public class FriendlyNameAttribute : Attribute
{
   public FriendlyNameAttribute(string name) { Name = name; Desc = string.Empty; }
   public FriendlyNameAttribute(string name, string desc) { Name = name; Desc = desc; }
   public string Name;
   public string Desc;
}

[AttributeUsage(AttributeTargets.Method)]
public class Driven : Attribute
{
   public Driven() {}
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeDeprecated : Attribute
{
   public Type UpgradeType = null;

   public NodeDeprecated(Type upgradeToType)
   {
      UpgradeType = upgradeToType;
   }

   public NodeDeprecated( )
   {}
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeNeedsGuiLayout : Attribute
{
   public bool Value = false;

   public NodeNeedsGuiLayout(bool value)
   {
      Value = value;
   }

   public NodeNeedsGuiLayout( )
   {}
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeComponentType : Attribute
{
   public NodeComponentType(Type type) 
   { 
      ComponentTypes = new Type[] { type };
   }
   
   public NodeComponentType(Type type1, Type type2) 
   { 
      ComponentTypes = new Type[] { type1, type2 };
   }
   
   public Type [] ComponentTypes;

   public bool ContainsType(Type type)
   {
      foreach ( Type t in ComponentTypes )
      {
         if ( t.IsAssignableFrom(type) ) return true;
      }

      return false;
   }
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeAutoAssignMasterInstance : Attribute
{
   public NodeAutoAssignMasterInstance(bool assign) { Value = assign; }
   public bool Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodePath : Attribute
{
   public NodePath(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodePropertiesPath : Attribute
{
   public NodePropertiesPath(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeCopyright : Attribute
{
   public NodeCopyright(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeToolTip : Attribute
{
   public NodeToolTip(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeDescription : Attribute
{
   public NodeDescription(string value) { Value = value; }
   public string Value;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeAuthor : Attribute
{
   public NodeAuthor(string value, string url) { Value = value; URL = url; }
   public string Value;
   public string URL;
}

[AttributeUsage(AttributeTargets.Class)]
public class NodeHelp : Attribute
{
   public NodeHelp(string value) { Value = value; }
   public string Value;
}

public class uScriptCode : MonoBehaviour
{
}

public class uScriptEvent : MonoBehaviour
{
}

public class uScriptLogic : System.Object
{
   public virtual void SetParent( GameObject parent ) {}
   
   //editor
   public virtual Hashtable EditorDragDrop( object o ) { return null; }
}

public class uScriptDebug : MonoBehaviour
{

   public enum Type
   {
      Message,
      Warning,
      Error,
      Debug
   }

   public static void Log(string msgString)
   {
      Log(msgString, Type.Message);
   }

   /// <summary>
   /// Displays a uScript message in Unity's console window.
   /// </summary>
   /// <param name="msgString">Message string to output to the console.</param>
   /// <param name="msgType">Message type to output (0 = message, 1 = warning, 2 = error).</param>
   public static void Log(string msgString, Type msgType)
   {
      string appName = "uScript: ";
      string msgOutput = appName + msgString + "\n";

      switch (msgType)
      {
         case Type.Message:
            {
               Debug.Log(msgOutput);
               break;
            }
         case Type.Warning:
            {
               Debug.LogWarning(msgOutput);
               break;
            }
         case Type.Error:
            {
               Debug.LogError(msgOutput);
               break;
            }
         case Type.Debug:
            {
#if ( ENABLE_DEBUG_LOG )
               Debug.Log(msgOutput);
#endif
               break;
            }
         default:
            {
               Debug.Log(msgOutput);
               break;
            }
      }
   }
}

public class uScriptCustomEvent
{
   public enum SendGroup
   {
      Parents,
      Children,
      All
   }
   
   public class CustomEventData
   {
      public CustomEventData() {}
      public CustomEventData(string eventName, object eventData, GameObject sender) { EventName = eventName; EventData = eventData; Sender = sender; }
      
      public string EventName = "";
      public object EventData = null;
      public GameObject Sender = null;
   }
   
   public static void BroadcastCustomEvent(string eventName, object eventData, GameObject eventSender)
   {
      GameObject[] gos = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
      CustomEventData cEventData = new CustomEventData(eventName, eventData, eventSender);
      foreach (GameObject go in gos) 
      {
         if (go && go.transform.parent == null) 
         {
            go.gameObject.BroadcastMessage("CustomEvent", cEventData, SendMessageOptions.DontRequireReceiver);
         }
      }   
   }

   public static void SendCustomEventUp(string eventName, object eventData, GameObject eventSender)
   {
      CustomEventData cEventData = new CustomEventData(eventName, eventData, eventSender);
      eventSender.SendMessageUpwards("CustomEvent", cEventData, SendMessageOptions.DontRequireReceiver);
   }

   public static void SendCustomEventDown(string eventName, object eventData, GameObject eventSender)
   {
      CustomEventData cEventData = new CustomEventData(eventName, eventData, eventSender);
      eventSender.BroadcastMessage("CustomEvent", cEventData, SendMessageOptions.DontRequireReceiver);
   }
}
