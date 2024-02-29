using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;
    public string[] imagePaths;
}

[System.Serializable]
public class QuestionData
{
    public List<Question> questions;
}

public class QuizLoader : MonoBehaviour
{
    public TextAsset quizData; // El archivo JSON que importaste en Resources
    public List<Question> loadedQuestions;

    void Start()
    {
        loadedQuestions = new List<Question>();
        if (quizData != null)
        {
            QuestionData questionData = JsonUtility.FromJson<QuestionData>(quizData.text);
            loadedQuestions = questionData.questions;
            


        }
        else
        {
            Debug.LogError("No se ha encontrado el archivo JSON.");
        }
    }
}