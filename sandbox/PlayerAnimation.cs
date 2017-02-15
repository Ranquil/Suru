using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
    Animator anim;
    GameObject playerObject;
    public string playerObjectName = ("Suru"); 
    //public bool jump;
    int runStateHash = Animator.StringToHash("Base Layer.Run");
    public float speed = 2;
    
    //bools are here until they are given functionality at Player.cs. I just don't want too many error notifications everywhere.
    bool isMoving = true;
    bool isDead = false;
    bool isLedge = false;
    Player playerScript;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        //playerObject links to our main character. playerScript references the Player script to access variables in there.
        playerObject = GameObject.Find(playerObjectName);
        playerScript = playerObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        //AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(isDead)
        {
            //all other bools but isDead are disabled to prevent weird behavior.
            anim.SetBool("isJumping", false);
            anim.SetBool("isMoving", false);
            anim.SetBool("isLedge", false);
            anim.SetBool("isMidAir", false);
            anim.SetBool("isDead", true);
        }
        if(gameObject.GetComponent<Player>().falling == false)
        {
            Debug.Log("A jump animation should be triggered?");
            anim.SetBool("isJumping", true);
            anim.SetBool("isMoving", false);
        }
        if (gameObject.GetComponent<Player>().falling == true)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isMoving", true);
            Debug.Log("Jump animation should end?");
        }
        /*if(isMoving)
        {
            anim.SetBool("isMoving", true);
        }
        if(!isMoving)
        {
            anim.SetBool("isMoving", false);
        }*/
        if(isLedge)
        {
            anim.SetBool("isLedge", true);
        }
        if(!isLedge)
        {
            anim.SetBool("isLedge", false);
        }
        if(playerScript.falling)
        {
            anim.SetBool("isMidAir", true);
            anim.SetBool("isMoving", false);
        }
        if(!playerScript.falling)
        {
            anim.SetBool("isMidAir", false);
            anim.SetBool("isMoving", true);
        }
	}
}
