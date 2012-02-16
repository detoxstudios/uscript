using UnityEngine;
using System.Collections;

using System;
using System.IO;
using System.Net;
using System.Text;

public class UpdateNotification
{
   private static string _latestVersion = "Unknown";
   public static string LatestVersion { get { return _latestVersion; } }

   private static string _webResults = string.Empty;
   public static string WebResponse { get { return _webResults; } }

   public static void CheckForUpdate()
   {
      // Used to build entire input
      StringBuilder sb = new StringBuilder();

      // Used on each read operation
      byte[] buf = new byte[8192];

      // Urepare the web page we will be asking for
      HttpWebRequest request = (HttpWebRequest)
      WebRequest.Create("http://detoxstudios.com/download/versionCheck.php?unity="+WWW.EscapeURL(Application.unityVersion)+"&uScript="+WWW.EscapeURL(uScript.FullVersionName));

      // Execute the request
      HttpWebResponse response = (HttpWebResponse)
      request.GetResponse();

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

      _webResults = sb.ToString();
   }
}