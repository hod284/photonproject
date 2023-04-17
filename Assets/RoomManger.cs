using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            print("���� �� �̸� : " + PhotonNetwork.CurrentRoom.Name);
            print("���� �� �ο��� : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("���� �� �ִ��ο��� : " + PhotonNetwork.CurrentRoom.MaxPlayers);

            string playerStr = "�濡 �ִ� �÷��̾� ��� : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
