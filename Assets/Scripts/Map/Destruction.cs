 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    private RoomTemplate templates;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(templates.openRoom, transform.position, Quaternion.identity);
    }

}
