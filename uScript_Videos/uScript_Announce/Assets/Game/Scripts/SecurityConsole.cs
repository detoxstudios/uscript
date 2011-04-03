using UnityEngine;
using System.Collections;

public class SecurityConsole : MonoBehaviour
{
   private bool m_AlarmHacked = false;
   public bool AlarmHacked { get { return m_AlarmHacked; } }

   public GameObject DoorFrame;
   public GameObject SecurityScreen;
   public GameObject DoorPointLight;

   public Material HackedMaterial;

   private bool m_InTrigger = false;

   // Use this for initialization
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

      if (Input.GetKeyUp("h"))
      {
         
         if ( m_InTrigger )
         {
            
            if ( false == m_AlarmHacked )
            {
               this.audio.Play();
               m_AlarmHacked = true;

               // Swap Materials & make door pointlight green
               SecurityScreen.renderer.material = HackedMaterial;

               Material[] tmpMaterials = DoorFrame.renderer.materials;
               tmpMaterials[1] = HackedMaterial;
               DoorFrame.renderer.materials = tmpMaterials;

               DoorPointLight.light.color = Color.green;

            }
         }

      }

   }

   void OnTriggerEnter(Collider other)
   {
      m_InTrigger = true;
   }

   void OnTriggerExit(Collider other)
   {
      m_InTrigger = false;
   }

   void OnGUI()
   {
      if (m_InTrigger)
      {
         if (m_AlarmHacked)
         {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 256, 64), "Alarm hacked!");
         }
         else
         {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 256, 64), "Press 'H' to hack!");
         }
      }
   }
}



