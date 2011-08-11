using UnityEditor;
using UnityEngine;

public class WelcomeWindow : EditorWindow
{
   private class Item
   {
      public GUIContent Icon;
      public GUIContent Label;
      public GUIContent Text;
      public string URL;

      public Item(string icon, string label, string text, string url)
      {
         this.Icon = new GUIContent(UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/" + icon + ".png", typeof(UnityEngine.Texture)) as UnityEngine.Texture);
         this.Label = new GUIContent(label);
         this.Text = new GUIContent(text);
         this.URL = url;
      }
   }

   private class Content
   {
      public Item Header = new Item( "iconWelcomeLogo",
                                     "Welcome To uScript",
                                     "We've worked hard to get this into your hands, and we cannot wait to see the wonderful things you create with it!",
                                     string.Empty);

      public Item QuickStart = new Item( "iconWelcomeQuickstart",
                                         "Quick Start",
                                         "Do you want to jump right in?  Check out our Getting Started guide to get you up and running.",
                                         "http://www.uscript.net/docs/index.php?title=Getting_Started");

      public Item Documentation = new Item( "iconWelcomeDocumentation",
                                            "Documentation",
                                            "For more extensive information on uScript, including the Node Reference Guide, check out our online documentation.",
                                            "http://uscript.net/docs/");

      public Item Tutorials = new Item( "iconWelcomeVideoTutorials",
                                        "Video Tutorials",
                                        "We have a selection of video tutorials that cover many uScript topics from basic to advanced.",
                                        "http://www.uscript.net/docs/index.php?title=Tutorials");

      public Item Examples = new Item( "iconWelcomeExamples",
                                       "Example Projects",
                                       "Deconstruct our example projects to see exactly how they function.  Each project is well documented.",
                                       "http://www.uscript.net/docs/index.php?title=Example_Projects");

      public Item Community = new Item( "iconWelcomeCommunity",
                                        "Community",
                                        "The uScript community is growing daily. Visit the forum and join the conversation.",
                                        "http://www.uscript.net/forum/");

      public Item Feedback = new Item( "iconWelcomeFeedback",
                                       "Feedback",
                                       "Your feedback is important to us!  We setup a UserVoice account where you can vote on existing suggestions or add your own.",
                                       "http://uscript.uservoice.com/forums/125157-uscript-feedback");

      public GUIContent showAtStartupText = new GUIContent("Show at Startup");
   }

   private static Content content;




   const int _windowWidth = 560;

   GUIStyle _styleClear;
   GUIStyle _styleHeaderRow;
   GUIStyle _styleHeaderLabel;
   GUIStyle _styleItemRow;
   GUIStyle _styleItemLabel;

   bool _firstRun = true;
   Rect _position;

   Preferences _preferences = null;
   static WelcomeWindow window = null;




   // Create the window
   public static void Init()
   {
      // Get existing open window or if none, make a new one:
      window = EditorWindow.GetWindow<WelcomeWindow>(true, "Welcome To uScript", true) as WelcomeWindow;
      window._firstRun = true;   // unnecessary, but we'll get a warning that 'window' is unused, otherwise
   }


   void OnEnable()
   {
      if (content == null)
      {
         content = new Content();
      }
   }


   void OnDisable()
   {
   }


   void OnFocus()
   {
   }


   void OnLostFocus()
   {
   }


