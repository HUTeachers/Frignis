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
	public UnityEvent fire;
	bool firing = false;

    GunState gunState = GunState.Normal;

    float checktime = 0.3f;
    float heat = 0;
    public Slider slider;

	// Use this for initialization
	void Start () {
		fire = new UnityEvent();
        fire.AddListener(SetSlider);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.K) && !firing)
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
            SetGunState();
            yield return new WaitForSeconds(ModeToWeaponCoolDownTime(gunState));

			firing = Input.GetKey(KeyCode.K);

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
