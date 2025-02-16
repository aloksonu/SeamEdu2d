using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CandyCatch
{
    public class CandySpawner : MonoBehaviour
    {
        [SerializeField] float maxX;
        [SerializeField] float spawanInterval;
        public GameObject[] candies;

        public static CandySpawner instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            StartSpawanCandies();
        }

        // Update is called once per frame
        void Update()
        {

        }


        void SpawnCandy()
        {
            int rand = Random.Range(0, candies.Length);

            float randomX = Random.Range(-maxX, maxX);
            Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

            Instantiate(candies[rand], randomPos, transform.rotation);
        }

        IEnumerator SpawanCandies()
        {
            yield return new WaitForSeconds(2);
            while (true)
            {
                SpawnCandy();
                yield return new WaitForSeconds(spawanInterval);
            }
        }


        public void StartSpawanCandies()
        {
            StartCoroutine("SpawanCandies");
        }
        public void StopSpawanCandies()
        {
            StopCoroutine("SpawanCandies");
        }
    }
}
