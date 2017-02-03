using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public GameObject Collectable;
    public GameObject Level;
    GameObject[] platforms;
    public GameObject Player;
    bool nibe = false;
    GameObject[] Colls;
    Transform[] collTrans;
    GameObject[] SaveColls;

    int j = 0;
    int k = 0;
    float[] lengthtoSurface;
    
    // Use this for initialization
    void Start ()
    {
        lengthtoSurface = new float[23];

        Colls = new GameObject[23];
        
        collTrans = new Transform[23];

        Collectable.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
        platforms = Level.GetComponent<Platforms>().getPlatforms(true);

        SaveColls = new GameObject[Colls.Length];
        for (int i = 0; i < Colls.Length; i++)
        {

            Colls[i] = Instantiate(Collectable);

            /*
            Colls[i].AddComponent<SpriteRenderer>();
            Colls[i].AddComponent<BoxCollider2D>();
            Colls[i].GetComponent<SpriteRenderer>().sprite = Collectable.GetComponent<SpriteRenderer>().sprite;
            */

            collTrans[i] = Colls[i].GetComponent<Transform>();
            
        }
        

        for(int i = 0; i < Colls.Length;i++)
        {
            SaveColls[i] = Instantiate(Colls[i], collTrans[i]) as GameObject;
            SaveColls[i].GetComponent<BoxCollider2D>().isTrigger = true;
        }
       
        lengthtoSurface[0] = 2.5f;
        lengthtoSurface[1] = 2.5f;
        lengthtoSurface[2] = 2.5f;
        lengthtoSurface[3] = 2.5f;
        lengthtoSurface[4] = 2.5f;
        lengthtoSurface[5] = 2.5f;
        lengthtoSurface[6] = 3.5f;
        lengthtoSurface[7] = 3.5f;
        lengthtoSurface[8] = 3.5f;
        lengthtoSurface[9] = 3.5f;
        lengthtoSurface[10] = 3.5f;
        lengthtoSurface[11] = 3.5f;
        lengthtoSurface[12] = 3.5f;
        lengthtoSurface[13] = 3.5f;
        lengthtoSurface[14] = 4.5f;
        lengthtoSurface[15] = 4.5f;
        lengthtoSurface[16] = 4.5f;
        lengthtoSurface[17] = 4.5f;
        lengthtoSurface[18] = 4.5f;
        lengthtoSurface[19] = 4.5f;
        lengthtoSurface[20] = 4.5f;
        lengthtoSurface[21] = 4.5f;
        lengthtoSurface[22] = 4.5f;


        nibe = true;

    }
   
     void collisioncheck()
    {
        for (int i = 0; i < SaveColls.Length; i++)
        {
            if (SaveColls[i] != null && SaveColls[i].GetComponent<BoxCollider2D>().IsTouching(Player.GetComponent<BoxCollider2D>()))
            {
                Debug.Log("Player törmäsi Collectableen");
                SaveColls[i].GetComponent<SpriteRenderer>().sprite = null;
                Destroy(SaveColls[i].gameObject);
            }
        }
    }
    
   /* void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            for(int i = 0; i < SaveColls.Length;i++)
            {
                if(SaveColls[i].name == Player.GetComponent<Player>().getHitCollect())
                {
                    
                }
            }
            
        }
    }*/
	
	// Update is called once per frame
	void Update ()
    {
        platforms = Level.gameObject.GetComponent<Platforms>().getPlatforms(true);
        collisioncheck();
    }
    void FixedUpdate()
    {
       

        if (nibe == true)
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                if (platforms[i] != null && SaveColls[i] != null && i < 13 && i != 0)
                {

                    SaveColls[i].transform.position = new Vector3(platforms[i].transform.position.x, platforms[i].transform.position.y + lengthtoSurface[i], platforms[i].transform.position.z);
                    
                }
           
               
            }
        }
        
    }
}
