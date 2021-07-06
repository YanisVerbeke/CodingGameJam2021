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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Hayo");
        SceneManager.LoadScene(sceneBuildIndex:2);

    }

    public void ChangeColorPink(int id_ping)
    {
        GameObject.Find("PingConnected_" + id_ping).GetComponent<Text>().color = Color.green;
    }

}
