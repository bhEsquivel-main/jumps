using UnityEngine;
using System.Collections;

public class JumperController : MonoBehaviour {

	[SerializeField] private ItemManager m_IM = default(ItemManager);
	[SerializeField] private bool m_cheatEnable = false;
	[SerializeField] private Rigidbody m_rb = default(Rigidbody);
	[SerializeField] private float m_MAX_JUMP_HEIGHT = 125f;
	public float m_JumpPower = 5f;

	[SerializeField] private bool canJump = false;

	private Vector3 m_MAX_JUMP = Vector3.zero;


	void Start(){
		canJump = true;
	}

	public void RestartGame(){
		Application.LoadLevel(0);
	}
	public void StartGame(){
		m_IM.InitGame();		
	}

	void Update () {

	

		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			Debug.Log("Jump");
			canJump = false;
			m_MAX_JUMP = transform.localPosition;
			m_MAX_JUMP.y += m_MAX_JUMP_HEIGHT;
			m_rb.velocity = Vector3.zero;
			Jump();
		}

		if (Input.GetKey (KeyCode.Space)) {
			if(transform.localPosition.y <= m_MAX_JUMP.y){
				JumpAdd();
			}
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			Debug.Log("Jump");
			canJump = false;
			m_MAX_JUMP = transform.localPosition;
			m_MAX_JUMP.y += m_MAX_JUMP_HEIGHT;
			Jump();
		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) {
			if(transform.localPosition.y <= m_MAX_JUMP.y){
				JumpAdd();
			}
		}



	}

	private void Jump(){
		m_rb.AddForce (transform.up * m_JumpPower,ForceMode.VelocityChange);
	}

	private void JumpAdd(){
		m_rb.AddForce (transform.up * m_JumpPower * 2f, ForceMode.Acceleration);
	}

	public void GotJumpItem(){
		canJump = true;
	}


	void OnTriggerEnter(Collider col){
		Debug.Log (col.collider.gameObject.name);
		if (col.collider.gameObject.name.Contains ("item0")) {
			GotJumpItem();		
		}
	}
}
