using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostitScale : MonoBehaviour {

    private Vector3 escala;
    private Transform currentParent;

	void Start () {
        escala = transform.lossyScale;
        currentParent = transform.parent;
	}
	
	void Update () {
		if(currentParent != transform.parent) {
            currentParent = transform.parent;
            Transform parentTransform = transform.parent;
            transform.localScale = new Vector3(escala.x/parentTransform.localScale.x, escala.y / parentTransform.localScale.y, escala.z / parentTransform.localScale.z);
        }
	}
}
