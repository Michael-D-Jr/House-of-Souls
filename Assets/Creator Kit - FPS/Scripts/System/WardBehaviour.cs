using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardBehaviour : MonoBehaviour
{

   Vector3[] wardPositions = { new Vector3(40, 2, -66), new Vector3(-17, 2, -66), new Vector3(40, 2, 15) };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /// <summary>
   /// Checks for a Collision with an object that has a Controller, which is the player character
   /// </summary>
   /// <param name="other">Collision with the player</param>
	private void OnTriggerEnter(Collider other)
	{
      Controller c = other.GetComponent<Controller>();

      if (c != null)
      {
         gameObject.GetComponent<MeshRenderer>().enabled = false;
         StartCoroutine(PauseTimer());
      }
   }

   //IEnumerator to determine the length of time the ward pauses the timer for
   private IEnumerator PauseTimer()
	{
      GameSystem.Instance.StopTimer();
      yield return new WaitForSeconds(10);
      GameSystem.Instance.StartTimer();
      //gameObject.SetActive(false);
      StartCoroutine(MoveWard());
	}

   //IEnumerator to move the Ward to a new position and make it visible again
   private IEnumerator MoveWard()
	{
      gameObject.transform.position = wardPositions[Random.Range(0, 3)];
      yield return new WaitForSeconds(12);
      //gameObject.SetActive(true);
      gameObject.GetComponent<MeshRenderer>().enabled = true;
      

	}
}
