// uScript Action Node
// (C) 2013 Detox Studios LLC
using UnityEngine;
using System.Globalization;

[NodePath("Actions/Variables/Int")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Converts an integer to a string with advanced formatting options.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Int To String", "Converts an integer to a string with advanced formatting options.")]
public class uScriptAct_IntToString : uScriptLogic
{
   public bool Out { get { return true; } }
 
   public enum FormatType
   {
      General,
      Currency,
      Decimal,
      Exponential,
      FixedPoint,
      Number,
      Percent,
      Hexadecimal
   }

   public void In(
      [FriendlyName("Target", "The integer you wish to convert to a string.")]
      int Target,

      [FriendlyName("Standard Format", "Standard numeric formatting string.\n\n"
      + "The following results will be generated when the Target value is equal to 125 and the Invariant Culture is used:\n\n"
      + "\tGeneral:\t\t\t125\n"
      + "\tCurrency:\t\t$125.00\n"
      + "\tDecimal:\t\t\t125\n"
      + "\tExponential:\t1.250000E+002\n"
      + "\tFixedPoint:\t\t125.00\n"
      + "\tNumber:\t\t\t125.00\n"
      + "\tPercent:\t\t\t12500.00 %\n"
      + "\tHexidecimal:\t7D"
      )]
      [DefaultValue(FormatType.General), SocketState(false, false)]
      FormatType StandardFormat,

      [FriendlyName("Custom Format", "An optional custom numeric format string.  If none is specified, the chosen Standard Format will be used instead.\n\n"
      + "The following results will be generated when the Target value is equal to 125 and the Invariant Culture is used:\n\n"
      + "\t#.####:\t\t\t125\n"
      + "\t0.####:\t\t\t125\n"
      + "\t0.0000:\t\t\t125.0000\n"
      + "\t0000.0000:\t\t0125.0000\n"
      + "\tC5:\t\t\t\t$125.00000"
      )]
      [DefaultValue(""), SocketState(false, false)]
      string CustomFormat,

      [FriendlyName("Custom Culture", "An optional custom culture string.  If none is specified, the Invariant Culture will be used.\n\n"
      + "The following results will be generated when the Target value is equal to 125 and the custom culture is set to \"sv-SE\"."
      + "  Note the use of ',' instead of '.' for the decimal separator and the currency symbol for Swedish Krona:\n\n"
      + "\tGeneral:\t\t\t125\n"
      + "\tCurrency:\t\t125,00 kr"
      )]
      [DefaultValue(""), SocketState(false, false)]
      string CustomCulture,

      [FriendlyName("Result", "The string representation of the Target value as specified by format and culture.")]
      out string Result
   )
   {
      string format = CustomFormat;
#if (!UNITY_FLASH && !UNITY_WEBPLAYER && !UNITY_WP8 && !UNITY_WP8_1 && !UNITY_WINRT_8_1)
      System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture(CustomCulture);
#endif
      if (string.IsNullOrEmpty(format))
      {
         switch (StandardFormat)
         {
            case FormatType.Currency:
               format = "C";
               break;

            case FormatType.Decimal:
               format = "D";
               break;
               
            case FormatType.Exponential:
               format = "E";
               break;

            case FormatType.FixedPoint:
               format = "F";
               break;

            case FormatType.Number:
               format = "N";
               break;

            case FormatType.Percent:
               format = "P";
               break;

            case FormatType.Hexadecimal:
               format = "X";
               break;

            default:
               format = "G";
               break;
         }
      }

#if (!UNITY_FLASH && !UNITY_WEBPLAYER && !UNITY_WP8 && !UNITY_WP8_1 && !UNITY_WINRT_8_1)
		Result = Target.ToString(format, ci);
#else
      Result = Target.ToString();
#endif
   }
}
