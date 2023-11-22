using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int ind;
    public GameObject ball;
    public GameObject butt;
    public GameObject round;
    public TMP_Text txtyouwin;
    float timegame;
    bool IsStart;
    
    private Vector3 offset;

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }


    public void StartChest(int dnk)
    {
        if (FindObjectOfType<Menu>().GlobalDNK >= dnk)
        {
            ball.GetComponent<Rigidbody2D>().isKinematic = false;
            ball.GetComponent<NewBehaviourScript>().count = 0;
            timegame = 40;
            IsStart = true;
            FindObjectOfType<Menu>().GlobalDNK -= dnk;
            butt.SetActive(false);
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.value, Random.value);
            ball.GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(ball.GetComponent<Rigidbody2D>().velocity, 14); 
        }
        else
        {
            GameObject gb = Instantiate(FindObjectOfType<Menu>().SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((FindObjectOfType<Menu>().GlobalDNK - dnk) * -1) + " dnk";
            gb.transform.parent = FindObjectOfType<GameManager>().canvas[0].transform;
        }
      
    }

    private void Update()
    {
        
        if (IsStart)
        {
            timegame -= Time.deltaTime;
            if (timegame < 0)
            {
                int cofint = ball.GetComponent<NewBehaviourScript>().count / ind;
                ball.GetComponent<Rigidbody2D>().isKinematic = true;
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                IsStart = false;
                butt.SetActive(true);
                var r = Random.Range(0, FindObjectOfType<Menu>().Changers.Length - 1);
                print("Random r: " + r);
                if (cofint > FindObjectOfType<Menu>().Changers[r].lineofchangersobject.Length - 1)
                {
                    cofint = FindObjectOfType<Menu>().Changers[r].lineofchangersobject.Length - 1;
                }
                var b = cofint;
                print("B confit: " + b);
                PlayerPrefs.SetInt(FindObjectOfType<Menu>().Changers[r].playerprefs, b); ;
                print("Founded playerprefs: " + FindObjectOfType<Menu>().Changers[r].playerprefs);
                FindObjectOfType<Menu>().Changers[r].gbchanger.transform.position = FindObjectOfType<Menu>().Changers[r].lineofchangersobject[b].transform.position;
                PlayerPrefs.SetInt(FindObjectOfType<Menu>().Changers[r].UnlockName + b, b);
                print(FindObjectOfType<Menu>().Changers[r].UnlockName + b);
                txtyouwin.text = "You win: " + FindObjectOfType<Menu>().Changers[r].lineofchangersobject[b].GetComponentInChildren<TMP_Text>().text;
                FindObjectOfType<Menu>().GetComponent<Menu>().Start();
            }
        }
        
    }
}
