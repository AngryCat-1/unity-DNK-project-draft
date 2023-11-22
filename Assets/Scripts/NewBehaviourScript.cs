using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    float time;
    public float maxSpeed = 4;
    public TMP_Text counttext;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down, ForceMode2D.Force);
         
    }

    // Update is called once per frame
    void Update()
    {
        counttext.text = count + "";
      if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale += 1;
        }
        time += Time.deltaTime;
        if (time < 2)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 1, ForceMode2D.Impulse);
        }

        if (GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxSpeed);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject. tag == "round")
        {
            count += 1;
        }
    }
   



}
