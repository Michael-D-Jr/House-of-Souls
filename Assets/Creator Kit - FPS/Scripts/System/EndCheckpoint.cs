using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
      Debug.Log("Something entered the checkpoint");
	}

	void OnTriggerStay (Collider other)
    {
        if (other.GetComponent<Controller>() == null)
            return;

		if (Input.GetButton("Interact"))
		{
         GameSystem.Instance.StopTimer();
         GameSystem.Instance.Win();
         Destroy(gameObject);
      }
      /*
        GameSystem.Instance.StopTimer();
        GameSystem.Instance.FinishRun();
        Destroy(gameObject);*/
    }

}
