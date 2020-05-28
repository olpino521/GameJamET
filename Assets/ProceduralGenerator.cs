using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    [SerializeField] int size = 256;
    [SerializeField] float offsetX = 0;
    [SerializeField] float offsetY = 0;
    [SerializeField] GameObject dirtBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Generate()
    {
        float width = dirtBlock.transform.lossyScale.x;
        float height = dirtBlock.transform.lossyScale.y;

        float perlin = Mathf.PerlinNoise(width, height);
    }
}
