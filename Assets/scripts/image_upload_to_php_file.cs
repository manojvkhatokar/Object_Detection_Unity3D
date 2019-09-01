using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class image_upload_to_php_file : MonoBehaviour
{

    public void upload_data_to_php_file()
    {
        StartCoroutine(upload_data_to_php_file_ienumerator());
    }

    IEnumerator upload_data_to_php_file_ienumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("image", "image"+screenshot_taker.image_index+"added");
        form.AddField("image_url", Application.dataPath+ "/captured_images/per_session_images/CameraScreenshot" + screenshot_taker.image_index + ".png");
        

        WWW www = new WWW("http://localhost/object_detection_connection.php", form);
        yield return www;

        if(www.text == "")
        {
            Debug.Log(" image not uploaded to php file");
        }
        else
        {
            Debug.Log(" image successfully sent to php file");

        }
    }

    




}