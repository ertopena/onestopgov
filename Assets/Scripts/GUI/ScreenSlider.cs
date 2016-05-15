using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GUI {

	public enum SlideFrom {
		Left,
		Right
	}

	public class ScreenSlider : MonoBehaviour {

		public static bool IsSliding { get; private set; }

		public RectTransform slidingScreen;
		public SlideFrom slideFrom;


		public void Slide () {
			if (!IsSliding) {
				IsSliding = true;
				StopAllCoroutines ();
				StartCoroutine (CoSlide ());
			}
		}


		IEnumerator CoSlide () {
			Vector2 centeredPos = slidingScreen.anchoredPosition;


			// Place sliding screen in its starting position.
			float factor = slideFrom == SlideFrom.Left ? -1f : 1f;
			slidingScreen.anchoredPosition += new Vector2 (factor * slidingScreen.rect.width, 0);


			// Place it above all the other screens on the hierarchy.
			slidingScreen.SetAsLastSibling ();


			// Slide in.
			for (int i = 0; i < 20; i++) {
				slidingScreen.anchoredPosition = Vector2.Lerp(slidingScreen.anchoredPosition, centeredPos, 0.3f);
				yield return new WaitForFixedUpdate ();
			}


			// End motion and allow sliding again.
			slidingScreen.anchoredPosition = centeredPos;
			IsSliding = false;
		}
	}
}
