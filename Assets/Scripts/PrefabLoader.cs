using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class PrefabLoader : MonoBehaviour
{
    public GameObject[] gb;
    public Text[] txt;
    public GameObject BasicObj;
    


    public GameObject RegenerationObj;
    public GameObject PoisonObj;
    GameObject gbfol;
    void Start()
    {
        if (PlayerPrefs.GetInt("shopPlant") == 0)
        {
            PlayerPrefs.SetInt("shopPlant", 1);
        }
       
        var base0 = Instantiate(BasicObj);
        var base1 = Instantiate(BasicObj);
        var base2 = Instantiate(BasicObj);
        var base3 = Instantiate(BasicObj);
        var base4 = Instantiate(BasicObj);
        var base5 = Instantiate(BasicObj);
        var base6 = Instantiate(BasicObj);
        var base7 = Instantiate(BasicObj);
        gb[0] = base0;
        gb[1] = base1;
        gb[2] = base2;
        gb[3] = base3;
        gb[4] = base4;
        gb[5] = base5;
        gb[6] = base6;
        gb[7] = base7;
        Load(0);
        Load(1);
        Load(2);
        Load(3);
        Load(4);
        Load(5);
        Load(6);
        Load(7);
        base0.SetActive(false);
        base1.SetActive(false);
        base2.SetActive(false);
        base3.SetActive(false);
        base4.SetActive(false);
        base5.SetActive(false);
        base6.SetActive(false);
        base7.SetActive(false);

        
    }

    private void Update()
    {

        gbfol = FindObjectOfType<GameManager>().clickobjectinfo;
    }
    public void Save(int index)
    {
        PlayerPrefs.SetString("name" + index, gbfol.name);
        PlayerPrefs.SetFloat("type" + index, gbfol.GetComponent<DnkPlant>().type);
        PlayerPrefs.SetFloat("scale" + index, gbfol.GetComponent<DnkPlant>().scale);
        PlayerPrefs.SetFloat("mass" + index, gbfol.GetComponent<DnkPlant>().mass);
        PlayerPrefs.SetFloat("drag" + index, gbfol.GetComponent<DnkPlant>().drag);
        PlayerPrefs.SetFloat("speed" + index, gbfol.GetComponent<DnkPlant>().speed);
        PlayerPrefs.SetFloat("mintime_adult" + index, gbfol.GetComponent<DnkPlant>().mintime_adult);
        PlayerPrefs.SetFloat("livetime" + index, gbfol.GetComponent<DnkPlant>().livetime);
        PlayerPrefs.SetFloat("needfoodsecond" + index, gbfol.GetComponent<DnkPlant>().needfoodsecond);
        PlayerPrefs.SetFloat("maxhp" + index, gbfol.GetComponent<DnkPlant>().maxhp);
        PlayerPrefs.SetFloat("maxfood" + index, gbfol.GetComponent<DnkPlant>().maxfood);
        PlayerPrefs.SetFloat("timetohavefood" + index, gbfol.GetComponent<DnkPlant>().timetohavefood);
        PlayerPrefs.SetFloat("type" + index, gbfol.GetComponent<DnkPlant>().maxdistancespawn);
        PlayerPrefs.SetInt("chancetochild1" + index, gbfol.GetComponent<DnkPlant>().chancetochild1);
        PlayerPrefs.SetFloat("tochildfood" + index, gbfol.GetComponent<DnkPlant>().tochildfood);
        PlayerPrefs.SetFloat("dietoorganiccount" + index, gbfol.GetComponent<DnkPlant>().dietoorganiccount);
        PlayerPrefs.SetInt("typespawn" + index, gbfol.GetComponent<DnkPlant>().typespawn);
        PlayerPrefs.SetInt("shape" + index, gbfol.GetComponent<DnkPlant>().shape);
        PlayerPrefs.SetFloat("colorR" + index, gbfol.GetComponent<DnkPlant>().color.r);
        PlayerPrefs.SetFloat("colorG" + index, gbfol.GetComponent<DnkPlant>().color.g);
        PlayerPrefs.SetFloat("colorB" + index, gbfol.GetComponent<DnkPlant>().color.b);
        PlayerPrefs.SetFloat("colorA" + index, gbfol.GetComponent<DnkPlant>().color.a);

        var gdcopyinf = Instantiate(gbfol, transform.position, transform.rotation);
        gb[index] = gdcopyinf;
        gdcopyinf.SetActive(false);
    }


    public void Load(int index)
    {
        gb[index].name = PlayerPrefs.GetString("name" + index);
        gb[index].GetComponent<DnkPlant>().type = PlayerPrefs.GetInt("type" + index);
        gb[index].GetComponent<DnkPlant>().scale = PlayerPrefs.GetFloat("scale" + index);
        gb[index].GetComponent<DnkPlant>().mass = PlayerPrefs.GetFloat("mass" + index);
        gb[index].GetComponent<DnkPlant>().drag = PlayerPrefs.GetFloat("drag" + index);
        gb[index].GetComponent<DnkPlant>().speed = PlayerPrefs.GetFloat("speed" + index);
        gb[index].GetComponent<DnkPlant>().mintime_adult = PlayerPrefs.GetFloat("mintime_adult" + index);
        gb[index].GetComponent<DnkPlant>().livetime = PlayerPrefs.GetFloat("livetime" + index);
        gb[index].GetComponent<DnkPlant>().needfoodsecond = PlayerPrefs.GetFloat("needfoodsecond" + index);
        gb[index].GetComponent<DnkPlant>().maxhp = PlayerPrefs.GetFloat("maxhp" + index);
        gb[index].GetComponent<DnkPlant>().maxfood = PlayerPrefs.GetFloat("maxfood" + index);
        gb[index].GetComponent<DnkPlant>().timetohavefood = PlayerPrefs.GetFloat("timetohavefood" + index);
        gb[index].GetComponent<DnkPlant>().maxdistancespawn = PlayerPrefs.GetFloat("maxdistance_spawn" + index);
        gb[index].GetComponent<DnkPlant>().chancetochild1 = PlayerPrefs.GetInt("chancetochild1" + index);
        gb[index].GetComponent<DnkPlant>().tochildfood = PlayerPrefs.GetFloat("tochildfood" + index);
        gb[index].GetComponent<DnkPlant>().dietoorganiccount = PlayerPrefs.GetFloat("dietoorganiccount" + index);
        gb[index].GetComponent<DnkPlant>().typespawn = PlayerPrefs.GetInt("typespawn" + index);
        gb[index].GetComponent<DnkPlant>().shape = PlayerPrefs.GetInt("shape" + index);
        gb[index].GetComponent<DnkPlant>().color.r = PlayerPrefs.GetFloat("colorR" + index);
        gb[index].GetComponent<DnkPlant>().color.g = PlayerPrefs.GetFloat("colorG" + index);
        gb[index].GetComponent<DnkPlant>().color.b = PlayerPrefs.GetFloat("colorB" + index);
        gb[index].GetComponent<DnkPlant>().color.a = PlayerPrefs.GetFloat("colorA" + index);
        txt[index].text = "Plant" + index;
    }



    public void spawn(int ind)
    {

        FindObjectOfType<Analitic>().arraythisminadd();


        if (ind >= 0)
        {
            if (PlayerPrefs.HasKey("type" + ind)) { Load(ind); }
            var creatgb = Instantiate(gb[ind], FindObjectOfType<Camera>().transform.position, transform.rotation);
            creatgb.GetComponent<DnkPlant>().time_adult = 0;
            creatgb.transform.position = new Vector3(creatgb.transform.position.x, creatgb.transform.position.y, 0.1f);
            creatgb.SetActive(true);
        }
        else 
        {
            if (GetComponent<GameManager>().gametype == 4)
            {
                var creatgb = Instantiate(BasicObj, FindObjectOfType<Camera>().transform.position, transform.rotation);
                creatgb.transform.position = new Vector3(creatgb.transform.position.x, creatgb.transform.position.y, 0.1f);
                print("AAAA");
                creatgb.SetActive(true);
            }
            else if (GetComponent<GameManager>().dnk >= 8)
            {
                var creatgb = Instantiate(GetComponent<GameManager>().Playerrefabloader, FindObjectOfType<Camera>().transform.position, transform.rotation);
                creatgb.transform.position = new Vector3(creatgb.transform.position.x, creatgb.transform.position.y, 0.1f);
                creatgb.SetActive(true);
                GetComponent<GameManager>().dnk -= 8;
            }
            else
            {
                Debug.Log("Variant 1. PV Spawn. Gametype != 4 and dnk <8");
                GameObject gb = Instantiate(GetComponent<GameManager>().SpawnText);
                gb.SetActive(true);
                gb.transform.position = new Vector3(950, 0, 0);
                gb.GetComponent<TMP_Text>().text = "You are missing " + ((GetComponent<GameManager>().dnk - 8) * -1) + " dnk";
                gb.transform.parent = GetComponent<GameManager>().canvas[0].transform;
            }


        }






    }

    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SpawnablePrefabs(int ind)
    {
        if (GetComponent<GameManager>().gametype == 4)
        {
            if (ind == 1)
            {
                var creatgb = Instantiate(RegenerationObj, FindObjectOfType<Camera>().transform.position, transform.rotation);
                creatgb.transform.position = new Vector3(creatgb.transform.position.x, creatgb.transform.position.y, 0.1f);
                creatgb.SetActive(true);
            }
            if (ind == 2)
            {
                var creatgb = Instantiate(PoisonObj, FindObjectOfType<Camera>().transform.position, transform.rotation);
                creatgb.transform.position = new Vector3(creatgb.transform.position.x, creatgb.transform.position.y, 0.1f);
                creatgb.SetActive(true);
            }
        }
        else
        {
            if (GetComponent<GameManager>().dnk >= 80 && ind == 1)
            {

                var creatgb = Instantiate(RegenerationObj, FindObjectOfType<Camera>().transform.position, transform.rotation);
                creatgb.transform.position = new Vector3(creatgb.transform.position.x, creatgb.transform.position.y, 0.1f);
                creatgb.SetActive(true);
                GetComponent<GameManager>().dnk -= 80;
            }

            else if (ind == 1)
            {
                Debug.Log("Variant 2. PV SpawnablePrefabs. Gametype != 4 and dnk <80");
                GameObject gb = Instantiate(GetComponent<GameManager>().SpawnText);
                gb.GetComponent<Animator>().speed = 1 / GetComponent<GameManager>().time;
                Debug.Log(gb.GetComponent<Animator>().speed + " speed of anim new text obj");
                gb.SetActive(true);
                gb.transform.position = new Vector3(950, 0, 0);
                gb.GetComponent<TMP_Text>().text = "You are missing " + ((GetComponent<GameManager>().dnk - 80) * -1) + " dnk";
                gb.transform.parent = GetComponent<GameManager>().canvas[0].transform;
            }


            }


            if (GetComponent<GameManager>().dnk >= 135 && ind == 2)
            {

                var creatgb = Instantiate(PoisonObj, FindObjectOfType<Camera>().transform.position, transform.rotation);
                creatgb.transform.position = new Vector3(creatgb.transform.position.x, creatgb.transform.position.y, 0.1f);
                creatgb.SetActive(true);
                GetComponent<GameManager>().dnk -= 135;
            }

            else if(ind == 2)
            {
                Debug.Log("Variant 2. PV SpawnablePrefabs. Gametype != 4 and dnk <135");
                GameObject gb = Instantiate(GetComponent<GameManager>().SpawnText);
                gb.SetActive(true);
                gb.transform.position = new Vector3(950, 0, 0);
                gb.GetComponent<TMP_Text>().text = "You are missing " + ((GetComponent<GameManager>().dnk - 135) * -1) + " dnk";
                gb.transform.parent = GetComponent<GameManager>().canvas[0].transform;
            }
            }
           

        }
    

