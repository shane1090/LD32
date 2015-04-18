using UnityEngine;
using System.Collections;

public class PickedObject : MonoBehaviour {

	Vector3 objectPosition;
	Quaternion objectRotation;
	GameObject pickedObject;
	bool canPick = true;
	bool picking = false;
	bool guiPick = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		guiPick = false;
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 10f)) {

			Debug.DrawLine(ray.origin, hit.point, Color.red);

			if (hit.collider.gameObject.tag == "PickUp") {
				guiPick = true;
			}

			if (guiPick) {
				objectPosition = transform.position;
				objectRotation = transform.rotation;

				if (Input.GetMouseButtonDown(0) && canPick) {
					picking = true;

					pickedObject = hit.collider.gameObject;
					hit.rigidbody.useGravity = false;
					hit.rigidbody.isKinematic = true;
					hit.collider.isTrigger = true;
					hit.transform.parent = gameObject.transform;
					hit.transform.position = objectPosition;
					hit.transform.rotation = objectRotation;
				}
			}
		}

		if (Input.GetMouseButtonUp (0) && picking) {
			picking = false;
			canPick = false;
		}

		if (Input.GetMouseButtonDown (0) && !canPick) {
			canPick = true;
			Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
			Collider cd = pickedObject.GetComponent<Collider>();

			rb.useGravity = true;
			rb.isKinematic = false;
			pickedObject.transform.parent = null;
			cd.isTrigger = false;
			rb.AddForce (transform.forward * 1000);
			pickedObject = null;
		}
	}

	void OnGUI () {
		GUI.contentColor = Color.black;

		if (guiPick && canPick) {
			GUI.Label (new Rect (Screen.width / 2f, Screen.height / 2f, Screen.width / 2f, Screen.height / 2f), "Pick Up");
		}
	}
}
