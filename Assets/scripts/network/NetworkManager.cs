using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Controla la conexión al servidor mediante Express.
/// </summary>
public class NetworkManager : MonoBehaviour
{
    [Tooltip("Activar para usar Express server. Desactivar para usar Socket server.")]
    public bool serverExpress = true;

	[Header("Config")]
	public string url;

	[Header("Errors")]
	public string serverError = "Error al conectarse al servidor";

    public virtual void Start()
    {
        if (serverExpress)
        {
            StartCoroutine(ConnectTo(url));
        }
    }

    /// <summary>
    /// Se conecta al servidor de la url indicada.
    /// </summary>
    /// <param name="url">Url del servidor</param>
    /// <returns></returns>
    public IEnumerator ConnectTo(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
				Utils.ShowError(serverError);
            }
            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(result);
                }
                else
                {
                    Utils.ShowError(serverError);
                }
            }
        }
    }
}
