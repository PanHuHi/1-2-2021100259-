using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPViewer : MonoBehaviour
{
    public BossHP bossHP;
    private Slider sliderHP;
    // Start is called before the first frame update
    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    private void Update()
    {
        sliderHP.value = bossHP.CurrentHP / bossHP.MaxHP;
    }
}
