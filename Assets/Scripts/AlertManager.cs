using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlertManager : MonoBehaviour
{
    public TextMeshProUGUI alertText;

    private void Start()
    {
        alertText.gameObject.SetActive(false); // Aseg�rate de que la ventana de alerta est� desactivada al inicio.
    }

    public void ShowAlert(string message)
    {
        alertText.text = message;
        alertText.gameObject.SetActive(true);
        Invoke("HideAlert", 1.0f); // Invoca el m�todo HideAlert despu�s de 2 segundos.
    }

    public void HideAlert()
    {
        alertText.gameObject.SetActive(false);
    }
}