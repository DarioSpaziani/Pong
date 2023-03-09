using UnityEngine;

namespace LezioneBasi 
{
	public class TemperatureExample : MonoBehaviour
	{
		void Start() {
			float c = TemperatureConverter.fahrenheitToCelsius(50.5f);
			print("celsius : " + c);

			float f = TemperatureConverter.celsiusToFahrenheit(20.5f);
			print("fahrenheit : " + f);
		}
    
	}
}