using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public TileType[] tileTypes;

    int[,] tiles;

    int mapSizeX = 10;
    int mapSizeY = 10;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMapData();
        GenerateMap();
    }


    void GenerateMapData()
    {
        // Allocate board tiles
        tiles = new int[mapSizeX, mapSizeY];

        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }

        tiles[0, 0] = 3;
        tiles[9, 9] = 3;
        tiles[9, 0] = 3;
        tiles[0, 9] = 3;


        for(int x = 1; x < mapSizeX-1; x++)
        {
            tiles[x, 0] = 2;
            tiles[x, 9] = 2;
        }

        for (int y = 1; y < mapSizeY - 1; y++)
        {
            tiles[0, y] = 1;
            tiles[9, y] = 1;
        }
    }


    void GenerateMap()
    {
        for (int x=0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                TileType tt = tileTypes[tiles[x, y]];
                if (tt.name == "boardEdgeVertical")
                {
                    if (x == 0)
                    {
                        Instantiate(tt.tileVisualPrefab, new Vector3(0.375f, y, -0.3f), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(tt.tileVisualPrefab, new Vector3(8.63f, y, -0.3f), Quaternion.identity);
                    }
                }
                else if (tt.name == "boardEdgeHorizontal")
                {
                    if (y == 0)
                    {
                        Instantiate(tt.tileVisualPrefab, new Vector3(x, 0.375f, -0.3f), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(tt.tileVisualPrefab, new Vector3(x, 8.63f, -0.3f), Quaternion.identity);
                    }
                }
                else if (tt.name == "tileCorner")
                {
                    if ((x == 0) && (y == 0))
                    {
                        Instantiate(tt.tileVisualPrefab, new Vector3(.375f, .375f, -0.3f), Quaternion.identity);
                    }
                    else if ((x == 0) && (y == 9))
                    {
                        Instantiate(tt.tileVisualPrefab, new Vector3(.375f, 8.625f, -0.3f), Quaternion.identity);
                    }
                    else if ((x == 9) && (y == 9))
                    {
                        Instantiate(tt.tileVisualPrefab, new Vector3(8.625f, 8.625f, -0.3f), Quaternion.identity);
                    }
                    else if ((x == 9) && (y == 0))
                    {
                        Instantiate(tt.tileVisualPrefab, new Vector3(8.625f, .375f, -0.3f), Quaternion.identity);
                    }
                }
                    
                else
                {
                    Instantiate(tt.tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity);
                }
                
            }
        }
    }

}
