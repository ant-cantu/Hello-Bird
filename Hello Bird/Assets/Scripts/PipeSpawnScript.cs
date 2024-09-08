using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;

    private LogicScript logic;
    private int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        // #include "LogicScript.cs"
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // Spawn pipes
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
            timer += Time.deltaTime;
        else
        {
            //(pipe, get position of the gameobject holding the script (spawn on top of spawner), same as spawner) 
            spawnPipe();
            timer = 0;
        }
        
    }

    void spawnPipe()
    {
        // Offset pipes
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Spawn pipe
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }

    public void checkLevel()
    {
        if (currentLevel >= 30)
            return;

        if (logic.getScore() > currentLevel)
        {
            currentLevel = logic.getScore();

            switch (currentLevel)
            {
                case 10:
                    spawnRate -= 1f;
                    break;
                case 20:
                    spawnRate -= 1f;
                    break;
                case 25:
                    spawnRate -= 1f;
                    break;
                case 30:
                    spawnRate -= .5f;
                    break;
                default:
                    break;
            }
        }

    }
}
