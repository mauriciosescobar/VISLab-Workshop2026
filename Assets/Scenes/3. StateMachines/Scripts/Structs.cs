using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public struct Start
{
    public GameObject camera;
    public List<GameObject> coins;
}

[Serializable]
public struct Levels
{
    public GameObject camera, playerStart;
    public List<GameObject> coins;
}

[Serializable]
public struct End
{
    public GameObject camera;
}
