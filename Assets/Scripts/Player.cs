using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	void Update () {
		transform.Translate(new Vector3(Input.GetAxis("Vertical")*Time.deltaTime, 0 ,-Input.GetAxis("Horizontal")*Time.deltaTime));
	}
}
