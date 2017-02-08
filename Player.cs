using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public UI_Operations opertaions;
    public GameObject player;
    public GameObject Highscore;
    public float fallspeed;
    public float jumpheight;
    Collider2D colli;
    bool jump = false;
    bool falling = true;
    public Camera maincamera;
    CircleCollider2D hitTrigger;
    public GameObject Level;
    GameObject[] platforms;
    Ray[] PlayerRays;
    Collectables[] collectablet;
    bool[] hitted;
    Touch TheTouach;
    Vector2[] points = new Vector2[6];
    RaycastHit2D[] hits;


    // Use this for initialization
    void Start () {
        PlayerRays = new Ray[6];
        hits = new RaycastHit2D[6];
        hitted = new bool[6];
        
        
        platforms = new GameObject[Level.GetComponent<Platforms>().getPlatforms(false).Length];
        platforms = Level.GetComponent<Platforms>().getPlatforms(false);
        colli = player.GetComponent<BoxCollider2D>();
        hitTrigger = player.GetComponent<CircleCollider2D>();
        player.GetComponent<Rigidbody2D>().freezeRotation = true;
        player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;


	}
	
	// Update is called once per frame

	void Update ()
    {
        platforms = Level.GetComponent<Platforms>().getPlatforms(true);

        if ((player.transform.position.x > maincamera.rect.xMax || player.transform.position.x < maincamera.rect.xMin - 10 || player.transform.position.y < -maincamera.rect.yMax - 10))
        {
            player.transform.position = new Vector3(maincamera.rect.center.x, maincamera.rect.center.y, player.transform.position.z);
        }
        Hitrays();
        keepcolliding();

        if(falling == false)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.GetComponent<Rigidbody2D>().mass = 0;
        }
        else
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            
            player.GetComponent<Rigidbody2D>().mass = 10;
        }

        
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clikattiin");
           
            if ( falling == false)
            {
                
                jump = true;

            }
        }
#elif UNITY_ANDROID

        if (Input.touchCount > 0)
        {
            
            
            Debug.Log("Touch");
             TheTouach = Input.touches[0];
            if (TheTouach.phase == TouchPhase.Began && TheTouach.position.y < maincamera.pixelRect.yMax - 100 && falling == false)
            {
                
                jump = true;

            }
        }
