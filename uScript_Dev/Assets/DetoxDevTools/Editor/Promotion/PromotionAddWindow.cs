// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PromotionAddWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PromotionAddWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.DetoxDevTools.Editor.Promotion
{
   using System;
   using System.Collections.Generic;
   using System.Diagnostics;
   using System.Globalization;
   using System.IO;

   using Detox.Editor;

   using UnityEditor;

   using UnityEngine;

   using Debug = UnityEngine.Debug;

   public class PromotionAddWindow : EditorWindow
   {
      private const string GlyphDelete = "\uf057";

      private const string GlyphCalendar = "\uf073";

      private const string GlyphPrevious = "\uf053";

      private const string GlyphToday = "\uf192";

      private const string GlyphNext = "\uf054";

      private const string GlyphUpload = "\uf093";
      
      private static PromotionAddWindow window;

      private static WWW webRequest;

      private bool showMonthButtons = true;

      private Rect calendarWindowRect = new Rect(10, 0, 240, 164);

      private DateTime calendarMinDate = DateTime.MinValue;

      private DateTime calendarMaxDate = DateTime.MaxValue;

      private bool showCalendarPopup;

      private DateTime currentDate;

      private DateTime initialDate;

      private DateTime selectedDate;

      private bool isFirstRun;

      private Promotion original;

      private Promotion current;

      private bool datePickerIsForStart = true;

      public enum UpdateStatus
      {
         None,
         CheckNeeded,
         CheckInProgress,
         ClientBuildCurrent,
         ClientBuildNewer,
         ClientBuildOlder,
         UpdateClientError,
         UpdateServerError
      }

      public static string WebResponse { get; private set; }

      public static PromotionAddWindow Window
      {
         get
         {
            if (window == null)
            {
               Open();
            }

            return window;
         }
      }

      public static void Open()
      {
         window = (PromotionAddWindow)GetWindow(typeof(PromotionAddWindow), true, Content.WindowTitle, true);

         window.minSize = window.maxSize = new Vector2(300, 300);
         window.Show();
         window.Focus();
      }

      internal void OnDisable()
      {
      }

      internal void OnEnable()
      {
         this.isFirstRun = true;

         this.original = new Promotion();
         this.current = this.original.DeepClone();
      }

      internal void OnGUI()
      {
         this.OnGUIHandleFirstRun();
         
         this.OnGUIHandleWindowOverrides();

         this.OnGUIDrawFields();
         this.OnGUIDrawPreview();
         this.OnGUIDrawButtons();

         this.OnGUIDrawWindows();
      }

      private static string FileBrowserButton(string value)
      {
         if (GUILayout.Button(GlyphUpload, Style.PopupIconButton, GUILayout.ExpandWidth(false)))
         {
            GUIUtility.keyboardControl = 0;

            const string Title = "Select Promotion Image";
            const string Extension = "*.pcx;*.png;*.jpg;*.jpeg;*.gif";
            var directory = value == string.Empty ? value : Path.GetDirectoryName(value);

            var newFilePath = EditorUtility.OpenFilePanel(Title, directory, Extension);
            if (value != newFilePath && newFilePath != string.Empty)
            {
               // Only assign if the path has changed and is not empty (cancel was pressed)
               value = newFilePath;
            }
         }
         return value;
      }

      private static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
      {
         var defaultCultureInfo = CultureInfo.CurrentCulture;
         return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
      }

      private static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
      {
         var firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
         var firstDayInWeek = dayInWeek.Date;

         while (firstDayInWeek.DayOfWeek != firstDay)
         {
            firstDayInWeek = firstDayInWeek.AddDays(-1);
         }

         return firstDayInWeek;
      }

      private static T ResetFieldButton<T>(T value, T originalValue)
      {
         var originalEnabledState = GUI.enabled;
         GUI.enabled = !EqualityComparer<T>.Default.Equals(value, originalValue) && originalEnabledState;

         var buttonLabel = GUI.enabled ? Content.ButtonResetField : GUIContent.none;
         if (GUILayout.Button(buttonLabel, Style.PopupIconButton, GUILayout.Width(16)))
         {
            GUIUtility.keyboardControl = 0;
            value = originalValue;
         }

         GUI.enabled = originalEnabledState;
         return value;
      }

      private void UploadPromotion()
      {
         WebResponse = "Uploading promotion ...";

         webRequest = this.CreateWebRequest("add");

         var stopwatch = Stopwatch.StartNew();
         var timeout = new TimeSpan(0, 0, 0, 50);

         while (!webRequest.isDone && stopwatch.Elapsed < timeout)
         {
         }

         stopwatch.Stop();

         if (webRequest.isDone)
         {
            this.ProcessWebResponse();
         }

         webRequest.Dispose();
      }

      private WWW CreateWebRequest(string action)
      {
         var uri = string.Format("http://www.detoxstudios.com/download/promotionAdmin.php");

         var form = new WWWForm();
         form.AddField("action", action);
         form.AddField("target", this.current.Edition.ToString());
         form.AddField("startDate", this.current.StartDate);
         form.AddField("endDate", this.current.EndDate);
         form.AddField("link", this.current.Link);

         //var encoded = Convert.ToBase64String(this.current.Image.EncodeToPNG());
         //Debug.Log("ENCODED: " + encoded + "\n");
         //form.AddField("imageData", encoded);
         form.AddBinaryData("image", this.current.Image.EncodeToPNG(), Path.GetFileName(this.current.ImagePath));

         var headers = form.headers;
         headers.Add("X-uScript-Edition", uScriptBuild.Edition.ToString());
         headers.Add("X-uScript-Version", uScriptBuild.Number);

         return new WWW(uri, form.data, headers);
      }

      private void ProcessWebResponse()
      {
         WebResponse = webRequest.text;

         if (string.IsNullOrEmpty(webRequest.error) == false)
         {
            // DO NOTHING - Better to silently fail than to report a web request error during the startup check.
            // An error will be generated when WWW fails to connect to the internet, and we don't want to annoy
            // users with daily warning messages, if they frequently run offline.

            //var msg = string.Format("{0}: \"{1}\"", Content.TitleError.text, webRequest.error);
            //uScriptDebug.Log(msg, uScriptDebug.Type.Warning);

            WebResponse = webRequest.error;
            return;
         }

         Open();

         window.Repaint();
      }

      private void OnGUIHandleFirstRun()
      {
         if (this.isFirstRun)
         {
            this.isFirstRun = false;
         }
      }

      private void OnGUIDrawWindows()
      {
         var e = Event.current;

         // Now that the standard GUI has been drawn, any GUI.Window elements can be processed.
         this.BeginWindows();
         {
            if (this.showCalendarPopup)
            {
               this.selectedDate = DateTime.MinValue;

               GUI.enabled = true;

               GUI.Window(10, this.calendarWindowRect, this.OnGUIDrawCalendar, string.Empty, Style.CalendarWindow);

               if (e.type == EventType.MouseDown || e.type == EventType.ContextClick)
               {
                  if (this.calendarWindowRect.Contains(e.mousePosition))
                  {
                     e.Use();
                  }
                  else
                  {
                     this.showCalendarPopup = false;
                     this.Repaint();
                  }
               }
            }
            else
            {
               if (this.selectedDate != DateTime.MinValue)
               {
                  if (this.datePickerIsForStart)
                  {
                     this.current.StartDate = this.selectedDate.ToString(Promotion.DateFormat);
                  }
                  else
                  {
                     this.current.EndDate = this.selectedDate.ToString(Promotion.DateFormat);
                  }

                  this.selectedDate = DateTime.MinValue;
               }
            }
         }
         this.EndWindows();

         GUI.enabled = true;
      }

      private void OnGUIHandleWindowOverrides()
      {
         var e = Event.current;

         // GUI.Windows needs special handling. CursorRects associated with GUI.Windows must be
         // applied be the rest of the GUI is processed, and when a Window is open, the
         // non-Window GUI must be disabled.
         if (this.showCalendarPopup)
         {
            // Force the arrow cursor to prevent the cursor from changing when the window is drawn over other controls.
            EditorGUIUtility.AddCursorRect(this.calendarWindowRect, MouseCursor.Arrow);

            if (e.type != EventType.Repaint)
            {
               // Disable the entire GUI until the window is drawn
               GUI.enabled = false;
            }
         }
      }

      private void OnGUIDrawPreview()
      {
         EditorGUILayout.Space();

         this.OnGUIDrawImageThumbnail();
         this.OnGUIDrawImageDimensions();

         EditorGUILayout.Space();
      }

      private void OnGUIDrawFieldEdition()
      {
         EditorGUILayout.BeginHorizontal();
         {
            var value = this.current.Edition;
            value = (uScriptBuild.EditionType)EditorGUILayout.EnumPopup(Content.PropertyLabelEdition, value);
            value = ResetFieldButton(value, this.original.Edition);
            this.current.Edition = value;
         }
         EditorGUILayout.EndHorizontal();
      }

      private void OnGUIDrawFieldEndDate()
      {
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2)
         EditorGUIUtility.fieldWidth -= 19;
#endif

         EditorGUILayout.BeginHorizontal();
         {
            var value = this.current.EndDate;
            value = EditorGUILayout.TextField(Content.PropertyLabelEndDate, value).Trim().ToLower();

            if (GUILayout.Button(GlyphCalendar, Style.PopupIconButton, GUILayout.ExpandWidth(false)))
            {
               GUIUtility.keyboardControl = 0;
               this.showCalendarPopup = !this.showCalendarPopup;
               this.datePickerIsForStart = false;

               DateTime dateTime;
               var parsed = DateTime.TryParse(value, out dateTime);
               if (parsed)
               {
                  this.initialDate = dateTime;
                  this.currentDate = dateTime;
               }
            }

            if (Event.current.type == EventType.Repaint && this.datePickerIsForStart == false)
            {
               var rect = GUILayoutUtility.GetLastRect();
               this.calendarWindowRect.y = rect.yMax + 2;
               this.calendarWindowRect.x = rect.xMax - this.calendarWindowRect.width;
            }

            value = ResetFieldButton(value, this.original.EndDate);

            if (value != this.current.EndDate)
            {
               if (value != string.Empty)
               {
                  if (value == "start")
                  {
                     this.current.EndDate = this.current.StartDate;
                  }
                  else if (value == "today")
                  {
                     this.current.EndDate = DateTime.Today.ToString(Promotion.DateFormat);
                  }
                  else
                  {
                     DateTime dateTime;
                     if (DateTime.TryParse(value, out dateTime))
                     {
                        this.current.EndDate = dateTime.ToString(Promotion.DateFormat);
                     }
                  }
               }
            }
         }
         EditorGUILayout.EndHorizontal();

#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2)
         EditorGUIUtility.fieldWidth += 19;
#endif
      }

      private void OnGUIDrawFieldID()
      {
         //int value;
         //var label = new GUIContent(
         //   "ID",
         //   "Enter the ID of the last promotion received. The number should be an positive integer value.");

         //EditorGUILayout.BeginHorizontal();
         //{
         //   value = EditorGUILayout.IntField(label, this.idParameter);

         //   if (GUILayout.Button("Reset", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
         //   {
         //      GUIUtility.keyboardControl = 0;
         //      value = 0;
         //   }
         //}
         //EditorGUILayout.EndHorizontal();

         //this.idParameter = Mathf.Max(0, value);
      }

      private void OnGUIDrawFieldImagePath()
      {
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2)
         EditorGUIUtility.fieldWidth -= 19;
#endif

         EditorGUILayout.BeginHorizontal();
         {
            var value = this.current.ImagePath;
            value = EditorGUILayout.TextField(Content.PropertyLabelImagePath, value).Trim();
            value = FileBrowserButton(value);
            value = ResetFieldButton(value, this.original.ImagePath);
            if (this.current.ImagePath != value)
            {
               this.current.ImagePath = value;
               this.current.Image = null;
            }
         }
         EditorGUILayout.EndHorizontal();

#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2)
         EditorGUIUtility.fieldWidth += 19;
#endif
      }

      private void OnGUIDrawFieldLinkPath()
      {
         EditorGUILayout.BeginHorizontal();
         {
            var value = this.current.Link;
            value = EditorGUILayout.TextField(Content.PropertyLabelLinkPath, value).Trim();
            value = ResetFieldButton(value, this.original.Link);
            this.current.Link = value;
         }
         EditorGUILayout.EndHorizontal();
      }

      private void OnGUIDrawFieldStartDate()
      {
         var e = Event.current;
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2)
         EditorGUIUtility.fieldWidth -= 19;
