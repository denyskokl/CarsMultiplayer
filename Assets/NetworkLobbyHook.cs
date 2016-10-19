using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Prototype.NetworkLobby;


public class NetworkLobbyHook : LobbyHook {

	public override void OnLobbyServerSceneLoadedForPlayer (NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
	{
		LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer> ();
		IdentifyPlayer localPlayer = gamePlayer.GetComponent<IdentifyPlayer> ();

		localPlayer.pname = lobby.playerName;
		localPlayer.playerColor = lobby.playerColor;
	}
}
