using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField] Transform pointPrefab;
    [SerializeField, Range(10, 100)] int resolution = 10;
	
    Transform[] points;

    public List<Vector3> lineData { get; } = new List<Vector3>();
    private GameManager gm;

    void Awake() {
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;

        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            lineData.Add(position);
        }
    }

    public void MakeParabola() {
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        
        lineData.Clear();
        for (int i = 0; i < points.Length; i++) {
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x;
            points[i].localPosition = position;
            points[i].localScale = scale;
            points[i].SetParent(transform, false);
            lineData.Add(position);
        }
        
        gm.SetLine(lineData);
    }
    
    public void MakeLinear() {
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        
        lineData.Clear();
        for (int i = 0; i < points.Length; i++) {
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x;
            points[i].localPosition = position;
            points[i].localScale = scale;
            points[i].SetParent(transform, false);
            lineData.Add(position);
        }
        
        gm.SetLine(lineData);
    }
    
    public void MakeQuad() {
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        
        lineData.Clear();
        for (int i = 0; i < points.Length; i++) {
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x * position.x;
            points[i].localPosition = position;
            points[i].localScale = scale;
            points[i].SetParent(transform, false);
            lineData.Add(position);
        }
        
        gm.SetLine(lineData);
    }

    private void Start() {
        gm = GameManager.Get();
        gm.SetLine(lineData);
    }
}