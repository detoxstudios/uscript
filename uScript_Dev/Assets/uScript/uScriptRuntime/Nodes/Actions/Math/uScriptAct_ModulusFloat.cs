// uScript Action Node
// (C) 2018 Detox Studios LLC

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2018 by Detox Studios LLC")]
[NodeToolTip("Performs the modulus operator on two float variables and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modulus Float", "Performs the modulus operator on two float variables and returns the result." + "\n\n[ A % B ]")]
public class uScriptAct_ModulusFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
   [FriendlyName("A", "The first variable."), AutoLinkType(typeof(float))]
   float A,

   [FriendlyName("B", "The second variable."), AutoLinkType(typeof(float))]
   float B,

   [FriendlyName("Result", "The float result of the operation.")]
   out float FloatResult
   )
   {
      FloatResult = A % B;
   }
}
