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


    void Start()
    {
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
            SceneManager.LoadScene(sceneBuildIndex: 3);
        }

    }

    public void ChangeColorPink(int id_ping)
    {
        Debug.Log("I Ping");

        GameObject.Find("PingConnected_" + id_ping).GetComponent<Text>().color = Color.green;
    }

    public void StartMenu()
    {
        Debug.Log("pressed");
        //GameObject _menuController = GameObject.Find("GameController").GetComponent<MenuController>().gameObject;
        GameObject _menuController = GameObject.Find("Menu").GetComponent<MenuController>().gameObject;
        bool isActive = _menuController.transform.Find("Options").gameObject.activeInHierarchy ? false :true ;
        _menuController.transform.Find("Options").gameObject.SetActive(isActive);
        Pause();


    }

    public void DisplayMenu()
    {
        GameObject _menuController = GameObject.Find("Menu").GetComponent<MenuController>().gameObject;
        _menuController.transform.Find("Options").gameObject.SetActive(false);
        _menuController.transform.Find("Die").gameObject.SetActive(false);
        Pause();
    }

    private void DieMenu()
    {
        GameObject _menuController = GameObject.Find("Menu").GetComponent<MenuController>().gameObject;
        bool isActive = _menuController.transform.Find("Die").gameObject.activeInHierarchy ? false : true;
        _menuController.transform.Find("Die").gameObject.SetActive(isActive);
        Pause();

    }

    private void Pause()
    {
        Time.timeScale = Time.timeScale == 0.0f ? 1.1f : 0.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);

    }

    public void Exit()
    {
        Application.Quit();
    }

    public int ChangeSkin(int nextSelected, int idPlayer)
    {
        Debug.Log("idPlayer : ");
        Debug.Log(idPlayer);
        Transform player = PlayerState.playerList[idPlayer-1].transform;

        if (nextSelected >= ArrayOfSkin.Count)
        {
            nextSelected = 0;
        }
        else if (nextSelected <= -1)
        {
            nextSelected = ArrayOfSkin.Count -1;
        }
        GameObject.Find("Image_player_" + idPlayer).GetComponent<Image>().sprite = ArrayOfSkin[nextSelected];
        ChangeStateChild(player);
        player.GetChild(nextSelected).gameObject.SetActive(true);

        PlayerState.playerList[idPlayer - 1].GetComponent<Player>().animator = PlayerState.playerList[idPlayer - 1].transform.GetChild(nextSelected).GetComponent<Animator>();

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
