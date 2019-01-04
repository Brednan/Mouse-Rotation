using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform MainCamera;

    public Transform Player;

    private Rigidbody rb;

    private PlayerMotor motor;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float lookSensitivity = 3;

	// Use this for initialization
	void Start () {

        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        motor.Move(_velocity);

        // Calculate rotation as a 3D vector (turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;


        //Apply Rotation
        motor.Rotate(_rotation);

        //Calculate camera rotation as a 3D vector (turnung around)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        //Apply camera rotation
        motor.RotateCamera(_cameraRotation);

    }
}
