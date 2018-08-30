using UnityEngine;

namespace Detox
{
    public class ExampleUtil : MonoBehaviour
    {
        void Start()
        {
            // Add the master component if it doesn't exist yet
            if (GameObject.FindObjectOfType<uScript_MasterComponent>() == null)
            {
                var go = GameObject.Find(uScriptRuntimeConfig.MasterObjectName);
                if (go == null) go = new GameObject(uScriptRuntimeConfig.MasterObjectName);
                go.AddComponent<uScript_MasterComponent>();
            }
        }
    }
}
