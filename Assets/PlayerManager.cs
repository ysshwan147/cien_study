using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    bool _isAlive = true;

    [SerializeField]    // 바로 다음 변수를 유니티 화면 inspector 창에 표시
    UI_Manager _uimanager;

    [SerializeField]
    float _health = 100.0f;
    [SerializeField]
    float _stemina = 100.0f;
    float _maxStemina = 100.0f;

    [SerializeField]
    float _time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 게임이 시작할때
        // 최대 체력 값을 UI 체력 바에 반영
        _uimanager.SetMaxHealth(_health);
        // 현재 체력(최대 체력 값)을 UI 체력 바에 반영
        _uimanager.SetHealth(_health);

        // 최대 스태미나 값을 UI 스태미나 바에 반영
        _uimanager.SetMaxStemina(_maxStemina);
        // 현재 스태미나(최대 스태미나 값)을 UI 스태미나 바에 반영
        _uimanager.SetStemina(_stemina);
        
        // 게임 플레이 시간(0초)를 UI에 나타냄
        _uimanager.SetTime(_time);
    }

    // Update is called once per frame
    void Update()
    {
        // 좌우로 움직이는 행동을 하고 있다면 스태미나가 줄어든다
        if (Input.GetAxis("Horizontal") != 0)
            _stemina -= Time.deltaTime;

        // 움직이지 않을 때 스태미나가 최대치보다 작다면 스태미나가 늘어남
        else if (_stemina < _maxStemina)
            _stemina += Time.deltaTime;


        // 스태미나가 변화한 값만큼 UI 스태미나 바에 반영
        _uimanager.SetStemina(_stemina);

        // 플레이 시간이 증가함
        _time += Time.deltaTime;
        
        // 플레이 시간 값을 UI에 나타냄
        _uimanager.SetTime(_time);
    }

    // controller가 collider에 접촉하고 있는지 확인하는 메소드
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        // 불 스프라이트에 닿고 있다면
        if (hit.gameObject.name == "Fire")
        {
            // 체력이 0보다 크면 체력이 감소
            if (_health > 0)
               _health -= 1;

            // 0보다 작거나 같아지면 캐릭터 사망처리, 게임오버 메시지, 캐릭터 파괴
            else
            {
                _isAlive = false;
                Debug.Log("Game Over");
                Destroy(gameObject);
            }

            // 변화하는 체력 값을 UI 체력 바에 반영
            _uimanager.SetHealth(_health);
        }
    }
}
