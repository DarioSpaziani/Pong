namespace LezioneBasi 
{
	public class TemperatureConverter 
	{
		public static float celsiusToFahrenheit(float celsius) {
			return (celsius * 9 / 5) + 32;
		}

		public static float fahrenheitToCelsius(float fahrenheit) {
			return (fahrenheit - 32) * 5 / 9;
		}
	}
}