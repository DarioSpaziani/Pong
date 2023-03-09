using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CoroutineTest : MonoBehaviour {
	private List<int> numbers = new List<int>();
	private int frameCount = 0;
	
	private void Start() {
		for (int i = 0; i < 5; i++) {
			numbers.Add(i);
		}
		StartCoroutine(myCoroutine());
	}

	private void Update() {
		frameCount++;
	}

	private IEnumerator myCoroutine() {
		foreach (int n in numbers) {
			yield return new WaitForSeconds(0.5f);
			print(n + " frame : " + frameCount);
		}
	}
}
