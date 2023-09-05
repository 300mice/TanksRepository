using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class TankController : MonoBehaviour
{
    public float m_Speed = 12f; // How fast the tank moves forward and back
    public float m_TurnSpeed = 180f; // How fast the tank turns in degrees per second
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue; // The current value of the movement input
    private float m_TurnInputValue; // the current value of the turn input

    public GameObject myPrefab;

    public int FrameRate = 60;


    private bool isMoving = false;
    private Vector3 targetPosition;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Application.targetFrameRate = FrameRate;
    }
    private void OnEnable()
    {

        // when the tank is turned on, make sure it is not kinematic
        m_Rigidbody.isKinematic = false;
        // also reset the input values
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
        StreamReader streamreader = new StreamReader("asd123");

    }



    private void OnDisable()
    {
        // when the tank is turned off, set it to kinematic so it stops moving
        m_Rigidbody.isKinematic = true;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle touch phases
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Raycast to find the touch position in the world
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        targetPosition = hit.point;
                        isMoving = true;
                    }
                    break;

                case TouchPhase.Ended:
                    isMoving = false;
                    break;
            }

        }

        if (isMoving)
        {
            float speed = 5f; // Adjust this to control movement speed
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

    }
    private void FixedUpdate()
    {
        

        //Instantiate(myPrefab, transform.position + new Vector3(0,20,0), Quaternion.identity);

    }
    /*rivate void Move()
    {
        // create a vector in the direction the tank is facing with a magnitude
        // based on the input, speed and time between frames
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed *
        Time.deltaTime;
        // Apply this movement to the rigidbody's position
        m_Rigidbody.AddForce( movement * 250); //you need a lot more force than the original movement speed
    }*/
    private void Turn()
    {
        // determine the number of degrees to be turned based on the input,
        // speed and time between frames
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        // make this into a rotation in the y axis
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        // apply this rotation to the rigidbody's rotation
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

}
