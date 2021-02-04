using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(-101)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject menuUI = null;
    [SerializeField] private GameObject SettingsUI = null;
    [SerializeField] private GameObject ShopUI = null;
    [SerializeField] private GameObject RankingUI = null;
    [SerializeField] private GameObject gameUI = null;
    [SerializeField] private GameObject pauseUI = null;
    [SerializeField] private GameObject deathUI = null;

    [SerializeField] private GameObject player = null;
    
    [SerializeField] private List<GameObject> disabledInMenus = null;
    
    private Death death;

    public bool IsDead { get; private set; }
    public bool IsMenu { get; private set;} = true;
    public bool IsSettings { get; private set;}
    public bool IsShop { get; private set;}
    public bool IsRanking { get; private set;}
    public bool IsGame { get; private set;}
    public bool IsPaused { get; private set;}

    private void Awake()
    {
        if (Instance == null) Instance = this;
        
        death = player.GetComponent<Death>();
    }

    void Start()
    {
        death.OnDied += Die;
        InputManager.Instance.OnTap+= Taped;
        
        ActivateMenuUI();
        
        
        SoundManager.PlaySound(SoundManager.Sound.Music, true);
    }

    private void Taped()
    {
        if(IsDead) ReloadGame();
    }

    #region UI Management

    private void ActivateMenuUI()
    {
        IsSettings = false;
        IsShop = false;
        IsRanking = false;
        IsMenu = true;
        
        SettingsUI.SetActive(false);
        ShopUI.SetActive(false);
        RankingUI.SetActive(false);
        
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        EnableGameElements(false);
    }

    private void ActivateSettingsUI()
    {
        IsSettings = !IsSettings;
        IsMenu = !IsSettings;
        
        SettingsUI.SetActive(IsSettings);
    }
    
    private void ActivateShopUI()
    {
        IsShop = !IsShop;
        IsMenu = !IsShop;
        
        ShopUI.SetActive(IsShop);
    }
    
    private void ActivateRankingUI()
    {
        IsRanking = !IsRanking;
        IsMenu = !IsRanking;
        
        RankingUI.SetActive(IsRanking);
    }
    
    private void ActivateGameUI()
    {
        IsMenu = false;
        IsPaused = false;
        IsGame = true;
        
        menuUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        EnableGameElements(true);
    }

    private void ActivatePauseUI()
    {
        IsGame = false;
        IsPaused = true;

        gameUI.SetActive(false);
        pauseUI.SetActive(true);
    }
    
    private void ActivateDeathUI()
    {
        IsGame = false;
        IsDead = true;

        gameUI.SetActive(false);
        deathUI.SetActive(true);
        
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        EnableGameElements(false);
    }
    
    private void EnableGameElements(bool state)
    {
        foreach (GameObject GO in disabledInMenus)
        {
            GO.SetActive(state);
        }
    }
    #endregion

    #region public actions

    public void PlayGame()
    {
        
        if (IsSettings) ActivateSettingsUI();
        else if (IsShop) ActivateShopUI();
        else if (IsRanking) ActivateRankingUI();
        else if (IsMenu || IsPaused)
        {
            Time.timeScale = 1;
            ActivateGameUI();
        }
    }

    public void backToMenu()
    {
        ActivateMenuUI();
    }
    
    public void OpenSettings()
    {
        ActivateSettingsUI();
    }
    
    public void OpenShop()
    {
        ActivateShopUI();
    }
    
    public void OpenRanking()
    {
        ActivateRankingUI();
    }
    
    public void PauseGame ()
    {
        Time.timeScale = 0;
        ActivatePauseUI();
    }
    #endregion

    #region Die

    private void Die()
    {
        IsDead = true;
        EnableGameElements(false);
        ActivateDeathUI();
        
        if(SystemInfo.deviceType == DeviceType.Desktop) StartCoroutine(KeyboardWaitForInput());
    }
    
    private IEnumerator KeyboardWaitForInput()
    {
        yield return new WaitForSeconds(1);
        
        bool done = false;
        while(!done) 
        {
            if(Input.anyKeyDown)
            {
                done = true; 
                ReloadGame();
            }
            yield return null; 
        }
    }

    #endregion

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
