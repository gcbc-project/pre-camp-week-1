using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public Text TotalScoreTxt;

    int totalScore = 0;

    private void Awake()
    {
        Instance = this;
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

    }

    void MadeRain()
    {
        //파라미터로 들어간 GameObject를 생성한다
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        TotalScoreTxt.text = totalScore.ToString();
    }
}
