// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Changes the case of the chracters in the specified string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Change Case", "Changes the case of the chracters in the specified string based on the case type (Upper, Lower, or Inverted).")]
public class uScriptAct_ChangeCase : uScriptLogic
{
   public enum CaseType {Upper, Lower, Invert};
	
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target string.")]
      string Target,

      [FriendlyName("Case", "Specifies what case to change the characters to.")]
      [SocketState(false, false)]
      CaseType caseType,
      
      [FriendlyName("Result", "Resulting string with replaced characters.")]
      out string Result
      )
   {
		if("" != Target)
		{
			if(caseType == CaseType.Upper)
			{
				Result = Target.ToUpper();
			}
			else if(caseType == CaseType.Lower)
			{
				Result = Target.ToLower();
			}
			else
			{	
				//Invert the casing on the string.
				string InvertedTarget = "";
				char[] targetChars = Target.ToCharArray();
				int i = 0;
				foreach(char c in targetChars)
				{
					if(char.IsLetter(c))
					{
						if(char.IsUpper(c))
						{
							targetChars[i] = char.ToLower(c);
						}
						else
						{
							targetChars[i] = char.ToUpper(c);
						}
					}
					
					InvertedTarget = InvertedTarget + targetChars[i].ToString();
	
					i++;
				}
				
				Result = InvertedTarget;
			}
			
		}
		else
		{
			Result = Target;
		}
   }
}

#endif