using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _menuCanvas;
    private bool _gameIsStarted;
    [HideInInspector] public AngryBall _ballScript;
    private GameObject [] Blocks;

    private void Awake()
    {
        _startButton.onClick.AddListener(StartGame);
        _exitButton.onClick.AddListener(ExitGame);
        Blocks = GameObject.FindGameObjectsWithTag("Block");
          

    }

    private void Update()
    {
        if (Blocks.Count(arrElem => arrElem != null ) == 0) 
        {
            _gameIsStarted = true;
            _menuCanvas.SetActive(true);
        }
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        if (_gameIsStarted)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        _gameIsStarted = true;
        _menuCanvas.SetActive(false);

    }



}
