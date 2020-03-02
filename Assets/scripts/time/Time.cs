using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SocketIO;

/// <summary>
/// Permite obtener datos del tiempo.
/// </summary>
public class Time : MonoBehaviour
{
    private const string URLTIME = "/time";

    public GameObject timeText;

    [Header("Errors")]
    public string timeError = "Error al obtener la hora";


    private SocketIOComponent socket;

    void Start()
    {
        GameObject networkManager = GameObject.FindGameObjectWithTag("NetworkManager");
        if (!networkManager.GetComponent<NetworkManager>().serverExpress) // Socket
        {
            socket = networkManager.GetComponent<NetworkManagerSocket>();

            socket.On("getTimeCallback", OnGetTime);
        }
    }

    /// <summary>
    /// Obtiene la fecha actual.
    /// </summary>
    public void GetCurrentTime()
    {
        GameObject networkManager = GameObject.FindGameObjectWithTag("NetworkManager");

        if (networkManager && networkManager.GetComponent<NetworkManager>())
        {
            if (networkManager.GetComponent<NetworkManager>().serverExpress) // Express
            {
                StartCoroutine(GetCurrentTimeExpress(networkManager));
            }
            else // Socket
            {
                GetCurrentTimeSocket();
            }
        }
    }

    /// <summary>
    /// Obtiene la fecha actual desde el servidor express.
    /// </summary>
    /// <param name="networkManager"></param>
    /// <returns></returns>
    public IEnumerator GetCurrentTimeExpress(GameObject networkManager)
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

    /// <summary>
    /// Obtiene la fecha actual desde el servidor socket.
    /// </summary>
    public void GetCurrentTimeSocket()
    {
        if (socket.ws.IsConnected)
        {
            socket.Emit("getTime");
        } else
        {
            Utils.ShowError(timeError);
        }
    }

    /// <summary>
    /// Obtiene la fecha del callback de getTime.
    /// </summary>
    /// <param name="evt">Datos del callback</param>
    public void OnGetTime(SocketIOEvent evt)
    {
        if (evt.data)
        {
            var timeData = evt.data.GetField("currentTime");
            if (timeData != null)
            {
                timeText.GetComponent<Text>().text = timeData.str;
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
