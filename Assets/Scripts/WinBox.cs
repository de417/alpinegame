using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other) {
		GameObject.Find("Player").SendMessage("Finish");
		
	}

}
