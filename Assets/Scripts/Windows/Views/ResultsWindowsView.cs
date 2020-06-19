using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.Views
{
	public class ResultsWindowsView: AWindowView
	{
		public GameObject Tab;
		public Button StatisticButton;
		public Button SearchButton;
		public Button PlusButton;
		public Button SettingsWindow;

		
		public TextMeshProUGUI Concentration;
		public TextMeshProUGUI Updated;
		public TextMeshProUGUI Danger;
		
		public TextMeshProUGUI OutputTime;
		public TextMeshProUGUI Undrink;
		public TextMeshProUGUI InAir;
	}
}