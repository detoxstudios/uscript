using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Detox.Utility.Bxml
{
   public class BxmlValue
   {
      private string m_Type = "";
      private byte[] m_Value = null;

      public object Value 
      { 
         get
         {
            if ( m_Type == typeof(float).ToString( ) )
            {
               return System.BitConverter.ToSingle( m_Value, 0 );
            }
            else if ( m_Type == typeof(byte[]).ToString( ) )
            {
               byte[] data = new byte[ m_Value.Length ];
               m_Value.CopyTo( data, 0 );

               return data;
            }
            else if ( m_Type == typeof(bool).ToString( ) )
            {
               return System.BitConverter.ToBoolean( m_Value, 0 );
            }
            else if ( m_Type == typeof(int).ToString( ) )
            {
               return System.BitConverter.ToInt32( m_Value, 0 );
            }
            else if ( m_Type == typeof(string).ToString( ) )
            {
               System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding( );
               string value = enc.GetString( m_Value, 0, (int) m_Value.Length );

               return value.TrimEnd( new char[] { '\0' } );
            }
            else
            {
               throw new Exception("Unrecognized value type for BxmlValue: " + m_Type );
            }
         }
         set
         {
            m_Type = value.GetType( ).ToString( );

            if ( value.GetType( ) == typeof(float) )
            {
               m_Value = System.BitConverter.GetBytes( (float) value );
            }
            else if ( value.GetType( ) == typeof(bool) )
            {
               m_Value = System.BitConverter.GetBytes( (bool) value );
            }
            else if ( value.GetType( ) == typeof(int) )
            {
               m_Value = System.BitConverter.GetBytes( (int) value );
            }
            else if ( value.GetType( ) == typeof(string) )
            {
               System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding( );
               m_Value = enc.GetBytes( value as string );
            }
            else if ( value.GetType( ) == typeof(byte[]) )
            {
               byte[] data = value as byte[];

               m_Value = new byte[ data.Length ];
               data.CopyTo( m_Value, 0 );
            }
            else
            {
               throw new Exception("Unrecognized value type for BxmlValue: " + m_Type );
            }
         }
      }      

      public void Write(BinaryWriter writer)
      {
         //writer.Write( m_Type.Length );
         writer.Write( m_Type );

         if ( "" != m_Type )
         {
            writer.Write( m_Value.Length );
            writer.Write( m_Value );
         }
      }

      public void Read(BinaryReader reader)
      {
         //writer.Write( m_Type.Length );
         m_Type = reader.ReadString( );
       
         if ( "" != m_Type )
         {  
            int length = reader.ReadInt32( );
            m_Value = reader.ReadBytes( length );
         }
      }
   }

   public class BxmlAttribute
   {
      private string m_Name = "";
      public string Name { get { return m_Name; } }

      private BxmlValue m_Value = new BxmlValue( );
      
      public object Value { get { return m_Value.Value; } } 
         
      public BxmlAttribute(string name, object value)
      {
         m_Name = name;
         m_Value.Value = value;
      }

      public BxmlAttribute()
      {
         m_Name = "";
      }

      public void Write(BinaryWriter writer)
      {         
         //writer.Write( m_Name.Length );
         writer.Write( m_Name );

         m_Value.Write( writer );
      }

      public void Read(BinaryReader reader)
      {         
         m_Name = reader.ReadString( );

         m_Value.Read( reader );
      }
   }
   
   public class BxmlTag
   {
      private List<BxmlTag> m_Children = new List<BxmlTag>( );
      private List<BxmlAttribute> m_Attributes = new List<BxmlAttribute>( );

      public BxmlTag [] ChildTags { get { return m_Children.ToArray( ); } }

      private string m_Name = "";
      public string Name { get { return m_Name; } }

      private BxmlValue m_Value = new BxmlValue( );
      public object Value { get { return m_Value.Value; } set { m_Value.Value = value; } }

      public BxmlTag(string name)
      {
         m_Name = name;
      }

      public BxmlTag()
      {
      }

      public void AddAttribute(string attribute, object value)
      {
         BxmlAttribute bxmlAttr = new BxmlAttribute( attribute, value );
         m_Attributes.Add( bxmlAttr );
      }

      public object GetAttribute(string name)
      {
         foreach ( BxmlAttribute attribute in m_Attributes )
         {
            if ( attribute.Name == name )
            {
               return attribute.Value;
            }
         }

         return null;
      }

      public BxmlTag AddChild(string name)
      {
         BxmlTag child = new BxmlTag( name );

         m_Children.Add(child);

         return child;
      }

      public int Write(BinaryWriter writer)
      {  
         int count = 1;

         //writer.Write( m_Name.Length );
         writer.Write( m_Name );

         writer.Write( (int) m_Children.Count );
         writer.Write( (int) m_Attributes.Count );

         m_Value.Write( writer );

         foreach ( BxmlAttribute attribute in m_Attributes )
         {
            attribute.Write( writer );
         }

         foreach ( BxmlTag tag in m_Children )
         {
            count += tag.Write( writer );
         }

         return count;
      }

      public void Read(BinaryReader reader)
      {
         m_Name = reader.ReadString( );

         int childCount  = reader.ReadInt32( );
         int attribCount = reader.ReadInt32( );

         m_Value.Read( reader );
         
         int i;

         for ( i = 0; i < attribCount; i++ )
         {
            BxmlAttribute attribute = new BxmlAttribute( );
            attribute.Read( reader );
            
            m_Attributes.Add( attribute );
         }

         for ( i = 0; i < childCount; i++ )
         {
            BxmlTag tag = new BxmlTag( );
            tag.Read( reader );

            m_Children.Add( tag );
         }
      }
   }

   public class BinaryXml
   {
      private const int CurrentVersion  = 1;
      private const int BinaryXmlHeader = 0xb387;

      private List<BxmlTag> m_TagStack = new List<BxmlTag>( );

      public BxmlTag CurrentTag  
      { 
         get 
         { 
            return m_TagStack.ToArray( )[ m_TagStack.Count - 1 ];
         } 
      }
    
      public BinaryXml()
      {
      }

      public BinaryXml(string rootTag)
      {
         m_TagStack.Add( new BxmlTag(rootTag) );
      }

      public void PushCurrentTag(BxmlTag tag)
      {
         m_TagStack.Add( tag );
      }

      public BxmlTag PopCurrentTag( )
      {
         BxmlTag popped = CurrentTag;

         m_TagStack.RemoveAt( m_TagStack.Count - 1 );
      
         return popped;
      }
  
      public BxmlTag RootTag { get { return m_TagStack.ToArray( )[ 0 ]; } }

      public bool Load(string path)
      {
         try
         {
            StreamReader input = new StreamReader( path );
            BinaryReader reader = new BinaryReader( input.BaseStream );

            bool success = Load( reader );

            input.Close( );

            return success;
         }
         catch (Exception)
         {}

         return false;
      }

      public bool Load(BinaryReader reader)
      {
         int version = reader.ReadInt32( );
         if ( version != CurrentVersion ) return false;

         int header = reader.ReadInt32( );
         if ( header != BinaryXmlHeader ) return false;

         //read past the tag count
         reader.ReadInt32( );

         BxmlTag rootTag = new BxmlTag( );
         rootTag.Read( reader );

         m_TagStack.Clear( );
         PushCurrentTag( rootTag );

         return true;
      }

      public bool Save(string path)
      {  
         bool result = true;

         StreamWriter output = null;
         BinaryWriter writer = null;
         
         try
         {
            output = new StreamWriter( path );
            writer = new BinaryWriter( output.BaseStream );
   
            result = Save( writer );
         }
         catch( Exception )
         {
            result = false;
         }

         if ( null != output )
         {
            output.Close( );
         }

         return result;
      }

      public bool Save(BinaryWriter writer)
      {
         BxmlTag rootTag = this.RootTag;

         //version, place holder
         writer.Write( (int) 0 );

         //header, placeholder
         writer.Write( (int) 0 );

         //num tags, placeholder
         writer.Write( (int) 0 );

         int tagCount = rootTag.Write( writer );

         //seek to the beginning and write header info
         writer.Seek( 0, SeekOrigin.Begin );

         //header
         writer.Write( (int) CurrentVersion );
         writer.Write( (int) BinaryXmlHeader );
         writer.Write( tagCount );

         writer.Seek( 0, SeekOrigin.End );

         return true;
      }
   }
}
