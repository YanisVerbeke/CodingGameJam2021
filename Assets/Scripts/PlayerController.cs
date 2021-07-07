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
        DontDestroyOnLoad(player);
    }



}
