using UnityEngine;
using System.Collections;

public class BattleScript : MonoBehaviour {
    public ArrayList enemy_ships;
    public ArrayList my_ships;
    Spaceship sp1;
    public Vector3 f;
    public float r;
    // Use this for initialization
    void Start()
    {
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
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            sp1.new_position = pz;
        }
        else if (Input.GetKey("right")){
            sp1.unityShip.transform.Rotate(0, 0, -r);
        }
        else if (Input.GetKey("left"))
        {
            sp1.unityShip.transform.Rotate(0, 0, r);
        }
        else
        {
            sp1.Move();
            //print(Screen.height);
        }
    }
}

