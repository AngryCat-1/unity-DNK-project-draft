using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    
    public float speed;
    public float speedmw;
    public Transform obj;
    GameManager gm;
    float defspeed;
    float defmw;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        defspeed = speed;
        defmw = speedmw;
    }

    public void Update()
    {
        if (gm.time != 0)
        {
            float mw = Input.GetAxis("Mouse ScrollWheel");
            if (mw > 0.1 && GetComponent<Camera>().orthographicSize < 3500)
            {
                GetComponent<Camera>().orthographicSize += speedmw * Time.deltaTime * 100;
            }
            if (mw < -0.1 && GetComponent<Camera>().orthographicSize > 1)
            {
                GetComponent<Camera>().orthographicSize -= speedmw * Time.deltaTime * 100;
                if (GetComponent<Camera>().orthographicSize < 1)
                {
                    GetComponent<Camera>().orthographicSize = 1;
                }

            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * (speed * GetComponent<Camera>().orthographicSize) * Time.deltaTime;
            obj.transform.position += tempVect;
            speed = defspeed / gm.time;
            speedmw = defmw / gm.time;
        }
        

        


           
        
        
       





    }
}
