using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using System.Linq;
using Unity.VisualScripting;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.ComponentModel;
using GPUInstancer;
using Photon.Pun;
using System.Reflection;

//using UnityEditorInternal;

public class GameManager : MonoBehaviour
{
    public bool isalotobject;
    public bool isMultiPlayer;
    public TMP_InputField DnkInputField;
    public int mytype;
    public GameObject mytypewarninggb;
    public int gametype;
    public bool IsNeedNoSpawn;
    public float dnk;
    public InputField timeinputfield;
    public float time;
    public bool AutoTime = false;
    public float fps;
    public GameObject[] plant1;
    GameObject randplant;
    public GameObject[] canvas;
    public GameObject[] Analytics;
    bool isfirstcanvason = true;
    bool isfirstcanvasonanalatycs = true;
    public Text textcoord;
    public GameObject camera1;
    public GameObject[] inputFieldsdnk;
    public Toggle[] settingsdnkplant;
    public InputField settingsdnkplant1inp;
    public bool isinfoon;
    public GameObject clickobjectinfo;
    public bool inputsfieldtrue;
    public Toggle edittogle;
    public GameObject paneldnk;
    public bool isActivate;
    public bool isMenu;
    public AnaluticsPlus[] analuticsplus;
    public GameObject refabloader;
    public GameObject Playerrefabloader;
    public GameObject Regenerationrefabloader;
    GameObject border;
    public Animation textanim;
    public GameObject[] spawnpoints;
    float timedel;
    bool isready;
    public int totalcount;
    public GameObject ScreenLose;
    public TMP_Text ScreenLoseText;
    public TMP_Text ScreenLoseTextMoney;
    bool IsActiveScreenLose;

    GameObject gbtextsandbox;
    int valueeditgame;
    public GameObject SpawnText;
    bool iscanmove;
    PostProcessVolume[] postproccesinggb;
    bool ispostproccesing;
    public Toggle PostProcessingTogle;
    bool IsColorChange;
    public InputField StartBetINP;
    public GameObject StartEvolution;
    bool isTextEndTyping;
    public Regeneration[] regenerationMassive;
    public GameObject[] LoseTextObject;
    public Sprite[] BG;
    float DeltaTIME;
    bool isneedmultiplayeroperation;
    public GameObject butStart;
    public string nameBasicObj;
    GameObject gb;


    float current_time;
    float last_frame_time;
    float desired_fps = 60;
    float max_delta_time =1;
    // Start is called before the first frame update
    void Start()
    {


        //  plant1 = GameObject.FindGameObjectsWithTag("Plant1");
        //  for (int br = 0; br < plant1.Length; br++)
        //  {
        //      plant1[br].AddComponent<IOCcam>
        // }

        camera1 = FindObjectOfType<Camera>().gameObject;


        if (FindObjectOfType<NumberEvolution>() != null)
        {
           
        
            camera1.transform.position = FindObjectOfType<NumberEvolution>().transform.position;
        }
        
        
        if (isMultiPlayer)
        {
            butStart.SetActive(false);
        }
        GameManager[] GameManagers = FindObjectsOfType<GameManager>();
        print("1. Gamemanagerscount = " + GameManagers.Length);
        if (GameManagers.Length > 1)
        {
            totalcount = PhotonNetwork.PlayerList.Length;
            for (int i = 0; i < GameManagers.Length ; i++)
            {
               
                print("INSIDE iter = " + i + " / MYTYPE = " + mytype);
                if (mytype == 0)
                {
                    print("DESTROY 2!");
                     Destroy(transform.parent.gameObject);
                }
                if (GameManagers[i].mytype != mytype && mytype != 0 && GameManagers[i] != this.gameObject)
                {
                    GameManagers[i].gameObject.SetActive(false);
                }
               
                if (GameManagers[i].isMultiPlayer)
                {
                  
                    
                        print("MultyPlayer, but mytype is not 0.");
                    GameManagers[i].IsNeedNoSpawn = true;
                    GameManagers[i].isneedmultiplayeroperation = true;
                        print("SETNING IsNeedNoSpawn and isneedmultiplayeroperation: " + IsNeedNoSpawn + " " + isneedmultiplayeroperation);
                    
                    
                }
            }
           
        }
      

        GameObject go1 = new GameObject("GpuInstancer");
        
        go1.AddComponent<GPUInstancerPrefabManager>();
        //print(PlayerPrefs.GetInt("shopSpawnCount") + "okpon");
        camera1 = FindObjectOfType<Camera>().gameObject;
        if (GameObject.FindGameObjectWithTag("ImageBG"))
        {
            if (PlayerPrefs.GetInt("shopBG") == 0)
            {
                PlayerPrefs.SetInt("shopBG", 1);
            }
            GameObject.FindGameObjectWithTag("ImageBG").GetComponent<SpriteRenderer>().sprite = BG[PlayerPrefs.GetInt("shopBG") - 1];
        }
        Regenerationrefabloader = GetComponent<PrefabLoader>().RegenerationObj;
        refabloader = FindObjectOfType<PrefabLoader>().BasicObj;

        Playerrefabloader = Instantiate(refabloader);
        Playerrefabloader.name = "PLAYERobj";
        if (isneedmultiplayeroperation)
        {
            Playerrefabloader.SetActive(false);
        }
        
      
            
            
        
        


        int chanceto = Random.Range(1, 3);
        if (gametype == 1)
        {
           
            if (chanceto == 1)
            {
                
            }
            else
            {

                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().scale = 3.3f;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().mass = 7;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().livetime = 38;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxhp = 125;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxfood = 234;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().dietoorganiccount = 6;
                
            }
        }
        if (gametype == 2)
        {
            if (chanceto == 1)
            {
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().scale = 6f;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().mass = 7;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().livetime = 38;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxhp = 125;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxfood = 234;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().dietoorganiccount = 6;
                
            }
            else
            {
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().scale = 4.5f;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().mass = 15;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().livetime = 42;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxhp = 230;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxfood = 280;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().dietoorganiccount = 6;
                
            }
        }
        if (gametype == 3)
        {
            if (chanceto == 1)
            {
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().scale = 4.5f;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().mass = 15;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().livetime = 42;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxhp = 230;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxfood = 280;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().dietoorganiccount = 6;
            }
            else
            {
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().scale = 9f;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().mass = 16;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().livetime = 150;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxhp = 1500;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().maxfood = 1800;
                FindObjectOfType<PrefabLoader>().BasicObj.GetComponent<DnkPlant>().dietoorganiccount = 9;
            }
        }
       

        if (PlayerPrefs.GetInt("shopPlant") == 1)
        {
            //Playerrefabloader = refabloader;
        }

        if (PlayerPrefs.GetInt("shopPlant") == 2)
        {
            Playerrefabloader.GetComponent<DnkPlant>().scale = 3.3f;
            Playerrefabloader.GetComponent<DnkPlant>().mass = 7;
            Playerrefabloader.GetComponent<DnkPlant>().livetime = 38;
            Playerrefabloader.GetComponent<DnkPlant>().maxhp = 125;
            Playerrefabloader.GetComponent<DnkPlant>().maxfood = 234;
            Playerrefabloader.GetComponent<DnkPlant>().dietoorganiccount = 6;
        }
        if (PlayerPrefs.GetInt("shopPlant") == 3)
        {
            Playerrefabloader.GetComponent<DnkPlant>().scale = 6f;
            Playerrefabloader.GetComponent<DnkPlant>().mass = 7;
            Playerrefabloader.GetComponent<DnkPlant>().livetime = 38;
            Playerrefabloader.GetComponent<DnkPlant>().maxhp = 125;
            Playerrefabloader.GetComponent<DnkPlant>().maxfood = 234;
            Playerrefabloader.GetComponent<DnkPlant>().dietoorganiccount = 6;
        }
        if (PlayerPrefs.GetInt("shopPlant") == 4)
        {
            Playerrefabloader.GetComponent<DnkPlant>().scale = 4.5f;
            Playerrefabloader.GetComponent<DnkPlant>().mass = 15;
            Playerrefabloader.GetComponent<DnkPlant>().livetime = 42;
            Playerrefabloader.GetComponent<DnkPlant>().maxhp = 230;
            Playerrefabloader.GetComponent<DnkPlant>().maxfood = 280;
            Playerrefabloader.GetComponent<DnkPlant>().dietoorganiccount = 6;
        }
        if (PlayerPrefs.GetInt("shopPlant") == 5)
        {
            Playerrefabloader.GetComponent<DnkPlant>().scale = 9f;
            Playerrefabloader.GetComponent<DnkPlant>().mass = 16;
            Playerrefabloader.GetComponent<DnkPlant>().livetime = 150;
            Playerrefabloader.GetComponent<DnkPlant>().maxhp = 1500;
            Playerrefabloader.GetComponent<DnkPlant>().maxfood = 1800;
            Playerrefabloader.GetComponent<DnkPlant>().dietoorganiccount = 9;
        }
        if (PlayerPrefs.GetInt("shopRegeneration") == 0)
        {
            PlayerPrefs.SetInt("shopRegeneration", 1);
        }
        if (PlayerPrefs.GetInt("shopRegeneration") == 2)
        {
            Regenerationrefabloader.GetComponent<Regeneration>().scale =3f;
            Regenerationrefabloader.GetComponent<Regeneration>().scalestrong = 0.009f;
            Regenerationrefabloader.GetComponent<Regeneration>().maxhpstrong = 0.006f;
            Regenerationrefabloader.GetComponent<Regeneration>().index = 6;
            Regenerationrefabloader.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 177 / 255f, 0 / 255f);
        }
        if (PlayerPrefs.GetInt("shopRegeneration") == 3)
        {
            Regenerationrefabloader.GetComponent<Regeneration>().scale = 4f;
            Regenerationrefabloader.GetComponent<Regeneration>().scalestrong = 0.0012f;
            Regenerationrefabloader.GetComponent<Regeneration>().maxhpstrong = 0.008f;
            Regenerationrefabloader.GetComponent<Regeneration>().index = 7.8f;
            Regenerationrefabloader.GetComponent<SpriteRenderer>().color = new Color(255F / 255f, 95 / 255F, 0 / 255f);
        }
        if (PlayerPrefs.GetInt("shopRegeneration") == 4)
        {
            Regenerationrefabloader.GetComponent<Regeneration>().scale = 4.3f;
            Regenerationrefabloader.GetComponent<Regeneration>().scalestrong = 0.0012f;
            Regenerationrefabloader.GetComponent<Regeneration>().maxhpstrong = 0.008f;
            Regenerationrefabloader.GetComponent<Regeneration>().index = 7.8f;
            Regenerationrefabloader.GetComponent<SpriteRenderer>().color = new Color(213 / 255f, 255 / 255f, 0 / 255f);
        }

