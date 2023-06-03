using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawner : MonoBehaviour
{
    public int openSide;

    // 1 bottom door
    // 2 top door 
    // 3 left door
    // 4 right door

    private roomTemplate templates;
    private int salaRandom;
    private bool spawned = false;

 

    void Start()
    {
        templates = GameObject.FindGameObjectsWithTag("Rooms").GetComponent<roomTemplate>();
        Invoke("spawn",0,1f);
        
    
    }
    void Spawn()
    {
        if (openSide == 1)
        {
            salaRandom = Random.Range(0, templates.bottomRooms.length);
            Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
        }
        else if (openSide == 2)
        {
            salaRandom = Random.Range(0, templates.topRooms.length);
            Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);

        }
        else if (openSide == 3)
        {
            salaRandom = Random.Range(0, templates.leftRooms.length);
            Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);

        }
        else if (openSide == 4)
        {
            salaRandom = Random.Range(0, templates.rightRooms.length);
            Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
 
        }
        spawned = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spawnPoint"))
        {
            Destroy(gameObjects);
        }
    }
}}
