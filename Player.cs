using UnityEngine;
using System.Collections;

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
	// Use this for initialization
	void Start () {
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
        
        Checkcollision();
        if (Input.GetButtonDown("Jump") && falling == false)
        {
          
                jump = true;
            
        }

    }
    void FixedUpdate()
    {
        platforms = Level.GetComponent<Platforms>().getPlatforms(false);
        if ((player.transform.position.x > maincamera.rect.xMax || player.transform.position.x < maincamera.rect.xMin - 10 || player.transform.position.y < -maincamera.rect.yMax - 10))
        {
            player.transform.position = new Vector3(maincamera.rect.center.x, maincamera.rect.center.y, player.transform.position.z);
        }
        
        if (falling == true)
        {
            player.GetComponent<Rigidbody2D>().mass = 10;
        }
       
        else if (falling == false)
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
        if (jump == true)
        {
            for (float i = 0; i < jumpheight; i = i + 1f)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpheight);
            }
            jump = false;
        }
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
    
    
}
