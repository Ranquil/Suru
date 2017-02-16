using UnityEngine;
using System.Collections;
        //Feel free to completely ignore this script, it has no use.
public class HighScore : MonoBehaviour {

    int Score;
   static int[] SavedScore;
	// Use this for initialization
	void Start () {
        SavedScore = new int[10];
        
        Score = 0;
	}
	void incrementScore(int score)
    {
        Score = Score + score;
    }
    void ResetScore()
    {
        Score = 0;
    }
    void SaveScore()
    {
        for (int i = 0; i < 10; i++)
        {
            if (SavedScore[i] == 0)
            {
                SavedScore[i] = Score;
                break;
            }
            else if(Score > SavedScore[i] && SavedScore[i+1] != 0 && i != 10 )
            {
                SavedScore[i + 1] = SavedScore[i]; 
                SavedScore[i] = Score;
                break;
            }
            
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
