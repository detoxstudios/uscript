// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Rotates the target GameObject by a number of degrees over X seconds.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Isometric Character Controller.")]
[NodeDescription("Simple character controller.  Character always moves forward and backwards along its forward vector.\n \nTarget: The character to control.\nTranslation Units Per Second: How many units to move per second when the forward/backward keys are pressed.\nRotation Units Per Second: How many units to rotate per second when the left/right keys are pressed.\nFilter Translation: Whether or not to filter the object's translation.\nTranslation Filter Constant: The strength of the translation filter (lower numbers mean more filtering, i.e. slower).\nFilter Rotation: Whether or not to filter the object's rotation.\nRotation Filter Constant: The strength of the rotation filter (lower numbers mean more filtering, i.e. slower).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Isometric_Character_Controller")]

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
   
   private float m_LastTranslateSpeed = 0.0f;
   private float m_LastRotateSpeed = 0.0f;
   private bool m_FilterTranslation = false;
   private bool m_FilterRotation = false;
   private float m_TranslationFilterConstant = 0.7f;
   private float m_RotationFilterConstant = 0.1f;

   [FriendlyName("Move Local Forward")]
   public void MoveForward(
      [FriendlyName("Target")] GameObject target,
      [FriendlyName("Translation Units Per Second"), DefaultValue(5f)] float translation,
      [FriendlyName("Rotation Units Per Second"), DefaultValue(1.5f)] float rotation,
      [FriendlyName("Filter Translation"), DefaultValue(false), SocketState(false, false)] bool filterTranslation,
      [FriendlyName("Translation Filter Constant"), DefaultValue(0.7f), SocketState(false, false)] float translationFilterConstant,
      [FriendlyName("Filter Rotation"), DefaultValue(false), SocketState(false, false)] bool filterRotation,
      [FriendlyName("Rotation Filter Constant"), DefaultValue(0.1f), SocketState(false, false)] float rotationFilterConstant
   )
   {
      m_Translate = Translate.Forward;

      m_Target = target;
      m_TranslateSpeed = m_LastTranslateSpeed = translation;
      m_RotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;
   }

   [FriendlyName("Move Local Backward")]
   public void MoveBackward(
      [FriendlyName("Target")] GameObject target,
      [FriendlyName("Translation Units Per Second")] float translation,
      [FriendlyName("Rotation Units Per Second"), DefaultValue(1.5f)] float rotation,
      [FriendlyName("Filter Translation"), DefaultValue(false), SocketState(false, false)] bool filterTranslation,
      [FriendlyName("Translation Filter Constant"), DefaultValue(0.7f), SocketState(false, false)] float translationFilterConstant,
      [FriendlyName("Filter Rotation"), DefaultValue(false), SocketState(false, false)] bool filterRotation,
      [FriendlyName("Rotation Filter Constant"), DefaultValue(0.1f), SocketState(false, false)] float rotationFilterConstant
   )
   {
      m_Translate = Translate.Backward;

      m_Target = target;
      m_TranslateSpeed = m_LastTranslateSpeed = translation;
      m_RotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;
   }

   [FriendlyName("Rotate Local Right")]
   public void RotateRight(
      [FriendlyName("Target")] GameObject target,
      [FriendlyName("Translation Units Per Second")] float translation,
      [FriendlyName("Rotation Units Per Second"), DefaultValue(1.5f)] float rotation,
      [FriendlyName("Filter Translation"), DefaultValue(false), SocketState(false, false)] bool filterTranslation,
      [FriendlyName("Translation Filter Constant"), DefaultValue(0.7f), SocketState(false, false)] float translationFilterConstant,
      [FriendlyName("Filter Rotation"), DefaultValue(false), SocketState(false, false)] bool filterRotation,
      [FriendlyName("Rotation Filter Constant"), DefaultValue(0.1f), SocketState(false, false)] float rotationFilterConstant
   )
   {
      m_Rotate = Rotate.Right;

      m_Target = target;
      m_TranslateSpeed = translation;
      m_RotateSpeed = m_LastRotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;
   }

   [FriendlyName("Rotate Local Left")]
   public void RotateLeft(
      [FriendlyName("Target")] GameObject target,
      [FriendlyName("Translation Units Per Second")] float translation,
      [FriendlyName("Rotation Units Per Second"), DefaultValue(1.5f)] float rotation,
      [FriendlyName("Filter Translation"), DefaultValue(false), SocketState(false, false)] bool filterTranslation,
      [FriendlyName("Translation Filter Constant"), DefaultValue(0.7f), SocketState(false, false)] float translationFilterConstant,
      [FriendlyName("Filter Rotation"), DefaultValue(false), SocketState(false, false)] bool filterRotation,
      [FriendlyName("Rotation Filter Constant"), DefaultValue(0.1f), SocketState(false, false)] float rotationFilterConstant
   )
   {
      m_Rotate = Rotate.Left;

      m_Target = target;
      m_TranslateSpeed = translation;
      m_RotateSpeed = m_LastRotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;
   }

   public void Update()
   {
      if (null == m_Target) return;
      
      float rotateSpeed = m_RotateSpeed;
      float translateSpeed = m_TranslateSpeed;
      
      // filter translation/rotation?
      if (m_FilterTranslation)
      {
         m_LastTranslateSpeed = translateSpeed = (m_LastTranslateSpeed * (1.0f - m_TranslationFilterConstant));
      }
      if (m_FilterRotation)
      {
         m_LastRotateSpeed = rotateSpeed = (m_LastRotateSpeed * (1.0f - m_RotationFilterConstant));
      }

      // apply translation/rotation
      if (Rotate.Left == m_Rotate)
      {
         m_Target.transform.RotateAroundLocal(Vector3.up, -rotateSpeed * Time.deltaTime);
      }
      else if (Rotate.Right == m_Rotate)
      {
         m_Target.transform.RotateAroundLocal(Vector3.up, rotateSpeed * Time.deltaTime);
      }

      if (Translate.Forward == m_Translate)
      {
         m_Target.transform.position += m_Target.transform.forward * translateSpeed * Time.deltaTime;
      }
      else if (Translate.Backward == m_Translate)
      {
         m_Target.transform.position += m_Target.transform.forward * -translateSpeed * Time.deltaTime;
      }
  
      // done translating/rotating?
      if (!m_FilterTranslation || Mathf.Abs(translateSpeed) <= 0.01)
      {
         m_Translate = Translate.None;
      }
      if (!m_FilterRotation || Mathf.Abs(rotateSpeed) <= 0.01)
      {
         m_Rotate = Rotate.None;
      }

      // if done translating and rotating, clear target
      if (m_Rotate == Rotate.None && m_Translate == Translate.None)
      {
         m_Target = null;
      }
   }
}