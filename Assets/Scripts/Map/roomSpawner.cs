using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawner : MonoBehaviour
{
    public int openSide;
    private int random;
    // 1 bottom door
    // 2 top door 
    // 3 left door
    // 4 right door

    private RoomTemplate templates;
    private bool spawned = false;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if (spawned == false)
        {
            if (openSide == 1)
            {
                random = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[random], transform.position, templates.bottomRooms[random].transform.rotation);
            }
            else if (openSide == 2)
            {
                random = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[random], transform.position, templates.topRooms[random].transform.rotation);

            }
            else if (openSide == 3)
            {
                random = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[random], transform.position, templates.leftRooms[random].transform.rotation);
            }
            else if (openSide == 4)
            {
                random = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[random], transform.position, templates.rightRooms[random].transform.rotation);
            }
            spawned = true;
        }
     }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SpawnPoint"))
        { 
            if (other.GetComponent<roomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }

    }

}
