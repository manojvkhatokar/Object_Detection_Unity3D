using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class image_upload_to_php_file : MonoBehaviour
{
    public InputField port_forwarding_ip_address;
    public static string ipaddress;

    public void upload_data_to_php_file()
    {

        WWWForm form = new WWWForm();
        byte[] byteArray = File.ReadAllBytes(Application.dataPath + "/captured_images/per_session_images/CameraScreenshot" + screenshot_taker.image_index + ".png");
        form.AddBinaryData("image_blob_data", byteArray, Application.dataPath + "/captured_images/per_session_images/CameraScreenshot" + screenshot_taker.image_index + ".png");

        StartCoroutine(upload_data_to_php_file_ienumerator());
        

    }
   

    IEnumerator upload_data_to_php_file_ienumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("image", "image"+screenshot_taker.image_index+"added");
        form.AddField("image_url", Application.dataPath+"/captured_images/per_session_images/CameraScreenshot"+screenshot_taker.image_index+".png");

        if (port_forwarding_ip_address.text == "")
        {
            //ipaddress = "http://localhost/object_detection_connection.php";
            Debug.Log(" using firebase database now");

        }
        else
        ipaddress = "http://"  + port_forwarding_ip_address.text + "/object_detection_connection.php";
        WWW www = new WWW(ipaddress, form);
        yield return www;

        if(www.text == "")
        {
            Debug.Log(" image not uploaded to php file");
        }
        else
        {
            Debug.Log(" image successfully sent to php file");

        }

        //using (UnityWebRequest www2 = UnityWebRequest.Post(ipaddress,form))
        //{
        //    yield return www2.SendWebRequest();

        //    if (www2.isNetworkError || www2.isHttpError)
        //    {
        //        Debug.Log(www2.error);
        //    }
        //    else
        //    {
        //        Debug.Log(www2.downloadHandler.text);

               

        //    }



        //}

    }

    




}