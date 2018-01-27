using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControler : MonoBehaviour {


	public float mFramerate;
	public float mBoostedFramerate;
	public Camera mCamera;
	RenderTexture mTexture;

	private AudioSource auds;

    public GameObject radarFlashEffect;
    float flashValue = 1;

	// Use this for initialization
	void Start () {
		mTexture = null;
		//mCamera.enabled = false;

		if (GetComponent<AudioSource>() != null)
			auds = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (flashValue > 0)
		{
			flashValue -= 0.05f;
		}
		else
		{
			flashValue = 0;
		}

		if (radarFlashEffect != null)
		{
			radarFlashEffect.GetComponent<Image> ().color = new Color (0, 1, 0, flashValue);
		}
    }

	//Take the camera's input for the current frame and save it like a screenshot
	//I DO NOT TAKE CREDIT FOR THIS CODE, original author can be found at: (1)
	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		//If this is the first frame, set the texture as the current frame from the camera
		if (mTexture == null) 
		{
			mTexture = Instantiate (src) as RenderTexture;

		}

		//When the desired framerate has been met, set the current "screenshot" of the screen as the current display
		if (Time.frameCount % mFramerate == 0)
        {
            Graphics.Blit(src, mTexture);

            if (radarFlashEffect != null)
            {
                flashValue = 1;
                radarFlashEffect.GetComponent<Image>().color = new Color(0, 1, 0, flashValue);
				if (auds != null)
				{
					auds.Stop ();
					auds.Play ();
				}
            }
        }

        //Set the current texture as the displayed image
        Graphics.Blit (mTexture, dest);
	}
}
