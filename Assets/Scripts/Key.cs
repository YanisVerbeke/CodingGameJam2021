using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject linkedObstacle;
    public int Speed { get; set; }
    private PlayerController playerController;
    private ObstacleController obstacleController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("GameController").GetComponent<PlayerController>();
        obstacleController = GameObject.Find("GameController").GetComponent<ObstacleController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.y < -2)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController.Score += 100;
            Debug.Log("Le score : ");
            Debug.Log(playerController.Score);
            if(playerController.Score % 500 == 0)
            {
                obstacleController.speed += 1;
            }
            if (playerController.Score % 1000 == 0 && obstacleController.speed > 1)
            {
                obstacleController.MaxTimeSpawn -= 1;
            }
            if(playerController.Score == 4000)
            {
                obstacleController.MinTimeSpawn -= 1;
            }
            if (linkedObstacle != null)
            {
                Destroy(linkedObstacle);
            }
            Destroy(this.gameObject);

        }
    }
}