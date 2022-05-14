using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    Slider _healthBar, _steminaBar;
    [SerializeField]
    Text _time;

    // 메소드를 호출하면서 현재 체력 값을 넘겨줌
    // 유니티 HealthBar inspector 창에 보이는 Value 값을 인자 값으로 설정
    public void SetHealth(float _arg)
    {
        _healthBar.value = _arg;
    }

    // 메소드를 호출하면서 최대 체력 값을 넘겨줌
    // 유니티 HealthBar inspector 창에 보이는 Max Value 값을 인자 값으로 설정
    public void SetMaxHealth(float _arg)
    {
        _healthBar.maxValue = _arg;
    }

    // 체력과 동일
    public void SetStemina(float _arg)
    {
        _steminaBar.value = _arg;
    }

    // 체력과 동일
    public void SetMaxStemina(float _arg)
    {
        _steminaBar.maxValue = _arg;
    }

    // 메소드를 호출하면서 플레이 시간 값을 넘겨줌
    // 유니티 Time inspector 창에 보이는 Text 입력 칸에 인자 값을 입력
    public void SetTime(float _arg)
    {
        _arg = (float) Math.Round(_arg);
        _time.text = _arg.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
