namespace SpencerHaney
{
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public GameObject CellPrefab;
        public GameObject HexGridPrefab;

        void Start()
        {
            HexGrid.CellPrefab = CellPrefab;
            CreateHexGrid();
        }

        void Update()
        {

        }

        public HexGrid CreateHexGrid()
        {
            GameObject obj = Instantiate(HexGridPrefab);
            HexGrid hg = obj.GetComponent<HexGrid>();
            return hg;
        }
    }
}