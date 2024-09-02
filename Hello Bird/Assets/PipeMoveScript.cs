using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 10; //7
    [SerializeField] private float deadZone = -55;

    //private int currentLevel = 0;

    private LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
                            //add to its current pos //vector3 because 3 fields //multiplication happens the same no matter the framerate
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x <= deadZone)
            Destroy(gameObject);

        /*
        if ((logic.getScore() >= 10 && logic.getScore() < 20) && currentLevel < 1)
        {
            currentLevel++;
            moveSpeed += 5;
            Debug.Log("Movement Speed: " + moveSpeed.ToString() + ", Current Level: " + currentLevel.ToString());
        }
        else if ((logic.getScore() >= 20 && logic.getScore() < 30) && currentLevel < 2)
        {
            currentLevel++;
            moveSpeed += 5;
            Debug.Log("Movement Speed: " + moveSpeed.ToString() + ", Current Level: " + currentLevel.ToString());
        }
        else if(logic.getScore() >= 40 && currentLevel < 3)
        {
            currentLevel++;
            moveSpeed += 5;
            Debug.Log("Movement Speed: " + moveSpeed.ToString() + ", Current Level: " + currentLevel.ToString());
        }
        */
    }
}
