using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AnimatorManager;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;

    public List<AnimatorSetup> animatorsetups;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void Play(AnimationType type)
    {
        foreach (var animation in animatorsetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }

    void Update()
    {
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
}

[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
}