#endif
        if (jump == true)
        {
            for (float i = 0; i < jumpheight; i = i + 1f)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpheight);
            }
            jump = false;
            falling = true;
        }
       
       
    }
    void FixedUpdate()
    {
       
        /*
        if (falling == true)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            player.GetComponent<Rigidbody2D>().mass = 20;
        }
        if (falling == false)
        {
            player.GetComponent<Rigidbody2D>().mass = 0;
        }
        if (Input.GetButtonDown("Jump") && falling == false)
        {
            if (falling == false)
            {
                jump = true;
            }


        }
        */
    }
    void Checkcollision()
    {
        if (platforms != null)
        {
            for (int i = 0; i < platforms.Length; i++)
            {

                if (platforms[i] != null && player.GetComponent<CircleCollider2D>().IsTouching(platforms[i].GetComponent<BoxCollider2D>()))
                {
                    if (Input.GetButtonDown("Jump") && falling == false)
                    {
                        if (falling == false)
                        {
                            jump = true;
                        }


                    }
                }
            }
        }
    }
    void keepcolliding()
    {
        if(hitted[0] == true)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (hitted[1] == true || hitted[2] == true)
        {
            


            falling = false;
            Debug.Log("Not Falling");

        }
        else
        {
            falling = true;
        }
        
        if (hitted[3] == true)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (hitted[4] == true)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y);
        }
        if (hitted[5] == true)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(-player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y);
        }
    }
    void Hitrays()
    {
       

        PlayerRays[0].origin = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y,0);
        PlayerRays[1].origin = new Vector3(player.transform.position.x + player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x - 0.5f, player.transform.position.y ,0);
        PlayerRays[2].origin = new Vector3(player.transform.position.x - player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x + 0.5f, player.transform.position.y ,0);
        PlayerRays[3].origin = new Vector3(player.transform.position.x + 0.2f, player.transform.position.y,0);
        PlayerRays[4].origin = new Vector3(player.transform.position.x + 0.2f, player.transform.position.y - player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y + 0.3f,0);
        PlayerRays[5].origin = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y - player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y + 0.3f,0);

        PlayerRays[0].direction = new Vector3(1, 0,0);
        PlayerRays[1].direction = new Vector3(0, -1,0);
        PlayerRays[2].direction = new Vector3(0, -1,0);
        PlayerRays[3].direction = new Vector3(-1, 0,0);
        PlayerRays[4].direction = new Vector3(-1, 0,0);
        PlayerRays[5].direction = new Vector3(1, 0,0);

       

        hits[0] = Physics2D.Raycast(PlayerRays[0].origin,PlayerRays[0].direction, player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x);
        hits[1] = Physics2D.Raycast(PlayerRays[1].origin,PlayerRays[1].direction, player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y);
        hits[2] = Physics2D.Raycast(PlayerRays[2].origin,PlayerRays[2].direction, player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y);
        hits[3] = Physics2D.Raycast(PlayerRays[3].origin,PlayerRays[3].direction, player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x );
        hits[4] = Physics2D.Raycast(PlayerRays[4].origin,PlayerRays[4].direction, player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x);
        hits[5] = Physics2D.Raycast(PlayerRays[5].origin, PlayerRays[5].direction, player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x );

        Debug.DrawRay(PlayerRays[0].origin, PlayerRays[0].direction * player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x, Color.red);  
        Debug.DrawRay(PlayerRays[1].origin, PlayerRays[1].direction * player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y, Color.blue);
        Debug.DrawRay(PlayerRays[2].origin, PlayerRays[2].direction * player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y, Color.blue);
        Debug.DrawRay(PlayerRays[3].origin, PlayerRays[3].direction * player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x, Color.red);
        Debug.DrawRay(PlayerRays[4].origin, PlayerRays[4].direction * player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x, Color.red);
        Debug.DrawRay(PlayerRays[5].origin, PlayerRays[5].direction * player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x, Color.red);

        /* points[0] = PlayerRays[0].GetPoint(player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x);
         points[1] = PlayerRays[1].GetPoint(-player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y);
         points[2] = PlayerRays[2].GetPoint(-player.GetComponent<SpriteRenderer>().sprite.bounds.extents.y);
         points[3] = PlayerRays[3].GetPoint(-player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x);
         points[4] = PlayerRays[4].GetPoint(-player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x);
         points[5] = PlayerRays[5].GetPoint(player.GetComponent<SpriteRenderer>().sprite.bounds.extents.x);*/

        for (int i = 0; i <platforms.Length;i++)
        {
            
          if(platforms[i] != null)
         {
                
                    
                        if (i == 4 && Level.GetComponent<Platforms>().getNeljaPlatform() == true)
                        {
                            if (platforms[i].GetComponent<BoxCollider2D>() == hits[0].collider && player.GetComponent<Rigidbody2D>().velocity.x > 0)
                            {
                                hitted[0] = true;
                            }
                            else
                            {
                                 hitted[0] = false;
                            }
                    
                            if (platforms[i].GetComponent<BoxCollider2D>() == hits[1].collider && player.GetComponent<Rigidbody2D>().velocity.y < 0 )
                            {
                                 hitted[1] = true;
                        Debug.Log("maahan osui");
                        break;
                            }
                            else
                            {
                                 hitted[1] = false;
                             }
                          
                            if (platforms[i].GetComponent<BoxCollider2D>() == hits[2].collider && player.GetComponent<Rigidbody2D>().velocity.y < 0)
                            {
                                hitted[2] = true;
                        Debug.Log("maahan osui");
                        break;
                    }
                            else 
                            {
                                 hitted[2] = false;
                             }
                            
                            if (platforms[i].GetComponent<BoxCollider2D>() == hits[3].collider && player.GetComponent<Rigidbody2D>().velocity.x < 0)
                            {
                                hitted[3] = true;
                            }
                            else
                            {
                                hitted[3] = false;
                            }
                            if (platforms[i].GetComponent<BoxCollider2D>() == hits[4].collider && player.GetComponent<Rigidbody2D>().velocity.x < 0)
                            {
                                 hitted[4] = true;
                              }
                              else
                              {
                                  hitted[4] = false;
                              }
                              if (platforms[i].GetComponent<BoxCollider2D>() == hits[5].collider && player.GetComponent<Rigidbody2D>().velocity.x > 0)
                                      {
                                  hitted[5] = true;
                              }
                              else
                              {
                                  hitted[5] = false;
                              }
                }
                        if ((i == 4 && Level.GetComponent<Platforms>().getNeljaPlatform() == false) || i == 6 || i == 10)
                        {
                            BoxCollider2D[] boxes = new BoxCollider2D[2];
                            boxes = platforms[i].GetComponents<BoxCollider2D>();
                            Debug.Log("Pituus: " + boxes.Length);

                            if (boxes.Length > 1 && boxes[0] == hits[0].collider && player.GetComponent<Rigidbody2D>().velocity.x > 0 || boxes.Length > 1 && boxes[1] == hits[0].collider && player.GetComponent<Rigidbody2D>().velocity.x > 0)
                            {
                                 hitted[0] = true;
                            }
                            else
                            {
                                hitted[0] = false;
                            }
                            if (boxes.Length > 1 && boxes[0] == hits[1].collider && player.GetComponent<Rigidbody2D>().velocity.y < 0 && falling == true || boxes.Length > 1 && boxes[1] == hits[1].collider && player.GetComponent<Rigidbody2D>().velocity.y < 0 && falling == true)
                            {
                                hitted[1] = true;
                        break;
                            }
                            else
                            {
                                hitted[1] = false;
                            }
                            if (boxes.Length > 1 && boxes[0] == hits[2].collider && player.GetComponent<Rigidbody2D>().velocity.y < 0 && falling == true || boxes.Length > 1 && boxes[1] == hits[2].collider && player.GetComponent<Rigidbody2D>().velocity.y < 0 && falling == true)
                            {
                                hitted[2] = true;
                        break;
                            }
                            else
                            {
                                hitted[2] = false;
                            }

                            if (boxes.Length > 1 && boxes[0] == hits[3].collider && player.GetComponent<Rigidbody2D>().velocity.x < 0 || boxes.Length > 1 && boxes[1] == hits[3].collider && player.GetComponent<Rigidbody2D>().velocity.x < 0)
                           {
                                hitted[3] = true;
                            }
                            else
                            {
                                hitted[3] = false;
                            }
                            if (boxes.Length > 1 && boxes[0] == hits[4].collider && player.GetComponent<Rigidbody2D>().velocity.x < 0 || boxes.Length > 1 && boxes[1] == hits[4].collider && player.GetComponent<Rigidbody2D>().velocity.x < 0)
                            {
                                hitted[4] = true;
                            }
                            else
                            {
                                hitted[4] = false;
                            }
                            if (boxes.Length > 1 && boxes[0] == hits[5].collider && player.GetComponent<Rigidbody2D>().velocity.x > 0 || boxes.Length > 1 && boxes[1] == hits[5].collider && player.GetComponent<Rigidbody2D>().velocity.x > 0)
                            {
                                hitted[5] = true;
                            }
                            else
                            {
                                hitted[5] = false;
                            }
                }
                        else
                        {
                            Debug.Log("Törmättiin");
                             if (platforms[i].GetComponent<BoxCollider2D>() == hits[0].collider && player.GetComponent<Rigidbody2D>().velocity.x > 0)
                             {
                                 hitted[0] = true;
                             }
                             else
                             {
                                 hitted[0] = true;
                             }
                             if (platforms[i].GetComponent<BoxCollider2D>() == hits[1].collider && player.GetComponent<Rigidbody2D>().velocity.y < 0)
                             {
                                 hitted[1] = true;
                        Debug.Log("Maahan osui");
                        break;
                             }
                             else
                             {
                                 hitted[1] = false;
                             }

                             if (platforms[i].GetComponent<BoxCollider2D>() == hits[2].collider && player.GetComponent<Rigidbody2D>().velocity.y < 0)
                             {
                                 hitted[2] = true;
                        Debug.Log("Maahan osui");
                        break;
                             }
                             else
                             {
                                 hitted[2] = false;
                             }

                             if (platforms[i].GetComponent<BoxCollider2D>() == hits[3].collider && player.GetComponent<Rigidbody2D>().velocity.x < 0)
                             {
                                 hitted[3] = true;
                             }
                             else
                             {
                                 hitted[3] = false;
                             }
                             if (platforms[i].GetComponent<BoxCollider2D>() == hits[4].collider && player.GetComponent<Rigidbody2D>().velocity.x < 0)
                             {
                                 hitted[4] = true;
                             }
                             else
                             {
                                 hitted[4] = false;
                             }
                             if (platforms[i].GetComponent<BoxCollider2D>() == hits[5].collider && player.GetComponent<Rigidbody2D>().velocity.x > 0)
                             {
                                 hitted[5] = true;
                             }
                             else
                             {
                                 hitted[5] = false;
                             }
                }
                       
                
           }
        }
        

    }
    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            falling = false;

            if (Input.GetButtonDown("Jump"))
            {
                if (falling == false)
                {
                    jump = true;
                }


            }
        }
       
    }
    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Platform")
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (falling == false)
                {
                    jump = true;
                }


            }
            
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
            falling = true;
        }
    }
    */
    
}
