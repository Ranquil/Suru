using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject player;
    public GameObject Highscore;
    public float fallspeed;
    public float jumpheight;

    Collider2D colli;
    bool jump = false;
    bool falling = true;
    public Camera maincamera;
	// Use this for initialization
	void Start () {
        colli = player.GetComponent<BoxCollider2D>();

        player.GetComponent<Rigidbody2D>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        if (jump == true)
        {
            for (float i = 0; i < jumpheight; i = i + 1f)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpheight);
            }
            jump = false;
        }
    }
    void FixedUpdate()
    {
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
        if (Input.GetButtonDown("Jump"))
        {
            if (falling == false)
            {
                jump = true;
            }


        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Platform"))
        {
            falling = false;
        }
        
        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Platform"))
        {
            falling = true;
        }
    }
}
