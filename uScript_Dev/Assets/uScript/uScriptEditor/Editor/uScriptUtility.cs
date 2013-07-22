// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptUtility.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   This file contains a collection of utility classes for use with uScript.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

public static class uScriptUtility
{
   /// <summary>Gets the index of an enumeration by name.</summary>
   /// <returns>The first occurrence of the specified name within the enumeration, if found; otherwise, -1.</returns>
   /// <param name="e">The enumeration type.</param>
   /// <param name="name">The name of the enumeration.</param>
   public static int GetEnumIndexByName(Enum e, string name)
   {
      return Array.IndexOf(Enum.GetNames(e.GetType()), name);
   }

   /// <summary>Gets the index of an enumeration by value.</summary>
   /// <returns>The first occurrence of the value within the enumeration, if found; otherwise, -1.</returns>
   /// <param name='e'>The enumeration type.</param>
   /// <param name='val'>The value to search for.</param>
   public static int GetEnumIndexByValue(Enum e, int val)
   {
      return Array.IndexOf((int[])Enum.GetValues(e.GetType()), val);
   }

   /// <summary>Gets the enumeration name by index.</summary>
   /// <returns>The name of the enum element, or throws an exception.</returns>
   /// <param name='e'>The enumeration type.</param>
   /// <param name='index'>The index of the enumeration.</param>
   public static string GetEnumNameByIndex(Enum e, int index)
   {
      return Enum.GetNames(e.GetType())[index];
   }

   /// <summary>Gets the index of the enum value by.</summary>
   /// <returns>The name of the enum element, or throws an exception.</returns>
   /// <param name='e'>The enumeration type.</param>
   /// <param name='index'>The index of the enumeration.</param>
   public static int GetEnumValueByIndex(Enum e, int index)
   {
      return ((int[])Enum.GetValues(e.GetType()))[index];
   }

   /// <summary>Rounds a numer to the nearest multiple.</summary>
   /// <returns>The rounded number.</returns>
   /// <param name='number'>The number to round.</param>
   /// <param name='multiple'>The multiple.</param>
   public static int RoundToMultiple(int number, int multiple)
   {
      return ((multiple / 2 + number) / multiple) * multiple;
   }
}


public static class uScriptExtensions
{
   public static void Information(this UnityEngine.GUIStyle style, int columns)
   {
      uScriptGUIStyle.Information(style, columns);
   }

   public enum TextOverflowMethod
   {
      Clip,
      EllipsisEnd,
      EllipsisMiddle
   }

   public static string FormatTextOverflow(this string text, UnityEngine.GUIStyle style, float maxWidth, TextOverflowMethod method)
   {
      return text + "_OVERFLOW";
   }

   public static string NewLine(this string text)
   {
      return text + "\n";
   }

   public static bool CoinToss(this System.Random r)
   {
      return r.NextDouble() < 0.5f;
   }

   public static T OneOf<T>(this System.Random r, params T[] array)
   {
      return array[r.Next(array.Length)];
   }
}


/// <summary>
/// String Extentensions
/// </summary>
public static class StringExtensions
{
   #region FormatWith

   /// <summary>
   /// Formats a string with one literal placeholder.
   /// </summary>
   /// <param name="text">The extension text</param>
   /// <param name="arg0">Argument 0</param>
   /// <returns>The formatted string</returns>
   public static string FormatWith(this string text, object arg0)
   {
      return string.Format(text, arg0);
   }

   /// <summary>
   /// Formats a string with two literal placeholders.
   /// </summary>
   /// <param name="text">The extension text</param>
   /// <param name="arg0">Argument 0</param>
   /// <param name="arg1">Argument 1</param>
   /// <returns>The formatted string</returns>
   public static string FormatWith(this string text, object arg0, object arg1)
   {
      return string.Format(text, arg0, arg1);
   }

   /// <summary>
   /// Formats a string with tree literal placeholders.
   /// </summary>
   /// <param name="text">The extension text</param>
   /// <param name="arg0">Argument 0</param>
   /// <param name="arg1">Argument 1</param>
   /// <param name="arg2">Argument 2</param>
   /// <returns>The formatted string</returns>
   public static string FormatWith(this string text, object arg0, object arg1, object arg2)
   {
      return string.Format(text, arg0, arg1, arg2);
   }

