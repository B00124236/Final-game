using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float pace = 5.0f;
    private float zDestroy = -10.0f;
    private Rigidbody objectsRb;

    // Start is called before the first frame update
    void Start()
    {
        objectsRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectsRb.AddForce(Vector3.forward * -pace);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
 }
  

   
