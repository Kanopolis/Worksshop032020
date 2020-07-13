using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Controller : MonoBehaviour
{
    //Rigidbody fürs Movement
    private Rigidbody rb;

    //Move Direction fürs Update
    private Vector3 moveDir;
    [SerializeField]
    private float mMoveSpeed;

    /// <summary>
    /// Init... Du kennst das Spiel...
    /// </summary>
    private void Awake()
    {
        //Rigidbody GET
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //GetInpus
        float inX = 0;
        if (Input.GetKey(KeyCode.D))
            inX = 1;
        else if(Input.GetKey(KeyCode.A))
            inX = -1;

        float inY = 0;
        if (Input.GetKey(KeyCode.W))
            inY = 1;
        else if (Input.GetKey(KeyCode.S))
            inY = -1;

        //Mach nen Vektor draus
        moveDir = this.transform.right * inX + this.transform.forward * inY;

        //Normalisieren
        moveDir.Normalize();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * mMoveSpeed;
    }
}
