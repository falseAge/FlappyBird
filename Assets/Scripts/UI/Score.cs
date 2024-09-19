using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _bird.ScoreChanger += OnScoreChanger;
    }

    private void OnDisable()
    {
        _bird.ScoreChanger -= OnScoreChanger;
    }

    private void OnScoreChanger(int score)
    {
        _score.text = score.ToString();
    }
}
