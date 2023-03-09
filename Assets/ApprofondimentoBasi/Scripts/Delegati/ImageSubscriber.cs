using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Delegati 
{
	public class ImageSubscriber : MonoBehaviour {
		//da assegnare ad un gameObject con image (Canvas -> Image)

		public Image image;

		private void Start() {
			if (ExampleDelegateManager.Instance != null) {
				ExampleDelegateManager.Instance.pressedSpaceBar += ShowImage;
			}
		}

		private void OnDestroy() {
			if (ExampleDelegateManager.Instance != null) {
				ExampleDelegateManager.Instance.pressedSpaceBar -= ShowImage;
			}
		}

		private void ShowImage() {
			if (image != null) {
				Color randomColor = Random.ColorHSV();
				image.color = randomColor;
			}
		}
	}

}