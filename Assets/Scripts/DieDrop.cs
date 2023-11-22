using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieDrop : MonoBehaviour
{
    public float index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index > 0) { index -= 0.005f; }
        if (index < 0) { Destroy(this.gameObject); }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Plant1")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * Random.Range(1, -1) * 50, ForceMode2D.Impulse);


            if (index >= collision.gameObject.GetComponent<DnkPlant>().dietoorganiccount)
            {
                
                Destroy(collision.gameObject);
                index += 1;
            }
            if (collision.gameObject.GetComponent<DnkPlant>().time_adult >= collision.gameObject.GetComponent<DnkPlant>().liveminusone)
            {
                
                index += 1;
                Destroy(collision.gameObject);
            }
        }
    }
}
