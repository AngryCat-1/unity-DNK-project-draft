using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regeneration : MonoBehaviour
{
    bool ismy;
    public float index;
    public float scale = 2.3078f;
    public float scalestrong = 0.18f;
    public float maxhpstrong = 0.004f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("shopRegeneration") + "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUF");
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (PlayerPrefs.GetInt("shopRegeneration") == 1 || (PlayerPrefs.GetInt("shopRegeneration") == 2))
        {
            if (collision.gameObject.tag == "Plant1")
            {
                if (collision.gameObject.GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                {
                    collision.gameObject.GetComponent<PlantController>().hp = collision.gameObject.GetComponent<DnkPlant>().maxhp;
                    collision.gameObject.GetComponent<PlantController>().food = collision.gameObject.GetComponent<DnkPlant>().maxfood;
                    collision.gameObject.GetComponent<DnkPlant>().time_adult = 0;
                    collision.gameObject.GetComponent<DnkPlant>().scale += scalestrong * 4;
                    collision.gameObject.GetComponent<DnkPlant>().maxhp += maxhpstrong;
                    collision.gameObject.transform.localScale = new Vector3(collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale);
                    index -= 0.009f;
                }
            }
        }
        if (PlayerPrefs.GetInt("shopRegeneration") == 3)
        {
            if (collision.gameObject.tag == "Plant1")
            {

                if (collision.gameObject.GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                {

                    collision.gameObject.GetComponent<PlantController>().hp = collision.gameObject.GetComponent<DnkPlant>().maxhp;
                    collision.gameObject.GetComponent<PlantController>().food = collision.gameObject.GetComponent<DnkPlant>().maxfood;
                    collision.gameObject.GetComponent<DnkPlant>().time_adult = 0;
                    collision.gameObject.GetComponent<DnkPlant>().scale += scalestrong * 4;
                    collision.gameObject.GetComponent<DnkPlant>().maxhp += maxhpstrong;
                    collision.gameObject.transform.localScale = new Vector3(collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale);
                    index -= 0.009f;
                }
                else
                {
                    //Debug.Log("DDD");
                    //Debug.Log(collision.gameObject.GetComponent<DnkPlant>().scale);
                    collision.gameObject.GetComponent<PlantController>().hp -= 0.009f;
                    collision.gameObject.GetComponent<PlantController>().food -= 0.007f;
                    collision.gameObject.GetComponent<DnkPlant>().time_adult += 0.008f;
                    collision.gameObject.GetComponent<DnkPlant>().scale -= scalestrong * 4;
                    collision.gameObject.GetComponent<DnkPlant>().maxhp -= maxhpstrong / 1.25f;
                    collision.gameObject.transform.localScale = new Vector3(collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale);
                    index += 0.003f;
                    //Debug.Log(collision.gameObject.GetComponent<DnkPlant>().scale + "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
                }


            }
        }
        if (PlayerPrefs.GetInt("shopRegeneration") == 4)
        {
            if (collision.gameObject.tag == "Plant1")
            {
                if (collision.gameObject.GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                {
                    collision.gameObject.GetComponent<PlantController>().hp = collision.gameObject.GetComponent<DnkPlant>().maxhp;
                    collision.gameObject.GetComponent<PlantController>().food = collision.gameObject.GetComponent<DnkPlant>().maxfood;
                    collision.gameObject.GetComponent<DnkPlant>().time_adult = 0;
                    collision.gameObject.GetComponent<DnkPlant>().scale += scalestrong * 4;
                    collision.gameObject.GetComponent<DnkPlant>().maxhp += maxhpstrong;
                    collision.gameObject.transform.localScale = new Vector3(collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale, collision.gameObject.GetComponent<DnkPlant>().scale);
                    index -= 0.009f;
                }
                else
                {
                    FindObjectOfType<GameManager>().dnk += 0.03f;
                }


            }
        }
    }
   
    
}
