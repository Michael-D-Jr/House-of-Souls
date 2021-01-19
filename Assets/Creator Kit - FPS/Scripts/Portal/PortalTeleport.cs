using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
   //prefab to instantiate
   public GameObject originalPortal;

   //Array to hold spawn point locations
   Vector3[] spawnPoints = { new Vector3(0, 2, 0), new Vector3(21, 2, 16), new Vector3(68, 2, 16), new Vector3(87, 2, 40), new Vector3(45, 2, 40), new Vector3(-6, 2, 40),
                             new Vector3(-68, 2, 40),new Vector3(-57, 2, 3),new Vector3(-57, 2, -14),new Vector3(-15, 2, -29),new Vector3(-15, 2, -64),new Vector3(68, 2, -64)};

   void Awake()
	{
      
	}

	// Start is called before the first frame update
	void Start()
   {
      //use a coroutine to move portal rather than destroing it and instantiating a new one
      StartCoroutine(PortalTimer());
   }

   // Update is called once per frame
   void Update()
   {

   }

   /// <summary>
   /// Method to control when to make and move the portal prefab within the map
   /// </summary>
   /// <returns></returns>
   private IEnumerator PortalTimer()
	{
      //instantiate portal at the start of the game
      GameObject portal = Instantiate(originalPortal, spawnPoints[Random.Range(0, 3)], Quaternion.identity);

      //move the portal to a random location every 15 seconds
      while (portal != null)
		{
         portal.transform.position = spawnPoints[Random.Range(0, 11)];
         yield return new WaitForSeconds(15);
         
      }
   }
}
