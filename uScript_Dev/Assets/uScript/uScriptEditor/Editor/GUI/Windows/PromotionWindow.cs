// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PromotionWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PromotionWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !UNITY_3_5
namespace Detox.Editor.GUI.Windows
{
#endif
   using System;
   using System.Collections.Generic;

   using UnityEditor;

   using UnityEngine;

   public class PromotionWindow : EditorWindow 
   {
      private static WWW webRequest;

      private static PromotionWindow window;

      private static Detox.Editor.Promotion promotion;

      public static string WebResponseText { get; private set; }

      public static Texture WebResponseTexture { get; private set; }

      public static Dictionary<string, string> WebResponseHeaders { get; private set; }

      public static PromotionWindow Open()
      {
         window = (PromotionWindow)GetWindow(typeof(PromotionWindow), true, string.Empty, true);
         return window;
      }

      public static void CheckServerForPromotion(uScriptBuild.EditionType target, string ignoredIDs, string dateOverride = "")
      {
         WebResponseText = "Checking server for promotion ...";

         webRequest = CreateWebRequest(target, ignoredIDs, dateOverride);

         var stopwatch = System.Diagnostics.Stopwatch.StartNew();
         var timeout = new TimeSpan(0, 0, 0, 5);

         while (!webRequest.isDone && stopwatch.Elapsed < timeout)
         {
         }

         stopwatch.Stop();

         if (webRequest.isDone)
         {
            ProcessWebResponse();
         }

         webRequest.Dispose();
      }

      internal void OnGUI()
      {
         if (promotion == null || promotion.Image == null)
         {
            this.Close();
            return;
         }

         var rect = new Rect(0, 0, promotion.Image.width, promotion.Image.height);

         EditorGUIUtility.AddCursorRect(rect, MouseCursor.Link);
         if (GUI.Button(rect, promotion.Image, GUIStyle.none))
         {
            OpenLink(promotion.LinkPath);
            this.Close();
         }

         GUI.DrawTexture(rect, promotion.Image);

         //rect.y += rect.height;
         //rect.height = 20;

         //GUILayout.BeginArea(rect);
         //{
         //   GUILayout.BeginHorizontal();
         //   {
         //      if (GUILayout.Button("Close"))
         //      {
         //         Debug.Log("CLOSE PRESSED\n");
         //      }
         //   }
         //   GUILayout.EndHorizontal();
         //}
         //GUILayout.EndArea();

         window.minSize = window.maxSize = new Vector2(promotion.Image.width, promotion.Image.height);
      }

      //internal void Update()
      //{
      //}

      private static WWW CreateWebRequest(uScriptBuild.EditionType target, string id, string date = "")
      {
         var uri = string.Format("https://www.detoxstudios.com/download/promotion.php");

         var form = new WWWForm();
         form.AddField("ignoredIDs", id);
         if (date != string.Empty)
         {
            form.AddField("date", date);
         }

         var headers = form.headers;
         headers.Add("X-USCRIPT-EDITION", target.ToString());
         headers.Add("X-USCRIPT-VERSION", uScriptBuild.Number);

         return new WWW(uri, form.data, headers);
      }

      private static void ProcessWebResponse()
      {
         var headers = webRequest.responseHeaders;

         WebResponseHeaders = headers;
         WebResponseText = webRequest.text;
         WebResponseTexture = webRequest.textureNonReadable;

         if (string.IsNullOrEmpty(webRequest.error) == false)
         {
            // DO NOTHING - Better to silently fail than to report a web request error for the promotion check.
            // An error will be generated when WWW fails to connect to the internet, and we don't want to annoy
            // users with daily warning messages, if they frequently run offline.
            WebResponseText = webRequest.error;
            return;
         }

         int promotionID;

         if (headers.ContainsKey("X-USCRIPT-PROMOTION-ID") == false
             || int.TryParse(webRequest.responseHeaders["X-USCRIPT-PROMOTION-ID"], out promotionID) == false
             || headers.ContainsKey("X-USCRIPT-PROMOTION-LINK") == false
             || string.IsNullOrEmpty(headers["X-USCRIPT-PROMOTION-LINK"]))
         {
            // The response must be invalid, so abort.
            return;
         }

         promotion = new Detox.Editor.Promotion
                        {
                           ID = promotionID,
                           LinkPath = headers["X-USCRIPT-PROMOTION-LINK"],
                           Image = webRequest.textureNonReadable
                        };

         Open();

         window.Repaint();
      }

      private static void OpenLink(string url)
      {
         if (promotion.LinkPath.StartsWith("content/"))
         {
            // This is appears to be a Unity asset store link, so open it in the store.
            UnityEditorInternal.AssetStore.Open(url);
         }
         else
         {
            // This must be a web link, so open it in the default web browser.
            var parts = url.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
               url = string.Format("http://{0}", url);
            }

            Application.OpenURL(url);
         }
      }
   }

#if !UNITY_3_5
}
#endif
