using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformManager : MonoBehaviour
{

    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    private int pointSelected = 0;
    public bool isPressed = false;
    private bool canMovePlatform;
    public int timeStopped;


    // Use this for initialization
    void Start()
    {
        currentPoint = points[pointSelected];

    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed && !canMovePlatform)
            movePlatform();

    }

    void movePlatform()
    {

        this.transform.position = Vector3.MoveTowards(this.transform.position, currentPoint.position, moveSpeed * Time.deltaTime);

        if ((this.transform.position - currentPoint.position).magnitude <= 0.1f)
        {
            pointSelected++;
            canMovePlatform = true;
            StartCoroutine(WaitToMove(timeStopped));
        }

        if (pointSelected == points.Length)
            pointSelected = 0;

        currentPoint = points[pointSelected];

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawSphere(points[i].position, 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.transform.SetParent(this.GetComponent<Transform>());
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.transform.SetParent(null);
    }

    IEnumerator WaitToMove(float time){
        yield return new WaitForSeconds(time);
        canMovePlatform = false;
    }



}
