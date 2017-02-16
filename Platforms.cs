using UnityEngine;
using System.Collections;

public class Platforms : MonoBehaviour {


    public GameObject[] alustat;    //"Alusta" means "platform", the -t makes it plural.
    GameObject[] platforms;         //I told you, the code is a bit convoluded. xd
    //GameObject Spawner;
    public float moveSpeed;
    float StartingPoint;
    public Camera maincam;              //I literally have no idea what each of these variables do here.
    GameObject[] chosenPlatforms;       //Feel free to rewrite anything that uses these.
                                        //Well, except for the stuff I explicitly say should be left as is. :D That stuff is understandable in 
    int[] movingplatforms;
    GameObject[] usedPlatform;
    Collider2D[] Collit;
    GameObject Spawner;
    bool spawn = true;
    Collider2D[] collis; 
    Collider2D[] collis1;
    bool iscolliding;
    bool isSpawning = false;
    int[] Randoms;
    Collider2D triggerstaycol;
    int time = 0;
    Camera Cam;
    bool ebin = false;
    bool[] varattu;     //Varattu = taken, reserved.  I have no idea what this does.
    bool PlatformNelja = false;     //"Neljä" means 4. ._.
    public GameObject blockToGenerate; //THESE! Please keep all variables below this! They're actually reusable!
    public GameObject lastBlock;
    public GameObject blockBeforeLast;  //Okay, this one here may or may not be useful, idk.
    int rng;
    float rng3; //Lol, this happened because there's a "rng2" in the function that uses these.
    public int middleBlockPriority;
    public int transitionPriority;
    public int gapPriority;
    GameObject[] lowLeft;       //Just make these public so one can just drag level block prefabs to these.
    GameObject[] lowMiddle;     //The ones that are arrays have 2 variations, and when generated, the game randomly chooses one of them.
    GameObject[] lowRight;
    GameObject lowToMid;
    GameObject[] midLeft;
    GameObject[] midMiddle;
    GameObject[] midRight;
    GameObject midToLow;
    GameObject midToHigh;
    GameObject[] highLeft;
    GameObject[] highMiddle;
    GameObject[] highRight;
    GameObject highToMid;
    GameObject highToLow;


