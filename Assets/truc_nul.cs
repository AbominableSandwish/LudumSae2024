using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truc_nul : MonoBehaviour
{
    private GameManager GM;
    void Start()
    {
        GM = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    public void truc_nul1()
    {
        GM.SetGameState(GameManager.GameState.Menu);
    }
}
