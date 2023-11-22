using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using System.Threading;


public class DnkPlant : MonoBehaviour
{
    public bool isalotobject;
    public float strong;
    public GameObject camera1;
    public Button buttonnoclick;
    public int type;
    [SerializeField] bool firstentity;
    public float scale;
    public Vector3 scaleV3;
    public Color color;
    public float mass;
    public float drag;
    public float speed;
    public float mintime_adult;
    public float time_adult;
    public float livetime;
    public float liveminusone;
    public float needfoodsecond;
    public float maxhp;
    public float maxfood;
    public float timetohavefood;
    public float maxdistancespawn;
    public int chancetochild1;
    public float tochildfood;
    public float dietoorganiccount;
    public GameObject diedrop;
    public bool canoneandonetoone;
    public int typespawn;
    public int shape;
    public GameManager game_manager;
    public bool isthismycomponent;


    [SerializeField] Toggle mutation;
    bool IsColl;
    public GameObject border;
    public Sprite[] shapes;
    int chancetomove;
    int chancetotype;
    [SerializeField] Toggle movecentre;
    GameObject w;


    // Start is called before the first frame update
    void Start()
    {

       
        InvokeRepeating("moveAction", 0.1f, 6);
        border = FindObjectOfType<Border>().gameObject;
        liveminusone = livetime - 1;
        int chancemut = Random.Range(0, 5);
        int chancecut = Random.Range(0, 22);

        if (mutation.isOn)
        {
            if (firstentity)
            {
                chancemut = 0;
            }
            if (chancecut == 0)
            {

            }
            if (chancemut == 0)
            {
                int chancemutobj = Random.Range(0, 14);
                if (chancemutobj == 0)
                {
                    scale += Random.Range(-3, 3);
                }
                if (chancemutobj == 1)
                {
                    color = new Color(Random.value, Random.value, Random.value, 1);

                }
                if (chancemutobj == 2)
                {
                    mass += Random.Range(-3, 3);
                    if (mass < 0.1f)
                    {
                        mass = 0.1f;
                    }
                }
                if (chancemutobj == 3)
                {
                    drag += Random.Range(-3, 3);
                    if (drag < 0.1f)
                    {
                        drag = 0.1f;
                    }
                }
                if (chancemutobj == 4)
                {
                    drag += Random.Range(-3, 3);
                    if (drag < 0.1f)
                    {
                        drag = 0.1f;
                    }
                }
                
                if (chancemutobj == 6)
                {
                    mintime_adult += Random.Range(-3, 3);
                    if (mintime_adult < 2)
                    {
                        mintime_adult = 2;
                    }
                }
                if (chancemutobj == 7)
                {
                    livetime += Random.Range(-7, 7);
                }
                if (chancemutobj == 8)
                {
                    needfoodsecond += Random.Range(-3, 3);
                    if (needfoodsecond < 0.5f)
                    {
                        needfoodsecond = 0.5f;
                    }

                }
                if (chancemutobj == 9)
                {
                    maxhp += Random.Range(-3, 3);
                    if (maxhp < 0.1f)
                    {
                        maxhp = 0.1f;
                    }
                }
                if (chancemutobj == 10)
                {
                    maxfood += Random.Range(-10, 10);
                    if (maxfood < 0.1f)
                    {
                        maxfood = 0.1f;
                    }
                }
                if (chancemutobj == 11)
                {
                    timetohavefood += Random.Range(-0.4f, 0.4f);
                    if (timetohavefood < 0.1f)
                    {
                        timetohavefood = 0.1f;
                    }
                }
                if (chancemutobj == 12)
                {
                    maxdistancespawn += Random.Range(-3.5f, -3.5f);
                }
                if (chancemutobj == 13)
                {
                    chancetochild1 += Random.Range(-15, 15);
                    if (chancetochild1 < 5)
                    {
                        chancetochild1 = 5;

                    }
                }
                if (chancemutobj == 14)
                {
                    tochildfood += Random.Range(-4, 4);

                }
                if (chancemutobj == 14)
                {
                    tochildfood += Random.Range(-4, 4);

                }
                if (chancemutobj == 15)
                {
                    dietoorganiccount += Random.Range(-2.5f, 2.5f);

                }
                if (chancemutobj == 16)
                {
                    if (canoneandonetoone) { canoneandonetoone = false; }
                    if (!canoneandonetoone) { canoneandonetoone = true; }

                }
                if (chancemutobj == 17 || chancemutobj == 18 || chancemutobj == 19 || chancemutobj == 20)
                {
                    typespawn = Random.Range(0, 2);
                }
                if (chancemutobj == 21)
                {
                    type = Random.Range(0, 21);
                }
                if (chancemutobj == 22)
                {
                    shape = Random.Range(1, 3);
                }
            }

        }

        scaleV3 = new Vector3(scale, scale, 1);
        GetComponent<Transform>().localScale = scaleV3;
        GetComponent<SpriteRenderer>().color = color;
        GetComponent<Rigidbody2D>().mass = mass;
        GetComponent<Rigidbody2D>().drag = drag;
        if (chancemut == 22)
        {
            GetComponent<SpriteRenderer>().sprite = shapes[shape - 1];
        }

        var gm = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gm.Length; i++)
        {
            if (gm[i].mytype == type)
            {
                game_manager = gm[i];
                print("gameManager - " + int.Parse(game_manager.analuticsplus[type].AnaluticsPlus_InputField.text));
                print("Yeah");
                i = gm.Length;
            }
        }
        if (gm.Length > 1)
        {
            if (type == 0)
            {
                print("NoYes");
                Destroy(this.gameObject);
            }
        }
        int newvalue = int.Parse(game_manager.analuticsplus[type].AnaluticsPlus_InputField.text) + 1;
        game_manager.analuticsplus[type].AnaluticsPlus_InputField.text = newvalue + "";
        
    }

    void moveAction()
    {
        
        chancetomove = Random.Range(0, 4);

        chancetotype = Random.Range(1, 5);
        if (chancetomove == 0 && type != game_manager.mytype && game_manager.time != 0)
        {

        
            if (chancetotype == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, game_manager.plant1[Random.Range(0, game_manager.plant1.Length - 1)].transform.position, 0.045f);
            }
            if (chancetotype == 2)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(0 + Random.Range(-10, 10), 0 + Random.Range(-10, 10), 0 + Random.Range(-10, 10)), 0.045f);
            }
            if (chancetotype == 3)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, 0, 0), 0.045f);
            }
            if (chancetotype == 4)
            {
                if (game_manager.regenerationMassive.Length != 0 )
                {
                    w = game_manager.regenerationMassive[Random.Range(0, game_manager.regenerationMassive.Length)].gameObject;
                    transform.position = Vector2.MoveTowards(transform.position, new Vector3(w.transform.position.x, w.transform.position.y, w.transform.position.z), 0.045f);
                }

            }

        }
    }
    void FixedUpdate()
    {
        if (int.Parse(game_manager.analuticsplus[type].AnaluticsPlus_InputField.text) >= 200 / game_manager.totalcount)
        {
            isalotobject = true;
        }
        else { isalotobject = false; }

        strong = (scale * 2) * (GetComponent<PlantController>().hp / 10);
        if (chancetomove == 0 && type != game_manager.mytype && game_manager.time != 0)
        {
            if (chancetotype == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, game_manager.plant1[Random.Range(0, game_manager.plant1.Length - 1)].transform.position, 0.045f);
            }
            if (chancetotype == 2)
            {
                if (!game_manager.isMenu)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector3(0 + Random.Range(-2, 2), 0 + Random.Range(-2, 2), 0), 0.045f);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector3(-605 + Random.Range(-10, 10), -199.9f + Random.Range(-10, 10), 0 + Random.Range(-10, 10)), 0.045f);
                }

            }
            if (chancetotype == 3)
            {
                if (!game_manager.isMenu)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, 0, 0), 0.045f);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector3(-605, -199, 0), 0.045f);
                }
            }
            if (chancetotype == 4)
            {
                if (game_manager.regenerationMassive.Length != 0)
                {
                    w = game_manager.regenerationMassive[Random.Range(0, game_manager.regenerationMassive.Length)].gameObject;
                    transform.position = Vector2.MoveTowards(transform.position, new Vector3(w.transform.position.x, w.transform.position.y, w.transform.position.z), 0.045f);
                }
            }
        }


        if (!game_manager.isMenu && movecentre.isOn && type == game_manager.mytype && game_manager.time != 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            transform.position = Vector2.MoveTowards(transform.position, mousePos2D, PlayerPrefs.GetInt("shopSpeed") / 22.2222222222f);
        }


        if (IsColl == false && time_adult >= 0.3f && border.GetComponent<Border>().isActivate)
        {

            Destroy(this.gameObject);
        }
    

        







        time_adult += Time.deltaTime;
            if (time_adult >= livetime)
            {
            
            Instantiate(diedrop, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Destroy(this.gameObject);
            }

            if (scale < 0.8f)
            {
                scale = 0.8f;
                scaleV3 = new Vector3(scale, scale, 1);
            }
        }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (game_manager == null)
        {
            var gm = FindObjectsOfType<GameManager>();
            for (int i = 0; i < gm.Length; i++)
            {
                if (gm[i].mytype == type)
                {
                    game_manager = gm[i];
                    print("Yeah");
                }
            }
        }
        if (game_manager.gametype == 4)
        {
            if (other.tag == "Border" && other.gameObject.GetComponent<Border>().isActivate)
            {
                IsColl = true;
            }

            if (other.tag == "Plant1" && type != other.gameObject.GetComponent<DnkPlant>().type)
            {

                other.gameObject.GetComponent<PlantController>().hp -= strong / 2;

                if (strong > other.gameObject.GetComponent<DnkPlant>().strong)
                {
                    float chancetoact = Random.Range(0, 2);
                    print(strong + " " + other.gameObject.GetComponent<DnkPlant>().strong);
                    if (chancetoact == 0)
                    {
                        scale = (scale + (other.gameObject.GetComponent<DnkPlant>().scale / 5));
                        mass = (mass + other.gameObject.GetComponent<DnkPlant>().mass);
                        drag = (drag + other.gameObject.GetComponent<DnkPlant>().drag);
                        speed = (speed + other.gameObject.GetComponent<DnkPlant>().speed) / 2;
                        mintime_adult = (mintime_adult + other.gameObject.GetComponent<DnkPlant>().mintime_adult);
                        livetime = (livetime + other.gameObject.GetComponent<DnkPlant>().livetime);
                        needfoodsecond = (needfoodsecond + other.gameObject.GetComponent<DnkPlant>().needfoodsecond);
                        maxhp = (maxhp + other.gameObject.GetComponent<DnkPlant>().maxhp);
                        maxfood = (maxfood + other.gameObject.GetComponent<DnkPlant>().maxfood);
                        timetohavefood = (timetohavefood + other.gameObject.GetComponent<DnkPlant>().timetohavefood) / 2;
                        maxdistancespawn = (maxdistancespawn + other.gameObject.GetComponent<DnkPlant>().maxdistancespawn) * 2;
                        chancetochild1 = (chancetochild1 + other.gameObject.GetComponent<DnkPlant>().chancetochild1) / 2;
                        tochildfood = (tochildfood + other.gameObject.GetComponent<DnkPlant>().tochildfood);
                        dietoorganiccount = (dietoorganiccount + other.gameObject.GetComponent<DnkPlant>().dietoorganiccount);
                        GetComponent<PlantController>().food += other.gameObject.GetComponent<PlantController>().food;

                        liveminusone = livetime - 1;
                        scaleV3 = new Vector3(scale, scale, 1);
                        GetComponent<Transform>().localScale = scaleV3;
                        GetComponent<SpriteRenderer>().color = color;
                        GetComponent<Rigidbody2D>().mass = mass;
                        GetComponent<Rigidbody2D>().drag = drag;





                        Destroy(other.gameObject);

                    }
                    if (chancetoact >= 1)
                    {
                        game_manager.analuticsplus[other.gameObject.GetComponent<DnkPlant>().type].AnaluticsPlus_InputField.text = (int.Parse(game_manager.analuticsplus[other.gameObject.GetComponent<DnkPlant>().type].AnaluticsPlus_InputField.text) - 1) + "";
                        game_manager.analuticsplus[type].AnaluticsPlus_InputField.text = (int.Parse(game_manager.analuticsplus[type].AnaluticsPlus_InputField.text) + 1) + "";
                        other.gameObject.GetComponent<DnkPlant>().type = type;
                        print(other.gameObject.GetComponent<DnkPlant>().type + " and " + type);
                        other.gameObject.GetComponent<DnkPlant>().color = color;
                        other.gameObject.GetComponent<SpriteRenderer>().color = color;



                    }





                }
            }
        
           

            
           


          


        }

        
    }
    void OnTriggerStay2D(Collider2D other)
    {
       
        if (game_manager.gametype != 4)
        {
            if (other.tag == "Border" && other.gameObject.GetComponent<Border>().isActivate)
            {
                IsColl = true;
            }

            if (other.tag == "Plant1" && type != other.gameObject.GetComponent<DnkPlant>().type)
            {

                

                if (strong > other.gameObject.GetComponent<DnkPlant>().strong)
                {
                    float chancetoact = Random.Range(0, 2);
                    print(strong + " " + other.gameObject.GetComponent<DnkPlant>().strong);
                    if (chancetoact == 0)
                    {
                        scale = (scale + (other.gameObject.GetComponent<DnkPlant>().scale / 5));
                        mass = (mass + other.gameObject.GetComponent<DnkPlant>().mass);
                        drag = (drag + other.gameObject.GetComponent<DnkPlant>().drag);
                        speed = (speed + other.gameObject.GetComponent<DnkPlant>().speed) / 2;
                        mintime_adult = (mintime_adult + other.gameObject.GetComponent<DnkPlant>().mintime_adult);
                        livetime = (livetime + other.gameObject.GetComponent<DnkPlant>().livetime);
                        needfoodsecond = (needfoodsecond + other.gameObject.GetComponent<DnkPlant>().needfoodsecond);
                        maxhp = (maxhp + other.gameObject.GetComponent<DnkPlant>().maxhp);
                        maxfood = (maxfood + other.gameObject.GetComponent<DnkPlant>().maxfood);
                        timetohavefood = (timetohavefood + other.gameObject.GetComponent<DnkPlant>().timetohavefood) / 2;
                        maxdistancespawn = (maxdistancespawn + other.gameObject.GetComponent<DnkPlant>().maxdistancespawn) * 2;
                        chancetochild1 = (chancetochild1 + other.gameObject.GetComponent<DnkPlant>().chancetochild1) / 2;
                        tochildfood = (tochildfood + other.gameObject.GetComponent<DnkPlant>().tochildfood);
                        dietoorganiccount = (dietoorganiccount + other.gameObject.GetComponent<DnkPlant>().dietoorganiccount);
                        GetComponent<PlantController>().food += other.gameObject.GetComponent<PlantController>().food;

                        liveminusone = livetime - 1;
                        scaleV3 = new Vector3(scale, scale, 1);
                        GetComponent<Transform>().localScale = scaleV3;
                        GetComponent<SpriteRenderer>().color = color;
                        GetComponent<Rigidbody2D>().mass = mass;
                        GetComponent<Rigidbody2D>().drag = drag;





                        Destroy(other.gameObject);

                    }
                    if (chancetoact >= 1)
                    {
                        game_manager.analuticsplus[other.gameObject.GetComponent<DnkPlant>().type].AnaluticsPlus_InputField.text = (int.Parse(game_manager.analuticsplus[other.gameObject.GetComponent<DnkPlant>().type].AnaluticsPlus_InputField.text) - 1) + "";
                        game_manager.analuticsplus[type].AnaluticsPlus_InputField.text = (int.Parse(game_manager.analuticsplus[type].AnaluticsPlus_InputField.text) + 1) + "";
                        other.gameObject.GetComponent<DnkPlant>().type = type;
                        print(other.gameObject.GetComponent<DnkPlant>().type + " and " + type);
                        other.gameObject.GetComponent<DnkPlant>().color = color;
                        other.gameObject.GetComponent<SpriteRenderer>().color = color;



                    }





                }
                else
                {
                    other.gameObject.GetComponent<PlantController>().hp -= strong / 2;
                }
            }
        }
    }
       private void OnTriggerExit2D(Collider2D collision)
       {
           if (collision.tag == "Border" && collision.gameObject.GetComponent<Border>().isActivate)
           {
            IsColl = false;
           }

        }



    public void OnDestroy()
    {
       

        
        game_manager.analuticsplus[type].AnaluticsPlus_InputField.text = (int.Parse(game_manager.analuticsplus[type].AnaluticsPlus_InputField.text) - 1) + "";

        if (game_manager.clickobjectinfo == this.gameObject)
        {
            game_manager.ExitDnkInfo();
        }

        
        
    }





}



   




    
