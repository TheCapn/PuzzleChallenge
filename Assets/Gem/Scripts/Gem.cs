using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gem : Tile 
{
	public enum Colors
	{
		black,
		blue,
		green,
		orange,
		purple,
		red,
		white,
		yellow
	}
	
	public List<Material> gemMaterials = new List<Material>();
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
