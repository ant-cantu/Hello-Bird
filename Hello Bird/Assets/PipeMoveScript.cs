using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 7;
    public float deadZone = -55;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                            //add to its current pos //vector3 because 3 fields //multiplication happens the same no matter the framerate
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x <= deadZone)
            Destroy(gameObject);
    }
}
