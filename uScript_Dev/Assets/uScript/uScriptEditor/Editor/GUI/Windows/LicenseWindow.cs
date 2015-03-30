#if !RELEASE
#define UNITY_STORE_PRO
#endif
//#define CLOSED_BETA

#if !(UNITY_STORE_PRO || UNITY_STORE_BASIC)

using UnityEditor;
using UnityEngine;

public class LicenseWindow : EditorWindow
{
   //
   // Common Window variables
   //
   static LicenseWindow window = null;

   static public bool isOpen = false;
   static public bool shouldOpen = false;

   bool _firstRun = true;
   bool _saveOnClose = false;


   //
   // Class-specific variables
   //
   GUIContent _contentAgreeToggle = null;
   GUIContent _contentAcceptButton = null;
   GUIContent _contentDeclineButton = null;

   GUIStyle _styleWindow = null;
   GUIStyle _styleContainer = null;
   GUIStyle _styleButton = null;

   Vector2 _scrollviewOffset = Vector2.zero;
   bool _hasAgreed = false;

   static int _licenseVersion { get { return 20111008; } }
   static int _licenseVersionAccepted = -1;

#pragma warning disable 414
   string _licenseText = @"IMPORTANT, PLEASE READ CAREFULLY. THIS IS A LICENSE AGREEMENT!

USCRIPT PROFESSIONAL - EULA

This SOFTWARE PRODUCT is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. This SOFTWARE PRODUCT is licensed, not sold.

End User License Agreement

This End User License Agreement (""EULA"") is a legal agreement between you (either an individual or a single entity) and Detox Studios LLC with regard to the copyrighted Software (herein referred to as ""SOFTWARE PRODUCT"" or ""SOFTWARE"") provided with this EULA. The SOFTWARE PRODUCT includes computer software, the associated media, any printed materials, and any ""online"" or electronic documentation. Use of any software and related documentation provided to you by Detox Studios LLC in whatever form or media, will constitute your acceptance of these terms, unless separate terms are provided by the software supplier, in which case certain additional or different terms may apply. If you do not agree with the terms of this EULA do not use the Software and uninstall it. By continuing past this EULA, and/or using the SOFTWARE PRODUCT, you agree to be bound by the terms of this EULA.  If you do not agree to the terms of this EULA, Detox Studios LLC is unwilling to license the SOFTWARE PRODUCT to you.

1.  Eligible Licensees. This Software is available for license solely to SOFTWARE owners, with no right of duplication or further distribution, licensing, or sub-licensing.  IF YOU DO NOT OWN THE SOFTWARE, THEN DO NOT DOWNLOAD, INSTALL, COPY OR USE THE SOFTWARE.
 
2.  License Grant.  Detox Studios LLC grants to you a personal, non-transferable and non-exclusive right to use the Software provided with this EULA. You agree you will not copy the Software except as necessary for your single and individual use. You may install the Software on as many computers as you wish for your single and individual use. Modifying, translating, renting, copying, transferring or assigning all or part of the Software, or any rights granted hereunder, to any other persons and removing any proprietary notices, labels or marks from the Software is strictly prohibited.  Furthermore, you hereby agree not to create derivative works based on the Software.  You may not transfer this Software.

3.  Copyright.  The Software is licensed, not sold.  You acknowledge that no title to the intellectual property in the Software is transferred to you. You further acknowledge that title and full ownership rights to the Software will remain the exclusive property of Detox Studios LLC and/or its suppliers, and you will not acquire any rights to the Software, except as expressly set forth above. All copies of the Software will contain the same proprietary notices as contained in or on the Software. All title and copyrights in and to the SOFTWARE PRODUCT (including but not limited to any images, photographs, animations, video, audio, music, text and ""applets,"" incorporated into the SOFTWARE PRODUCT), the accompanying printed materials, and any copies of the SOFTWARE PRODUCT, are owned by Detox Studios LLC or its suppliers.  The SOFTWARE PRODUCT is protected by copyright laws and international treaty provisions.

4.  Reverse Engineering.  You agree that you will not attempt, and if you are a corporation, you will use your best efforts to prevent your employees and contractors from attempting to reverse compile, modify, translate or disassemble the Software in whole or in part. Any failure to comply with the above or any other terms and conditions contained herein will result in the automatic termination of this license and the reversion of the rights granted hereunder to Detox Studios LLC.

5.  Disclaimer of Warranty. The Software is provided ""AS IS"" without warranty of any kind. Detox Studios LLC and its suppliers disclaim and make no express or implied warranties and specifically disclaim the warranties of merchantability, fitness for a particular purpose and non-infringement of third-party rights. The entire risk as to the quality and performance of the Software is with you. Neither Detox Studios LLC nor its suppliers warrant that the functions contained in the Software will meet your requirements or that the operation of the Software will be uninterrupted or error-free. You acknowledge that Detox Studios LLC may update, modify or cancel some or all of the functionality of the Software at any time, without prior notice. Detox Studios LLC IS NOT OBLIGATED TO PROVIDE ANY UPDATES TO THE SOFTWARE.

6.  Copyright.  The Software is licensed, not sold.  You acknowledge that no title to the intellectual property in the Software is transferred to you. You further acknowledge that title and full ownership rights to the Software will remain the exclusive property of Detox Studios LLC and/or its suppliers, and you will not acquire any rights to the Software, except as expressly set forth above. All copies of the Software will contain the same proprietary notices as contained in or on the Software. All title and copyrights in and to the SOFTWARE PRODUCT (including but not limited to any images, photographs, animations, video, audio, music, text and ""applets,"" incorporated into the SOFTWARE PRODUCT), the accompanying printed materials, and any copies of the SOFTWARE PRODUCT, are owned by Detox Studios LLC or its suppliers.  The SOFTWARE PRODUCT is protected by copyright laws and international treaty provisions.  You may not copy the printed materials accompanying the SOFTWARE PRODUCT.

7.  Rental.  You may not loan, rent, or lease the SOFTWARE.  

8.  Upgrades.  If the SOFTWARE is an upgrade from an earlier release or previously released version, you now may use that upgraded product only in accordance with this EULA.  If the SOFTWARE PRODUCT is an upgrade of a software program which you licensed as a single product, the SOFTWARE PRODUCT may be used only as part of that single product package and may not be separated for use by anyone other than the individual user who has been granted the license.

9.  OEM Product Support. Product support for the SOFTWARE PRODUCT is provided by Detox Studios LLC through an online website and documentation.  For product support, please visit http://uscript.net.  Should you have any questions concerning this, please refer to the email address provided in the documentation.

10. No Liability for Consequential Damages.  In no event shall Detox Studios LLC or its suppliers be liable for any damages whatsoever (including, without limitation, incidental, direct, indirect special and consequential damages, damages for loss of business profits, business interruption, loss of business information, loss from the need to modify files generated by the Software, or other pecuniary loss) arising out of the use or inability to use this SOFTWARE PRODUCT, even if Detox Studios LLC has been advised of the possibility of such damages.  Because some states/countries do not allow the exclusion or limitation of liability for consequential or incidental damages, the above limitation may not apply to you.

11. Indemnification By You.  If you distribute the Software in violation of this Agreement, you agree to indemnify, hold harmless and defend Detox Studios LLC and its suppliers from and against any claims or lawsuits, including attorney's fees that arise or result from the use or distribution of the Software in violation of this Agreement.

12. Termination of Use. Without prejudice to any other rights, Detox Studios LLC may terminate this EULA if you fail to comply with the terms and conditions of this EULA. In such event, you must destroy all copies of the Software and all of its component parts. The above assurance and commitment as well as all warranties, representations, indemnity clauses and restrictions contained in this EULA, shall survive termination of this EULA.

Should you have any questions concerning this EULA, or if you desire to contact Detox Studios LLC for any reason, please visit us on the World Wide Web at www.detoxstudios.com

(rev. 10/08/2011)";


