using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTorch : MonoBehaviour
{
    [SerializeField] int power = 3;
    [SerializeField] Unit healingUnit;
    [SerializeField] GameObject fX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(power <= 0)
        {
            return;
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            if (!healingUnit.IsMaxHealth())
            {
                Debug.Log("I feel reguvinated");
                healingUnit.Heal(1);
                power--;
            }
            else
            {
                Debug.Log("I don't need anymore");
            }

            if(power <= 0)
            {
                fX.SetActive(false);
                Debug.Log("The torch burns out");
            }
        }
    }
}
