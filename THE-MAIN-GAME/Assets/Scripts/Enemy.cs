using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public int health =10;
    public float speed =2f;
    public Transform player;

    private Vector2 lastPosition;
    private Vector2 newPosition;

// The enemy object's movement
    void Update(){
	lastPosition = transform.position;
// Move towards player
	if (Vector2.Distance(player.position, transform.position)<5 && Vector2.Distance(player.position, transform.position)>1){
	    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

	newPosition = transform.position;
// Death
        if (health <= 0)
        {
            Destroy(gameObject);
    }

// Flipping the enemy
	if (lastPosition.x < newPosition.x){
	    flipRight();
    }   else if (lastPosition.x > newPosition.x){
	    flipLeft();
    }

    }

// The enemy object takes damage
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

// The flipper functions
    void flipRight(){
	    Vector3 Scaler = transform.localScale;
	    if (Scaler.x > 0){    
	        Scaler.x *= -1;
	        transform.localScale = Scaler;
        }
    }

    void flipLeft(){
	    Vector3 Scaler = transform.localScale;
	    if (Scaler.x < 0){    
	        Scaler.x *= -1;
	        transform.localScale = Scaler;
        }
        }
}

