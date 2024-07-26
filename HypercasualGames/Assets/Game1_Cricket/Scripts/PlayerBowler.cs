using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowler : MonoBehaviour
{
    public enum State { Idle, Aiming, Running, Bowling}

    [Header("Elements")]
    [SerializeField] private Animator bowlerAnimator;
    [SerializeField] private GameObject fakeBall;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runDuration;
    private float runTimer;

    private State state;

    private void Start()
    {
        StartRunning();
    }

    private void Update()
    {
        ManageState();
    }

    void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                break;
            case State.Running:
                Run();
                break;
            case State.Bowling:
                StartBowling();
                break;
            case State.Aiming:
                break;
        }
    }

    

    void StartRunning()
    {
        state = State.Running;
        bowlerAnimator.SetInteger("State", 1);
    }

    void StartBowling()
    {
        state = State.Bowling;
        bowlerAnimator.SetInteger("State", 2);
    }

    private void Run()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        runTimer += Time.deltaTime;

        if (runTimer >= runDuration)
        {
            state = State.Bowling;
        }
    }

    public void ThrowBall()
    {
        fakeBall.SetActive(false);
    }
}
