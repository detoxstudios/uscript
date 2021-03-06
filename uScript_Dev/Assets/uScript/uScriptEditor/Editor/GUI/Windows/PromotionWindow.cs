// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PromotionWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PromotionWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI.Windows
{
   using System;
   using System.Collections.Generic;

   using Detox.Editor;

   using UnityEditor;

   using UnityEngine;

   public class PromotionWindow : EditorWindow 
   {
      private static WWW webRequest;

      private static PromotionWindow window;

      // ReSharper disable once RedundantNameQualifier
      private static Detox.Editor.Promotion promotion;

      public static string WebResponseText { get; private set; }

      public static Texture WebResponseTexture { get; private set; }

      public static Dictionary<string, string> WebResponseHeaders { get; private set; }

      public static PromotionWindow Open()
      {
         window = (PromotionWindow)GetWindow(typeof(PromotionWindow), true, string.Empty, true);
         return window;
      }

      public static void StartupCheck()
      {
         const string DateFormat = "yyyyMMdd";

         // Only check once per day
         var today = int.Parse(DateTime.Now.ToString(DateFormat));
         if (Preferences.LastPromotionCheck > 0 && Preferences.LastPromotionCheck < today)
         {
            CheckServerForPromotion(uScriptBuild.Edition, Preferences.IgnorePromotions);
         }

         // Update the date so we won't check again until tomorrow
         Preferences.LastPromotionCheck = today;
      }

      public static void CheckServerForPromotion(uScriptBuild.EditionType target, string ignoredIDs, string dateOverride = "")
      {
#if (UNITY_5_4_OR_NEWER)
         if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebGL)
#else
         if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebPlayer || EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebGL)
#endif
         {
            // Abort, because the web targets do not support WWW calls in the editor.
            //
            // Exception: Expected root element to be < cross - domain - policy >.found html instead
            //    MonoForks.System.Windows.Browser.Net.FlashCrossDomainPolicy + Handler.OnStartElement(System.String name, IAttrList attrs)
            //    MonoForks.Mono.Xml.MiniParser.Parse(IReader reader, IHandler handler)
            //    MonoForks.System.Windows.Browser.Net.FlashCrossDomainPolicy.FromStream(System.IO.Stream originalStream)
            //    MonoForks.System.Windows.Browser.Net.CrossDomainPolicyManager.BuildFlashPolicy(Boolean statuscodeOK, MonoForks.System.Uri uri, System.IO.Stream responsestream, System.Collections.Generic.Dictionary`2 responseheaders)
            //    UnityEngine.WWW:get_isDone()
            return;
         }

         WebResponseText = "Checking server for promotion ...";

         webRequest = CreateWebRequest(target, ignoredIDs, dateOverride);
         if (webRequest == null)
         {
            return;
         }

         // Coroutines do not work in the editor, but we still need to handle the request in a non-blocking manner.
         // ReSharper disable once RedundantNameQualifier
         Detox.Editor.JobManager.Add(
            () => webRequest.isDone,
            () =>
               {
                  ProcessWebResponse();
                  webRequest.Dispose();
               });
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
            if (string.IsNullOrEmpty(promotion.Link) == false)
            {
               ReportClick(promotion.ID);
               OpenLink(promotion.Link);
            }
            this.Close();
         }

         if (string.IsNullOrEmpty(promotion.Title) == false)
         {
            this.titleContent = new GUIContent(promotion.Title);
         }

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

      private static WWW CreateWebRequest(uScriptBuild.EditionType target, string id, string date = "")
      {
         var uri = string.Format("https://www.detoxstudios.com/download/promotion.php");

         var form = new WWWForm();
         form.AddField("ignoredIDs", id);
         if (date != string.Empty)
         {
            form.AddField("date", date);
         }

         var headers = uScriptUtility.GetFormHeaders(form);
         headers.Add("X-USCRIPT-EDITION", target.ToString());
         headers.Add("X-USCRIPT-VERSION", uScriptBuild.Number);

         return new WWW(uri, form.data, headers);
      }

      private static void ProcessWebResponse()
      {
         var headers = webRequest.responseHeaders;

         WebResponseHeaders = headers;

         if (string.IsNullOrEmpty(webRequest.error) == false)
         {
            // DO NOTHING - Better to silently fail than to report a web request error for the promotion check.
            // An error will be generated when WWW fails to connect to the internet, and we don't want to annoy
            // users with daily warning messages, if they frequently run offline.
            WebResponseText = webRequest.error;
            return;
         }

         WebResponseText = webRequest.text;
         WebResponseTexture = webRequest.textureNonReadable;

         int promotionID;

         if (headers.ContainsKey("X-USCRIPT-PROMOTION-ID") == false
             || int.TryParse(webRequest.responseHeaders["X-USCRIPT-PROMOTION-ID"], out promotionID) == false
             || headers.ContainsKey("X-USCRIPT-PROMOTION-TITLE") == false
             || headers.ContainsKey("X-USCRIPT-PROMOTION-LINK") == false)
         {
            // The response must be invalid, so abort.
            return;
         }

         // ReSharper disable once RedundantNameQualifier
         promotion = new Detox.Editor.Promotion
                        {
                           ID = promotionID,
                           Title = headers["X-USCRIPT-PROMOTION-TITLE"],
                           Link = headers["X-USCRIPT-PROMOTION-LINK"],
                           Image = webRequest.textureNonReadable
                        };

         Open();

         // Store the promotion ID so that it can be ignored in the future
         Preferences.IgnorePromotions = string.Format("{0},{1}", promotionID, Preferences.IgnorePromotions).TrimEnd(',');

         window.Repaint();
      }

      private static void OpenLink(string url)
      {
         if (promotion.Link.StartsWith("content/"))
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

      private static void ReportClick(int promotionID)
      {
         var uri = string.Format("https://www.detoxstudios.com/download/promotion.php");

         var form = new WWWForm();
         form.AddField("clicked", promotionID);

         var headers = uScriptUtility.GetFormHeaders(form);
         headers.Add("X-USCRIPT-EDITION", uScriptBuild.Edition.ToString());
         headers.Add("X-USCRIPT-VERSION", uScriptBuild.Number);

         webRequest = new WWW(uri, form.data, headers);

         // Coroutines do not work in the editor, but we still need to handle the request in a non-blocking manner.
         // We don't care about the response, since we're just notifying the server to record the click event.
         // ReSharper disable once RedundantNameQualifier
         Detox.Editor.JobManager.Add(() => webRequest.isDone, () => webRequest.Dispose());
      }
   }
}
