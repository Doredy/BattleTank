using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleItem : MonoBehaviour
{
    [SerializeField]
    private float invincibleTime;
    [SerializeField]
    private AudioClip getSound;
    [SerializeField]
    private GameObject effectPrefab;


    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TankHealth>().isInvincible = true;
            other.gameObject.GetComponent<TankHealth>().invincibleTime = invincibleTime;
            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
        }
    }
}
