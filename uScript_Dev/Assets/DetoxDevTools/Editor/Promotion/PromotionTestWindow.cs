// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PromotionTestWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the UpdateCheck type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !UNITY_3_5
namespace Detox.DetoxDevTools.Editor.Promotion
{
#endif
   using System;
   using System.Globalization;
   using System.Linq;

   using Detox.Editor.GUI.Windows;

   using UnityEditor;

   using UnityEngine;

   public class PromotionTestWindow : EditorWindow
   {
      private static PromotionTestWindow window;

      private string dateParameter = string.Empty;
      private string idParameter = string.Empty;
      private uScriptBuild.EditionType targetParameter = uScriptBuild.EditionType.Basic;

      private Vector2 scrollviewPosition;

      [MenuItem("uScript/Internal/Test Windows/Check for Promotion %#z", false, 101)]
      internal static void Init()
      {
         // Get existing open window or if none, make a new one:
         //PromotionTestWindow window = (PromotionTestWindow)EditorWindow.GetWindow (typeof (PromotionTestWindow));
         window = (PromotionTestWindow)GetWindow(typeof(PromotionTestWindow), false, "Promotion Test", true);
         window.minSize = window.maxSize = new Vector2(320, 480);
      }

      internal void OnGUI()
      {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
      EditorGUIUtility.LookLikeControls(110);
#else
         EditorGUIUtility.labelWidth = 110;
#endif

         GUILayout.Label("Parameters", EditorStyles.boldLabel);
         EditorGUI.indentLevel++;
         {
            this.DoTargetParameterField();
            this.DoPromotionParameterField();
            this.DoDateParameterField();
         }
         EditorGUI.indentLevel--;

         EditorGUILayout.Space();

         GUILayout.Label("uScript", EditorStyles.boldLabel);
         EditorGUI.indentLevel++;
         EditorGUILayout.LabelField("Latest ID", UpdateNotification.LatestVersion);
         EditorGUI.indentLevel--;

         EditorGUILayout.Space();

         if (GUILayout.Button("Check for Promotion"))
         {
            GUIUtility.keyboardControl = 0;
            PromotionWindow.CheckServerForPromotion(this.targetParameter, this.idParameter, this.dateParameter);
         }

         EditorGUILayout.Space();

         GUILayout.Label("Server Response", EditorStyles.boldLabel);

         if (PromotionWindow.WebResponseHeaders != null)
         {
            EditorGUI.indentLevel++;
            {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
               EditorGUIUtility.LookLikeControls(200);
#else
               var originalLabelWidth = EditorGUIUtility.labelWidth;
               EditorGUIUtility.labelWidth = 200;
#endif

               EditorGUILayout.LabelField("Status", PromotionWindow.WebResponseHeaders["STATUS"]);

               var headers = PromotionWindow.WebResponseHeaders.Keys.ToList();
               headers.Remove("STATUS");
               headers.Sort();

               var textInfo = new CultureInfo("en-US", false).TextInfo;
               foreach (var header in headers)
               {
                  var words = header.Split('-');
                  for (var i = 0; i < words.Length; i++)
                  {
                     words[i] = textInfo.ToTitleCase(words[i].ToLower());
                  }

                  var label = string.Join("-", words).Replace("-Id", "-ID").Replace("-Uscript-", "-uScript-");
                  EditorGUILayout.LabelField(label, PromotionWindow.WebResponseHeaders[header]);
               }

#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
               EditorGUIUtility.LookLikeControls(110);
#else
               EditorGUIUtility.labelWidth = originalLabelWidth;
#endif
            }
            EditorGUI.indentLevel--;

            EditorGUILayout.Space();

            this.scrollviewPosition = EditorGUILayout.BeginScrollView(this.scrollviewPosition, GUILayout.ExpandHeight(true));
            {
               switch (PromotionWindow.WebResponseHeaders["CONTENT-TYPE"])
               {
                  case "image/png":
                     var textureContent = PromotionWindow.WebResponseTexture;
                     GUILayout.Box(
                        textureContent,
                        GUIStyle.none,
                        GUILayout.Height(textureContent.height),
                        GUILayout.ExpandHeight(true));
                     break;

                  default:
                     var text = new GUIContent(PromotionWindow.WebResponseText ?? string.Empty);
                     var height = GUI.skin.label.CalcHeight(text, 100);
                     EditorGUILayout.SelectableLabel(text.text, GUILayout.Height(height), GUILayout.ExpandHeight(true));
                     break;
               }
            }
            EditorGUILayout.EndScrollView();
         }
      }

      private static string FormatDate(DateTime dateTime)
      {
         return string.Format("{0:0000}-{1:00}-{2:00}", dateTime.Year, dateTime.Month, dateTime.Day);
      }

      private void DoDateParameterField()
      {
         string value;
         var label = new GUIContent(
            "Date",
            "Enter \"today\", \"tomorrow\", \"yesterday\", or a specific date in the format \"YYYY-MM-DD\".");

         EditorGUILayout.BeginHorizontal();
         {
            value = EditorGUILayout.TextField(label, this.dateParameter).ToLower().Trim();

            if (GUILayout.Button("Reset", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
            {
               GUIUtility.keyboardControl = 0;
               value = string.Empty;
            }
         }
         EditorGUILayout.EndHorizontal();

         if (value == this.dateParameter)
         {
            return;
         }

         if (value == string.Empty)
         {
            this.dateParameter = string.Empty;
         }
         else if (value == "today")
         {
            this.dateParameter = FormatDate(DateTime.Today);
         }
         else if (value == "tomorrow")
         {
            this.dateParameter = FormatDate(DateTime.Today.AddDays(1));
         }
         else if (value == "yesterday")
         {
            this.dateParameter = FormatDate(DateTime.Today.AddDays(-1));
         }
         else
         {
            DateTime dateTime;
            var parsed = DateTime.TryParse(value, out dateTime);
            this.dateParameter = parsed ? FormatDate(dateTime) : string.Empty;
         }
      }

      private void DoPromotionParameterField()
      {
         string value;
         var label = new GUIContent(
            "ID",
            "Enter the ID of the last promotion received. The number should be an positive integer value.");

         EditorGUILayout.BeginHorizontal();
         {
            value = EditorGUILayout.TextField(label, this.idParameter);

            if (GUILayout.Button("Reset", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
            {
               GUIUtility.keyboardControl = 0;
               value = string.Empty;
            }

            if (value != this.idParameter)
            {
               this.idParameter = value.Trim();
            }
         }
         EditorGUILayout.EndHorizontal();
      }

      private void DoTargetParameterField()
      {
         uScriptBuild.EditionType value;
         var label = new GUIContent(
            "Target",
            "Specify the uScript edition the promotion should target.");

         EditorGUILayout.BeginHorizontal();
         {
            value = (uScriptBuild.EditionType)EditorGUILayout.EnumPopup(label, this.targetParameter);

            if (GUILayout.Button("Reset", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
            {
               GUIUtility.keyboardControl = 0;
               value = uScriptBuild.EditionType.Basic;
            }
         }
         EditorGUILayout.EndHorizontal();

         this.targetParameter = value;
      }
   }
#if !UNITY_3_5
}
#endif
