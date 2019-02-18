using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //add 1 to our gemAmount in the ScoreScript
        ScoreScript.gemAmount += 1;
        //destroy this gem
        Destroy(gameObject);
    }

}
