using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float m_DampTime = 0.2f;
    public Transform m_target;
    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;

    private Vector3 currentPos;

    //public ArrayList currentPoss = new ArrayList();

    //public ArrayList enemyTanks = new ArrayList();

    public List<GameObject> enemyTanks = new List<GameObject>();

    private void Awake()
    {
        
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        currentPos = transform.position - m_target.position;
        //currentPoss.Add(currentPos);
        //currentPoss.Add(m_target);
    }

    private void Start()
    {
        /*int[] numbers = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

        for (int i = 0; i < 12; i++)
        {
            Debug.Log(numbers[i]);
        }*/
    }
    private void FixedUpdate()
    {
        Move();
        //var asd123 = currentPoss[0] as Transform;
        //Debug.Log(asd123.position);
        /*GameObject enemyTank = Instantiate(gameObject);
        enemyTanks.Add(enemyTank);*/
        //enemyTanks.Add(new Vector3(0, 5, 5));
    }
    private void Move()
    {
        m_DesiredPosition = m_target.position + currentPos;
        transform.position = Vector3.SmoothDamp( transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }

}

