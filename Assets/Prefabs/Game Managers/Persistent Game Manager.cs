using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PersistentGameManager {

    private static int lives, score, level;
    
    public static int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }
    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    public static int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

}
