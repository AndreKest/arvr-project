using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routToGo;
    private float tParam;
    private Vector3 ObjectPosition;
    private float speedModifier;
    private bool coroutineAllowed;


    // Start is called before the first frame update
    void Start()
    {
        routToGo = 0;
        tParam = 0f;
        speedModifier = 0.1f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed == true) {
            StartCoroutine(GoByTheRoute(routToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNumber) {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1) {
            tParam += Time.deltaTime * speedModifier;

            ObjectPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            transform.LookAt(ObjectPosition);
            transform.position = ObjectPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        routToGo += 1;

        if (routToGo > routes.Length - 1) {
            routToGo = 0;
        }

        coroutineAllowed = true;
        
    }
}
