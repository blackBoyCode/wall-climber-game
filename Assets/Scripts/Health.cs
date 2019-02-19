using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //DONT FORGET THIS!!!!!!!

public class Health : MonoBehaviour {

    static public int health;
    public int numOfHearts; //heart containers

    public Image[] hearts;
    public Sprite fullHeart;
   // public Sprite blackHearts;

	void Start () {
        health = 3;
	}
	
	void Update () {

        //if by accident we enter more hearts than containers available
        if(health > numOfHearts){
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++){

            //for each new heart of the array we want to create a new heart sprite
            hearts[i].sprite = fullHeart;

            
            if (i < health){ //make the heart white if we havent reached full health
                hearts[i].color = Color.white;
            } else { //make the heart black if we have reached full health
                hearts[i].color = Color.black;
            }

            //create a new heart if i is less than the number of hearts we want
            if(i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
	}
}
