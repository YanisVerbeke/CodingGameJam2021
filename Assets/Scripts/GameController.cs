using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        for (int i = 0; i < PlayerState.playerList.Count; i++)
        {
            int x_position = i == 0 ? -8 : 8 ;

            PlayerState.playerList[i].transform.position = new Vector3(x_position, 2, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
