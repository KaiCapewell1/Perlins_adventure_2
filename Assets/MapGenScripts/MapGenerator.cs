using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    System.Random r = new System.Random();

    public int mapWidth;
    public int mapHeight;

    public GameObject TEMPWALL;
    public GameObject TEMP;
    public GameObject TEMPDOOR;

    public GameObject player;

    void Start()
    {
        GenerateMap();
    }


    private void GenerateMap()
    {
        int randomX = r.Next(1, mapWidth - 1);
        int randomY = r.Next(1, mapHeight - 1);

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                if (i == 0 || i == mapWidth - 1 || j == 0 || j == mapHeight - 1)
                {
                    Instantiate(TEMPWALL, new Vector3(i, j, 0f), Quaternion.identity);
                }

                if (i == randomX && j == randomY)
                {
                    Vector2 position = new Vector2(randomX, randomY);
                    CreateSpawnRoom(position);
                    
                }
            }
        }

        CreateEndRoom();
    }

    private void CreateSpawnRoom(Vector2 position)
    {
        Instantiate(TEMP, position, Quaternion.identity);
        player.transform.position = position;
    }


    private void CreateEndRoom()
    {
        int wall = r.Next(0, 4);
        Vector2 doorPos = Vector2.zero;

        switch (wall) {
            case 0:
                doorPos = new Vector2(r.Next(1, mapWidth - 1), mapHeight - 1);
                break;
            case 1:
                doorPos = new Vector2(r.Next(1, mapWidth - 1), 0);
                break;
            case 2:
                doorPos = new Vector2(0, r.Next(1, mapHeight - 1));
                break;
            case 3:
                doorPos = new Vector2(mapWidth - 1, r.Next(1, mapHeight - 1));
                break;
        }

        Instantiate(TEMPDOOR, doorPos, Quaternion.identity);
        GameObject InvalidWall = Instantiate(TEMP, doorPos, Quaternion.identity);

        Destroy(InvalidWall);
    }
}