   /// <summary>
   /// Formats a string with a list of literal placeholders.
   /// </summary>
   /// <param name="text">The extension text</param>
   /// <param name="args">The argument list</param>
   /// <returns>The formatted string</returns>
   public static string FormatWith(this string text, params object[] args)
   {
      return string.Format(text, args);
   }

   /// <summary>
   /// Formats a string with a list of literal placeholders.
   /// </summary>
   /// <param name="text">The extension text</param>
   /// <param name="provider">The format provider</param>
   /// <param name="args">The argument list</param>
   /// <returns>The formatted string</returns>
   public static string FormatWith(this string text, IFormatProvider provider, params object[] args)
   {
      return string.Format(provider, text, args);
   }
   #endregion

   #region UnityEngine.Color to hex
   public static string ToHex(this UnityEngine.Color color)
   {
      return ((int)(color.r * 255)).ToString("X2") + ((int)(color.g * 255)).ToString("X2") + ((int)(color.b * 255)).ToString("X2");
   }
   #endregion

   #region HTML Tags
   public static string Bold(this string value)
   {
      return "<b>" + value + "</b>";
   }

   public static string BoldItalic(this string value)
   {
      return "<b><i>" + value + "</i></b>";
   }

   public static string Italic(this string value)
   {
      return "<i>" + value + "</i>";
   }

   public static string Color(this string value, UnityEngine.Color color)
   {
      return "<color=#" + color.ToHex() + ">" + value + "</color>";
   }

   public static string White(this string value)
   {
      return value.Color(UnityEngine.Color.white);
   }

   public static string Black(this string value)
   {
      return value.Color(UnityEngine.Color.black);
   }

   public static string Red(this string value)
   {
      return value.Color(UnityEngine.Color.red);
   }

   public static string Green(this string value)
   {
      return value.Color(UnityEngine.Color.green);
   }

   public static string Blue(this string value)
   {
      return value.Color(UnityEngine.Color.blue);
   }
   #endregion

   #region To X conversions
   /// <summary>
   /// Parses a string into an Enum
   /// </summary>
   /// <typeparam name="T">The type of the Enum</typeparam>
   /// <param name="value">String value to parse</param>
   /// <returns>The Enum corresponding to the stringExtensions</returns>
   public static T ToEnum<T>(this string value)
   {
      return ToEnum<T>(value, false);
   }

   /// <summary>
   /// Parses a string into an Enum
   /// </summary>
   /// <typeparam name="T">The type of the Enum</typeparam>
   /// <param name="value">String value to parse</param>
   /// <param name="ignorecase">Ignore the case of the string being parsed</param>
   /// <returns>The Enum corresponding to the stringExtensions</returns>
   public static T ToEnum<T>(this string value, bool ignoreCase)
   {
      if (value == null)
      {
         throw new ArgumentNullException("Value");
      }

      value = value.Trim();

      if (value.Length == 0)
      {
         throw new ArgumentNullException("Must specify valid information for parsing in the string.", "value");
      }

      Type t = typeof(T);
      if (!t.IsEnum)
      {
         throw new ArgumentException("Type provided must be an Enum.", "T");
      }

      return (T)Enum.Parse(t, value, ignoreCase);
   }

   /// <summary>
   /// Converts a string value to bool value, supports "T" and "F" conversions.
   /// </summary>
   /// <param name="value">The string value.</param>
   /// <returns>A bool based on the string value</returns>
   public static bool? ToBoolean(this string value)
   {
   if (string.Compare("T",value,true) == 0)
   {
   return true;
   }
   if (string.Compare("F", value, true) == 0)
   {
   return false;
   }
   bool result;
   if (bool.TryParse(value, out result))
   {
   return result;
   }
   else return null;
   }
   #endregion

   #region ValueOrDefault
   public static string GetValueOrEmpty(this string value)
   {
      return GetValueOrDefault(value, string.Empty);
   }

   public static string GetValueOrDefault(this string value, string defaultvalue)
   {
      if (value != null) return value;
      {
         return defaultvalue;
      }
   }
   #endregion

