using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyFloat : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnEnable()
    {
        animator.Play("Idle");
    }
}
