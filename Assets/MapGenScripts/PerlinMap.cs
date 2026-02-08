using UnityEngine;
using System.Collections.Generic;
public class PerlinMap : MonoBehaviour
{
    public GameObject WaterTile;
    public GameObject GrassTile;
    public GameObject MoutainTile;

    public int MapWidth;
    public int MapHeight;

    public float perlinScale = 5;

    private int offsetX;
    private int offsetY;

    private float WaterRange = 0.2f;
    private float MoutainRange = 0.6f;

    private List<GameObject> tiles = new List<GameObject>();



    void Start()
    {
        OffsetPos();
        GenerateMap();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            foreach (GameObject tile in tiles)
            {
                Destroy(tile);
            }

            tiles.Clear();

           
            OffsetPos();

          
            GenerateMap();
        }
    }

    private void OffsetPos()
    {
        offsetX = Random.Range(0, 9999);
        offsetY = Random.Range(0, 9999);
    }
    private void GenerateMap()
    {
        for (int i = 0; i < MapWidth; i++)
        {
            for (int j = 0; j < MapHeight; j++)
            {
                float xCord = (float)i / MapWidth * perlinScale + offsetX;
                float yCord = (float)j / MapHeight * perlinScale + offsetY;

                float noise = Mathf.PerlinNoise(xCord, yCord);

                GameObject tilePlaced;

                if (noise < WaterRange)
                {
                    tilePlaced = WaterTile;
                }

                else if (noise > MoutainRange)
                {
                    tilePlaced = MoutainTile;
                }
                else
                {
                    tilePlaced = GrassTile;
                }

                GameObject tile = Instantiate(tilePlaced, new Vector2(i, j), Quaternion.identity);

                tiles.Add(tile);


            }
        }
    }
}