using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBrick : MonoBehaviour {

	// Use this for initialization
	void OnDestroy()
    {
        GameObject powerup = Instantiate(Resources.Load("Powerup", typeof(GameObject)), this.transform.position, new Quaternion()) as GameObject;
    }
}
