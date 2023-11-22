using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditorInternal;


public class PlantController : MonoBehaviour
{
    public float food = 0;
    public float hp;

    [SerializeField] bool lightfood;
    DnkPlant dnk;
    float time_tofood;
    public float time_tohungry;
    public GameObject entity;
    bool child1;
    bool child2;
    public GameObject child1g;
    public GameObject child2g;
    public LineRenderer line;
    public Toggle physictogle;
    public Toggle linetoogle;
    public Toggle physicjump;
    bool colwithplant;
    // Start is called before the first frame update


    public void Awake()
    {
        dnk = GetComponent<DnkPlant>();
    }
    void Start()
    {
        lightfood = true;
        dnk = GetComponent<DnkPlant>();
        food = dnk.maxfood;
        line = GetComponent<LineRenderer>();
        dnk = GetComponent<DnkPlant>();
        hp = dnk.maxhp;
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
     //   Vector3 vec0 = new Vector3(entity.transform.position.x, entity.transform.position.y, -0.1f);
     //   Vector3 vec1 = new Vector3(entity.transform.position.x, entity.transform.position.y, -0.1f);
     //   Vector3 vec2 = new Vector3(entity.transform.position.x, entity.transform.position.y, -0.1f);
    //    Vector3 vec3 = new Vector3(entity.transform.position.x, entity.transform.position.y, -0.1f);
    //    line.SetPosition(0, vec0);
    //    line.SetPosition(1, vec1);
     //   line.SetPosition(2, vec2);
     //   line.SetPosition(3, vec3);
        InvokeRepeating("UpdatePerSecond", 0f, 0.5f);
    }

    void Update()
    {
    
        time_tofood += Time.deltaTime;
        time_tohungry += Time.deltaTime;
    }
    void UpdatePerSecond()
    {
        int chancetospeed = Random.Range(0, 100);
        
        if (physictogle.isOn && chancetospeed == 0 && physicjump.isOn)
        {
            transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z + Random.Range(0, 180), this.transform.rotation.z + Random.Range(0, 180));
            GetComponent<Rigidbody2D>().AddForce(transform.up * dnk.speed, ForceMode2D.Impulse); ;
        }

        if (physictogle.isOn) { GetComponent<Rigidbody2D>().isKinematic = false; }
        if (!physictogle.isOn) { GetComponent<Rigidbody2D>().isKinematic = true; }

        if (!linetoogle.isOn) { GetComponent<LineRenderer>().enabled = false; }
        if (linetoogle.isOn) { GetComponent<LineRenderer>().enabled = true; }



        else { GetComponent<Rigidbody2D>().isKinematic = true; }

        if (hp < 0)
        {
            Destroy(this.gameObject);
        }
        bool isfeedchild1g = false;
        bool isfeedchild2g = false;
        if (child1g != null && isfeedchild1g)
        {
            child1g.GetComponent<PlantController>().food = 0;
            child1g.GetComponent<PlantController>().food += food / dnk.tochildfood;
            food -= food / dnk.tochildfood;
            isfeedchild1g = false;
        }
        if (child2g != null && isfeedchild2g)
        {
            child2g.GetComponent<PlantController>().food = 0;
            child1g.GetComponent<PlantController>().food += food / dnk.tochildfood;
            food -= food / dnk.tochildfood;
            isfeedchild2g = false;
        }



