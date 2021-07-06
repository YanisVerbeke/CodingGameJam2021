using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    MenuController _menuController;
    

    void Start()
    {
        PlayerState.playerList = new List<GameObject>();
        _menuController = GameObject.Find("MenuController").GetComponent<MenuController>();

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
