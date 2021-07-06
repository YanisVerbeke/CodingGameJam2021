using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject linkedBar;
    private int _speed;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (linkedBar != null)
            {
                Destroy(linkedBar);
            }
            Destroy(this.gameObject);
        }
    }
}
