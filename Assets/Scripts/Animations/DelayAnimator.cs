using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float delay;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.enabled = false;

        Invoke("EnableAnimator", delay);
    }

    void EnableAnimator()
    {
        animator.enabled = true;
    }
}
