namespace SpencerHaney
{ 
	using System.Collections.Generic;
	public class Colony
	{
		private List<ColonyCell> _cells;

		public Colony ()
		{
			_cells = new List<ColonyCell> ();
		}

		public void AddCell(ColonyCell cell)
		{
			_cells.Add (cell);
		}
	}
}