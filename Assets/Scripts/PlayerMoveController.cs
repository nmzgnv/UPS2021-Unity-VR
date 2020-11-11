using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMoveController : MonoBehaviour
{
	[SerializeField]
	private float _horizontalSensivity = 2f;

	private CharacterController _characterController;
	private GameManager _gameManager;
	private Animator _animator;

	private float _speed = 6f;
	private float _gravity = 20.0f;

	private Vector3 _moveDirection = Vector3.zero;

	private string _runningAnimId = "Running";
	private string _sideRunningAnimId = "SideRunning";
	private string _dieAnimId = "Death";

	void Start()
	{
		_gameManager = FindObjectOfType<GameManager>();
		_characterController = GetComponent<CharacterController>();
		_animator = GetComponent<Animator>();
	}

	void Update()
	{
		float _horizontalAngle = _horizontalSensivity * Input.GetAxis("Mouse X");
		if (!_gameManager.IsGameEnded)
			transform.Rotate(0, _horizontalAngle, 0);

		if (_characterController.isGrounded)
		{
			var _verticalInput = Input.GetAxis("Vertical");
			var _horizontalInput = Input.GetAxis("Horizontal");

			_animator.SetFloat(_runningAnimId, _verticalInput);
			_animator.SetFloat(_sideRunningAnimId, _horizontalInput);

			_moveDirection = new Vector3(_horizontalInput, 0, _verticalInput);
			_moveDirection *= _speed;
			_moveDirection = this.transform.TransformDirection(_moveDirection);
		}
		_moveDirection.y -= _gravity * Time.deltaTime;

		if (!_gameManager.IsGameEnded)
			_characterController.Move(_moveDirection * Time.deltaTime);
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.tag == "Respawn")
		{
			_gameManager.GameOver();
			_animator.Play(_dieAnimId);
		}
	}

}