        if (dnk.time_adult >= dnk.mintime_adult && !GetComponent<DnkPlant>().isalotobject)
        {
            int chancetochild = Random.Range(0, dnk.chancetochild1);

            if (chancetochild == 0)
            {
                if (child1 == false && child2 == false) //&& food >= dnk.maxfood * 0.8f)
                {
                    
                    if (GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                    {

                        FindObjectOfType<GameManager>().dnk += 1;
                        if (GetComponent<DnkPlant>().game_manager.gametype == 1)
                        {
                            GetComponent<DnkPlant>().game_manager.dnk += 6;
                        }
                    }
                    if (FindObjectOfType<Analitic>() != null) { FindObjectOfType<Analitic>().arraythisminadd(); }
                   
                    if (dnk.typespawn == 0) { SpawnObj(child1g, new Vector3(this.transform.position.x + Random.Range(-dnk.maxdistancespawn, dnk.maxdistancespawn), this.transform.position.y + Random.Range(-dnk.maxdistancespawn, dnk.maxdistancespawn), this.transform.position.z), Quaternion.identity); }
                    if (dnk.typespawn == 1) { SpawnObj(child1g, new Vector3(this.transform.position.x + Random.Range(dnk.maxdistancespawn - (dnk.maxdistancespawn / 5), dnk.maxdistancespawn), this.transform.position.y, this.transform.position.z), Quaternion.identity); }
                    if (dnk.typespawn == 2) { SpawnObj(child1g, new Vector3(this.transform.position.x, this.transform.position.y + Random.Range(dnk.maxdistancespawn - (dnk.maxdistancespawn / 5), dnk.maxdistancespawn), this.transform.position.z), Quaternion.identity); }
                    
                    child1g.GetComponent<PlantController>().food += GetComponent<DnkPlant>().tochildfood;
                    food -= GetComponent<DnkPlant>().tochildfood;
                    child1g.GetComponent<DnkPlant>().time_adult = 0;
                    Vector3 vec1 = new Vector3(child1g.transform.position.x, child1g.transform.position.y, -0.1f);
                    line.SetPosition(1, vec1);
                    child1 = true;
                    //child1g = entity;
                    if (GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                    {
                        FindObjectOfType<GameManager>().dnk += 1;
                    }
                  
                }
                if (child1 == false && child2 == true) //&& food >= dnk.maxfood * 0.8f)
                {

                    if (FindObjectOfType<Analitic>() != null) { FindObjectOfType<Analitic>().arraythisminadd(); }


                    if (GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                    {
                        
                        FindObjectOfType<GameManager>().dnk += 1;
                        if (GetComponent<DnkPlant>().game_manager.gametype == 1)
                        {
                            GetComponent<DnkPlant>().game_manager.dnk += 6;
                        }
                    }
                    if (dnk.typespawn == 0) { SpawnObj(child1g, new Vector3(this.transform.position.x + Random.Range(-dnk.maxdistancespawn, dnk.maxdistancespawn), this.transform.position.y + Random.Range(-dnk.maxdistancespawn, dnk.maxdistancespawn), this.transform.position.z), Quaternion.identity); }
                    if (dnk.typespawn == 1) { SpawnObj(child1g, new Vector3(this.transform.position.x + Random.Range(dnk.maxdistancespawn - (dnk.maxdistancespawn / 5), dnk.maxdistancespawn), this.transform.position.y, this.transform.position.z), Quaternion.identity); }
                    if (dnk.typespawn == 2) { SpawnObj(child1g, new Vector3(this.transform.position.x, this.transform.position.y + Random.Range(dnk.maxdistancespawn - (dnk.maxdistancespawn / 5), dnk.maxdistancespawn), this.transform.position.z), Quaternion.identity); }
                    child1g.GetComponent<PlantController>().food += GetComponent<DnkPlant>().tochildfood;
                    food -= GetComponent<DnkPlant>().tochildfood;
                    child1g.GetComponent<DnkPlant>().time_adult = 0;
                    Vector3 vec1 = new Vector3(child1g.transform.position.x, child1g.transform.position.y, -0.1f);
                    line.SetPosition(1, vec1);
                    child1 = true;
                    //child1g = entity;
                }
                if (child1 == true && child2 == false) //&& food >= dnk.maxfood * 0.8f)
                {

                    if (GetComponent<DnkPlant>().type == FindObjectOfType<GameManager>().mytype)
                    {
                        FindObjectOfType<GameManager>().dnk += 1;
                        if (GetComponent<DnkPlant>().game_manager.gametype == 1)
                        {
                            GetComponent<DnkPlant>().game_manager.dnk += 6;
                        }
                    }
                    if (FindObjectOfType<Analitic>() != null) { FindObjectOfType<Analitic>().arraythisminadd(); }
                    if (dnk.typespawn == 0) {  SpawnObj(child2g, new Vector3(this.transform.position.x + Random.Range(-dnk.maxdistancespawn, dnk.maxdistancespawn), this.transform.position.y + Random.Range(-dnk.maxdistancespawn, dnk.maxdistancespawn), this.transform.position.z), Quaternion.identity); }
                    if (dnk.typespawn == 1) {  SpawnObj(child2g, new Vector3(this.transform.position.x + Random.Range(dnk.maxdistancespawn - (dnk.maxdistancespawn / 5), dnk.maxdistancespawn), this.transform.position.y, this.transform.position.z), Quaternion.identity); }
                    if (dnk.typespawn == 2) { SpawnObj(child2g, new Vector3(this.transform.position.x, this.transform.position.y + Random.Range(dnk.maxdistancespawn - (dnk.maxdistancespawn / 5), dnk.maxdistancespawn), this.transform.position.z), Quaternion.identity); }
                    child1g.GetComponent<PlantController>().food += GetComponent<DnkPlant>().tochildfood;
                    food -= GetComponent<DnkPlant>().tochildfood;
                    child2g.GetComponent<DnkPlant>().time_adult = 0;
                    Vector3 vec2 = new Vector3(child2g.transform.position.x, child2g.transform.position.y, -0.1f);
                    Vector3 vec3 = new Vector3(this.transform.position.x, this.transform.position.y, -0.1f);
                    line.SetPosition(2, vec2);
                    line.SetPosition(3, vec3);
                    child2 = true;
                    //child2g = entity;
                }
            }



        }



        if (food < 0)
        {
            hp -= 10f;
        }
        else if (hp < dnk.maxhp && colwithplant != true)
        {
            hp += 2.5f;
            food -= 0.5f;
        }




        if (time_tohungry >= 1)
        {
            food -= dnk.needfoodsecond;
            time_tohungry = 0;

        }




        if (lightfood == true)
        {
            if (time_tofood >= dnk.timetohavefood && food < dnk.maxfood)
            {
                food += 1;
                time_tofood = 0;

            }
        }



        //       if (dnk.time_adult >= dnk.mintime_adult  && child1g != null && child2g != null)
        //       {
        //           Debug.Log("********************   line renderering 1 !!!");
        //           //Vector3 vec1 = new Vector3(this.transform.position.x, this.transform.position.y, -0.1f);
        //           Vector3 vec2 = new Vector3(child2g.transform.position.x, child2g.transform.position.y, -0.1f);//координаты точек
        //           //line.SetPosition(0, vec1);
        //           line.SetPosition(2, vec2);
        //       }
        //      if (dnk.time_adult >= dnk.mintime_adult && child1g != null && child2g == null)
        //      {
        //           Debug.Log("********************   line renderering 2 !!!");
        //           Vector3 vec1 = new Vector3(entity.transform.position.x, entity.transform.position.y, -0.1f);
        //           Vector3 vec2 = new Vector3(child1g.transform.position.x, child1g.transform.position.y, -0.1f);//координаты точек
        //           line.SetPosition(0, vec1);//0-начальная точка линии
        //           line.SetPosition(1, vec2);//1-конечная точка линии
        //       }




    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plant1")
        {
            colwithplant = true;
            if (dnk.typespawn > 0 && collision.gameObject.GetComponent<DnkPlant>().typespawn > 0)
            {
                int chancerandrodelete = Random.Range(0, 456);
                if (chancerandrodelete == 0) { Destroy(collision.gameObject); }
            }
            else
            {
                int chancerandrodelete = Random.Range(0, 10000);
                if (chancerandrodelete == 0) { Destroy(collision.gameObject); }
            }







        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plant1" )
        {
            colwithplant = false;

        }


    }


    void SpawnObj(GameObject child1or2, Vector3 v3, Quaternion q)
    {
        if (PhotonNetwork.IsConnected)
        {
            var obj = PhotonNetwork.Instantiate("Empty", v3, q);
            UnityEngine.Component[] components = GetComponents<UnityEngine.Component>();
            UnityEngine.Component[] componentsobj = obj.GetComponents<UnityEngine.Component>();

            for (int g = 0; g < componentsobj.Length; g++)
            {
                Destroy(componentsobj[g]);
            }
          //  for (int qw = 0; qw < components.Length; qw++)
        //    {
        //        UnityEditorInternal.ComponentUtility.CopyComponent(components[qw]);
         //       UnityEngine.Component comptopaste = obj.AddComponent(components[qw].GetType());
         //       UnityEditorInternal.ComponentUtility.PasteComponentValues(comptopaste);
          //  }

            foreach (Component c in components)
            {
                Debug.Log("@@ " + c.name + "\t[" + c.name + "] " + "\t" + c.GetType() + "\t" + c.GetType().BaseType);
            }

            if (child1or2 == child1g)
            {
                child1g = obj;
            }
            if (child1or2 == child2g)
            {
                child2g = obj;
            }
        }
        else
        {
            var obj = Instantiate(entity, v3, q);
            if (child1or2 == child1g)
            {
                child1g = obj;
            }
            if (child1or2 == child2g)
            {
                child2g = obj;
            }
        }
       
    }
}

    // Update is called once per frame
      
       
    

    

