using UnityEngine;
using System.Collections;

public class Platforms : MonoBehaviour {


    public GameObject[] alustat;
    GameObject[] platforms;
    //GameObject Spawner;
    public float moveSpeed;
    float StartingPoint;
    public Camera maincam;
    GameObject[] chosenPlatforms;
    int movingplatform = 0;
    int movingplatform1 = 0;
    int movingplatform2 = 0;
    int movingplatform3 = 0;
    int movingplatform4 = 0;
    int movingplatform5 = 0;
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
    bool varattu;
    bool check = false;
    bool check1 = false;
    bool check2 = false;
    bool check3 = false;
    
    // Use this for initialization
    void Start ()
    {
        
        Spawner = new GameObject();
        Spawner.AddComponent<BoxCollider2D>();
        Spawner.AddComponent<Rigidbody2D>().isKinematic = true;
        Spawner.transform.position = new Vector3(20, 0, 0);
        Spawner.GetComponent<BoxCollider2D>().size = new Vector2(20, 20);
        Spawner.gameObject.name = "Spawner";
        Spawner.GetComponent<BoxCollider2D>().isTrigger = true;
        Spawner.GetComponent<Rigidbody2D>().sleepMode.Equals(RigidbodySleepMode2D.NeverSleep);

        ebin = true;
        iscolliding = false;
        Randoms = new int[4];
        collis = new Collider2D[2];
        collis1 = new Collider2D[2];
        Collit = new Collider2D[alustat.Length + 5];
        chosenPlatforms = new GameObject[3];
        
        Cam = maincam.GetComponent<Camera>();
        
        platforms = new GameObject[alustat.Length];
        platforms[0] = Instantiate(alustat[0] , alustat[0].transform.position, Quaternion.identity) as GameObject;
        platforms[1] = Instantiate(alustat[1] , alustat[1].transform.position, Quaternion.identity) as GameObject;
        platforms[2] = Instantiate(alustat[2] , alustat[2].transform.position, Quaternion.identity) as GameObject;
        platforms[3] = Instantiate(alustat[3] , alustat[3].transform.position, Quaternion.identity) as GameObject;
        platforms[4] = Instantiate(alustat[4] , alustat[4].transform.position, Quaternion.identity) as GameObject;
        platforms[5] = Instantiate(alustat[5] , alustat[5].transform.position, Quaternion.identity) as GameObject;
        platforms[6] = Instantiate(alustat[6] , alustat[6].transform.position, Quaternion.identity) as GameObject;
        platforms[7] = Instantiate(alustat[7] , alustat[7].transform.position, Quaternion.identity) as GameObject;
        platforms[8] = Instantiate(alustat[8] , alustat[8].transform.position, Quaternion.identity) as GameObject;
        platforms[9] = Instantiate(alustat[9] , alustat[9].transform.position, Quaternion.identity) as GameObject;
        platforms[10] =Instantiate(alustat[10], alustat[10].transform.position, Quaternion.identity) as GameObject;
        platforms[11] =Instantiate(alustat[11], alustat[11].transform.position, Quaternion.identity) as GameObject;
        platforms[12] =Instantiate(alustat[12], alustat[12].transform.position, Quaternion.identity) as GameObject;
        platforms[13] =Instantiate(alustat[13], alustat[13].transform.position, Quaternion.identity) as GameObject;
        platforms[14] =Instantiate(alustat[14], alustat[14].transform.position, Quaternion.identity) as GameObject;
        platforms[15] =Instantiate(alustat[15], alustat[15].transform.position, Quaternion.identity) as GameObject;
        platforms[16] =Instantiate(alustat[16], alustat[16].transform.position, Quaternion.identity) as GameObject;
        platforms[17] =Instantiate(alustat[17], alustat[17].transform.position, Quaternion.identity) as GameObject;
        platforms[18] =Instantiate(alustat[18], alustat[18].transform.position, Quaternion.identity) as GameObject;
        platforms[19] =Instantiate(alustat[19], alustat[19].transform.position, Quaternion.identity) as GameObject;
        platforms[20] =Instantiate(alustat[20], alustat[20].transform.position, Quaternion.identity) as GameObject;
        platforms[21] =Instantiate(alustat[21], alustat[21].transform.position, Quaternion.identity) as GameObject;
        platforms[22] =Instantiate(alustat[22], alustat[22].transform.position, Quaternion.identity) as GameObject;

        

        for(int i = 0; i < platforms.Length; i++)
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
        platforms[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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

        usedPlatform = new GameObject[platforms.Length];
        usedPlatform[1] = platforms[2];
        usedPlatform[2] = platforms[0];
        usedPlatform[3] = platforms[4];
        usedPlatform[4] = platforms[8];
        usedPlatform[5] = platforms[9];
        usedPlatform[6] = platforms[2];
        usedPlatform[7] = platforms[0];
        usedPlatform[8] = platforms[4];
        usedPlatform[9] = platforms[8];
        usedPlatform[10] = platforms[9];
        usedPlatform[11] = platforms[2];
        usedPlatform[12] = platforms[0];
        usedPlatform[13] = platforms[4];
        usedPlatform[14] = platforms[8];
        usedPlatform[15] = platforms[4];
        usedPlatform[16] = platforms[8];
        usedPlatform[17] = platforms[9];
        usedPlatform[18] = platforms[9];
        usedPlatform[19] = platforms[1];
        usedPlatform[20] = platforms[1];
        usedPlatform[21] = platforms[1];
        usedPlatform[22] = platforms[1];

       
        usedPlatform[1] = Instantiate(platforms[2]);
        usedPlatform[2] = Instantiate(platforms[0]);
        usedPlatform[3] = Instantiate(platforms[4]);

        usedPlatform[1].GetComponent<BoxCollider2D>().enabled = true;
        usedPlatform[2].GetComponent<BoxCollider2D>().enabled = true;
        usedPlatform[3].GetComponent<BoxCollider2D>().enabled = true;
        movingplatform = 1;
        StartingPoint = platforms[0].transform.position.x;
    }
    void instatePlatforms(int TheRand, int rand, int rand1, int rand2)
    {
        Debug.Log("Ennen Spawnia päästiin.");

        
            int add = 0;
            int add1 = 0;
            int add2 = 0;


            //  int[] addative = { 4, 5, 7, 8, 13, 14, 16, 17 };

            if (TheRand == 1 && movingplatform == 0 && varattu == true)
            {



                usedPlatform[1] = Instantiate(platforms[rand]);
                usedPlatform[2] = Instantiate(platforms[rand1]);
                usedPlatform[3] = Instantiate(platforms[rand2]);

                usedPlatform[1].GetComponent<BoxCollider2D>().enabled = true;
                usedPlatform[2].GetComponent<BoxCollider2D>().enabled = true;
                usedPlatform[3].GetComponent<BoxCollider2D>().enabled = true;
                movingplatform = 1;
            varattu = false;

            }
            /*else if (TheRand == 1 && movingplatform == 1)
            {
                TheRand++;
            }*/
            if (TheRand == 2 && movingplatform1 == 0 && varattu == true)
            {

                if (rand == 2)
                {
                    add = 5;

                }
                if (rand == 3)
                {
                    add = 7;

                }
                if (rand1 == 0)
                {
                    add1 = 8;

                }
                if (rand1 == 1)
                {
                    add1 = 7;

                }
                if (rand2 == 4)
                {
                    add2 = 2;

                }
                if (rand2 == 5)
                {
                    add2 = 1;

                }



                usedPlatform[4] = Instantiate(platforms[rand + add]);
                usedPlatform[5] = Instantiate(platforms[rand1 + add1]);
                usedPlatform[6] = Instantiate(platforms[rand2 + add2]);

                if (rand == 2)
                {
                    BoxCollider2D[] Boxes = new BoxCollider2D[2];
                    Boxes = usedPlatform[4].GetComponents<BoxCollider2D>();
                    Boxes[0].enabled = true;
                    Boxes[1].enabled = true;
                }
                else if (rand == 3)
                {
                    usedPlatform[5].GetComponent<BoxCollider2D>().enabled = true;
                }

                usedPlatform[5].GetComponent<BoxCollider2D>().enabled = true;

                if (rand2 == 4 || rand2 == 5)
                {
                    BoxCollider2D[] Boxes = new BoxCollider2D[2];
                    Boxes = usedPlatform[6].GetComponents<BoxCollider2D>();
                    Boxes[0].enabled = true;
                    Boxes[1].enabled = true;
                }


                /*  usedPlatform[4].transform.position = new Vector3(usedPlatform[4].transform.position.x + 20, usedPlatform[4].transform.position.y, usedPlatform[4].transform.position.z);
                  usedPlatform[5].transform.position = new Vector3(usedPlatform[5].transform.position.x + 20, usedPlatform[5].transform.position.y, usedPlatform[5].transform.position.z);
                  usedPlatform[6].transform.position = new Vector3(usedPlatform[6].transform.position.x + 20, usedPlatform[6].transform.position.y, usedPlatform[6].transform.position.z);*/

                movingplatform1 = 1;
            varattu = false;
        }
           /* else if (TheRand == 2 && movingplatform1 == 1)
            {
                TheRand++;
            }*/
            if (TheRand == 3 && movingplatform2 == 0 && varattu == true)
            {

                if (rand == 2)
                {
                    add = 8;

                }
                if (rand == 3)
                {
                    add = 8;

                }
                if (rand1 == 0)
                {
                    add1 = 9;

                }
                if (rand1 == 1)
                {
                    add1 = 8;

                }
                if (rand2 == 4)
                {
                    add2 = 9;

                }
                if (rand2 == 5)
                {
                    add2 = 8;

                }


                usedPlatform[7] = Instantiate(platforms[rand + add]);
                usedPlatform[8] = Instantiate(platforms[rand1 + add1]);
                usedPlatform[9] = Instantiate(platforms[rand2 + add2]);

                usedPlatform[7].GetComponent<BoxCollider2D>().enabled = true;
                usedPlatform[8].GetComponent<BoxCollider2D>().enabled = true;
                usedPlatform[9].GetComponent<BoxCollider2D>().enabled = true;
                /*  usedPlatform[7].transform.position = new Vector3(usedPlatform[7].transform.position.x + 40, usedPlatform[7].transform.position.y, usedPlatform[7].transform.position.z);
                  usedPlatform[8].transform.position = new Vector3(usedPlatform[8].transform.position.x + 40, usedPlatform[8].transform.position.y, usedPlatform[8].transform.position.z);
                  usedPlatform[9].transform.position = new Vector3(usedPlatform[9].transform.position.x + 40, usedPlatform[9].transform.position.y, usedPlatform[9].transform.position.z);*/

                movingplatform2 = 1;
            varattu = false;
        }
           /* else if (TheRand == 3 && movingplatform2 == 1)
            {
                TheRand++;
            }*/
            if (TheRand == 4 && movingplatform3 == 0 && varattu == true)
            {

                if (rand == 2)
                {
                    add = 13;

                }
                if (rand == 3)
                {
                    add = 12;

                }
                if (rand1 == 0)
                {
                    add1 = 16;

                }
                if (rand1 == 1)
                {
                    add1 = 15;

                }
                if (rand2 == 4)
                {
                    add2 = 16;

                }
                if (rand2 == 5)
                {
                    add2 = 17;

                }

                usedPlatform[10] = Instantiate(platforms[rand + add]);
                usedPlatform[11] = Instantiate(platforms[rand1 + add1]);
                usedPlatform[12] = Instantiate(platforms[rand2 + add2]);

                if (rand == 2 || rand == 3)
                {
                    BoxCollider2D[] Boxes = new BoxCollider2D[2];
                    Boxes = usedPlatform[10].GetComponents<BoxCollider2D>();
                    Boxes[0].enabled = true;
                    Boxes[1].enabled = true;
                }

                usedPlatform[11].GetComponent<BoxCollider2D>().enabled = true;
                usedPlatform[12].GetComponent<BoxCollider2D>().enabled = true;

                /*usedPlatform[10].transform.position = new Vector3(usedPlatform[10].transform.position.x + 60, usedPlatform[10].transform.position.y, usedPlatform[10].transform.position.z);
                usedPlatform[11].transform.position = new Vector3(usedPlatform[11].transform.position.x + 60, usedPlatform[11].transform.position.y, usedPlatform[11].transform.position.z);
                usedPlatform[12].transform.position = new Vector3(usedPlatform[12].transform.position.x + 60, usedPlatform[12].transform.position.y, usedPlatform[12].transform.position.z);*/

                movingplatform3 = 1;
            varattu = false;
        }
        /*else if (TheRand == 4 && movingplatform3 == 1)
        {
            TheRand = 1;
        }*/
        /* if (TheRand == 5)
         {
             if (rand == 2)
             {
                 add = 5;
             }
             if (rand == 3)
             {
                 add = 4;
             }
             if (rand1 == 0)
             {
                 add1 = 8;
             }
             if (rand1 == 1)
             {
                 add1 = 7;
             }
             if (rand2 == 4)
             {
                 add2 = 7;
             }
             if (rand2 == 5)
             {
                 add2 = 7;
             }
             usedPlatform[13] = platforms[rand];
             usedPlatform[14] = platforms[rand1];
             usedPlatform[15] = platforms[rand2];
             chosenPlatforms = TheRand;
             movingplatform4 = 1;
         }
         if (TheRand == 6)
         {
             if (rand == 2)
             {
                 add = 5;
             }
             if (rand == 3)
             {
                 add = 4;
             }
             if (rand1 == 0)
             {
                 add1 = 8;
             }
             if (rand1 == 1)
             {
                 add1 = 7;
             }
             if (rand2 == 4)
             {
                 add2 = 7;
             }
             if (rand2 == 5)
             {
                 add2 = 7;
             }
             usedPlatform[16] = platforms[rand];
             usedPlatform[17] = platforms[rand1];
             usedPlatform[18] = platforms[rand2];
             chosenPlatforms = TheRand;
             movingplatform5 = 1;
         }*/

        varattu = true;
        spawn = true;
        
        
    }
    // Update is called once per frame
    
    
    void Update()
    {
        
        CheckCollision();
        
             
           

       
        movePlatforms();
       
        iscolliding = false;
       // destroyPlatforms();
       

    }

    void CheckCollision()
    {

        for(int i = 0; i <usedPlatform.Length; i++)
        {
            
                if (usedPlatform[i] != null && i < 13 && i != 0)
                {
                    if (i < 4 && i > 0)
                    {
                        if (usedPlatform[3].GetComponent<SpriteRenderer>().sprite.rect.xMax < Cam.pixelRect.xMax)
                        {
                            instatePlatforms(Random.Range(1, 5), Random.Range(2, 4), Random.Range(0, 2), Random.Range(4, 6));

                        }
                    }
                    if (i < 7 && i> 3)
                    {
                        if (usedPlatform[6].GetComponent<SpriteRenderer>().sprite.rect.xMax < Cam.pixelRect.xMax)
                        {
                            instatePlatforms(Random.Range(1, 5), Random.Range(2, 4), Random.Range(0, 2), Random.Range(4, 6));
                        }
                    }
                    if (i< 10 && i > 6)
                    {
                        if (usedPlatform[9].GetComponent<SpriteRenderer>().sprite.rect.xMax < Cam.pixelRect.xMax)
                        {
                            instatePlatforms(Random.Range(1, 5), Random.Range(2, 4), Random.Range(0, 2), Random.Range(4, 6));
                        }
                    }
                    if (i < 13 && i > 9)
                    {
                        if (usedPlatform[12].GetComponent<SpriteRenderer>().sprite.rect.xMax < Cam.pixelRect.xMax)
                        {
                            instatePlatforms(Random.Range(1, 5), Random.Range(2, 4), Random.Range(0, 2), Random.Range(4, 6));
                        }
                    }
                }
                
                

            }
        bool Allmet = true;
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
            instatePlatforms(Random.Range(1, 5), Random.Range(2, 4), Random.Range(0, 2), Random.Range(4, 6));
        }


    }
       
  
  
