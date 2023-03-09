using UnityEngine;

namespace LezioneBasi {

	public class Car : MonoBehaviour {
		private string brand, model, plate;

		public Car(string brand, string model, string plate) {
			this.brand = brand;
			this.model = model;
			this.plate = plate;
		}

		public string getBrand() {
			return brand;
		}

		public string getModel() {
			return model;
		}

		public void setPlate(string plate) {
			this.plate = plate;
		}

		public string getPlate() {
			return plate;
		}
	}

}

