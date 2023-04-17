using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class singlton <T> :MonoBehaviour where T: MonoBehaviour
{
     private  static T _instance;
    private static object m_lock = new object();
    private static bool nowinstance= false;

    public static T instance
    {

        get
        {
            if (nowinstance)
            {
                Debug.Log("�̹� ����");
                return _instance;
            }
            lock (m_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
                    if (_instance == null)
                    {

                        var ob = new GameObject();
                        _instance = ob.AddComponent<T>();
                        ob.gameObject.name = typeof(T).Name;
                        nowinstance = true;
                        Debug.Log("�ν��Ͻ� ����");
                        DontDestroyOnLoad(ob);
                    }
                }
                return _instance;
            }
        }
    }
  

}
