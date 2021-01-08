using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{
   public Transform player;
   public Transform ghost;
   public Vector3 playerReset;
   public Vector3 ghostReset;

   

   //public Vector3 playerStartPos = new V3;

   //public Vector3 ghostStartPos = new Vector3 (-83,2,0);

   int moveSpeed = 4;
   int maxDistance = 2;
   int minDistance = 1;

   // Start is called before the first frame update
   void Start()
   {
        
   }

   // Update is called once per frame
   void Update()
   {
      transform.LookAt(player);

		if (Vector3.Distance(transform.position, player.position) >= minDistance)
		{
         transform.position += transform.forward * moveSpeed * Time.deltaTime;

			if (Vector3.Distance(transform.position, player.position) <= maxDistance)
			{
            //Debug.Log("Hunter is about to capture player");
            StartCoroutine(PlayerCaught());
            
            //RestartLevel.Restart();
			}
		}
		if (PauseMenu.Instance.isActiveAndEnabled)
		{
         moveSpeed = 0;
		}
		else
		{
         moveSpeed = 4;
		}
   }

   IEnumerator PlayerCaught() 
   {
      yield return new WaitForSeconds(.5f);
      //RestartLevel.Restart();
      player.transform.position = playerReset;
      ghost.transform.position = ghostReset;
      //GameSystem.Instance.ChangeHealth();
      
      
      
   }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Controller>())
		{
         StartCoroutine(PlayerCaught());
         GameSystem.Instance.ChangeHealth();
		}
	}

	




}
