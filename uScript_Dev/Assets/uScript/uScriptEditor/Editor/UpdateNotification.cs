// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateNotification.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the UpdateNotification type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Text;

using UnityEditor;

using UnityEngine;

public class UpdateNotification
{
   private static UpdateStatus updateStatus;

   public enum UpdateStatus
   {
      None,
      ClientBuildCurrent,
      ClientBuildNewer,
      ClientBuildOlder,
      UpdateClientError,
      UpdateServerError
   }

   public static string LatestVersion { get; private set; }

   public static string WebResponse { get; private set; }

   public static UpdateStatus ManualCheck()
   {
      // Perform a manual update check, even if the system is disabled
      const string CheckForUpdates = "Check for Updates";
      const string Okay = "Okay";

      var updateResult = CheckServerForUpdate();

      // Inform them of the results
      string msg;
      var isAssetStoreProduct = uScript.ProductType == "uScript_AssetStore";

      var yourVersion = string.Format("\tYour version: \t{0}\n", uScript.BuildNumber);
      var latestVersion = string.Format("\tLatest version: \t{0}\n", LatestVersion);

      switch (updateResult)
      {
         case UpdateStatus.ClientBuildCurrent:
            msg = string.Format("The uScript Editor you are currently using is up to date.\n\n{0}", yourVersion);
            EditorUtility.DisplayDialog(CheckForUpdates, msg, Okay);
            break;

         case UpdateStatus.ClientBuildNewer:
            msg = string.Format("The uScript Editor you are currently using is newer than the version publicly available.\n\n{0}{1}", yourVersion, latestVersion);
            EditorUtility.DisplayDialog(CheckForUpdates, msg, Okay);
            break;

         case UpdateStatus.ClientBuildOlder:
            msg = isAssetStoreProduct
                  ? "A new version of uScript has been uploaded to the Unity Asset Store, and should be available for download."
                  : "There is a new version of uScript available for download from the Detox Studios website.";
            msg = string.Format("{0}\n\n{1}{2}", msg, yourVersion, latestVersion);

            var prompt = EditorUtility.DisplayDialog(
               "uScript Update Available!",
               msg,
               isAssetStoreProduct ? "Open Asset Store" : "Open Download Page",
               Okay);

            if (prompt)
            {
               if (isAssetStoreProduct)
               {
                  UnityEditorInternal.AssetStore.Open("com.unity3d.kharma:content/1808");
               }
               else
               {
                  Application.OpenURL("http://detoxstudios.com/products/uscript/download/");
               }
            }

            break;

         case UpdateStatus.UpdateClientError:
            msg = string.Format("The client experienced an error:\n\t{0}\n\nPlease report this issue to the Detox support team.", WebResponse);
            EditorUtility.DisplayDialog(CheckForUpdates, msg, Okay);
            break;

         case UpdateStatus.UpdateServerError:
            msg = string.Format("An update server error occurred:\n\t{0}\n\nPlease check again later.", WebResponse);
            EditorUtility.DisplayDialog(CheckForUpdates, msg, Okay);
            break;
      }

      return updateResult;
   }

