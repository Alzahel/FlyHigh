using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
   [SerializeField] private GameObject deathUI = null;
   [SerializeField] private List<GameObject> disableOnDeath = null;

   [SerializeField] private GameObject deathExplosion = null;


   public delegate void DeathEvent();
   public event DeathEvent OnDied;
   private void Start()
   {
      deathUI.SetActive(false);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
      {
         if(other.CompareTag("Planet")) SoundManager.PlaySound(SoundManager.Sound.Explosion);
         GetComponent<PlayerController>().enabled = false;
         
         foreach (GameObject GO in disableOnDeath)
         {
            GO.SetActive(false);
         }

         GameObject deathEffectGO = Instantiate(deathExplosion, this.transform);
         
         if(SystemInfo.deviceType == DeviceType.Handheld) Handheld.Vibrate();
         OnDied?.Invoke();
      };
   }
}
