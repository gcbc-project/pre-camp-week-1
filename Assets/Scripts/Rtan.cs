using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    float direction = 0.05f;

    // Inspector에 있는 SpriteRenderer를 담기 위한 변수 선언
    SpriteRenderer rtanSpriteRender;

    // Start is called before the first frame update
    void Start()
    {
        //모든 기기들이 60 프레임 사용
        Application.targetFrameRate = 60;

        // Inspector에 있는 SpriteRenderer를 가져옴
        /* 
        여기서 GetComponent 메소드는 Script가 들어가 있는 오브젝트의 
        Inspector 내용만을 가져올 수 있음
        */
        rtanSpriteRender = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 좌클릭 시 이벤트 발생
        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            rtanSpriteRender.flipX = !rtanSpriteRender.flipX;
        }

        //오른쪽 벽끝에 닿았을때
        if (this.transform.position.x > 2.4)
        {
            rtanSpriteRender.flipX = true;
            direction = -0.05f;
        }

        //왼쪽 벽끝에 닿았을때
        if (this.transform.position.x < -2.4)
        {
            rtanSpriteRender.flipX = false;
            direction = 0.05f;
        }

        //기본 움직임 설정
        transform.position += Vector3.right * direction;
    }
}
