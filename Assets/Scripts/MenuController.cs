using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Sprite> ArrayOfSkin;
    [SerializeField] List<string> ArrayOfNameSkin;
    [SerializeField] AudioSource audioSource;

    private PlayerController playerController;
    private int _displayedScore;
    private bool _isDisplayingScore;
    GameObject _menuController;

    void Start()
    {
        Debug.Log("PlayerState.currentState");
        Debug.Log(PlayerState.currentState);
        playerController = GetComponent<PlayerController>();
        if (PlayerState.currentState == PlayerState.StateMenu.INMENU)
        {
            PlayerState.currentState = PlayerState.StateMenu.INMENU;
        }
        _displayedScore = 0;
        _isDisplayingScore = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDisplayingScore && _menuController != null)
        {
            if (_displayedScore < playerController.Score)
            {
                _displayedScore += 10;
            }
            Debug.Log(_menuController.transform.Find("ScoreEndText"));
            _menuController.transform.Find("Die").gameObject.transform.Find("ScoreEndText").gameObject.GetComponent<Text>().text = _displayedScore.ToString();
        }
    }


    public void StartGame()
    {

        Debug.Log("Start");
        Debug.Log(PlayerState.playerList.Count);
        if (PlayerState.playerList.Count >= 1)
        {
            Debug.Log("Succes");

            //PlayerState.playerList[0];
            PlayerState.currentState = PlayerState.StateMenu.INGAME;

            SceneManager.LoadScene(sceneBuildIndex: 1);
        }

    }

    public void ChangeColorPink(int id_ping)
    {
        id_ping--;
        Debug.Log("I Ping" + id_ping);

        GameObject.Find("PingConnected_" + id_ping).GetComponent<Text>().color = Color.green;
        GameObject.Find("Text_left_" + id_ping).GetComponent<Text>().text = "LB";
        GameObject.Find("Text_right_" + id_ping).GetComponent<Text>().text = "RB";
        GameObject.Find("Text_press_" + id_ping).GetComponent<Text>().text = "";
    }

    public void StartMenu()
    {
        Debug.Log("pressed");
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
        //GameObject _menuController = GameObject.Find("GameController").GetComponent<MenuController>().gameObject;
        GameObject _menuController = GameObject.Find("Menu").GetComponent<MenuController>().gameObject;
        bool isActive = _menuController.transform.Find("Options").gameObject.activeInHierarchy ? false : true;
        _menuController.transform.Find("Options").gameObject.SetActive(isActive);
        Pause();
        PlayerState.currentState = PlayerState.currentState == PlayerState.StateMenu.INPAUSE ? PlayerState.StateMenu.INGAME : PlayerState.StateMenu.INPAUSE;
    }

    public void DisplayMenu()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
        GameObject _menuController = GameObject.Find("Menu").GetComponent<MenuController>().gameObject;
        _menuController.transform.Find("Options").gameObject.SetActive(false);
        _menuController.transform.Find("Die").gameObject.SetActive(false);
        Pause();
        PlayerState.currentState = PlayerState.StateMenu.INGAME;
    }

    public void DieMenu()
    {
        _menuController = GameObject.Find("Menu").GetComponent<MenuController>().gameObject;
        bool isActive = _menuController.transform.Find("Die").gameObject.activeInHierarchy ? false : true;
        _menuController.transform.Find("Die").gameObject.SetActive(isActive);
        _displayedScore = 0;
        _isDisplayingScore = true;
        Pause();
        PlayerState.currentState = PlayerState.StateMenu.INPAUSE;

    }

    private void Pause()
    {
        Time.timeScale = Time.timeScale == 0.0f ? 1.0f : 0.0f;
    }

    public void Restart()
    {
        PlayerState.playerList = new List<GameObject>();
        foreach (var player in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(player);
        }
        PlayerState.currentState = PlayerState.StateMenu.INMENU;
        SceneManager.LoadScene(sceneBuildIndex: 0);
        Time.timeScale = 1.0f;

    }

    public void Exit()
    {
        Application.Quit();
    }

    public int ChangeSkin(int nextSelected, int idPlayer)
    {
        Debug.Log("idPlayer : ");
        Debug.Log(idPlayer);
        Transform player = PlayerState.playerList[idPlayer].transform;

        if (nextSelected >= ArrayOfSkin.Count)
        {
            nextSelected = 0;
        }
        else if (nextSelected <= -1)
        {
            nextSelected = ArrayOfSkin.Count - 1;
        }
        GameObject.Find("Image_player_" + idPlayer).GetComponent<Image>().sprite = ArrayOfSkin[nextSelected];
        GameObject.Find("Text_press_" + idPlayer).GetComponent<Text>().text = ArrayOfNameSkin[nextSelected];
        ChangeStateChild(player);
        player.GetChild(nextSelected).gameObject.SetActive(true);

        PlayerState.playerList[idPlayer].GetComponent<Player>().animator = PlayerState.playerList[idPlayer].transform.GetChild(nextSelected).GetComponent<Animator>();

        return nextSelected;
    }


    private void ChangeStateChild(Transform parentObject)
    {
        foreach (Transform child in parentObject)
        {
            child.gameObject.SetActive(false);
        }
    }

}
