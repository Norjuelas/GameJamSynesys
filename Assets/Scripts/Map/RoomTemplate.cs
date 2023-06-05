using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject closedRoom;
    public GameObject openRoom;

    public List<GameObject> rooms;

    public GameObject Object1;

    private void Start(){
        
        Invoke("SpawnEnemies",3f);

    }
    void SpawnEnemies(){
        Instantiate(Object1,rooms[rooms.Count-1].transform.position,Quaternion.identity);
    }
}
