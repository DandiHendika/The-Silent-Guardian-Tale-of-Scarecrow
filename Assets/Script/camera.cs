using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // Objek yang akan diikuti (karakter)
    public Vector3 offset;      // Jarak offset kamera terhadap karakter

    void Update()
    {
        // Mengatur posisi kamera agar mengikuti karakter dengan offset
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
