using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Globalization;

namespace Detox.Utility
{
   //generic to allow editing of custom types in the property grid

   [TypeConverterAttribute(typeof(EditableObjectConverter))]
   public abstract class EditableObject
   {
      public abstract string Description { get; }
      public abstract Attribute[] GetAttributes(string propertyName);
   }

   public class EditableObjectConverter : ExpandableObjectConverter
   {
      public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) 
      {
          if (typeof(EditableObject).IsAssignableFrom(destinationType)) return true;
          return base.CanConvertTo(context, destinationType);
      }

      public override object ConvertTo(ITypeDescriptorContext context,
                                       CultureInfo culture, 
                                       object value, 
                                       Type destinationType) 
      {
         
         EditableObject editableObject = value as EditableObject;
         if ( null != editableObject && destinationType == typeof(String) )
         {
            return editableObject.Description;
         }
         
         return base.ConvertTo(context, culture, value, destinationType);
      }
   }
}
