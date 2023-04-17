using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
public class Setdate : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        var data = DateManger.instance.datalist("¼­¿ï");
        for (int i = 0; i < data.Count; i++)
        {
           var a = Instantiate(prefab, parent.transform);
            var s = data[i].Split("\n").ToList();
            a.transform.GetChild(0).GetComponent<Text>().text = s[1];
            a.transform.GetChild(1).GetComponent<Text>().text = s[2];
            a.transform.GetChild(2).GetComponent<Text>().text = s[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
