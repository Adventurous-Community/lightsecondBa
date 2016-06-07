using UnityEngine;
using System.Collections;
using System;

public abstract class Device
{

    public string label;
    public string description;
    public int hp;
    public int max_hp;
    public int energy_usage;
    public bool is_firing;
    public int d_type;
    public GameObject unityShip;
    public GameObject unityDevice;
    public abstract void Fire();

}

public class Weapon: Device
{
    public int w_range;

    public override void Fire()
    {
        throw new NotImplementedException();
    }
}

public class Drive: Device{
	public int speed;
    public float r_speed;
    public Vector3 new_position;
    public Quaternion new_rotation;

    public override void Fire(){
        Vector3 direction = new_position - unityShip.transform.position;
        float r_angle = new_rotation.z - unityShip.transform.rotation.z;
        if(r_angle > 180)
        {
            unityShip.transform.rotation.Set(0, 0, r_speed,0);

        }
		direction.Normalize ();
		direction *= speed;
		unityShip.transform.Translate(direction*Time.deltaTime);
        
	}
}

public class Spaceship
{
    public string log;
    public Vector3 position;
    public Vector3 new_position;
    public Quaternion rotation;
    public Quaternion new_rotation;
    public GameObject unityShip;
    public int energy;
    public int max_energy;
    public int hp;
    public int max_hp;
    public ArrayList weapons;//оружие
    public ArrayList sciDevices;//Научные девайсы(для лечения)
    public ArrayList superWeapons;//супероружие
    public ArrayList drives;//Двигатели

    public Spaceship(GameObject us, int m_hp, int m_en)
    {
        position = us.transform.position;
        new_position = position;
        rotation = us.transform.rotation;
        new_rotation = rotation;
        unityShip = us;
        max_hp = m_hp;
        hp = max_hp;
        energy = m_en;
        max_energy = m_en;
        weapons = new ArrayList();
        sciDevices = new ArrayList();
        superWeapons = new ArrayList();
        drives = new ArrayList();
        log = "started";
    }



    public void Move()
    {
        //log += "?";
        for(int i = 0; i < drives.Count; i++)
        {
            Drive d = (Drive)drives[i];
            d.new_position = new_position;
            double en_req = d.energy_usage * Time.deltaTime;
            //log += en_req.ToString();
            //log += "<";
            //log += energy.ToString();
            //log += " ";
            if ((en_req <= energy) && (d.is_firing == true))
            {
                //log += "!";
                d.Fire();
                
            }
            position = unityShip.transform.position;
        }
    }
}

    public class MainScript : MonoBehaviour {

	

	

	public ArrayList enemy_ships;
    public ArrayList my_ships;
    Spaceship sp1;
	// Use this for initialization
	void Start () {
        sp1 = new Spaceship(transform.gameObject, 100, 100);
        sp1.new_position = new Vector3(-1, 1, 0);
        Drive d1 = new Drive();
        d1.is_firing = true;
        d1.energy_usage = 1;
        d1.speed = 2;
        d1.unityShip = sp1.unityShip;
        sp1.drives.Add(d1);
	}
	
	// Update is called once per frame
	void Update () {
        print(sp1.log);
        if (Input.GetMouseButtonDown(0))
        {
            sp1.new_position = Input.mousePosition-sp1.position;
        }
        else
        {
            sp1.Move();
            //print(Screen.height);
        }
	}
}
