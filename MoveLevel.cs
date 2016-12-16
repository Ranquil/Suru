using UnityEngine;
using UnityEditor;
using System.Collections;

public class MoveLevel : MonoBehaviour {

    public int timeLimit;
    public GameObject[] planes;
    public GameObject Camera;
    public int sizeOfSprites;
    GameObject[] Backrounds;
    public float LevelSpeed;
    public float Layer1ParMultiplier;
    public float Layer2ParMultiplier;
    public float Layer3ParMultiplier;
    public float Layer4ParMultiplier;
    SpriteRenderer[] planeSpriteR;
    public Sprite[] Planesprite;
    float[] StartPositions;

    Camera mainCamera;
    [MenuItem("AssetDatabase/loadAllAssetsAtPath")]
    // Use this for initialization
    void Start ()
    {
        
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
            
                            
             if (k.tag.Equals("TallTrees"))
             {
                Planesprite = Resources.LoadAll<Sprite>("Resources");
                Debug.Log("Lataukseen päästiin");
             }                    

        }
       

       

	}
	
	// Update is called once per frame
	void Update ()
    {

        moveLevel();
        
	}

    void moveLevel()
    {






        /*
          Backrounds[0].transform.position = new Vector3(Backrounds[0].transform.position.x - LevelSpeed, Backrounds[0].transform.position.y, Backrounds[0].transform.position.z);
          Backrounds[1].transform.position = new Vector3(Backrounds[1].transform.position.x - LevelSpeed, Backrounds[1].transform.position.y, Backrounds[1].transform.position.z);
          Backrounds[2].transform.position = new Vector3(Backrounds[2].transform.position.x - LevelSpeed, Backrounds[2].transform.position.y, Backrounds[2].transform.position.z);
          Backrounds[3].transform.position = new Vector3(Backrounds[3].transform.position.x - LevelSpeed, Backrounds[3].transform.position.y, Backrounds[3].transform.position.z);
          Backrounds[4].transform.position = new Vector3(Backrounds[4].transform.position.x - LevelSpeed, Backrounds[4].transform.position.y, Backrounds[4].transform.position.z);
          Backrounds[5].transform.position = new Vector3(Backrounds[5].transform.position.x - LevelSpeed, Backrounds[5].transform.position.y, Backrounds[5].transform.position.z);
          Backrounds[6].transform.position = new Vector3(Backrounds[6].transform.position.x - LevelSpeed, Backrounds[6].transform.position.y, Backrounds[6].transform.position.z);
          Backrounds[7].transform.position = new Vector3(Backrounds[7].transform.position.x - LevelSpeed, Backrounds[7].transform.position.y, Backrounds[7].transform.position.z);
          */


        for (int i = 0; i < Backrounds.Length; i++)
        {
            Backrounds[i].transform.Find("New Sprite").position = new Vector3(Backrounds[i].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
            Backrounds[i].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (1)").position.x - LevelSpeed * Layer2ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
            Backrounds[i].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (2)").position.x - LevelSpeed * Layer3ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
            Backrounds[i].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[i].transform.Find("New Sprite (3)").position.x - LevelSpeed * Layer4ParMultiplier, Backrounds[i].transform.position.y, Backrounds[i].transform.position.z);
        }
        /*
        Backrounds[1].transform.Find("New Sprite").position = new Vector3(Backrounds[1].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[1].transform.position.y, Backrounds[1].transform.position.z);
        Backrounds[1].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[1].transform.Find("New Sprite (1)").position.x - LevelSpeed * Layer2ParMultiplier, Backrounds[1].transform.position.y, Backrounds[1].transform.position.z);
        Backrounds[1].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[1].transform.Find("New Sprite (2)").position.x - LevelSpeed * Layer3ParMultiplier, Backrounds[1].transform.position.y, Backrounds[1].transform.position.z);
        Backrounds[1].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[1].transform.Find("New Sprite (3)").position.x - LevelSpeed * Layer4ParMultiplier, Backrounds[1].transform.position.y, Backrounds[1].transform.position.z);

        Backrounds[2].transform.Find("New Sprite").position = new Vector3(Backrounds[2].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[2].transform.position.y, Backrounds[2].transform.position.z);
        Backrounds[2].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[2].transform.Find("New Sprite (1)").position.x - LevelSpeed * Layer2ParMultiplier, Backrounds[2].transform.position.y, Backrounds[2].transform.position.z);
        Backrounds[2].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[2].transform.Find("New Sprite (2)").position.x - LevelSpeed * Layer3ParMultiplier, Backrounds[2].transform.position.y, Backrounds[2].transform.position.z);
        Backrounds[2].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[2].transform.Find("New Sprite (3)").position.x - LevelSpeed * Layer4ParMultiplier, Backrounds[2].transform.position.y, Backrounds[2].transform.position.z);

        Backrounds[3].transform.Find("New Sprite").position = new Vector3(Backrounds[3].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[3].transform.position.y, Backrounds[3].transform.position.z);
        Backrounds[3].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[3].transform.Find("New Sprite (1)").position.x - LevelSpeed  * Layer2ParMultiplier, Backrounds[3].transform.position.y, Backrounds[3].transform.position.z);
        Backrounds[3].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[3].transform.Find("New Sprite (2)").position.x - LevelSpeed  * Layer3ParMultiplier, Backrounds[3].transform.position.y, Backrounds[3].transform.position.z);
        Backrounds[3].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[3].transform.Find("New Sprite (3)").position.x - LevelSpeed  * Layer4ParMultiplier, Backrounds[3].transform.position.y, Backrounds[3].transform.position.z);

        Backrounds[4].transform.Find("New Sprite").position = new Vector3(Backrounds[4].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[4].transform.position.y, Backrounds[4].transform.position.z);
        Backrounds[4].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[4].transform.Find("New Sprite (1)").position.x - LevelSpeed * Layer2ParMultiplier, Backrounds[4].transform.position.y, Backrounds[4].transform.position.z);
        Backrounds[4].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[4].transform.Find("New Sprite (2)").position.x - LevelSpeed * Layer3ParMultiplier, Backrounds[4].transform.position.y, Backrounds[4].transform.position.z);
        Backrounds[4].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[4].transform.Find("New Sprite (3)").position.x - LevelSpeed * Layer4ParMultiplier, Backrounds[4].transform.position.y, Backrounds[4].transform.position.z);

        Backrounds[5].transform.Find("New Sprite").position = new Vector3(Backrounds[5].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[5].transform.position.y, Backrounds[5].transform.position.z);
        Backrounds[5].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[5].transform.Find("New Sprite (1)").position.x - LevelSpeed * Layer2ParMultiplier, Backrounds[5].transform.position.y, Backrounds[5].transform.position.z);
        Backrounds[5].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[5].transform.Find("New Sprite (2)").position.x - LevelSpeed * Layer3ParMultiplier, Backrounds[5].transform.position.y, Backrounds[5].transform.position.z);
        Backrounds[5].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[5].transform.Find("New Sprite (3)").position.x - LevelSpeed * Layer4ParMultiplier, Backrounds[5].transform.position.y, Backrounds[5].transform.position.z);

        Backrounds[6].transform.Find("New Sprite").position = new Vector3(Backrounds[6].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[6].transform.position.y, Backrounds[6].transform.position.z);
        Backrounds[6].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[6].transform.Find("New Sprite (1)").position.x - LevelSpeed * Layer2ParMultiplier, Backrounds[6].transform.position.y, Backrounds[6].transform.position.z);
        Backrounds[6].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[6].transform.Find("New Sprite (2)").position.x - LevelSpeed * Layer3ParMultiplier, Backrounds[6].transform.position.y, Backrounds[6].transform.position.z);
        Backrounds[6].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[6].transform.Find("New Sprite (3)").position.x - LevelSpeed * Layer4ParMultiplier, Backrounds[6].transform.position.y, Backrounds[6].transform.position.z);

        Backrounds[7].transform.Find("New Sprite").position = new Vector3(Backrounds[7].transform.Find("New Sprite").position.x - LevelSpeed * Layer1ParMultiplier, Backrounds[7].transform.position.y, Backrounds[7].transform.position.z);
        Backrounds[7].transform.Find("New Sprite (1)").position = new Vector3(Backrounds[7].transform.Find("New Sprite (1)").position.x - LevelSpeed * Layer2ParMultiplier, Backrounds[7].transform.position.y, Backrounds[7].transform.position.z);
        Backrounds[7].transform.Find("New Sprite (2)").position = new Vector3(Backrounds[7].transform.Find("New Sprite (2)").position.x - LevelSpeed * Layer3ParMultiplier, Backrounds[7].transform.position.y, Backrounds[7].transform.position.z);
        Backrounds[7].transform.Find("New Sprite (3)").position = new Vector3(Backrounds[7].transform.Find("New Sprite (3)").position.x - LevelSpeed * Layer4ParMultiplier, Backrounds[7].transform.position.y, Backrounds[7].transform.position.z);
        */
        if (Backrounds[0].tag.Equals("TallTrees"))
        {
            //  Backrounds[0].transform.position = new Vector3(j.transform.position.x + LevelSpeed, j.transform.position.y, j.transform.position.z);
        }

        /*
        for(int i = 0; i < Backrounds.Length; i++)
        {

            for (int j = 0; j < 4; j++)
            {
                if ((Backrounds[i].transform.Find("New Sprite").position.x + 20) < mainCamera.rect.xMin && j == 0)
                {


                    Backrounds[i].transform.Find("New Sprite").position = new Vector3(
                        StartPositions[7],
                        Backrounds[i].transform.Find("New Sprite").position.y,
                        Backrounds[i].transform.Find("New Sprite").position.z);
                }

                if ((Backrounds[i].transform.Find("New Sprite (" + j + ")").position.x + 20) < mainCamera.rect.xMin && j > 0)
                {


                    Backrounds[i].transform.Find("New Sprite (" + j + ")").position = new Vector3(
                        StartPositions[7],
                        Backrounds[i].transform.Find("New Sprite (" + j + ")").position.y,
                        Backrounds[i].transform.Find("New Sprite (" + j + ")").position.z);
                }
            }
        }
        */
        
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
             StartPositions[7] ,
            Backrounds[2].transform.Find("New Sprite (1)").position.y,
            Backrounds[2].transform.Find("New Sprite (1)").position.z);
        }
        if ((Backrounds[2].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
        {
            Backrounds[2].transform.Find("New Sprite (2)").position = new Vector3(
                StartPositions[7] ,
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
                StartPositions[7] ,
                Backrounds[3].transform.Find("New Sprite").position.y,
                Backrounds[3].transform.Find("New Sprite").position.z);
        }
        if ((Backrounds[3].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
        {
            Backrounds[3].transform.Find("New Sprite (1)").position = new Vector3(
                    StartPositions[7] ,
                    Backrounds[3].transform.Find("New Sprite (1)").position.y,
                    Backrounds[3].transform.Find("New Sprite (1)").position.z);
        }
        if ((Backrounds[3].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
        {
            Backrounds[3].transform.Find("New Sprite (2)").position = new Vector3(
                    StartPositions[7] ,
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
                    StartPositions[7] ,
                    Backrounds[4].transform.Find("New Sprite (1)").position.y,
                    Backrounds[4].transform.Find("New Sprite (1)").position.z);
        }
        if ((Backrounds[4].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
        {
            Backrounds[4].transform.Find("New Sprite (2)").position = new Vector3(
                    StartPositions[7] ,
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
                StartPositions[7] ,
                Backrounds[5].transform.Find("New Sprite").position.y,
                Backrounds[5].transform.Find("New Sprite").position.z);
        }
        if ((Backrounds[5].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
        {
            Backrounds[5].transform.Find("New Sprite (1)").position = new Vector3(
                    StartPositions[7] ,
                    Backrounds[5].transform.Find("New Sprite (1)").position.y,
                    Backrounds[5].transform.Find("New Sprite (1)").position.z);
        }
        if ((Backrounds[5].transform.Find("New Sprite (2)").position.x + 20) < mainCamera.rect.xMin)
        {
            Backrounds[5].transform.Find("New Sprite (2)").position = new Vector3(
                    StartPositions[7] ,
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
                StartPositions[7] ,
                Backrounds[6].transform.Find("New Sprite").position.y,
                Backrounds[6].transform.Find("New Sprite").position.z);
        }
        if ((Backrounds[6].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
        {
            Backrounds[6].transform.Find("New Sprite (1)").position = new Vector3(
                    StartPositions[7] ,
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
                StartPositions[7] ,
                Backrounds[7].transform.Find("New Sprite").position.y,
                Backrounds[7].transform.Find("New Sprite").position.z);
        }
        if ((Backrounds[7].transform.Find("New Sprite (1)").position.x + 20) < mainCamera.rect.xMin)
        {
            Backrounds[7].transform.Find("New Sprite (1)").position = new Vector3(
                    StartPositions[7] ,
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
        
    }

    void GeneratePlatforms()
    {

    }
}
