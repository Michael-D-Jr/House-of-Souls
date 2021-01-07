using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{

   public GameObject originalPortal;

   Vector3[] spawnPoints = { new Vector3(0, 2, 0), new Vector3(21, 2, 16), new Vector3(68, 2, 16), new Vector3(87, 2, 40), new Vector3(45, 2, 40), new Vector3(-6, 2, 40),
                             new Vector3(-68, 2, 40),new Vector3(-57, 2, 3),new Vector3(-57, 2, -14),new Vector3(-15, 2, -29),new Vector3(-15, 2, -64),new Vector3(68, 2, -64)};

   void Awake()
	{
      
	}

	// Start is called before the first frame update
	void Start()
   {
      StartCoroutine(PortalTimer());
   }

   // Update is called once per frame
   void Update()
   {

   }
   private IEnumerator PortalTimer()
	{
      GameObject portal = Instantiate(originalPortal, spawnPoints[Random.Range(0, 3)], Quaternion.identity);
      while (portal != null)
		{
         portal.transform.position = spawnPoints[Random.Range(0, 11)];
         yield return new WaitForSeconds(15);
         
      }
   }
}
