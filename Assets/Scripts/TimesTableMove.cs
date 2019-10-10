using UnityEngine;
using System.Collections;
public class TimesTableMove : MonoBehaviour
{
    public Transform farEnd;
    //private Vector3 frometh;
    //private Vector3 untoeth;
    //private float secondsForOneLength = 20f;
    float speed = 60f; 

    void Start()
    {
        //frometh = transform.position;
        //untoeth = farEnd.position;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, farEnd.position, step);
    }
}
