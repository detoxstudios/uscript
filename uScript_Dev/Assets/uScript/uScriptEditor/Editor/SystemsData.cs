using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Detox.Data.Systems
{
   public class RegistryValue
   {
      public string Path;
      public object Value;
   }

   public class RegistryData : ISerializable
   {
      private Hashtable m_Hashtable = new Hashtable( );

      public RegistryValue [] RegistryValues
      {
         get
         {
            RegistryValue[] values = new RegistryValue[ m_Hashtable.Count ];

            IDictionaryEnumerator enumerator = m_Hashtable.GetEnumerator( );
            
            int i = 0;

            while ( enumerator.MoveNext( ) )
            {
               values[ i ] = new RegistryValue( );
               values[ i ].Path  = enumerator.Key as string;
               values[ i ].Value = enumerator.Value;
               
               ++i;
            }

            return values;
         }
      }

      public object GetValue(string key)
      {
         return m_Hashtable[ key ];
      }
      
      public void SetValue(string key, string value)
      {
         m_Hashtable[ key ] = value;
      }
      
      public void SetValue(string key, int value)
      {
         m_Hashtable[ key ] = value;
      }

      public void SetValue(string key, float value)
      {
         m_Hashtable[ key ] = value;
      }

      public int Version { get { return 1; } }

      public void Load(ObjectSerializer serializer)
      {
         m_Hashtable = serializer.LoadNamedObject( "Settings" ) as Hashtable;
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject( "Settings", m_Hashtable );
      }
   }
}
