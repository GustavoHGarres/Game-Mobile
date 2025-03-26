using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManger : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup>animatorSetups;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }
    
    public void Play(AnimationType type)
    {
        foreach(var animation in animatorSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed;
                break;
            }
        }
    }

    [System.Serializable]
    public class AnimatorSetup
    {
       public AnimatorManger.AnimationType type;
       public string trigger;
       public float speed = 1f;
    }
}
