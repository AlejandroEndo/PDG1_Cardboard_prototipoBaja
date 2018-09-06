using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction : MonoBehaviour {

    public GameObject postHolder;
    private GameObject onPointerObject;

    public Camera camara;

    private GameObject selectedPostit;
    public bool selected;

    public LayerMask postitMask;
    public LayerMask boardMask;
    public LayerMask instructionMask;

    [SerializeField]
    [Range(0f, 2f)]
    private float offset;
    
    [Range(0,100)]
    public float rayDistance;

    [Range(0,1)]
    public float emissionValue;

    void Start() {
        selected = false;
    }

    void Update() {
        Vector3 rotation = new Vector3(postHolder.transform.rotation.x, camara.transform.rotation.y, postHolder.transform.rotation.z);

        //postHolder.transform.rotation = Quaternion.Euler(45, camera.transform.rotation.y, camera.transform.rotation.z);
        //Quaternion rotation = Quaternion.Euler(camera.transform.localRotation);
        postHolder.transform.rotation = camara.transform.localRotation;

        Vector3 position = Vector3.Normalize(camara.transform.position) * 5;
        position.y = 0.8f;
        postHolder.transform.position = position;
        
    }

    public void Click() {

        RaycastHit hit;
        if (selected) {
            if (Physics.Raycast(camara.transform.position, camara.transform.TransformDirection(Vector3.forward), out hit, rayDistance, boardMask)) {
                selectedPostit.transform.position = hit.point + hit.normal * 0.02f; // Posicion post-it cuando coloco
                //selectedPostit.transform.parent = hit.transform;
                selectedPostit.transform.SetParent(hit.transform);
                selectedPostit.transform.localRotation = Quaternion.Euler(0,0,0);
                selectedPostit = null;
                selected = false;
            }
        } else if (!selected) {
            if (Physics.Raycast(camara.transform.position, camara.transform.TransformDirection(Vector3.forward), out hit, rayDistance, postitMask)) {
                hit.transform.parent = postHolder.transform;
                hit.transform.localPosition = new Vector3(0, offset, 0.3f); // Aqui!
                hit.transform.rotation = postHolder.transform.rotation;
                selectedPostit = hit.transform.gameObject;
                selected = true;
            }
        }
    }

    public void showInstructions(){

        RaycastHit hit;
        if (Physics.Raycast(camara.transform.position, camara.transform.TransformDirection(Vector3.forward), out hit, rayDistance, instructionMask)) {
            hit.transform.GetComponent<ToogleInstructions>().InstructionToggle();
        }
    }
}
