using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public int Score { get; set; }
    public Text ScoreText;


    MenuController _menuController;



    private void Awake()
    {
        if (PlayerState.playerList == null)
        {
            PlayerState.playerList = new List<GameObject>();
        }
    }
    void Start()
    {
        _menuController = GameObject.Find("GameController").GetComponent<MenuController>();
        ScoreText = GameObject.Find("Menu").gameObject.transform.Find("ScorePanel").gameObject.transform.Find("Image").gameObject.transform.Find("ScoreText").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        SetCountScore();
    }

    public void AddPlayer(GameObject player)
    {
        PlayerState.playerList.Add(player);
        DontDestroyOnLoad(player);
        _menuController.ChangeColorPink(PlayerState.playerList.Count);
    }

    public void SetCountScore()
    {
        if (PlayerState.currentState == PlayerState.StateMenu.INGAME)
        {
            ScoreText.text = "SCORE : " + Score.ToString();
        }
    }
}
