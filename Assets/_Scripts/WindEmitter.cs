using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEmitter : MonoBehaviour {

    [SerializeField] private GameObject _windObject;
    [SerializeField] private GameObject _windEmitterObject;
    [SerializeField] private Transform _windParentObject;
    private float _timer;
    private Vector3 _currentPosn;
    private Bounds _bounds;
    [SerializeField] bool _strongWind = false;
    //
    [SerializeField]  private float _speed = 2f;
    [SerializeField] private float _maxRotation = 20f;

    // Use this for initialization
    void Start () {
        _bounds = _windEmitterObject.GetComponent<MeshRenderer>().bounds;
        StartCoroutine(BlowWind());
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0f,(_maxRotation * Mathf.Sin(Time.time * _speed)-270), 0f);
    }

    public IEnumerator BlowWind(){
        //Debug.Log("Blowing Wind");
        _timer = Random.Range(0.1f, 0.3f);

        yield return new WaitForSeconds(_timer);
        var clone = Instantiate(_windObject, GetRandomPosition(), _windEmitterObject.transform.rotation, _windParentObject);
        if (_strongWind)
        {
            clone.GetComponent<WindMovement>().strongWind = true;
        }
        StartCoroutine(BlowWind());
    }

    private Vector3 GetRandomPosition()
    {
       _currentPosn = new Vector3(Random.Range(_bounds.min.x, _bounds.max.x), Random.Range(_bounds.min.y, _bounds.max.y), _bounds.center.z);
        return _currentPosn;
        }

}
