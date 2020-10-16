using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour 
{
    private bool jumpActive;
    [SerializeField]private Vector3 speed;
    public float testing;
    private GameObject obj;
    CharacterController objCC;
    private Vector3 resetSpeed;

    void Start()
    {
        resetSpeed = speed;
    }

    void Update()
    {
        if (jumpActive)
        {
            Vector3 test = new Vector3(speed.x, speed.y, speed.z);
            speed.y -= testing * Time.deltaTime;
            objCC = obj.gameObject.GetComponent<CharacterController>();

            speed.y -= 10 * Time.deltaTime;
            objCC.Move(speed * Time.deltaTime);

            if (speed.y <= 0)
            {
                speed = resetSpeed;
                jumpActive = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "Player")
        {
            obj = other.gameObject;
            jumpActive = true;
        }
    }
}
