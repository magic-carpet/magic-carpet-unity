using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMovement : MonoBehaviour {

    private Rigidbody rb;
    public bool strongWind = false;

    public float MoveSpeed = 50.0f;

    public float frequency = 40.0f;  // Speed of sine movement
    public float magnitude = 2.0f;   // Size of sine movement
    private Vector3 axis;

    private Vector3 pos;

    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
        transform.localScale = Vector3.one * Random.Range(0.5f, 2.5f);
        pos = transform.position;
        Destroy(gameObject, 10.0f);
        axis = transform.right;  // May or may not be the axis you want

    }
	
	// Update is called once per frame
	void Update () {

        pos -= transform.forward * Time.deltaTime * MoveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Panel"){
            //Debug.Log("Wind hit " + other.gameObject.name);
            if (strongWind)
            {
                other.gameObject.GetComponent<PanelSpin>().WindStrongSpinPanel();
            }else{
                other.gameObject.GetComponent<PanelSpin>().WindGentleSpinPanel();
            }
        }
    }
}
