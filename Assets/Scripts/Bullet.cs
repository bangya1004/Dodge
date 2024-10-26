using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;            // 이동에 사용할 리지드바디 컴포넌트
    private float bulletSpeed = 8.0f;   // 탄알 이동 속력

    void Awake()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 "rigid"에 할당
        rigid = GetComponent<Rigidbody>();
        // 리지드바디 속도 = 앞쪽 방향 * 이동 속력
        rigid.velocity = transform.forward * bulletSpeed;

        // 1.5초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 1.5f);
    }

    // 트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if(other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방 PlayerController 컴포넌트의 Die() 메서드 실행
            playerController.Die();

            Destroy(gameObject);
        }
    }
}
