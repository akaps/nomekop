using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject tracked;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - tracked.transform.position;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = tracked.transform.position + offset;
    }
}
