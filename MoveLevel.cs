using UnityEngine;
using UnityEditor;
using System.Collections;
    //Feel free to rewrite this. Just scroll down and witness the glory...
public class MoveLevel : MonoBehaviour {

    public int timeLimit;
    public GameObject[] planes;
    public GameObject Camera;
    public string LevelName;
    int sizeOfSprites;
    GameObject[] Backrounds;
    public float LevelSpeed;
    public float Layer1ParMultiplier;
    public float Layer2ParMultiplier;
    public float Layer3ParMultiplier;
    public float Layer4ParMultiplier;
    public float Layer5ParMultiplier;
    SpriteRenderer[] planeSpriteR;
    public Sprite[] Planesprite;
    float[] StartPositions;

    Camera mainCamera;
   // [MenuItem("AssetDatabase/loadAllAssetsAtPath")]
    // Use this for initialization
    void Start ()
    {
        sizeOfSprites = Resources.LoadAll<Sprite>("Resources").Length;
        Backrounds = new GameObject[8];
        planeSpriteR = new SpriteRenderer[8];

        for (int i = 0; i < planes.Length; i++)
        {
            Backrounds[i] = Instantiate(planes[i], planes[i].transform.position, Quaternion.identity) as GameObject;
        }
        /*
        Backrounds[0] = Instantiate(planes[0], planes[0].transform.position, Quaternion.identity) as GameObject;
        Backrounds[1] = (GameObject)Instantiate(planes[1], planes[1].transform.position, Quaternion.identity);
        Backrounds[2] = (GameObject)Instantiate(planes[2], planes[2].transform.position, Quaternion.identity);
        Backrounds[3] = (GameObject)Instantiate(planes[3], planes[3].transform.position, Quaternion.identity);
        Backrounds[4] = Instantiate(planes[4], planes[4].transform.position, Quaternion.identity) as GameObject;
        Backrounds[5] = (GameObject)Instantiate(planes[5], planes[5].transform.position, Quaternion.identity);
        Backrounds[6] = (GameObject)Instantiate(planes[6], planes[6].transform.position, Quaternion.identity);
        Backrounds[7] = (GameObject)Instantiate(planes[7], planes[7].transform.position, Quaternion.identity);
        */
         //
        int spriterenderCount = 0;
        Planesprite = new Sprite[sizeOfSprites];

        StartPositions = new float[planes.Length];
        for(int i = 0; i < StartPositions.Length; i++)
        {
            StartPositions[i] = Backrounds[i].transform.position.x;
        }

        foreach (var k in Backrounds)
        {
            

            planeSpriteR[spriterenderCount] = k.GetComponent<SpriteRenderer>();
            spriterenderCount++;

            mainCamera = Camera.GetComponent<Camera>();
            
                Planesprite = Resources.LoadAll<Sprite>("Resources");
                Debug.Log("Lataukseen päästiin");
                 
        }
       

       

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (LevelName != null && LevelName != "")
        {
            moveLevel();
        }
	}

