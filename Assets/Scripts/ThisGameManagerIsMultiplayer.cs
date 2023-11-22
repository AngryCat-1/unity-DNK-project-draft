using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThisGameManagerIsMultiplayer : MonoBehaviour
{
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.05f)
        {
            SceneManager.LoadScene("Menu1");
            Destroy(this.gameObject);
        }
    }
}