   #region Email
   /// <summary>
   /// Send an email using the supplied string.
   /// </summary>
   /// <param name="body">String that will be used i the body of the email.</param>
   /// <param name="subject">Subject of the email.</param>
   /// <param name="sender">The email address from which the message was sent.</param>
   /// <param name="recipient">The receiver of the email.</param>
   /// <param name="server">The server from which the email will be sent.</param>
   /// <returns>A boolean value indicating the success of the email send.</returns>
//   public static bool Email(this string body, string subject, string sender, string recipient, string server)
//   {
//      System.Net.Mail.MailAddress senderAddress = new System.Net.Mail.MailAddress(sender);
//      System.Net.Mail.MailAddress recipientAddress = new System.Net.Mail.MailAddress(recipient);
//      System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(senderAddress.Address, recipientAddress.Address, subject, body);
//      System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(server);
//      client.Credentials = new System.Net.NetworkCredential();
//      try
//      {
//         client.Send(message);
//         UnityEngine.Debug.Log("Mail sent!".NewLine());
//      }
//      catch (Exception e)
//      {
//         UnityEngine.Debug.Log("Mail was not sent!".NewLine());
//         throw new Exception("Could not send mail from: " + sender + " to: " + recipient + " thru smtp server: " + server + "\n\n" + e.Message, e);
//      }
//      return true;
//   }
   #endregion
   
   #region Truncate
   /// <summary>
   /// Truncates the string to a specified length and replace the truncated to a ...
   /// </summary>
   /// <param name="maxLength">total length of characters to maintain before the truncate happens</param>
   /// <returns>truncated string</returns>
//   public static string Truncate(this string text, int maxLength)
//   {
//   // replaces the truncated string to a ...
//   const string suffix = "...";
//   string truncatedString = text;
//   if (maxLength <= 0) return truncatedString;
//   int strLength = maxLength - suffix.Length;
//   if (strLength <= 0) return truncatedString;
//   if (text == null || text.Length <= maxLength) return truncatedString;
//   truncatedString = text.Substring(0, strLength);
//   truncatedString = truncatedString.TrimEnd();
//   truncatedString += suffix;
//   return truncatedString;
//   }
   #endregion

   #region HTMLHelper

   /// <summary>
   /// Converts to a HTML-encoded string
   /// </summary>
   /// <param name="data">The data.</param>
   /// <returns></returns>
//   public static string HtmlEncode(this string data)
//   {
//      return System.Web.HttpUtility.HtmlEncode(data);
//   }

   /// <summary>
   /// Converts the HTML-encoded string into a decoded string
   /// </summary>
//   public static string HtmlDecode(this string data)
//   {
//      return System.Web.HttpUtility.HtmlDecode(data);
//   }

   /// <summary>
   /// Parses a query string into a System.Collections.Specialized.NameValueCollection
   /// using System.Text.Encoding.UTF8 encoding.
   /// </summary>
//   public static System.Collections.Specialized.NameValueCollection ParseQueryString(this string query)
//   {
//      return System.Web.HttpUtility.ParseQueryString(query);
//   }
   
   /// <summary>
   /// Encode an Url string
   /// </summary>
//   public static string UrlEncode(this string url)
//   {
//      return System.Web.HttpUtility.UrlEncode(url);
//   }
   
   /// <summary>
   /// Converts a string that has been encoded for transmission in a URL into a
   /// decoded string.
   /// </summary>
//   public static string UrlDecode(this string url)
//   {
//      return System.Web.HttpUtility.UrlDecode(url);
//   }
   
   /// <summary>
   /// Encodes the path portion of a URL string for reliable HTTP transmission from
   /// the Web server to a client.
   /// </summary>
//   public static string UrlPathEncode(this string url)
//   {
//      return System.Web.HttpUtility.UrlPathEncode(url);
//   }
   #endregion
   
   #region IsNullOrEmpty
   /// <summary>
   /// Determines whether [is not null or empty] [the specified input].
   /// </summary>
   /// <returns>
   ///  <c>true</c> if [is not null or empty] [the specified input]; otherwise, <c>false</c>.
   /// </returns>
   public static bool IsNotNullOrEmpty(this string input)
   {
      return !String.IsNullOrEmpty(input);
   }
   #endregion
   


   public static bool IsEmpty(this UnityEngine.Rect rect)
   {
      return ((((rect.height == 0) && (rect.width == 0)) && (rect.x == 0)) && (rect.y == 0));
   }


}
