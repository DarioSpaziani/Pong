using System.Collections.Generic;
using UnityEngine;

namespace LezioneBasi 
{
	public class WhileTest : MonoBehaviour {

		private List<int> numbers;
    
		void Start() {
			WhileLoop();
			DoWhileLoop();
			ForLoop();
			ForEachLoop();
		}
    
		void WhileLoop() //esegue il codice finché è vera
		{
			int number = 0;
			while (number < 5) {
				print("while :" +number);
				number += 1;
			}
		}

		void DoWhileLoop() { // anche questo esegue il codice ma controlla DOPO la condizione
			int number = 0;  // quindi sempre almeno una volta il codice verrà eseguito
			do {
				print("do :" + number);
				number = number + 1;
			} while (number < -1);
		}

		void ForLoop() {
			for (int i = 0; i < 5; i++) {
				numbers.Add(i);
			}
		}

		void ForEachLoop() {
			foreach (int n in numbers) {
				print("n : " + n);
			}
		}
	}
}
