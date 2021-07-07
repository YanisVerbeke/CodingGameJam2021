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
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }

    }

    public void ChangeColorPink(int id_ping)
    {
        Debug.Log("I Ping");

        GameObject.Find("PingConnected_" + id_ping).GetComponent<Text>().color = Color.green;
    }

    public int ChangeSkin(int nextSelected, int idPlayer)
    {
        Debug.Log(nextSelected);

        if (nextSelected >= ArrayOfSkin.Count)
        {
            nextSelected = 0;
        }
        else if (nextSelected <= -1)
        {
            nextSelected = ArrayOfSkin.Count -1;
        }
        GameObject.Find("Image_player_" + idPlayer).GetComponent<Image>().sprite = ArrayOfSkin[nextSelected];

        return nextSelected;
    }

}
