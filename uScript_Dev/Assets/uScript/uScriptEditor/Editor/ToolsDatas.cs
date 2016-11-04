using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Detox.Data.Tools
{
   public class AppFrameworkData : ISerializable
   {
      private Hashtable m_Hashtable = new Hashtable( );

      public ICollection GetAllKeys()
      {
         return m_Hashtable.Keys;
      }

      public object Get(string key)
      {
         return m_Hashtable[ key ];
      }
      
      public void Set(string key, object value)
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

      public void Save(string path)
      {
         ObjectSerializer serializer = new ObjectSerializer( );
         serializer.Save( path, this );
      }

      public void Load(string path)
      {
         object data;
         AppFrameworkData appData = null;

         ObjectSerializer serializer = new ObjectSerializer();

         if ( true == serializer.Load(path, out data) )
         {
            appData = data as AppFrameworkData;
         }
         else
         {
            appData = new AppFrameworkData();
         }

         m_Hashtable = appData.m_Hashtable;
      }
   }
}

