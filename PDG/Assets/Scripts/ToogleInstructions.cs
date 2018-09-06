using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleInstructions : MonoBehaviour {

	public GameObject ObjectToToggle;

	public void InstructionToggle(){
		ObjectToToggle.SetActive(true);
		this.gameObject.SetActive(false);
	}
}
