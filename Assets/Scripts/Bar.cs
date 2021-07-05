using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float speed;
    public GameObject labar;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(labar, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.down * Time.deltaTime);
    }
}
