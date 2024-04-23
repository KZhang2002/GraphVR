using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;

    public static GameManager Instance {
        get { return _instance; }
    }


    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
    }

    private void Start() {
        
    }

    public List<Vector3> line { get; private set; }

    // subscription stuff
    public delegate void LineChangeHandler(List<Vector3> newState);

    public event LineChangeHandler OnLineChange;

    public void SetLine(List<Vector3> newLine) {
        OnLineChange?.Invoke(newLine);
        line = newLine;
        Debug.Log($"State changed to {newLine}");
    }
}