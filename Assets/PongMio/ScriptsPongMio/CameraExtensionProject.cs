﻿using UnityEngine;

namespace PongMio {

	public static class CameraExtensionProject {
		public static Bounds OrthographicBounds(this Camera camera){
			float screenAspect = (float) Screen.width / (float) Screen.height;
			float cameraHeight = camera.orthographicSize * 2;
			Bounds bounds = new Bounds(
				camera.transform.position,
				new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
			return bounds;
		}
	}

}