using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> map;
    

    void Start()
    {
        LoadMap();
        for (int i = 0; i < PlayerState.playerList.Count; i++)
        {
            int x_position = i == 0 ? -12 : 12 ;

            PlayerState.playerList[i].transform.position = new Vector3(x_position, 4, 0);
        }

    }

    private void LoadMap()
    {
        System.Random random = new System.Random();

        int num = random.Next(0, map.Count);
        Instantiate(map[num], new Vector3(-12, 0, 0), new Quaternion());
        int num2 = random.Next(0, map.Count);
        Instantiate(map[num2], new Vector3(12, 0, 0), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
