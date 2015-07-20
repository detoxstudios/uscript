// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryAssetStore.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the QueryAssetStore type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if UNITY_5
namespace Detox.DetoxDevTools.Editor
{
   using System;
   using System.Collections.Generic;
   using System.Diagnostics;
   using System.Reflection;

   using Detox.Editor;

   using UnityEditor;

   using UnityEngine;

   using Debug = UnityEngine.Debug;

   public class QueryAssetStore
   {
      private static WWW webRequest;
      
      [MenuItem("uScript/Internal/Test Windows/Asset Store/Asset Store Query")]
      public static void RunQuery()
      {
         var unityEditor = Assembly.GetAssembly(typeof(AssetStoreAsset));

         var assetStoreClient = unityEditor.GetType("UnityEditor.AssetStoreClient");
         if (assetStoreClient == null)
         {
            Debug.LogError("UnityEditor.AssetStoreClient was not found in the assembly.\n");
            return;
         }

         var apiUrl = assetStoreClient.GetMethod(
            "APIUrl",
            BindingFlags.NonPublic | BindingFlags.Static,
            null,
            new[] { typeof(string) },
            null);
         if (apiUrl == null)
         {
            Debug.LogError("UnityEditor.AssetStoreClient was not found in the assembly.\n");
            return;
         }

         var text = apiUrl.Invoke(null, new object[] { "/en-US/content/overview/1808" });

         var assetStoreAssetsInfo = unityEditor.GetType("UnityEditor.AssetStoreAssetsInfo");
         if (assetStoreAssetsInfo == null)
         {
            Debug.LogError("UnityEditor.AssetStoreAssetsInfo was not found in the assembly.\n");
            return;
         }

         var ctors = assetStoreAssetsInfo.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
         var ctorParams = ctors[0].GetParameters();
         var ctorParam1 = ctorParams[0].ParameterType;
         var ctorParam2 = ctorParams[1].ParameterType;

         var ctor = assetStoreAssetsInfo.GetConstructor(
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            new[] { ctorParam1, ctorParam2 },
            null);
         if (ctor == null)
         {
            Debug.LogError(
               string.Format(
                  "UnityEditor.AssetStoreAssetsInfo({0}, {1}) was not found in the assembly.\n",
                  ctorParam1,
                  ctorParam2));
            return;
         }

         //List<AssetStoreAsset> assets = new List<AssetStoreAsset>();
         //var r = ctor.Invoke(null, new object[] { null, assets });

         //var assetStoreClient_DoneCallback_type = assetStoreClient.GetMembers();
         //foreach (var e in assetStoreClient_DoneCallback_type)
         //{
         //   Debug.Log("Member: " + e + "\n");
         //}



         //var createJSONRequest = assetStoreClient.GetMethod("CreateJSONRequest", BindingFlags.NonPublic|BindingFlags.Static,null, new []{string, } )
         
         //AssetStoreAssetsInfo r = new AssetStoreAssetsInfo(callback, assets);
         //return AssetStoreClient.CreateJSONRequest(text, delegate(AssetStoreResponse ar)
         //{
         //   r.Parse(ar);
         //});

         Debug.Log("text: " + text + "\n");
      }




      [MenuItem("uScript/Internal/Test Windows/Asset Store/WWW")]
      private static void SilentlyCheckServerForUpdate()
      {
         webRequest = CreateWebRequest();

         // Coroutines do not work in the editor, but we still need to handle the request in a non-blocking manner.
         JobManager.Add(
            () => webRequest.isDone,
            () =>
               {
                  SilentlyProcessWebResponse();
                  webRequest.Dispose();
               });
      }

      private static WWW CreateWebRequest()
      {
         // TODO: Look into making this a POST form rather than a GET request
         var uri = string.Format("https://www.assetstore.unity3d.com/api/en-US/content/overview/{0}.json", 18440);

         var form = new WWWForm();
         var headers = form.headers;
         headers.Add("Accept-Language", "en-US,en;q=0.8");
         headers.Add("Host", "www.assetstore.unity3d.com");
         headers.Add("Referer", "https://www.assetstore.unity3d.com/en/");
         headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.130 Safari/537.36");
         headers.Add("X-Requested-With", "UnityAssetStore");
         headers.Add("X-Kharma-Version", "5.0.0-r84275");
         headers.Add("X-Unity-Session", "26c4202eb475d02864b40827dfff11a14657aa41");

         //foreach (var h in headers)
         //{
         //   Debug.Log("Header: " + h + "\n");
         //}

         return new WWW(uri, null, headers);
      }

