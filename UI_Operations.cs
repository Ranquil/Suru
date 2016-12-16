using UnityEngine;
using System.Collections;

public class UI_Operations : MonoBehaviour {

    public GameObject[] buttons;
    public GameObject[] Levels;

    bool menuPressed = false;
    bool BackPressed = true;
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
        buttons[1].GetComponent<SpriteRenderer>().sprite = null;
        buttons[2].GetComponent<SpriteRenderer>().sprite = null;
	}
    void OnMouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {

            mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (menuPressed == false)
            {
                

                if (Physics2D.GetRayIntersection(mouseRay, 100f) == Buttons_box[0])
                {
                    Debug.Log("painoit Start nappia");

                    Levels[0].GetComponent<MoveLevel>().enabled = true;
                    Levels[0].GetComponent<Platforms>().enabled = true;
                    Buttons_box[0].enabled = false;
                    buttons[0].GetComponent<SpriteRenderer>().sprite = null;

                    buttons[1].GetComponent<SpriteRenderer>().sprite = Sprites[1];
                    Buttons_box[1].enabled = true;
                    buttons[2].GetComponent<SpriteRenderer>().sprite = Sprites[2];
                    Buttons_box[2].enabled = true;
                    menuPressed = true;
                    BackPressed = false;
                }
            }
            if(BackPressed == false)
            {
               

                if (Physics2D.GetRayIntersection(mouseRay, 100f) == Buttons_box[1])
                {
                    
                    buttons[1].GetComponent<SpriteRenderer>().sprite = null;
                    Buttons_box[1].enabled = false;


                    buttons[0].GetComponent<SpriteRenderer>().sprite = Sprites[0];
                    Levels[0].GetComponent<MoveLevel>().enabled = false;
                    Levels[0].GetComponent<Platforms>().enabled = false;
                    Buttons_box[0].enabled = true;

                    menuPressed = false;
                    BackPressed = true;
                }
                if(Physics2D.GetRayIntersection(mouseRay, 100f) == Buttons_box[2])
                {
                    buttons[0].GetComponent<SpriteRenderer>().sprite = Sprites[0];
                    Levels[0].GetComponent<MoveLevel>().enabled = false;
                    Levels[0].GetComponent<Platforms>().enabled = false;
                    Buttons_box[0].enabled = true;

                    menuPressed = false;
                    BackPressed = true;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        OnMouseClick();
	}
}
