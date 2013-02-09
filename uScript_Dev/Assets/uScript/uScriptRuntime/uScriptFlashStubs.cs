#if UNITY_FLASH
public class WWWForm
{
   public void AddField(System.String s1, System.String s2)
   {
      UnityEngine.Debug.Log("uScript Message: This WWWForm class is a stubbed version for flash until Unity's flash support has matured!\n");
   }
};

public class WWW
{
   public bool isDone = false;
   public System.String text = "";
   public System.String error = "";
   public UnityEngine.Texture2D texture = null;
   
   public WWW(System.String url) { UnityEngine.Debug.Log("uScript Message: This WWW class is a stubbed version for flash until Unity's flash support has matured!\n"); }
   public WWW(System.String url, WWWForm form) { UnityEngine.Debug.Log("uScript Message: This WWW class is a stubbed version for flash until Unity's flash support has matured!\n"); }

   public static System.String EscapeURL(System.String s) { return s; }
   public static System.String UnEscapeURL(System.String s) { return s; }
};

public enum NetworkDisconnection
{
   Disconnected,
   LostConnection
};

namespace UnityEngine
{
   
   public enum NetworkConnectionError
   {
      NoError
   };

   public class NetworkMessageInfo
   {
   };
   
   public enum MasterServerEvent
   {
      RegistrationFailedGameName
   };
   
   public class BitStream
   {
   };
   
   public struct NetworkPlayer
   {
      public System.String ipAddress;
      public System.String externalIP;
      public System.Int32 port;
      public System.Int32 externalPort;
      public System.String guid;
   };
}

public enum NetworkPeerType
{
   Disconnected,
   Connecting,
   Server,
   Client
};

public class Network
{
   static public UnityEngine.NetworkPlayer player;
   static public NetworkPeerType peerType;
};

#endif