      /*
$json_url = "https://www.assetstore.unity3d.com/api/en-US/content/overview/" . $id . ".json";

$opts = array(
    'http'=>array(
        'method'=>"GET",
        'header'=>"Accept-Language: en-US,en;q=0.8\r\n" .
            "Host: www.assetstore.unity3d.com\r\n" .
            "Referer: https://www.assetstore.unity3d.com/en/\r\n" .
            "User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.130 Safari/537.36\r\n" .
            "X-Requested-With: UnityAssetStore\r\n" .
            "X-Kharma-Version: 5.0.0-r84275\r\n" .
            "X-Unity-Session: 26c4202eb475d02864b40827dfff11a14657aa41\r\n" .
//			"Connection: keep-alive\r\n" .
//			"Accept: *
/*\r\n" .
//			"DNT: 1\r\n" .
//			"Accept-Encoding: gzip, deflate, sdch\r\n" .
//			"Cookie: SERVERID=varnish02; _ga=GA1.3.1923382095.1410401817; cookies=accepted; webauth_nonce=d5476fa0a9847e6fd4e9156e12e72451; __utma=219392861.1923382095.1410401817.1436243140.1436250336.76; __utmc=219392861; __utmz=219392861.1436250336.76.48.utmcsr=google|utmccn=(organic)|utmcmd=organic|utmctr=(not%20provided); __utmv=219392861.|1=cu_account_id=26586=1; webauth_logged_in=18025d755a2a6ce11a31cf5ac23df4e899984b72; kharma_explicitly_logged_out=1\r\n"
            ""
    )
      */




      private static void SilentlyProcessWebResponse()
      {
         if (string.IsNullOrEmpty(webRequest.error) == false)
         {
            // DO NOTHING - Better to silently fail than to report a web request error during the startup check.
            // An error will be generated when WWW fails to connect to the internet, and we don't want to annoy
            // users with daily warning messages, if they frequently run offline.

            var msg = string.Format("Error: \"{0}\"", webRequest.error);
            uScriptDebug.Log(msg, uScriptDebug.Type.Warning);
         }
         else
         {
            Debug.Log("webRequest.text: " + webRequest.text + "\n");
         }
         //else if (BuildInfo.TryParse(webRequest.text, out serverBuild) == false)
         //{
         //   var msg = string.Format("Failed to parse server response: '{0}'", webRequest.text);
         //   uScriptDebug.Log(msg, uScriptDebug.Type.Error);
         //}
         //else if (BuildInfo.TryParse(uScriptBuild.Number, out clientBuild) == false)
         //{
         //   var msg = string.Format("Failed to parse client build number: '{0}'", uScriptBuild.Number);
         //   uScriptDebug.Log(msg, uScriptDebug.Type.Error);
         //}
//         else
//         {
//            updateStatus = clientBuild == serverBuild
//                              ? UpdateStatus.ClientBuildCurrent
//                              : (clientBuild > serverBuild ? UpdateStatus.ClientBuildNewer : UpdateStatus.ClientBuildOlder);

//            if (updateStatus == UpdateStatus.ClientBuildCurrent || updateStatus == UpdateStatus.ClientBuildNewer)
//            {
//               return;
//            }

//            // Add build information
//            var clientVersion = clientBuild.ToString();
//            var serverVersion = LatestVersion = serverBuild.ToString();

//            if (uScript.Preferences.IgnoreUpdateBuild == serverVersion)
//            {
//               return;
//            }

//#if !UNITY_3_5
//            if (updateStatus == UpdateStatus.ClientBuildOlder)
//            {
//               serverVersion = serverVersion.Bold();
//            }
//#endif

//            clientVersion = string.Format("        Your version: \t{0}", clientVersion);
//            serverVersion = string.Format("        Latest version: \t{0}", serverVersion);

//            Open();
//            updateStatus = UpdateStatus.ClientBuildOlder;
//            window.Title = Content.TitleClientBuildOlder;
//            var msg = IsAsssetStoreProduct
//                         ? Content.BodyClientBuildOlderUnity.text
//                         : Content.BodyClientBuildOlderDetox.text;
//            window.Body = new GUIContent(string.Format("{0}\n\n{1}\n{2}", msg, clientVersion, serverVersion));
//            window.Repaint();
//         }
      }


   }
}
#endif
