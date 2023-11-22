using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject[] gbs;
    static int maxinst;
    // Start is called before the first frame update
    void SpawnObjects()
    {
        print(Resources.Load("2block"));
        Vector3 center = transform.position;
        Vector3 top = center + Vector3.up * 6;
        Vector3 bottom = center + Vector3.down * 6;
        Vector3 left = center + Vector3.left * 6;
        Vector3 right = center + Vector3.right * 6;

        // проверяем, есть ли объекты на местах, где мы хотим создать новые объекты
        bool topClear = Physics.CheckSphere(top, 0.1f);
        bool bottomClear = Physics.CheckSphere(bottom, 0.1f);
        bool leftClear = Physics.CheckSphere(left, 0.1f);
        bool rightClear = Physics.CheckSphere(right, 0.1f);

        // создаем объекты на свободных местах
        if (!topClear)
        {
            var chancetoedit = Random.Range(0, 5);
            if (chancetoedit < 4)
            {
                Instantiate(this.gameObject, top, Quaternion.identity);
            }
            else
            {
                Instantiate(gbs[Random.Range(0, 3)], top, Quaternion.identity);

            }
        }
        if (!bottomClear)
        {
            var chancetoedit1 = Random.Range(0, 5);
            if (chancetoedit1 < 4)
            {
                Instantiate(this.gameObject, bottom, Quaternion.identity);
            }
            else
            {
                Instantiate(gbs[Random.Range(0, 3)], bottom, Quaternion.identity);

            }
        }
        if (!leftClear)
        {
            var chancetoedit2 = Random.Range(0, 5);
            if (chancetoedit2 < 4)
            {
                Instantiate(this.gameObject, left, Quaternion.identity);
            }
            else
            {
                Instantiate(gbs[Random.Range(0, 3)], left, Quaternion.identity);

            }
        }
        if (!rightClear)
        {
            var chancetoedit3 = Random.Range(0, 5);
            if (chancetoedit3 < 4)
            {
                Instantiate(this.gameObject, right, Quaternion.identity);
            }
            else
            {
                Instantiate(gbs[Random.Range(0, 3)], right, Quaternion.identity);

            }
        }
    }

    void Start()
    {
        maxinst += 1;
        if (maxinst < 10000)
        {
            SpawnObjects();
        }
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
