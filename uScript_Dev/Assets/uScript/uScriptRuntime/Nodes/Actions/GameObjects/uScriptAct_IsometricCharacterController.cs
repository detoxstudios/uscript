// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Isometric Character Controller.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Isometric Character Controller", "Simple character controller.  Character always moves forward and backwards along its forward vector.")]
public class uScriptAct_IsometricCharacterController : uScriptLogic
{
   private enum Direction
   {
      None,
      Forward,
      Backward,
      Right,
      Left
   }

   private GameObject m_Target = null;
   private Direction m_Translate = Direction.None;
   private Direction m_Rotate = Direction.None;
   private Direction m_Strafe = Direction.None;
   private float m_TranslateSpeed = 0.0f;
   private float m_RotateSpeed = 0.0f;
   private CharacterController m_Controller = null;

   private float m_LastTranslateSpeed = 0.0f;
   private float m_LastRotateSpeed = 0.0f;
   private bool m_FilterTranslation = false;
   private bool m_FilterRotation = false;
   private float m_TranslationFilterConstant = 0.7f;
   private float m_RotationFilterConstant = 0.1f;


   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Out { get { return true; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Resume()
   // Parameter Attributes are applied below in RotateLeft()
   [FriendlyName("Move Local Forward")]
   public void MoveForward(GameObject target, float translation, float rotation, bool filterTranslation, float translationFilterConstant, bool filterRotation, float rotationFilterConstant)
   {
      m_Translate = Direction.Forward;

      m_Target = target;
      m_TranslateSpeed = m_LastTranslateSpeed = translation;
      m_RotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;

      if (null != target) m_Controller = target.GetComponent<CharacterController>();
   }


   // Parameter Attributes are applied below in RotateLeft()
   [FriendlyName("Move Local Backward")]
   public void MoveBackward(GameObject target, float translation, float rotation, bool filterTranslation, float translationFilterConstant, bool filterRotation, float rotationFilterConstant)
   {
      m_Translate = Direction.Backward;

      m_Target = target;
      m_TranslateSpeed = m_LastTranslateSpeed = translation;
      m_RotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;

      if (null != target) m_Controller = target.GetComponent<CharacterController>();
   }


   // Parameter Attributes are applied below in RotateLeft()
   [FriendlyName("Strafe Local Right")]
   public void StrafeRight(GameObject target, float translation, float rotation, bool filterTranslation, float translationFilterConstant, bool filterRotation, float rotationFilterConstant)
   {
      m_Strafe = Direction.Right;

      m_Target = target;
      m_TranslateSpeed = m_LastTranslateSpeed = translation;
      m_RotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;

      if (null != target) m_Controller = target.GetComponent<CharacterController>();
   }

   // Parameter Attributes are applied below in RotateLeft()
   [FriendlyName("Strafe Local Left")]
   public void StrafeLeft(GameObject target, float translation, float rotation, bool filterTranslation, float translationFilterConstant, bool filterRotation, float rotationFilterConstant)
   {
      m_Strafe = Direction.Left;

      m_Target = target;
      m_TranslateSpeed = m_LastTranslateSpeed = translation;
      m_RotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;

      if (null != target) m_Controller = target.GetComponent<CharacterController>();
   }

   // Parameter Attributes are applied below in RotateLeft()
   [FriendlyName("Rotate Local Right")]
   public void RotateRight(GameObject target, float translation, float rotation, bool filterTranslation, float translationFilterConstant, bool filterRotation, float rotationFilterConstant)
   {
      m_Rotate = Direction.Right;

      m_Target = target;
      m_TranslateSpeed = translation;
      m_RotateSpeed = m_LastRotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;

      if (null != target) m_Controller = target.GetComponent<CharacterController>();
   }

   [FriendlyName("Rotate Local Left")]
   public void RotateLeft(
      [FriendlyName("Target", "The character to control.")]
      GameObject target,

      [FriendlyName("Translation Units Per Second", "How many units to move per second when the forward/backward keys are pressed.")]
      float translation,

      [FriendlyName("Rotation Units Per Second", "How many units to rotate per second when the left/right keys are pressed.")]
      [DefaultValue(1.5f)]
      float rotation,

      [FriendlyName("Filter Translation", "If True, the object's translation will be filtered.")]
      [DefaultValue(false), SocketState(false, false)]
      bool filterTranslation,
      
      [FriendlyName("Translation Filter Constant", "The strength of the translation filter (lower numbers mean more filtering, i.e. slower).")]
      [DefaultValue(0.7f), SocketState(false, false)]
      float translationFilterConstant,
      
      [FriendlyName("Filter Rotation", "If True, the object's rotation will be filtered.")]
      [DefaultValue(false), SocketState(false, false)]
      bool filterRotation,
      
      [FriendlyName("Rotation Filter Constant", "The strength of the rotation filter (lower numbers mean more filtering, i.e. slower).")]
      [DefaultValue(0.1f), SocketState(false, false)]
      float rotationFilterConstant
      )
   {
      m_Rotate = Direction.Left;

      m_Target = target;
      m_TranslateSpeed = translation;
      m_RotateSpeed = m_LastRotateSpeed = rotation;

      m_FilterTranslation = filterTranslation;
      m_FilterRotation = filterRotation;
      m_TranslationFilterConstant = translationFilterConstant;
      m_RotationFilterConstant = rotationFilterConstant;

      if (null != target) m_Controller = target.GetComponent<CharacterController>();
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
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
      if (Direction.Left == m_Rotate)
      {
#if  !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2_0
         m_Target.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime, Space.Self);
#else
         m_Target.transform.RotateAroundLocal(Vector3.up, -rotateSpeed * Time.deltaTime);
#endif
      }
      else if (Direction.Right == m_Rotate)
      {
#if  !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2_0	
         m_Target.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.Self);
#else
         m_Target.transform.RotateAroundLocal(Vector3.up, rotateSpeed * Time.deltaTime);
#endif
      }

      Vector3 movement = Vector3.zero;

      // apply translation/rotation
      if (Direction.Left == m_Strafe)
      {
         movement = m_Target.transform.right * - translateSpeed * Time.deltaTime;
      }
      else if (Direction.Right == m_Strafe)
      {
         movement = m_Target.transform.right * translateSpeed * Time.deltaTime;
      }

      if (Direction.Forward == m_Translate)
      {
         movement = m_Target.transform.forward * translateSpeed * Time.deltaTime;
      }
      else if (Direction.Backward == m_Translate)
      {
         movement = m_Target.transform.forward * -translateSpeed * Time.deltaTime;
      }
  
      if (null == m_Controller)
      {
         m_Target.transform.position += movement;
      }
      else
      {
         m_Controller.Move( movement );
      }

      // done translating/rotating?
      if (!m_FilterTranslation || Mathf.Abs(translateSpeed) <= 0.01)
      {
         m_Translate = Direction.None;
         m_Strafe    = Direction.None;
      }
      if (!m_FilterRotation || Mathf.Abs(rotateSpeed) <= 0.01)
      {
         m_Rotate = Direction.None;
      }

      // if done translating and rotating, clear target
      if (m_Rotate == Direction.None && m_Translate == Direction.None && m_Strafe == Direction.None)
      {
         m_Target = null;
      }
   }

}
