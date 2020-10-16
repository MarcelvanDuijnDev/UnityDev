using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Health
    [Header("Player Stats")]
    public float health;
    public float armor, thirst, hunger;
    [SerializeField]private float m_ThirstDecreaseRate, m_HungerDecreaseRate;
    [SerializeField]private float maxHealth, maxArmor;
    //Movement
    [Header("Movement")]
    public float normalSpeed;
    public float sprintSpeed;
    [SerializeField]private float jumpSpeed;
    [SerializeField]private float gravity;
    private float gravityReset;
    [Header("Camera's")]
    [SerializeField]private GameObject fps_camera;
    [SerializeField]private GameObject thirdperson_Camera;
    [SerializeField]private GameObject m_FlashLight;
    private bool camera_Perspective;
    private Vector3 moveDirection = Vector3.zero;
    //Look around
    [Header("Camera Settings")]
    public float cameraSensitivity;
    [SerializeField]private Transform head,cameraObj;
    private bool headMode;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float speed;
    private float dpadHorizontal, dpadVertical;

    //Upgrades
    private float m_Healht_Upgrade;
    private float m_Armor_Upgrade;
    private float m_HealthRegen_Upgrade;
    private float m_NormalSpeed_Upgrade;
    private float m_SprintSpeed_Upgrade;
    private float m_JumpHeight_Upgrade;

    //
    CharacterController controller;

    [Header("Tools")]
    [SerializeField]private GameObject m_Exe;
    [HideInInspector]public int m_ToolSelected;

    [Header("Watch")]
    [SerializeField]private GameObject watch;
    private bool lockPlayer;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gravityReset = gravity;
        controller = GetComponent<CharacterController>();
    }

    void Update() 
    {
        //Items
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (watch.gameObject.activeSelf)
            {
                watch.SetActive(false);
                lockPlayer = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                watch.SetActive(true);
                lockPlayer = true;
                Cursor.lockState = CursorLockMode.None;
                m_ToolSelected = 0;
                if (m_Exe.gameObject.activeSelf)
                {
                    m_Exe.SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            watch.SetActive(false);
            lockPlayer = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (m_Exe.gameObject.activeSelf)
            {
                m_Exe.SetActive(false);
                m_ToolSelected = 0;
            }
            else
            {
                m_Exe.SetActive(true);
                m_ToolSelected = 1;
            }
        }

        if (health <= 0)
        {
            Debug.Log("dead");
        }
        if (health <= maxHealth)
        {
            health += m_HealthRegen_Upgrade * Time.deltaTime;
        }
        //dpadHorizontal = Input.GetAxis("DPadHorizontal");
        //dpadVertical = Input.GetAxis("DPadVertical");
        if (Input.GetKeyDown(KeyCode.B)) //|| Input.GetButtonDown("Select"))
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
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!m_FlashLight.activeSelf)
            {
                m_FlashLight.SetActive(true);
            }
            else
            {
                m_FlashLight.SetActive(false);
            }
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

        if (!lockPlayer)
        {
            //Rotation
            rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
            //rotationX += Input.GetAxis("RightJoystickHorizontal") * cameraSensitivity * Time.deltaTime;
            //rotationY += -Input.GetAxis("RightJoystickVertical") * cameraSensitivity * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            head.transform.localRotation = Quaternion.AngleAxis(rotationY, Vector3.left);

            //Movement
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump")) //|| Input.GetButton("AButton"))
                    moveDirection.y = jumpSpeed + m_JumpHeight_Upgrade;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }


        //Sprint
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed + m_SprintSpeed_Upgrade;
        }
        else
        {
            speed = normalSpeed + m_NormalSpeed_Upgrade;
        }
        //Upgrades
        maxHealth = 100 + m_Healht_Upgrade;
        maxArmor = 100 + m_Armor_Upgrade;
        jumpSpeed = 8 + m_JumpHeight_Upgrade;

        //Thirst / Hunger
        thirst -= m_ThirstDecreaseRate * Time.deltaTime;
        hunger -= m_HungerDecreaseRate * Time.deltaTime;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "AmmoPickup")
        {
            AddAmmo(other.gameObject);
        }
        if(other.gameObject.tag == "HealthPickup")
        {
            AddHealth(other.gameObject);
        }
        if(other.gameObject.tag == "ArmorPickup")
        {
            AddArmor(other.gameObject);
        }

        //Water 
        if (other.gameObject.transform.name == "Water")
        {
            gravity = -10;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.name == "Water")
        {
            
            gravity = gravityReset;
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

    public void AddThirst(float amount)
    {
        thirst += amount;
        if(thirst > 100)
        {
            thirst = 100;
        }
    }

    public void AddHunger(float amount)
    {
        hunger += amount;
        if(hunger > 100)
        {
            hunger = 100;
        }
    }

    public void Upgrade(float healhtUpgrade,float armorUpgrade,float healthRegenUpgrade ,float normalSpeedUpgrade,float sprintSpeedUpgrade,float jumpHeightUpgrade)
    {
        m_Healht_Upgrade = healhtUpgrade;
        m_Armor_Upgrade = armorUpgrade;
        m_HealthRegen_Upgrade = healthRegenUpgrade;
        m_NormalSpeed_Upgrade = normalSpeedUpgrade;
        m_SprintSpeed_Upgrade = sprintSpeedUpgrade;
        m_JumpHeight_Upgrade = jumpHeightUpgrade;
    }
}
