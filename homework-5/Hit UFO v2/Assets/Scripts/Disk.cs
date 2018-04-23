using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mygame
{
    public class Disk : MonoBehaviour
    {
        public float size;
        public Color color;
        public float speed;
        public Vector3 direction;

        public void SetLevel(int Round = 1)
        {
            this.SetRandomSize(Round);
            this.SetRandomColor();
            this.SetRandomSpeed(Round);
            this.SetRandomDireation();
            this.gameObject.SetActive(true);
        }

        private void SetRandomColor()
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);
            this.color = new Color(r, g, b);
            this.gameObject.transform.GetComponent<Renderer>().material.color = this.color;
        }

        private void SetRandomSize(int Round = 1)
        {
            float Level = 0.1f * (Round - 1) + 1;
            Level *= Level;
            this.size = Random.Range(0.7f / Level, 1f);
            this.gameObject.transform.localScale = (new Vector3(3.5f, 0.4f, 3.5f))*this.size;
            this.gameObject.transform.rotation = Quaternion.identity;
        }

        private void SetRandomSpeed(int Round = 1)
        {
            this.speed = Random.Range(4f,6f) * (0.09f * (Round - 1) + 1);
        }

        private void SetRandomDireation()
        {
            this.direction = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(2f, 3f), Random.Range(3f, 6f));
        }
    }
}