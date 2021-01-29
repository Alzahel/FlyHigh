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
    [SerializeField] private GameObject gameUI = null;
    [SerializeField] private GameObject pauseUI = null;
    [SerializeField] private GameObject deathUI = null;

    [SerializeField] private Button settingsButton;
    
    [SerializeField] private GameObject player = null;
    
    [SerializeField] private List<GameObject> disabledInMenus = null;
    
    private Death death;

    public bool IsDead { get; private set; }
    public bool IsMenu { get; private set;} = true;
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
       // InputManager.Instance.OnTap += TouchPressed;
        InputManager.Instance.OnTap+= Taped;
        
        ActivateMenuUI();
        
        SoundManager.PlaySound(SoundManager.Sound.Music, true);
    }

    private void Taped()
    {
        if(IsDead) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void TouchPressed()
    {
        ActivateGameUI();
    }
    
    #region UI Management

    private void ActivateMenuUI()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        EnableGameElements(false);
    }
    
    private void ActivateGameUI()
    {
        IsMenu = false;
        IsDead = false;
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

    #region Play

    

    #endregion

    #region Pause

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            yield return null; 
        }
    }

    #endregion

    public void Settings()
    {
        IsMenu = false;
        Debug.Log("settings");
    }
    
}
