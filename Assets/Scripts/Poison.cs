using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public float index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        index -= 0.003f;
        if (index <= 0 )
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (PlayerPrefs.GetInt("shopPoison") == 1 || (PlayerPrefs.GetInt("shopPoison") == 2))
        {
            if (collision.gameObject.tag == "Plant1")
            {
                if (collision.gameObject.GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                {
                    collision.gameObject.GetComponent<DnkPlant>().time_adult -= 0.008f;
                    collision.gameObject.GetComponent<DnkPlant>().scale -= 0.02f;
                    collision.gameObject.GetComponent<DnkPlant>().maxhp -= 0.005f;
                    collision.gameObject.transform.localScale = new Vector3(collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale);
                }
            }
        }
        if (PlayerPrefs.GetInt("shopPoison") == 3)
        {
            if (collision.gameObject.tag == "Plant1")
            {

                if (collision.gameObject.GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                {

                    collision.gameObject.GetComponent<DnkPlant>().time_adult -= 0.008f;
                    collision.gameObject.GetComponent<DnkPlant>().scale += 0.02f;
                    collision.gameObject.GetComponent<DnkPlant>().maxhp += 0.005f;
                    collision.gameObject.transform.localScale = new Vector3(collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale);
                }
                else
                {
                    collision.gameObject.GetComponent<DnkPlant>().time_adult -= 0.008f;
                    collision.gameObject.GetComponent<DnkPlant>().scale -= 0.02f;
                    collision.gameObject.GetComponent<DnkPlant>().maxhp -= 0.005f;
                    collision.gameObject.transform.localScale = new Vector3(collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale);
                }


            }
        }
        if (PlayerPrefs.GetInt("shopPoison") == 4)
        {
            if (collision.gameObject.tag == "Plant1")
            {
                if (collision.gameObject.GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                {
                    collision.gameObject.GetComponent<DnkPlant>().time_adult -= 0.008f;
                    collision.gameObject.GetComponent<DnkPlant>().scale += 0.02f;
                    collision.gameObject.GetComponent<DnkPlant>().maxhp += 0.005f;
                    collision.gameObject.transform.localScale = new Vector3(collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale);
                }
                else
                {
                    FindObjectOfType<GameManager>().dnk += 0.03f;
                }


            }
        }
    }


}



