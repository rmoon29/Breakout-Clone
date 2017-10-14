using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : MonoBehaviour {

    // 10 x 10 pixel
    public Texture2D[] map;
    public ColorToPrefab[] colorMappings;
	// Use this for initialization
	void Start () {
        
        GenerateLevel(0);
        DelegateHandler.onNewLevel += GenerateLevel;
	}
	
    void GenerateLevel(int level)
    {
        Debug.Log("Generating Level");
        for (int x = 0; x < map[level].width; x++)
        {
            for (int y = 0; y < map[level].height; y++)
            {
                GenerateTile(x, y, level);
            }
        }

    }
    void GenerateTile(int x, int y, int level)
    {
        Color pixelColor = map[level].GetPixel(x, y);

        if(pixelColor.a == 0)
        {
            return;
        }
        //Debug.Log("Showing pixel at: " + x + y);
        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2();
                position.x = (x + .8f) * 1.5f;
                position.y = (y + 3.5f) / 1.4f;
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
                DelegateHandler.addBrick();
            }
        }

    }
}

