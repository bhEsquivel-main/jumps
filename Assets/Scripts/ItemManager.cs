using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ItemManager : MonoBehaviour {



	public JumperController m_jumperController;
	public Vector3 m_itemStartPos;
	private bool isInitialized = false;

	[SerializeField] private Transform m_platform;

	
	private ItemController[] m_itemControllerList;

	void Awake(){
		m_itemControllerList = GetComponentsInChildren<ItemController> ();
	}

	public void InitGame(){
		if (!isInitialized)
			StartCoroutine (StartGame ());
	}

	private IEnumerator StartGame(){
		yield return new WaitForEndOfFrame();
		m_platform.GetComponent<TweenPosition> ().enabled = true;
		while (true) {
			Debug.Log("log");
			GetAvailableItem().Enable();   
			yield return new WaitForSeconds(GetNextSpawnTime());
		}

	}

	private ItemController GetAvailableItem(){
		ItemController ic =	m_itemControllerList.First(x => x.IsEnable == false);
		return ic;
	}

	private float GetNextSpawnTime(){
		return (Random.Range (0, 2) + 1) * 0.4f ;
	}

	public void DestroyMe(){
		Destroy (gameObject);
	}
}
