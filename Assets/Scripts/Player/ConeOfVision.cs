using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOfVision : MonoBehaviour
{
    public float VisionRange;
    [Range(0,360)]
    public float VisionAngle;
    public GameObject EnemyRef;
    public LayerMask VisionObstructingLayer;
    public LayerMask VisionTargetLayer;
    public bool canSeeTarget;

    // Start is called before the first frame update
    void Start()
    {
        EnemyRef = GameObject.FindGameObjectWithTag("enemy");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine(){
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);
        while(true){
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck(){
        Collider[] RangeCheck = Physics.OverlapSphere(transform.position, VisionRange, VisionTargetLayer);
        if(RangeCheck.Length !=0){
            Transform target = RangeCheck[0].transform;
            Vector3 DirectionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, DirectionToTarget) < VisionAngle/2){
                float DistanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, DirectionToTarget, DistanceToTarget, VisionObstructingLayer)){
                    canSeeTarget = true;
                }else{
                    canSeeTarget = false;
                }
            }else{
                canSeeTarget = false;
            }
        }else if(canSeeTarget){
            canSeeTarget = false;
        }
    }
}