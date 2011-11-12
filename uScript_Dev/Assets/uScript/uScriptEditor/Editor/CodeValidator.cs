using System;
using System.Reflection;

using UnityEditor;

public class CodeValidator
{
   static private bool m_IsCompiling = false;
   static private bool m_UserOverrideErrors = false;
   
   static public bool RequireRebuild( bool forceCheck )
   {
      bool compiling = EditorApplication.isCompiling;

      bool check = forceCheck;

      if ( true == compiling ) 
      {
         m_IsCompiling = true;
      }
      else if ( true == m_IsCompiling )
      {
         m_IsCompiling = false;
         check = true;
      }

      bool requireRebuild = false;

      //it was compiling and now it's not or we're being forced to check
      if ( true == check )
      {
         if ( false == CanGeneratedScriptsCompile( ) )
         {
            bool yes = EditorUtility.DisplayDialog( "Rebuild Scripts?", "uScript has detected compile errors with your generated scripts.  " +
                                                    "Rebuilding all scripts usually fixes this, would you like to rebuild all?", "Yes", "No" );

            if ( true == yes )
            {
               requireRebuild = true;
            }
            else
            {
               //if they chose 'no' don't rebuild scripts
               //then we won't ask them again until the scripts can successfully compile
               //at which time we reset the override
               m_UserOverrideErrors = true;
            }
         }
      }

      return requireRebuild;
   }

   static private bool CanGeneratedScriptsCompile( )
   {
      //using undocumented methods so double check each return value and
      //leave gracefully if something is null (no longer supported)

		// get the Assembly
		Assembly asm = Assembly.GetAssembly(typeof(UnityEditorInternal.MonoScripts));
		if ( null == asm ) return true;

		Type type = asm.GetType("UnityEditorInternal.LogEntries");
		if ( null == type ) return true;

		// package the types by reference
		System.Type[] arrTypes = new System.Type[3];
		arrTypes.SetValue(Type.GetType("System.Int32&"), 0);
		arrTypes.SetValue(Type.GetType("System.Int32&"), 1);
		arrTypes.SetValue(Type.GetType("System.Int32&"), 2);
		
		MethodInfo m = type.GetMethod("GetCountsByType", arrTypes);
		if ( null == m ) return true;
		
		int numErrors = 0;
		int numWarnings = 0;
		int numMessages = 0;

      // package the parameters
		object[] arrParms = new object[3];
		arrParms.SetValue(numErrors, 0);
		arrParms.SetValue(numWarnings, 1);
		arrParms.SetValue(numMessages, 2);
		
		m.Invoke(null, arrParms);
		
		// update the reference parameters
		numErrors = (int)arrParms[0];
		numWarnings = (int)arrParms[1];
		numMessages = (int)arrParms[2];

      bool canCompile = true;

      if ( numErrors > 0 && false == m_UserOverrideErrors )
      {
         string generatedScripts = uScriptConfig.ConstantPaths.RelativePath(uScript.Preferences.GeneratedScripts);

         Type logEntryType = asm.GetType("UnityEditorInternal.LogEntry");
   		if ( null == logEntryType ) return true;

   		MethodInfo start = type.GetMethod("StartGettingEntries", new Type[]{} );
   		if ( null == start ) return true;

         start.Invoke(null, new object[]{} );


         MethodInfo getEntry = type.GetMethod("GetEntryInternal", new Type[]{typeof(int), logEntryType} );
   		if ( null == getEntry ) return true;
         
         //super long logs really slow this down
         //so just check the last 10 entries
         int i = (numWarnings + numMessages + numErrors) - 10;

         object logEntry = Activator.CreateInstance(logEntryType);
   		if ( null == logEntry ) return true;

         while ( true )
         {
            bool result = (bool) getEntry.Invoke(null, new object[]{i,logEntry} );
            if ( false == result ) break;

            FieldInfo field = logEntryType.GetField("condition");
   		   if ( null == field ) return true;

            string condition = field.GetValue( logEntry ) as string;

            if ( condition.Contains(generatedScripts) &&
                 condition.Contains("error CS") )
            {
               canCompile = false;
               break;
            }

            ++i;
         }

         MethodInfo end = type.GetMethod("EndGettingEntries", new Type[]{} );
 		   if ( null == end ) return true;

         end.Invoke(null, new object[]{} );
      }
      else if ( 0 == numErrors )
      {
         //reset user override when there are no compiler errors
         //so we can prompt them again next time we detect one
         m_UserOverrideErrors = false;
      }

      return canCompile;
   }
}

