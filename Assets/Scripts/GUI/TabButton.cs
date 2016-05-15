using UnityEngine;
using System.Collections;

namespace GUI {
	public class TabButton : MonoBehaviour {

		public void RequestTabSlide () {
			int siblingOrder = transform.GetSiblingIndex ();
			GetComponentInParent<TransitionManager> ().TransitionToScreen (this);
		}
	}
}
