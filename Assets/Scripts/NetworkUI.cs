using Unity.Netcode;
using UnityEngine;

public class NetworkUI : MonoBehaviour
{
    private void OnGUI()
    {
        // Keep the interface in the top-left corner.
        GUILayout.BeginArea(new Rect(10, 10, 250, 250));

        GUILayout.BeginVertical("box");

        GUILayout.Label("UNITY SLITHER.IO LAB");

        var manager = NetworkManager.Singleton;

        if (manager == null)
        {
            GUILayout.Label("NetworkManager not found!");
            GUILayout.EndVertical();
            GUILayout.EndArea();
            return;
        }

        if (manager.IsHost)
            GUILayout.Label("Status: HOST");
        else if (manager.IsServer)
            GUILayout.Label("Status: SERVER");
        else if (manager.IsClient)
            GUILayout.Label(manager.IsConnectedClient
                ? "Status: CLIENT CONNECTED"
                : "Status: CONNECTING");
        else
            GUILayout.Label("Status: DISCONNECTED");

        if (GUILayout.Button("Stop (Shutdown)"))
        {
            if (manager != null && manager.IsListening)
            {
                manager.Shutdown();
            }
        }
        else
        {
            if (GUILayout.Button("Start Host", GUILayout.Height(35)))
            {
                manager.StartHost();
            }

            if (GUILayout.Button("Start Client", GUILayout.Height(35)))
            {
                manager.StartClient();
            }



            if (GUILayout.Button("Start Server", GUILayout.Height(35)))
            {
                manager.StartServer();
            }

            
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}