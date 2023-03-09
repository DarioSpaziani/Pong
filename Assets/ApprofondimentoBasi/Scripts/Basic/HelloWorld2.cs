using UnityEngine;

namespace LezioneBasi {

	public class HelloWorld2 : MonoBehaviour
	{
		//esempio per i modificatori di accesso
   
		//quando si dichiara accessibilità tipo e nome è una dichiarazione;


		private string first;
		public string second = "second";
   
		//la seconda variabile non viene considerata nel codice, MA ha la priorità ciò che viene assegnato nell'editor di Unity.

		private void Start() {
			//quando si assegna un valore è un assegnamento e sovrascriverà ciò che abbiamo inserito nell'editor
			first = "first";
			second = "second";
			print(first);
			print(second);
		}
   
		//Esempio per lo Scope = la visibilità di una variabile
		private void foo() {
			string myString = "myString";
			print(first);
			print(myString);
		}
   
		/*Se proviamo a prendere una variabile globale lo possiamo fare tranquillamente,
		//se invece proviamo a prendere una variabile private dichiarata in una funzione privata vedremo che non è possibile.
		//poiché dal momento che siamo in un blocco diverso, questa variabile non sarà visibile.*/
   
		private void bar() {
			print(first);
			//print(myString);  //QUESTA NON è POSSIBILE PRENDERLA PERCHE' DICHIARATA IN UN ALTRO BLOCCO
		}
	}


}