    // Use this for initialization
    void Start ()
    {
        movingplatforms = new int[6];
        Spawner = new GameObject();
        Spawner.AddComponent<BoxCollider2D>();              //Yes, let's construct simple GameObjects along with their positions and colliders in code, that's a wonderful idea!
        Spawner.AddComponent<Rigidbody2D>().isKinematic = true;
        Spawner.transform.position = new Vector3(20, 0, 0);
        Spawner.GetComponent<BoxCollider2D>().size = new Vector2(20, 20);
        Spawner.gameObject.name = "Spawner";
        Spawner.GetComponent<BoxCollider2D>().isTrigger = true;
        Spawner.GetComponent<Rigidbody2D>().sleepMode.Equals(RigidbodySleepMode2D.NeverSleep);

        lowLeft = new GameObject[2];
        lowMiddle = new GameObject[2];
        lowRight  = new GameObject[2];
        midLeft   = new GameObject[2];
        midMiddle = new GameObject[2];
        midRight  = new GameObject[2];
        highLeft  = new GameObject[2];
        highMiddle= new GameObject[2];
        highRight = new GameObject[2];

        varattu = new bool[6];
        for (int i = 0; i < varattu.Length; i++)
        {
            varattu[i] = false;
        }
        ebin = true;
        iscolliding = false;
        Randoms = new int[4];
        collis = new Collider2D[2];
        collis1 = new Collider2D[2];
        Collit = new Collider2D[alustat.Length + 5];
        chosenPlatforms = new GameObject[3];
        
        Cam = maincam.GetComponent<Camera>();
        
        platforms = new GameObject[alustat.Length];
        platforms[0] = Instantiate(alustat[0] , alustat[0].transform.position, Quaternion.identity) as GameObject;      //Yes, setting up a bunch of level blocks that should be generated in the
        platforms[1] = Instantiate(alustat[1] , alustat[1].transform.position, Quaternion.identity) as GameObject;      //game should obviously be constructed completely in code instead of being
        platforms[2] = Instantiate(alustat[2] , alustat[2].transform.position, Quaternion.identity) as GameObject;      //made as prefabs and put into the script via public GameObjects. 
        platforms[3] = Instantiate(alustat[3] , alustat[3].transform.position, Quaternion.identity) as GameObject;
        platforms[4] = Instantiate(alustat[4] , alustat[4].transform.position, Quaternion.identity) as GameObject;      //After all, it's obviously better to generate all the possible level blocks
        platforms[5] = Instantiate(alustat[5] , alustat[5].transform.position, Quaternion.identity) as GameObject;      //all at once when the level is instantiated and then stoaring them in
        platforms[6] = Instantiate(alustat[6] , alustat[6].transform.position, Quaternion.identity) as GameObject;      //completely separate GameObject variables. Instead of just making them
        platforms[7] = Instantiate(alustat[7] , alustat[7].transform.position, Quaternion.identity) as GameObject;      //as prefabs and calling them whenever needed.
        platforms[8] = Instantiate(alustat[8] , alustat[8].transform.position, Quaternion.identity) as GameObject;
        platforms[9] = Instantiate(alustat[9] , alustat[9].transform.position, Quaternion.identity) as GameObject;      //Obviously.
        platforms[10] =Instantiate(alustat[10], alustat[10].transform.position, Quaternion.identity) as GameObject;
        platforms[11] =Instantiate(alustat[11], alustat[11].transform.position, Quaternion.identity) as GameObject;
        platforms[12] =Instantiate(alustat[12], alustat[12].transform.position, Quaternion.identity) as GameObject;
        platforms[13] =Instantiate(alustat[13], alustat[13].transform.position, Quaternion.identity) as GameObject;
        platforms[14] =Instantiate(alustat[14], alustat[14].transform.position, Quaternion.identity) as GameObject;
        platforms[15] =Instantiate(alustat[15], alustat[15].transform.position, Quaternion.identity) as GameObject;
        platforms[16] =Instantiate(alustat[16], alustat[16].transform.position, Quaternion.identity) as GameObject;     //Please kill me.
        platforms[17] =Instantiate(alustat[17], alustat[17].transform.position, Quaternion.identity) as GameObject;
        platforms[18] =Instantiate(alustat[18], alustat[18].transform.position, Quaternion.identity) as GameObject;
        platforms[19] =Instantiate(alustat[19], alustat[19].transform.position, Quaternion.identity) as GameObject;
        platforms[20] =Instantiate(alustat[20], alustat[20].transform.position, Quaternion.identity) as GameObject;
        platforms[21] =Instantiate(alustat[21], alustat[21].transform.position, Quaternion.identity) as GameObject;
        platforms[22] =Instantiate(alustat[22], alustat[22].transform.position, Quaternion.identity) as GameObject;

        
        for(int i = 0; i < movingplatforms.Length; i++)
        {
            movingplatforms[i] = 0;
        }
        for(int i = 0; i < platforms.Length; i++)       //Yes, this too is done in code. ;___;
        {
            Debug.Log("Platform init");

                if(i == 0 || i == 1)
                {
                 platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                 (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x,
                    platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 4.375f);

                    platforms[i].GetComponent<BoxCollider2D>().offset = new Vector2(0, -8.5f);
                Collit[i] = platforms[i].GetComponent<BoxCollider2D>();
                }
                if(i == 2 || i == 3)
                {
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                 (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 1.25f,
                    platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 4.375f);

                platforms[i].GetComponent<BoxCollider2D>().offset = new Vector2(1.75f, -8.5f);
                Collit[i] = platforms[i].GetComponent<BoxCollider2D>();
            }
                if(i == 4 || i == 5)
                {
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 1.25f,
                   platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 4.375f);

                platforms[i].GetComponent<BoxCollider2D>().offset = new Vector2(-1.75f, -8.5f);
                Collit[i] = platforms[i].GetComponent<BoxCollider2D>();
            }
                if (i == 6)
                {
                BoxCollider2D[] Colliders;
                    platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                    (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2,
                    platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2.25f);

                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                    (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x,
                    platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 4.375f);
                Colliders = platforms[i].GetComponents<BoxCollider2D>();
                Colliders[0].offset = new Vector2(-2.625f, -6f);
                Colliders[1].offset = new Vector2(0, -8.5f);
                Collit[i] = Colliders[0];
                Collit[i + 1] = Colliders[1];
            }
                if (i == 7)
                {
                    BoxCollider2D[] Colliders;
                    platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                        (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2,
                        platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2.25f);

                    platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                        (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x,
                        platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 4.375f);
                    Colliders = platforms[i].GetComponents<BoxCollider2D>();
                    Colliders[0].offset = new Vector2(2.625f,-6f);
                    Colliders[1].offset = new Vector2(0, -8.5f);
                Collit[i +1] = Colliders[0];
                Collit[i + 2] = Colliders[1];



            }
            if(i == 10 || i == 11)
            {
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                        (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 1.5f,
                        platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2.25f);

                platforms[i].GetComponent<BoxCollider2D>().offset = new Vector2(1.9f, -6f);
                Collit[i + 2] = platforms[i].GetComponent<BoxCollider2D>();
            }
            if (i >= 8 && i <= 9)
            {
                
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                       (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x,
                       platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2.25f);

                platforms[i].GetComponent<BoxCollider2D>().offset = new Vector2(0, -6f);
                Collit[i + 2] = platforms[i].GetComponent<BoxCollider2D>();
            }
            if(i == 12 || i == 13)
            {
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                       (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 1.5f,
                       platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2.25f);

                platforms[i].GetComponent<BoxCollider2D>().offset = new Vector2(-1.9f, -6f);
                Collit[i + 2] = platforms[i].GetComponent<BoxCollider2D>();
            }
            if(i == 14)
            {
                BoxCollider2D[] Colliders;
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                    (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 1.5f,
                    platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 1.5f);

                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                    (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x,
                    platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2.25f);
                Colliders = platforms[i].GetComponents<BoxCollider2D>();
                Colliders[0].offset = new Vector2(-1.75f, -3.25f);
                Colliders[1].offset = new Vector2(0, -6f);
                Collit[i + 2] = Colliders[0];
                Collit[i + 3] = Colliders[1];
            }
            if(i == 15)
            {
                BoxCollider2D[] Colliders;
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                    (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 1.5f,
                    platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 1.5f);

                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                    (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x,
                    platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2.25f);
                Colliders = platforms[i].GetComponents<BoxCollider2D>();
                Colliders[0].offset = new Vector2(1.75f, -3.25f);
                Colliders[1].offset = new Vector2(0, -6f);
                Collit[i + 3] = Colliders[0];
                Collit[i + 4] = Colliders[1];
            }
            if(i == 16 || i == 17)
            {
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                   (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x,
                   platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 1.5f);

                platforms[i].GetComponent<BoxCollider2D>().offset = new Vector2(0, -3.25f);
                Collit[i + 4] = platforms[i].GetComponent<BoxCollider2D>();
            }
            if(i == 18 || i == 19)
            {
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                  (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2f,
                  platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 1.5f);

                platforms[i].GetComponent<BoxCollider2D>().offset = new Vector2(2.25f, -3.25f);
                Collit[i + 4] = platforms[i].GetComponent<BoxCollider2D>();
            }
            if (i == 20 || i == 21)
            {
                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                  (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2f,
                  platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 1.5f);

                platforms[i].GetComponent<BoxCollider2D>().offset = new Vector2(-2.25f, -3.25f);
                Collit[i + 4] = platforms[i].GetComponent<BoxCollider2D>();
            }
            if(i == 22)
            {
                BoxCollider2D[] Colliders;

                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                 (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x / 4.25f,
                 platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 1.5f);

                platforms[i].AddComponent<BoxCollider2D>().size = new Vector2
                (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x,
                   platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y / 4.375f);


                Colliders = platforms[i].GetComponents<BoxCollider2D>();
                Colliders[0].offset = new Vector2(-4.25f, -3.25f);
                Colliders[1].offset = new Vector2(0, -8.5f);
                Collit[i + 4] = Colliders[0];
                Collit[i + 5] = Colliders[1];
            }

           

        }
        for (int i = 0; i < Collit.Length; i++)
        {
            Debug.Log("Coll init");
            Collit[i].enabled = false;
        }
        platforms[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);          //Hhhhnnngggh
        platforms[2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[3].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[4].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[5].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[6].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[7].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[8].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[9].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[10].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[11].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[12].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[13].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[14].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[15].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[16].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[17].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[18].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[19].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[20].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[21].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        platforms[22].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        lowLeft[0] =   platforms[2];
        lowMiddle[0] = platforms[0];
        lowRight[0]  = platforms[4];
        lowLeft[1] =   platforms[3];        //Please, make it stop. ;___;
        lowMiddle[1] = platforms[1];
        lowRight[1] =  platforms[5];
        lowToMid  =    platforms[7];
        midLeft[0]   = platforms[10];
        midMiddle[0] = platforms[8];
        midRight[0]  = platforms[12];
        midLeft[1] =   platforms[11];
        midMiddle[1] = platforms[9];
        midRight[1] =  platforms[13];
        midToLow    =  platforms[6];
        midToHigh =    platforms[15];
        highLeft[0]  = platforms[18];
        highMiddle[0] =platforms[16];
        highRight[0] = platforms[20];
        highLeft[1] =  platforms[19];
        highMiddle[1]= platforms[17];
        highRight[1] = platforms[21];
        highToMid =    platforms[14];
        highToLow =    platforms[22];

        usedPlatform = new GameObject[6];
        usedPlatform[0] = null;
        usedPlatform[1] = null;
        usedPlatform[2] = null;
        usedPlatform[3] = null;
        usedPlatform[4] = null;
        usedPlatform[5] = null;
      

        blockToGenerate = lowMiddle[Random.Range(0, 2)];
        lastBlock = lowMiddle[Random.Range(0, 2)];
        blockBeforeLast = lowMiddle[Random.Range(0, 2)];


        usedPlatform[0] = Instantiate(blockToGenerate);

        usedPlatform[0].GetComponent<BoxCollider2D>().enabled = true;

        movingplatforms[0] = 1;
        
        StartingPoint = platforms[0].transform.position.x;
    }
    void instatePlatforms(GameObject TehPlatform) //, int rand, int rand1, int rand2)
    {
        Debug.Log("Ennen Spawnia päästiin.");   //"Made it before Spawn" or something like that. The grammar is a bit weird so even I don't fully get what this means.


       
        Debug.Log("Chosen next block");

       

        for (int j = 0; j < movingplatforms.Length; j++)
        {
            if (movingplatforms[j] == 0)
            {


               
                    if (usedPlatform[j] == null)
                    {
                        if (TehPlatform != null)
                        {
                            usedPlatform[j] = Instantiate(TehPlatform);
                        }
                        else
                        {
                            break;
                        }

                        if (usedPlatform[j] != null)
                        {
                            if (usedPlatform[j].GetComponents<BoxCollider2D>().Length > 1)
                            {
                                usedPlatform[j].GetComponents<BoxCollider2D>()[0].enabled = true;
                                usedPlatform[j].GetComponents<BoxCollider2D>()[1].enabled = true;
                            }
                            else
                            {
                                usedPlatform[j].GetComponent<BoxCollider2D>().enabled = true;
                            }
                        }
                    if (usedPlatform[j] != null)
                    {
                        movingplatforms[j] = 1;
                    }
                    break;
                }
                   
                    
                
                
                
            }
        }
          
    }
    // Update is called once per frame 
    
