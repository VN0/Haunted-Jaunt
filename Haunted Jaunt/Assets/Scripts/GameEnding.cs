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
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    private bool _isPlayerAtExit;
    private bool _isPlayerCaught;
    private float _timer;
    private bool _hasAudioPlayed;

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
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (_isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool toRestart, AudioSource audioSource)
    {
        if (!_hasAudioPlayed)
        {
            audioSource.Play();
            _hasAudioPlayed = true;
        }
        _timer += Time.deltaTime;

        imageCanvasGroup.alpha = _timer / fadeDuration;

        if (toRestart)
        {
            StartCoroutine(ReloadLevel());
        }
        else
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }

    IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}