   public static UpdateStatus StartupCheck()
   {
      // Introduce the user to the update system on the first launch
      var preferences = uScript.Preferences;
      var updateResult = UpdateStatus.None;

      // LastUpdateCheck will be 0 when uScript it first run, or when the uScriptSettings file is removed
      if (preferences.LastUpdateCheck <= 0)
      {
         const string Message = "This update check will send basic, anonymous Unity and uScript information to our update server. No personally identifiable information is transmitted or collected.\n\nThis service can be enable or disable at any time from within the uScript Preferences panel.\n";

         var enable = EditorUtility.DisplayDialog(
            "Automatically check for uScript updates?",
            Message,
            "Enable",
            "Disable");

         preferences.LastUpdateCheck = int.Parse(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"));
         preferences.CheckForUpdate = enable;
         preferences.Save();
      }

      // If the update system is enabled, we *might* check for update availability
      if (preferences.CheckForUpdate)
      {
         // Only check once per day
         var today = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
         if (preferences.LastUpdateCheck < today)
         {
//            Debug.Log("Performing an update check ...\n");

            updateResult = CheckServerForUpdate();

            // Update the date so we won't check again until tomorrow
            preferences.LastUpdateCheck = today;
            preferences.Save();

            // Inform the user of a new version only if they did not previously
            // choose to skip the update
            if (updateResult == UpdateStatus.ClientBuildOlder
//               || _updateResult == UpdateNotification.UpdateStatus.ClientBuildCurrent
               && preferences.IgnoreUpdateBuild != LatestVersion)
            {
//               Debug.Log("\tNew version detected!\n");

               string msg;
               var isAssetStoreProduct = uScript.ProductType == "uScript_AssetStore";

               if (isAssetStoreProduct)
               {
                  msg = "A new version of uScript has been uploaded to the Unity Asset Store, "
                      + "and should be available for download.\n";
               }
               else
               {
                  msg = "There is a new version of uScript available for download from the "
                      + "Detox Studios website.\n";
               }

               msg += "\n"
                    + "\tYour version: \t" + uScript.BuildNumber + "\n"
                    + "\tLatest version: \t\t" + LatestVersion
                    + "\n";

               // display a dialog with the following options
               //    Skip this Update
               //    Remind Again in 7 Days
               //    Open Download Page

               var prompt = EditorUtility.DisplayDialogComplex(
                  "uScript Update Available!",
                  msg,
                  isAssetStoreProduct ? "Open Asset Store" : "Open Download Page",
                  "Skip this Update",
                  "Remind in 7 Days");

               // ... which will:
               if (prompt == 0)
               {
                  if (isAssetStoreProduct)
                  {
                     UnityEditorInternal.AssetStore.Open("http://u3d.as/content/1808");
                  }
                  else
                  {
                     Application.OpenURL("http://detoxstudios.com/products/uscript/download/");
                  }
               }
               else if (prompt == 1)
               {
                  preferences.IgnoreUpdateBuild = LatestVersion;
                  preferences.Save();
               }
               else
               {
                  preferences.LastUpdateCheck = int.Parse(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));
                  preferences.Save();
               }
            }
         }
      }

      return updateResult;
   }

   /// <summary>
   /// Checks with the server to see if an update is available, using the client's current build information for comparison.
   /// </summary>
   /// <returns>The result of the check.</returns>
   private static UpdateStatus CheckServerForUpdate()
   {
      var httpWebRequest = CreateWebRequest();
      if (httpWebRequest != null)
      {
         var httpWebResponse = SubmitWebRequest(httpWebRequest);
         if (httpWebResponse != null)
         {
            if (ProcessWebResponse(httpWebResponse) == UpdateStatus.None)
            {
               // Release the connections.  Failure to do so may cause the application to run out of connections.
               httpWebResponse.Close();

               // Analyze the results
               int currentBuild;
               int serverBuild;

               var errorMessage = string.Empty;

               // Get the current build number
               var valueSegments = uScript.BuildNumber.Split('.');
               var tmpValue = valueSegments[valueSegments.GetUpperBound(0)];
               if (int.TryParse(tmpValue, out currentBuild) == false)
               {
                  if (tmpValue == null)
                  {
                     tmpValue = string.Empty;
                  }

                  errorMessage = string.Format("Attempted conversion of '{0}' failed.", tmpValue);
                  updateStatus = UpdateStatus.UpdateServerError;
               }

               // Get the server build number
               //         valueSegments = latestVersion.Split('.');
               valueSegments = LatestVersion.Split('.');
               tmpValue = valueSegments[valueSegments.GetUpperBound(0)];
               if (int.TryParse(tmpValue, out serverBuild) == false)
               {
                  if (tmpValue == null)
                  {
                     tmpValue = string.Empty;
                  }

                  errorMessage = string.Format("Attempted conversion of '{0}' failed.", tmpValue);
                  updateStatus = UpdateStatus.UpdateServerError;
               }

               if (updateStatus != UpdateStatus.UpdateServerError)
               {
                  updateStatus = currentBuild < serverBuild
                              ? UpdateStatus.ClientBuildOlder
                              : (currentBuild > serverBuild
                                    ? UpdateStatus.ClientBuildNewer
                                    : UpdateStatus.ClientBuildCurrent);
               }

               // Handle error results
               if (errorMessage != string.Empty)
               {
                  if (updateStatus == UpdateStatus.UpdateServerError)
                  {
                     Debug.LogWarning(
                        string.Format("{0}\nPlease report this issue to support@detoxstudios.com", errorMessage));
                  }
                  else
                  {
                     Debug.Log(string.Format("{0}\n", errorMessage));
                  }
               }
            }
         }
      }

      // Return success result
      return updateStatus;
   }

