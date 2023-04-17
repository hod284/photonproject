using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using System.Linq;
using TMPro;
public class Networkmanger : MonoBehaviourPunCallbacks
{
    public GameObject RoomLIst;
    public TMP_InputField input;
    public TMP_Dropdown Max;
    public Button RoomEnterButton;
    public int Maxpeople;

    public void Awake()
    {
        Max.onValueChanged.AddListener(delegate { Count(Max.value); });
    }
    public void Count(int c)
    {
      int.TryParse(Max.transform.GetChild(0).GetComponent<TMP_Text>().text, out Maxpeople);
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
   
    }
   
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("main");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("规 曼啊 角菩\n" + message);
    }
    public void Creatroom()
    {
        var ROOM = GameObject.Instantiate(RoomEnterButton, RoomLIst.transform);
        ROOM.transform.GetChild(0).GetComponent<TMP_Text>().text = input.text;
        PhotonNetwork.CreateRoom(input.text, new RoomOptions { MaxPlayers =(byte)Maxpeople });
       
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log(input.text + "规积己 己傍");
    }


    // Update is called once per frame
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        int roomcount = RoomLIst.transform.childCount;
        var namelist_before = new List<string>();
        for (int i = 0; i < roomcount; i++)
            namelist_before.Add(RoomLIst.transform.GetChild(i).gameObject.name);
        var namelist_now = roomList.Select(x => x.Name).ToList();
        if (namelist_before.Count != namelist_now.Count)
        {
            if (namelist_before.Count > namelist_now.Count)
            {
                var list = namelist_before.Where(x => !namelist_now.Contains(x)).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    var degameobject = RoomLIst.transform.Find(list[i]);
                    Destroy(degameobject);
                }
            }
            else
            {
                var list = namelist_now.Where(x => !namelist_before.Contains(x)).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    var nowroom = Instantiate(RoomEnterButton, RoomLIst.transform);
                    nowroom.name = list[i];
                }
            }
        }
    }
}