#endif

         EditorGUILayout.BeginHorizontal();
         {
            var value = EditorGUILayout.TextField(Content.PropertyLabelStartDate, this.current.StartDate).Trim().ToLower();

            if (GUILayout.Button(GlyphCalendar, Style.PopupIconButton, GUILayout.ExpandWidth(false)))
            {
               GUIUtility.keyboardControl = 0;
               this.showCalendarPopup = !this.showCalendarPopup;
               this.datePickerIsForStart = true;

               DateTime dateTime;
               var parsed = DateTime.TryParse(value, out dateTime);
               if (parsed)
               {
                  this.initialDate = dateTime;
                  this.currentDate = dateTime;
               }
            }

            if (e.type == EventType.Repaint && this.datePickerIsForStart)
            {
               var rect = GUILayoutUtility.GetLastRect();
               this.calendarWindowRect.y = rect.yMax + 2;
               this.calendarWindowRect.x = rect.xMax - this.calendarWindowRect.width;
            }

            value = ResetFieldButton(value, this.original.StartDate);

            if (value != this.current.StartDate)
            {
               if (value != string.Empty)
               {
                  if (value == "end")
                  {
                     this.current.StartDate = this.current.EndDate;
                  }
                  else if (value == "today")
                  {
                     this.current.StartDate = DateTime.Today.ToString(Promotion.DateFormat);
                  }
                  else
                  {
                     DateTime dateTime;
                     if (DateTime.TryParse(value, out dateTime))
                     {
                        this.current.StartDate = dateTime.ToString(Promotion.DateFormat);
                     }
                  }
               }
            }
         }
         EditorGUILayout.EndHorizontal();

