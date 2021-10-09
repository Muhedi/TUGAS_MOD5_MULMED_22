using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletScript : MonoBehaviour{
    public float timer;
    public float velX = 5f;
    float velY = 0f;
    Rigidbody2D rb;
   

 // Start is called before the first frame update
 void Start(){
    rb = GetComponent<Rigidbody2D>();
   
    
}

 // Update is called once per frame
 void Update(){
    rb.velocity = new Vector2(velX, velY);
    timer += 1.0f*Time.deltaTime;
    if(timer >= 3){
        Destroy(gameObject);

    }
 }

 void OnCollisionEnter2D (Collision2D col)
 {
     if(col.gameObject.CompareTag("enemigo"))
     {
         ScoreScript2.scoreValue += 10;
         Destroy(col.gameObject);
         Destroy(gameObject);
         
        
     }
 }
}
