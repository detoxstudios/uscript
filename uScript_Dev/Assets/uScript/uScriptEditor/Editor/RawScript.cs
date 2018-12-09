using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Detox.Drawing;
using System.IO;
using System.Reflection;

using Detox.Utility;
using Detox.Data;
using Detox.Data.ScriptEditor;

using UnityEngine;

namespace Detox.ScriptEditor
{
   public class RawScript
   {
      public Parameter []ExternalEventParameters  { get { return m_GeneratedCode.LogicEventArgs; } }
      public Parameter []ExternalParameters       { get { return m_GeneratedCode.ExternalParameters; } }
      public Plug      []ExternalInputs           { get { return m_GeneratedCode.ExternalInputs; } }
      public Plug      []ExternalOutputs          { get { return m_GeneratedCode.ExternalOutputs; } }
      public Plug      []ExternalEvents           { get { return m_GeneratedCode.ExternalEvents; } }
      public Driven    []Drivens                  { get { return m_GeneratedCode.Drivens; } }
      public string    []RequiredMethods          { get { return m_GeneratedCode.RequiredMethods; } }
      public string    EventArgs                  { get { return m_Type + "." + m_GeneratedCode.LogicEventArgsDeclaration(); } }
      public string    FriendlyName               { get { return m_FriendlyName; } }
      public string    Description                { get { return m_Description; } }
      public string    Type                       { get { return m_Type; } }

      private string m_Type = "";
      private string m_Description  = "";
      private string m_FriendlyName = "";

      private UnityCSharpGenerator m_GeneratedCode;

      public bool Load( string path )
      {
          Profile p = new Profile( "Raw Script: " + path );

         ScriptEditor scriptEditor = new ScriptEditor( "", null, null );
         if ( false == scriptEditor.Open(path) ) return false;

         m_GeneratedCode = new UnityCSharpGenerator( );
         
         m_FriendlyName = scriptEditor.FriendlyName.Default;
         m_Description  = scriptEditor.Description.Default;

         m_Type = Path.GetFileNameWithoutExtension(path) + uScriptConfig.Files.GeneratedCodeExtension;

         if ( 0 != scriptEditor.Externals.Length )
         {
            m_GeneratedCode.ParseExternals( scriptEditor );
         }

          p.End();

         return true;
      }
   }
}
