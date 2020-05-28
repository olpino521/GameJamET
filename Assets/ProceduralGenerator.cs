using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    [Header("Procedural Values")]
    [SerializeField] int maxHeight = 10;
    [SerializeField] int minHeight = 5;
    [SerializeField] int maxWidth = 10;
    [SerializeField] int minWidth = 10;
    [Header("Prefabs")]
    [SerializeField] GameObject dirtBlock;
    [SerializeField] GameObject spike;
    [SerializeField] GameObject end;
    //chance form 0 to 100 for the spike to spawn
    [SerializeField] int spikeChance;

    float offsetX = 0;
    float offsetY = 0;

    void Start()
    {
        //Create a randpm value to start the offset with
        offsetY = Random.Range(0, 2048);
        offsetX = Random.Range(0, 2048);
        Generate();
    }

    public void Generate()
    {
        //Get width and height of prefabs to instantiate them properly
        float width = dirtBlock.transform.lossyScale.x;
        float height = dirtBlock.transform.lossyScale.y;

        //Create a playable level using perlin noise to make random height for every column 
        for (int i = minWidth; i < maxWidth; i++)
        {
            int columnHeight = (int)Mathf.Round(Mathf.PerlinNoise(i / maxHeight + offsetX, offsetY / maxHeight + offsetY) * maxHeight);
            //Increase the offset using delta time for small increases
            offsetX += Time.deltaTime;
            offsetY += Time.deltaTime;
            for (int j = minHeight; j < minHeight + columnHeight; j++)
            {
                Instantiate(dirtBlock, new Vector2(i * width, j * height), Quaternion.identity);
                // Create a spike given the chance in top of ceratin columns
                if (j == minHeight + columnHeight - 1)
                {
                    //If its the last one then create a flag
                    if(i == maxWidth -1 )
                    {
                        Instantiate(end, new Vector2(i * width, (j + 1) * height), Quaternion.identity);
                        return;
                    }
                    //Chance to create a spike
                    int chanceSpike = Random.Range(0, 100);
                    if (chanceSpike <= spikeChance)
                        Instantiate(spike, new Vector2(i * width, (j + 1) * height), Quaternion.identity);
                }

            }
        }
    }
}
