using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    
    

    void Start()
    {
        PlayerState.playerList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer(GameObject player)
    {
        PlayerState.playerList.Add(player);
        PlayerState.test = player;
        DontDestroyOnLoad(PlayerState.test);

        SpawnPlayer(player);
        Debug.Log("adding player ");
        Debug.Log(PlayerState.playerList.Count);
    }

    private void SpawnPlayer(GameObject player)
    {
        int x_position = 0;
        if (PlayerState.playerList.Count == 1)
        {
            x_position = 0;
        }
        else if (PlayerState.playerList.Count == 2)
        {
            x_position = 3;
        }
        player.transform.position = new Vector3(x_position, player.transform.position.y, player.transform.position.z);
    }

}
