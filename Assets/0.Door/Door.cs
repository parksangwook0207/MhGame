using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{


    public enum DoorState
    {
        Open,
        Closed
    }

   
    public DoorState CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
            Animate();
        }
    }
   
    public bool IsDoorOpen { get { return CurrentState == DoorState.Open; } }
 
    public bool IsDoorClosed { get { return CurrentState == DoorState.Closed; } }

    public DoorState InitialState = DoorState.Closed;
    public float AnimationSpeed = 1;

    [SerializeField]
    private AnimationClip openAnimation;
    [SerializeField]
    private AnimationClip closeAnimation;

    private Animation animator;
    private DoorState currentState;

    void Awake()
    {
        animator = GetComponent<Animation>();
        if (animator == null)
        {
            Debug.LogError("Every DoorController needs an Animator.");
            return;
        }

        
        animator.playAutomatically = false;

        
        openAnimation.legacy = true;
        closeAnimation.legacy = true;
        animator.AddClip(openAnimation, DoorState.Open.ToString());
        animator.AddClip(closeAnimation, DoorState.Closed.ToString());
    }

    void Start()
    {
        currentState = InitialState;
        var clip = GetCurrentAnimation();
        animator[clip].speed = 9999;
        animator.Play(clip);
    }

   
    public void CloseDoor()
    {
        if (IsDoorClosed)
            return;

        CurrentState = DoorState.Closed;
    }

    public void OpenDoor()
    {
        if (IsDoorOpen)
            return;

        CurrentState = DoorState.Open;
    }

    public void ToggleDoor()
    {
        if (IsDoorOpen)
            CloseDoor();
        else
            OpenDoor();
    }

    private void Animate()
    {
        var clip = GetCurrentAnimation();
        animator[clip].speed = AnimationSpeed;
        animator.Play(clip);
    }

    private string GetCurrentAnimation()
    {
        return CurrentState.ToString();
    }
}

