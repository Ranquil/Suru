using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public GameObject Collectable;
    public GameObject[] Platforms;
    public GameObject Player;
    GameObject[] Colls;
    
    Transform[] collTrans;
    int j = 0;
    int i = 0;
    float[] lengthtoSurface;
    // Use this for initialization
    void Awake()
    {
        lengthtoSurface = new float[23];

        Colls = new GameObject[23];

        collTrans = new Transform[23];
        for (int i = 0; i < Colls.Length; i++)
        {
            Colls[i] = Collectable;
            collTrans[i] = Colls[i].transform;


            Colls[i].AddComponent<BoxCollider2D>();
            Colls[i].AddComponent<Rigidbody2D>();
            Colls[i].GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
    void Start ()
    {
        
       
        lengthtoSurface[0] = 2.5f;
        lengthtoSurface[1] = 2.5f;
        lengthtoSurface[2] = 2.5f;
        lengthtoSurface[3] = 2.5f;
        lengthtoSurface[4] = 2.5f;
        lengthtoSurface[5] = 2.5f;
        lengthtoSurface[6] = 3.5f;
        lengthtoSurface[7] = 3.5f;
        lengthtoSurface[8] = 3.5f;
        lengthtoSurface[9] = 3.5f;
        lengthtoSurface[10] = 3.5f;
        lengthtoSurface[11] = 3.5f;
        lengthtoSurface[12] = 3.5f;
        lengthtoSurface[13] = 3.5f;
        lengthtoSurface[14] = 4.5f;
        lengthtoSurface[15] = 4.5f;
        lengthtoSurface[16] = 4.5f;
        lengthtoSurface[17] = 4.5f;
        lengthtoSurface[18] = 4.5f;
        lengthtoSurface[19] = 4.5f;
        lengthtoSurface[20] = 4.5f;
        lengthtoSurface[21] = 4.5f;
        lengthtoSurface[22] = 4.5f;

        


    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

	   
	}
    void FixedUpdate()
    {


        collTrans[i].position = new Vector3(Platforms[j].transform.position.x, Platforms[j].transform.position.y + lengthtoSurface[j], Platforms[j].transform.position.z);


        Instantiate(Colls[i], collTrans[i]);

        if (j < 22)
        {
            j++;
        }
        if(i < Colls.Length)
        {
            i++;
        }
        if(j == 22)
        {
            j = 0;
        }
        if(i == Colls.Length)
        {
            i = 0;
        }


    }
}
