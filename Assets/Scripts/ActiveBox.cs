using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class ActiveBox : MonoBehaviour
{
	[SerializeField]
	private float _forceGain;
    [SerializeField]
    private GameObject _target2Throw;
	private Rigidbody _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			Throw();
	}

	private void Throw()
	{
		Vector3 _direction = _target2Throw.transform.position - transform.position;
		_direction += Vector3.up;
		_rb.AddForce(_direction * _forceGain, ForceMode.Impulse);
	}
}
