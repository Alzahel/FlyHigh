using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Scrolling scrolling = null;
    private float startTime = 0;
    private float currentTime = 0;
    [SerializeField] private FloatVariable score = null;
    private float bestScore;
    
    [SerializeField] private TextMeshProUGUI tmpScore = null;
    [SerializeField] private TextMeshProUGUI tmpPauseScore = null;
    [SerializeField] private TextMeshProUGUI tmpDeathScore = null;
    [SerializeField] private TextMeshProUGUI tmpMenuBestScore = null;
    [SerializeField] private TextMeshProUGUI tmpPauseBestScore = null;
    [SerializeField] private TextMeshProUGUI tmpDeathBestScore = null;

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();

        if (!PlayerPrefs.HasKey("bestScore"))
        {
            PlayerPrefs.SetFloat("bestScore", bestScore);
            return;
        }
        
        bestScore = PlayerPrefs.GetFloat("bestScore");
        tmpMenuBestScore.text = "Best score : " + bestScore;
        tmpPauseBestScore.text = "Best core : " + bestScore;
        tmpDeathBestScore.text = "Best core : " + bestScore;
    }

    public void ResetScore()
    {
        score.Value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGame) return;
        
        currentTime = Time.time - startTime;
        score.Value = Mathf.RoundToInt(score.Value + (currentTime * scrolling.verticalSpeed / 10));
        tmpScore.text = score.Value.ToString();
        tmpPauseScore.text = "Score : " + score.Value;
        tmpDeathScore.text = "Score : " + score.Value;

        if (score.Value > bestScore)
        {
            bestScore = score.Value;
            PlayerPrefs.SetFloat("bestScore", bestScore);
            tmpMenuBestScore.text = "Best score : " + bestScore;
            tmpPauseBestScore.text = "Best core : " + bestScore;
            tmpDeathBestScore.text = "Best core : " + bestScore;
        }
    }
}
