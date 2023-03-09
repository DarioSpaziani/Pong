using System;
using UnityEngine;

public class Lifecycle : MonoBehaviour {

    private void Awake() {
        print("Awake");
    }

    private void OnEnable() {
        print("OnEnable");
    }

    void Start()
    {
        print("Start");
    }
    
    void Update()
    {

    }

    private void LateUpdate() {

    }

    private void OnDisable() {
        print("OnDisable");
    }

    private void OnDestroy() {
        print("OnDestroy");
    }
}