#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2)
         EditorGUIUtility.fieldWidth += 19;
#endif
      }

      private void OnGUIDrawCalendar(int windowID)
      {
         if (Event.current.type == EventType.Layout)
         {
            return;
         }

         var rect = new Rect(0, 0, this.calendarWindowRect.width, 20);
         rect.y = this.OnGUIDrawCalendarHeader(rect);
         rect.y = this.OnGUIDrawCalendarDayNames(rect);
         rect.y = this.OnGUIDrawCalendarGrid(rect);
      }

      private float OnGUIDrawCalendarGrid(Rect rect)
      {
         rect.x = 1;
         rect.width = 34;

         var firstDayOfMonth = new DateTime(this.currentDate.Year, this.currentDate.Month, 1);
         var firstDateInFirstWeek = GetFirstDayOfWeek(firstDayOfMonth);

         var days = 0;
         while (days < 42)
         {
            for (var day = 0; day < 7; day++)
            {
               var date = firstDateInFirstWeek.AddDays(days + day);
               var style = Style.CalendarDayButton(date, this.currentDate);

               if (date.Date == this.initialDate.Date)
               {
                  var initialDateRect = new Rect(rect.x + 2, rect.y + 2, rect.width - 4, rect.height - 4);
                  GUI.Box(initialDateRect, string.Empty);
               }

               if (GUI.Button(rect, date.Day.ToString(CultureInfo.InvariantCulture), style))
               {
                  this.selectedDate = date;
                  this.showCalendarPopup = false;
               }

               rect.x += rect.width;
            }

            rect.x = 1;
            rect.y += rect.height;

            days += 7;
         }

         rect.y -= rect.height;

         return rect.y;
      }

      private float OnGUIDrawCalendarDayNames(Rect rect)
      {
         rect.x = 0;
         rect.width = 240;
         rect.height = 20;

         GUI.Box(rect, GUIContent.none);

         rect.x = 2;
         rect.width = 32;

         var dayNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;
         foreach (var dayName in dayNames)
         {
            GUI.Label(rect, dayName, Style.CalendarDayNameLabel);
            rect.x += rect.width + 2;
         }

         rect.y += rect.height;

         return rect.y;
      }

      private float OnGUIDrawCalendarHeader(Rect rect)
      {
         rect.x += 4;
         rect.height += 2;

         GUI.Label(rect, GlyphCalendar, Style.CalendarTitleIcon);

         rect.x += 16;

         GUI.Label(rect, this.currentDate.ToString("MMMM yyyy"), Style.CalendarTitleLabel);

         if (this.showMonthButtons)
         {
            rect.y += 2;
            rect.height -= 4;
            rect.width = 24;

            if (this.showMonthButtons)
            {
               rect.x = 240 - (rect.width * 3) - 2;

               GUI.enabled = this.CanDecrementMonth();
               if (GUI.Button(rect, GlyphPrevious, Style.CalendarMonthButtonLeft))
               {
                  this.ChangeSelectedMonth(-1);
               }

               rect.x += rect.width;

               if (GUI.Button(rect, GlyphToday, Style.CalendarMonthButtonMid))
               {
                  this.ChangeSelectedMonth();
               }

               rect.x += rect.width;

               GUI.enabled = this.CanIncrementMonth();
               if (GUI.Button(rect, GlyphNext, Style.CalendarMonthButtonRight))
               {
                  this.ChangeSelectedMonth(1);
               }
            }

            GUI.enabled = true;
         }

         rect.y -= 2;
         rect.height += 4;

         rect.y += rect.height;

         return rect.y;
      }

      private bool CanDecrementMonth()
      {
         return this.calendarMinDate.AddMonths(1).Date <= this.currentDate.Date;
      }

      private bool CanIncrementMonth()
      {
         return this.calendarMaxDate.AddMonths(-1).Date >= this.currentDate.Date;
      }

      private void ChangeSelectedMonth(int months = 0)
      {
         this.currentDate = months == 0 ? DateTime.Today.Date : this.currentDate.AddMonths(months);
      }

      private void OnGUIDrawFields()
      {
         EditorGUILayout.BeginVertical();
         {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
            EditorGUIUtility.LookLikeControls(100, 100);
#else
            EditorGUIUtility.labelWidth = 100;
            EditorGUIUtility.fieldWidth = 100;
#endif

            EditorGUILayout.Space();

            this.OnGUIDrawFieldID();
            this.OnGUIDrawFieldEdition();
            
            EditorGUILayout.Space();

            this.OnGUIDrawFieldStartDate();
            this.OnGUIDrawFieldEndDate();

            EditorGUILayout.Space();
            
            this.OnGUIDrawFieldLinkPath();
            this.OnGUIDrawFieldImagePath();
         }
         EditorGUILayout.EndVertical();
      }

      private void OnGUIDrawImageDimensions()
      {
         var texture = this.current.Image;
         if (texture != null)
         {
            var found = texture.width != 8 || texture.height != 8;
            var label = found ? string.Format("{0} x {1}", texture.width, texture.height) : "No image was found.";
            GUILayout.Label(label, Style.ImageDimensions);
         }
      }

      private void OnGUIDrawImageThumbnail()
      {
         var value = this.current.ImagePath;

         if (value != string.Empty)
         {
            this.current.Image = new Texture2D(8, 8);
            var www = new WWW(string.Format("file:///{0}", value));
            www.LoadImageIntoTexture(this.current.Image);

            var found = this.current.Image.width != 8 || this.current.Image.height != 8;
            if (found)
            {
               var width = Window.position.width - 8f;
               var height = Mathf.Ceil(292f / this.current.Image.width * this.current.Image.height);

               GUILayout.Label(this.current.Image, GUILayout.Width(width), GUILayout.Height(height));
            }
         }
      }

      private void OnGUIDrawButtons()
      {
         EditorGUILayout.BeginHorizontal();
         {
            this.OnGUIDrawResetButton();
            GUILayout.FlexibleSpace();
            this.OnGUIDrawCancelButton();
            this.OnGUIDrawSaveButton();
         }
         EditorGUILayout.EndHorizontal();

         GUILayout.Space(6);

         if (Event.current.type == EventType.Repaint)
         {
            var rect = GUILayoutUtility.GetLastRect();
            Window.minSize = Window.maxSize = new Vector2(300, rect.yMax);
         }
      }

      private void OnGUIDrawResetButton()
      {
         if (GUILayout.Button(Content.ButtonResetFields, GUILayout.ExpandWidth(false)))
         {
            GUIUtility.keyboardControl = 0;
            this.current = this.original.DeepClone();
         }
      }

      private void OnGUIDrawCancelButton()
      {
         if (GUILayout.Button(Content.ButtonCancel, GUILayout.ExpandWidth(false)))
         {
            this.Close();
         }
      }

      private void OnGUIDrawSaveButton()
      {
         var originalEnabledState = GUI.enabled;
         GUI.enabled = !string.IsNullOrEmpty(this.current.ImagePath) && !string.IsNullOrEmpty(this.current.Link)
                       && originalEnabledState;

         if (GUILayout.Button(Content.ButtonSave, GUILayout.ExpandWidth(false)))
         {
            this.UploadPromotion();
            this.Close();

            Debug.Log(string.Format("webResponse: {0}\n", WebResponse));
         }

         GUI.enabled = originalEnabledState;
      }

      private static class Content
      {
         static Content()
         {
            ButtonCancel = new GUIContent("Cancel");
            ButtonResetField = new GUIContent(GlyphDelete, "Reset this field value to its initial state.");
            ButtonResetFields = new GUIContent("Reset", "Reset the field values to their initial state.");
            ButtonSave = new GUIContent("Save");

            PropertyLabelEdition = new GUIContent("Edition Target", "Specify the uScript edition the promotion should target.");

            PropertyLabelEndDate = new GUIContent(
               "End Date",
               string.Format("Enter \"start\", \"today\", or a date \"{0}\".", Promotion.DateFormat));

            PropertyLabelStartDate = new GUIContent(
               "Start Date",
               string.Format("Enter \"end\", \"today\", or a date \"{0}\".", Promotion.DateFormat));

            PropertyLabelImagePath = new GUIContent("Image Path", "Absolute path to the image file");

            PropertyLabelLinkPath = new GUIContent("Link Path", "Relative asset store path or a full HTTP(s) URL.");

            WindowTitle = "Add Promotion";
         }

         public static GUIContent ButtonCancel { get; private set; }

         public static GUIContent ButtonResetField { get; private set; }

         public static GUIContent ButtonResetFields { get; private set; }

         public static GUIContent ButtonSave { get; private set; }

         public static GUIContent PropertyLabelEdition { get; private set; }

         public static GUIContent PropertyLabelEndDate { get; private set; }

         public static GUIContent PropertyLabelImagePath { get; private set; }

         public static GUIContent PropertyLabelLinkPath { get; private set; }

         public static GUIContent PropertyLabelStartDate { get; private set; }

         public static string WindowTitle { get; private set; }
      }

      private static class Style
      {
         private static readonly GUIStyle CalendarDayOther;

         private static readonly GUIStyle CalendarDayOtherToday;

         private static readonly GUIStyle CalendarDayThis;

         private static readonly GUIStyle CalendarDayThisToday;

         static Style()
         {
            var fontAwesome = uScriptGUI.GetFont("Assets/DetoxDevTools/Editor/Fonts/FontAwesome.otf");

            ImageDimensions = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };

            CalendarDayThis = new GUIStyle(GUI.skin.button)
            {
               normal = GUI.skin.label.normal,
               alignment = TextAnchor.MiddleCenter,
            };

            CalendarDayOther = new GUIStyle(CalendarDayThis)
            {
               normal =
               {
                  textColor =
                     new Color(
                     CalendarDayThis.normal.textColor.r,
                     CalendarDayThis.normal.textColor.g,
                     CalendarDayThis.normal.textColor.b,
                     0.5f)
               }
            };

            CalendarDayThisToday = new GUIStyle(CalendarDayThis)
            {
               fontStyle = FontStyle.Bold,
               normal = { textColor = new Color(1, 0.8f, 0, 1) }
            };

            CalendarDayOtherToday = new GUIStyle(CalendarDayThisToday)
            {
               normal =
               {
                  textColor =
                     new Color(
                     CalendarDayThisToday.normal.textColor.r,
                     CalendarDayThisToday.normal.textColor.g,
                     CalendarDayThisToday.normal.textColor.b,
                     0.5f)
               }
            };

            CalendarTitleLabel = new GUIStyle(EditorStyles.largeLabel)
            {
               fontStyle = FontStyle.Bold,
               alignment = TextAnchor.MiddleLeft,
            };

            CalendarMonthButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft)
            {
               alignment = TextAnchor.MiddleCenter,
               font = fontAwesome,
               contentOffset = new Vector2(-1, 1),
            };

            CalendarMonthButtonMid = new GUIStyle(EditorStyles.miniButtonMid)
            {
               alignment = TextAnchor.MiddleCenter,
               font = fontAwesome,
               contentOffset = new Vector2(0, 1),
            };

            CalendarMonthButtonRight = new GUIStyle(EditorStyles.miniButtonRight)
            {
               alignment = TextAnchor.MiddleCenter,
               font = fontAwesome,
               contentOffset = new Vector2(-1, 1),
            };

            CalendarDayNameLabel = new GUIStyle(EditorStyles.boldLabel)
            {
               alignment = TextAnchor.MiddleCenter,
            };

            CalendarTitleIcon = new GUIStyle(EditorStyles.largeLabel)
            {
               alignment = TextAnchor.MiddleLeft,
               font = fontAwesome,
            };

            PopupIconButton = new GUIStyle(EditorStyles.label)
            {
               alignment = TextAnchor.MiddleLeft,
               font = fontAwesome,
               contentOffset = new Vector2(1, 1),
            };

            CalendarWindow = new GUIStyle(uScriptGUIStyle.MenuContextWindow);
         }

         public static GUIStyle ImageDimensions { get; private set; }

         public static GUIStyle CalendarDayNameLabel { get; private set; }

         public static GUIStyle CalendarMonthButtonLeft { get; private set; }

         public static GUIStyle CalendarMonthButtonMid { get; private set; }

         public static GUIStyle CalendarMonthButtonRight { get; private set; }

         public static GUIStyle PopupIconButton { get; private set; }

         public static GUIStyle CalendarTitleIcon { get; private set; }

         public static GUIStyle CalendarTitleLabel { get; private set; }

         public static GUIStyle CalendarWindow { get; private set; }

         public static GUIStyle CalendarDayButton(DateTime date, DateTime selectedDate)
         {
            var isMonth = date.Month == selectedDate.Month;
            var isToday = date.Date == DateTime.Today.Date;

            if (isMonth)
            {
               return isToday ? CalendarDayThisToday : CalendarDayThis;
            }

            return isToday ? CalendarDayOtherToday : CalendarDayOther;
         }
      }
   }
}
