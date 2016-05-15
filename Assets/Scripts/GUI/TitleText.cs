using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GUI {
	public class TitleText : MonoBehaviour {

		public Text title;


		private Color clear = new Color(1f, 1f, 1f, 0);


		public void FadeTitle (string newText) {
			StopAllCoroutines ();
			StartCoroutine (CoFadeTitle (newText));
		}


		IEnumerator CoFadeTitle (string newText) {

			for (int i = 0; i < 20; i++) {
				title.color = Color.Lerp (Color.white, clear, (float)i / 20);
				yield return new WaitForFixedUpdate ();
			}


			title.color = Color.clear;
			title.text = newText;
			yield return new WaitForFixedUpdate ();


			for (int i = 0; i < 20; i++) {
				title.color = Color.Lerp (clear, Color.white, (float)i / 20);
				yield return new WaitForFixedUpdate ();
			}


			title.color = Color.white;
		}
	}
}
