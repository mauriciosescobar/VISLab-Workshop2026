using UnityEngine;
using System;
using System.Collections.Generic;

public class EnumStateMachine : MonoBehaviour
{
    // Define every possible state 
    public enum SceneState
    {
        Start,
        Level1,
        Level2,
        Level3,
        End
    }

    [SerializeField] private SceneState currentState;
    // private fields for the state machine to hold references to the scene objects, serialized so they can be set in the inspector
    // packing state data into structs to be serialized in the inspector, so that the state machine doesn't have a million variables
    [SerializeField] private GameObject player;
    [SerializeField] private Start start;
    [SerializeField] private Levels level1;
    [SerializeField] private Levels level2;
    [SerializeField] private Levels level3;
    [SerializeField] private End end;

    // The public static property that other scripts access, it's a singleton
    public static EnumStateMachine Instance { get; private set; }

    private void Awake()
    {
        // Enforce the Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Delete duplicate instances
            return;
        }
        Instance = this;
    }

    void Start()
    {
        ChangeState(SceneState.Start);
    }

    void Update()
    {
        // Per-frame logic per state 
        switch (currentState)
        {
            case SceneState.Start:
                UpdateStart();
                break;

            case SceneState.Level1:
                UpdateLevel1();
                break;

            case SceneState.Level2:
                UpdateLevel2();
                break;

            case SceneState.Level3:
                UpdateLevel3();
                break;

            case SceneState.End:
                // nothing to check, End is terminal
                break;
        }
    }

    // The transition function: the only place currentState should change
    public void ChangeState(SceneState newState)
    {
        if (newState == currentState)
            return;

        ExitState(currentState);
        currentState = newState;
        EnterState(newState);
    }

    //  Enter: runs once, when a state becomes active 
    private void EnterState(SceneState state)
    {
        switch (state)
        {
            case SceneState.Start:
                start.camera.SetActive(true);
                break;

            case SceneState.Level1:
                level1.camera.SetActive(true);
                player.transform.position = level1.playerStart.transform.position;
                break;

            case SceneState.Level2:
                level2.camera.SetActive(true);
                player.transform.position = level2.playerStart.transform.position;
                break;

            case SceneState.Level3:
                level3.camera.SetActive(true);
                player.transform.position = level3.playerStart.transform.position;
                break;

            case SceneState.End:
                end.camera.SetActive(true);
                break;
        }
    }

    // Exit: runs once, when leaving a state (cleanup) 
    private void ExitState(SceneState state)
    {
        switch (state)
        {
            case SceneState.Start:
                start.camera.SetActive(false);
                break;

            case SceneState.Level1:
                level1.camera.SetActive(false);
                break;

            case SceneState.Level2:
                level2.camera.SetActive(false);
                break;

            case SceneState.Level3:
                level3.camera.SetActive(false);
                break;

            case SceneState.End:
                end.camera.SetActive(false);
                break;
        }
    }

    // Per-state update logic 
    private void UpdateStart()
    {
        if (CountActive(start.coins) == 0)
        {
            ChangeState(SceneState.Level1);
        }
    }

    private void UpdateLevel1()
    {
        if (CountActive(level1.coins) == 0)
        {
            ChangeState(SceneState.Level2);
        }
    }

    private void UpdateLevel2()
    {
        if (CountActive(level2.coins) == 0)
        {
            ChangeState(SceneState.Level3);
        }
    }

    private void UpdateLevel3()
    {
        if (CountActive(level3.coins) == 0)
        {
            ChangeState(SceneState.End);
        }
    }

    private int CountActive(List<GameObject> coins)
    {
        int count = 0;
        foreach (var coin in coins)
        {
            if (coin.activeSelf)
                count++;
        }
        return count;
    }
}
