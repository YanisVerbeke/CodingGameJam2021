using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Sprite> ArrayOfSkin;
    [SerializeField] List<string> ArrayOfNameSkin;
    AudioSource audioSource;

    void Start()
    {
        Debug.Log("PlayerState.currentState");
        Debug.Log(PlayerState.currentState);
        if (PlayerState.currentState == PlayerState.StateMenu.INMENU)
        {
            PlayerState.currentState = PlayerState.StateMenu.INMENU;
        }
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

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

            SceneManager.LoadScene(sceneBuildIndex: 2);
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
        //GameObject _menuController = GameObject.Find("GameController").GetComponent<MenuController>().gameObject;
        GameObject _menuController = GameObject.Find("Menu").GetComponent<MenuController>().gameObject;
        bool isActive = _menuController.transform.Find("Options").gameObject.activeInHierarchy ? false : true;
        _menuController.transform.Find("Options").gameObject.SetActive(isActive);
        Pause();
        PlayerState.currentState = PlayerState.currentState == PlayerState.StateMenu.INPAUSE ? PlayerState.StateMenu.INGAME : PlayerState.StateMenu.INPAUSE;


    }

    public void DisplayMenu()
    {
        GameObject _menuController = GameObject.Find("Menu").GetComponent<MenuController>().gameObject;
        _menuController.transform.Find("Options").gameObject.SetActive(false);
        _menuController.transform.Find("Die").gameObject.SetActive(false);
        Pause();
        PlayerState.currentState = PlayerState.StateMenu.INGAME;
    }

    public void DieMenu()
    {
        GameObject _menuController = GameObject.Find("Menu").GetComponent<MenuController>().gameObject;
        bool isActive = _menuController.transform.Find("Die").gameObject.activeInHierarchy ? false : true;
        _menuController.transform.Find("Die").gameObject.SetActive(isActive);
        Pause();
        PlayerState.currentState = PlayerState.StateMenu.INPAUSE;

    }

    private void Pause()
    {
        //Time.timeScale = Time.timeScale == 0.0f ? 1.0f : 0.0f;
        if (Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
            audioSource.UnPause();
        }
        else
        {
            Time.timeScale = 0.0f;
            audioSource.Pause();
        }
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
