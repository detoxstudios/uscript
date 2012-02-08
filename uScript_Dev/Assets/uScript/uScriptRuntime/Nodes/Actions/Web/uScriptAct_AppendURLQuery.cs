// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Web/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Add a simple field/value pair to the URL query.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#WebAppendURLQuery")]

[FriendlyName("Append URL Query", "Add a simple field/value pair to the URL query.")]
public class uScriptAct_AppendURLQuery : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("URL", "The original URL string.")]
      string URL,

      [FriendlyName("Field Name", "The field name.")]
      string Field,

      [FriendlyName("Value", "The field value. Non-string objects will be convertd to a string using ToString().")]
      object Value,

      [FriendlyName("Escape Value", "If True, the value string will be escaped before it is appended to the URL.")]
      [DefaultValue(true), SocketState(false, false)]
      bool EscapeValue,

      [FriendlyName("Semicolon Separator", "If True, the semicolon character, ';' will be used as the pair separator instead of the ampersand, '&'.  W3C recommends that all web servers support semicolon separators in the place of ampersand separators, but many servers do not.")]
      [SocketState(false, false)]
      bool UseSemicolon,

      [FriendlyName("Result", "The resulting URL after the field has been appended.")]
      out string Result
      )
   {
      // A typical URL containing a query string is as follows:
      //
      //    http://server/path/program?query_string
      //
      // When a server receives a request for such a page, it runs a program
      // (if configured to do so), passing the query_string unchanged to the
      // program. The question mark is used as a separator and is not part of
      // the query string.
      //
      // A link in a web page may have a URL that contains a query string.
      // However, the main use of query strings is to contain the content of
      // an HTML form, also known as web form. In particular, when a form
      // containing the fields field1, field2, field3 is submitted, the content
      // of the fields is encoded as a query string as follows:
      //
      //    field1=value1&field2=value2&field3=value3...
      //
      //    * The query string is composed of a series of field-value pairs.
      //
      //    * The field-value pairs are each separated by an equals sign. The
      //      equals sign may be omitted if the value is an empty string.
      //
      //    * The series of pairs is separated by the ampersand, '&' or
      //      semicolon, ';'.
      //
      // Multiple values can also be associated with a single field:
      //
      //    field1=value1&field1=value2&field1=value3...
      //
      // For each field of the form, the query string contains a pair
      // field=value. Web forms may include fields that are not visible to the
      // user; these fields are included in the query string when the form is
      // submitted
      //
      // This convention is a W3C recommendation. W3C recommends that all web
      // servers support semicolon separators in the place of ampersand
      // separators.
      //

      if (URL == null)
      {
         URL = string.Empty;
      }

      // Does the URL already contain a query separator?
      if (URL.Contains("?") == false)
      {
         URL += "?";
      }

      // Does the URL already contain a query?
      if (URL.EndsWith("?") == false)
      {
         // It must, so append the series separator
         URL += (UseSemicolon ? ";" : "&");
      }

      // Does the value need to be escaped?
      string value = (EscapeValue ? WWW.EscapeURL(Value.ToString()) : Value.ToString());

      // Should both the entire field/value pair be appended?
      URL += (value == string.Empty ? Field : Field + "=" + value);

      Result = URL;
   }
}
