/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    private bool _isPlayerAtExit;
    private bool _isPlayerCaught;
    private float _timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            _isPlayerAtExit = true;
            Debug.Log("Player spotted");
        }
    }

    public void CaughtPlayer()
    {
        _isPlayerCaught = true;
    }

    void Update()
    {
        if (_isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (_isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool toRestart)
    {
        _timer += Time.deltaTime;

        imageCanvasGroup.alpha = _timer / fadeDuration;

        if (toRestart)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }
}