using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class StartManger : MonoBehaviourPunCallbacks
{
    public TMP_Text title;
    public Button start;
    public TMP_Text gate;
    public void Awake()
    {
        DateManger.instance.Inite();
    }

    public void Conect()
    {
        title.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("���� ���� ���� �Ϸ�");
        StartCoroutine(load());
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log("���� ���� ������");
        PhotonNetwork.ConnectUsingSettings();
    }
    IEnumerator load()
    {
        var nowscene = SceneManager.LoadSceneAsync(1);
        nowscene.allowSceneActivation = false;
        while (!nowscene.isDone)
        {
            var number = nowscene.progress * 100.0f;
            gate.text = number.ToString() + "%";
            yield return null;
            nowscene.allowSceneActivation = true;
        }
    }
}
