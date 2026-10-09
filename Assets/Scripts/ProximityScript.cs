using UnityEngine;

public class ProximityScript : MonoBehaviour
{/*
    private bool isCamUsable;
    private WebCamTexture camera;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        
        if(devices.Length == 0)
        {
            isCamUsable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                camera = new WebCamTexture(devices[i].name, Screen.width, Screen.height, 60);
            }
        }

        if(camera == null)
        {
            return;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(!isCamUsable)
        {
            return;
        }

        float ratio = (float.Parse(camera.width.ToString())) / float.Parse(camera.height.ToString());
        fit.aspectRatio = ratio;

        float scaleY = camera.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -camera.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }*/
}
