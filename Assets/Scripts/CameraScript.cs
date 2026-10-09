using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
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

        if (devices.Length == 0)
        {
            Debug.Log("No Camera Available");
            isCamUsable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                camera = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (camera == null)
        {
            Debug.Log("Unable to find the Back Camera");
            return;
        }

        camera.Play();
        background.texture = camera;
        isCamUsable = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isCamUsable)
        
            return;
        

        float ratio = (float.Parse(camera.width.ToString())) / float.Parse(camera.height.ToString());
        fit.aspectRatio = ratio;

        float scaleY = camera.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -camera.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }


}
