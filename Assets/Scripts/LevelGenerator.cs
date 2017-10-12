﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    // 10 x 10 pixel
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
	// Use this for initialization
	void Start () {
        GenerateLevel();
	}
	
    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }

    }
    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if(pixelColor.a == 0)
        {
            return;
        }
        Debug.Log("Showing pixel at: " + x + y);
        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2();
                position.x = (x + .8f) * 1.5f;
                position.y = y;
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }

    }
}