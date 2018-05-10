using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mygame
{
    public class PatrolFactory : MonoBehaviour
    {
        public GameObject PatrolPrefab;

        private List<GameObject> used = new List<GameObject>();
        private List<GameObject> free = new List<GameObject>();

        private void Awake()
        {
            //PatrolPrefab = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Patrol"), Vector3.zero, Quaternion.identity);
            PatrolPrefab.SetActive(false);
        }

        public GameObject GetPatrol()
        {
            GameObject NewPatrol = null;
            if (free.Count > 0)
            {
                NewPatrol = free[0];
                free.Remove(free[0]);
            }
            else
            {
                NewPatrol = GameObject.Instantiate<GameObject>(PatrolPrefab, Vector3.zero, Quaternion.identity);
                NewPatrol.name = NewPatrol.GetInstanceID().ToString();
                NewPatrol.SetActive(true);
            }

            used.Add(NewPatrol);
            //NewPatrol.GetComponent<Disk>().SetLevel(Round);

            return NewPatrol;
        }

        public void FreePatrol(GameObject UsedPatrol)
        {
            if (UsedPatrol != null)
            {
                UsedPatrol.SetActive(false);
                free.Add(UsedPatrol);
                used.Remove(UsedPatrol);
            }
        }
    }
}
