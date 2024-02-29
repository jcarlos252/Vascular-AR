using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlertManager : MonoBehaviour
{
    public TextMeshProUGUI alertText;

    private void Start()
    {
        alertText.gameObject.SetActive(false); // Asegúrate de que la ventana de alerta esté desactivada al inicio.
    }

    public void ShowAlert(string message)
    {
        alertText.text = message;
        alertText.gameObject.SetActive(true);
        Invoke("HideAlert", 1.0f); // Invoca el método HideAlert después de 2 segundos.
    }

    public void HideAlert()
    {
        alertText.gameObject.SetActive(false);
    }
}