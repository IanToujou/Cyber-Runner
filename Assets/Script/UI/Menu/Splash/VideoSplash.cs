using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoSplash : MonoBehaviour {

    private static bool hasStarted = false;
    private VideoPlayer player;

    void Start() {

        player = gameObject.GetComponent<VideoPlayer>();

        //Change the canvas alpha depending on the video start.
        if(hasStarted)
        {
            MenuUI.DeactivateAllCanvas();
            player.targetCameraAlpha = 0f;
        } else
        {
            player.targetCameraAlpha = 1.0f;
        }

    }
    
    void Update() {

        //Start the fading animation once.
        if(!hasStarted)
        {
            if (player.time >= 5.0f)
            {
                StartCoroutine(FadeVideoPlayerAlpha(player, 0, 1f));
                hasStarted = true;
            }
        }

    }
    
    public static IEnumerator FadeVideoPlayerAlpha(VideoPlayer player, int direction, float fadeSpeed) {

        if (player.renderMode == UnityEngine.Video.VideoRenderMode.CameraNearPlane || player.renderMode == UnityEngine.Video.VideoRenderMode.CameraFarPlane || player.renderMode == UnityEngine.Video.VideoRenderMode.RenderTexture)
        {
            RawImage rawImage = null;
            if (player.renderMode == UnityEngine.Video.VideoRenderMode.RenderTexture)
            {
                player.gameObject.TryGetComponent<RawImage>(out rawImage);
                if (!rawImage) Debug.LogWarning("No RawImage on the VideoPlayer GameObject found. -> (" + player.gameObject.name + ")");
            }

            float alpha = (direction == 0) ? 1f : 0f;
            float fadeEndValue = (direction == 0) ? 0f : 1f;

            if (direction == 0)
            {
                while (alpha >= fadeEndValue)
                {
                    alpha -= Time.deltaTime * fadeSpeed;
                    if (rawImage) rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, alpha);
                    else player.targetCameraAlpha = alpha;
                    yield return null;
                }
                player.Stop();
                if (rawImage) rawImage.enabled = false;
                MenuUI.SetActiveCanvas(MenuUI.MAIN);
            } else {

                //Make sure alpha is 0
                if (rawImage) rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, alpha);
                else player.targetCameraAlpha = alpha;

                //Enable the RawImage and start the player
                if (rawImage) rawImage.enabled = true;
                player.Play();

                //Delay, to make sure the Image has the correct Texture
                yield return new WaitForSeconds(0.1f);

                while (alpha <= fadeEndValue)
                {
                    alpha += Time.deltaTime * fadeSpeed;
                    if (rawImage) rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, alpha);
                    else player.targetCameraAlpha = alpha;
                    yield return null;
                }
            }
        } else {
            Debug.LogWarning("VideoRenderMode (for alpha) must be RenderTexture, CameraFarPlane or CameraNearPlane. GameObject -> (" + player.gameObject.name + ")");
        }
    }
    
}
