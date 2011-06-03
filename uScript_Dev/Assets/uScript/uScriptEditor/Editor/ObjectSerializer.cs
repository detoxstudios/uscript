using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Reflection;

using Detox.Utility.Bxml;
using Detox.Utility;
//using Detox.Data.Model;

using Microsoft.DirectX;

namespace Detox.Data
{
   public interface ISerializable
   {
      //IMPORTANT:
      //do not make these virtual in derived classes
      //because object serializer must go through each
      //child class and get the correct version
      //for that child class
      int Version { get; }

      void Load(ObjectSerializer serializer);
      void Save(ObjectSerializer serializer);
   }

   public interface ITypeSerializer
   {
      int Version { get; }
      string SerializableType { get; }

      object Load(ObjectSerializer serializer);
      void   Save(ObjectSerializer serializer, object data);   
   }

   public class ObjectSerializer
   {
      private BinaryXml m_Bxml = null;
      
      private int m_CurrentVersion = 0;
      public int CurrentVersion { get { return m_CurrentVersion; } }

      private static Hashtable m_TypeSerializers = new Hashtable( );

      public static void AddTypeSerializer(ITypeSerializer typeSerializer)
      {
         m_TypeSerializers[ typeSerializer.SerializableType ] = typeSerializer;
      }

      public ObjectSerializer( )
      {
         AddTypeSerializer( new IntSerializer( ) );
         AddTypeSerializer( new ColorSerializer( ) );
         AddTypeSerializer( new HashtableSerializer( ) );
         AddTypeSerializer( new StringSerializer( ) );
         AddTypeSerializer( new StringArraySerializer( ) );
         AddTypeSerializer( new BoolSerializer( ) );
         AddTypeSerializer( new FloatSerializer( ) );            
         AddTypeSerializer( new BoneSerializer( ) );
         AddTypeSerializer( new BoneArraySerializer( ) );
         AddTypeSerializer( new MatrixSerializer( ) );
         AddTypeSerializer( new MatrixArraySerializer( ) );
         AddTypeSerializer( new Vector2Serializer( ) );
         AddTypeSerializer( new Vector2ArraySerializer( ) );
         AddTypeSerializer( new Vector3Serializer( ) );
         AddTypeSerializer( new Vector3ArraySerializer( ) );
         AddTypeSerializer( new Vector4Serializer( ) );
         AddTypeSerializer( new Vector4ArraySerializer( ) );
         AddTypeSerializer( new BoneDescSerializer( ) );
         AddTypeSerializer( new BoneDescArraySerializer( ) );            
         AddTypeSerializer( new SampleSerializer( ) );
         AddTypeSerializer( new AnimExportSettingsSerializer( ) );
         AddTypeSerializer( new EnumSerializer( ) );
         AddTypeSerializer( new GuidSerializer( ) );
         AddTypeSerializer( new SystemIdSerializer( ) );
      }

      public bool Load(string path, out object data )
      {
         data = null;
         
         try
         {
            if ( "" == path ) return false;

            StreamReader input = new StreamReader( path );
            BinaryReader reader = new BinaryReader( input.BaseStream );

            bool success = Load( reader, out data );

            input.Close( );

            return success;
         }
         catch (Exception e)
         {
            Status.Error( "Exception: " + e.Message + " when loading " + path );
            return false;
         }
      }

      public bool Load(BinaryReader reader, out object data )
      {
         data = null;

         m_Bxml = new BinaryXml( );
         
         if ( true == m_Bxml.Load(reader) )
         {
            data = LoadNamedObject( "Data" );
         }

         return null != data;
      }

      public object LoadNamedObject(string name)
      {
         BxmlTag loadTag = null;

         //find the first child tag with a name attribute
         //which matches the name we want to load
         //if name is null then load the first child
         foreach ( BxmlTag tag in m_Bxml.CurrentTag.ChildTags )
         {
            if ( tag.Name == name )
            {
               loadTag = tag;
               break;
            }
         }

         if ( null == loadTag ) return null;

         //move our current tag down to the next level
         //and any further loads will be done from
         //children of this tag
         m_Bxml.PushCurrentTag(loadTag);

         string type = loadTag.GetAttribute( "Type" ) as string;
         
         m_Bxml.PopCurrentTag( );

         return LoadNamedObject( name, null, type );
      }

      public bool Save(BinaryWriter writer, object data)
      {
         m_Bxml = new BinaryXml( "ObjectSerializer" );

         SaveNamedObject( "Data", data );

         return m_Bxml.Save( writer );
      }

      public bool Save(string path, object data)
      {
         try
         {
            StreamWriter output = new StreamWriter( path );
            BinaryWriter writer = new BinaryWriter( output.BaseStream );

            bool success = Save( writer, data );

            output.Close( );

            return success;
         }
         catch (Exception)
         {}

         return false;
      }

      public void SaveNamedObject(string name, object data)
      {
         SaveNamedObject( name, data, data.GetType( ) ); 
      }

