using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Analitic : MonoBehaviour
{
    float arrayListObj;
    public Text arrayListObjtext;
    float arrayListObjLastMinute;
    public Text arrayListObjLastMinutetext;
    float arrayListObjThisMin;
    public Text arrayListObjThisMintext;
    float arrayListObjThisMinIsBigger;
    public Text arrayListObjIsBiggertext;
    public float timedelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void arraythisminadd()
    {
        arrayListObjThisMin += 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (arrayListObjLastMinute != 0)
        {
            arrayListObjThisMinIsBigger = ((arrayListObjThisMin / arrayListObjLastMinute) * 100) - 100;
            arrayListObjIsBiggertext.text = "ThisMin>LastMinute:" + Mathf.Round(arrayListObjThisMinIsBigger) + "%";
        }
        
        arrayListObjtext.text = "Obj:" + arrayListObj + "";
        if (arrayListObjLastMinutetext != null) { arrayListObjLastMinutetext.text = "ObjLastMinute:" + arrayListObjLastMinute + ""; }

        arrayListObjThisMintext.text = "ObjThisMinute:" + arrayListObjThisMin + "";
        timedelay += Time.deltaTime;
        if (timedelay >= 60)
        {
            timedelay = 0;
            arrayListObjLastMinute = arrayListObjThisMin;
            arrayListObjThisMin = 0;
            
        }
        arrayListObj = FindObjectOfType<GameManager>().plant1.Length;
    }
}
