using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	[SerializeField] private bool isEnabled = false;
	[SerializeField] private float m_xAllowance = 100f;
	[SerializeField] private TweenPosition m_tweenPos = default(TweenPosition);

	public bool IsEnable{
		get {
			return isEnabled;
		}
	}

	void Start(){
		Disable ();
		m_tweenPos.enabled = false;
	}

	public void Enable(){
		isEnabled = true;	
		m_tweenPos.enabled = true;
		m_tweenPos.ResetToBeginning ();
		m_tweenPos.PlayForward ();
	}

	public void Disable(){
		isEnabled = false;
		//m_tweenPos.enabled = false;
	}



}
