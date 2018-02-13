using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public GameObject bulletCasing;
    public GameObject arms;
    public Sprite notFiringSprite;
    public Sprite firingSprite;
    public SpriteRenderer sprite;
    public Light muzzleFlash;

    void Update ()
    {
		if ( Input.GetButtonDown("Fire1") )
        {
            Instantiate(projectile, arms.transform.position, Quaternion.identity);
            Instantiate(bulletCasing, new Vector3(arms.transform.position.x - .5f, arms.transform.position.y, arms.transform.position.z), Quaternion.identity);
           
            StartCoroutine("FirePistol");
        }
	}

    IEnumerator FirePistol()
    {
        sprite.sprite = firingSprite;
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(.02f);
        sprite.sprite = notFiringSprite;
        muzzleFlash.enabled = false;
    }
}
