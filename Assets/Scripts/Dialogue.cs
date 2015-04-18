using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

	public string[] dialogueText;
	public GUIText output;
	public float timer = 0f;

	private bool active = false;
	private int curLine = 0;
	private bool triggered = false;

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player") && triggered == false) {
			output.enabled = true;
			output.text = this.dialogueText[0];
			curLine = 0;
			active = true;
			timer = 0f;
		}
	}

	void Update() {
		if (active) {
			timer += 1.0f * Time.deltaTime;
		}
	}

	void OnGUI () {
		//if (output.enabled && !triggered && Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return) {
		if (active && !triggered) {

			if (timer >= 3f) {
				curLine++;
				timer = 0f;
			}

			if (curLine < dialogueText.Length) {
				output.text = dialogueText[curLine];
			} else {
				curLine = 0;
				output.enabled = false;
				triggered = true;
				active = false;
			}
		}
	}
}
