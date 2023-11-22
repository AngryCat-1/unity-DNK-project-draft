using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerManager : MonoBehaviour
{
    public GameObject gbmultiplayer;
    public GameObject thisgb;
    public InstantiaterObject[] inst;
    // Start is called before the first frame update
    public void Start()
    {
        GameObject gb = new GameObject();
       // var gb1 = Instantiate(gbmultiplayer);
       // thisgb = gb1;
        //inst = FindObjectsOfType<InstantiaterObject>();
        //FindObjectOfType<InstantiaterObject>().IndexProcedure(thisgb);



    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
