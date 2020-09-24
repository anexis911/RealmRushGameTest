using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] int baseHP = 10;
    [SerializeField] Text healthText = null;
    [SerializeField] AudioClip baseHit = null;


    private void Start()
    {
        healthText.text = baseHP.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (baseHP <= 0)
        {
            Debug.Log("KABOOM!");
        }
        else
        {
            baseHP--;
            AudioSource.PlayClipAtPoint(baseHit, Camera.main.transform.position);
        }
        healthText.text = baseHP.ToString();
    }

}
