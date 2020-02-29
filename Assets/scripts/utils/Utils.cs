using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Métodos útiles comunes.
/// </summary>
public static class Utils
{
    /// <summary>
    /// Muestra un pop-up con un mensaje de error.
    /// </summary>
    /// <param name="errorMsg">Mensaje a mostrar</param>
    public static void ShowError(string errorMsg)
    {
        GameObject errorAlert = GameObject.FindGameObjectWithTag("ErrorAlert");
        if (errorAlert)
        {
            errorAlert.GetComponentInChildren<Text>().text = errorMsg;
            errorAlert.GetComponent<Animator>().Play("Active");
        }
        Debug.Log(errorMsg);
    }
}