   private static WebRequest CreateWebRequest()
   {
      updateStatus = UpdateStatus.None;
      WebResponse = null;

      WebRequest httpWebRequest = null;

      try
      {
         httpWebRequest =
            WebRequest.Create(
               string.Format(
                  "http://detoxstudios.com/download/versionCheck.php?productName={0}&productBuild={1}&platformName={2}&platformBuild={3}&platformPro={4}",
                  WWW.EscapeURL(uScript.ProductType),
                  WWW.EscapeURL(uScript.BuildNumber),
                  WWW.EscapeURL(Application.platform.ToString()),
                  WWW.EscapeURL(Application.unityVersion),
                  WWW.EscapeURL(uScript.IsUnityPro.ToString()))) as HttpWebRequest;
      }
      catch (Exception e)
      {
         WebResponse = string.Format(e.Message);
      }

      if (httpWebRequest == null)
      {
         if (string.IsNullOrEmpty(WebResponse))
         {
            WebResponse = string.Format("Failed to create web request.");
         }

         updateStatus = UpdateStatus.UpdateClientError;
      }

      return httpWebRequest;
   }

   private static UpdateStatus ProcessWebResponse(WebResponse httpWebResponse)
   {
      System.IO.Stream responseStream = null;

      try
      {
         responseStream = httpWebResponse.GetResponseStream();
      }
      catch (Exception e)
      {
         WebResponse = string.Format(e.Message);
      }

      if (responseStream == null)
      {
         if (string.IsNullOrEmpty(WebResponse))
         {
            WebResponse = string.Format("Failed to get a response stream.");
         }

         updateStatus = UpdateStatus.UpdateServerError;
      }
      else
      {
         // Used to build entire result string
         var sb = new StringBuilder();

         // Used on each read operation
         var buf = new byte[8192];

         int count;

         do
         {
            // Fill the buffer with data
            count = responseStream.Read(buf, 0, buf.Length);

            // Make sure we read some data
            if (count == 0)
            {
               continue;
            }

            // Translate from bytes to ASCII text
            var tempString = Encoding.ASCII.GetString(buf, 0, count);

            // Continue building the string
            sb.Append(tempString);
         }
         while (count > 0); // Any more data to read?

         LatestVersion = sb.ToString() != string.Empty ? sb.ToString() : "Unknown";
         WebResponse = sb.ToString();

         // Close the stream.  Failure to do so may cause the application to run out of connections.
         responseStream.Close();
      }

      return updateStatus;
   }

   private static HttpWebResponse SubmitWebRequest(WebRequest httpWebRequest)
   {
      HttpWebResponse httpWebResponse = null;

      try
      {
         httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
      }
      catch (WebException e)
      {
         // If a WebException is thrown, use the Response and Status properties of the exception to determine the response from the server.
         WebResponse = string.Format(e.Status.ToString());
      }

      if (httpWebResponse == null)
      {
         if (string.IsNullOrEmpty(WebResponse))
         {
            WebResponse = string.Format("Failed to get a web response.");
         }

         updateStatus = UpdateStatus.UpdateServerError;
      }

      return httpWebResponse;
   }
}
