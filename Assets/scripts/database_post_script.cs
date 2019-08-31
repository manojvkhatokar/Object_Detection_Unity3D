using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class database_post_script : MonoBehaviour
{

    public InputField image;
    public InputField image_url;
    // Start is called before the first frame update
     void Start()
    {
        StartCoroutine(send_data());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator send_data()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/object_detection_connection.php"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;

            }

           

        }

        WWWForm form = new WWWForm();
        form.AddField("image", image.text);
        form.AddField("image_url", image_url.text);

        WWW www1 = new WWW("http://localhost/object_detection_connnection.php", form);
        yield return www1;

        //if (www1.text[0] == '0')
        //{
        //    DBManager.username = usernameField.text;
        //    SceneManager.LoadScene(2);
        // Debug.Log("LoggedIn");

        //}
        //else
        //{
        //    errorDisplay.text = "Incorrect Details";
        //    Debug.Log("Login Failed #" + www1.text);
        //}

    }

}
