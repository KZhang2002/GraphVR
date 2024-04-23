using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    private GameManager gm;
    private List<Vector3> lineData;
    private Boolean moveFlag = false;
    [SerializeField] private float speed = 1f;
    
    void Awake() {
        gm = GameManager.Instance;
    }

    // IEnumerator StartLift() {
    //     yield return new WaitForSeconds(5);
    //     foreach (Vector3 point in lineData) {
    //         yield return new WaitForSeconds(0.2f);
    //         
    //     }
    // }

    // Update is called once per frame
    void Update() {
        if (moveFlag) {
            var step =  speed * Time.deltaTime;
            int i = 0;
            bool lineTraversed = false;
            //Vector3 point in lineData)
            while(!lineTraversed) {
                var point = lineData[i];
                Vector3 target = transform.position;
                target.y = point.y;
                transform.position = Vector3.MoveTowards(transform.position, target, step);
                if (transform.position == target) {
                    if (i == lineData.Count) {
                        lineTraversed = true;
                        moveFlag = false;
                    }
                    i++;
                }
            }
        }
    }

    private void SetLineData(List<Vector3> ld) {
        lineData = ld;
        moveFlag = true;
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
}