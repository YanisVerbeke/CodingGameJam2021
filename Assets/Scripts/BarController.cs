using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public GameObject barPrefab;
    private GameObject currentBar;

    // Start is called before the first frame update
    void Start()
    {
        currentBar = Instantiate(barPrefab, new Vector3(0, 10, 0), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBar.transform.position.y < -1)
        {
            currentBar = Instantiate(barPrefab, new Vector3(0, 10, 0), new Quaternion());
        }   
    }
}