   string _licenseTextPLE = @"IMPORTANT, PLEASE READ CAREFULLY. THIS IS A LICENSE AGREEMENT!

USCRIPT PLE (PERSONAL LEARNING EDITION) - EULA

This SOFTWARE PRODUCT is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. This SOFTWARE PRODUCT is licensed, not sold.  This SOFTWARE PRODUCT is for evaluation and personal learning only and may not be used in any way to develop, or contribute to the development of, commercial products.

End User License Agreement

This End User License Agreement (""EULA"") is a legal agreement between you (either an individual or a single entity) and Detox Studios LLC with regard to the copyrighted Software (herein referred to as ""SOFTWARE PRODUCT"" or ""SOFTWARE"") provided with this EULA. The SOFTWARE PRODUCT includes computer software, the associated media, any printed materials, and any ""online"" or electronic documentation. Use of any software and related documentation provided to you by Detox Studios LLC in whatever form or media, will constitute your acceptance of these terms, unless separate terms are provided by the software supplier, in which case certain additional or different terms may apply. If you do not agree with the terms of this EULA do not use the Software and uninstall it. By continuing past this EULA, and/or using the SOFTWARE PRODUCT, you agree to be bound by the terms of this EULA.  If you do not agree to the terms of this EULA, Detox Studios LLC is unwilling to license the SOFTWARE PRODUCT to you.

1.  Eligible Licensees. This Software is available for license solely to SOFTWARE owners, with no right of duplication or further distribution, licensing, or sub-licensing.  IF YOU DO NOT OWN THE SOFTWARE, THEN DO NOT DOWNLOAD, INSTALL, COPY OR USE THE SOFTWARE.
 
2.  License Grant.  Detox Studios LLC grants to you a personal, non-transferable and non-exclusive right to use the Software provided with this EULA. You agree you will not copy the Software except as necessary for your single and individual use. You may install the Software on as many computers as you wish for your single and individual use. Modifying, translating, renting, copying, transferring or assigning all or part of the Software, or any rights granted hereunder, to any other persons and removing any proprietary notices, labels or marks from the Software is strictly prohibited.  Furthermore, you hereby agree not to create derivative works based on the Software.  You may not transfer this Software.  You may not use this software, directly or indirectly, to generate commercial products, or receive compensation of any kind for any product in which the SOFTWARE was used in its development.

3.  Copyright.  The Software is licensed, not sold.  You acknowledge that no title to the intellectual property in the Software is transferred to you. You further acknowledge that title and full ownership rights to the Software will remain the exclusive property of Detox Studios LLC and/or its suppliers, and you will not acquire any rights to the Software, except as expressly set forth above. All copies of the Software will contain the same proprietary notices as contained in or on the Software. All title and copyrights in and to the SOFTWARE PRODUCT (including but not limited to any images, photographs, animations, video, audio, music, text and ""applets,"" incorporated into the SOFTWARE PRODUCT), the accompanying printed materials, and any copies of the SOFTWARE PRODUCT, are owned by Detox Studios LLC or its suppliers.  The SOFTWARE PRODUCT is protected by copyright laws and international treaty provisions.

4.  Reverse Engineering.  You agree that you will not attempt, and if you are a corporation, you will use your best efforts to prevent your employees and contractors from attempting to reverse compile, modify, translate or disassemble the Software in whole or in part. Any failure to comply with the above or any other terms and conditions contained herein will result in the automatic termination of this license and the reversion of the rights granted hereunder to Detox Studios LLC.

5.  Disclaimer of Warranty. The Software is provided ""AS IS"" without warranty of any kind. Detox Studios LLC and its suppliers disclaim and make no express or implied warranties and specifically disclaim the warranties of merchantability, fitness for a particular purpose and non-infringement of third-party rights. The entire risk as to the quality and performance of the Software is with you. Neither Detox Studios LLC nor its suppliers warrant that the functions contained in the Software will meet your requirements or that the operation of the Software will be uninterrupted or error-free. You acknowledge that Detox Studios LLC may update, modify or cancel some or all of the functionality of the Software at any time, without prior notice. Detox Studios LLC IS NOT OBLIGATED TO PROVIDE ANY UPDATES TO THE SOFTWARE.

6.  Copyright.  The Software is licensed, not sold.  You acknowledge that no title to the intellectual property in the Software is transferred to you. You further acknowledge that title and full ownership rights to the Software will remain the exclusive property of Detox Studios LLC and/or its suppliers, and you will not acquire any rights to the Software, except as expressly set forth above. All copies of the Software will contain the same proprietary notices as contained in or on the Software. All title and copyrights in and to the SOFTWARE PRODUCT (including but not limited to any images, photographs, animations, video, audio, music, text and ""applets,"" incorporated into the SOFTWARE PRODUCT), the accompanying printed materials, and any copies of the SOFTWARE PRODUCT, are owned by Detox Studios LLC or its suppliers.  The SOFTWARE PRODUCT is protected by copyright laws and international treaty provisions.  You may not copy the printed materials accompanying the SOFTWARE PRODUCT.

7.  Rental.  You may not loan, rent, or lease the SOFTWARE.  

8.  Upgrades.  If the SOFTWARE is an upgrade from an earlier release or previously released version, you now may use that upgraded product only in accordance with this EULA.  If the SOFTWARE PRODUCT is an upgrade of a software program which you licensed as a single product, the SOFTWARE PRODUCT may be used only as part of that single product package and may not be separated for use by anyone other than the individual user who has been granted the license.

9.  OEM Product Support. Product support for the SOFTWARE PRODUCT is provided by Detox Studios LLC through an online website and documentation.  For product support, please visit http://uscript.net.  Should you have any questions concerning this, please refer to the email address provided in the documentation.

10. No Liability for Consequential Damages.  In no event shall Detox Studios LLC or its suppliers be liable for any damages whatsoever (including, without limitation, incidental, direct, indirect special and consequential damages, damages for loss of business profits, business interruption, loss of business information, loss from the need to modify files generated by the Software, or other pecuniary loss) arising out of the use or inability to use this SOFTWARE PRODUCT, even if Detox Studios LLC has been advised of the possibility of such damages.  Because some states/countries do not allow the exclusion or limitation of liability for consequential or incidental damages, the above limitation may not apply to you.

11. Indemnification By You.  If you distribute the Software in violation of this Agreement, you agree to indemnify, hold harmless and defend Detox Studios LLC and its suppliers from and against any claims or lawsuits, including attorney's fees that arise or result from the use or distribution of the Software in violation of this Agreement.

12. Termination of Use. Without prejudice to any other rights, Detox Studios LLC may terminate this EULA if you fail to comply with the terms and conditions of this EULA. In such event, you must destroy all copies of the Software and all of its component parts. The above assurance and commitment as well as all warranties, representations, indemnity clauses and restrictions contained in this EULA, shall survive termination of this EULA.

Should you have any questions concerning this EULA, or if you desire to contact Detox Studios LLC for any reason, please visit us on the World Wide Web at www.detoxstudios.com

(rev. 10/08/2011)";


