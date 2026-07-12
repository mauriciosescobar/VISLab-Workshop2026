using UnityEngine;
using System;
using System.Collections.Generic;


// Common interface every state implements 
public interface ISceneState
{
    void Enter();
    void Update();
    void Exit();
}

public class ClassStateMachine : MonoBehaviour
{
    // private fields for the state machine to hold references to the scene objects, serialized so they can be set in the inspector
    // packing state data into structs to be serialized in the inspector, so that the state machine doesn't have a million variables
    [SerializeField] private GameObject player;
    [SerializeField] private Start start;
    [SerializeField] private Levels level1;
    [SerializeField] private Levels level2;
    [SerializeField] private Levels level3;
    [SerializeField] private End end;
    public ISceneState CurrentState { get; private set; }

    // The public static property that other scripts access, it's a singleton
    public static ClassStateMachine Instance { get; private set; }

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
    // Start sets the first state
    void Start() {
        ChangeState(new StartState(this));
    }
    // Update calls the current state's Update method
    void Update() {
        CurrentState?.Update();
    }
    // ChangeState handles the transition between states
    public void ChangeState(ISceneState newState) {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }
    // exposed so state classes can reach shared references
    public GameObject PlayerReadOnly => player;
    public Start StartReadOnly => start;
    public Levels Level1ReadOnly => level1;
    public Levels Level2ReadOnly => level2;
    public Levels Level3ReadOnly => level3;
    public End EndReadOnly => end;

    // Shared helper — coin counting logic used by every level state
    public static int CountActive(List<GameObject> coins)
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

// the states recives the state machine to have the context of the scene, and can access the shared references through it
public class StartState : ISceneState
{
    private readonly ClassStateMachine context;
    public StartState(ClassStateMachine context) {
        this.context = context;
    }
    public void Enter() {
        context.StartReadOnly.camera.SetActive(true);
    }
    public void Update() {
        if (ClassStateMachine.CountActive(context.StartReadOnly.coins) == 0) {
            context.ChangeState(new Level1State(context));
        }
    }
    public void Exit() {
        context.StartReadOnly.camera.SetActive(false);
    }
}

public class Level1State : ISceneState
{
    private readonly ClassStateMachine context;
    public Level1State(ClassStateMachine context) {
        this.context = context;
    }
    public void Enter() {
        context.Level1ReadOnly.camera.SetActive(true);
        context.PlayerReadOnly.transform.position = context.Level1ReadOnly.playerStart.transform.position;
    }
    public void Update() {
        if (ClassStateMachine.CountActive(context.Level1ReadOnly.coins) == 0) {
            context.ChangeState(new Level2State(context));
        }
    }
    public void Exit() {
        context.Level1ReadOnly.camera.SetActive(false);
    }
}

public class Level2State : ISceneState
{
    private readonly ClassStateMachine context;
    public Level2State(ClassStateMachine context) {
        this.context = context;
    }
    public void Enter() {
        context.Level2ReadOnly.camera.SetActive(true);
        context.PlayerReadOnly.transform.position = context.Level2ReadOnly.playerStart.transform.position;
    }
    public void Update() {
        if (ClassStateMachine.CountActive(context.Level2ReadOnly.coins) == 0) {
            context.ChangeState(new Level3State(context));
        }
    }
    public void Exit() {
        context.Level2ReadOnly.camera.SetActive(false);
    }
}

public class Level3State : ISceneState
{
    private readonly ClassStateMachine context;
    public Level3State(ClassStateMachine context) {
        this.context = context;
    }
    public void Enter() {
        context.Level3ReadOnly.camera.SetActive(true);
        context.PlayerReadOnly.transform.position = context.Level3ReadOnly.playerStart.transform.position;
    }
    public void Update() {
        if (ClassStateMachine.CountActive(context.Level3ReadOnly.coins) == 0) {
            context.ChangeState(new EndState(context));
        }
    }
    public void Exit() {
        context.Level3ReadOnly.camera.SetActive(false);
    }
}


public class EndState : ISceneState
{
    private readonly ClassStateMachine context;
    public EndState(ClassStateMachine context) {
        this.context = context;
    }
    public void Enter() {
        context.EndReadOnly.camera.SetActive(true);
    }
    public void Update() {

    }
    public void Exit() {
        
    }
}