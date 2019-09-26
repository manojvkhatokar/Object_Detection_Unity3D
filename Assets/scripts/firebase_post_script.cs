using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;


public class firebase_post_script : MonoBehaviour
{
    public void post_to_firebase()
    {
        
        Image_class image = new Image_class();
        RestClient.Put("https://flask-3a1fb.firebaseio.com/.json", image);
        Debug.Log(" posting to firebase done");
        

    }
}
