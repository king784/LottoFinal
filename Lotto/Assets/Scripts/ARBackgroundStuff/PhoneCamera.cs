using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;//if camera is avaialble
    private WebCamTexture backCam;//camera background
    private Texture defaultBackground;//default for rollback

    public RawImage background;//raw works better
    public AspectRatioFitter fitter;//size of the background texture idk

    //trouble shooting variables
    public TMP_Text e1;
    public TMP_Text e2;
    public TMP_Text e3;
    public TMP_Text e4;

    private void Start()
    {
        defaultBackground = background.texture;//get the rollback from the background given in editor
        WebCamDevice[] devices = WebCamTexture.devices;//add camera's to an array
        if (devices.Length == 0)//oh no there aren't any cameras available
        {
            Debug.Log("No camera detected.");
            camAvailable = false;
            return;//let's just stop here -_-
        }

        for (int i = 0; i < devices.Length; i++)//go through all available cameras
        {
            if (!devices[i].isFrontFacing)//if camera isn't the front camera
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);//back camera is stored with the given values
                e2.text = "found a camera that wasn't front facing";
            }
        }

        if (backCam == null)//back cam wasn't actually found after all
        {
            Debug.Log("No back camera found :( .");
            return;
        }

        backCam.Play();//this makes the device use the camera
        e3.text = "camera was set to play";
        background.texture = backCam;//make the camera view be the background texture
        camAvailable = true;
    }

    private void Update()
    {
        if (!camAvailable)
        {
            e1.text = "no camera available";
            return;
        }

        if (camAvailable)
        {
            e1.text = "Camera is available";
        }

        float ratio = (float)backCam.width / (float)backCam.height;//get the precise heigh and width with float
        fitter.aspectRatio = ratio;//get the aspect ratio

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;//check if flipped
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);//background is scaled properly
        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);//background orientation follows the camera view


        e4.text = string.Format($"Ratio: {ratio}, scaleY: {scaleY}, orient: {orient}, background: {background.ToString()}");
    }
}