    void moveLevel()
    {

        //Liikutetaan haluttua kenttää ja kun background sprite menee näytön yli se palaa lähtöruutuun.


        switch (LevelName)
        {
            

            case "TallTrees": 
        
            for (int i = 0; i < Backrounds.Length; i++)
            {
                Backrounds[i].transform.Find("New Sprite").position = new Vector3(Backrounds[i].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
                Backrounds[i].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (1)").position.x - LevelSpeed * Layer2ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
                Backrounds[i].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (2)").position.x - LevelSpeed * Layer3ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
                Backrounds[i].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (3)").position.x - LevelSpeed * Layer4ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
            }

            if ((Backrounds[0].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {


                Backrounds[0].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[0].transform.Find("New Sprite").position.y,
                    Backrounds[0].transform.Find("New Sprite").position.z);
            }

            if ((Backrounds[0].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[0].transform.Find("New Sprite (1)").position = new Vector3(
                    StartPositions[7], //+ Backrounds[0].transform.Find("New Sprite (1)").position.x * -1,
                    Backrounds[0].transform.Find("New Sprite (1)").position.y,
                    Backrounds[0].transform.Find("New Sprite (1)").position.z);
            }

            if ((Backrounds[0].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[0].transform.Find("New Sprite (2)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[0].transform.Find("New Sprite (2)").position.y,
                    Backrounds[0].transform.Find("New Sprite (2)").position.z);
            }
            if ((Backrounds[0].transform.Find("New Sprite (3)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[0].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[0].transform.Find("New Sprite (3)").position.y,
                    Backrounds[0].transform.Find("New Sprite (3)").position.z);
            }


            if ((Backrounds[1].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[1].transform.Find("New Sprite").position = new Vector3(
                     StartPositions[7],
                     Backrounds[1].transform.Find("New Sprite").position.y,
                     Backrounds[1].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[1].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[1].transform.Find("New Sprite (1)").position = new Vector3(
                StartPositions[7],
                Backrounds[1].transform.Find("New Sprite (1)").position.y,
                Backrounds[1].transform.Find("New Sprite (1)").position.z);
            }

            if ((Backrounds[1].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[1].transform.Find("New Sprite (2)").position = new Vector3(
                StartPositions[7],
                Backrounds[1].transform.Find("New Sprite (2)").position.y,
                Backrounds[1].transform.Find("New Sprite (2)").position.z);
            }
            if ((Backrounds[1].transform.Find("New Sprite (3)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[1].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[1].transform.Find("New Sprite (3)").position.y,
                    Backrounds[1].transform.Find("New Sprite (3)").position.z);
            }
            if ((Backrounds[2].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[2].transform.Find("New Sprite").position = new Vector3(
                     StartPositions[7],
                    Backrounds[2].transform.Find("New Sprite").position.y,
                    Backrounds[2].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[2].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[2].transform.Find("New Sprite (1)").position = new Vector3(
                 StartPositions[7],
                Backrounds[2].transform.Find("New Sprite (1)").position.y,
                Backrounds[2].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[2].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[2].transform.Find("New Sprite (2)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[2].transform.Find("New Sprite (2)").position.y,
                    Backrounds[2].transform.Find("New Sprite (2)").position.z);
            }
            if ((Backrounds[2].transform.Find("New Sprite (3)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[2].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[2].transform.Find("New Sprite (3)").position.y,
                    Backrounds[2].transform.Find("New Sprite (3)").position.z);
            }
            if ((Backrounds[3].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[3].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[3].transform.Find("New Sprite").position.y,
                    Backrounds[3].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[3].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[3].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[3].transform.Find("New Sprite (1)").position.y,
                        Backrounds[3].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[3].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[3].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[3].transform.Find("New Sprite (2)").position.y,
                        Backrounds[3].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[3].transform.Find("New Sprite (3)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[3].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[3].transform.Find("New Sprite (3)").position.y,
                    Backrounds[3].transform.Find("New Sprite (3)").position.z);
            }
            if ((Backrounds[4].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[4].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[4].transform.Find("New Sprite").position.y,
                    Backrounds[4].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[4].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[4].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[4].transform.Find("New Sprite (1)").position.y,
                        Backrounds[4].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[4].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[4].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[4].transform.Find("New Sprite (2)").position.y,
                        Backrounds[4].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[4].transform.Find("New Sprite (3)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[4].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[4].transform.Find("New Sprite (3)").position.y,
                    Backrounds[4].transform.Find("New Sprite (3)").position.z);
            }
            if ((Backrounds[5].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[5].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[5].transform.Find("New Sprite").position.y,
                    Backrounds[5].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[5].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[5].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[5].transform.Find("New Sprite (1)").position.y,
                        Backrounds[5].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[5].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[5].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[5].transform.Find("New Sprite (2)").position.y,
                        Backrounds[5].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[5].transform.Find("New Sprite (3)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[5].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[5].transform.Find("New Sprite (3)").position.y,
                    Backrounds[5].transform.Find("New Sprite (3)").position.z);
            }
            if ((Backrounds[6].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[6].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[6].transform.Find("New Sprite").position.y,
                    Backrounds[6].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[6].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[6].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[6].transform.Find("New Sprite (1)").position.y,
                        Backrounds[6].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[6].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[6].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[6].transform.Find("New Sprite (2)").position.y,
                        Backrounds[6].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[6].transform.Find("New Sprite (3)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[6].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[6].transform.Find("New Sprite (3)").position.y,
                    Backrounds[6].transform.Find("New Sprite (3)").position.z);
            }
            if ((Backrounds[7].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[7].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[7].transform.Find("New Sprite").position.y,
                    Backrounds[7].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[7].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[7].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[7].transform.Find("New Sprite (1)").position.y,
                        Backrounds[7].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[7].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[7].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[7].transform.Find("New Sprite (2)").position.y,
                        Backrounds[7].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[7].transform.Find("New Sprite (3)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[7].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[7].transform.Find("New Sprite (3)").position.y,
                    Backrounds[7].transform.Find("New Sprite (3)").position.z);
            }
                break;

            case "Desert":
        
            for (int i = 0; i < Backrounds.Length; i++)
            {
                Backrounds[i].transform.Find("New Sprite").position = new Vector3(Backrounds[i].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
                Backrounds[i].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (1)").position.x - LevelSpeed * Layer2ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
                Backrounds[i].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (2)").position.x - LevelSpeed * Layer3ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
                Backrounds[i].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (3)").position.x - LevelSpeed * Layer4ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
                Backrounds[i].transform.Find("New Sprite (4)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (4)").position.x - LevelSpeed * Layer5ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
                }
            if ((Backrounds[0].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {


                Backrounds[0].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[0].transform.Find("New Sprite").position.y,
                    Backrounds[0].transform.Find("New Sprite").position.z);
            }

            if ((Backrounds[0].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[0].transform.Find("New Sprite (1)").position = new Vector3(
                    StartPositions[7], //+ Backrounds[0].transform.Find("New Sprite (1)").position.x * -1,
                    Backrounds[0].transform.Find("New Sprite (1)").position.y,
                    Backrounds[0].transform.Find("New Sprite (1)").position.z);
            }

            if ((Backrounds[0].transform.Find("New Sprite (2)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[0].transform.Find("New Sprite (2)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[0].transform.Find("New Sprite (2)").position.y,
                    Backrounds[0].transform.Find("New Sprite (2)").position.z);
            }
            if ((Backrounds[0].transform.Find("New Sprite (3)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[0].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[0].transform.Find("New Sprite (3)").position.y,
                    Backrounds[0].transform.Find("New Sprite (3)").position.z);
            }
                if ((Backrounds[0].transform.Find("New Sprite (4)").position.x + 40) < mainCamera.rect.xMin)
                {
                    Backrounds[0].transform.Find("New Sprite (4)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[0].transform.Find("New Sprite (4)").position.y,
                        Backrounds[0].transform.Find("New Sprite (4)").position.z);
                }

                if ((Backrounds[1].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[1].transform.Find("New Sprite").position = new Vector3(
                     StartPositions[7],
                     Backrounds[1].transform.Find("New Sprite").position.y,
                     Backrounds[1].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[1].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[1].transform.Find("New Sprite (1)").position = new Vector3(
                StartPositions[7],
                Backrounds[1].transform.Find("New Sprite (1)").position.y,
                Backrounds[1].transform.Find("New Sprite (1)").position.z);
            }

            if ((Backrounds[1].transform.Find("New Sprite (2)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[1].transform.Find("New Sprite (2)").position = new Vector3(
                StartPositions[7],
                Backrounds[1].transform.Find("New Sprite (2)").position.y,
                Backrounds[1].transform.Find("New Sprite (2)").position.z);
            }
            if ((Backrounds[1].transform.Find("New Sprite (3)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[1].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[1].transform.Find("New Sprite (3)").position.y,
                    Backrounds[1].transform.Find("New Sprite (3)").position.z);
            }
                if ((Backrounds[1].transform.Find("New Sprite (4)").position.x + 40) < mainCamera.rect.xMin)
                {
                    Backrounds[1].transform.Find("New Sprite (4)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[1].transform.Find("New Sprite (4)").position.y,
                        Backrounds[1].transform.Find("New Sprite (4)").position.z);
                }
                if ((Backrounds[2].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[2].transform.Find("New Sprite").position = new Vector3(
                     StartPositions[7],
                    Backrounds[2].transform.Find("New Sprite").position.y,
                    Backrounds[2].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[2].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[2].transform.Find("New Sprite (1)").position = new Vector3(
                 StartPositions[7],
                Backrounds[2].transform.Find("New Sprite (1)").position.y,
                Backrounds[2].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[2].transform.Find("New Sprite (2)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[2].transform.Find("New Sprite (2)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[2].transform.Find("New Sprite (2)").position.y,
                    Backrounds[2].transform.Find("New Sprite (2)").position.z);
            }
            if ((Backrounds[2].transform.Find("New Sprite (3)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[2].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[2].transform.Find("New Sprite (3)").position.y,
                    Backrounds[2].transform.Find("New Sprite (3)").position.z);
            }
                if ((Backrounds[2].transform.Find("New Sprite (4)").position.x + 40) < mainCamera.rect.xMin)
                {
                    Backrounds[2].transform.Find("New Sprite (4)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[2].transform.Find("New Sprite (4)").position.y,
                        Backrounds[2].transform.Find("New Sprite (4)").position.z);
                }
                if ((Backrounds[3].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[3].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[3].transform.Find("New Sprite").position.y,
                    Backrounds[3].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[3].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[3].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[3].transform.Find("New Sprite (1)").position.y,
                        Backrounds[3].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[3].transform.Find("New Sprite (2)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[3].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[3].transform.Find("New Sprite (2)").position.y,
                        Backrounds[3].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[3].transform.Find("New Sprite (3)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[3].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[3].transform.Find("New Sprite (3)").position.y,
                    Backrounds[3].transform.Find("New Sprite (3)").position.z);
            }
                if ((Backrounds[3].transform.Find("New Sprite (4)").position.x + 40) < mainCamera.rect.xMin)
                {
                    Backrounds[3].transform.Find("New Sprite (4)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[3].transform.Find("New Sprite (4)").position.y,
                        Backrounds[3].transform.Find("New Sprite (4)").position.z);
                }
                if ((Backrounds[4].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[4].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[4].transform.Find("New Sprite").position.y,
                    Backrounds[4].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[4].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[4].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[4].transform.Find("New Sprite (1)").position.y,
                        Backrounds[4].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[4].transform.Find("New Sprite (2)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[4].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[4].transform.Find("New Sprite (2)").position.y,
                        Backrounds[4].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[4].transform.Find("New Sprite (3)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[4].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[4].transform.Find("New Sprite (3)").position.y,
                    Backrounds[4].transform.Find("New Sprite (3)").position.z);
            }
                if ((Backrounds[4].transform.Find("New Sprite (4)").position.x + 40) < mainCamera.rect.xMin)
                {
                    Backrounds[4].transform.Find("New Sprite (4)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[4].transform.Find("New Sprite (4)").position.y,
                        Backrounds[4].transform.Find("New Sprite (4)").position.z);
                }
                if ((Backrounds[5].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[5].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[5].transform.Find("New Sprite").position.y,
                    Backrounds[5].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[5].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[5].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[5].transform.Find("New Sprite (1)").position.y,
                        Backrounds[5].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[5].transform.Find("New Sprite (2)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[5].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[5].transform.Find("New Sprite (2)").position.y,
                        Backrounds[5].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[5].transform.Find("New Sprite (3)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[5].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[5].transform.Find("New Sprite (3)").position.y,
                    Backrounds[5].transform.Find("New Sprite (3)").position.z);
            }
                if ((Backrounds[5].transform.Find("New Sprite (4)").position.x + 40) < mainCamera.rect.xMin)
                {
                    Backrounds[5].transform.Find("New Sprite (4)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[5].transform.Find("New Sprite (4)").position.y,
                        Backrounds[5].transform.Find("New Sprite (4)").position.z);
                }
                if ((Backrounds[6].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[6].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[6].transform.Find("New Sprite").position.y,
                    Backrounds[6].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[6].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[6].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[6].transform.Find("New Sprite (1)").position.y,
                        Backrounds[6].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[6].transform.Find("New Sprite (2)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[6].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[6].transform.Find("New Sprite (2)").position.y,
                        Backrounds[6].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[6].transform.Find("New Sprite (3)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[6].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[6].transform.Find("New Sprite (3)").position.y,
                    Backrounds[6].transform.Find("New Sprite (3)").position.z);
            }
                if ((Backrounds[6].transform.Find("New Sprite (4)").position.x + 40) < mainCamera.rect.xMin)
                {
                    Backrounds[6].transform.Find("New Sprite (4)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[6].transform.Find("New Sprite (4)").position.y,
                        Backrounds[6].transform.Find("New Sprite (4)").position.z);
                }
                if ((Backrounds[7].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin)
            {

                Backrounds[7].transform.Find("New Sprite").position = new Vector3(
                    StartPositions[7],
                    Backrounds[7].transform.Find("New Sprite").position.y,
                    Backrounds[7].transform.Find("New Sprite").position.z);
            }
            if ((Backrounds[7].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
            {
                Backrounds[7].transform.Find("New Sprite (1)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[7].transform.Find("New Sprite (1)").position.y,
                        Backrounds[7].transform.Find("New Sprite (1)").position.z);
            }
            if ((Backrounds[7].transform.Find("New Sprite (2)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[7].transform.Find("New Sprite (2)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[7].transform.Find("New Sprite (2)").position.y,
                        Backrounds[7].transform.Find("New Sprite (2)").position.z);

            }
            if ((Backrounds[7].transform.Find("New Sprite (3)").position.x + 40) < mainCamera.rect.xMin)
            {
                Backrounds[7].transform.Find("New Sprite (3)").position = new Vector3(
                    StartPositions[7],
                    Backrounds[7].transform.Find("New Sprite (3)").position.y,
                    Backrounds[7].transform.Find("New Sprite (3)").position.z);
            }
                if ((Backrounds[7].transform.Find("New Sprite (4)").position.x + 40) < mainCamera.rect.xMin)
                {
                    Backrounds[7].transform.Find("New Sprite (4)").position = new Vector3(
                        StartPositions[7],
                        Backrounds[7].transform.Find("New Sprite (4)").position.y,
                        Backrounds[7].transform.Find("New Sprite (4)").position.z);
                }
                break;
            default:

                break;
       }
    }

   
}
