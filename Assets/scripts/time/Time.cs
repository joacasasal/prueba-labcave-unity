using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// Permite obtener datos del tiempo.
/// </summary>
public class Time : MonoBehaviour
{
    private const string URLTIME = "/time";

    public GameObject timeText;

    [Header("Errors")]
    public string timeError = "Error al obtener la hora";

    /// <summary>
    /// Obtiene la fecha actual.
    /// </summary>
    public void GetCurrentTime()
    {
        StartCoroutine(GetCurrentTimeCo());
    }
    public IEnumerator GetCurrentTimeCo()
    {
        GameObject networkManager = GameObject.FindGameObjectWithTag("NetworkManager");
        if (networkManager)
        {
            string url = networkManager.GetComponent<NetworkManager>().url + URLTIME;
            using (UnityWebRequest www = UnityWebRequest.Get(url))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError)
                {
                    Utils.ShowError(timeError);
                    Debug.Log(timeError);
                }
                else
                {
                    if (www.isDone && www.downloadHandler != null)
                    {
                        var timeData = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                        if (timeData != null)
                        {
                            timeText.GetComponent<Text>().text = timeData;
                            Debug.Log(timeData);
                        }
                        else
                        {
                            Utils.ShowError(timeError);
                        }
                    }
                    else
                    {
                        Utils.ShowError(timeError);
                    }
                }
            }
        }
    }
}
