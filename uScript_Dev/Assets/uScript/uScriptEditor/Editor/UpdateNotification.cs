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

   private static string _webResults = string.Empty;
   public static string WebResponse { get { return _webResults; } }

   public static Result CheckForUpdate()
   {
      // Used to build entire result string
      StringBuilder sb = new StringBuilder();

      // Used on each read operation
      byte[] buf = new byte[8192];

      // Urepare the web page we will be asking for
      HttpWebRequest request = WebRequest.Create("http://detoxstudios.com/download/versionCheck.php"
                                    + "?p="+WWW.EscapeURL(uScript.ProductType)
                                    + "&b="+WWW.EscapeURL(uScript.BuildNumber)
                                    + "&u="+WWW.EscapeURL(Application.unityVersion)) as HttpWebRequest;

      // Execute the request
      HttpWebResponse response = request.GetResponse() as HttpWebResponse;

      // We will read data via the response stream
      Stream resStream = response.GetResponseStream();

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
      _webResults = sb.ToString();

      // Return -1:UpdateAvailable, 0:Current, +1:ClientVersionNewer

      string tmpValue;
      string[] valueSegments;
      int currentBuild;
      int serverBuild;

      valueSegments = uScript.BuildNumber.Split('.');
      tmpValue = valueSegments[valueSegments.GetUpperBound(0)];
      if (Int32.TryParse(tmpValue, out currentBuild) == false)
      {
         if (tmpValue == null) tmpValue = "";
         Debug.LogWarning(string.Format("Attempted conversion of '{0}' failed.", tmpValue));
         return Result.UpdateServerError;
      }

      valueSegments = _latestVersion.Split('.');
      tmpValue = valueSegments[valueSegments.GetUpperBound(0)];
      if (Int32.TryParse(tmpValue, out serverBuild) == false)
      {
         if (tmpValue == null) tmpValue = "";
         Debug.LogWarning(string.Format("Attempted conversion of '{0}' failed.", tmpValue));
         return Result.UpdateServerError;
      }

      return (currentBuild < serverBuild
              ? Result.ClientBuildOlder
              : (currentBuild > serverBuild
                 ? Result.ClientBuildNewer
                 : Result.ClientBuildCurrent));
   }
}
