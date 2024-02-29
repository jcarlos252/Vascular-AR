using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizResults : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    // Start is called before the first frame update
    void Start()
    {
        // Recuperar las respuestas correctas e incorrectas almacenadas en PlayerPrefs
        int respuestasCorrectas = PlayerPrefs.GetInt("CorrectAnswers", 0);
        int respuestasIncorrectas = PlayerPrefs.GetInt("IncorrectAnswers", 0);

        // Mostrar los resultados en un Text o cualquier otro componente UI
        if (resultText != null)
        {
            resultText.text = "Correct answers: " + respuestasCorrectas + "\nIncorrect answers: " + respuestasIncorrectas;
        }
        else
        {
            Debug.LogError("No se ha asignado un componente Text para mostrar los resultados.");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButton()
    {
        SceneManager.LoadScene("TrainingMenu");
    }
}
