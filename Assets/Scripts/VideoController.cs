using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class VideoController : MonoBehaviour
{
    public VideoClip[] videoClips; // Arrastra tus videos aquí desde el proyecto.
    public VideoPlayer videoPlayer;
    public Button close;
    private int currentVideoIndex = 0;

    private void Start()
    {
       
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.clip = videoClips[currentVideoIndex];
        videoPlayer.Play();
        Image imagenBoton = close.GetComponent<Image>();
        imagenBoton.enabled = true;

    }

    public void PlayNextVideo()
    {
        currentVideoIndex++;
        if (currentVideoIndex < videoClips.Length)
        {
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.Play();

        }
        else
        {
            currentVideoIndex--;
            Debug.Log("Has llegado al final de los videos.");
            SceneManager.LoadScene("UltrasoundProcedure");


        }
    }

    public void PlayPreviousVideo()
    {
        // Verifica si hay un video anterior disponible.
        if (currentVideoIndex > 0)
        {
            currentVideoIndex--;
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.Play();
        }
        else
        {
            Debug.Log("Ya estás en el primer video.");
        }
    }
}