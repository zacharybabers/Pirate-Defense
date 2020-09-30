using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
  [SerializeField] private int hitPoints = 10;
  [SerializeField] private int healthDecrease = 1;
  [SerializeField] private Text healthText;

  private void Start()
  {
    healthText.text = ("HP: " + hitPoints);
  }
  
  private void OnTriggerEnter(Collider other)
  {
    hitPoints -= healthDecrease;
    healthText.text = ("HP: " + hitPoints);
  }
}
