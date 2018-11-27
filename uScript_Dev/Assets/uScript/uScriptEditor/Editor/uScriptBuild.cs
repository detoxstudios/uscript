// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios, LLC" file="uScriptBuild.cs">
//   Copyright 2010-2018 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Contains classes referenced by uScript generated code which needs to be included in a dll to be linked with users' games.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !RELEASE
#define UNITY_STORE_PRO
#endif

using System;

public static class uScriptBuild
{
   public static string Copyright { get { return "\u00A9 2010-2018 Detox Studios, LLC."; } }

   // Version Name and Version Data
   // Set version - format is MAJOR.MINOR.FOUR-DIGIT-BUILD-NUMBER
   public static string Number { get { return "1.0.3107"; } }
   private static string productNameAppendText = "";


#if DETOX_STORE_PLE || UNITY_STORE_PLE
   public static string Name { get { return "Personal Learning Edition" + productNameAppendText; } }
#elif DETOX_STORE_BASIC || UNITY_STORE_BASIC
   public static string Name { get { return "Basic Edition" + productNameAppendText; } }
#else
   public static string Name { get { return "Professional Edition" + productNameAppendText; } }
#endif



   //public string LastUnityBuild { get { return "3.3"; } }
   //public string CurrentUnityBuild { get { return "3.4"; } }
   //public string BetaUnityBuild { get { return "3.5"; } }
   //public DateTime ExpireDate { get { return new DateTime(2011, 11, 30); } }

   public enum EditionType { PLE, Basic, Pro }
   public enum SourceType { Detox, Unity }

#if UNITY_STORE_PRO
   public const EditionType Edition = EditionType.Pro;
   public const SourceType Source = SourceType.Unity;
#elif UNITY_STORE_BASIC
   public const EditionType Edition = EditionType.Basic;
   public const SourceType Source = SourceType.Unity;
#elif DETOX_STORE_PRO
   public const EditionType Edition = EditionType.Pro;
   public const SourceType Source = SourceType.Detox;
#elif DETOX_STORE_BASIC
   public const EditionType Edition = EditionType.Basic;
   public const SourceType Source = SourceType.Detox;
#else
   public const EditionType Edition = EditionType.PLE;
   public const SourceType Source = SourceType.Detox;
#endif
}