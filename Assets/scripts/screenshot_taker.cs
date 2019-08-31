using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenshot_taker : MonoBehaviour
{
    public static int image_index = 0;
     private static screenshot_taker instance;
    private  Camera myCamera;
    private bool takeScreenshotOnNextFrame;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();

        

    }
    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);
            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/captured_images/CameraScreenshot"+image_index+".png", byteArray);
            Debug.Log("saved CameraScreenshot.png");
            

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;


        }
    }

    private void takeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }

    public static void take_screenshot_static(int width, int height)
    {

        Debug.Log("took screenshot");
        instance.takeScreenshot(width, height);

        
    }
    public static void take_screenshot_static()
    {
        Debug.Log("took screenshot");
        instance.takeScreenshot(Screen.width, Screen.height);
    }


    // Update is called once per frame
    void Update()
    {


        
    }
}
