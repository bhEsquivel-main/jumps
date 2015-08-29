using UnityEngine;
using System.Collections;

public class JumperController : MonoBehaviour {

	[SerializeField] private bool m_cheatEnable = false;
	[SerializeField] private Rigidbody m_rb = default(Rigidbody);
	[SerializeField] private float m_MAX_JUMP_HEIGHT = 125f;
	public float m_JumpPower = 5f;

	[SerializeField] private bool canJump = false;

	private Vector3 m_MAX_JUMP = Vector3.zero;


	void Start(){
		canJump = true;
	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(0);
		}

		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			Debug.Log("Jump");
			canJump = false;
			m_MAX_JUMP = transform.localPosition;
			m_MAX_JUMP.y += m_MAX_JUMP_HEIGHT;
			Jump();
		}

		if (Input.GetKey (KeyCode.Space)) {
			if(transform.localPosition.y <= m_MAX_JUMP.y){
				JumpAdd();
			}
		}


	}

	private void Jump(){
		m_rb.AddForce (transform.up * m_JumpPower,ForceMode.VelocityChange);
	}

	private void JumpAdd(){
		m_rb.AddForce (transform.up * m_JumpPower * 2, ForceMode.Acceleration);
	}

	public void GotJumpItem(){
		canJump = true;
	}

	
	void OnCollisionEnter(Collision col){
		Debug.Log (col.collider.gameObject.name);
		if (col.collider.gameObject.name.Contains ("Platform")) {
			GotJumpItem();		
		}
	}
}