   string _licenseTextBasic = @"IMPORTANT, PLEASE READ CAREFULLY. THIS IS A LICENSE AGREEMENT!

USCRIPT BASIC - EULA

This SOFTWARE PRODUCT is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. This SOFTWARE PRODUCT is licensed, not sold.

End User License Agreement

This End User License Agreement (""EULA"") is a legal agreement between you (either an individual or a single entity) and Detox Studios LLC with regard to the copyrighted Software (herein referred to as ""SOFTWARE PRODUCT"" or ""SOFTWARE"") provided with this EULA. The SOFTWARE PRODUCT includes computer software, the associated media, any printed materials, and any ""online"" or electronic documentation. Use of any software and related documentation provided to you by Detox Studios LLC in whatever form or media, will constitute your acceptance of these terms, unless separate terms are provided by the software supplier, in which case certain additional or different terms may apply. If you do not agree with the terms of this EULA do not use the Software and uninstall it. By continuing past this EULA, and/or using the SOFTWARE PRODUCT, you agree to be bound by the terms of this EULA.  If you do not agree to the terms of this EULA, Detox Studios LLC is unwilling to license the SOFTWARE PRODUCT to you.

1.  Eligible Licensees. This Software is available for license solely to SOFTWARE owners, with no right of duplication or further distribution, licensing, or sub-licensing.  IF YOU DO NOT OWN THE SOFTWARE, THEN DO NOT DOWNLOAD, INSTALL, COPY OR USE THE SOFTWARE.
 
2.  License Grant.  Detox Studios LLC grants to you a personal, non-transferable and non-exclusive right to use the Software provided with this EULA. You agree you will not copy the Software except as necessary for your single and individual use. You may install the Software on as many computers as you wish for your single and individual use. Modifying, translating, renting, copying, transferring or assigning all or part of the Software, or any rights granted hereunder, to any other persons and removing any proprietary notices, labels or marks from the Software is strictly prohibited.  Furthermore, you hereby agree not to create derivative works based on the Software.  You may not transfer this Software.

3.  Copyright.  The Software is licensed, not sold.  You acknowledge that no title to the intellectual property in the Software is transferred to you. You further acknowledge that title and full ownership rights to the Software will remain the exclusive property of Detox Studios LLC and/or its suppliers, and you will not acquire any rights to the Software, except as expressly set forth above. All copies of the Software will contain the same proprietary notices as contained in or on the Software. All title and copyrights in and to the SOFTWARE PRODUCT (including but not limited to any images, photographs, animations, video, audio, music, text and ""applets,"" incorporated into the SOFTWARE PRODUCT), the accompanying printed materials, and any copies of the SOFTWARE PRODUCT, are owned by Detox Studios LLC or its suppliers.  The SOFTWARE PRODUCT is protected by copyright laws and international treaty provisions.

4.  Reverse Engineering.  You agree that you will not attempt, and if you are a corporation, you will use your best efforts to prevent your employees and contractors from attempting to reverse compile, modify, translate or disassemble the Software in whole or in part. Any failure to comply with the above or any other terms and conditions contained herein will result in the automatic termination of this license and the reversion of the rights granted hereunder to Detox Studios LLC.

5.  Disclaimer of Warranty. The Software is provided ""AS IS"" without warranty of any kind. Detox Studios LLC and its suppliers disclaim and make no express or implied warranties and specifically disclaim the warranties of merchantability, fitness for a particular purpose and non-infringement of third-party rights. The entire risk as to the quality and performance of the Software is with you. Neither Detox Studios LLC nor its suppliers warrant that the functions contained in the Software will meet your requirements or that the operation of the Software will be uninterrupted or error-free. You acknowledge that Detox Studios LLC may update, modify or cancel some or all of the functionality of the Software at any time, without prior notice. Detox Studios LLC IS NOT OBLIGATED TO PROVIDE ANY UPDATES TO THE SOFTWARE.

6.  Copyright.  The Software is licensed, not sold.  You acknowledge that no title to the intellectual property in the Software is transferred to you. You further acknowledge that title and full ownership rights to the Software will remain the exclusive property of Detox Studios LLC and/or its suppliers, and you will not acquire any rights to the Software, except as expressly set forth above. All copies of the Software will contain the same proprietary notices as contained in or on the Software. All title and copyrights in and to the SOFTWARE PRODUCT (including but not limited to any images, photographs, animations, video, audio, music, text and ""applets,"" incorporated into the SOFTWARE PRODUCT), the accompanying printed materials, and any copies of the SOFTWARE PRODUCT, are owned by Detox Studios LLC or its suppliers.  The SOFTWARE PRODUCT is protected by copyright laws and international treaty provisions.  You may not copy the printed materials accompanying the SOFTWARE PRODUCT.

7.  Rental.  You may not loan, rent, or lease the SOFTWARE.  

8.  Upgrades.  If the SOFTWARE is an upgrade from an earlier release or previously released version, you now may use that upgraded product only in accordance with this EULA.  If the SOFTWARE PRODUCT is an upgrade of a software program which you licensed as a single product, the SOFTWARE PRODUCT may be used only as part of that single product package and may not be separated for use by anyone other than the individual user who has been granted the license.

9.  OEM Product Support. Product support for the SOFTWARE PRODUCT is provided by Detox Studios LLC through an online website and documentation.  For product support, please visit http://uscript.net.  Should you have any questions concerning this, please refer to the email address provided in the documentation.

10. No Liability for Consequential Damages.  In no event shall Detox Studios LLC or its suppliers be liable for any damages whatsoever (including, without limitation, incidental, direct, indirect special and consequential damages, damages for loss of business profits, business interruption, loss of business information, loss from the need to modify files generated by the Software, or other pecuniary loss) arising out of the use or inability to use this SOFTWARE PRODUCT, even if Detox Studios LLC has been advised of the possibility of such damages.  Because some states/countries do not allow the exclusion or limitation of liability for consequential or incidental damages, the above limitation may not apply to you.

11. Indemnification By You.  If you distribute the Software in violation of this Agreement, you agree to indemnify, hold harmless and defend Detox Studios LLC and its suppliers from and against any claims or lawsuits, including attorney's fees that arise or result from the use or distribution of the Software in violation of this Agreement.

12. Termination of Use. Without prejudice to any other rights, Detox Studios LLC may terminate this EULA if you fail to comply with the terms and conditions of this EULA. In such event, you must destroy all copies of the Software and all of its component parts. The above assurance and commitment as well as all warranties, representations, indemnity clauses and restrictions contained in this EULA, shall survive termination of this EULA.

Should you have any questions concerning this EULA, or if you desire to contact Detox Studios LLC for any reason, please visit us on the World Wide Web at www.detoxstudios.com

(rev. 10/08/2011)";

#pragma warning restore 414



