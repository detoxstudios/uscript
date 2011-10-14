using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using Detox.Drawing.Design;
using System.Globalization;

namespace Detox.Utility
{
   [Serializable]
   public class Platform
   {
      public static Platform Win     = new Platform("win");
      public static Platform iPhone  = new Platform("iphone");
      public static Platform Invalid = new Platform("invalid");

      public static Platform [] Platforms 
      { 
         get { return new Platform[2] {Win, iPhone}; }
      }

      private string m_Type = "";

      public Platform(string type)
      {
         m_Type = type;
      }

      public override string ToString() { return m_Type; }
   
      public override bool Equals(Object obj)
      {
         Platform id = obj as Platform;
         if ( null == id ) return false;

         return this == id;
      }
      
      public static bool operator == (Platform id1, Platform id2)
      {
         return id1.m_Type == id2.m_Type;
      }

      public static bool operator != (Platform id1, Platform id2)
      {
         return false == (id1 == id2);
      }        

      public override int GetHashCode()
      {
         return base.GetHashCode( );
      }
   }

   public class SystemIdConverter : StringConverter
   {
      // Overrides the CanConvertFrom method of TypeConverter.
      // The ITypeDescriptorContext interface provides the context for the
      // conversion. Typically, this interface is used at design time to 
      // provide information about the design-time container.
      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
         if (sourceType == typeof(string))
         {
            return true;
         }
         return base.CanConvertFrom(context, sourceType);
      }

      // Overrides the ConvertFrom method of TypeConverter.
      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
         if (value is string)
         {
            return new SystemId((String)value);
         }
         return base.ConvertFrom(context, culture, value);
      }

      // Overrides the CanConvertFrom method of TypeConverter.
      // The ITypeDescriptorContext interface provides the context for the
      // conversion. Typically, this interface is used at design time to 
      // provide information about the design-time container.
      public override bool CanConvertTo(ITypeDescriptorContext context, Type sourceType)
      {
         if (sourceType == typeof(SystemId))
         {
            return true;
         }
         return base.CanConvertFrom(context, sourceType);
      }

      // Overrides the ConvertTo method of TypeConverter.
      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
         if (destinationType == typeof(string) && value != null)
         {
            return ((SystemId)value).ToString();
         }
         return base.ConvertTo(context, culture, value, destinationType);
      }
   }

   public class SystemIdTypeEditor : Detox.Windows.Forms.Design.FileNameEditor
   {
      //public override Object EditValue(
      //   ITypeDescriptorContext context,
      //   IServiceProvider provider,
      //   Object value
      //)
      //{
      //   String filename = "";

      //   if (value is SystemId)
      //   {
      //      filename = value.ToString();
      //   }
      //   else if (value is String)
      //   {
      //      filename = value.ToString();
      //   }

      //   if (!String.IsNullOrEmpty(filename))
      //   {
      //      Microsoft.Win32.OpenFileDialog fileDlg = new Microsoft.Win32.OpenFileDialog();
      //      fileDlg.FileName = filename;

      //      if ((bool)fileDlg.ShowDialog())
      //      {
      //         return fileDlg.FileName;
      //      }
      //   }

      //   return null;
      //}

      //public override UITypeEditorEditStyle GetEditStyle(
      //   ITypeDescriptorContext context
      //)
      //{
      //   return UITypeEditorEditStyle.Modal;
      //}
   }

   [Serializable]
   [TypeConverter(typeof(SystemIdConverter))]
//   [Editor(typeof(Detox.Windows.Forms.Design.FileNameEditor), typeof(UITypeEditor))]
   [Editor(typeof(Detox.Utility.SystemIdTypeEditor), typeof(Detox.Windows.Forms.Design.FileNameEditor))]
   public class SystemId
   {
//      [Browsable(false)]
//      public override string Description { get { return ""; } }

      //32 + . + 8 extension + null
      public static int Length { get { return 42; } }

      public override string ToString()
      {
         System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding( );
         string value = enc.GetString(m_Bytes);
         
         return value.TrimEnd( new char[] { '\0' } );
      }

      public string Extension
      {
         get
         {
            //return extension without the leading '.'
            string extension = System.IO.Path.GetExtension(ToString());
            if ( extension.Length > 1 ) return extension.Substring( 1 );
            
            return "";
         }
      }

      public string Name
      {
         get
         {
            return System.IO.Path.GetFileNameWithoutExtension(ToString());
         }
      }

      private byte [] m_Bytes = null;
      public byte [] Bytes 
      { 
         get 
         { 
            byte[] bytes = new byte[ Length ];
            m_Bytes.CopyTo( bytes, 0 );

            return bytes; 
         } 
      }

      public SystemId(byte[] id)
      {
         m_Bytes = new byte[ Length ];
         id.CopyTo( m_Bytes, 0 );
      }

      public SystemId(string id)
      {
         int i = 0;

         m_Bytes = new byte[ Length ];

         foreach ( char c in id )
         {
            m_Bytes[ i++ ] = (byte) c;
         
            if ( i == Length ) break;
         }

         while ( i < SystemId.Length )
         {
            m_Bytes[ i++ ] = 0;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode( );
      }

      public override bool Equals(Object obj)
      {
         if (obj == null) return false;

         if (obj is SystemId)
         {
            return (SystemId)obj == this;
         }

         return false;
      }
      
      public static bool operator == (SystemId id1, SystemId id2)
      {
         int i = SystemId.Length;

         for ( i = 0; i < SystemId.Length; i++ )
         {
            if ( id1.m_Bytes[ i ] != id2.m_Bytes[ i ] ) return false;
         }
         
         return true;
      }

      public static bool operator != (SystemId id1, SystemId id2)
      {
         return false == (id1 == id2);
      }

      public static implicit operator SystemId(String id)
      {
         return new SystemId(id);
      }
   }
}
