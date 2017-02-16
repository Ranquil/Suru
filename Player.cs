using UnityEngine;
using System.Collections;
        //This script works and it's readable! It's made by another programmer though. ":D" However, you can rewrite it if you want to.
public class Player : MonoBehaviour {

    public GameObject player;
    public GameObject Highscore;
    public float fallspeed;
    public float jumpheight;
    Collider2D col;
    public bool jump = true;
    public bool falling = true;
    public Camera maincamera;
    public GameObject collisioner;
	// Use this for initialization
	void Start () {
        //colli = player.GetComponent<BoxCollider2D>();
        collisioner = player.transform.Find("Collider").gameObject;
        if (collisioner != null) Debug.Log("We found the collider, Sir!");
        else Debug.LogError("We haven't found jack shit, Sir!");
        col = collisioner.GetComponent<BoxCollider2D>();
        player.GetComponent<Rigidbody2D>().freezeRotation = true;
        falling = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
       /* if (jump == true)
        {
            for (float i = 0; i < jumpheight; i = i + 1f)
            {
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpheight);
            }
            jump = false;
        }*/
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
                //Debug.Log("Lift off!");
            }
            //else Debug.Log("Dafuq are you jumping in the air?");

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
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Platform"))
        {
            falling = false;
            //Debug.Log("We're grounded!");
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
