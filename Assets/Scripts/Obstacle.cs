using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject linkedKey;
    public int Speed { get; set; }

    private MenuController _menuController;

    // Start is called before the first frame update
    void Start()
    {
        _menuController = GameObject.Find("GameController").GetComponent<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * Speed);

        if (transform.position.y < -2)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            _menuController.DieMenu();
            //Destroy(other.gameObject);
        }
    }
}
