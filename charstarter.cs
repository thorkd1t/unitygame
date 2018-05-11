using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class charstarter : MonoBehaviour {
	public GameObject pl;
	// Use this for initialization
	void Start () {
		Instantiate(pl);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
 }