using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int _score;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _scoreTxt;

    private void Start()
    {
        UpdateScore();
    }

    public void AddScore()
    {
        _score++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        _scoreTxt.text = string.Format("Score: {0}",_score);
    }
}
