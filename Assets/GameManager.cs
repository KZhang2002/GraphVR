using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager {
    private static GameManager _instance = new GameManager();

    public static GameManager Get() {
        if (_instance == null) _instance = new GameManager();
        return _instance;
    }
    
    // subscription stuff
    public delegate void LineChangeHandler(List<Vector3> newState);

    public event LineChangeHandler OnLineChange;
    
    public List<Vector3> line { get; private set; }

    public void SetLine(List<Vector3> newLine) {
        OnLineChange?.Invoke(newLine);
        line = newLine;
        // Debug.Log($"Line has been changed!");
    }
}