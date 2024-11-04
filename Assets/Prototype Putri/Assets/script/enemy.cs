using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed ;        // Kecepatan musuh
    public float moveDistance; // Jarak gerakan musuh
    private Vector3 startPosition;   // Posisi awal musuh
    private bool movingRight = true; // Arah gerakan musuh

    void Start()
    {
        startPosition = transform.position; // Menyimpan posisi awal musuh
    }

    void Update()
    {
        // Menggerakkan musuh ke kanan atau kiri
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            // Cek apakah sudah mencapai batas gerakan
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false; // Ubah arah gerakan
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            // Cek apakah sudah mencapai batas gerakan
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true; // Ubah arah gerakan
            }
        }
    }

}
