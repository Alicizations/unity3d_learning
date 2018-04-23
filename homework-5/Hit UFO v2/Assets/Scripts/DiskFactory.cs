using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mygame
{
    public class DiskFactory : MonoBehaviour
    {
        public GameObject DiskPrefab;

        private List<GameObject> used = new List<GameObject>();
        private List<GameObject> free = new List<GameObject>();

        private void Awake()
        {
            DiskPrefab = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("DiskPrefab"), Vector3.zero, Quaternion.identity);
            DiskPrefab.SetActive(false);
        }

        public GameObject GetDisk(int Round)
        {
            GameObject NewDisk = null;
            if (free.Count > 0)
            {
                NewDisk = free[0];
                free.Remove(free[0]);
            }
            else
            {
                NewDisk = GameObject.Instantiate<GameObject>(DiskPrefab, Vector3.zero, Quaternion.identity);
                NewDisk.name = NewDisk.GetInstanceID().ToString();
            }

            // 设置UFO难度
            NewDisk.GetComponent<Disk>().SetLevel(Round);

            return NewDisk;
        }

        public void FreeDisk(GameObject UsedDisk)
        {
            if (UsedDisk != null)
            {
                UsedDisk.SetActive(false);
                free.Add(UsedDisk);
                used.Remove(UsedDisk);
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
