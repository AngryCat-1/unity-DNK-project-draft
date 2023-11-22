using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Border : MonoBehaviour
{
    public InputField[] inputFields;
    public DnkOnformationPlant2[] inputFieldsDnkOnFormationPlant2;
    public Transform[] borders;
    public bool isActivate;
    // Start is called before the first frame update
    void Start()
    {
        inputFieldsDnkOnFormationPlant2[0] = inputFields[0].GetComponent<DnkOnformationPlant2>();
        inputFieldsDnkOnFormationPlant2[1] = inputFields[1].GetComponent<DnkOnformationPlant2>();
        borders[0].localScale = new Vector2(float.Parse(inputFields[0].text) / 21, float.Parse(inputFields[1].text) / 21);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!FindObjectOfType<GameManager>().isMenu)
        {
            if (float.Parse(inputFields[0].text) == 0 || float.Parse(inputFields[1].text) == 0)
            {

                isActivate = false;


            }
            else
            {

                isActivate = true;
            }

            if (inputFieldsDnkOnFormationPlant2[0].ismouse == false && inputFieldsDnkOnFormationPlant2[1].ismouse == false)
            {
                borders[0].localScale = new Vector2(float.Parse(inputFields[0].text) / 21, float.Parse(inputFields[1].text) / 21);



            }
        }
       

        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plant1" )
        {
            
            Destroy(collision.gameObject);
            


        }
    }

   
   
}
