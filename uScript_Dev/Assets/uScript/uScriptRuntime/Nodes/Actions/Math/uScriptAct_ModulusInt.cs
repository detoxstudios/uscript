// uScript Action Node
// (C) 2018 Detox Studios LLC

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2018 by Detox Studios LLC")]
[NodeToolTip("Performs the modulus operator on two integer variables and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Modulus Int", "Performs the modulus operator on two integer variables and returns the result." + "\n\n[ A % B ]")]
public class uScriptAct_ModulusInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
   [FriendlyName("A", "The first variable."), AutoLinkType(typeof(int))]
   int A,

   [FriendlyName("B", "The second variable."), AutoLinkType(typeof(int))]
   int B,

   [FriendlyName("Result", "The integer result of the operation.")]
   out int IntResult
   )
   {
      IntResult = A % B;
   }
}
