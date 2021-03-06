using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject linkedObstacle;
    public int Speed { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (linkedObstacle != null)
            {
                Destroy(linkedObstacle);
            }
            Destroy(this.gameObject);
        }
    }
}