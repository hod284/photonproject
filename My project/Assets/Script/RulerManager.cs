using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;

public class RulerManager : MonoBehaviour
{
    public ARRaycastManager m_RaycastManager;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    private Vector2 _centerVec;
    public Transform _rulerPool;
    public GameObject _rulerObj;
    public TMP_Text nowdismater;
    private RulerObjST _nowRulerObj;
    private List<RulerObjST> _rulerObjList =new List<RulerObjST>();
    private bool _rulerEnable;
    private Vector3 _rulerPosSave;
    // Start is called before the first frame update
    void Start()
    {
        _centerVec = new Vector2( Screen.width * 0.5f, Screen.height * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            _centerVec = Input.GetTouch(0).position;
            MakeRulerObj();
        }
        else
            _centerVec = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        if (m_RaycastManager.Raycast(_centerVec, s_Hits, TrackableType.PlaneWithinPolygon))
        {
           
                var hitPose = s_Hits[0].pose; // 첫번째로 측정된 면의 정보를 가져옴.
                _rulerPosSave = hitPose.position;

                if (_nowRulerObj != null&& _rulerEnable)
                {
                    _nowRulerObj.SetObj(hitPose.position);
                    _nowRulerObj.checkline();
                     nowdismater.text = _nowRulerObj._text.text;
                }
            
        }
        
    }

    public void MakeRulerObj()
    {
      
            if(_rulerEnable ==false)
            {
                Debug.Log(_rulerObj);
                GameObject tObj = Instantiate(_rulerObj) as GameObject;
                tObj.transform.SetParent(_rulerPool);
                tObj.transform.position = Vector3.zero;
                tObj.transform.localScale = new Vector3(1,1,1);

                RulerObjST tObjST = tObj.GetComponent<RulerObjST>();
                tObjST.SetInit(_rulerPosSave);
                _rulerObjList.Add(tObjST);
                _nowRulerObj = tObjST; 
                _rulerEnable = true;
               nowdismater.gameObject.SetActive(true);
            }
            else
            {
                 _rulerEnable = false;
                 _nowRulerObj = null;
                 nowdismater.gameObject.SetActive(false);
            }
        
    }
}
