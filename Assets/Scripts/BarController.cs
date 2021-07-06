using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public GameObject barPrefab;
    private GameObject currentBar;
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

        if(Time.time > TimeSpawnBar)
        {
            BarPosition = Random.Range(0, 2);
            Debug.Log(BarPosition);
            if (BarPosition == 0)
            {
                currentBar = Instantiate(barPrefab, new Vector3(0, 10, 0), new Quaternion());
            }
            else
            {
                currentBar = Instantiate(barPrefab, new Vector3(20, 10, 0), new Quaternion());
            }
            TimeSpawnBar = Random.Range(MinTimeSpawn, MaxTimeSpawn) + Time.time;
        }
            
    
    }
}
