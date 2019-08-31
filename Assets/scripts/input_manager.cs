using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_manager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            ++screenshot_taker.image_index;
            Debug.Log(" pressed key k");
            screenshot_taker.take_screenshot_static();
        }


    }
    public void post_to_database()
    {

    }

}

