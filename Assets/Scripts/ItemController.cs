using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		Debug.Log("aa");
		if (col.gameObject.name.Contains ("Player")) {
			col.gameObject.GetComponent<JumperController>().GotJumpItem();
		}
	}
}
