using System.Collections;
using System.Collections.Generic;
using Photon;
using Photon.Pun;
using UnityEngine;

public class InstantiaterObject : MonoBehaviour
{




    static int currentnumber = 1;
    public GameObject SpawnedMultPlayer;
    // Start is called before the first frame update


    public void IndexProcedure(GameObject gameObject)
    {

        Debug.Log("Мой номер игрока: " + currentnumber);
        gameObject.GetComponentInChildren<GameManager>().mytype = currentnumber;
        gameObject.GetComponentInChildren<GameManager>().isMultiPlayer = true;

        

    //    string name1 = "Playerrefabloader" + Random.Range(-10000, 10000);
      //  GameObject.Find("Playerrefabloader").name = name1;
     //   gameObject.GetComponentInChildren<GameManager>().nameBasicObj = name1;
     //   print("name1 - " + name1);
      //  print(gameObject.GetComponentInChildren<GameManager>().mytype + " mytype");
        currentnumber += 1;
    }



    // Update is called once per frame
    void Update()
    {

    }
}


