using UnityEngine;                          //IGNORE THIS SCRIPT!
using System.Collections;                   //THE STUFF HERE WAS USEFULL,
                                            //BUT IT'S MOVED TO THE PLATFORMS
public enum level_id                        //SCRIPT AND THEN IT GOT FIXED!
{
    FOR_OF_MEET_MORNING, FOR_OF_MEET_EVENING,
    LAKE_OF_STILL_NIGHT, LAKE_OF_STILL_DAY, LAKE_OF_STILL_UNDERWATER,
    COCOON_CAVERNS,
    MOUNT_OF_FLUX_NIGHT, MOUNT_OF_FLUX_DAY,
    DEAD_LANDS_DAY, DEAD_LANDS_NIGHT,
    SLEEP_RUINS_NIGHT, SLEEP_RUINS_DAY,
    SAV_OF_GROWTH_NIGHT, SAV_OF_GROWTH_DAY,
    RAIN_OF_FATE_DAY, RAIN_OF_FATE_NIGHT,
    LIES_AT_THE_HEAVENS,
    FOR_OF_MEET_ENDING,
    _length
}

public class LevelData : MonoBehaviour
{
    public level_id levelID;
    public Sprite name;
    public Sprite thumbnail;
    public Platform platforms;
    public GameObject otherObject;
    public GameObject musicPlayer;
    public float speedIncreaser;
    //Use the following things only if you think they'd be useful.
    GameObject blockToGenerate; //Once ChooseLevelBlock() has been run, create this GameObject.
    GameObject lastBlock;
    GameObject blockBeforeLast;
    int rng;
    public int middleBlockPriority;
    public int gapPriority;
    public Gameobject lowLeft;
    public Gameobject lowMiddle;
    public Gameobject lowRight;
    public Gameobject lowToMid;
    public Gameobject midLeft;
    public Gameobject midMiddle;
    public Gameobject midRight;
    public Gameobject midToLow;
    public Gameobject midToHigh;
    public Gameobject highLeft;
    public Gameobject highMiddle;
    public Gameobject highRight;
    public Gameobject higToMid;
    public Gameobject highToLow;

    public void ChooseLevelBlock()
    {
        if (lastBlock == lowLeft || lastBlock == midLeft || lastBlock == highLeft)  //If it's a right corner block, the next block is a gap.
        {
            blockBeforeLast = lastBlock;
            lastBlock = blockToGenerate;
            blockToGenerate = null;
            Debug.Log("Gap");
        }

        else if (lastBlock == lowLeft || lastBlock == lowMiddle || lastBlock == midToLow || lastBlock == highToLow)
        {
            blockBeforeLast = lastBlock;
            lastBlock = blockToGenerate;

            float rng2 = (float)Random.Range(0, middleBlockPriority) / 2;
            if (rng2 <= 0.5f)
            {

                rng2 = Random.Range(0f, (float)transitionPriority);
                if (rng <= 0.5f)
                {
                    blockToGenerate = lowRight;
                    Debug.Log("Low Right");
                }
                else
                {
                    blockToGenerate = lowToMid;
                    Debug.Log("Low to Mid");
                }
            }
            else
            {
                blockToGenerate = lowMiddle;
                Debug.Log("Low Middle");
            }
        }

        else if (lastBlock == midLeft || lastBlock == midMiddle || lastBlock == lowToMid || lastBlock == highToMid)
        {
            blockBeforeLast = lastBlock;
            lastBlock = blockToGenerate;

            float rng2 = (float)Random.Range(0, middleBlockPriority) / 2;
            if (rng2 <= 0.5f)
            {

                rng = Random.Range(0, 2);
                if (rng == 0)
                {
                    blockToGenerate = midRight;
                    Debug.Log("Mid Right");
                }
                else if (rng == 1)
                {
                    blockToGenerate = midToLow;
                    Debug.Log("Mid to Low");
                }
                else
                {
                    blockToGenerate = midToHigh;
                    Debug.Log("Mid to High");
                }
            }
            else
            {
                blockToGenerate = midMiddle;
                Debug.Log("Mid Middle");
            }
        }

        else if (lastBlock == highLeft || lastBlock == highMiddle || lastBlock == midToHigh)
        {
            blockBeforeLast = lastBlock;
            lastBlock = blockToGenerate;

            float rng2 = (float)Random.Range(0, middleBlockPriority) / 2;
            if (rng2 <= 0.5f)
            {

                rng = Random.Range(0, 2);
                if (rng == 0)
                {
                    blockToGenerate = highRight;
                    Debug.Log("High Right");
                }
                else if (rng2 == 1)
                {
                    blockToGenerate = highToMid;
                    Debug.Log("High to Mid");
                }
                else
                {
                    blockToGenerate = highToLow;
                    Debug.Log("High to Low");
                }
            }
            else
            {
                blockToGenerate = highMiddle;
                Debug.Log("High Middle");
            }
        }

        else if (lastBlock == null) //What happens if the last piece was a gap
        {
            if (blockBeforeLast == lowRight)
            {
                blockBeforeLast = lastBlock;
                lastBlock = blockToGenerate;

                blockToGenerate = lowLeft;
                Debug.Log("Low Left");
            }

            else if (blockBeforeLast == midRight)
            {
                blockBeforeLast = lastBlock;
                lastBlock = blockToGenerate;

                rng = Random.Range(0, 1);
                if (rng == 0)
                {
                    blockToGenerate = midLeft;
                    Debug.Log("Mid Left");
                }
                else
                {
                    blockToGenerate = lowLeft;
                    Debug.Log("Low Left;");
                }
            }

            else if (blockBeforeLast == highRight)
            {
                blockBeforeLast = lastBlock;
                lastBlock = blockToGenerate;

                rng = Random.Range(0, 2);
                if (rng == 0)
                {
                    blockToGenerate = highLeft;
                    Debug.Log("High Left");
                }
                else if (rng == 1)
                {
                    blockToGenerate = midLeft;
                    Debug.Log("Mid Left");
                }
                else
                {
                    blockToGenerate = lowLeft;
                    Debug.Log("Low Left;");
                }
            }
        }
        
    }

}