    void Update()
    {
        
        CheckCollision();
        
       
        movePlatforms();
       
        iscolliding = false;
       // destroyPlatforms();
       

    }
    public bool getNeljaPlatform()
    {
        return PlatformNelja;
    }

    void CheckCollision()
    {
        bool check = true;
        
        for (int i = 0; i < usedPlatform.Length; i++)
        {

            if (usedPlatform[i] == null)
            {
                varattu[i] = false;

            }
            else
            {
                varattu[i] = true;
                Debug.Log("Varattu true");
            }
        }
        for (int i = 0; i < usedPlatform.Length; i++)
        {
            if (varattu[i] == true)
            {
                if (usedPlatform[i].GetComponents<BoxCollider2D>().Length > 1)
                {
                    if (usedPlatform[i].GetComponents<BoxCollider2D>()[0].IsTouching(Spawner.GetComponent<BoxCollider2D>()) || usedPlatform[i].GetComponents<BoxCollider2D>()[1].IsTouching(Spawner.GetComponent<BoxCollider2D>()))
                    {
                        check = false;
                        Debug.Log("Check False");

                    }
                }
                else if (usedPlatform[i].GetComponent<BoxCollider2D>().IsTouching(Spawner.GetComponent<BoxCollider2D>()))
                {

                    check = false;
                    Debug.Log("Check False");
                }
                
            }
        }
          
        
        if (check)
        {
            check = false;
            ChooseLevelBlock();
            instatePlatforms(blockToGenerate);//, Random.Range(2, 4), Random.Range(0, 2), Random.Range(4, 6);
            
            
        }
        
       /* bool Allmet = true;
        for (int s = 0; s < usedPlatform.Length; s++)
        {
            if (usedPlatform[s] != null && s < 13 && s != 0)
            {
                Debug.Log("Else in update");
                Allmet = false;
            }


        }
        if (Allmet)
        {
            Debug.Log("ALLMet");
            instatePlatforms(Random.Range(1, 5), Random.Range(2, 4), Random.Range(0, 2), Random.Range(4, 6);
        }

        */
    }
    public void ChooseLevelBlock()      //THIS VOID RIGHT HERE!! Please use it! It's an algorithm for selecting which level block to generate next. Just use the variables I said were reusable and then call this function.
    {

        if (lastBlock == lowRight[0] || lastBlock == midRight[0] || lastBlock == highRight[0] || lastBlock == lowRight[1] || lastBlock == midRight[1] || lastBlock == highRight[1])  //If it's a right corner block, the next block is a gap.
        {
            blockBeforeLast = lastBlock;
            lastBlock = blockToGenerate;
            blockToGenerate = null;
            Debug.Log("Gap");
           
        }
        else if (lastBlock == lowLeft[0] || lastBlock == lowMiddle[0] || lastBlock == lowLeft[1] || lastBlock == lowMiddle[1] || lastBlock == midToLow || lastBlock == highToLow)
        {
            lastBlock = blockToGenerate;
            float rng2 = (float)Random.Range(0f, middleBlockPriority) / 2;
            if (rng2 <= 0.5f)
            {

                rng3 = Random.Range(0f, (float)transitionPriority);
                if (rng3 <= 0.5f)
                {
                    blockToGenerate = lowRight[Random.Range(0, 2)];
                    Debug.Log("Low Right");
                }
                else
                {
                    blockToGenerate = lowToMid;
                    Debug.Log("Low to Mid");
                }
            }
            else
            {
                blockToGenerate = lowMiddle[Random.Range(0, 2)];
                Debug.Log("Low Middle");
            }       //Turns out that we don't need the blockBeforeLast variable atm. We might in the future though if the gaps can get a bit longer.
           // blockBeforeLast = lastBlock;
           
        }
        else if (lastBlock == midLeft[0] || lastBlock == midMiddle[0] || lastBlock == midLeft[1] || lastBlock == midMiddle[1] || lastBlock == lowToMid || lastBlock == highToMid)
        {
            lastBlock = blockToGenerate;
            float rng2 = (float)Random.Range(0f, middleBlockPriority) / 2;
            if (rng2 <= 0.5f)
            {

                rng = Random.Range(0, 3);
                if (rng == 0)
                {
                    blockToGenerate = midRight[Random.Range(0, 2)];
                    Debug.Log("Mid Right");
                }
                else if (rng == 1)
                {
                    blockToGenerate = midToLow;
                    Debug.Log("Mid to Low");
                }
                else
                {
                    blockToGenerate = midToHigh;
                    Debug.Log("Mid to High");
                }
            }
            else
            {
                blockToGenerate = midMiddle[Random.Range(0, 2)];
                Debug.Log("Mid Middle");
            }
           // blockBeforeLast = lastBlock;
           
        }
        else if (lastBlock == highLeft[0] || lastBlock == highMiddle[0] || lastBlock == highLeft[1] || lastBlock == highMiddle[1] || lastBlock == midToHigh)
        {
            lastBlock = blockToGenerate;
            float rng2 = (float)Random.Range(0f, middleBlockPriority) / 2;
            if (rng2 <= 0.5f)
            {

                rng = Random.Range(0, 3);
                if (rng == 0)
                {
                    blockToGenerate = highRight[Random.Range(0, 2)];
                    Debug.Log("High Right");
                }
                else if (rng == 1)
                {
                    blockToGenerate = highToMid;
                    Debug.Log("High to Mid");
                }
                else
                {
                    blockToGenerate = highToLow;
                    Debug.Log("High to Low");
                }
            }
            else
            {
                blockToGenerate = highMiddle[Random.Range(0, 2)];
                Debug.Log("High Middle");
            }
           // blockBeforeLast = lastBlock;
            
        }
        else if (lastBlock == null) //What happens if the last piece was a gap // you fall... :D 
        {
            if (blockBeforeLast == lowRight[0] || blockBeforeLast == lowRight[1])
            {
                lastBlock = blockToGenerate;
                blockToGenerate = lowLeft[Random.Range(0, 2)];
                Debug.Log("Low Left");
               // blockBeforeLast = lastBlock;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                
            }
            else if (blockBeforeLast == midRight[0] || blockBeforeLast == midRight[1])
            {
                lastBlock = blockToGenerate;
                rng = Random.Range(0, 2);
                if (rng == 0)
                {
                    blockToGenerate = midLeft[Random.Range(0, 2)];
                    Debug.Log("Mid Left");
                }
                else
                {
                    blockToGenerate = lowLeft[Random.Range(0, 2)];
                    Debug.Log("Low Left;");
                }
                // blockBeforeLast = lastBlock;
               
            }
            else if (blockBeforeLast == highRight[0] || blockBeforeLast == highRight[1])
            {
                
                rng = Random.Range(0, 3);
                if (rng == 0)
                {
                    blockToGenerate = highLeft[Random.Range(0, 2)];
                    Debug.Log("High Left");
                }
                else if (rng == 1)
                {
                    blockToGenerate = midLeft[Random.Range(0, 2)];
                    Debug.Log("Mid Left");
                }
                else
                {
                    blockToGenerate = lowLeft[Random.Range(0, 2)];
                    Debug.Log("Low Left;");
                }
                lastBlock = blockToGenerate;
                // blockBeforeLast = lastBlock;

            }
            else if(blockBeforeLast == null)
            {
                lastBlock = blockToGenerate;
                rng = Random.Range(0, 6);
                {
                    if (rng == 0)
                    {
                        blockToGenerate = lowLeft[Random.Range(0, 2)];
                        Debug.Log("Low Left");
                        // blockBeforeLast = lastBlock;
                    }
                    else if (rng == 1)
                    {
                        blockToGenerate = midLeft[Random.Range(0, 2)];
                        Debug.Log("Mid Left");
                    }
                    else if (rng == 2)
                    {
                        blockToGenerate = lowLeft[Random.Range(0, 2)];
                        Debug.Log("Low Left;");
                    }
                    // blockBeforeLast = lastBlock;
                    else if (rng == 3)
                    {
                        blockToGenerate = highLeft[Random.Range(0, 2)];
                        Debug.Log("High Left");
                    }
                    else if (rng == 4)                       
                    {
                        blockToGenerate = midLeft[Random.Range(0, 2)];
                        Debug.Log("Mid Left");
                    }
                    else
                    {
                        blockToGenerate = lowLeft[Random.Range(0, 2)];
                        Debug.Log("Low Left;");
                    }
                }
            }
        }

    }



