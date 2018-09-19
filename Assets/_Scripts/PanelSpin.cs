using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSpin : MonoBehaviour {

    private Rigidbody _rb;
    [SerializeField] private float _rotSpeed=100f;
	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
       //_rb.AddTorque(Vector3.forward * _rotSpeed);

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void SpinPanel(){
        float rand = Random.Range(_rotSpeed - 20f, _rotSpeed + 20f);
        _rb.AddTorque(Vector3.forward * rand);

    }

    public void WindGentleSpinPanel()
    {
        float rand = Random.Range(_rotSpeed - 101f, _rotSpeed - 99f);
        _rb.AddTorque(Vector3.forward * rand);

    }

    public void WindStrongSpinPanel()
    {
        float rand = Random.Range(_rotSpeed - 99f, _rotSpeed - 98f);
        _rb.AddTorque(Vector3.forward * rand);

    }

    public void TouchSpinPanel()
    {
        float rand = Random.Range(_rotSpeed - 20f, _rotSpeed + 20f);
        _rb.AddTorque(Vector3.forward * rand);

    }
}
