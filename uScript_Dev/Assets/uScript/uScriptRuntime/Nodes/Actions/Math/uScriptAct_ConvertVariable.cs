// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Converts a variable into another type.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Converts a variable into another type.")]
[NodeDescription("Converts a variable into another type.\n \nTarget: The Target variable to be converted.\nInt Value (out): The Target variable represented as an integer.\nFloat Value (out): The Target variable represented as a floating point value.\nString Value (out): The Target variable represented as a string.\nBoolean Value (out): The Target variable represented as a Boolean (true/false) value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Convert_Variable")]

[FriendlyName("Convert Variable")]
public class uScriptAct_ConvertVariable : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(object Target,
      [FriendlyName("Int Value")] out int IntValue,
      [FriendlyName("Float Value")] out float FloatValue,
      [FriendlyName("String Value")] out string StringValue,
      [FriendlyName("Boolean Value")] out bool BooleanValue
      )
   {
      int tempIntValue = 0;
      float tempFloatValue = 0F;
      string tempStringValue = Target.ToString();
      bool tempBooleanValue = false;

      // Convert from GameObject
      if (typeof(GameObject) == Target.GetType())
      {
         GameObject tmpTarget = (GameObject)Target;

         if (tmpTarget != null)
         {
            tempIntValue = 1;
            tempFloatValue = 1F;
            tempBooleanValue = true;
            tempStringValue = tmpTarget.name;
         }
         else
         {
            tempIntValue = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = "null";
         }
      }

      // Convert from Enum
      else if (Target is System.Enum)
      {
         tempIntValue = (int)Target;
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
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = 1;
            tempFloatValue = 1F;
            tempBooleanValue = true;
            tempStringValue = tmpTarget.ToString();
         }
      }

      // Convert from Vector3
      else if (typeof(Vector3) == Target.GetType())
      {
         Vector3 tmpTarget = (Vector3)Target;

         if (tmpTarget.ToString() == "(0.0, 0.0, 0.0)")
         {
            tempIntValue = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = 1;
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
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = 1;
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
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = tmpTarget;
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
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = tmpTarget.ToString();
         }
         else
         {
            tempIntValue = System.Convert.ToInt32(tmpTarget);
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
            tempFloatValue = 1F;
            tempBooleanValue = true;
            tempStringValue = "True";
         }
         else
         {
            tempIntValue = 0;
            tempFloatValue = 0F;
            tempBooleanValue = false;
            tempStringValue = "False";
         }
      }

      // Output results
      IntValue = tempIntValue;
      FloatValue = tempFloatValue;
      StringValue = tempStringValue;
      BooleanValue = tempBooleanValue;
   }
}