using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
public class roomenterbutton : MonoBehaviour
{
    public TMP_Text name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        PhotonNetwork.JoinRoom(name.ToString());
    }
}
