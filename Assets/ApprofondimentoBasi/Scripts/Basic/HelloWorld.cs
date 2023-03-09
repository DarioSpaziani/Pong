using UnityEngine;

namespace LezioneBasi {
	public class HelloWorld : MonoBehaviour {

		//esempio per dimostrare il costruttore(Vedi script car) e come riutilizzarlo modificandolo a seconda della funzione
		private void Start() {
			Car FirstCar = new Car("Volkswgen", "A4", "TT456YY");
			Car SecondCar = new Car("Ferrari", "AA", "CJ765UI");
			//ora possiamo far eseguire azioni a questi due oggetti
        
			print(FirstCar.getBrand());
			print(SecondCar.getBrand());
        
		}
	}
    

}

