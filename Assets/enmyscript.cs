using UnityEngine;
using System.Collections;
using System;

public class enemyScript : MonoBehaviour
{
    public int H;
    public int W;
    GameObject cont;
    MainScript ms;
    public int rangemy; // досигаемость оружия игрока
    public int renge; // досигаемость оружия бота
                      // Use this for initialization
    void Start()
    {
        H = Screen.height;
        W = Screen.width;
        cont = GameObject.Find("Controller");
        ms = cont.GetComponent<MainScript>();
    }

    void Update()
    {
        rangemy = 0;
        float xy = 0;
        Spaceship s1 = (Spaceship)ms.my_ships[0];
        float x1 = s1.position.x;
        float y1 = s1.position.y;
        double nr1 = s1.new_rotation.z;
        double r1 = System.Math.Asin(x1 / (x1 * x1) + (y1 * y1));
        Weapon d11 = (Weapon)s1.weapons[0];
        int d11_t = d11.d_type;
        float rg11 = d11.w_range;
        Weapon d12 = (Weapon)s1.weapons[1];
        int d12_t = d12.d_type;
        float rg12 = d12.w_range;
        Spaceship s2 = (Spaceship)ms.enemy_ships[0];
        float x2 = s2.position.x;
        float y2 = s2.position.y;
        double r2 = s2.rotation.z;
        double nr2 = s2.new_rotation.z;
        Weapon d21 = (Weapon)s2.weapons[0];
        int d21_t = d21.d_type;
        float rg21 = d21.w_range;
        Weapon d22 = (Weapon)s2.weapons[1];
        int d22_t = d22.d_type;
        float rg22 = d22.w_range;
        if (x1 > x2)
        {
            if (y1 > y2)
            {
                xy = ((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2));
            }
            else if (y2 > y1)
            {
                xy = ((x1 - x2) * (x1 - x2)) + ((y2 - y1) * (y2 - y1));
            }
            else
            {
                xy = x1 - x2;
            }
        }
        else if (x2 > x1)
        {
            if (y1 > y2)
            {
                xy = ((x2 - x1) * (x2 - x1)) + ((y1 - y2) * (y1 - y2));
            }
            else if (y2 > y1)
            {
                xy = ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1));
            }
            else
            {
                xy = x2 - x1;
            }
        }
        else
        {
            if (y1 > y2)
            {
                xy = y1 - y2;
            }
            else if (y2 > y1)
            {
                xy = y2 - y1;
            }
        }
        r2 = Math.Abs(r2);
        r1 = Math.Abs(r1);
        if (System.Math.Sin(r2) > System.Math.Sin(r1))
        {
            if (r2 - r1 >= 180)
            {
                nr2 += ((360 - r2) + r1);
            }
            else
            {
                nr2 -= r2 - r1;
            }
        }
        else if (System.Math.Sin(r2) < System.Math.Sin(r1))
        {
            if (r1 - r2 >= 180)
            {
                nr2 -= ((360 - r1) + r2);
                nr2 = 360 - Math.Abs(nr2);
            }
            else
            {
                nr2 += r1 - r2;
            }
        }
        if ((xy >= rg21) || (xy >= rg22))
        {
            if (xy >= rg21)
            {
                d21.is_firing = false;
                if (x1 > x2)
                {
                    if (y1 > y2)
                    {
                        x2 += (x1 - x2) - 1;
                        y2 += (y1 - y2) - 1;
                    }
                    else if (y2 > y1)
                    {
                        x2 += (x1 - x2) - 1;
                        y2 -= ((y2 - y1) - 1);
                    }
                    else
                    {
                        x2 += (x1 - x2) - 1;
                    }
                }
                else if (x2 > x1)
                {
                    if (y1 > y2)
                    {
                        x2 -= ((x2 - x1) - 1);
                        y2 += ((y1 - y2) - 1);
                    }
                    else if (y2 > y1)
                    {
                        x2 -= ((x2 - x1) - 1);
                        y2 -= ((y2 - y1) - 1);
                    }
                    else
                    {
                        x2 -= ((x2 - x1) - 1);
                    }
                }
                else
                {
                    if (y1 > y2)
                    {
                        y2 += ((y1 - y2) - 1);
                    }
                    else if (y2 > y1)
                    {
                        y2 -= ((y2 - y1) - 1);
                    }
                }
            }
            else if (xy >= rg22)
            {
                d22.is_firing = false;
                if (x1 > x2)
                {
                    if (y1 > y2)
                    {
                        x2 += (x1 - x2) - 1;
                        y2 += (y1 - y2) - 1;
                    }
                    else if (y2 > y1)
                    {
                        x2 += (x1 - x2) - 1;
                        y2 -= ((y2 - y1) - 1);
                    }
                    else
                    {
                        x2 += (x1 - x2) - 1;
                    }
                }
                else if (x2 > x1)
                {
                    if (y1 > y2)
                    {
                        x2 -= ((x2 - x1) - 1);
                        y2 += ((y1 - y2) - 1);
                    }
                    else if (y2 > y1)
                    {
                        x2 -= ((x2 - x1) - 1);
                        y2 -= ((y2 - y1) - 1);
                    }
                    else
                    {
                        x2 -= ((x2 - x1) - 1);
                    }
                }
                else
                {
                    if (y1 > y2)
                    {
                        y2 += ((y1 - y2) - 1);
                    }
                    else if (y2 > y1)
                    {
                        y2 -= ((y2 - y1) - 1);
                    }
                }
            }
            else if (xy < rg21)
            {
                d21.is_firing = true;
            }
            else if (xy < rg22)
            {
                d22.is_firing = true;
            }
        }
        else if ((xy < rg21) && (xy < rg22))
        {
            d21.is_firing = true;
            d22.is_firing = true;
        }
    }
}