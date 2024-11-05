using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    SpriteRenderer sprite;
    private GameObject grabbedObject;
    private int layerIndex;
    private Vector2 facePosisition;
    
    private void Start(){
        sprite = GetComponent<SpriteRenderer>();
        layerIndex = LayerMask.NameToLayer("Grabable");
        facePosisition = transform.position;
    }
    
    private void Update(){
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, facePosisition, rayDistance);
    
        if(hitInfo.collider!=null && hitInfo.collider.gameObject.layer == layerIndex){
            if(Input.GetKey(KeyCode.P) && grabbedObject == null){
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }else if(Input.GetKey(KeyCode.P)){
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