      public void SaveBaseObject(object data, Type type)
      {
         SaveNamedObject( "Base", data, type );
      }

      public void LoadBaseObject(object data, Type type)
      {
         LoadNamedObject( "Base", data, type.ToString( ) );
      }

      public object [] LoadNamedObjects(string name)
      {
         object [] array = null;

         //search through all child tags to find
         //a parent which has our named objects
         foreach ( BxmlTag tag in m_Bxml.CurrentTag.ChildTags )
         {
            if ( tag.Name as string == name )
            {
               //once we find our parent set it to the current
               //and follow the traditional routine to load
               //the array of a children
               m_Bxml.PushCurrentTag( tag );

               int i, items = (int) tag.Value;

               array = new object[ items ];

               for ( i = 0; i < items; i++ )
               {
                  array[ i ] = LoadNamedObject( "Item" + i );
               }

               break;
            }
         }

         m_Bxml.PopCurrentTag( );

         return array;
      }

      public void SaveNamedObjects(string name, object [] array)
      {
         //manually add a child which is our named objects
         //and how many their are
         BxmlTag tag = m_Bxml.CurrentTag.AddChild( name );         
         tag.Value = array.Length;

         //move the tag stack down so we save
         //save our array as children
         m_Bxml.PushCurrentTag( tag );

         int i = 0;

         foreach ( object value in array )
         {
            SaveNamedObject( "Item" + i, value );
         
            i++;
         }

         m_Bxml.PopCurrentTag( );
      }

      public void GetData( out object value )
      {
         value = m_Bxml.CurrentTag.Value;
      }

      public void SetData(object value)
      {
         m_Bxml.CurrentTag.Value = value;
      }
   
      private void SaveNamedObject(string name, object data, Type type)
      {
         BxmlTag tag = m_Bxml.CurrentTag.AddChild( name );
         m_Bxml.PushCurrentTag( tag );

         ITypeSerializer typeSerializer = null;

         if ( m_TypeSerializers.Contains(type.ToString()) )
         {
            typeSerializer = m_TypeSerializers[ type.ToString() ] as ITypeSerializer;
         }
         else if ( type.IsEnum )
         {
            typeSerializer = m_TypeSerializers[ typeof(Enum).ToString() ] as ITypeSerializer;
         }

         if ( null != typeSerializer )
         {
            tag.AddAttribute( "Type", typeSerializer.SerializableType );
            tag.AddAttribute( "Version", typeSerializer.Version );
            
            typeSerializer.Save( this, data );
         }
         else
         {
            if ( null == (data as ISerializable) )
            {
               Status.Error( "No typeserializer found for " + type );
               throw new Exception("No typeserializer found for " + type );
            }
            else
            {
               tag.AddAttribute( "Type", type.ToString() );
   
               //save version of this class
               PropertyInfo versionProperty = type.GetProperty("Version");
               MethodInfo getVersionMethod  = versionProperty.GetGetMethod();
               int currentVersion = (int)getVersionMethod.Invoke(data, null);
               tag.AddAttribute( "Version", currentVersion );

               //tell this class to save
               MethodInfo saveMethod = type.GetMethod("Save", new Type[] { typeof(ObjectSerializer) });
               saveMethod.Invoke(data, new object[] { this });
            }
         }

         m_Bxml.PopCurrentTag( );
      }            

      private object LoadNamedObject(string name, object data, string type)
      {
         BxmlTag loadTag = null;

         //find the first child tag with a name attribute
         //which matches the name we want to load
         //if name is null then load the first child
         foreach ( BxmlTag tag in m_Bxml.CurrentTag.ChildTags )
         {
            if ( tag.Name == name )
            {
               loadTag = tag;
               break;
            }
         }

         if ( null == loadTag ) return null;

         //move our current tag down to the next level
         //and any further loads will be done from
         //children of this tag
         m_Bxml.PushCurrentTag( loadTag );

         int previousVersion = m_CurrentVersion;

         m_CurrentVersion = (int) loadTag.GetAttribute( "Version" );

         if ( m_TypeSerializers.Contains(type) )
         {
            ITypeSerializer typeSerializer = m_TypeSerializers[ type ] as ITypeSerializer;
            data = typeSerializer.Load( this );
         }
         else
         {  
            if ( null == data )
            {
               data = Activator.CreateInstance( Type.GetType(type) );
            }
         
            if ( null == (data as ISerializable) )
            {
               Status.Error( "No typeserializer found for " + type );
               throw new Exception("No typeserializer found for " + type );
            }

            //tell this class to save
            MethodInfo loadMethod = Type.GetType(type).GetMethod("Load", new Type[] { typeof(ObjectSerializer) });
            loadMethod.Invoke(data, new object[] { this });
         }

         m_CurrentVersion = previousVersion;

         m_Bxml.PopCurrentTag( );
         
         return data;
      }            
   }
}
