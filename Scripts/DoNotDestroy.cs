using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{

	void Awake()
	{
		GameObject[] obj = GameObject.FindGameObjectsWithTag("MSMusic");
		if (obj.Length > 1)
			Destroy(this.gameObject);

		DontDestroyOnLoad(this.gameObject);
	}
}