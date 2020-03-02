using UnityEngine;
using SocketIO;

/// <summary>
/// Controla la conexión al servidor mediante socket.io.
/// </summary>
public class NetworkManagerSocket : SocketIOComponent
{
	[Header("Errors")]
	public string serverError = "Error al conectarse al servidor";

    public override void Start()
    {
        base.Start();

        On("connected", OnConnected);
    }

    /// <summary>
    /// Se ejecuta al conectarse al server socket.
    /// </summary>
    /// <param name="evt"></param>
    public void OnConnected(SocketIOEvent evt)
    {
        Debug.Log("connected to " + url);
    }
}
