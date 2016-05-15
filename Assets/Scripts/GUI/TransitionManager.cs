using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GUI {

	[System.Serializable]
	public class ScreenInfo {
		public RectTransform rect;
		public string name;
	}


	public class TransitionManager : MonoBehaviour {

		public bool InTransition { get; private set; }
		public int numberOfScreens { get { return screens.Length - 1; } }
		public ScreenInfo[] screens;


		private int _lastScreen = 1;


		public void TransitionToScreen (TabButton tab) {
			if (InTransition)
				return;


			int indexRequested = IndexOfScreenRequested (tab);
			if (indexRequested == _lastScreen)
				return;


			ScreenInfo screenRequested = screens [indexRequested];


			InTransition = true;
			SlideFrom slideFrom = GetSlideFrom (tab);
			GetComponent<ScreenSlider> ().Slide(screenRequested.rect, slideFrom);
			GetComponent<TitleText> ().FadeTitle (screenRequested.name);


			_lastScreen = indexRequested;
		}


		int IndexOfScreenRequested (TabButton tab) {
			return tab.transform.GetSiblingIndex ();
		}


		ScreenInfo ScreenRequested (TabButton tab) {
			return screens[IndexOfScreenRequested (tab)];
		}


		SlideFrom GetSlideFrom (TabButton tab) {
			SlideFrom slideFrom;


			if (IndexOfScreenRequested (tab) > _lastScreen)
				return SlideFrom.Right;
			else
				return SlideFrom.Left;
		}


		public void ReportTransitionEnd () {
			InTransition = false;
		}
	}
}
