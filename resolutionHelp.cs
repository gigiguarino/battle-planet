using UnityEngine;
using System.Collections;

public class resolutionHelp : MonoBehaviour {

	Resolution res;

	// Use this for initialization
	void Start () 
	{
		res = Screen.currentResolution;

		if (res.refreshRate == 60) 
		{
			QualitySettings.vSyncCount = 1;
		}

		if (res.refreshRate == 120)
		{
			QualitySettings.vSyncCount = 2;
		}
	}
}
