using UnityEngine;
using System.Collections;


public class AlarmTrigger : MonoBehaviour
{

   public GameObject SecurityConsoleScreen;
   public GameObject[] AlarmLights;
   public GameObject SecurityDoor;
   public GameObject SecurityConsoleTrigger;
   


   private SecurityConsole m_SecurityConsole = null;

   private bool m_ShouldRotate = false;


   // Use this for initialization
   void Start()
   {
      m_SecurityConsole = SecurityConsoleTrigger.GetComponent<SecurityConsole>();
   }

   // Update is called once per frame
   void Update()
   {

      if ( m_ShouldRotate && false == m_SecurityConsole.AlarmHacked )
      {
         float speed = 360f;
         bool op = false;
         foreach ( GameObject SingleLight in AlarmLights )
         {
            if (op)
            {
               SingleLight.transform.Rotate(0, speed * Time.deltaTime, 0);

               op = false;
            }
            else
            {
               SingleLight.transform.Rotate(0, -speed * Time.deltaTime, 0);
               op = true;
            }
         }

      }

   }


   void OnTriggerEnter(Collider other)
   {

      if ( false == m_SecurityConsole.AlarmHacked )
      {
         foreach ( GameObject SingleLight in AlarmLights )
         {
            m_ShouldRotate = true;
            SingleLight.active = true;
         }

         SecurityDoor.animation["ModoAnim"].speed = 2.5f;
         SecurityDoor.animation.Play(PlayMode.StopAll);

         this.audio.Play();
      }

   }


   void OnTriggerExit(Collider other)
   {

      if ( false == m_SecurityConsole.AlarmHacked )
      {
         foreach (GameObject SingleLight in AlarmLights)
         {
            SingleLight.active = false;
            m_ShouldRotate = false;
         }

         SecurityDoor.animation["ModoAnim"].speed = -2.5f;
         SecurityDoor.animation["ModoAnim"].time = SecurityDoor.animation["ModoAnim"].length;
         SecurityDoor.animation.Play(PlayMode.StopAll);

         this.audio.Stop();
      }

   }

}
