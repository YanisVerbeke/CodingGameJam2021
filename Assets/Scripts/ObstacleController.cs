using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject keyPrefab;
    private GameObject currentObstacle;
    private GameObject currentKey;
    [SerializeField] int MinTimeSpawn;
    [SerializeField] int MaxTimeSpawn;
    private float TimeSpawnBar;
    private int BarPosition;



    // Start is called before the first frame update
    void Start()
    {
        TimeSpawnBar = Time.time;
        //currentBar = Instantiate(barPrefab, new Vector3(0, 10, 0), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > TimeSpawnBar)
        {
            BarPosition = Random.Range(0, 10000);
            Debug.Log(BarPosition);
            if (BarPosition < 5000)
            {
                currentObstacle = Instantiate(obstaclePrefab, new Vector3(-8, 19, 0), new Quaternion());
                currentKey = Instantiate(keyPrefab, new Vector3(Random.Range(2, 15), 20, 0), new Quaternion());
            }
            else
            {
                currentObstacle = Instantiate(obstaclePrefab, new Vector3(8, 19, 0), new Quaternion());
                currentKey = Instantiate(keyPrefab, new Vector3(Random.Range(-14, -1), 20, 0), new Quaternion());
            }
            Obstacle obstacle = currentObstacle.GetComponent<Obstacle>();
            Key key = currentKey.GetComponent<Key>();
            obstacle.linkedKey = currentKey;
            obstacle.Speed = 3;
            key.linkedObstacle = currentObstacle;
            key.Speed = 3;

            TimeSpawnBar = Random.Range(MinTimeSpawn, MaxTimeSpawn) + Time.time;
        }
    }
}
