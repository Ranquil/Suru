using UnityEngine;
using System.Collections;

public class UI_Operations : MonoBehaviour {

    public GameObject[] buttons;
    public GameObject[] Levels;
    public GameObject player;
    public GameObject[] BackGrounds;

    bool PausePressed = true;
    bool BackPressed = true;
    bool OnStart = false;
    Sprite[] Sprites;
    public Camera mainCamera;
    BoxCollider2D[] Buttons_box;
    Ray mouseRay;
    RaycastHit mouseHit;
    // Use this for initialization
    void Start () {


        Sprites = new Sprite[buttons.Length];
        Buttons_box = new BoxCollider2D[buttons.Length];
        
        for (int i = 0; i < buttons.Length; i++)
        {
            Sprites[i] = buttons[i].GetComponent<SpriteRenderer>().sprite;
            Buttons_box[i] = buttons[i].GetComponent<BoxCollider2D>();

        }

        

        buttons[1].GetComponent<SpriteRenderer>().enabled = false;
        buttons[2].GetComponent<SpriteRenderer>().enabled = false;
        buttons[0].GetComponent<SpriteRenderer>().enabled = false;
	}
    void OnStartPressed()
    {
        if (Input.GetMouseButtonUp(0))
        {

            mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            //Onko TapToPlay nappi painettavissa jos false niin on
            if (PausePressed == false)
            {


                if (Physics2D.GetRayIntersection(mouseRay, 100f).collider == Buttons_box[0])
                {
                    Debug.Log("painoit Start nappia");

                    Levels[0].GetComponent<MoveLevel>().enabled = true;
                    Levels[0].GetComponent<Platforms>().enabled = true;
                    Levels[0].GetComponent<Collectables>().enabled = true;

                    player.GetComponent<SpriteRenderer>().enabled = true;
                    player.GetComponent<BoxCollider2D>().enabled = true;
                    player.GetComponent<CircleCollider2D>().enabled = true;
                    player.GetComponent<Player>().enabled = true;

                    Buttons_box[0].enabled = false;
                    buttons[0].GetComponent<SpriteRenderer>().enabled = false;

                    buttons[1].GetComponent<SpriteRenderer>().enabled = true;
                    Buttons_box[1].enabled = true;
                    buttons[2].GetComponent<SpriteRenderer>().enabled = true;
                    Buttons_box[2].enabled = true;
                    PausePressed = true;
                    BackPressed = false;
                }
            }
            //Onko Back nappi painettavissa jos false niin on
            if (BackPressed == false)
            {


                if (Physics2D.GetRayIntersection(mouseRay, 100f).collider == Buttons_box[1])
                {

                    buttons[1].GetComponent<SpriteRenderer>().enabled = false;
                    Buttons_box[1].enabled = false;
                    buttons[2].GetComponent<SpriteRenderer>().enabled = false;
                    Buttons_box[2].enabled = false;


                    buttons[0].GetComponent<SpriteRenderer>().enabled = true;
                    Levels[0].GetComponent<MoveLevel>().enabled = false;
                    Levels[0].GetComponent<Platforms>().enabled = false;
                    Levels[0].GetComponent<Collectables>().enabled = false;
                    Buttons_box[0].enabled = true;

                    PausePressed = false;
                    BackPressed = true;
                }
                if (Physics2D.GetRayIntersection(mouseRay, 100f).collider == Buttons_box[2])
                {
                    buttons[1].GetComponent<SpriteRenderer>().enabled = false;
                    Buttons_box[1].enabled = false;
                    buttons[2].GetComponent<SpriteRenderer>().enabled = false;
                    Buttons_box[2].enabled = false;

                    buttons[0].GetComponent<SpriteRenderer>().enabled = true;
                    Levels[0].GetComponent<MoveLevel>().enabled = false;
                    Levels[0].GetComponent<Platforms>().enabled = false;
                    Levels[0].GetComponent<Collectables>().enabled = false;

                    player.GetComponent<Player>().enabled = false;
                    Buttons_box[0].enabled = true;

                    Debug.Break();
                    Application.Quit();



                }

            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {

            mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics2D.GetRayIntersection(mouseRay, 100f).collider == Buttons_box[3])
            {
                Debug.Log("Nappia Painettu");
                Levels[0].GetComponent<MoveLevel>().enabled = true;
                Levels[0].GetComponent<Platforms>().enabled = true;
                Levels[0].GetComponent<Collectables>().enabled = true;

                player.GetComponent<SpriteRenderer>().enabled = true;
                player.GetComponent<BoxCollider2D>().enabled = true;
                player.GetComponent<CircleCollider2D>().enabled = true;
                player.GetComponent<Player>().enabled = true;

                BackGrounds[0].GetComponent<SpriteRenderer>().enabled = false;
                Buttons_box[3].enabled = false;
                Buttons_box[0].enabled = false;
                buttons[3].GetComponent<SpriteRenderer>().enabled = false;
                buttons[0].GetComponent<SpriteRenderer>().enabled = false;

                buttons[1].GetComponent<SpriteRenderer>().enabled = true;
                Buttons_box[1].enabled = true;
                buttons[2].GetComponent<SpriteRenderer>().enabled = true;
                Buttons_box[2].enabled = true;

                OnStart = true;
                BackPressed = false;
            }
            


            if (OnStart == true)
            {
                OnStartPressed();
            }
        }
    }
}
