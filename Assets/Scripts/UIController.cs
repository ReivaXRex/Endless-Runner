using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text distanceTravelled;
    [SerializeField] Text CoinCounter;
    [SerializeField] Text CoinCounterGO;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject gameMusic;
    [SerializeField] Player player;


    private void Update()
    {
        CoinCount();
        ShowGameOverScreen();
    }

    void ShowGameOverScreen()
    {
        if (player.isAlive == false)
        {
            gameOverScreen.SetActive(true);
            gameMusic.SetActive(false);
            float roundedDistance = Mathf.Ceil(player.distanceTravelled);
            distanceTravelled.text = roundedDistance.ToString();
            CoinCounterGO.text = player.collectedCoins.ToString();
        }
      

        // distanceTravelled.text = "" + player.distanceTravelled;

    }

    void CoinCount()
    {
        CoinCounter.text = "Coins: " + player.collectedCoins;
    }

    public void GameRestart()
    {
       // Debug.Log("Restart the Game");
        SceneManager.LoadScene(0);
    }
}
