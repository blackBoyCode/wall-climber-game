using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //DONT FORGET THISSSS

public class ScoreScript : MonoBehaviour {

    Text gems;
    public static int gemAmount;

	void Start () {
        gems = GetComponent<Text>();
	}
	
	void Update () {
        gems.text = gemAmount.ToString();
	}
}
