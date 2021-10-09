using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private bool facingRight;
    private PolygonCollider2D polygoncollider2D;

    [SerializeField]
    private LayerMask platformsLayerMask;

    [SerializeField]
    private float movementSpeed;


    public GameObject BullettoRight, BullettoLeft;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

private void Awake(){
    polygoncollider2D = transform.GetComponent<PolygonCollider2D>();
 }
 // Start is called before the first frame update
 void Start(){
    facingRight = true;
    myRigidbody = transform.GetComponent<Rigidbody2D> ();
 }
 // Update is called once per frame
 void Update(){
 //if(IsGrounded() && Input.GetKeyDown(KeyCode, Space))
    if(IsGrounded() && Input.GetButtonDown("Jump"))
    {
        float jumpVelocity = 10f;
        myRigidbody.velocity = Vector2.up*jumpVelocity;
    } 
    if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
    {
     nextFire = Time.time + fireRate;
     fire();
    }
 }

 private bool IsGrounded(){
    RaycastHit2D raycastHit2d = Physics2D.BoxCast (polygoncollider2D.bounds.center, polygoncollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
    
    return raycastHit2d.collider != null;
 }

 void FixedUpdate(){
    float horizontal = Input.GetAxis("Horizontal");
    HandleMovement(horizontal);
    Flip(horizontal);
 }
 
 private void HandleMovement(float horizontal){
    myRigidbody.velocity = new Vector2(horizontal*movementSpeed, myRigidbody.velocity.y);
 }

 private void Flip(float horizontal){
    if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        }
 }

 void fire(){
    bulletPos = transform.position;
    if(facingRight){
        bulletPos += new Vector2(+1f, -0.08f);
        Instantiate(BullettoRight, bulletPos, Quaternion.identity);
    }
    else{
        bulletPos += new Vector2(-1f, -0.08f);
        Instantiate(BullettoLeft, bulletPos, Quaternion.identity);
    }
  
    }
    

void OnCollisionEnter2D (Collision2D col){
     if(col.gameObject.CompareTag("enemigo"))
     {
         Destroy(gameObject);
         SceneManager.LoadScene("GameOver");
         ScoreScript2.scoreValue = 0;
     }

 }
 

}