        Regenerationrefabloader.transform.localScale = new Vector3(Regenerationrefabloader.GetComponent<Regeneration>().scale, Regenerationrefabloader.GetComponent<Regeneration>().scale, Regenerationrefabloader.GetComponent<Regeneration>().scale);

        if (PlayerPrefs.GetInt("shopBonus") == 1)
        {
            Playerrefabloader.GetComponent<DnkPlant>().maxhp += 50;
        }
        if (PlayerPrefs.GetInt("shopBonus") == 2)
        {
            Playerrefabloader.GetComponent<DnkPlant>().scale += 1.5f;
        }
        if (PlayerPrefs.GetInt("shopBonus") == 3)
        {
            Playerrefabloader.GetComponent<DnkPlant>().livetime += 10;
        }
        if (PlayerPrefs.GetInt("shopBonus") == 4)
        {
            Playerrefabloader.GetComponent<DnkPlant>().dietoorganiccount += 4;
        }
        if (PlayerPrefs.GetInt("shopBonus") == 5)
        {
            Playerrefabloader.GetComponent<DnkPlant>().maxfood += 100;
            Playerrefabloader.GetComponent<DnkPlant>().timetohavefood -= 0.1f;
        }

        InvokeRepeating("TestToWin", 0, 1);
        DnkInputField.enabled = false;
        

        
      //  gbtextsandbox = GameObject.FindGameObjectWithTag("TxtButtonSandBox");
        isready = true;
        border = FindObjectOfType<Border>().gameObject;
        refabloader = FindObjectOfType<PrefabLoader>().BasicObj;


       
        for (int i = 0; i < analuticsplus.Length; i++)
        {
            analuticsplus[i].AnaluticsPlus_InputField.enabled = false;
        }

        if (isMenu)
        {
            SpawnObMenu();
        }
        if (gametype != 4 && !isneedmultiplayeroperation && FindObjectOfType<NumberEvolution>() == null)
        {
            if (GameManagers.Length < 2)
            {
                SpawnObMenu();
            }
            var VEC = new Vector3(Random.Range(spawnpoints[0].transform.position.x, spawnpoints[1].transform.position.x), Random.Range(spawnpoints[1].transform.position.y, spawnpoints[0].transform.position.y));
            for (int i = 0; i < PlayerPrefs.GetInt("shopSpawnCount"); i++)
            {
                if (isneedmultiplayeroperation)
                {
                    print("SECRET FUNCTION. isneedmultiplayeroperation = " + isneedmultiplayeroperation);
                    Playerrefabloader.GetComponent<DnkPlant>().type = mytype;
                    print(Playerrefabloader);
                }

                var obj = Instantiate(Playerrefabloader, new Vector3(VEC.x + Random.Range(-3, 3), VEC.y + Random.Range(-3, 3), VEC.z), Quaternion.identity);
                obj.layer = LayerMask.GetMask("WorldColide");
               // var gg = obj.AddComponent<IOClod>();
               // gg.Occludee = true;
                if (!isMenu)
                {
                    camera1.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, camera1.transform.position.z);
                }

                obj.SetActive(true);



                obj.GetComponent<DnkPlant>().scale += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().scale < 1.5f)
                {
                    obj.GetComponent<DnkPlant>().scale = 1.5f;
                }


                obj.GetComponent<DnkPlant>().color = new Color(Random.value, Random.value, Random.value, 1);



