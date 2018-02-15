using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public GameObject bulletCasing;
    public GameObject projectileSpawn;
    public GameObject projectileSpawnBack;
    public Sprite notFiringSprite;
    public Sprite firingSprite;
    public SpriteRenderer sprite;
    public Light muzzleFlash;

    void Update ()
    {
		if ( Input.GetButtonDown("Fire1") )
        {
           
            if ( PlayerResourceManager.GetAmmoCount() > 0 )
            {
                StartCoroutine("FirePistol");
            }
            else
            {
                // TODO Click sfx.
            }
        }
	}

    IEnumerator FirePistol()
    {
        GameObject bullet = Instantiate(projectile, projectileSpawn.transform.position, Quaternion.identity);
        PlayerResourceManager.DecreaseAmmoCount ( 1 );
        // TODO Shot sfx
        bullet.SendMessage ( "SetProjectileSpawnBack", projectileSpawnBack );
        Instantiate(bulletCasing, new Vector3(projectileSpawn.transform.position.x - .5f, projectileSpawn.transform.position.y, projectileSpawn.transform.position.z), Quaternion.identity);
        sprite.sprite = firingSprite;
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(.02f);
        sprite.sprite = notFiringSprite;
        muzzleFlash.enabled = false;
    }
}
