// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Conversions")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Converts a variable into another type.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Convert_Variable")]

[FriendlyName("Convert Variable", "Converts a variable into another type.")]
public class uScriptAct_ConvertVariable : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target variable to be converted.")]
      object Target,
      
      [FriendlyName("Int Value", "The Target variable represented as an integer.")]
      out int IntValue,
      
      [FriendlyName("Int 64 Value", "The Target variable represented as a System.Int64.")]
      out System.Int64 Int64Value,
      
      [FriendlyName("Float Value", "The Target variable represented as a floating-point value.")]
      out float FloatValue,
      
      [FriendlyName("String Value", "The Target variable represented as a string.")]
      out string StringValue,
      
      [FriendlyName("Boolean Value", "The Target variable represented as a Boolean (true/false) value.")]
      out bool BooleanValue,
      
      [FriendlyName("Vector3 Value", "The Target variable represented as a Vector3 value.")]
      out Vector3 Vector3Value
      )
   {
      int tempIntValue = 0;
      System.Int64 tempInt64Value = 0;
      float tempFloatValue = 0F;
      string tempStringValue = Target.ToString();
      bool tempBooleanValue = false;
      Vector3 tempVector3Value = Vector3.zero;

      // Convert from GameObject
      if (typeof(GameObject) == Target.GetType())
      {
         GameObject tmpTarget = (GameObject)Target;

         if (tmpTarget != null)
         {
            tempIntValue = 1;
            tempInt64Value = 1;
            tempFloatValue = 1F;
            tempBooleanValue = true;
            tempStringValue = tmpTarget.name;
         }
         else
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = "null";
         }
      }

      // Convert from Enum
      else if (Target is System.Enum)
      {
         tempIntValue = (int)Target;
         tempInt64Value = (System.Int64)Target;
         tempFloatValue = tempIntValue;
         tempBooleanValue = tempIntValue == 0 ? false : true;
         tempStringValue = Target.ToString();
      }

      // Convert from Vector2
      else if (typeof(Vector2) == Target.GetType())
      {
         Vector3 tmpTarget = (Vector2)Target;

         if (tmpTarget.ToString() == "(0.0, 0.0)")
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = 1;
            tempInt64Value = 1;
            tempFloatValue = 1F;
            tempBooleanValue = true;
            tempStringValue = tmpTarget.ToString();
         }
      }

      // Convert from Vector3
      else if (typeof(Vector3) == Target.GetType())
      {
         Vector3 tmpTarget = (Vector3)Target;
         tempVector3Value = tmpTarget;

         if (tmpTarget.ToString() == "(0.0, 0.0, 0.0)")
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = 1;
            tempInt64Value = 1;
            tempFloatValue = 1F;
            tempBooleanValue = true;
            tempStringValue = tmpTarget.ToString();
         }
      }

      // Convert from Vector4
      else if (typeof(Vector4) == Target.GetType())
      {
         Vector4 tmpTarget = (Vector4)Target;

         if (tmpTarget.ToString() == "(0.0, 0.0, 0.0, 0.0)")
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = 1;
            tempInt64Value = 1;
            tempFloatValue = 1F;
            tempBooleanValue = true;
            tempStringValue = tmpTarget.ToString();
         }
      }

      // Convert from String
      else if (typeof(string) == Target.GetType())
      {
         string tmpTarget = (string)Target;

         if (tmpTarget == "")
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget;
         }
         else
         {
            string []components = tmpTarget.Split( ',' );

            if ( components.Length >= 3 )
            {
               System.Single.TryParse(components[0], out tempVector3Value.x);
               System.Single.TryParse(components[1], out tempVector3Value.y);
               System.Single.TryParse(components[2], out tempVector3Value.z);
            }

            int intNumber = 1;
            bool canConvertInt = System.Int32.TryParse(tmpTarget, out intNumber);
            if (canConvertInt)
            {
               tempIntValue = intNumber;
            }
            else
            {
               tempIntValue = 1;
            }

            System.Int64 int64Number = 1;
            bool canConvertInt64 = System.Int64.TryParse(tmpTarget, out int64Number);
            if (canConvertInt64)
            {
               tempInt64Value = int64Number;
            }
            else
            {
               tempInt64Value = 1;
            }

            float floatNumber = 1F;
            bool canConvertFloat = System.Single.TryParse(tmpTarget, out floatNumber);
            if (canConvertFloat)
            {
               tempFloatValue = floatNumber;
            }
            else
            {
               tempFloatValue = 1F;
            }

            tempBooleanValue = true;
            tempStringValue = tmpTarget;
         }
      }
		
	  // Convert from TextAsset
      else if (typeof(TextAsset) == Target.GetType())
      {
         TextAsset tmpTextAsset = (TextAsset)Target;
			
		 string tmpTarget = tmpTextAsset.text;

         if (tmpTarget == "")
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget;
         }
         else
         {
            int intNumber = 1;
            bool canConvertInt = System.Int32.TryParse(tmpTarget, out intNumber);
            if (canConvertInt)
            {
               tempIntValue = intNumber;
            }
            else
            {
               tempIntValue = 1;
            }

            System.Int64 int64Number = 1;
            bool canConvertInt64 = System.Int64.TryParse(tmpTarget, out int64Number);
            if (canConvertInt64)
            {
               tempInt64Value = int64Number;
            }
            else
            {
               tempInt64Value = 1;
            }

            float floatNumber = 1F;
            bool canConvertFloat = System.Single.TryParse(tmpTarget, out floatNumber);
            if (canConvertFloat)
            {
               tempFloatValue = floatNumber;
            }
            else
            {
               tempFloatValue = 1F;
            }

            tempBooleanValue = true;
            tempStringValue = tmpTarget;
         }
      }

      // Convert from Int
      else if (typeof(int) == Target.GetType())
      {
         int tmpTarget = (int)Target;

         if (tmpTarget == 0)
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = tmpTarget;
            tempInt64Value = System.Convert.ToInt64(tmpTarget);
            tempFloatValue = System.Convert.ToSingle(tmpTarget);
            tempBooleanValue = true;
            tempStringValue = tmpTarget.ToString();
         }
      }

      // Convert from Int64
      else if (typeof(System.Int64) == Target.GetType())
      {
         System.Int64 tmpTarget = (System.Int64)Target;

         if (tmpTarget == 0)
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = System.Convert.ToInt32(tmpTarget);
            tempInt64Value = tmpTarget;
            tempFloatValue = System.Convert.ToSingle(tmpTarget);
            tempBooleanValue = true;
            tempStringValue = tmpTarget.ToString();
         }
      }

      // Convert from Float
      else if (typeof(float) == Target.GetType())
      {
         float tmpTarget = (float)Target;

         if (tmpTarget == 0)
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = System.Convert.ToInt32(tmpTarget);
            tempInt64Value = System.Convert.ToInt64(tmpTarget);
            tempFloatValue = tmpTarget;
            tempBooleanValue = true;
            tempStringValue = tmpTarget.ToString();
         }
      }
		
      // Convert from Bool
      else if (typeof(bool) == Target.GetType())
      {
         bool tmpTarget = (bool)Target;

         if (tmpTarget == true)
         {
            tempIntValue = 1;
            tempInt64Value = 1;
            tempFloatValue = 1F;
            tempBooleanValue = true;
            tempStringValue = "True";
         }
         else
         {
            tempIntValue = 0;
            tempInt64Value = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = "False";
         }
      }

      // Output results
      IntValue = tempIntValue;
      Int64Value = tempInt64Value;
      FloatValue = tempFloatValue;
      StringValue = tempStringValue;
      BooleanValue = tempBooleanValue;
      Vector3Value = tempVector3Value;
   }
}