
using UnityEngine;

public class Gun : MonoBehaviour
{

	public float damage = 10f;
	public float range = 100f;

	public Camera fpsCam;
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Shoot()
	{
		muzzleFlash.Play ();

		RaycastHit hit;
		if(Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log (hit.transform.name);
		}

		GameObject impactGO = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
		Destroy (impactGO, 1.0f);
	}
}
