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

    public static string data = "";



    public void upload_data_to_php_file()
    {

        WWWForm form = new WWWForm();
        //byte[] byteArray = File.ReadAllBytes(Application.dataPath + "/captured_images/per_session_images/CameraScreenshot" + screenshot_taker.image_index + ".png");
        //form.AddBinaryData("image_blob_data", byteArray, Application.dataPath + "/captured_images/per_session_images/CameraScreenshot" + screenshot_taker.image_index + ".png");

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

        else if(port_forwarding_ip_address.text == "localhost")
        {
            ipaddress = "http://localhost/object_detection_connection.php";

        }
        else
        {
            ipaddress = "http://" + port_forwarding_ip_address.text + "/object_detection_connection.php";
        }
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




        // Encode texture into PNG
        //byte[] bytes = screenshot_taker.renderResult.EncodeToJPG();
        // Create a Web Form
        //WWWForm form = new WWWForm();
        //form.AddField("frameCount", Time.frameCount.ToString());
        //form.AddBinaryData("image_blob_data", bytes, "captured_image.jpg", "image/jpg");
        // Upload to a cgi script
        //using (var w = UnityWebRequest.Post("/opt/lampp/cgi-bin/test-cgi", form))
        //{
        //    w.chunkedTransfer = false;
        //    yield return w.SendWebRequest();
        //    if (w.error != null)
        //    {
        //        print("error" + w.error);
        //    }
        //    else
        //    {
        //        print("Finished Uploading Captured Image: " + w.responseCode);
        //    }
        //}



        //   data="hi";
        //JsonUtility.ToJson(data);
        //Debug.Log(data);

        //using (UnityWebRequest www_json = UnityWebRequest.Put("0.0.0.0:5000/predict", data))

        //{
        //    www_json.SetRequestHeader("Content-Type", "application/json");
        //    //Debug.Log("");

        //}   


        //######################################trying this out still for json direct send to flask_app.py
        string json = "hi";
        var jsonBinary = System.Text.Encoding.UTF8.GetBytes(json);

        DownloadHandlerBuffer downloadHandlerBuffer = new DownloadHandlerBuffer();

        UploadHandlerRaw uploadHandlerRaw = new UploadHandlerRaw(jsonBinary);
        uploadHandlerRaw.contentType = "application/json";

        UnityWebRequest www_json =
            new UnityWebRequest("0.0.0.0:5000/predict", "POST", downloadHandlerBuffer, uploadHandlerRaw);

        yield return www_json.SendWebRequest();

        if (www_json.isNetworkError)
            Debug.LogError(string.Format("{0}: {1}", www_json.url, www_json.error));
        else
            Debug.Log(string.Format("Response: {0}", www_json.downloadHandler.text));
    
    
    }

    




}