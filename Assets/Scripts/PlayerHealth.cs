using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] public int hitPoints = 10;
  [SerializeField] private int healthDecrease = 1;
  [SerializeField] private Text healthText;
  [SerializeField] private AudioClip selfDestructSFX;
  private AudioSource soundPlayer;
  private void Start()
  {
    soundPlayer = GetComponent<AudioSource>();
    healthText.text = ("HP: " + hitPoints);
  }
  
  private void OnTriggerEnter(Collider other)
  {
    Invoke(nameof(DecreaseHealth), 0.5f);
    Invoke(nameof(PlaySelfDestructSound), 0.5f);
  }

  private void PlaySelfDestructSound()
  {
    soundPlayer.PlayOneShot(selfDestructSFX);
  }

  private void DecreaseHealth()
  {
    hitPoints -= healthDecrease;
    healthText.text = ("HP: " + hitPoints);
  }
}
