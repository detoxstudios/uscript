using UnityEditor;
using UnityEngine;
using System.Collections;

using System;
using System.IO;
using System.Net;
using System.Text;

public class UpdateNotification
{
   public enum Result
   {
      CheckNeeded,
      ClientBuildCurrent,
      ClientBuildNewer,
      ClientBuildOlder,
      UpdateServerError
   }

   private static string _latestVersion = "Unknown";
   public static string LatestVersion { get { return _latestVersion; } }

   private static string _webResponse = string.Empty;
   public static string WebResponse { get { return _webResponse; } }

   private static Result CheckForUpdate()
   {
      Result result = Result.CheckNeeded;
      string resultDetails = string.Empty;

      HttpWebRequest request = null;
      HttpWebResponse response = null;

      // Prepare the web page we will be asking for
      request = WebRequest.Create("http://detoxstudios.com/download/versionCheck.php"
                                 + "?productName="+WWW.EscapeURL(uScript.ProductType)
                                 + "&productBuild="+WWW.EscapeURL(uScript.BuildNumber)
                                 + "&platformName="+WWW.EscapeURL(Application.platform.ToString())
                                 + "&platformBuild="+WWW.EscapeURL(Application.unityVersion)) as HttpWebRequest;

      // Execute the request
      try
      {
         response = request.GetResponse() as HttpWebResponse;
//         Debug.Log("Response Status Code: " + response.StatusCode.ToString() + "\n");
      }
      catch (WebException e)
      {
         // If a WebException is thrown, use the Response and Status properties
         // of the exception to determine the response from the server.
         result = Result.UpdateServerError;
         _webResponse = string.Format( e.Status.ToString() );
      }

      // We will read data via the response stream
      if ( response != null )
      {
         Stream resStream = response.GetResponseStream();

         // Used to build entire result string
         StringBuilder sb = new StringBuilder();
   
         // Used on each read operation
         byte[] buf = new byte[8192];
   
   
         string tempString = null;
         int count = 0;
   
         do
         {
            // Fill the buffer with data
            count = resStream.Read(buf, 0, buf.Length);
   
            // Make sure we read some data
            if (count != 0)
            {
               // Translate from bytes to ASCII text
               tempString = Encoding.ASCII.GetString(buf, 0, count);
   
               // Continue building the string
               sb.Append(tempString);
            }
         } while (count > 0); // Any more data to read?
   
         _latestVersion = (sb.ToString() != string.Empty ? sb.ToString() : "Unknown");
         _webResponse = sb.ToString();

         // Close the streams and release the connections.  Failure to do so may
         // cause the application to run out of connections.
         resStream.Close();
         response.Close();


         // Analyze the results
         string[] valueSegments;
         string tmpValue;

         int currentBuild;
         int serverBuild;

         // Get the current build number
         valueSegments = uScript.BuildNumber.Split('.');
         tmpValue = valueSegments[valueSegments.GetUpperBound(0)];
         if (Int32.TryParse(tmpValue, out currentBuild) == false)
         {
            if (tmpValue == null) tmpValue = string.Empty;
            resultDetails = string.Format("Attempted conversion of '{0}' failed.", tmpValue);
            result = Result.UpdateServerError;
         }
   
         // Get the server build number
         valueSegments = _latestVersion.Split('.');
         tmpValue = valueSegments[valueSegments.GetUpperBound(0)];
         if (Int32.TryParse(tmpValue, out serverBuild) == false)
         {
            if (tmpValue == null) tmpValue = string.Empty;
            resultDetails = string.Format("Attempted conversion of '{0}' failed.", tmpValue);
            result = Result.UpdateServerError;
         }

         if (result != Result.UpdateServerError)
         {
            result = (currentBuild < serverBuild
                     ? Result.ClientBuildOlder
                     : (currentBuild > serverBuild
                        ? Result.ClientBuildNewer
                        : Result.ClientBuildCurrent));
         }
      }

      // Handle error results
      if (resultDetails != string.Empty)
      {
         if (result == Result.UpdateServerError)
         {
            Debug.LogWarning( resultDetails + '\n' + "Please report this issue to support@detoxstudios.com");
         }
         else
         {
            Debug.Log( resultDetails + '\n');
         }
      }

      // Return success result
      return result;
   }




