// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Converts a variable into another type.

using UnityEngine;
using System.Collections;

public class uScriptAct_ConvertVariable : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(object Target,
      out int IntValue,
      out float FloatValue,
      out string StringValue,
      out bool BooleanValue
      )
   {

      int tempIntValue = 0;
      float tempFloatValue = 0F;
      string tempStringValue = "";
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

      // Convert from Vector3
      if (typeof(Vector3) == Target.GetType())
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
      if (typeof(Vector4) == Target.GetType())
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
      if (typeof(string) == Target.GetType())
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

      // Convert from Int
      if (typeof(int) == Target.GetType())
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
      if (typeof(float) == Target.GetType())
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

      // Output results
      IntValue = tempIntValue;
      FloatValue = tempFloatValue;
      StringValue = tempStringValue;
      BooleanValue = tempBooleanValue;
   }
}