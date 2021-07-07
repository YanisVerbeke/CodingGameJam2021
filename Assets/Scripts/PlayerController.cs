using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public int Score { get; set; }


    MenuController _menuController;



    private void Awake()
    {
        PlayerState.playerList = new List<GameObject>();

    }
    void Start()
    {
        _menuController = GameObject.Find("GameController").GetComponent<MenuController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer(GameObject player)
    {
        PlayerState.playerList.Add(player);
        DontDestroyOnLoad(player);
        _menuController.ChangeColorPink(PlayerState.playerList.Count);
    }
}
