#if (UNITY_EDITOR)
using UnityEngine;
using System.Collections;
using System.IO;

public class GetWatermarkData : MonoBehaviour
{

   private bool keybool = true;


   // Use this for initialization
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

      if (Input.GetKey("up") & keybool)
      {
         keybool = false;
         Debug.Log("Creating Watermark byte text file...\n");
         // Import the texture data
         
         // Take the .PNG file and rename the exstension to ".bytes"
         // Specify the filename to use:
         string ImageFileName = "uScript_WatermarkBytes"; // uScript_WatermarkBytes.bytes
         TextAsset WatermarkDataOut = Resources.Load(ImageFileName) as TextAsset;

         // Write out the bytes to a text file:
         string allBytes = "";
         foreach (byte singleByte in WatermarkDataOut.bytes)
         {
            allBytes = allBytes + singleByte.ToString() + ",";
         }
         using (StreamWriter writer = new StreamWriter("WatermarkDataOutput.txt")) // File will appear in root project folder.
         {
            writer.Write(allBytes);
         }
         Debug.Log("File created!\n");
         keybool = true;
      }

   }


  
}

#endif
