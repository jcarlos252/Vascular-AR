using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UltrasoundProcedure : MonoBehaviour
{
    // Start is called before the first frame update


    public void GoToQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }
}