   // Create the window
   public static void Init()
   {
      // Get existing open window or if none, make a new one:
      window = EditorWindow.GetWindow<LicenseWindow>(true, "uScript End User License Agreement", true) as LicenseWindow;
      window._firstRun = true;   // unnecessary, but we'll get a warning that 'window' is unused, otherwise
   }


   void Update()
   {
      // In WindowsEditor, the Utility Window is not always on top, so force it
      if (Application.platform == RuntimePlatform.WindowsEditor
          && isOpen
             && (focusedWindow == null
                 || focusedWindow.GetType() != typeof(LicenseWindow)))
      {
         EditorWindow.FocusWindowIfItsOpen<LicenseWindow>();
      }
   }


   void OnEnable()
   {
      isOpen = true;
   }


   void OnDisable()
   {
      isOpen = false;

      if (_saveOnClose && _hasAgreed)
      {
         // Save the license acceptance
         _licenseVersionAccepted = _licenseVersion;
         uScript.SetSetting("EULA\\AgreedVersion", _licenseVersionAccepted);
         uScript.Preferences.Save();
      }
      else
      {
         // User has declined, so close the uScript Editor
         uScript.Instance.Close();
      }
   }


   void OnGUI()
   {
      if (_firstRun)
      {
         _firstRun = false;

         uScriptGUIStyle.Init();

         // Force the window to a position relative to the uScript window
         base.position = new Rect(uScript.Instance.position.x + 50, uScript.Instance.position.y + 50, 0, 0);

         // Set the min and max window dimensions to prevent resizing
         base.minSize = new Vector2(600, 400);
         base.maxSize = base.minSize;

         // prepare the content for the window
         _contentAgreeToggle = new GUIContent("  I agree to the terms of this license.");
         _contentAcceptButton = new GUIContent("Accept");
         _contentDeclineButton = new GUIContent("Close uScript");

         // Setup the custom GUIStyles used to layout the window
         _styleWindow = new GUIStyle();
         _styleWindow.margin = new RectOffset(16, 16, 8, 16);

         _styleContainer = new GUIStyle(GUI.skin.box);
         _styleContainer.padding = new RectOffset(1, 1, 1, 1);

         _styleButton = new GUIStyle(GUI.skin.button);
         _styleButton.fixedWidth = 100;
      }


      //
      // Window contents
      //
      EditorGUILayout.BeginVertical(_styleWindow);
      {
         //
         // Project Settings
         //

         EditorGUILayout.BeginHorizontal(_styleContainer);
         {
            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, true, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, GUI.skin.scrollView);
            {
               // prevent the help TextArea from getting focus
               GUI.SetNextControlName("EULA");

#if DETOX_STORE_PRO
               GUILayout.TextArea(_licenseText, uScriptGUIStyle.ReferenceText);
#elif CLOSED_BETA
               GUILayout.TextArea(_licenseText, uScriptGUIStyle.ReferenceText);
#elif DETOX_STORE_PLE
               GUILayout.TextArea(_licenseTextPLE, uScriptGUIStyle.ReferenceText);
#elif DETOX_STORE_BASIC
               GUILayout.TextArea(_licenseTextBasic, uScriptGUIStyle.ReferenceText);
#endif
               if (GUI.GetNameOfFocusedControl() == "EULA")
               {
                  GUIUtility.keyboardControl = 0;
               }
            }
            EditorGUILayout.EndScrollView();
         }
         EditorGUILayout.EndHorizontal();


         EditorGUILayout.Separator();

         GUILayout.BeginHorizontal();
         {
            _hasAgreed = GUILayout.Toggle(_hasAgreed, _contentAgreeToggle);

            GUILayout.FlexibleSpace();

            GUI.enabled = _hasAgreed;
            if (GUILayout.Button(_contentAcceptButton, _styleButton))
            {
               _saveOnClose = true;
               this.Close();
            }
            GUI.enabled = true;

            GUILayout.Space(10);

            if (GUILayout.Button(_contentDeclineButton, _styleButton))
            {
               this.Close();
            }
         }
         GUILayout.EndHorizontal();
      }
      EditorGUILayout.EndVertical();
   }


   public static bool HasUserAcceptedLicense()
   {
      // Get the current accepted version and compare to the latest
      _licenseVersionAccepted = (int)uScript.GetSetting("EULA\\AgreedVersion", -1);
      return _licenseVersionAccepted == _licenseVersion;
   }


}
#endif