    void movePlatforms()
    {
        /*
        platforms[0].transform.position = new Vector3(platforms[0].transform.position.x - moveSpeed, platforms[0].transform.position.y, platforms[0].transform.position.z);     Lotsa commented code, yay.
        platforms[1].transform.position = new Vector3(platforms[1].transform.position.x - moveSpeed, platforms[1].transform.position.y, platforms[1].transform.position.z);     This shit was a thing at one point.
        platforms[2].transform.position = new Vector3(platforms[2].transform.position.x - moveSpeed, platforms[2].transform.position.y, platforms[2].transform.position.z);
        platforms[3].transform.position = new Vector3(platforms[3].transform.position.x - moveSpeed, platforms[3].transform.position.y, platforms[3].transform.position.z);
        platforms[4].transform.position = new Vector3(platforms[4].transform.position.x - moveSpeed, platforms[4].transform.position.y, platforms[4].transform.position.z);
        platforms[5].transform.position = new Vector3(platforms[5].transform.position.x - moveSpeed, platforms[5].transform.position.y, platforms[5].transform.position.z);
        platforms[6].transform.position = new Vector3(platforms[6].transform.position.x - moveSpeed, platforms[6].transform.position.y, platforms[6].transform.position.z);
        platforms[7].transform.position = new Vector3(platforms[7].transform.position.x - moveSpeed, platforms[7].transform.position.y, platforms[7].transform.position.z);
        platforms[8].transform.position = new Vector3(platforms[8].transform.position.x - moveSpeed, platforms[8].transform.position.y, platforms[8].transform.position.z);
        platforms[9].transform.position = new Vector3(platforms[9].transform.position.x - moveSpeed, platforms[9].transform.position.y, platforms[9].transform.position.z);
        platforms[10].transform.position = new Vector3(platforms[10].transform.position.x - moveSpeed, platforms[10].transform.position.y, platforms[10].transform.position.z);
        platforms[11].transform.position = new Vector3(platforms[11].transform.position.x - moveSpeed, platforms[11].transform.position.y, platforms[11].transform.position.z);
        platforms[12].transform.position = new Vector3(platforms[12].transform.position.x - moveSpeed, platforms[12].transform.position.y, platforms[12].transform.position.z);
        platforms[13].transform.position = new Vector3(platforms[13].transform.position.x - moveSpeed, platforms[13].transform.position.y, platforms[13].transform.position.z);
        platforms[14].transform.position = new Vector3(platforms[14].transform.position.x - moveSpeed, platforms[14].transform.position.y, platforms[14].transform.position.z);
        platforms[15].transform.position = new Vector3(platforms[15].transform.position.x - moveSpeed, platforms[15].transform.position.y, platforms[15].transform.position.z);
        platforms[16].transform.position = new Vector3(platforms[16].transform.position.x - moveSpeed, platforms[16].transform.position.y, platforms[16].transform.position.z);
        platforms[17].transform.position = new Vector3(platforms[17].transform.position.x - moveSpeed, platforms[17].transform.position.y, platforms[17].transform.position.z);
        platforms[18].transform.position = new Vector3(platforms[18].transform.position.x - moveSpeed, platforms[18].transform.position.y, platforms[18].transform.position.z);
        platforms[19].transform.position = new Vector3(platforms[19].transform.position.x - moveSpeed, platforms[19].transform.position.y, platforms[19].transform.position.z);
        platforms[20].transform.position = new Vector3(platforms[20].transform.position.x - moveSpeed, platforms[20].transform.position.y, platforms[20].transform.position.z);
        platforms[21].transform.position = new Vector3(platforms[21].transform.position.x - moveSpeed, platforms[21].transform.position.y, platforms[21].transform.position.z);
        platforms[22].transform.position = new Vector3(platforms[22].transform.position.x - moveSpeed, platforms[22].transform.position.y, platforms[22].transform.position.z);
        */
        for (int i = 0; i < movingplatforms.Length; i++)
        {
            if (movingplatforms[i] == 1)
            {
                usedPlatform[i].transform.position = new Vector3(usedPlatform[i].transform.position.x - moveSpeed, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                /* for (int i = 1; i < 4; i++)
                 {
                     if (usedPlatform[i].transform.position.x + 15 < Cam.rect.xMin)
                     {
                         Debug.Log("Tänne päästiin");
                         //usedPlatform[i].transform.position = new Vector3(StartingPoint, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                         Destroy(usedPlatform[i]);

                     }*/
                if (usedPlatform[i].transform.position.x + 2.5 < Cam.transform.position.x - 10)
                {

                    Destroy(usedPlatform[i].gameObject);
                    usedPlatform[i] = null;

                    movingplatforms[i] = 0;
                }
                //}


            }
        }
        /*
            if (movingplatform1 == 1)
            {
                usedPlatform[4].transform.position = new Vector3(usedPlatform[4].transform.position.x - moveSpeed, usedPlatform[4].transform.position.y, usedPlatform[4].transform.position.z);     Even more commented code, yaaaay...
                usedPlatform[5].transform.position = new Vector3(usedPlatform[5].transform.position.x - moveSpeed, usedPlatform[5].transform.position.y, usedPlatform[5].transform.position.z);
                usedPlatform[6].transform.position = new Vector3(usedPlatform[6].transform.position.x - moveSpeed, usedPlatform[6].transform.position.y, usedPlatform[6].transform.position.z);
                /*  for (int i = 4; i < 7; i++)
                  {
                      if (usedPlatform[i].transform.position.x + 15 < Cam.rect.xMin)
                      {
                          // usedPlatform[i].transform.position = new Vector3(StartingPoint, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                          Destroy(usedPlatform[i]);
                      }
                if (usedPlatform[6].transform.position.x + 2.5 < Cam.transform.position.x - 10)
                {


                    Destroy(usedPlatform[4]);
                    PlatformNelja = false;
                    Destroy(usedPlatform[5]);
                    Destroy(usedPlatform[6]);
                    Debug.Log("Moving Platform päästiin.");
                    movingplatform1 = 0;
                }
                //}
            }
            if (movingplatform2 == 1)
            {
                usedPlatform[7].transform.position = new Vector3(usedPlatform[7].transform.position.x - moveSpeed, usedPlatform[7].transform.position.y, usedPlatform[7].transform.position.z);
                usedPlatform[8].transform.position = new Vector3(usedPlatform[8].transform.position.x - moveSpeed, usedPlatform[8].transform.position.y, usedPlatform[8].transform.position.z);
                usedPlatform[9].transform.position = new Vector3(usedPlatform[9].transform.position.x - moveSpeed, usedPlatform[9].transform.position.y, usedPlatform[9].transform.position.z);
                /* for (int i = 7; i < 10; i++)
                 {
                     if (usedPlatform[i].transform.position.x + 15 < Cam.rect.xMin)
                     {
                         //  usedPlatform[i].transform.position = new Vector3(StartingPoint, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                         Destroy(usedPlatform[i]);
                     }
                if (usedPlatform[9].transform.position.x + 2.5 < Cam.transform.position.x - 10)
                {

                    Destroy(usedPlatform[7].gameObject);
                    Destroy(usedPlatform[8].gameObject);
                    Destroy(usedPlatform[9].gameObject);
                    movingplatform2 = 0;
                }
                //}
            }
            if (movingplatform3 == 1)
            {
                usedPlatform[10].transform.position = new Vector3(usedPlatform[10].transform.position.x - moveSpeed, usedPlatform[10].transform.position.y, usedPlatform[10].transform.position.z);
                usedPlatform[11].transform.position = new Vector3(usedPlatform[11].transform.position.x - moveSpeed, usedPlatform[11].transform.position.y, usedPlatform[11].transform.position.z);
                usedPlatform[12].transform.position = new Vector3(usedPlatform[12].transform.position.x - moveSpeed, usedPlatform[12].transform.position.y, usedPlatform[12].transform.position.z);
                /* for (int i = 10; i < 13; i++)
                 {
                     if (usedPlatform[i].transform.position.x + 15 < Cam.rect.xMin)
                     {
                         // usedPlatform[i].transform.position = new Vector3(StartingPoint, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                         Destroy(usedPlatform[i]);
                     }
                if (usedPlatform[12].transform.position.x + 2.5 < Cam.transform.position.x - 10)
                {

                    Destroy(usedPlatform[10].gameObject);
                    Destroy(usedPlatform[11].gameObject);
                    Destroy(usedPlatform[12].gameObject);
                    movingplatform3 = 0;
                }
                //}
            }
            if (movingplatform4 == 1)
            {
                usedPlatform[13].transform.position = new Vector3(usedPlatform[13].transform.position.x - moveSpeed, usedPlatform[13].transform.position.y, usedPlatform[13].transform.position.z);    ...it's still going...
                usedPlatform[14].transform.position = new Vector3(usedPlatform[14].transform.position.x - moveSpeed, usedPlatform[14].transform.position.y, usedPlatform[14].transform.position.z);
                usedPlatform[15].transform.position = new Vector3(usedPlatform[15].transform.position.x - moveSpeed, usedPlatform[15].transform.position.y, usedPlatform[15].transform.position.z);
                /*for (int i = 13; i < 16; i++)
                {
                    if (usedPlatform[i].transform.position.x + 15 < Cam.rect.xMin)
                    {
                        // usedPlatform[i].transform.position = new Vector3(StartingPoint, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                        Destroy(usedPlatform[i]);
                    }
                if (usedPlatform[15].transform.position.x + 2.5 < Cam.transform.position.x - 10)
                {
                    Destroy(usedPlatform[13].gameObject);
                    Destroy(usedPlatform[14].gameObject);
                    Destroy(usedPlatform[15].gameObject);
                    movingplatform4 = 0;
                }

                //}
            }
            if (movingplatform5 == 1)
            {
                usedPlatform[16].transform.position = new Vector3(usedPlatform[16].transform.position.x - moveSpeed, usedPlatform[16].transform.position.y, usedPlatform[16].transform.position.z);
                usedPlatform[17].transform.position = new Vector3(usedPlatform[17].transform.position.x - moveSpeed, usedPlatform[17].transform.position.y, usedPlatform[17].transform.position.z);
                usedPlatform[18].transform.position = new Vector3(usedPlatform[18].transform.position.x - moveSpeed, usedPlatform[18].transform.position.y, usedPlatform[18].transform.position.z);
                /*for (int i = 16; i < 19; i++)
                {
                    if (usedPlatform[i].transform.position.x + 15 < Cam.rect.xMin)
                    {
                        // usedPlatform[i].transform.position = new Vector3(StartingPoint, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                        Destroy(usedPlatform[i]);
                    }
                if (usedPlatform[18].transform.position.x + 2.5 < Cam.transform.position.x - 10)
                {
                    Destroy(usedPlatform[16].gameObject);
                    Destroy(usedPlatform[17].gameObject);
                    Destroy(usedPlatform[18].gameObject);

                    movingplatform5 = 0;                                              ._.
                    }
            }
        }*/
      

    }
    
  /* void OnTriggerStay2D(Collider2D col)
    {
         if (col.gameObject.tag == "Platform")
         {
             return;
         }

       


    }*/
    public GameObject[] getPlatforms(bool whole)
    {
        return usedPlatform;
        /*
        GameObject[] fstplatform = new GameObject[3];
        GameObject[] sstplatform = new GameObject[3];
        GameObject[] tstplatform = new GameObject[3];
        GameObject[] fostplatform = new GameObject[3];

        if(whole)
        {
            return usedPlatform;
        }

        if(usedPlatform[1] != null && usedPlatform[2] != null && usedPlatform[3] != null && 
            usedPlatform[4] != null && usedPlatform[5] != null && usedPlatform[6] != null &&
            usedPlatform[7] != null && usedPlatform[8] != null && usedPlatform[9] != null &&
            usedPlatform[10] != null && usedPlatform[11] != null && usedPlatform[12] != null)
        {
            return usedPlatform;
        }

        if (usedPlatform[1] != null && usedPlatform[2] != null && usedPlatform[3] != null)
        {


            fstplatform[0] = usedPlatform[1];
            fstplatform[1] = usedPlatform[2];
            fstplatform[2] = usedPlatform[3];

            return fstplatform;
        }
        
        if (usedPlatform[4] != null && usedPlatform[5] != null && usedPlatform[6] != null)
        {
            sstplatform[0] = usedPlatform[4];
            sstplatform[1] = usedPlatform[5];
            sstplatform[2] = usedPlatform[6];
            return sstplatform;
        }
       
        if (usedPlatform[7] != null && usedPlatform[8] != null && usedPlatform[9] != null)
        {
            tstplatform[0] = usedPlatform[7];
            tstplatform[1] = usedPlatform[8];
            tstplatform[2] = usedPlatform[9];
            return tstplatform;
        }

        if (usedPlatform[10] != null && usedPlatform[11] != null && usedPlatform[12] != null)                                                      .____________________.
        {
            fostplatform[0] = usedPlatform[10];
            fostplatform[1] = usedPlatform[11];
            fostplatform[2] = usedPlatform[12];
            return fostplatform;

        }
        */
       
    }


   /* void OnTriggerExit2D(Collider2D col)
    {
       
            if (iscolliding) return;

            iscolliding = true;

            if (col.gameObject.tag == "Platform")
            {

                 instatePlatforms(Random.Range(1, 4), Random.Range(2, 3), Random.Range(0, 1), Random.Range(4, 5));

            }
        
    }*/


    /*
    void destroyPlatforms()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            if (platforms[i].GetComponent<SpriteRenderer>().sprite.bounds.max.x < Cam.rect.xMin)
            {
                Destroy(platforms[i].gameObject);
            }

        }
    }
   */

}
