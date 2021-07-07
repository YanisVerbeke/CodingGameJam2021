using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject keyPrefab;
    private GameObject currentObstacle;
    private GameObject currentKey;
    public int MinTimeSpawn { get; set; }
    public int MaxTimeSpawn { get; set; }
    private float TimeSpawnBar;
    private int BarPosition;

    public float speed { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        TimeSpawnBar = Time.time;
        speed = 3;
        MaxTimeSpawn = 6;
        MinTimeSpawn = 2;
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
            obstacle.Speed = (int)speed;
            key.linkedObstacle = currentObstacle;
            key.Speed = (int)speed;

            TimeSpawnBar = Random.Range(MinTimeSpawn, MaxTimeSpawn) + Time.time;
        }
    }
}
