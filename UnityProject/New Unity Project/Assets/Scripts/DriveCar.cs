using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    Vector3 PointStart;
    Vector3 PointEnd;
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        PointStart = transform.position;

        if(transform.position.x > 0){
            PointEnd = new Vector3(-240.0f, transform.position.y, transform.position.z);
            speed = 40.0f;
}
        if(transform.position.x < 0){
            PointEnd = new Vector3(200.0f, transform.position.y, transform.position.z);
            speed = 30.0f;
        }


    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.Lerp(transform.position, PointEnd, Time.deltaTime * speed);
        transform.position = Vector3.MoveTowards(transform.position, PointEnd, speed * Time.deltaTime);

        if (Vector3.Magnitude(transform.position - PointEnd) < 0.01) {
            transform.position = PointStart;           
        }


    }
}
