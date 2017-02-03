using UnityEngine;
using System.Collections;

public enum level_id
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

[System.Serializable]
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
    GameObject blockToGenerate;
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
}

public class LevelGeneration : MonoBehaviour
{
    public void ChooseLevelBlock()
    {
        if (lastBlock == lowLeft || lastBlock == midLeft || lastBlock == highLeft)  //If it's a right corner block, the next block is a gap.
        {
            blockBeforeLast = lastBlock;
            lastBlock = blockToGenerate;
            blockToGenerate = null;
            Console.WriteLine("Gap");
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
                    Console.WriteLine("Low Right");
                }
                else
                {
                    blockToGenerate = lowToMid;
                    Console.WriteLine("Low to Mid");
                }
            }
            else
            {
                blockToGenerate = lowMiddle;
                Console.WriteLine("Low Middle");
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
                    Console.WriteLine("Mid Right");
                }
                else if (rng == 1)
                {
                    blockToGenerate = midToLow;
                    Console.WriteLine("Mid to Low");
                }
                else
                {
                    blockToGenerate = midToHigh;
                    Console.WriteLine("Mid to High");
                }
            }
            else
            {
                blockToGenerate = midMiddle;
                Console.WriteLine("Mid Middle");
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
                    Console.WriteLine("High Right");
                }
                else if (rng2 == 1)
                {
                    blockToGenerate = highToMid;
                    Console.WriteLine("High to Mid");
                }
                else
                {
                    blockToGenerate = highToLow;
                    Console.WriteLine("High to Low");
                }
            }
            else
            {
                blockToGenerate = highMiddle;
                Console.WriteLine("High Middle");
            }
        }

        else if (lastBlock == null) //What happens if the last piece was a gap
        {
            if (blockBeforeLast == lowRight)
            {
                blockBeforeLast = lastBlock;
                lastBlock = blockToGenerate;

                blockToGenerate = lowLeft;
                Console.WriteLine("Low Left");
            }

            else if (blockBeforeLast == midRight)
            {
                blockBeforeLast = lastBlock;
                lastBlock = blockToGenerate;

                rng = Random.Range(0, 1);
                if (rng == 0)
                {
                    blockToGenerate = midLeft;
                    Console.WriteLine("Mid Left");
                }
                else
                {
                    blockToGenerate = lowLeft;
                    Console.WriteLine("Low Left;");
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
                    Console.WriteLine("High Left");
                }
                else if (rng == 1)
                {
                    blockToGenerate = midLeft;
                    Console.WriteLine("Mid Left");
                }
                else
                {
                    blockToGenerate = lowLeft;
                    Console.WriteLine("Low Left;");
                }
            }
        }
        
    }

}