    void movePlatforms()
    {
        /*
        platforms[0].transform.position = new Vector3(platforms[0].transform.position.x - moveSpeed, platforms[0].transform.position.y, platforms[0].transform.position.z);
        platforms[1].transform.position = new Vector3(platforms[1].transform.position.x - moveSpeed, platforms[1].transform.position.y, platforms[1].transform.position.z);
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
        if (movingplatform == 1)
        {
            usedPlatform[1].transform.position = new Vector3(usedPlatform[1].transform.position.x - moveSpeed, usedPlatform[1].transform.position.y, usedPlatform[1].transform.position.z);
            usedPlatform[2].transform.position = new Vector3(usedPlatform[2].transform.position.x - moveSpeed, usedPlatform[2].transform.position.y, usedPlatform[2].transform.position.z);
            usedPlatform[3].transform.position = new Vector3(usedPlatform[3].transform.position.x - moveSpeed, usedPlatform[3].transform.position.y, usedPlatform[3].transform.position.z);
            /* for (int i = 1; i < 4; i++)
             {
                 if (usedPlatform[i].transform.position.x + 15 < Cam.rect.xMin)
                 {
                     Debug.Log("Tänne päästiin");
                     //usedPlatform[i].transform.position = new Vector3(StartingPoint, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                     Destroy(usedPlatform[i]);

                 }*/
            if (usedPlatform[3].transform.position.x + 2.5 < Cam.transform.position.x - 10)
            {
                
                Destroy(usedPlatform[1].gameObject);
                Destroy(usedPlatform[2].gameObject);
                Destroy(usedPlatform[3].gameObject);
                movingplatform = 0;
            }
        //}


        }
        if ( movingplatform1 == 1)
        {
            usedPlatform[4].transform.position = new Vector3(usedPlatform[4].transform.position.x - moveSpeed, usedPlatform[4].transform.position.y, usedPlatform[4].transform.position.z);
            usedPlatform[5].transform.position = new Vector3(usedPlatform[5].transform.position.x - moveSpeed, usedPlatform[5].transform.position.y, usedPlatform[5].transform.position.z);
            usedPlatform[6].transform.position = new Vector3(usedPlatform[6].transform.position.x - moveSpeed, usedPlatform[6].transform.position.y, usedPlatform[6].transform.position.z);
          /*  for (int i = 4; i < 7; i++)
            {
                if (usedPlatform[i].transform.position.x + 15 < Cam.rect.xMin)
                {
                    // usedPlatform[i].transform.position = new Vector3(StartingPoint, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                    Destroy(usedPlatform[i]);
                }*/
                if (usedPlatform[6].transform.position.x + 2.5 < Cam.transform.position.x - 10)
                {
                

                Destroy(usedPlatform[4]);
                    Destroy(usedPlatform[5]);
                    Destroy(usedPlatform[6]);
                    Debug.Log("Moving Platform päästiin.");
                    movingplatform1 = 0;
                }
            //}
        }
        if ( movingplatform2 == 1)
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
                }*/
                if (usedPlatform[9].transform.position.x + 2.5 < Cam.transform.position.x - 10)
                {

              

                Destroy(usedPlatform[7].gameObject);
                    Destroy(usedPlatform[8].gameObject);
                    Destroy(usedPlatform[9].gameObject);
                    movingplatform2 = 0;
                }
            //}
        }
        if ( movingplatform3 == 1)
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
                }*/
                if (usedPlatform[12].transform.position.x + 2.5 < Cam.transform.position.x - 10)
                {
                

               

                Destroy(usedPlatform[10].gameObject);
                    Destroy(usedPlatform[11].gameObject);
                    Destroy(usedPlatform[12].gameObject);
                    movingplatform3 = 0;
                }
            //}
        }
        if ( movingplatform4 ==1)
        {
            usedPlatform[13].transform.position = new Vector3(usedPlatform[13].transform.position.x - moveSpeed, usedPlatform[13].transform.position.y, usedPlatform[13].transform.position.z);
            usedPlatform[14].transform.position = new Vector3(usedPlatform[14].transform.position.x - moveSpeed, usedPlatform[14].transform.position.y, usedPlatform[14].transform.position.z);
            usedPlatform[15].transform.position = new Vector3(usedPlatform[15].transform.position.x - moveSpeed, usedPlatform[15].transform.position.y, usedPlatform[15].transform.position.z);
            /*for (int i = 13; i < 16; i++)
            {
                if (usedPlatform[i].transform.position.x + 15 < Cam.rect.xMin)
                {
                    // usedPlatform[i].transform.position = new Vector3(StartingPoint, usedPlatform[i].transform.position.y, usedPlatform[i].transform.position.z);
                    Destroy(usedPlatform[i]);
                }*/
            if (usedPlatform[15].transform.position.x + 2.5 < Cam.transform.position.x - 10)
            {
                Destroy(usedPlatform[13].gameObject);
                Destroy(usedPlatform[14].gameObject);
                Destroy(usedPlatform[15].gameObject);
                movingplatform4 = 0;
                }

            //}
        }
        if ( movingplatform5 ==1)
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
                }*/
            if (usedPlatform[18].transform.position.x + 2.5 < Cam.transform.position.x - 10)
            {
                Destroy(usedPlatform[16].gameObject);
                Destroy(usedPlatform[17].gameObject);
                Destroy(usedPlatform[18].gameObject);
                
                movingplatform5 = 0;
                
            }
        }

      

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

        if (usedPlatform[10] != null && usedPlatform[11] != null && usedPlatform[12] != null)
        {
            fostplatform[0] = usedPlatform[10];
            fostplatform[1] = usedPlatform[11];
            fostplatform[2] = usedPlatform[12];
            return fostplatform;

        }
        return null;
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
