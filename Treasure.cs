using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour
{

	public int value = 10;
	public GameObject explosionPrefab;
    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag == "Player")
		{
			JobDonner();
		}
	}
    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			JobDonner();
		}
	}
	void JobDonner()
    {
		if (GameManager.gm != null)
		{
			// tell the game manager to Collect
			GameManager.gm.Collect(value);
		}

		// explode if specified
		if (explosionPrefab != null)
		{
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		}

		// destroy after collection
		Destroy(gameObject);
	}
}