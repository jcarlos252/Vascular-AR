using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageController : MonoBehaviour
{
    public Sprite[] images; // Arrastra tus imágenes aquí desde el proyecto.
    public Image imageDisplay;
    public Button nextButton;
    public Button prevButton;
    public int currentImageIndex = 0;

    private void Start()
    {
        imageDisplay.sprite = images[currentImageIndex];
        UpdateButtonsInteractivity();
    }

    public void ShowNextImage()
    {
        currentImageIndex++;
        if (currentImageIndex < images.Length)
        {
            imageDisplay.sprite = images[currentImageIndex];
        }
        UpdateButtonsInteractivity();
        
    }

    public void ShowPreviousImage()
    {
        currentImageIndex--;
        if (currentImageIndex >= 0)
        {
            imageDisplay.sprite = images[currentImageIndex];
        }
        UpdateButtonsInteractivity();
    }

    private void UpdateButtonsInteractivity()
    {
        nextButton.interactable = currentImageIndex < images.Length - 1;
        prevButton.interactable = currentImageIndex > 0;
    }

    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("TrainingMenu"); // Cambia "MainScene" al nombre de tu escena principal.
    }
}