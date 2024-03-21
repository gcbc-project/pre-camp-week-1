using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Rain;
    public Text TotalScoreTxt;
    public Text TotalTimeTxt;
    public GameObject EndPanel;

    int totalScore = 0;
    float totalTime = 30.0f;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating(함수이름, 시작시간, 주기시간)
        // 0초부터 1초마다 MadeRain 함수 실행
        InvokeRepeating("MadeRain", 0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0f;
            EndPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        TotalTimeTxt.text = totalTime.ToString("N2");
    }

    void MadeRain()
    {
        //파라미터로 들어간 GameObject를 생성한다
        Instantiate(Rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        if (totalScore < 0) totalScore = 0;
        TotalScoreTxt.text = totalScore.ToString();
    }
}