   public static Result ManualCheck()
   {
      // Perform a manual update check, even if the system is disabled
//      Debug.Log("Performing a manual update check ...\n");

      UpdateNotification.Result _updateResult;
      _updateResult = UpdateNotification.CheckForUpdate();

      // Inform them of the results
      string msg = string.Empty;
      bool isAssetStoreProduct = uScript.ProductType == "uScript_AssetStore";

      switch (_updateResult)
      {
         case Result.ClientBuildCurrent:
            msg = "The uScript Editor is up to date.\n"
                + "\n"
                + "\tCurrent version: \t" + uScript.BuildNumber + "\n";
            EditorUtility.DisplayDialog("Check for Updates", msg, "Okay");
            break;

         case Result.ClientBuildNewer:
            msg = "The uScript Editor is newer than the version publicly available.\n"
                + "\n"
                + "\tCurrent version: \t" + uScript.BuildNumber + "\n"
                + "\tLatest version: \t\t" + UpdateNotification.LatestVersion + "\n";
            EditorUtility.DisplayDialog("Check for Updates", msg, "Okay");
            break;
   
         case Result.ClientBuildOlder:
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
                 + "\tCurrent version: \t" + uScript.BuildNumber + "\n"
                 + "\tLatest version: \t\t" + UpdateNotification.LatestVersion + "\n";
   
            bool prompt = EditorUtility.DisplayDialog("uScript Update Available!", msg,
                           (isAssetStoreProduct ? "Open Asset Store" : "Open Download Page"),
                           "Okay");

            // ... which will:
            if (prompt)
            {
               // "Open Download Page"
               if (isAssetStoreProduct)
               {
                  UnityEditorInternal.AssetStore.Open("http://u3d.as/content/1808");
               }
               else
               {
                  Application.OpenURL("http://detoxstudios.com/products/uscript/download/");
               }
            }
            break;
   
         case Result.UpdateServerError:
            msg = "An update server error occurred:\n\t"
                + _webResponse + "\n\n"
                + "Please check again later.";
            EditorUtility.DisplayDialog("Check for Updates", msg, "Okay");
            break;
      }

      return _updateResult;
   }




   public static Result StartupCheck()
   {
      //
      // Introduce the user to the update system on the first launch
      //
      Preferences _preferences = uScript.Preferences;
      UpdateNotification.Result _updateResult = Result.CheckNeeded;

      if (_preferences.LastUpdateCheck <= 0)
      {
         bool enable = EditorUtility.DisplayDialog("Automaticly check for uScript updates?",
               "This update check will send basic, anonymous Unity and uScript information to our update server. No personally identifiable information is transmitted or collected.\n" +
               "\n" +
               "This service can be enable or disable at any time from within the uScript Preferences panel.\n",
               "Enable", "Disable");

         if (_preferences.CheckForUpdate != enable)
         {
            _preferences.CheckForUpdate = enable;
            _preferences.Save();
         }
      }

      //
      // If the update system is enabled, we *might* check for update availability
      //
      if (_preferences.CheckForUpdate)
      {
         // Only check once per day
         int today = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
         if (_preferences.LastUpdateCheck < today)
         {
//            Debug.Log("Performing an update check ...\n");

            _updateResult = UpdateNotification.CheckForUpdate();

            // Update the date so we won't check again until tomorrow
            _preferences.LastUpdateCheck = today;
            _preferences.Save();

            // Inform the user of a new version only if they did not previously
            // choose to skip the update
            if (_updateResult == UpdateNotification.Result.ClientBuildOlder
//               || _updateResult == UpdateNotification.Result.ClientBuildCurrent
               && _preferences.IgnoreUpdateBuild != UpdateNotification.LatestVersion)
            {
//               Debug.Log("\tNew version detected!\n");

               string msg = string.Empty;
               bool isAssetStoreProduct = uScript.ProductType == "uScript_AssetStore";

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
                    + "\tCurrent version: \t" + uScript.BuildNumber + "\n"
                    + "\tLatest version: \t\t" + UpdateNotification.LatestVersion
                    + "\n";


               // display a dialog with the following options
               //    Skip this Update
               //    Remind Again in 7 Days
               //    Open Download Page

               int prompt = EditorUtility.DisplayDialogComplex("uScript Update Available!", msg,
                              (isAssetStoreProduct ? "Open Asset Store" : "Open Download Page"),
                              "Skip this Update", "Remind in 7 Days");

               // ... which will:
               if (prompt == 0)
               {
                  // "Open Download Page"
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
                  // "Skip this update"
                  _preferences.IgnoreUpdateBuild = UpdateNotification.LatestVersion;
                  _preferences.Save();
               }
               else
               {
                  // "Remind Again in 7 Days"
                  _preferences.LastUpdateCheck = int.Parse(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));
                  _preferences.Save();
               }
            }
         }
      }
      return _updateResult;
   }

}
