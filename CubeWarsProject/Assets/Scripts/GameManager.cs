using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager singleton;

    [SerializeField]
    private TMP_Text _scoreTx;

    [SerializeField]
    private TMP_Text _healthPointsTx;

    [SerializeField]
    private GameObject _losePanel;

    [SerializeField]
    private GameObject _winPanel;

    private int _score = 0;

    private void Awake()
    {
        singleton = this;
        _score = 0;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Enemie.ResetEnemieCount();
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void Victory()
    {
        _winPanel.SetActive(true);
        Time.timeScale = 0.1f;
    }

    public void GameLose()
    {
        _losePanel.SetActive(true);
    }

    public void UpdateHealthPoints(int hp)
    {
        _healthPointsTx.text = $"HP: {hp}";
    }

    public void UpdateScore(int amount)
    {
        _score += amount;
        _scoreTx.text = $"Score: {_score}";
    }
}
