using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform fireballSourceTransform;
    public AudioSource Sound;

    public float damage = 10;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
            fireball.damage = damage;
            Sound.Play();
        }
    }
}
