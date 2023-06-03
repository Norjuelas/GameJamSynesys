using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmState : MonoBehaviour
{

    public ConeOfVision script;
    public GameObject SpotLight1;
    public GameObject SpotLight2;
    public float scareTimer = 0f;
    void Update()
    {
        if(script.canSeeTarget){
            SpotLight1.GetComponent<Light>().range = 0;
        }
    }
}
