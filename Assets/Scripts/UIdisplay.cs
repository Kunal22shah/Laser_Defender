using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIdisplay : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = playerHealth.getHealth();

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.getHealth();
        scoreText.text = scoreKeeper.getScore().ToString("000000000");
    }
}
