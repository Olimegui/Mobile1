using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AnimatorManager;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;

    public List<AnimatorSetup> animatorSetups;

    private bool isDead = false;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1f)
    {
        if (isDead && type != AnimationType.DEAD) return;

        foreach (var animation in animatorSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;

                if (type == AnimationType.DEAD)
                {
                    isDead = true;
                    StopMovement();
                }

                break;
            }
        }
    }

    public void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimationType.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(AnimationType.DEAD);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(AnimationType.IDLE);
        }
    }


    private void StopMovement()
    {
        TouchController touchController = GetComponent<TouchController>();
        if (touchController != null)
        {
            touchController.canMove = false;
        }

        PlayerController playerController = GetComponent <PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }

    }
}

[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
    public float speed = 1f;
}
