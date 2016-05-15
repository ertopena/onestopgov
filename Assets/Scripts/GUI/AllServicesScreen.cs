using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AllServicesScreen : AppScreen {

	public ServiceAdapter Adapter { get; private set; }
	public GameObject servicePrefab;
	public RectTransform scrollrectContent;


	void Awake () {
		Adapter = new ServiceAdapter();
	}


	public override void ReportScreenLoaded () {
		var json = System.Convert.ToString (Adapter.GetServices());
		List<Service> services = JsonUtility.FromJson<List<Service>> (json);
	}


	void RenderServices (List<Service> services) {
		// Kill services.
		foreach (RectTransform rt in scrollrectContent.GetComponentsInChildren<RectTransform> ()) {
			Destroy (rt.gameObject);
		}


		// Populate with new services.
		for (int i = 0; i < services.Count; i++) {
			GameObject service = (GameObject)Instantiate (servicePrefab);
			service.transform.SetParent (scrollrectContent, false);
			service.GetComponent<ServiceButton> ().Init (services[i].name, services[i].service_reference, services[i].fields);
		}
	}
}