                obj.GetComponent<DnkPlant>().mass += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().mass < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().mass = 0.1f;
                }


                obj.GetComponent<DnkPlant>().drag += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().drag < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().drag = 0.1f;
                }


                obj.GetComponent<DnkPlant>().drag += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().drag < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().drag = 0.1f;
                }


                obj.GetComponent<DnkPlant>().speed += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().speed < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().speed = 0.1f;
                }


                obj.GetComponent<DnkPlant>().mintime_adult += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().mintime_adult < 2)
                {
                    obj.GetComponent<DnkPlant>().mintime_adult = 2;
                }


                obj.GetComponent<DnkPlant>().livetime += Random.Range(-7, 7);


                obj.GetComponent<DnkPlant>().needfoodsecond += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().needfoodsecond < 0.5f)
                {
                    obj.GetComponent<DnkPlant>().needfoodsecond = 0.5f;
                }



                obj.GetComponent<DnkPlant>().maxhp += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().maxhp < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().maxhp = 0.1f;
                }


                obj.GetComponent<DnkPlant>().maxfood += Random.Range(-10, 10);
                if (obj.GetComponent<DnkPlant>().maxfood < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().maxfood = 0.1f;
                }


                obj.GetComponent<DnkPlant>().timetohavefood += Random.Range(-0.4f, 0.4f);
                if (obj.GetComponent<DnkPlant>().timetohavefood < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().timetohavefood = 0.1f;
                }


                obj.GetComponent<DnkPlant>().maxdistancespawn += Random.Range(-3.5f, -3.5f);


                obj.GetComponent<DnkPlant>().chancetochild1 += Random.Range(-15, 15);
                if (obj.GetComponent<DnkPlant>().chancetochild1 < 5)
                {
                    obj.GetComponent<DnkPlant>().chancetochild1 = 5;

                }


                obj.GetComponent<DnkPlant>().tochildfood += Random.Range(-4, 4);



                obj.GetComponent<DnkPlant>().tochildfood += Random.Range(-4, 4);



                obj.GetComponent<DnkPlant>().dietoorganiccount += Random.Range(-2.5f, 2.5f);



                if (obj.GetComponent<DnkPlant>().canoneandonetoone) { obj.GetComponent<DnkPlant>().canoneandonetoone = false; }
                if (!obj.GetComponent<DnkPlant>().canoneandonetoone) { obj.GetComponent<DnkPlant>().canoneandonetoone = true; }

                int chancetype = Random.Range(1, 12);
                if (chancetype > 2)
                {
                    obj.GetComponent<DnkPlant>().typespawn = 0;
                }
                else
                {
                    obj.GetComponent<DnkPlant>().typespawn = Random.Range(1, 2);
                }




                obj.GetComponent<DnkPlant>().shape = Random.Range(1, 3);
                //Debug.Log(obj);





            }
        

        if (isMenu)
        {
            SpawnObMenu();
        }


        FindObjectOfType<GPUInstancerPrefabManager>().autoSelectCamera = true;


        }
        else if (gametype!=4 && FindObjectOfType<NumberEvolution>() == null)
        {
            if (GameManagers.Length < 2)
            {
                SpawnObMenu();
            }
            var VEC = new Vector3(Random.Range(spawnpoints[0].transform.position.x, spawnpoints[1].transform.position.x), Random.Range(spawnpoints[1].transform.position.y, spawnpoints[0].transform.position.y));
            for (int i = 0; i < PlayerPrefs.GetInt("shopSpawnCount"); i++)
            {
                if (isneedmultiplayeroperation)
                {
                    //print("SECRET FUNCTION. isneedmultiplayeroperation = " + isneedmultiplayeroperation);
                    Playerrefabloader.GetComponent<DnkPlant>().type = mytype;
                    //print(Playerrefabloader);
                }

                GameObject obj = (GameObject)PhotonNetwork.Instantiate("Empty", new Vector3(VEC.x + Random.Range(-3, 3), VEC.y + Random.Range(-3, 3), VEC.z), Quaternion.identity);
                obj.name = "Empty" + Random.Range(0, 10000);
                print("@@_1 INSTANT NAME: " + obj.name);
                print("@@_2 PARENT for " + obj.name + ". PLAYERREFABLOADER: " + Playerrefabloader.name);
               // UnityEngine.Component[] components = Playerrefabloader.GetComponents<UnityEngine.Component>();
                UnityEngine.Component[] componentsobj = obj.GetComponents<UnityEngine.Component>();

                
                //   for (int q = 0; q < components.Length; q++)
                //   {
                //      UnityEditorInternal.ComponentUtility.CopyComponent(components[q]);
                //       UnityEngine.Component comptopaste =  obj.AddComponent(components[q].GetType());
                //      UnityEditorInternal.ComponentUtility.PasteComponentValues(comptopaste);
                //   }


                // Получаем все компоненты на объекте-источнике
                UnityEngine.Component[] components = Playerrefabloader.GetComponents<UnityEngine.Component>();

                // Копируем каждый компонент на объект-приемник
                foreach (UnityEngine.Component component in components)
                {
                    // Пропускаем компонент CopyAllComponents, чтобы избежать бесконечной рекурсии
                    //print("foreach");
                    // Создаем новый компонент на объекте-приемнике и копируем значения из компонента-источника
                    if (!(component is Transform))
                    {
                        print("@@_3 TRANSFER COMPONENT: " + component.GetType() + " FROM : " + Playerrefabloader.name + " TO: " + obj.name);
                        UnityEngine.Component newComponent = obj.AddComponent(component.GetType());
                        System.Reflection.FieldInfo[] fields = component.GetType().GetFields();
                        print("@@_4 SOURCE " + Playerrefabloader.name + " COMPONENT " + component.GetType() + " :  " + component.ToString());

                        foreach (System.Reflection.FieldInfo field in fields)
                        {
                            print("@@_5 TRANSFER " + field.Name + " VALUE: " + field.GetValue(component) + " OF COMPONENT: " + component.GetType() + " FROM : " + Playerrefabloader.name + " TO: " + obj.name);
                            field.SetValue(newComponent, field.GetValue(component));
                        }
                        print("@@_6 TARGET " + obj.name + " COMPONENT " + newComponent.GetType() + " :  " + newComponent.ToString());
                    }
                }

                
                foreach (UnityEngine.Component component in components)
                {
                    System.Reflection.FieldInfo[] fields = component.GetType().GetFields();
                    foreach (System.Reflection.FieldInfo field in fields)
                    {
                        print("## RESULT SOURCE!!! " + Playerrefabloader.name + component.ToString() + " FIELD: " + field.Name + " : " + field.GetValue(component));
                    }

                }

                UnityEngine.Component[] components_target = obj.GetComponents<UnityEngine.Component>();
                foreach (UnityEngine.Component comp_target in components_target)
                {
                    System.Reflection.FieldInfo[] fields = comp_target.GetType().GetFields();
                    foreach (System.Reflection.FieldInfo field in fields)
                    {
                        print("## RESULT TARGET!!! " + obj.name + comp_target.ToString() + " FIELD: " + field.Name + " : " + field.GetValue(comp_target));
                    }

                }


                obj.GetComponent<SpriteRenderer>().sprite = Playerrefabloader.GetComponent<SpriteRenderer>().sprite;
                obj.GetComponent<DnkPlant>().scaleV3 = new Vector3(obj.GetComponent<DnkPlant>().scale, obj.GetComponent<DnkPlant>().scale, obj.GetComponent<DnkPlant>().scale);
                obj.transform.localScale = obj.GetComponent<DnkPlant>().scaleV3;
                obj.GetComponent<SpriteRenderer>().color = obj.GetComponent<DnkPlant>().color;
                //print("Playerrefabloader - " + Playerrefabloader);
                camera1.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, camera1.transform.position.z);
                Playerrefabloader.SetActive(false);
                Destroy(GameObject.Find("PLAYERobj(Clone)"));
                obj.SetActive(true);
                //obj.GetComponent<SpriteRenderer>().sprite = Resources.Load("Packages/2D Sprite/Editor/ObjectMenuCreation/DefaultAssets/Textures/v2/Square") as Sprite;
                if (!isMenu)
                {
                    camera1.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, -30);
                }

                obj.SetActive(true);



                obj.GetComponent<DnkPlant>().scale += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().scale < 1.5f)
                {
                    obj.GetComponent<DnkPlant>().scale = 1.5f;
                }


                obj.GetComponent<DnkPlant>().color = new Color(Random.value, Random.value, Random.value, 1);



                obj.GetComponent<DnkPlant>().mass += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().mass < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().mass = 0.1f;
                }


                obj.GetComponent<DnkPlant>().drag += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().drag < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().drag = 0.1f;
                }


                obj.GetComponent<DnkPlant>().drag += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().drag < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().drag = 0.1f;
                }


                obj.GetComponent<DnkPlant>().speed += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().speed < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().speed = 0.1f;
                }


                obj.GetComponent<DnkPlant>().mintime_adult += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().mintime_adult < 2)
                {
                    obj.GetComponent<DnkPlant>().mintime_adult = 2;
                }


                obj.GetComponent<DnkPlant>().livetime += Random.Range(-7, 7);


                obj.GetComponent<DnkPlant>().needfoodsecond += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().needfoodsecond < 0.5f)
                {
                    obj.GetComponent<DnkPlant>().needfoodsecond = 0.5f;
                }



                obj.GetComponent<DnkPlant>().maxhp += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().maxhp < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().maxhp = 0.1f;
                }


                obj.GetComponent<DnkPlant>().maxfood += Random.Range(-10, 10);
                if (obj.GetComponent<DnkPlant>().maxfood < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().maxfood = 0.1f;
                }


                obj.GetComponent<DnkPlant>().timetohavefood += Random.Range(-0.4f, 0.4f);
                if (obj.GetComponent<DnkPlant>().timetohavefood < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().timetohavefood = 0.1f;
                }


                obj.GetComponent<DnkPlant>().maxdistancespawn += Random.Range(-3.5f, -3.5f);


                obj.GetComponent<DnkPlant>().chancetochild1 += Random.Range(-15, 15);
                if (obj.GetComponent<DnkPlant>().chancetochild1 < 5)
                {
                    obj.GetComponent<DnkPlant>().chancetochild1 = 5;

                }


                obj.GetComponent<DnkPlant>().tochildfood += Random.Range(-4, 4);



                obj.GetComponent<DnkPlant>().tochildfood += Random.Range(-4, 4);



                obj.GetComponent<DnkPlant>().dietoorganiccount += Random.Range(-2.5f, 2.5f);



                if (obj.GetComponent<DnkPlant>().canoneandonetoone) { obj.GetComponent<DnkPlant>().canoneandonetoone = false; }
                if (!obj.GetComponent<DnkPlant>().canoneandonetoone) { obj.GetComponent<DnkPlant>().canoneandonetoone = true; }

                int chancetype = Random.Range(1, 12);
                if (chancetype > 2)
                {
                    obj.GetComponent<DnkPlant>().typespawn = 0;
                }
                else
                {
                    obj.GetComponent<DnkPlant>().typespawn = Random.Range(1, 2);
                }




                obj.GetComponent<DnkPlant>().shape = Random.Range(1, 3);
                //Debug.Log(obj);





            }


            if (isMenu)
            {
                SpawnObMenu();
            }


            FindObjectOfType<GPUInstancerPrefabManager>().autoSelectCamera = true;
        }
        camera1 = FindObjectOfType<Camera>().gameObject;
     //   camera1.AddComponent<IOCcam>();
    }
    //print("SSSSSSSSSSSSSSSSSSSSSSSSS");








   
    IEnumerator DisconnectAndLoad()
    {
        if (PhotonNetwork.InRoom)
        {
            SceneManager.LoadScene("Menu");
            GameObject gb = new GameObject();
            gb.AddComponent<ThisGameManagerIsMultiplayer>();
            DontDestroyOnLoad(gb);
            

            PhotonNetwork.AutomaticallySyncScene = false;
        }
        else
            yield return null;

        PhotonNetwork.Disconnect();

    }
    public void Menu()
    {
        
      if (isMultiPlayer)
      {



            Destroy(RoomManager.Instance.gameObject);

            StartCoroutine(DisconnectAndLoad());
           // SceneManager.LoadScene("Menu");




        }
          else
        {
            SceneManager.LoadScene("Menu");
        }
        
       
       
    }


    public void inputfieldvaluePlus(TMP_InputField inputfield)
    {
        if (dnk - valueeditgame > 0)
        {
            //print("a");
            float index = 1;
            if (inputfield.name == "InputField(TMP) (6)")
            {
                index = 0.2f;
            }
            if (inputfield.name == "InputField (TMP) (9)")
            {
                index = 0.2f;
            }
            var value = (float.Parse(inputfield.text) + index);
            edittogle.isOn = true;
            inputfield.text = value + "";
            int r = 0;

            if (!settingsdnkplant[0].isOn && !settingsdnkplant[1].isOn)
            {
                //print("b");
                clickobjectinfo.GetComponent<DnkPlant>().type = int.Parse(inputFieldsdnk[0].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().scale = float.Parse(inputFieldsdnk[1].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().mass = float.Parse(inputFieldsdnk[2].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().mintime_adult = float.Parse(inputFieldsdnk[3].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().time_adult = float.Parse(inputFieldsdnk[4].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().livetime = float.Parse(inputFieldsdnk[5].GetComponent<TMP_InputField>().text);



                clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = float.Parse(inputFieldsdnk[6].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().maxhp = float.Parse(inputFieldsdnk[7].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().maxfood = float.Parse(inputFieldsdnk[8].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = float.Parse(inputFieldsdnk[9].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn = float.Parse(inputFieldsdnk[10].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 = int.Parse(inputFieldsdnk[11].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().tochildfood = float.Parse(inputFieldsdnk[12].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount = float.Parse(inputFieldsdnk[13].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().shape = inputFieldsdnk[15].GetComponent<Dropdown>().value;

                edittogle.isOn = false;
                if (clickobjectinfo.GetComponent<DnkPlant>().timetohavefood < 0.5f)
                {
                    clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = 0.5f;
                }
                if (clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond <= 0.1f)
                {
                    clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = 0.1f;
                }

                clickobjectinfo.GetComponent<DnkPlant>().scaleV3 = new Vector3(clickobjectinfo.GetComponent<DnkPlant>().scale, clickobjectinfo.GetComponent<DnkPlant>().scale, 1);
                clickobjectinfo.GetComponent<Transform>().localScale = clickobjectinfo.GetComponent<DnkPlant>().scaleV3;
                clickobjectinfo.GetComponent<SpriteRenderer>().color = clickobjectinfo.GetComponent<DnkPlant>().color;
                clickobjectinfo.GetComponent<Rigidbody2D>().mass = clickobjectinfo.GetComponent<DnkPlant>().mass;
                clickobjectinfo.GetComponent<Rigidbody2D>().drag = clickobjectinfo.GetComponent<DnkPlant>().drag;
            }
            if (settingsdnkplant[0].isOn)
            {

                for (int i = 0; i < plant1.Length; i++)
                {
                    if ((plant1[i].GetComponent<DnkPlant>().type == mytype || ((plant1[i].GetComponent<DnkPlant>().strong <= 40 && PlayerPrefs.GetInt("shopControl") == 2) || (plant1[i].GetComponent<DnkPlant>().strong <= 85 && PlayerPrefs.GetInt("shopControl") == 3) || (PlayerPrefs.GetInt("shopControl") == 4))))
                    {
                        clickobjectinfo = plant1[i];
                        inputfield.text = value + "";
                        if (clickobjectinfo.GetComponent<DnkPlant>().timetohavefood < 0.5f)
                        {
                            clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = 0.5f;
                        }
                        if (clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond <= 0.1f)
                        {
                            clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = 0.1f;
                        }
                        clickobjectinfo.GetComponent<DnkPlant>().type = int.Parse(inputFieldsdnk[0].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().scale = float.Parse(inputFieldsdnk[1].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().mass = float.Parse(inputFieldsdnk[2].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().mintime_adult = float.Parse(inputFieldsdnk[3].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().time_adult = float.Parse(inputFieldsdnk[4].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().livetime = float.Parse(inputFieldsdnk[5].GetComponent<TMP_InputField>().text);



                        clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = float.Parse(inputFieldsdnk[6].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().maxhp = float.Parse(inputFieldsdnk[7].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().maxfood = float.Parse(inputFieldsdnk[8].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = float.Parse(inputFieldsdnk[9].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn = float.Parse(inputFieldsdnk[10].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 = int.Parse(inputFieldsdnk[11].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().tochildfood = float.Parse(inputFieldsdnk[12].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount = float.Parse(inputFieldsdnk[13].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().shape = inputFieldsdnk[15].GetComponent<Dropdown>().value;

                        edittogle.isOn = false;

                        clickobjectinfo.GetComponent<DnkPlant>().scaleV3 = new Vector3(clickobjectinfo.GetComponent<DnkPlant>().scale, clickobjectinfo.GetComponent<DnkPlant>().scale, 1);
                        clickobjectinfo.GetComponent<Transform>().localScale = clickobjectinfo.GetComponent<DnkPlant>().scaleV3;
                        clickobjectinfo.GetComponent<SpriteRenderer>().color = clickobjectinfo.GetComponent<DnkPlant>().color;
                        clickobjectinfo.GetComponent<Rigidbody2D>().mass = clickobjectinfo.GetComponent<DnkPlant>().mass;
                        clickobjectinfo.GetComponent<Rigidbody2D>().drag = clickobjectinfo.GetComponent<DnkPlant>().drag;

                    }
                }
            }
            if (settingsdnkplant[1].isOn)
            {
                if (plant1.Length - r > 0)
                {
                    for (int i = 0; i < int.Parse(settingsdnkplant1inp.text);)
                    {

                        if ((plant1[plant1.Length - r - 1].GetComponent<DnkPlant>().type == mytype || (plant1[plant1.Length - r - 1].GetComponent<DnkPlant>().strong <= 40 && PlayerPrefs.GetInt("shopControl") == 2) || plant1[plant1.Length - r - 1].GetComponent<DnkPlant>().strong <= 85 && PlayerPrefs.GetInt("shopControl") == 3) || (PlayerPrefs.GetInt("shopControl") == 4))
                        {
                            //Debug.Log("лан");
                            i += 1;
                            r += 1;
                            clickobjectinfo = plant1[plant1.Length - r];
                            inputfield.text = value + "";
                            if (clickobjectinfo.GetComponent<DnkPlant>().timetohavefood < 0.5f)
                            {
                                clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = 0.5f;
                            }
                            if (clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond <= 0.1f)
                            {
                                clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = 0.1f;
                            }
                            clickobjectinfo.GetComponent<DnkPlant>().type = int.Parse(inputFieldsdnk[0].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().scale = float.Parse(inputFieldsdnk[1].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().mass = float.Parse(inputFieldsdnk[2].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().mintime_adult = float.Parse(inputFieldsdnk[3].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().time_adult = float.Parse(inputFieldsdnk[4].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().livetime = float.Parse(inputFieldsdnk[5].GetComponent<TMP_InputField>().text);



                            clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = float.Parse(inputFieldsdnk[6].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().maxhp = float.Parse(inputFieldsdnk[7].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().maxfood = float.Parse(inputFieldsdnk[8].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = float.Parse(inputFieldsdnk[9].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn = float.Parse(inputFieldsdnk[10].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 = int.Parse(inputFieldsdnk[11].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().tochildfood = float.Parse(inputFieldsdnk[12].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount = float.Parse(inputFieldsdnk[13].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().shape = inputFieldsdnk[15].GetComponent<Dropdown>().value;

                            edittogle.isOn = false;

                            clickobjectinfo.GetComponent<DnkPlant>().scaleV3 = new Vector3(clickobjectinfo.GetComponent<DnkPlant>().scale, clickobjectinfo.GetComponent<DnkPlant>().scale, 1);
                            clickobjectinfo.GetComponent<Transform>().localScale = clickobjectinfo.GetComponent<DnkPlant>().scaleV3;
                            clickobjectinfo.GetComponent<SpriteRenderer>().color = clickobjectinfo.GetComponent<DnkPlant>().color;
                            clickobjectinfo.GetComponent<Rigidbody2D>().mass = clickobjectinfo.GetComponent<DnkPlant>().mass;
                            clickobjectinfo.GetComponent<Rigidbody2D>().drag = clickobjectinfo.GetComponent<DnkPlant>().drag;
                        }
                        else
                        {
                            r += 1;
                        }
                    }
                }

            }





        }









        if (clickobjectinfo.GetComponent<DnkPlant>().timetohavefood < 0.5f)
        {
            clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = 0.5f;
        }
        if (clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond <= 0.1f)
        {
            clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = 0.1f;
        }


        edittogle.isOn = false;
    }

    public void inputfieldvalueMinus(TMP_InputField inputfield)
    {
        if (dnk - valueeditgame > 0)
        {
            float index = 1;
            if (inputfield.name == "InputField(TMP) (6)")
            {
                index = 0.2f;
            }
            if (inputfield.name == "InputField (TMP) (9)")
            {
                index = 0.2f;
            }
            var value = (float.Parse(inputfield.text) - index);
            edittogle.isOn = true;
            inputfield.text = value + "";
            int r = 0;

            if (!settingsdnkplant[0].isOn && !settingsdnkplant[1].isOn)
            {
                inputfield.text = value + "";
                clickobjectinfo.GetComponent<DnkPlant>().type = int.Parse(inputFieldsdnk[0].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().scale = float.Parse(inputFieldsdnk[1].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().mass = float.Parse(inputFieldsdnk[2].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().mintime_adult = float.Parse(inputFieldsdnk[3].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().time_adult = float.Parse(inputFieldsdnk[4].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().livetime = float.Parse(inputFieldsdnk[5].GetComponent<TMP_InputField>().text);



                clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = float.Parse(inputFieldsdnk[6].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().maxhp = float.Parse(inputFieldsdnk[7].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().maxfood = float.Parse(inputFieldsdnk[8].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = float.Parse(inputFieldsdnk[9].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn = float.Parse(inputFieldsdnk[10].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 = int.Parse(inputFieldsdnk[11].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().tochildfood = float.Parse(inputFieldsdnk[12].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount = float.Parse(inputFieldsdnk[13].GetComponent<TMP_InputField>().text);


                clickobjectinfo.GetComponent<DnkPlant>().shape = inputFieldsdnk[15].GetComponent<Dropdown>().value;

                edittogle.isOn = false;
                if (clickobjectinfo.GetComponent<DnkPlant>().timetohavefood < 0.5f)
                {
                    clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = 0.5f;
                }
                if (clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond <= 0.1f)
                {
                    clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = 0.1f;
                }
                clickobjectinfo.GetComponent<DnkPlant>().scaleV3 = new Vector3(clickobjectinfo.GetComponent<DnkPlant>().scale, clickobjectinfo.GetComponent<DnkPlant>().scale, 1);
                clickobjectinfo.GetComponent<Transform>().localScale = clickobjectinfo.GetComponent<DnkPlant>().scaleV3;
                clickobjectinfo.GetComponent<SpriteRenderer>().color = clickobjectinfo.GetComponent<DnkPlant>().color;
                clickobjectinfo.GetComponent<Rigidbody2D>().mass = clickobjectinfo.GetComponent<DnkPlant>().mass;
                clickobjectinfo.GetComponent<Rigidbody2D>().drag = clickobjectinfo.GetComponent<DnkPlant>().drag;
            }
            if (settingsdnkplant[0].isOn)
            {

                for (int i = 0; i < plant1.Length; i++)
                {
                    if ((plant1[i].GetComponent<DnkPlant>() || (plant1[i].GetComponent<DnkPlant>().strong <= 40 && PlayerPrefs.GetInt("shopControl") == 2) || plant1[i].GetComponent<DnkPlant>().strong <= 85 && PlayerPrefs.GetInt("shopControl") == 3) || (PlayerPrefs.GetInt("shopControl") == 4))
                    {
                        clickobjectinfo = plant1[i];
                        inputfield.text = value + "";
                        if (clickobjectinfo.GetComponent<DnkPlant>().timetohavefood < 0.5f)
                        {
                            clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = 0.5f;
                        }
                        if (clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond <= 0.1f)
                        {
                            clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = 0.1f;
                        }
                        clickobjectinfo.GetComponent<DnkPlant>().type = int.Parse(inputFieldsdnk[0].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().scale = float.Parse(inputFieldsdnk[1].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().mass = float.Parse(inputFieldsdnk[2].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().mintime_adult = float.Parse(inputFieldsdnk[3].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().time_adult = float.Parse(inputFieldsdnk[4].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().livetime = float.Parse(inputFieldsdnk[5].GetComponent<TMP_InputField>().text);



                        clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = float.Parse(inputFieldsdnk[6].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().maxhp = float.Parse(inputFieldsdnk[7].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().maxfood = float.Parse(inputFieldsdnk[8].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = float.Parse(inputFieldsdnk[9].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn = float.Parse(inputFieldsdnk[10].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 = int.Parse(inputFieldsdnk[11].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().tochildfood = float.Parse(inputFieldsdnk[12].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount = float.Parse(inputFieldsdnk[13].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().shape = inputFieldsdnk[15].GetComponent<Dropdown>().value;

                        edittogle.isOn = false;

                        clickobjectinfo.GetComponent<DnkPlant>().scaleV3 = new Vector3(clickobjectinfo.GetComponent<DnkPlant>().scale, clickobjectinfo.GetComponent<DnkPlant>().scale, 1);
                        clickobjectinfo.GetComponent<Transform>().localScale = clickobjectinfo.GetComponent<DnkPlant>().scaleV3;
                        clickobjectinfo.GetComponent<SpriteRenderer>().color = clickobjectinfo.GetComponent<DnkPlant>().color;
                        clickobjectinfo.GetComponent<Rigidbody2D>().mass = clickobjectinfo.GetComponent<DnkPlant>().mass;
                        clickobjectinfo.GetComponent<Rigidbody2D>().drag = clickobjectinfo.GetComponent<DnkPlant>().drag;

                    }
                }
            }
            if (settingsdnkplant[1].isOn)
            {
                if (plant1.Length - r > 0)
                {
                    for (int i = 0; i < int.Parse(settingsdnkplant1inp.text);)
                    {

                        if ((plant1[plant1.Length - r - 1].GetComponent<DnkPlant>().type == mytype || (plant1[plant1.Length - r - 1].GetComponent<DnkPlant>().strong <= 40 && PlayerPrefs.GetInt("shopControl") == 2) || plant1[plant1.Length - r - 1].GetComponent<DnkPlant>().strong <= 85 && PlayerPrefs.GetInt("shopControl") == 3) || (PlayerPrefs.GetInt("shopControl") == 4))
                        {
                            //Debug.Log("лан");
                            i += 1;
                            r += 1;
                            clickobjectinfo = plant1[plant1.Length - r];
                            inputfield.text = value + "";
                            if (clickobjectinfo.GetComponent<DnkPlant>().timetohavefood < 0.5f)
                            {
                                clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = 0.5f;
                            }
                            if (clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond <= 0.1f)
                            {
                                clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = 0.1f;
                            }
                            clickobjectinfo.GetComponent<DnkPlant>().type = int.Parse(inputFieldsdnk[0].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().scale = float.Parse(inputFieldsdnk[1].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().mass = float.Parse(inputFieldsdnk[2].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().mintime_adult = float.Parse(inputFieldsdnk[3].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().time_adult = float.Parse(inputFieldsdnk[4].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().livetime = float.Parse(inputFieldsdnk[5].GetComponent<TMP_InputField>().text);



                            clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = float.Parse(inputFieldsdnk[6].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().maxhp = float.Parse(inputFieldsdnk[7].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().maxfood = float.Parse(inputFieldsdnk[8].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = float.Parse(inputFieldsdnk[9].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn = float.Parse(inputFieldsdnk[10].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 = int.Parse(inputFieldsdnk[11].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().tochildfood = float.Parse(inputFieldsdnk[12].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount = float.Parse(inputFieldsdnk[13].GetComponent<TMP_InputField>().text);


                            clickobjectinfo.GetComponent<DnkPlant>().shape = inputFieldsdnk[15].GetComponent<Dropdown>().value;

                            edittogle.isOn = false;

                            clickobjectinfo.GetComponent<DnkPlant>().scaleV3 = new Vector3(clickobjectinfo.GetComponent<DnkPlant>().scale, clickobjectinfo.GetComponent<DnkPlant>().scale, 1);
                            clickobjectinfo.GetComponent<Transform>().localScale = clickobjectinfo.GetComponent<DnkPlant>().scaleV3;
                            clickobjectinfo.GetComponent<SpriteRenderer>().color = clickobjectinfo.GetComponent<DnkPlant>().color;
                            clickobjectinfo.GetComponent<Rigidbody2D>().mass = clickobjectinfo.GetComponent<DnkPlant>().mass;
                            clickobjectinfo.GetComponent<Rigidbody2D>().drag = clickobjectinfo.GetComponent<DnkPlant>().drag;
                        }
                        else
                        {
                            r += 1;
                        }
                    }
                }
                
            }





        }









        if (clickobjectinfo.GetComponent<DnkPlant>().timetohavefood < 0.5f)
        {
            clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = 0.5f;
        }
        if (clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond <= 0.1f)
        {
            clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = 0.1f;
        }


        edittogle.isOn = false;















        if (clickobjectinfo.GetComponent<DnkPlant>().timetohavefood < 0.5f)
        {
            clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = 0.5f;
        }
        if (clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond <= 0.1f)
        {
            clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = 0.1f;
        }


        edittogle.isOn = false;
    }





    public void Addvalue(int value)
    {
        valueeditgame = value;

        if (settingsdnkplant[0].isOn && dnk - valueeditgame * int.Parse(analuticsplus[clickobjectinfo.GetComponent<DnkPlant>().type].AnaluticsPlus_InputField.text) >= 0)
        {
            valueeditgame = valueeditgame * int.Parse(analuticsplus[clickobjectinfo.GetComponent<DnkPlant>().type].AnaluticsPlus_InputField.text) ;
        }
        if (settingsdnkplant[1].isOn && dnk - valueeditgame * int.Parse(settingsdnkplant1inp.text) >= 0)
        {
            valueeditgame = valueeditgame * int.Parse(settingsdnkplant1inp.text);
        }
        if (dnk - valueeditgame >= 0)
        {
            dnk -= valueeditgame;
        }
        else
        {

            GameObject gb = Instantiate(SpawnText);
            gb.SetActive(true);
            gb.transform.position = new Vector3(950, 0, 0);
            gb.GetComponent<TMP_Text>().text = "You are missing " + ((dnk - value) * -1) + " dnk";
            gb.transform.parent = canvas[0].transform;
            
        }

       
    }

   
    void SpawnObMenu()
    {

   
        if (isMenu)
        {
            border = GameObject.FindObjectOfType<Border>().gameObject;
            border.GetComponent<Border>().transform.localScale = new Vector3(2.22f, 3.64f, 1);
        }
        //Debug.Log("inst111");
        int rr = Random.Range(3, 10);
        totalcount = rr;
        //if (!IsNeedNoSpawn && !isMultiPlayer)
        
            for (int i = 0; i < rr; i++)
            {
                //Debug.Log("inst");
                var obj = Instantiate(refabloader, new Vector3(Random.Range(spawnpoints[0].transform.position.x, spawnpoints[1].transform.position.x), Random.Range(spawnpoints[1].transform.position.y, spawnpoints[0].transform.position.y)), Quaternion.identity);
           // var gg = obj.AddComponent<IOClod>();
           // gg.Occludee = true;
            obj.SetActive(true);
            obj.layer = LayerMask.GetMask("WorldColide");



            obj.GetComponent<DnkPlant>().scale += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().scale < 1.5f)
                {
                    obj.GetComponent<DnkPlant>().scale = 1.5f;
                }


                obj.GetComponent<DnkPlant>().color = new Color(Random.value, Random.value, Random.value, 1);



                obj.GetComponent<DnkPlant>().mass += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().mass < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().mass = 0.1f;
                }


                obj.GetComponent<DnkPlant>().drag += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().drag < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().drag = 0.1f;
                }


                obj.GetComponent<DnkPlant>().drag += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().drag < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().drag = 0.1f;
                }


                obj.GetComponent<DnkPlant>().speed += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().speed < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().speed = 0.1f;
                }


                obj.GetComponent<DnkPlant>().mintime_adult += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().mintime_adult < 2)
                {
                    obj.GetComponent<DnkPlant>().mintime_adult = 2;
                }


                obj.GetComponent<DnkPlant>().livetime += Random.Range(-7, 7);


                obj.GetComponent<DnkPlant>().needfoodsecond += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().needfoodsecond < 0.5f)
                {
                    obj.GetComponent<DnkPlant>().needfoodsecond = 0.5f;
                }



                obj.GetComponent<DnkPlant>().maxhp += Random.Range(-3, 3);
                if (obj.GetComponent<DnkPlant>().maxhp < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().maxhp = 0.1f;
                }


                obj.GetComponent<DnkPlant>().maxfood += Random.Range(-10, 10);
                if (obj.GetComponent<DnkPlant>().maxfood < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().maxfood = 0.1f;
                }


                obj.GetComponent<DnkPlant>().timetohavefood += Random.Range(-0.4f, 0.4f);
                if (obj.GetComponent<DnkPlant>().timetohavefood < 0.1f)
                {
                    obj.GetComponent<DnkPlant>().timetohavefood = 0.1f;
                }


                obj.GetComponent<DnkPlant>().maxdistancespawn += Random.Range(-3.5f, -3.5f);


                obj.GetComponent<DnkPlant>().chancetochild1 += Random.Range(-15, 15);
                if (obj.GetComponent<DnkPlant>().chancetochild1 < 5)
                {
                    obj.GetComponent<DnkPlant>().chancetochild1 = 5;

                }


                obj.GetComponent<DnkPlant>().tochildfood += Random.Range(-4, 4);



                obj.GetComponent<DnkPlant>().tochildfood += Random.Range(-4, 4);



                obj.GetComponent<DnkPlant>().dietoorganiccount += Random.Range(-2.5f, 2.5f);



                if (obj.GetComponent<DnkPlant>().canoneandonetoone) { obj.GetComponent<DnkPlant>().canoneandonetoone = false; }
                if (!obj.GetComponent<DnkPlant>().canoneandonetoone) { obj.GetComponent<DnkPlant>().canoneandonetoone = true; }

                int chancetype = Random.Range(1, 12);
                if (chancetype > 2)
                {
                    obj.GetComponent<DnkPlant>().typespawn = 0;
                }
                else
                {
                    obj.GetComponent<DnkPlant>().typespawn = Random.Range(1, 2);
                }


                obj.GetComponent<DnkPlant>().type = i + 1;


                obj.GetComponent<DnkPlant>().shape = Random.Range(1, 3);
                //Debug.Log(obj);
                var randval = Random.Range(gametype - 2, gametype + 1);
                if (randval > 0)
                {
                    for (int r = 0; r < randval; r++)
                    {
                        Instantiate(obj, new Vector3(obj.transform.position.x + Random.Range(-3, 3), obj.transform.position.y + Random.Range(-3, 3), 0), Quaternion.identity);
                    }
                }

            
        }
       

    }



    public void ExitDnkInfo()
    {
        FindObjectOfType<DnkOnformationPlant2>().ismouse = false;
        FindObjectOfType<DnkOnformationPlant1>().ismouse = false;
        FindObjectOfType<DnkOnformationPlant>().ismouse = false;
        paneldnk.SetActive(false);
        isinfoon = false;
        edittogle.isOn = false;
        clickobjectinfo = null;
        IsColorChange = false;

    }

    void TestToWin()
    {
        
        int r = 0;
        for (int i = 0; i < analuticsplus.Length; i++)
        {
            if (int.Parse(analuticsplus[i].AnaluticsPlus_InputField.text) > 0)
            {
                if (mytype != i)
                {
                    r += 1;
                }
               
            }
        }
        if ( 4>5 && !ScreenLose.activeSelf && r == 0 && gametype != 4 && !StartEvolution.activeSelf && !IsNeedNoSpawn)
        {
            ScreenLose.SetActive(true);
            ScreenLoseText.text = "You took the " + "1" + " place" + " out of " + totalcount;
         
            PlayerPrefs.SetFloat("GlobalDnk", (PlayerPrefs.GetFloat("GlobalDnk") + 15 * gametype));
            float delta = 15;
            delta *= gametype;
            PlayerPrefs.SetFloat("GlobalDnk", (PlayerPrefs.GetFloat("GlobalDnk") + delta));
            ScreenLoseTextMoney.text = "Your reward - " + Mathf.Round(delta) + " dnk";
            timeinputfield.text = 0 + "";

        }
        if (4 > 5 && !ScreenLose.activeSelf && r == 0 && gametype != 4 && !StartEvolution.activeSelf && IsNeedNoSpawn)
        {
            ScreenLose.SetActive(true);
            ScreenLoseText.text = "You beat the boss";

            PlayerPrefs.SetFloat("GlobalDnk", (PlayerPrefs.GetFloat("GlobalDnk") + 15));
            float delta = 15;
            delta *= gametype;
            PlayerPrefs.SetFloat("GlobalDnk", (PlayerPrefs.GetFloat("GlobalDnk") + delta));
            ScreenLoseTextMoney.text = "Your reward - " + Mathf.Round(delta) + " dnk";
            timeinputfield.text = 0 + "";
            

                PlayerPrefs.SetInt("maxlevelbossfights", PlayerPrefs.GetInt("maxlevelbossfights") + 1);
            
        }
    }

    private void FixedUpdate()
    {
       
        if (!isMenu && gametype != 4 && time != 0 && border.transform.localScale.x > 0 && border.transform.localScale.y > 0)
        {
            border.GetComponent<Border>().inputFields[0].text = ((float.Parse(border.GetComponent<Border>().inputFields[0].text) - 0.01f) + "");
            border.GetComponent<Border>().inputFields[1].text = ((float.Parse(border.GetComponent<Border>().inputFields[1].text) - 0.01f) + "");
        }
    }
    // Update is called once per frame
    void Update()
    {
       
        if (isMenu && plant1.Length == 0)
        {
            SpawnObMenu();
        }
        //print("YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEESSSSSSSSSSS");
        if (!isMenu)
        {
            GameObject.FindGameObjectWithTag("ImageBG").transform.localScale = new Vector3(camera1.GetComponent<Camera>().orthographicSize / 2.5f, camera1.GetComponent<Camera>().orthographicSize / 3, camera1.GetComponent<Camera>().orthographicSize / 50);

        }

        // Debug.Log("GlobalDnk" + PlayerPrefs.GetFloat("GlobalDnk"));
        regenerationMassive = GameObject.FindObjectsOfType<Regeneration>();
       // Debug.Log(PlayerPrefs.GetInt("shopRegeneration"));

        LoseTextObject = GameObject.FindGameObjectsWithTag("TxtYouAreMissingXCoins");
        if (ScreenLose.activeSelf && !isMenu && gametype!=4)
        {
            timeinputfield.text = 0 + "";
            for (int i = 0; i < LoseTextObject.Length; i++)
            {
                Destroy(LoseTextObject[i]);
            }
        }
     

       







        if (!IsColorChange && clickobjectinfo != null)
        {
            inputFieldsdnk[16].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.r;
            inputFieldsdnk[17].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.g;
            inputFieldsdnk[18].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.b;
            inputFieldsdnk[19].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.a;
            IsColorChange = true;

        }
        if (clickobjectinfo != null && isinfoon)
        {
            float red = inputFieldsdnk[16].GetComponent<Slider>().value;
            float green = inputFieldsdnk[17].GetComponent<Slider>().value;
            float blue = inputFieldsdnk[18].GetComponent<Slider>().value;
            float alpha = inputFieldsdnk[19].GetComponent<Slider>().value;
            clickobjectinfo.GetComponent<DnkPlant>().color.r = red;
            clickobjectinfo.GetComponent<DnkPlant>().color.g = green;
            clickobjectinfo.GetComponent<DnkPlant>().color.b = blue;
            clickobjectinfo.GetComponent<DnkPlant>().color.a = alpha;
            clickobjectinfo.GetComponent<SpriteRenderer>().color = clickobjectinfo.GetComponent<DnkPlant>().color;
        }

        if (gametype != 4)
        {
            if( 4 > 5 && int.Parse(analuticsplus[mytype].AnaluticsPlus_InputField.text) <= 0 && !StartEvolution.activeSelf && !IsActiveScreenLose && (!IsNeedNoSpawn || isMultiPlayer))
        {
                IsActiveScreenLose = true;
                timeinputfield.text = "0";

                ScreenLose.SetActive(true);
                int r = 0;
                for (int i = 0; i < analuticsplus.Length; i++)
                {
                    if (int.Parse(analuticsplus[i].AnaluticsPlus_InputField.text) > 0)
                    {
                        if (mytype != i)
                        {
                            r += 1;
                        }
                     
                    }
                }

                float delta = ((float)totalcount - (float)r) / ((float)totalcount + 1) * 10;
                float halspast = (totalcount + 1) / 1.4f;
                delta -= halspast;
                delta *= gametype;
                PlayerPrefs.SetFloat("GlobalDnk", (PlayerPrefs.GetFloat("GlobalDnk") + delta));
                ScreenLoseTextMoney.text = "Your reward - " + Mathf.Round(delta) + " dnk";

                ScreenLoseText.text = "You took the " + (r + 1) + " place" + " out of " + (totalcount + 1);

            }
            if (4 > 5 && int.Parse(analuticsplus[mytype].AnaluticsPlus_InputField.text) <= 0 && !StartEvolution.activeSelf && !IsActiveScreenLose && IsNeedNoSpawn && !isMultiPlayer)
            {
                IsActiveScreenLose = true;
                ScreenLose.SetActive(true);
                timeinputfield.text = "0";

                ScreenLoseText.text = "You lose the duel" ;

            }

        }
            
        
        postproccesinggb = FindObjectsOfType<PostProcessVolume>();
        if (PostProcessingTogle.isOn)
        {
            for (int i = 0; i < postproccesinggb.Length; i++)
            {
                postproccesinggb[i].enabled = true;
               
                
            }

        }else
        {
            for (int i = 0; i < postproccesinggb.Length; i++)
            {
                postproccesinggb[i].enabled = false;
            }
        }
        if (gametype != 4)
        {
            DnkInputField.text = dnk + "";
        }
       
       
        
      
        
        timedel += Time.deltaTime;



        if (timedel >= 60 && isMenu)
        {
            int val0 = plant1.Length;
            isready = false;
            for (int i = 0; i < val0; i++)
            {
                Destroy(plant1[i]);

                //Debug.Log("HELP!!!");
                if (i == (val0-1))
                {
                    timedel = 0;
                  //  SpawnObMenu();
                    timedel = 0;
                }

            }

        }
        if (isready && isMenu && plant1.Length >= 240 && timedel >= 1)
        {
            int val0 = plant1.Length;
            isready = false;
            for (int i = 0; i < val0; i++)
            {
                Destroy(plant1[i]);

                //Debug.Log("HELP!!!");
                if (i == (val0-1))
                {
                    timedel = 0;
                //    SpawnObMenu();
                    timedel = 0;
                }
                
            }
            isready = true;
        }

        



        if (clickobjectinfo == null)
        {
            paneldnk.SetActive(false);
            isinfoon = false;
            edittogle.isOn = false;
            clickobjectinfo = null;
        }
        if (AutoTime == true)
        {
             DeltaTIME += (Time.deltaTime - DeltaTIME) * 0.1f;
             float fps = 1.0f / DeltaTIME / 10 ;
              timeinputfield.text = fps / (DeltaTIME * 1000) + "";
          //  DeltaTIME += (Time.deltaTime - DeltaTIME) * 0.1f;
          //  float fps = 1.0f / DeltaTIME / 10;
         //   if (float.Parse(timeinputfield.text) > fps)
          //      {
         //       timeinputfield.text = (float.Parse(timeinputfield.text) - 0.1f) + "";
         ///   }
         //   if (float.Parse(timeinputfield.text) < fps)
       //     {
        //        timeinputfield.text = (float.Parse(timeinputfield.text) + 0.1f) + "";
        //    }



            // var value1 = plant1.Length;


            // if (value1 < 40) { timeinputfield.text = "10"; }
            // if (value1 < 110 && value1 > 40) { timeinputfield.text = "7"; }
            //  if (value1 < 200 && value1 > 110) { timeinputfield.text = "3"; }
            // if (value1 < 250 && value1 > 200) { timeinputfield.text = "1"; }
            // if (value1 < 300 && value1 > 250) { timeinputfield.text = "1"; }
            // if (value1 < 360 && value1 > 300) { timeinputfield.text = "0,95"; }
            // if (value1 < 510 && value1 > 360) { timeinputfield.text = "0,8"; }
            //if (value1 < 600 && value1 > 510) { timeinputfield.text = "0,6"; }
            // if (value1 < 750 && value1 > 600) { timeinputfield.text = "0,5"; }
            // if (value1 < 970 && value1 > 750) { timeinputfield.text = "0,3"; }
            // if (value1 < 1100 && value1 > 970) { timeinputfield.text = "0,2"; }
            // if (value1 < 1900 && value1 > 1100) { timeinputfield.text = "0,1"; }
            // if (value1 < 2600 && value1 > 1900) { timeinputfield.text = "0,0450"; }
            // if (value1 < 3500 && value1 > 2600) { timeinputfield.text = "0,001"; }
            // if (value1 < 7000 && value1 > 3500) { timeinputfield.text = "0,0002"; }
            // if (value1 < 16000 && value1 > 7000) { timeinputfield.text = "0,0001"; }
            // if (value1 < 45000 && value1 > 16000) { timeinputfield.text = "0,0007"; }







        }

        textcoord.text = new Vector2(camera1.transform.position.x, camera1.transform.position.y) + "";
       
        plant1 = GameObject.FindGameObjectsWithTag("Plant1");
      
        


        
        if (time > 10) { timeinputfield.text = "10"; }
        time = float.Parse(timeinputfield.text);



      Time.timeScale = time;


        if (isinfoon && gametype == 4 )
        {
            
            if (Input.GetMouseButton(0) && !FindObjectOfType<DnkOnformationPlant>().ismouse && !FindObjectOfType<DnkOnformationPlant1>().ismouse)
            {

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                clickobjectinfo.transform.position = mousePos2D;

                


            }
            if (Input.GetMouseButtonDown(1) && FindObjectOfType<DnkOnformationPlant>().ismouse == false)
            {
                
                Destroy(clickobjectinfo);


            }
            if (!edittogle.isOn)
            {
                if (inputsfieldtrue == true)
                {
                    inputFieldsdnk[0].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[1].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[2].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[3].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[4].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[5].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[6].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[7].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[8].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[9].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[10].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[11].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[12].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[13].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[14].GetComponent<TMP_InputField>().enabled = false;
                    inputFieldsdnk[15].GetComponent<Dropdown>().enabled = false;
                    //Debug.Log("##########################");
                    inputsfieldtrue = false;
                }

                
                inputFieldsdnk[0].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().type + "";
                inputFieldsdnk[1].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().scale + "";
                inputFieldsdnk[2].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().mass + "";
                inputFieldsdnk[3].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().mintime_adult + "";
                inputFieldsdnk[4].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().time_adult + "";
                inputFieldsdnk[5].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().livetime + "";
                inputFieldsdnk[6].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond + "";
                inputFieldsdnk[7].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().maxhp + "";
                inputFieldsdnk[8].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().maxfood + "";
                inputFieldsdnk[9].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().timetohavefood + "";
                inputFieldsdnk[10].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn + "";
                inputFieldsdnk[11].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 + "";
                inputFieldsdnk[12].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().tochildfood + "";
                inputFieldsdnk[13].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount + "";
                inputFieldsdnk[14].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().typespawn + "";
                inputFieldsdnk[15].GetComponent<Dropdown>().value = clickobjectinfo.GetComponent<DnkPlant>().shape;
                inputFieldsdnk[16].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.r;
                inputFieldsdnk[17].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.g;
                inputFieldsdnk[18].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.b;
                inputFieldsdnk[19].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.a;



            }
            if (edittogle.isOn)
            {
                if (inputsfieldtrue == false)
                {
                    inputFieldsdnk[0].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[1].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[2].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[3].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[4].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[5].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[6].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[7].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[8].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[9].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[10].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[11].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[12].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[13].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[14].GetComponent<TMP_InputField>().enabled = true;
                    inputFieldsdnk[15].GetComponent<Dropdown>().enabled = true;
                    inputsfieldtrue = true;
                }

                if (!FindObjectOfType<DnkOnformationPlant>().ismouse)
                {
                    clickobjectinfo.GetComponent<DnkPlant>().type = int.Parse(inputFieldsdnk[0].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().scale = float.Parse(inputFieldsdnk[1].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().mass = float.Parse(inputFieldsdnk[2].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().mintime_adult = float.Parse(inputFieldsdnk[3].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().time_adult = float.Parse(inputFieldsdnk[4].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().livetime = float.Parse(inputFieldsdnk[5].GetComponent<TMP_InputField>().text);



                    clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = float.Parse(inputFieldsdnk[6].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().maxhp = float.Parse(inputFieldsdnk[7].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().maxfood = float.Parse(inputFieldsdnk[8].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = float.Parse(inputFieldsdnk[9].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn = float.Parse(inputFieldsdnk[10].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 = int.Parse(inputFieldsdnk[11].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().tochildfood = float.Parse(inputFieldsdnk[12].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount = float.Parse(inputFieldsdnk[13].GetComponent<TMP_InputField>().text);


                    clickobjectinfo.GetComponent<DnkPlant>().shape = inputFieldsdnk[15].GetComponent<Dropdown>().value;

                    clickobjectinfo.GetComponent<DnkPlant>().typespawn = int.Parse(inputFieldsdnk[14].GetComponent<TMP_InputField>().text);
                    if (clickobjectinfo.GetComponent<DnkPlant>().typespawn < 0 || clickobjectinfo.GetComponent<DnkPlant>().typespawn > 2)
                    {
                        clickobjectinfo.GetComponent<DnkPlant>().typespawn = 0;

                    }

                    clickobjectinfo.GetComponent<DnkPlant>().scaleV3 = new Vector3(clickobjectinfo.GetComponent<DnkPlant>().scale, clickobjectinfo.GetComponent<DnkPlant>().scale, 1);
                    clickobjectinfo.GetComponent<Transform>().localScale = clickobjectinfo.GetComponent<DnkPlant>().scaleV3;
                    clickobjectinfo.GetComponent<SpriteRenderer>().color = clickobjectinfo.GetComponent<DnkPlant>().color;
                    clickobjectinfo.GetComponent<Rigidbody2D>().mass = clickobjectinfo.GetComponent<DnkPlant>().mass;
                    clickobjectinfo.GetComponent<Rigidbody2D>().drag = clickobjectinfo.GetComponent<DnkPlant>().drag;

                    clickobjectinfo.GetComponent<SpriteRenderer>().sprite = clickobjectinfo.GetComponent<DnkPlant>().shapes[clickobjectinfo.GetComponent<DnkPlant>().shape];





                }
                



                

            }


        }

        if (isinfoon && gametype != 4)
        {
            if (Input.GetMouseButton(0) && !FindObjectOfType<DnkOnformationPlant>().ismouse && !FindObjectOfType<DnkOnformationPlant1>().ismouse && time != 0)
            {

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                //clickobjectinfo.transform.position = mousePos2D;
                clickobjectinfo.transform.position = Vector2.MoveTowards(clickobjectinfo.transform.position, mousePos2D, PlayerPrefs.GetInt("shopSpeed") / 22.2222222222f);









            }
            if ((clickobjectinfo.GetComponent<DnkPlant>().type == mytype) || (clickobjectinfo.GetComponent<DnkPlant>().strong <= 40 && PlayerPrefs.GetInt("shopControl") == 2) || (clickobjectinfo.GetComponent<DnkPlant>().strong <= 85 && PlayerPrefs.GetInt("shopControl") == 3) || (PlayerPrefs.GetInt("shopControl") == 4))
            {
                if (Input.GetMouseButtonDown(1) && FindObjectOfType<DnkOnformationPlant>().ismouse == false)
                {

                    Destroy(clickobjectinfo);


                }
                if (!edittogle.isOn)
                {
                    if (inputsfieldtrue == true)
                    {
                        inputFieldsdnk[0].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[1].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[2].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[3].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[4].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[5].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[6].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[7].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[8].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[9].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[10].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[11].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[12].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[13].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[14].GetComponent<TMP_InputField>().enabled = false;
                        inputFieldsdnk[15].GetComponent<Dropdown>().enabled = false;
                        //Debug.Log("##########################");
                        inputsfieldtrue = false;
                    }


                    inputFieldsdnk[0].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().type + "";
                    inputFieldsdnk[1].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().scale + "";
                    inputFieldsdnk[2].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().mass + "";
                    inputFieldsdnk[3].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().mintime_adult + "";
                    inputFieldsdnk[4].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().time_adult + "";
                    inputFieldsdnk[5].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().livetime + "";
                    inputFieldsdnk[6].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond + "";
                    inputFieldsdnk[7].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().maxhp + "";
                    inputFieldsdnk[8].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().maxfood + "";
                    inputFieldsdnk[9].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().timetohavefood + "";
                    inputFieldsdnk[10].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn + "";
                    inputFieldsdnk[11].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 + "";
                    inputFieldsdnk[12].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().tochildfood + "";
                    inputFieldsdnk[13].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount + "";
                    inputFieldsdnk[14].GetComponent<TMP_InputField>().text = clickobjectinfo.GetComponent<DnkPlant>().typespawn + "";
                    inputFieldsdnk[15].GetComponent<Dropdown>().value = clickobjectinfo.GetComponent<DnkPlant>().shape;
                    inputFieldsdnk[16].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.r;
                    inputFieldsdnk[17].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.g;
                    inputFieldsdnk[18].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.b;
                    inputFieldsdnk[19].GetComponent<Slider>().value = clickobjectinfo.GetComponent<DnkPlant>().color.a;



                }
                if (edittogle.isOn)
                {
                    if (inputsfieldtrue == false)
                    {
                        inputFieldsdnk[0].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[1].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[2].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[3].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[4].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[5].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[6].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[7].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[8].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[9].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[10].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[11].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[12].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[13].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[14].GetComponent<TMP_InputField>().enabled = true;
                        inputFieldsdnk[15].GetComponent<Dropdown>().enabled = true;
                        inputsfieldtrue = true;
                    }

                    if (!FindObjectOfType<DnkOnformationPlant>().ismouse)
                    {
                        clickobjectinfo.GetComponent<DnkPlant>().type = int.Parse(inputFieldsdnk[0].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().scale = float.Parse(inputFieldsdnk[1].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().mass = float.Parse(inputFieldsdnk[2].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().mintime_adult = float.Parse(inputFieldsdnk[3].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().time_adult = float.Parse(inputFieldsdnk[4].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().livetime = float.Parse(inputFieldsdnk[5].GetComponent<TMP_InputField>().text);



                        clickobjectinfo.GetComponent<DnkPlant>().needfoodsecond = float.Parse(inputFieldsdnk[6].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().maxhp = float.Parse(inputFieldsdnk[7].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().maxfood = float.Parse(inputFieldsdnk[8].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().timetohavefood = float.Parse(inputFieldsdnk[9].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().maxdistancespawn = float.Parse(inputFieldsdnk[10].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().chancetochild1 = int.Parse(inputFieldsdnk[11].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().tochildfood = float.Parse(inputFieldsdnk[12].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().dietoorganiccount = float.Parse(inputFieldsdnk[13].GetComponent<TMP_InputField>().text);


                        clickobjectinfo.GetComponent<DnkPlant>().shape = inputFieldsdnk[15].GetComponent<Dropdown>().value;

                        clickobjectinfo.GetComponent<DnkPlant>().typespawn = int.Parse(inputFieldsdnk[14].GetComponent<TMP_InputField>().text);
                        if (clickobjectinfo.GetComponent<DnkPlant>().typespawn < 0 || clickobjectinfo.GetComponent<DnkPlant>().typespawn > 2)
                        {
                            clickobjectinfo.GetComponent<DnkPlant>().typespawn = 0;

                        }

                        clickobjectinfo.GetComponent<DnkPlant>().scaleV3 = new Vector3(clickobjectinfo.GetComponent<DnkPlant>().scale, clickobjectinfo.GetComponent<DnkPlant>().scale, 1);
                        clickobjectinfo.GetComponent<Transform>().localScale = clickobjectinfo.GetComponent<DnkPlant>().scaleV3;
                        clickobjectinfo.GetComponent<SpriteRenderer>().color = clickobjectinfo.GetComponent<DnkPlant>().color;
                        clickobjectinfo.GetComponent<Rigidbody2D>().mass = clickobjectinfo.GetComponent<DnkPlant>().mass;
                        clickobjectinfo.GetComponent<Rigidbody2D>().drag = clickobjectinfo.GetComponent<DnkPlant>().drag;

                        clickobjectinfo.GetComponent<SpriteRenderer>().sprite = clickobjectinfo.GetComponent<DnkPlant>().shapes[clickobjectinfo.GetComponent<DnkPlant>().shape];


                    }






                }
            }
            


        }

        var value0 = plant1.Length;



        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pressed left click, casting ray.");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider)
            {

                if (gametype != 4)
                {
                    if (hit.collider.gameObject.tag == "Plant1" && (hit.collider.gameObject.GetComponent<DnkPlant>().type == mytype || (hit.collider.gameObject.GetComponent<DnkPlant>().strong <= 40 && PlayerPrefs.GetInt("shopControl") == 2) || ((hit.collider.gameObject.GetComponent<DnkPlant>().strong <= 85 && PlayerPrefs.GetInt("shopControl") == 3) || (PlayerPrefs.GetInt("shopControl") == 4))))
                    {
                        // Debug.Log(hit.collider.gameObject.name);
                        paneldnk.SetActive(true);
                        inputFieldsdnk[0].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().type + "";
                        inputFieldsdnk[1].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().scale + "";
                        inputFieldsdnk[2].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().mass + "";
                        inputFieldsdnk[3].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().mintime_adult + "";
                        inputFieldsdnk[4].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().time_adult + "";
                        inputFieldsdnk[5].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().livetime + "";
                        inputFieldsdnk[6].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().needfoodsecond + "";
                        inputFieldsdnk[7].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().maxhp + "";
                        inputFieldsdnk[8].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().maxfood + "";
                        inputFieldsdnk[9].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().timetohavefood + "";
                        inputFieldsdnk[10].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().maxdistancespawn + "";
                        inputFieldsdnk[11].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().chancetochild1 + "";
                        inputFieldsdnk[12].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().tochildfood + "";
                        inputFieldsdnk[13].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().dietoorganiccount + "";
                        inputFieldsdnk[14].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().typespawn + "";
                        inputFieldsdnk[15].GetComponent<Dropdown>().value = hit.collider.gameObject.GetComponent<DnkPlant>().shape;


                        isinfoon = true;

                        clickobjectinfo = hit.collider.gameObject;
                        //FindObjectOfType<Camera>().transform.position = new Vector3(clickobjectinfo.transform.position.x, clickobjectinfo.transform.position.y, FindObjectOfType<Camera>().transform.position.z);


                    }
                    else if (hit.collider.gameObject == clickobjectinfo)
                    {

                        paneldnk.SetActive(false);
                        isinfoon = false;
                        edittogle.isOn = false;
                        clickobjectinfo = null;
                    }

                }
                else
                {
                    if (hit.collider.gameObject.tag == "Plant1" )
                    {
                        // Debug.Log(hit.collider.gameObject.name);
                        paneldnk.SetActive(true);
                        inputFieldsdnk[0].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().type + "";
                        inputFieldsdnk[1].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().scale + "";
                        inputFieldsdnk[2].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().mass + "";
                        inputFieldsdnk[3].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().mintime_adult + "";
                        inputFieldsdnk[4].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().time_adult + "";
                        inputFieldsdnk[5].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().livetime + "";
                        inputFieldsdnk[6].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().needfoodsecond + "";
                        inputFieldsdnk[7].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().maxhp + "";
                        inputFieldsdnk[8].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().maxfood + "";
                        inputFieldsdnk[9].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().timetohavefood + "";
                        inputFieldsdnk[10].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().maxdistancespawn + "";
                        inputFieldsdnk[11].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().chancetochild1 + "";
                        inputFieldsdnk[12].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().tochildfood + "";
                        inputFieldsdnk[13].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().dietoorganiccount + "";
                        inputFieldsdnk[14].GetComponent<TMP_InputField>().text = hit.collider.gameObject.GetComponent<DnkPlant>().typespawn + "";
                        inputFieldsdnk[15].GetComponent<Dropdown>().value = hit.collider.gameObject.GetComponent<DnkPlant>().shape;


                        isinfoon = true;

                        clickobjectinfo = hit.collider.gameObject;
                        //FindObjectOfType<Camera>().transform.position = new Vector3(clickobjectinfo.transform.position.x, clickobjectinfo.transform.position.y, FindObjectOfType<Camera>().transform.position.z);


                    }
                    else if (hit.collider.gameObject == clickobjectinfo)
                    {

                    //    paneldnk.SetActive(false);
                    //    isinfoon = false;
                    //    edittogle.isOn = false;
                    //    clickobjectinfo = null;
                    }
                }
               



            }

            else if (FindObjectOfType<DnkOnformationPlant>())
            {
                if (!FindObjectOfType<DnkOnformationPlant>().ismouse && isinfoon)
                {

                //    paneldnk.SetActive(false);
                //    isinfoon = false;
                //    edittogle.isOn = false;
                //    clickobjectinfo = null;
                }

            }



        }

    }

    public void AutoTimeFunction()
    {
        if (AutoTime == false)
        {
            
            
            AutoTime = true;
        }
        else
        {
            AutoTime = false;
        }
       
    }

   
   
    public void Restart()
    {
        if (isneedmultiplayeroperation)
        {
            PhotonNetwork.LeaveRoom();
            
            SceneManager.LoadScene("Menu");

        }
        
        if (!isMenu && gametype == 4)
        {
            if (FindObjectOfType<NumberEvolution>() == null)
            {
                GameObject gb1 = new GameObject("DontDestroyEvolution");
                gb1.AddComponent<NumberEvolution>();
                DontDestroyOnLoad(gb1);
                gb = gb1;

                
            }
            else
            {
                gb = GameObject.FindObjectOfType<NumberEvolution>().gameObject;
                
            }
            bool isEvolution = false;
            for (int i = 0; i < plant1.Length; i++)
            {
                if (plant1[i].GetComponent<DnkPlant>().type == mytype)
                {
                    if (!isEvolution)
                    {
                        gb.transform.position = plant1[i].transform.position;
                        isEvolution = true;
                    }
                    int chancetodelete = Random.Range(1, 4);
                    if (chancetodelete >= 3)
                    {
                        plant1[i].transform.parent = gb.transform;
                    }
                    else
                    {
                        Destroy(plant1[i]);
                    }
                }
            }
            
            inputFieldsdnk[15].GetComponent<Dropdown>().value = 0;
            SceneManager.LoadScene("SandBox");
            ScreenLose.SetActive(false);

        }
        if (gametype == 1 && !isMenu)
        {
            if (FindObjectOfType<NumberEvolution>() == null)
            {
                GameObject gb1 = new GameObject("DontDestroyEvolution");
                gb1.AddComponent<NumberEvolution>();
                DontDestroyOnLoad(gb1);
                gb = gb1;
            }
            else
            {
                gb = GameObject.FindObjectOfType<NumberEvolution>().gameObject;
            }
            for (int i = 0; i < plant1.Length; i++)
            {
                if (plant1[i].GetComponent<DnkPlant>().type == mytype)
                {
                    int chancetodelete = Random.Range(1, 3);
                    if (chancetodelete >= 2)
                    {
                        plant1[i].transform.parent = gb.transform;
                    }
                    else
                    {
                        Destroy(plant1[i]);
                    }
                }
            }
         
            ScreenLose.SetActive(false);

            SceneManager.LoadScene("Peaceful Life");
            ScreenLose.SetActive(false);
        }
        if (gametype == 2 && !isMenu)
        {
            if (FindObjectOfType<NumberEvolution>() == null)
            {
                GameObject gb1 = new GameObject("DontDestroyEvolution");
                gb1.AddComponent<NumberEvolution>();
                DontDestroyOnLoad(gb1);
                gb = gb1;
            }
            else
            {
                gb = GameObject.FindObjectOfType<NumberEvolution>().gameObject;
            }
            for (int i = 0; i < plant1.Length; i++)
            {
                if (plant1[i].GetComponent<DnkPlant>().type == mytype)
                {
                    int chancetodelete = Random.Range(1, 3);
                    if (chancetodelete >= 2)
                    {
                        plant1[i].transform.parent = gb.transform;
                    }
                    else
                    {
                        Destroy(plant1[i]);
                    }
                }
            }
         
            ScreenLose.SetActive(false);

            SceneManager.LoadScene("The struggle for power");
            ScreenLose.SetActive(false);
        }
        if (gametype == 3 && !isMenu)
        {
            if (FindObjectOfType<NumberEvolution>() == null)
            {
                GameObject gb1 = new GameObject("DontDestroyEvolution");
                gb1.AddComponent<NumberEvolution>();
                DontDestroyOnLoad(gb1);
                gb = gb1;
            }
            else
            {
                gb = GameObject.FindObjectOfType<NumberEvolution>().gameObject;
            }
            for (int i = 0; i < plant1.Length; i++)
            {
                if (plant1[i].GetComponent<DnkPlant>().type == mytype)
                {
                    int chancetodelete = Random.Range(1, 3);
                    if (chancetodelete >= 2)
                    {
                        plant1[i].transform.parent = gb.transform;
                    }
                    else
                    {
                        Destroy(plant1[i]);
                    }
                }
            }
         
            ScreenLose.SetActive(false);

            SceneManager.LoadScene("JustHell");
            ScreenLose.SetActive(false);
        }


    }
    public void CanvasOnOff()
    {
       if (!isfirstcanvason)
       {
            canvas[1].SetActive(false);
            canvas[0].SetActive(true);
            isfirstcanvason = true;
       }
       else
       {
            canvas[1].SetActive(true);
            canvas[0].SetActive(false);
            isfirstcanvason = false;
       }
    }
    public void AnalyticOnOff()
    {
        if (!isfirstcanvasonanalatycs)
        {
            Analytics[1].SetActive(false);
            Analytics[0].SetActive(true);
            isfirstcanvasonanalatycs = true;
        }
        else
        {
            Analytics[1].SetActive(true);
            Analytics[0].SetActive(false);
            isfirstcanvasonanalatycs = false;
        }
    }

    [System.Serializable]
    public class AnaluticsPlus
    {
        public TMP_InputField AnaluticsPlus_InputField;
        public Toggle AnaluticsPlus_Toogle;

        

    }




}


