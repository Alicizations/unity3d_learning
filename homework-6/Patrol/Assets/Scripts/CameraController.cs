using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 target = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, target, 5 * Time.deltaTime);
    }
}
