using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum GunState
{
    Overheat,
    Normal
}

public class FiringManagement : MonoBehaviour {
	public KeyCode FireKey;
	public UnityEvent fire;
	bool firing = false;

    GunState gunState = GunState.Normal;

    float checktime = 0.3f;
    float heat = 0;
    public Slider slider;

    public GameObject Bullet;
    public GameObject BigBullet;

	// Use this for initialization
	void Awake () {
		fire = new UnityEvent();
        fire.AddListener(Fire);
		fire.AddListener(SetGunState);
		fire.AddListener(SetSlider);
		
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(FireKey) && !firing)
		{
			StartCoroutine(AutoFire(ModeToWeaponCoolDownTime(gunState)));
		}

	}

	IEnumerator AutoFire(float checktime)
	{
		firing = true;
		while (firing)
		{
            
            fire.Invoke();
            
            yield return new WaitForSeconds(ModeToWeaponCoolDownTime(gunState));

			firing = Input.GetKey(FireKey);

		}

	}

    void SetSlider()
    {
        slider.value = heat;
        
    }

    float ModeToWeaponCoolDownTime(GunState state)
    {
        if(state == GunState.Overheat)
        {
            return 1f;
        }
        else
        {
            return 0.3f;
        }
    }

    void Fire()
    {
        GameObject temp;
        if(gunState == GunState.Normal)
        {
            temp = Instantiate(Bullet, transform.position + transform.right, Quaternion.identity);
        }
        else
        {
            temp = Instantiate(BigBullet, transform.position + transform.right, Quaternion.identity);
        }
        AccelerateShot(temp);
    }

    void AccelerateShot(GameObject gameObject)
    {
        Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (gunState == GunState.Normal)
        {
            rb2d.AddForce(transform.right, ForceMode2D.Impulse);
        }
        else
        {
            rb2d.AddForce(transform.right *3f, ForceMode2D.Impulse);
        }
    }

    void SetGunState()
    {
        if(heat < 1f)
        {
            heat += 0.1f;
            gunState = GunState.Normal;
        }
        else
        {
            heat -= 0.5f;
            gunState = GunState.Overheat;

        }
    }

}
