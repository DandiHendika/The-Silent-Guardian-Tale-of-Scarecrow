using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    #region Variable
    public float speed;
    public float jumpForce;
    Rigidbody2D body;
    SpriteRenderer sprite;
    private Vector3 startPosition;
    private Vector3 checkpointPosition;
    private bool isGrounded;
    public Transform pickUpPoint;
    public float pickUpRange = 1.5f;
    private GameObject heldObject = null;
    public LayerMask playerLayer;
    public LayerMask pickedUpLayer; 
    public Vector2 pickUpOffset = new Vector2(0.5f, 0);
    #endregion

    private void Start()
    {
       body = GetComponent<Rigidbody2D>();
       sprite = GetComponent<SpriteRenderer>();
       startPosition = transform.position;
       checkpointPosition = startPosition;
       UpdatePickUpPoint();
       isGrounded = true;
    }

    // Update is called once per frame
    private void Update()
    {
        #region Movement
        if (Input.GetKey(KeyCode.RightArrow)){
            body.velocity = new Vector2(speed,body.velocity.y);
            sprite.flipX = false;
            UpdatePickUpPoint();
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            body.velocity = new Vector2(-speed, body.velocity.y);
            sprite.flipX = true;
            UpdatePickUpPoint();
        }
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded) {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            isGrounded = false;  
        }
        if (transform.position.y < -20f) // Ubah -5f sesuai dengan posisi ground kamu
        {
            ResetPosition(); // Mengatur ulang posisi karakter
            isGrounded = true;
        }
        #endregion

        #region PickUp
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (heldObject == null)
            {
                // Mencari objek di sekitar yang bisa diambil
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickUpRange);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("PickUp"))
                    {
                        heldObject = collider.gameObject;
                        heldObject.transform.SetParent(pickUpPoint);
                        heldObject.transform.localPosition = Vector3.zero;
                        heldObject.GetComponent<Rigidbody2D>().isKinematic = true;
                        heldObject.layer = pickedUpLayer;
                        Collider2D heldCollider = heldObject.GetComponent<Collider2D>();
                         if (heldCollider != null)
                        {
                            heldCollider.enabled = false;
                        }
                        break;
                    }
                }
            }else
            {
                Collider2D heldCollider = heldObject.GetComponent<Collider2D>();
                if (heldCollider != null)
                {
                    heldCollider.enabled = true;
                }
                heldObject.transform.SetParent(null);
                heldObject.GetComponent<Rigidbody2D>().isKinematic = false;
                heldObject.layer = LayerMask.NameToLayer("Default");
                heldObject = null;
            }
        }
        #endregion
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PickUp"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ResetPosition();
        }
    }

    #region CheckPoint
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointPosition = transform.position;
            Debug.Log("Checkpoint reached!");
        }
    }
        private void ResetPosition()
    {
        Debug.Log("Resetting position to checkpoint: " + checkpointPosition);
        transform.position = checkpointPosition;
        body.velocity = Vector2.zero;
    }
    #endregion

    private void UpdatePickUpPoint()
    {
        pickUpPoint.localPosition = sprite.flipX ? new Vector3(-pickUpOffset.x, pickUpOffset.y, 0) : new Vector3(pickUpOffset.x, pickUpOffset.y, 0);
    }
    
}
