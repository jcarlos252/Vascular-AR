using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor.VersionControl;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public UnityEngine.UI.Button[] answerButtons;
    public UnityEngine.UI.Image[] questionImages;
    public AlertManager alertManager;

    private int correctAnswers = 0;
    private int incorrectAnswers = 0;

    public RectTransform imagenRectTransform;
    public Vector2 posicionDeseadaImagen;
    public UnityEngine.UI.Button answer1;
    public UnityEngine.UI.Button answer2;
    public UnityEngine.UI.Button answer3;
    public UnityEngine.UI.Button answer4;
    public Vector2 posicionDeseada1;
    public Vector2 posicionDeseada2;
    public Vector2 posicionDeseada3;
    public Vector2 posicionDeseada4;


    private int currentQuestion = 0;
    private List<Question> questions;

    void Start()
    {
        // Obtén la lista de preguntas del QuizLoader
        QuizLoader quizLoader = FindObjectOfType<QuizLoader>();
        if (quizLoader != null)
        {
            questions = quizLoader.loadedQuestions;
        }
        else
        {
            Debug.LogError("No se ha encontrado el objeto QuizLoader.");
        }

        if (questions != null && questions.Count > 0)
        {
            ShowQuestion(currentQuestion);
        }
        else
        {
            Debug.LogError("No se han cargado preguntas.");
        }

    }

    void ShowQuestion(int questionIndex)
    {
        if (questionIndex < questions.Count)
        {
            questionText.text = questions[questionIndex].question;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                TextMeshProUGUI textMeshPro = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();

                if (textMeshPro != null)
                {
                    textMeshPro.text = questions[questionIndex].answers[i];
                }
                else
                {
                    Debug.LogError("No se encontró un componente TextMeshProUGUI en el botón " + i);
                }

            }

            // Verifica si hay imágenes para mostrar
            if (questions[questionIndex].imagePaths != null && questions[questionIndex].imagePaths.Length > 0)
            {
                int numberOfImagesToShow = questions[questionIndex].imagePaths.Length;

                for (int i = 0; i < questionImages.Length; i++)
                {
                   if (questionIndex == 1)
                    {
                        RectTransform botonRectTransform1 = answer1.GetComponent<RectTransform>();
                        botonRectTransform1.anchoredPosition = posicionDeseada1;
                        RectTransform botonRectTransform2 = answer2.GetComponent<RectTransform>();
                        botonRectTransform2.anchoredPosition = posicionDeseada2;
                        RectTransform botonRectTransform3 = answer3.GetComponent<RectTransform>();
                        botonRectTransform3.anchoredPosition = posicionDeseada3;
                        RectTransform botonRectTransform4 = answer4.GetComponent<RectTransform>();
                        botonRectTransform4.anchoredPosition = posicionDeseada4;

                    }

                    if (questionIndex == 2)
                    {
                        imagenRectTransform.anchoredPosition = posicionDeseadaImagen;
                   
                    }
                    if (i < numberOfImagesToShow)
                    {
                        questionImages[i].gameObject.SetActive(true);
                        // Asegúrate de cargar y asignar las imágenes correctamente
                        questionImages[i].sprite = Resources.Load<Sprite>(questions[questionIndex].imagePaths[i]);
                       
                    }
                    else
                    {
                        questionImages[i].gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                // Si no hay imágenes, asegúrate de desactivar todos los objetos de imagen
                foreach (var image in questionImages)
                {
                    image.gameObject.SetActive(false);
                }
            }
        }
    }


    public void CheckAnswer(int answerIndex)
    {
        if (currentQuestion < questions.Count)
        {
            if (answerIndex == questions[currentQuestion].correctAnswerIndex)
            {
                correctAnswers++;
                alertManager.alertText.color = Color.green;
                alertManager.ShowAlert("CORRECT");
            }
            else
            {
                incorrectAnswers++;
                alertManager.alertText.color = Color.red;
                alertManager.ShowAlert("INCORRECT");
            }

            currentQuestion++;

            if (currentQuestion < questions.Count)
            {
                ShowQuestion(currentQuestion);
            }
            else
            {
          
                Debug.Log("Fin del quiz");

                PlayerPrefs.SetInt("CorrectAnswers", correctAnswers);
                PlayerPrefs.SetInt("IncorrectAnswers", incorrectAnswers);

                SceneManager.LoadScene("QuizResults"); // Cambiar a la nueva escena.
                }
            }
        }
    }
