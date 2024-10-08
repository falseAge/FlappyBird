using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]

public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanger;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void AddScore()
    {
        _score++;
        ScoreChanger?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChanger?.Invoke(_score);
        _mover.ResetBird();

    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
