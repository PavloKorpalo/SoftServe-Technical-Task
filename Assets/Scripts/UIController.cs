using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject GameWinMenu;
    private Text _scoreText;
    private SnakeScript _score;
    // Start is called before the first frame update
    void Awake()
    {
        _score = FindObjectOfType<SnakeScript>();
        _scoreText = FindObjectOfType<Text>();
        Time.timeScale = 0;
        
    }

    


    void Update()
    {

      
            _scoreText.text = "Score: " + _score.Score;

            if (_score.IsDestroyed == true)
            {
                Time.timeScale = 0;
                GameOverMenu.SetActive(true);
            }
            if(_score.Score == 7) 
            {
                Time.timeScale = 0;
                GameWinMenu.SetActive(true);
            }
        
      

    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 2;
    }
}
