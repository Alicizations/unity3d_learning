using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{
    public class PhysisActionManager : MonoBehaviour, IActionManager  {

        public void PlayDisk(GameObject disk, Vector3 initPosition)
        {
            Debug.Log(disk);
            disk.transform.GetComponent<Rigidbody>().useGravity = true;
            disk.transform.position = initPosition;
            disk.transform.GetComponent<Rigidbody>().velocity = disk.GetComponent<Disk>().direction * disk.GetComponent<Disk>().speed;
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}