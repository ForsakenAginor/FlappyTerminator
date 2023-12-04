using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Player _player;

    private ObjectPoolGenerator[] _spawners;
    private Health _playerHealth;

    private void Awake()
    {
        _playerHealth = _player.GetHealth();
        _spawners = FindObjectsOfType<ObjectPoolGenerator>();
    }

    private void OnEnable()
    {
        _startScreen.StartButtonClicked += OnStartButtonClicked;
        _gameOverScreen.RestartButtonClicked += OnRestartButtonClicked;
        _playerHealth.Die += OnDie;
        _player.Crashed += OnCrashed;
    }

    private void OnDisable()
    {
        _startScreen.StartButtonClicked -= OnStartButtonClicked;
        _gameOverScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _playerHealth.Die -= OnDie;
        _player.Crashed -= OnCrashed;
    }

    private void Start()
    {
        _startScreen.Open();
        _gameOverScreen.Close();
        Time.timeScale = 0;
    }

    private void OnRestartButtonClicked()
    {
        _gameOverScreen.Close();
        _player.ResetPlayer();

        if (_spawners != null)
        {
            foreach (var spawner in _spawners)
                spawner.ResetPool();
        }

        Time.timeScale = 1;
    }

    private void OnStartButtonClicked()
    {
        _startScreen.Close();
        Time.timeScale = 1;
    }

    private void OnDie()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

    private void OnCrashed()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
