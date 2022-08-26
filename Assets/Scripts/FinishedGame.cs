using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishedGame : MonoBehaviour
{
    public GameObject panel;
    public GameObject firstScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(other.gameObject);
            MoneyCounter.moneyAmount += 100;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
