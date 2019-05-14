/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;

    private bool _isPlayerAtExit;
    private float _timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _isPlayerAtExit = true;
            Debug.Log("Player spotted");
        }
    }

    void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        _timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = _timer / fadeDuration;

        if (_timer > fadeDuration + displayImageDuration)
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }
}