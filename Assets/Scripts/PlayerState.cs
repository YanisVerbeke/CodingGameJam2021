using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static List<GameObject> playerList;
    public static bool inGame;
    public static GameObject test;

    public enum StateMenu { INMENU, INGAME ,INPAUSE};

    public static StateMenu currentState;
}
