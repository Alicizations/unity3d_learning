using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        if (player == null)
        {
            return;
        }
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        Vector3 target = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, target, 5 * Time.deltaTime);
    }
}
