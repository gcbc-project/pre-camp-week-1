using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;
    SpriteRenderer rainSprite;

    // Start is called before the first frame update
    void Start()
    {
        // 비 오브젝트의 SpriteRenderer Inspector 정보를 가져오기
        rainSprite = GetComponent<SpriteRenderer>();

        // 비오브젝트의 위치를 랜덤으로 생성 (X,Y 각각)
        float poX = Random.Range(-2.4f, 2.4f);
        float poY = Random.Range(3.0f, 5.0f);

        // 비 오브젝트의 위치 이동
        this.transform.position = new Vector3(poX, poY, 0);

        // 비 오브젝트의 타입을 랜덤으로 생성 (1~3) 정수형
        int rainType = Random.Range(1, 5);

        switch (rainType)
        {
            case 1:
                size = 0.8f;
                score = 1;
                rainSprite.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
                break;
            case 2:
                size = 1.0f;
                score = 2;
                rainSprite.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
                break;
            case 3:
                size = 1.2f;
                score = 3;
                rainSprite.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
                break;
            case 4:
                size = 0.8f;
                score = -5;
                rainSprite.color = new Color(1f, 100 / 255f, 1f, 1f);
                break;
        }

        // 비 오브젝트의 크기를 변경
        transform.localScale = new Vector3(size, size, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}
