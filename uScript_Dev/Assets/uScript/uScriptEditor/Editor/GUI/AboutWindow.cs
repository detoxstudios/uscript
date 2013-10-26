// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the AboutWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using UnityEditor;

   using UnityEngine;

   using Application = UnityEngine.Application;
   using GUI = UnityEngine.GUI;

   public class AboutWindow : EditorWindow
   {
      private const int WindowWidth = 320;
      private const int WindowHeight = 260;

      private static AboutWindow window;

      private bool isFirstRun;
      private bool isWindows;

      // Create the window
      public static void Init()
      {
         // Get existing open window or if none, make a new one:
         window = EditorWindow.GetWindow<AboutWindow>(true, "uScript Quick Command Reference", true) as AboutWindow;
         window.isFirstRun = true;   // unnecessary, but we'll get a warning that 'window' is unused, otherwise
      }

      public void OnGUI()
      {
         if (this.isFirstRun)
         {
            this.isFirstRun = false;

            this.isWindows = Application.platform == RuntimePlatform.WindowsEditor;

            // Set the min and max window dimensions to prevent resizing
            this.minSize = new Vector2(WindowWidth, WindowHeight);
            this.maxSize = this.minSize;

            // Force the window to a position relative to the uScript window
            //         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, WINDOW_WIDTH, WINDOW_HEIGHT);

            if (this.isWindows)
            {
               window.Focus();
            }
         }

         if (Event.current.type != EventType.Repaint)
         {
            this.Repaint();
         }

         // Apply an content offset, because for some reason,
         // there is a 10-pixel gap between the window bar and the first row.
         GUILayout.Space(-10);

         EditorGUILayout.BeginVertical();
         {
            GUILayout.Label(Content.Header, Style.Header);

            GUILayout.Space(16);

            EditorGUILayout.BeginVertical();
            {
               GUILayout.Label("uScript " + uScript.ProductName, Style.ProductName);
               GUILayout.Label("Version " + uScript.BuildNumber, Style.ProductVersion);
               GUILayout.Label("\n" + uScript.Copyright + "\nAll rights reserved.\n", Style.ProductCopyright);

               if (GUILayout.Button("www.detoxstudios.com", Style.WebsiteLink))
               {
                  Application.OpenURL("http://detoxstudios.com/");
               }
            }

            EditorGUILayout.EndVertical();
         }

         EditorGUILayout.EndVertical();
      }

      private static class Content
      {
         static Content()
         {
            Header = new GUIContent(uScriptGUI.GetTexture("AboutLogo"));
         }

         public static GUIContent Header { get; private set; }
      }

      private static class Style
      {
         static Style()
         {
            Header = new GUIStyle { padding = new RectOffset(0, 32, 0, 0), stretchWidth = false };

            ProductCopyright = new GUIStyle(EditorStyles.label) { alignment = TextAnchor.UpperCenter };
            ProductName = new GUIStyle(EditorStyles.boldLabel) { alignment = TextAnchor.UpperCenter };
            ProductVersion = new GUIStyle(EditorStyles.label) { alignment = TextAnchor.UpperCenter };

            WebsiteLink = new GUIStyle(GUI.skin.button) { alignment = TextAnchor.UpperCenter };
            WebsiteLink.hover.background = WebsiteLink.normal.background;
            WebsiteLink.hover.textColor = WebsiteLink.normal.textColor;
            WebsiteLink.normal.background = uScriptGUI.GetTexture("Transparent");
            WebsiteLink.margin = new RectOffset(80, 80, 3, 3);
         }

         public static GUIStyle Header { get; private set; }

         public static GUIStyle ProductCopyright { get; private set; }

         public static GUIStyle ProductName { get; private set; }

         public static GUIStyle ProductVersion { get; private set; }

         public static GUIStyle WebsiteLink { get; private set; }
      }
   }
}
