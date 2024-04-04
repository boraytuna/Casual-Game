using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGroundX : MonoBehaviour
{
    Vector3 originalPosition;

    [SerializeField]
    private float distanceX = 5f; 

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private int direction = 1;


    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float movementX = Mathf.Sin(Time.time * speed) * distanceX;
        transform.position = originalPosition + new Vector3(movementX * direction, 0, 0);
    }

    //fix here
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player landed");
            other.transform.parent.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player exit");
            other.transform.parent.SetParent(null);
        }
    }


}
