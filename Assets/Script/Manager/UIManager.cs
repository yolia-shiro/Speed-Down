using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text runTime;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public Text Score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        runTime.text = GameManager.instance.runTime.ToString("00000");
    }

   public void CreateGameOverUI()
    {
        Time.timeScale = 0.0f;
        Score.text = runTime.text;
        gameOverPanel.SetActive(true);
    }
}
