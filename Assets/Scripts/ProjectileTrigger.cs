using UnityEngine;
using System.Collections;

public class ProjectileTrigger : MonoBehaviour {
	public GameObject projectile;
	public float speed = 50.0f;

	// prevents spamming trigger;
	float cooldownMax = 0.2f;
	float cooldown = 0.2f;

	bool canShoot = true;

	void Start () {

	}

	void Update () {
		if(GvrViewer.Instance.Triggered && canShoot) {
			fireProjectile();
		}
		if(Input.GetMouseButtonDown(0) && canShoot) {
			fireProjectile();
		}

		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
			if (cooldown <= 0) {
				canShoot = true;
			}
		}
	}

	void fireProjectile() {
		canShoot = false;
		cooldown = cooldownMax;
		GameObject vrLauncher = GvrViewer.Instance.gameObject;
		GameObject _projectile = Instantiate (projectile, vrLauncher.transform.position, vrLauncher.transform.rotation) as GameObject;
		_projectile.GetComponent<Rigidbody>().velocity = vrLauncher.transform.forward*speed;
	}
}
