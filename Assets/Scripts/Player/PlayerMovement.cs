using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float _rotationSpeed = 180;

    private Vector3 rotation;

    public bool IsRunning;

    public float Stamina = 100f;
    private bool StaminaCooldown = false;

    public float CooldownTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        IsRunning = Input.GetButton("Run");

        float z = Input.GetAxis("Vertical");
        if(z < 0){
            z = z/2f;
        }
        if(z > 0 && IsRunning && Stamina > 0f){
            z = z*1.8f;
            Stamina = Stamina - 2;
            StaminaCooldown = true;
            CooldownTime = 10f;
        }

        if(StaminaCooldown && !IsRunning){
            CooldownTime = CooldownTime - 1;
        }
        if(CooldownTime < 0 && Stamina < 100){
            StaminaCooldown = false;
            Stamina = Stamina + 1;
        }

        Vector3 move = transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        this.transform.Rotate(this.rotation);
    }
}
