// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios, LLC" file="uScriptAct_WebText.cs">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   uScript Action Node
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

[NodePath("Actions/Web/Download")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Download text data from the specified URL.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Web Text", "Download text data from the specified URL.")]
public class uScriptAct_WebText : uScriptLogic
{
   private bool finished;
   private WWW www;

   // ================================================================================
   //    Output Sockets
   // ================================================================================
   [FriendlyName("Out")]
   public bool Out { get; private set; }

   [FriendlyName("Success")]
   public bool OutFinished { get; private set; }

   [FriendlyName("Error")]
   public bool OutError { get; private set; }

   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   public void In(
      [FriendlyName("URL", "The URL to download")]
      string URL,
      [FriendlyName("Form Data", "A WWWForm instance containing the form data to post."), SocketState(false, false)]
      WWWForm Form,
      [FriendlyName("Result", "The downloaded data.")]
      out string Result,
      [FriendlyName("Error", "Returns an error message if there was an error during the download."), SocketState(false, false)]
      out string Error)
   {
      this.Out = true;
      this.OutFinished = false;
      this.OutError = false;

      this.finished = false;
      this.www = Form == null ? new WWW(URL) : new WWW(URL, Form);

      Result = string.Empty;
      Error = string.Empty;
   }

   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   [Driven]
   public bool Driven(out string result, out string error)
   {
      this.Out = false;

      result = string.Empty;
      error = string.Empty;

      if (this.finished)
      {
         return false;
      }

      if (this.www.isDone)
      {
         this.finished = true;

         if (this.www.error != null)
         {
            error = this.www.error;
            this.OutError = true;
         }
         else
         {
            result = this.www.text;
            this.OutFinished = true;
         }
      }

      return true;
   }
}
