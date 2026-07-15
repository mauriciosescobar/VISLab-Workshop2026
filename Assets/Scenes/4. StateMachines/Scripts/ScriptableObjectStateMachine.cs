using UnityEngine;
using System;
using System.Collections.Generic;

// Base class every state asset inherits from 
// No runtime data stored here — this is an asset on disk, shared across
// play sessions, so all data lives in the context (the state machine) instead.
public abstract class SceneState : ScriptableObject
{
    public abstract void Enter(ScriptableObjectStateMachine machine);
    public abstract void Tick(ScriptableObjectStateMachine machine);
    public abstract void Exit(ScriptableObjectStateMachine machine);
}

// The state machine: holds current state, shared references, and drives everything via Unity's Update()
public class ScriptableObjectStateMachine : MonoBehaviour
{
    [Header("Initial state")]
    [SerializeField] private SceneState initialState;

    // packing state data into structs to be serialized in the inspector,
    // so that the state machine doesn't have a million variables
    [SerializeField] private GameObject player;
    [SerializeField] private Start start;
    [SerializeField] private Levels level1;
    [SerializeField] private Levels level2;
    [SerializeField] private Levels level3;
    [SerializeField] private End end;

    public SceneState CurrentState { get; private set; }

    // The public static property that other scripts access, it's a singleton
    public static ScriptableObjectStateMachine Instance { get; private set; }

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
        ChangeState(initialState);
    }

    void Update()
    {
        CurrentState?.Tick(this);
    }

    public void ChangeState(SceneState newState)
    {
        CurrentState?.Exit(this);
        CurrentState = newState;
        CurrentState?.Enter(this);
    }

    // Exposed so state assets can reach shared references
    public GameObject Player => player;
    public Start StartData => start;
    public Levels Level1Data => level1;
    public Levels Level2Data => level2;
    public Levels Level3Data => level3;
    public End EndData => end;

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

[CreateAssetMenu(menuName = "SceneStates/Start State")]
public class StartStateObject : SceneState
{
    [SerializeField] private SceneState nextState; // assign Level1State asset

    public override void Enter(ScriptableObjectStateMachine machine)
    {
        machine.StartData.camera.SetActive(true);
    }

    public override void Tick(ScriptableObjectStateMachine machine)
    {
        if (ScriptableObjectStateMachine.CountActive(machine.StartData.coins) == 0)
            machine.ChangeState(nextState);
    }

    public override void Exit(ScriptableObjectStateMachine machine)
    {
        machine.StartData.camera.SetActive(false);
    }
}

[CreateAssetMenu(menuName = "SceneStates/Level1 State")]
public class Level1StateObject : SceneState
{
    [SerializeField] private SceneState nextState; // assign Level2State asset

    public override void Enter(ScriptableObjectStateMachine machine)
    {
        machine.Level1Data.camera.SetActive(true);
        machine.Player.transform.position = machine.Level1Data.playerStart.transform.position;
    }

    public override void Tick(ScriptableObjectStateMachine machine)
    {
        if (ScriptableObjectStateMachine.CountActive(machine.Level1Data.coins) == 0)
            machine.ChangeState(nextState);
    }

    public override void Exit(ScriptableObjectStateMachine machine)
    {
        machine.Level1Data.camera.SetActive(false);
    }
}

[CreateAssetMenu(menuName = "SceneStates/Level2 State")]
public class Level2StateObject : SceneState
{
    [SerializeField] private SceneState nextState; // assign Level3State asset

    public override void Enter(ScriptableObjectStateMachine machine)
    {
        machine.Level2Data.camera.SetActive(true);
        machine.Player.transform.position = machine.Level2Data.playerStart.transform.position;
    }

    public override void Tick(ScriptableObjectStateMachine machine)
    {
        if (ScriptableObjectStateMachine.CountActive(machine.Level2Data.coins) == 0)
            machine.ChangeState(nextState);
    }

    public override void Exit(ScriptableObjectStateMachine machine)
    {
        machine.Level2Data.camera.SetActive(false);
    }
}

[CreateAssetMenu(menuName = "SceneStates/Level3 State")]
public class Level3StateObject : SceneState
{
    [SerializeField] private SceneState nextState; // assign EndState asset

    public override void Enter(ScriptableObjectStateMachine machine)
    {
        machine.Level3Data.camera.SetActive(true);
        machine.Player.transform.position = machine.Level3Data.playerStart.transform.position;
    }

    public override void Tick(ScriptableObjectStateMachine machine)
    {
        if (ScriptableObjectStateMachine.CountActive(machine.Level3Data.coins) == 0)
            machine.ChangeState(nextState);
    }

    public override void Exit(ScriptableObjectStateMachine machine)
    {
        machine.Level3Data.camera.SetActive(false);
    }
}

[CreateAssetMenu(menuName = "SceneStates/End State")]
public class EndStateObject : SceneState
{
    public override void Enter(ScriptableObjectStateMachine machine)
    {
        machine.EndData.camera.SetActive(true);
    }

    public override void Tick(ScriptableObjectStateMachine machine)
    {

    }

    public override void Exit(ScriptableObjectStateMachine machine)
    {

    }
}
