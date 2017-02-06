﻿namespace SpencerHaney
{
	using UnityEngine;
	using UnityEngine.UI;

	public class GameManager : MonoBehaviour
	{
		public GameObject CellPrefab;
		public GameObject HexGridPrefab;
		public Text FoodText;
		public Text MetalText;
		public Text NaquadahText;
		Planet Planet;

		public static GameManager Instance
		{
			get;
			set;
		}

		void Awake ()
		{
			DontDestroyOnLoad (transform.gameObject);
			Instance = this;
		}

		void Start ()
		{
			HexGrid.CellPrefab = CellPrefab;
			Planet = new Planet ();
			Planet.Grid = CreateHexGrid ();
		}

		void Update ()
		{

		}

		public HexGrid CreateHexGrid ()
		{
			GameObject obj = Instantiate (HexGridPrefab);
			HexGrid hg = obj.GetComponent<HexGrid> ();
			return hg;
		}
	}
}