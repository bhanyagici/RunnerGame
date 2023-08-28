using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro'ya ulaþabilmemizi saðlýyor.
using UnityEngine.SceneManagement;// Sahnelere ulaþabilmemizi saðlýyor.
using UnityEditor.Experimental.GraphView;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public PlayerController playerController;
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    public GameObject EndPanel;

    private void Start()
    {
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }



       private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Coin"))
         {
             AddCoin();
             Destroy(other.gameObject);
         }
         /*else if (other.CompareTag("End"))
         {
             playerController.runningSpeed = 0;

            if (score >= maxScore)
            {
                Debug.Log("You Win!..");
            }
            else
            {
                Debug.Log("You Lose!..");
            }
         }*/
     }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            Debug.Log("Touched Obstacle!..");
            //Sahnenin yemiden baþlatýlmasýný saðlýyor.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if(collision.gameObject.CompareTag("End"))
        {
            playerController.runningSpeed = 0;

            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);

            EndPanel.SetActive(true);

            if (score >= maxScore)
            {
                PlayerAnim.SetBool("win", true);
            }
            else
            {
                PlayerAnim.SetBool("lose", true);
            }
        }
    }

    public void RestarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }
}
