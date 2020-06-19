using System;
using Windows.Views;
using Core;
using DG.Tweening;
using UnityEngine;

namespace Windows
{
	public class ResultsWindowsPresenter: AWindowPresenter
	{
		private readonly ResultsWindowsView _view;
		private readonly IWindowsController _windowsController;

		public ResultsWindowsPresenter(ResultsWindowsView view, IWindowsController windowsController) : base(view)
		{
			_view = view;
			_windowsController = windowsController;
		}

		public override void Show()
		{
			base.Show();
			Subscribe();
		}

		private void Subscribe()
		{
			_view.SettingsWindow.onClick.AddListener(OnSettingsClick);
			_view.StatisticButton.onClick.AddListener(OnStatisticClick);
			_view.PlusButton.onClick.AddListener(OnPlusClick);
			_view.SearchButton.onClick.AddListener(OnSearchClick);
			FillData();
		}

		private void OnSettingsClick()
		{
			D.Error($"Settings!");
			_windowsController.Window<PropsWindowPresenter>().Open();
		}

		private void OnStatisticClick()
		{
			D.Error($"Statistic!");
			_windowsController.Window<StatisticWindowPresenter>().Open();
		}

		private void OnPlusClick()
		{
			D.Error($"Plus!");
			_windowsController.Window<InputWindowPresenter>().Open();
		}

		private void OnSearchClick()
		{
			D.Error($"Search");
			Data.Ready = false;
			Data.Promile = 0f;
		}

		private void FillData()
		{
			_view.Tab.SetActive(Data.Ready);
			var len = Math.Min(Data.Promile.ToString().Length, 4);
			_view.Concentration.text = Data.Promile.ToString().Substring(0, len).Replace(',', '.');
			// _view.Updated.text = "";
			// _view.Danger.text = "";
			_view.OutputTime.text = $"{Mathf.Clamp(Mathf.RoundToInt(Data.Promile / 0.15f), 0, 50)} часов {Mathf.Clamp(Mathf.Abs(Mathf.RoundToInt(60*(Data.Promile / 0.15f - Mathf.RoundToInt(Data.Promile / 0.15f)))), 0, 59)} минут";
			_view.Undrink.text = $"{Mathf.Clamp(Mathf.RoundToInt(Data.Promile / 0.15f) - 2, 0, 50)} часов {Mathf.Clamp(Mathf.Abs(Mathf.RoundToInt(60*(Data.Promile / 0.15f - Mathf.RoundToInt(Data.Promile / 0.15f)))), 0, 59)} минут";
			len = Math.Min((Data.Promile / 0.3f * 0.16f).ToString().Length, 4);
			_view.InAir.text = $"{(Data.Promile / 0.3f * 0.16f).ToString().Substring(0, len).Replace(',', '.')} мг/л";
		}
	}
}