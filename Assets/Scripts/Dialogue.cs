using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

	public string[] dialogue;
	public GUIText output;

	private int curLine = 0;
	private bool triggered = false;

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player") && triggered == false) {
			output.enabled = true;
			output.text = dialogue [0];
		}
	}

	void OnGUI () {
		if (output.enabled && Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return) {
			curLine++;
			if (curLine < dialogue.Length) {
				output.text = dialogue[curLine];
			} else {
				curLine = 0;
				output.enabled = false;
				triggered = true;
			}
		}
	}
}
