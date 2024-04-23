using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField] Transform pointPrefab;
    [SerializeField, Range(10, 100)] int resolution = 10;

    public List<Vector3> pointPos { get; } = new List<Vector3>();
    private GameManager gm;

    void Awake() {
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;

        for (int i = 0; i < resolution; i++) {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            pointPos.Add(position);
        }
    }

    private void Start() {
        gm = GameManager.Instance;
    }
}