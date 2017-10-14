using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBackground : MonoBehaviour {
    public float rotationSpeed = 4f;
    float time = 0f;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(0, 0, (Mathf.Sin(time) * 50));
    }
}
