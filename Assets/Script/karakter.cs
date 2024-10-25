using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Rigidbody2D body;
    SpriteRenderer sprite;
    private Vector3 startPosition;
    private Vector3 checkpointPosition;
    
    void Start()
    {
       body = GetComponent<Rigidbody2D>();
       sprite = GetComponent<SpriteRenderer>();
       startPosition = transform.position;
       checkpointPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            body.velocity = new Vector2(speed,body.velocity.y);
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            body.velocity = new Vector2(-speed, body.velocity.y);
            sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            body.velocity = new Vector2(body.velocity.x, jumpForce);  
        }
        if (transform.position.y < -5f) // Ubah -5f sesuai dengan posisi ground kamu
        {
            ResetPosition(); // Mengatur ulang posisi karakter
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
             // Karakter berada di tanah
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ResetPosition();        // Menghentikan semua gerakan
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointPosition = transform.position; // Menyimpan posisi checkpoint
            Debug.Log("Checkpoint reached!"); // Pesan untuk debug
        }
    }
        private void ResetPosition()
    {
        Debug.Log("Resetting position to checkpoint: " + checkpointPosition);
        transform.position = checkpointPosition; // Kembali ke posisi awal
        body.velocity = Vector2.zero;       // Menghentikan semua gerakan
        
    }
}
