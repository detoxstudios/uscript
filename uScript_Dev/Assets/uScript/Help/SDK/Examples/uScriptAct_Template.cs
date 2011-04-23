// uScript Example Action Node
// (C) 2011 Detox Studios LLC
// Desc: Template example node. It does nothing of value.

using UnityEngine;
using System.Collections;

// This section uses Attributes to tell uScript information it can us in the UI and other ways.
[NodePath("Action/YourFolder")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Template example node. It does nothing of value.")]
[NodeDescription("Template example node. It does nothing of value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net")]

[FriendlyName("Example Node")]
public class uScriptAct_ExampleNode : uScriptLogic
{

   // We need this variable in order to change the SpeicalOut proerty to true so it will fire.
   private bool m_SpecialOut = false; 


   // Without a friendly name, uScript will just use the property name-- 'Out' in this case.
   public bool Out { get { return true; } }


   // This other output uses a FriendlyName attribute. We set it to false (via m_SpecialOut) so we can only turn it to true
   // If certain conditions are met in one or more of the 'In' methods below.
   [FriendlyName("Special Out")]
   public bool SpecialOut { get { return m_SpecialOut; } }


   [FriendlyName("In")]
   public void In([FriendlyName("Float Input")] float FloatInput, [FriendlyName("String Input")] string StringInput, [FriendlyName("Vector3 Output")] out Vector3 Vector3Output)
   {
      // Set this to false in case the node has already run it's logic and had set it to true last time.
      m_SpecialOut = false; 

      Vector3Output = new Vector3(0, 0, 0);
   }


   // This creates a second input to the node where alternate logic can be run (think Play and Stop on the Play Sound node).
   // Currently, all input methods need to have the same parameters.
   [FriendlyName("Special In")]
   public void SpecialIn([FriendlyName("Float Input")] float FloatInput, [FriendlyName("String Input")] string StringInput, [FriendlyName("Vector3 Output")] out Vector3 Vector3Output)
   {
      // Set this to false in case the node has already run it's logic and had set it to true last time.
      m_SpecialOut = false;

      Vector3Output = new Vector3(1, 1, 1);
      if (StringInput == "Use Speical Out!")
      {
         // We are going to send the signal out through the SpecialOut socket because of logic we did that matched!
         m_SpecialOut = true;
      }
   }


   // Remember to use the 'override' keyword for the standard Unity methods Update, LateUpdate, FixedUpdate and OnGUI...
   // We are not using this at all so it doesn't need to be here. Just here for informational purposes!
   // If you wanted to do something over time you may put something here for example (like a time delay or
   // Lerp/Slerp of something.
   public override void Update()
   {
      
   }


}


