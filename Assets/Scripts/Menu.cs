using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
 
    public float GlobalDNK;
    int index;
    public GameObject SpawnText;
    public ChangersObject[] Changers;
    public GameObject buychange;
    public GameObject textchange;
    public TMP_Text textdnk;
    public GameObject[] shopImages;
    public Button[] butImages;
    int maxlevelbossfights;
    bool iscan;
    float time;

    // Start is called before the first frame update



   

    public void LoadSceneImage(int ind)
    {
       
        for(int i = 0; i < shopImages.Length; i++)
        {
            if (i != ind)
            {
                butImages[i].interactable = true;
                shopImages[i].SetActive(false);
            }
            else
            {
                butImages[i].interactable = false;
                shopImages[i].SetActive(true);
            }
        }
    }

    private void Awake()
    {
        iscan = true;
    }

    public void Start()
    {
       
        
        GlobalDNK = PlayerPrefs.GetFloat("GlobalDnk");
        for (int i = 0; i < Changers.Length; i++)
        {
            if (PlayerPrefs.GetInt(Changers[i].playerprefs) == 0)
            {
                
                    PlayerPrefs.SetInt(Changers[i].playerprefs, 1);
                    var gb = Instantiate(buychange, new Vector3(Changers[i].lineofchangersobject[0].transform.position.x, Changers[i].lineofchangersobject[0].transform.position.y, 100), Quaternion.identity);
                    gb.transform.parent = Changers[i].lineofchangersobject[0];
                
                
            }
            if (PlayerPrefs.HasKey(Changers[i].playerprefs))
            {
                Changers[i].gbchanger.transform.position = Changers[i].lineofchangersobject[PlayerPrefs.GetInt(Changers[i].playerprefs) - 1].transform.position;
            }
            else
            {
                Changers[i].gbchanger.transform.position = Changers[i].lineofchangersobject[0].transform.position;
            }

            for (int r = 0; r < Changers[i].lineofchangersobject.Length; r++)
            {
                if (iscan)
                {
                    GameObject txtgb = Instantiate(textchange, new Vector3(Changers[i].lineofchangersobject[r].transform.position.x + 27, Changers[i].lineofchangersobject[r].transform.position.y - 37, 0), Quaternion.identity);
                    txtgb.GetComponent<TMP_Text>().text = "Cost: " + Changers[i].costlineobj[r];
                    txtgb.transform.parent = Changers[i].lineofchangersobject[r];
                }
               
                if (PlayerPrefs.HasKey(Changers[i].UnlockName + (r + 1)))
                {
                    var gb = Instantiate(buychange, new Vector3(Changers[i].lineofchangersobject[r].transform.position.x, Changers[i].lineofchangersobject[r].transform.position.y, 100), Quaternion.identity);
                    gb.transform.parent = Changers[i].lineofchangersobject[r];
                }
            }
        }
        Destroy(FindObjectOfType<RoomManager>().gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        textdnk.text = GlobalDNK + " dna";
        iscan = false;
        Vector3 newScale = FindObjectOfType<Border>().transform.localScale - new Vector3(0.035f, 0.035f, 0f) * Time.deltaTime;
        FindObjectOfType<Border>().transform.localScale = newScale;
       

        // FindObjectOfType<Border>().gameObject.transform.localScale = new Vector3(FindObjectOfType<Border>().gameObject.transform.localScale.x - 0.05f, FindObjectOfType<Border>().gameObject.transform.localScale.y - 0.05f, 0);
        if (Input.GetKey(KeyCode.Q))
        {
            GlobalDNK = 99999;
        }
        PlayerPrefs.SetFloat("GlobalDnk", GlobalDNK);


        
    }

    public void LoadScene(string Scene)
    {

        SceneManager.LoadScene(Scene);
    }
    public void LoadSceneBossFight(string Scene)
    {
        if (PlayerPrefs.GetInt("maxlevelbossfights") == 0)
        {
            PlayerPrefs.SetInt("maxlevelbossfights", 1);
        }
        if (int.Parse(Scene) <= PlayerPrefs.GetInt("maxlevelbossfights"))
        {
            SceneManager.LoadScene(Scene);
        }
        
    }

    public void MinusValuePlant(int localindex)
    {
        index = localindex;
    }
    public void ChangePlant(int money)
    {
        if (PlayerPrefs.HasKey("shopUnlockPlant" + index))
        {
            PlayerPrefs.SetInt("shopPlant", index);
            Changers[0].gbchanger.transform.position = Changers[0].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else if (GlobalDNK - money >= 0)
        {
            PlayerPrefs.SetInt("shopUnlockPlant" + index, index);
            PlayerPrefs.SetInt("shopPlant", index);
            Changers[0].gbchanger.transform.position = Changers[0].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else
        {
            GameObject gb = Instantiate(SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((GlobalDNK - money) * -1) + " dnk";
            gb.transform.parent = FindObjectOfType<GameManager>().canvas[0].transform;

        }

    }



    public void MinusValueRegeneration(int localindex)
    {

        index = localindex;

    }
    public void ChangeRegeneration(int money)
    {
        if (PlayerPrefs.HasKey("shopUnlockRegeneration" + index))
        {
            PlayerPrefs.SetInt("shopRegeneration", index);
            Changers[1].gbchanger.transform.position = Changers[1].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else if (GlobalDNK - money >= 0)
        {
            PlayerPrefs.SetInt("shopRegeneration", index);
            PlayerPrefs.SetInt("shopUnlockRegeneration" + index, index);
            Changers[1].gbchanger.transform.position = Changers[1].lineofchangersobject[index - 1].transform.position;
            GlobalDNK -= money;
            Start();
        }
        else
        {
            GameObject gb = Instantiate(SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((GlobalDNK - money) * -1) + " dnk";
            gb.transform.parent = FindObjectOfType<GameManager>().canvas[0].transform;
        }

    }
    public void MinusValueBonus(int localindex)
    {

        index = localindex;

    }
    public void ChangeBonus(int money)
    {
        if (PlayerPrefs.HasKey("shopUnlockBonus" + index))
        {
            PlayerPrefs.SetInt("shopBonus", index);
            Changers[2].gbchanger.transform.position = Changers[2].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else if (GlobalDNK - money >= 0)
        {
            PlayerPrefs.SetInt("shopUnlockBonus" + index, index);
            PlayerPrefs.SetInt("shopBonus", index);
            Changers[2].gbchanger.transform.position = Changers[2].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else
        {
            GameObject gb = Instantiate(SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((GlobalDNK - money) * -1) + " dnk";
            gb.transform.parent = FindObjectOfType<GameManager>().canvas[0].transform;

        }
    }
    public void MinusValuePoison(int localindex)
    {

        index = localindex;

    }
    public void ChangePoison(int money)
    {

        if (PlayerPrefs.HasKey("shopUnlockPoison" + index))
        {
            PlayerPrefs.SetInt("shopPoison", index);
            Changers[3].gbchanger.transform.position = Changers[3].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else if (GlobalDNK - money >= 0)
        {
            PlayerPrefs.SetInt("shopUnlockPoison" + index, index);
            PlayerPrefs.SetInt("shopPoison", index);
            Changers[3].gbchanger.transform.position = Changers[3].lineofchangersobject[index - 1].transform.position;
            Start();

        }
        else
        {
            GameObject gb = Instantiate(SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((GlobalDNK - money) * -1) + " dnk";
            gb.transform.parent = FindObjectOfType<GameManager>().canvas[0].transform;

        }
    }
    public void MinusValueSpawnCount(int localindex)
    {

        index = localindex;

    }
    public void ChangeSpawnCount(int money)
    {
        if (PlayerPrefs.HasKey("shopUnlockSpawnCount" + index))
        {
            PlayerPrefs.SetInt("shopSpawnCount", index);
            Changers[4].gbchanger.transform.position = Changers[4].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else if (GlobalDNK - money >= 0)
        {
            PlayerPrefs.SetInt("shopUnlockSpawnCount" + index, index);
            PlayerPrefs.SetInt("shopSpawnCount", index);
            Changers[4].gbchanger.transform.position = Changers[4].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else
        {
            GameObject gb = Instantiate(SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((GlobalDNK - money) * -1) + " dnk";
            gb.transform.parent = FindObjectOfType<GameManager>().canvas[0].transform;

        }
    }
    public void MinusValueBG(int localindex)
    {

        index = localindex;

    }
    public void ChangeBG(int money)
    {
        if (PlayerPrefs.HasKey("shopUnlockBG" + index))
        {
            PlayerPrefs.SetInt("shopBG", index);
            Changers[5].gbchanger.transform.position = Changers[5].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else if (GlobalDNK - money >= 0)
        {
            PlayerPrefs.SetInt("shopUnlockBG" + index, index);
            PlayerPrefs.SetInt("shopBG", index);
            Changers[5].gbchanger.transform.position = Changers[5].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else
        {
            GameObject gb = Instantiate(SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((GlobalDNK - money) * -1) + " dnk";
            gb.transform.parent = FindObjectOfType<GameManager>().canvas[0].transform;

        }
    }
    public void MinusValueControl(int localindex)
    {

        index = localindex;

    }
    public void ChangeControl(int money)
    {
        if (PlayerPrefs.HasKey("shopUnlockControl" + index))
        {
            PlayerPrefs.SetInt("shopControl", index);
            Changers[6].gbchanger.transform.position = Changers[6].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else if (GlobalDNK - money >= 0)
        {
            PlayerPrefs.SetInt("shopUnlockControl" + index, index);
            PlayerPrefs.SetInt("shopControl", index);
            Changers[6].gbchanger.transform.position = Changers[6].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else
        {
            GameObject gb = Instantiate(SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((GlobalDNK - money) * -1) + " dnk";
            gb.transform.parent = FindObjectOfType<GameManager>().canvas[0].transform;

        }
    }
    public void MinusValueSpeed(int localindex)
    {

        index = localindex;

    }
    public void ChangeSpeed(int money)
    {
        if (PlayerPrefs.HasKey("shopUnlockSpeed" + index))
        {
            PlayerPrefs.SetInt("shopSpeed", index);
            Changers[7].gbchanger.transform.position = Changers[7].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else if (GlobalDNK - money >= 0)
        {
            PlayerPrefs.SetInt("shopUnlockSpeed" + index, index);
            PlayerPrefs.SetInt("shopSpeed", index);
            Changers[7].gbchanger.transform.position = Changers[7].lineofchangersobject[index - 1].transform.position;
            Start();
        }
        else
        {
            GameObject gb = Instantiate(SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((GlobalDNK - money) * -1) + " dnk";
            gb.transform.parent = FindObjectOfType<GameManager>().canvas[0].transform;

        }
    }


    [Serializable]
    public class ChangersObject
    {
        public Transform[] lineofchangersobject;
        public int[] costlineobj;

        public GameObject gbchanger;
        public string playerprefs;
        public string UnlockName;
    }
}
