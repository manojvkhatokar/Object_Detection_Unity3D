using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class input_manager : MonoBehaviour
{
   public AudioSource camera_shutter_sound;

    private void Awake()
    {
        
        Directory.Delete(Application.dataPath + "/captured_images/per_session_images",true);
        Directory.CreateDirectory(Application.dataPath + "/captured_images/per_session_images");
        Debug.Log(" created per_session_images directory successfully");

    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            play_camera_shutter_sound();

            ++screenshot_taker.image_index;
            Debug.Log(" pressed key z");
            screenshot_taker.take_screenshot_static();
        }


    }
    public void post_to_database()
    {

    }

    public void play_camera_shutter_sound()
    {
        camera_shutter_sound.Play();
    }

    public void take_screenshot()
    {
        ++screenshot_taker.image_index;
        screenshot_taker.take_screenshot_static();
    }
    

}

