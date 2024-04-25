using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class Platform : MonoBehaviour {
    private GameManager gm;
    private List<Vector3> lineData;
    public Boolean moveFlag = false;
    private int linePointInd = 0;
    [SerializeField] private float graphScaleFactor = 30f;
    //[SerializeField] private float graphYOffset = 30f;
    [SerializeField] private float speed = 5f;
    public Vector3 offSet { get; private set; }
    
    void Awake() {
        gm = GameManager.Get();
    }

    IEnumerator StartLift() {
        yield return new WaitForSeconds(3);
        RestartRide();
    }

    // Update is called once per frame
    void Update() {
        if (moveFlag) {
            var step =  speed * Time.deltaTime;
            bool lineTraversed = false;
            //Vector3 point in lineData)
            if(!lineTraversed && linePointInd < lineData.Count) {
                var point = lineData[linePointInd];
                Vector3 target = transform.position;
                target.x = point.x * graphScaleFactor;
                target.y = point.y * graphScaleFactor;
                target.z = point.z - 60;
                Vector3 newPos = Vector3.MoveTowards(transform.position, target, step);
                offSet = newPos - transform.position;
                transform.position = newPos;
                if (transform.position == target) {
                    if (linePointInd == lineData.Count) {
                        lineTraversed = true;
                        moveFlag = false;
                    }
                    //Debug.Log("Changed goal point");
                    linePointInd++;
                }
            }
        }
    }

    private void SetLineData(List<Vector3> ld) {
        lineData = ld;
        linePointInd = 0;
        StartCoroutine(StartLift());
    }
    
    private void OnEnable() {
        gm.OnLineChange += HandleLineChange;
    }

    private void OnDisable() {
        gm.OnLineChange -= HandleLineChange;
    }

    private void HandleLineChange(List<Vector3> ld) {
        SetLineData(ld);
    }

    public void RestartRide() {
        linePointInd = 0;
        moveFlag = true;
    }
}