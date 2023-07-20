using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winPopUp;
    private Health[] alivePlayers;
    private void Start()
    {
        alivePlayers = FindObjectsOfType<Health>();
        for (int i = 0; i < alivePlayers.Length; ++i)
        {
            alivePlayers[i].OnDeath += GameManager_OnDeath; ;
        }
        winPopUp.SetActive(false);
        Resume();
    }

    private void GameManager_OnDeath(object sender, System.EventArgs e)
    {
        Win();
    }

    public void Pause()
    { 
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
    public void Win()
    { 
        winPopUp.SetActive(true);
        Pause();
    }
    private void OnDestroy()
    {
        for (int i = 0; i < alivePlayers.Length; ++i)
        {
            alivePlayers[i].OnDeath -= GameManager_OnDeath;
        }
    }
}
