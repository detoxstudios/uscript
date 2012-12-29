using System;

//
// This file contains a collection of utility classes for use with uScript
// _______________________________________________________________________
//

public static class uScriptUtility
{
   /// <summary>Gets the index of an enumeration by name.</summary>
   /// <returns>The first occurance of 'name' within the enum, if found; otherwise, -1.</returns>
   /// <param name='e'>The enumeration type.</param>
   /// <param name='name'>The name of the enumeration.</param>
   public static int GetEnumIndexByName(Enum e, string name)
   {
      return Array.IndexOf(Enum.GetNames(e.GetType()), name);
   }

   /// <summary>Gets the index of an enumeration by value.</summary>
   /// <returns>The first occurance of the value within the enum, if found; otherwise, -1.</returns>
   /// <param name='e'>The enumeration type.</param>
   /// <param name='val'>The value to search for.</param>
   public static int GetEnumIndexByValue(Enum e, int val)
   {
      return Array.IndexOf((int[])Enum.GetValues(e.GetType()), val);
   }

   /// <summary>Gets the enumeration name by index.</summary>
   /// <returns>The name of the enum element, or throws an exception.</returns>
   /// <param name='e'>The enumeration type.</param>
   /// <param name='index'>The index of the enumeration.</param>
   public static string GetEnumNameByIndex(Enum e, int index)
   {
      return Enum.GetNames(e.GetType())[index];
   }

   /// <summary>Gets the index of the enum value by.</summary>
   /// <returns>The name of the enum element, or throws an exception.</returns>
   /// <param name='e'>The enumeration type.</param>
   /// <param name='index'>The index of the enumeration.</param>
   public static int GetEnumValueByIndex(Enum e, int index)
   {
      return ((int[])Enum.GetValues(e.GetType()))[index];
   }

   /// <summary>Rounds a numer to the nearest multiple.</summary>
   /// <returns>The rounded number.</returns>
   /// <param name='number'>The number to round.</param>
   /// <param name='multiple'>The multiple.</param>
   public static int RoundToMultiple(int number, int multiple)
   {
      return ((multiple / 2 + number) / multiple) * multiple;
   }
   
}
