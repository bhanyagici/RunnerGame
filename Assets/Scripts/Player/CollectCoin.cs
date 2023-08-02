using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro'ya ula�abilmemizi sa�l�yor.
using UnityEngine.SceneManagement;// Sahnelere ula�abilmemizi sa�l�yor.

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    PlayerController playerController;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Debug.Log("Congrats!...");
            playerController.runningSpeed = 0;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("Touched Obstacle!..");
            //Sahnenin yemiden ba�lat�lmas�n� sa�l�yor.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }
}
