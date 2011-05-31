// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Rotates the target GameObject by a number of degrees over X seconds.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Isometric Character Controller.")]
[NodeDescription("Simple character controller.  Character always moves forward and backwards along its forward vector.\n \nTarget: The character to control.\nTranslation Units Per Second: How many units to move per second when the forward/backward keys are pressed.\nRotation Units Per Second: How many units to rotate per second when the left/right keys are pressed.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Isometric Character Controller")]
public class uScriptAct_IsometricCharacterController : uScriptLogic
{
   public bool Out { get { return true; } }

   private enum Translate
   {
      None,
      Forward,
      Backward
   }

   private enum Rotate
   {
      None,
      Right,
      Left
   }

   private GameObject m_Target = null;
   private Translate m_Translate = Translate.None;
   private Rotate m_Rotate = Rotate.None;
   private float m_TranslateSpeed = 0.0f;
   private float m_RotateSpeed = 0.0f;

   [FriendlyName("Move Local Forward")]
   public void MoveForward(
      [FriendlyName("Target")] GameObject target,
      [FriendlyName("Translation Units Per Second"), DefaultValue(5f)] float translation,
      [FriendlyName("Rotation Units Per Second"), DefaultValue(1.5f)] float rotation
   )
   {
      m_Translate = Translate.Forward;

      m_Target = target;
      m_TranslateSpeed = translation;
      m_RotateSpeed = rotation;
   }

   [FriendlyName("Move Local Backward")]
   public void MoveBackward(
      [FriendlyName("Target")] GameObject target,
      [FriendlyName("Translation Units Per Second")] float translation,
      [FriendlyName("Rotation Units Per Second")] float rotation
   )
   {
      m_Translate = Translate.Backward;

      m_Target = target;
      m_TranslateSpeed = translation;
      m_RotateSpeed = rotation;
   }

   [FriendlyName("Rotate Local Right")]
   public void RotateRight(
      [FriendlyName("Target")] GameObject target,
      [FriendlyName("Translation Units Per Second")] float translation,
      [FriendlyName("Rotation Units Per Second")] float rotation
   )
   {
      m_Rotate = Rotate.Right;

      m_Target = target;
      m_TranslateSpeed = translation;
      m_RotateSpeed = rotation;
   }

   [FriendlyName("Rotate Local Left")]
   public void RotateLeft(
      [FriendlyName("Target")] GameObject target,
      [FriendlyName("Translation Units Per Second")] float translation,
      [FriendlyName("Rotation Units Per Second")] float rotation
   )
   {
      m_Rotate = Rotate.Left;

      m_Target = target;
      m_TranslateSpeed = translation;
      m_RotateSpeed = rotation;
   }

   public override void FixedUpdate()
   {
      if (null == m_Target) return;

      if (Rotate.Left == m_Rotate)
      {
         m_Target.transform.RotateAroundLocal(Vector3.up, -m_RotateSpeed * Time.deltaTime);
      }
      else if (Rotate.Right == m_Rotate)
      {
         m_Target.transform.RotateAroundLocal(Vector3.up, m_RotateSpeed * Time.deltaTime);
      }

      if (Translate.Forward == m_Translate)
      {
         m_Target.transform.position += m_Target.transform.forward * m_TranslateSpeed * Time.deltaTime;
      }
      else if (Translate.Backward == m_Translate)
      {
         m_Target.transform.position += m_Target.transform.forward * -m_TranslateSpeed * Time.deltaTime;
      }

      m_Target = null;
      m_Rotate = Rotate.None;
      m_Translate = Translate.None;
   }
}