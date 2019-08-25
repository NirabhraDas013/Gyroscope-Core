using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
	private bool gyroEnabled;
	private Gyroscope gyro;

	private GameObject cameraContainer;
	private Quaternion rot;

	private Quaternion origin = Quaternion.identity;

	private void Start()
	{
		cameraContainer = new GameObject ("CameraContainer");
		cameraContainer.transform.position = transform.position;

		transform.SetParent (cameraContainer.transform);
		gyroEnabled = EnableGyro ();
	}

	private void Update()
	{
		if(gyroEnabled)
		{
			transform.localRotation = gyro.attitude * rot;
		}
	}

	private bool EnableGyro()
	{
		if(SystemInfo.supportsGyroscope)
		{
			gyro = Input.gyro;
			gyro.enabled = true;

			cameraContainer.transform.rotation = Quaternion.Euler (90f, 90f, 0);
			rot = new Quaternion (0, 0, 1, 0);

			return true;
		}

		return false;
	}

	void OnGUI() {
		GUILayout.Label(origin.eulerAngles+" <- origin");
		GUILayout.Label(Input.gyro.attitude.eulerAngles+" <- gyro");
		GUILayout.Label(Quaternion.Inverse(Input.gyro.attitude).eulerAngles+" <- inv gyro");
		GUILayout.Label(transform.localRotation.eulerAngles+" <- localRotation");
	}
}