   public void OnGUI()
   {
      if (_firstRun)
      {
         _firstRun = false;

         // Force the window to a position relative to the uScript window
         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, 0, 0);

         // Setup the custom styles for this window
         _styleClear = new GUIStyle();
//         style.normal.background = GUI.skin.box.normal.background;
         _styleClear.border = GUI.skin.box.border;
         _styleClear.margin = new RectOffset();
         _styleClear.padding = new RectOffset();

         _styleHeaderRow = new GUIStyle(_styleClear);
         _styleHeaderRow.margin = new RectOffset(40, 40, 0, 16);

         _styleHeaderLabel = new GUIStyle(_styleClear);
         _styleHeaderLabel.normal.textColor = EditorStyles.boldLabel.normal.textColor;
         _styleHeaderLabel.fontStyle = FontStyle.Bold;
         _styleHeaderLabel.fontSize = 32;

         _styleItemRow = new GUIStyle(_styleClear);
         _styleItemRow.margin = new RectOffset(64, 64, 16, 16);

         _styleItemLabel = new GUIStyle(_styleClear);
         _styleItemLabel.normal.textColor = EditorStyles.boldLabel.active.textColor;
         _styleItemLabel.fontSize = EditorStyles.boldLabel.fontSize;
         _styleItemLabel.fontStyle = FontStyle.Bold;
         _styleItemLabel.margin = new RectOffset(4, 4, 0, 4);

         #if UNITY_EDITOR && UNITY_STANDALONE_WIN
         //Debug.Log("===== Editor in Windows");
         window.Focus();
         #endif
      }

      if (_position != new Rect())
      {
         // Set the min and max window dimensions to prevent resizing
         base.minSize = new Vector2(_position.width, _position.height + 16);
         base.maxSize = base.minSize;
      }


      // Get the Preferences
      _preferences = uScript.Preferences;

      GUILayout.BeginVertical(_styleClear, GUILayout.Width(_windowWidth));
      {
         GUILayout.BeginVertical();
         {
            this.ShowItem(content.Header);

            GUILayout.Space(16);

            this.ShowItem(content.QuickStart);
            this.ShowItem(content.Documentation);
            this.ShowItem(content.Tutorials);
            this.ShowItem(content.Examples);
            this.ShowItem(content.Community);
            this.ShowItem(content.Feedback);
         }
         GUILayout.EndVertical();

         GUILayout.Space(8);

         GUILayout.BeginHorizontal(GUILayout.Height(20));
         {
            GUILayout.FlexibleSpace();
            GUI.changed = false;
            _preferences.ShowAtStartup = GUILayout.Toggle(_preferences.ShowAtStartup, content.showAtStartupText);
            if (GUI.changed)
            {
               _preferences.Save();
            }
            GUILayout.Space(16);
         }
         GUILayout.EndHorizontal();
      }
      GUILayout.EndVertical();

      if (Event.current.type == EventType.Repaint)
      {
         _position = GUILayoutUtility.GetLastRect();
      }
   }


   private void ShowItem(Item item)
   {
      bool isHeader = string.IsNullOrEmpty(item.URL);

      GUILayout.BeginHorizontal(isHeader ? _styleHeaderRow : _styleItemRow);
      {
         GUILayout.BeginHorizontal(GUILayout.Width(item.Icon.image.width));
         {
            if (isHeader)
            {
               GUILayout.Label(item.Icon);
               GUILayout.Space(16);
            }
            else
            {
               if (GUILayout.Button(item.Icon, _styleClear, GUILayout.ExpandWidth(false)))
               {
                  this.ShowHelpPageOrBrowseURL(item.URL);
               }
               if (Event.current.type == EventType.Repaint)
               {
                  EditorGUIUtility.AddCursorRect(GUILayoutUtility.GetLastRect(), MouseCursor.Link);
               }
               GUILayout.Space(8);
            }
         }
         GUILayout.EndHorizontal();

         GUILayout.BeginVertical(GUILayout.ExpandWidth(true));
         {
            if (isHeader)
            {
               GUILayout.Label(item.Label, _styleHeaderLabel);
               GUILayout.Label(item.Text, "WordWrappedLabel");
            }
            else
            {
               if (GUILayout.Button(item.Label, _styleItemLabel, GUILayout.ExpandWidth(false)))
               {
                  this.ShowHelpPageOrBrowseURL(item.URL);
               }
               EditorGUIUtility.AddCursorRect(GUILayoutUtility.GetLastRect(), MouseCursor.Link);
               GUILayout.Label(item.Text, "WordWrappedLabel");
            }
         }
         GUILayout.EndVertical();
      }
      GUILayout.EndHorizontal();
   }

   private void ShowHelpPageOrBrowseURL(string url)
   {
      if (url.StartsWith("file"))
      {
         Help.ShowHelpPage(url);
      }
      else
      {
         Help.BrowseURL(url);
      }
   }
}
