using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class DefaultRoom
{
    public string Name;
    public string sceneName;
    public int maxPlayer;
}

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public List<DefaultRoom> defaultRooms;
    public GameObject roomUI;

    void Start()
    {
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.NickName = "Sungkyul"; // �÷��̾� �̸�
        PhotonNetwork.AutomaticallySyncScene = true; // ������ Ŭ���̾�Ʈ�� ����ȭ
    }

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("������ ������ �õ��մϴ�.");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("������ ����Ǿ����ϴ�.");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("���ǿ� �����Ͽ����ϴ�.");
        roomUI.SetActive(true);
    }

    public void InitiliazeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        PhotonNetwork.LoadLevel(roomSettings.sceneName);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("�濡 �����Ͽ����ϴ�.");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("���ο� �÷��̾ �����Ͽ����ϴ�.");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
