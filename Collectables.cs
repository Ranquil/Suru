using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {

    public GameObject[] Collectable;
    Transform[] collTrans;

	// Use this for initialization
	void Start ()
    {
        collTrans = new Transform[Collectable.Length];
        for(int i =0)
        collTrans[i] = Collectable.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    collTrans.position.
	}
}
