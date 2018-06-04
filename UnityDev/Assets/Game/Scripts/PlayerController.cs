﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Health
    public float health, armor;
    [SerializeField]private float maxHealth, maxArmor;
    //Movement
    [SerializeField]private float normalSpeed, sprintSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]private float gravity;
    [SerializeField]private GameObject fps_camera, thirdperson_Camera;
    private bool camera_Perspective;
    private Vector3 moveDirection = Vector3.zero;
    //Look around
    public float cameraSensitivity;
    [SerializeField]private Transform head,cameraObj;
    private bool headMode;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float speed;
    private float dpadHorizontal, dpadVertical;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() 
    {
        dpadHorizontal = Input.GetAxis("DPadHorizontal");
        dpadVertical = Input.GetAxis("DPadVertical");
        if (Input.GetKeyDown(KeyCode.B) || Input.GetButtonDown("Select"))
        {
            camera_Perspective = !camera_Perspective;
        }
        if(dpadVertical == 1)
        {
            camera_Perspective = false;
        }
        if(dpadVertical == -1)
        {
            camera_Perspective = true;
        }


        if (!camera_Perspective)
        {
            fps_camera.SetActive(true);
            thirdperson_Camera.SetActive(false);
        }
        else
        {
            fps_camera.SetActive(false);
            thirdperson_Camera.SetActive(true);
        }

        //Look around
        rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotationX += Input.GetAxis("RightJoystickHorizontal") * cameraSensitivity * Time.deltaTime;
        rotationY += -Input.GetAxis("RightJoystickVertical") * cameraSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp (rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        head.transform.localRotation = Quaternion.AngleAxis(rotationY, Vector3.left);

        //Movement
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump") || Input.GetButton("AButton"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);


        //Sprint
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = normalSpeed;
        }
    }

    public void SetValues(float setPlayerSpeed, float setSprintSpeed)
    {
        normalSpeed = setPlayerSpeed;
        sprintSpeed = setSprintSpeed;
    }

    public void DoDamage(float damageAmount)
    {
        float damage = 0;
        if(armor > damageAmount)
        {
            armor -= damageAmount;
        }
        else
        {
            damage = damageAmount - armor;
            health -= damage;
            armor = 0;
        }
        if(health <= 0)
        {
            Debug.Log("dead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "AmmoPickup")
        {
            AddAmmo(other.gameObject);
            Debug.Log("1");
        }
        if(other.gameObject.tag == "HealthPickup")
        {
            AddHealth(other.gameObject);
        }
        if(other.gameObject.tag == "ArmorPickup")
        {
            AddArmor(other.gameObject);
        }
    }

    private void AddHealth(GameObject otherObj)
    {
        if (health <= maxHealth)
        {
            float amount = otherObj.gameObject.GetComponent<Pickup>().pickupAmount;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                health += amount;
            }
            otherObj.gameObject.SetActive(false);
        }
    }

    private void AddArmor(GameObject otherObj)
    {
        if (armor <= maxArmor)
        {
            float amount = otherObj.gameObject.GetComponent<Pickup>().pickupAmount;
            if(amount > maxArmor)
            {
                armor = maxArmor;
            }
            else
            {
                armor += amount;
            }
            otherObj.gameObject.SetActive(false);
        }
    }

    private void AddAmmo(GameObject otherObj)
    {
        float amount = otherObj.gameObject.GetComponent<Pickup>().pickupAmount;
        Weapon weaponScript = this.gameObject.GetComponentInChildren<Weapon>();
        weaponScript.currentAmmo += amount;
        otherObj.gameObject.SetActive(false);
    }
}
