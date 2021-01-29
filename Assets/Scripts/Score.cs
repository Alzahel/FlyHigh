using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Scrolling scrolling = null;
    private float startTime = 0;
    private float currentTime = 0;
    [SerializeField] private FloatVariable score;
    
    [SerializeField] private TextMeshProUGUI tmpScore = null;
    [SerializeField] private TextMeshProUGUI tmpDeathScore = null;
    
    // Start is called before the first frame update
    void Start()
    {
        score.Value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGame) return;
        
        currentTime = Time.time - startTime;
        score.Value = Mathf.RoundToInt(score.Value + (currentTime * scrolling.verticalSpeed / 10));
        tmpScore.text = score.Value.ToString();
        tmpDeathScore.text = "Score : " + score.Value;
    }
}
