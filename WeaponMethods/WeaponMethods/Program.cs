using System;
using WeaponMethods.Models;
namespace WeaponMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
        TryMagazineCapacity:
            Console.Write("Write the magazine capacity: ");
            int magazine = Convert.ToInt32(Console.ReadLine());
            if (magazine > 500 || magazine < 0)
            {
                Console.WriteLine("This magazine capacity is impossible");
                goto TryMagazineCapacity;
            }
        TryBulletCount:
            Console.Write("Write the bullet count: ");
            int bulletCount = Convert.ToInt32(Console.ReadLine());
            if (bulletCount > magazine || bulletCount < 0)
            {
                Console.WriteLine("This bullet count can't be in the magazine");
                goto TryBulletCount;
            }
            Console.WriteLine("Is this gun shoot in single mode?\nType true: yes\nType false: no");
            bool fireMode = Convert.ToBoolean(Console.ReadLine());
            Weapon weapon = new Weapon(magazine, bulletCount, fireMode);
            do
            {
                string commands = "-----------------------------\n1: Shoot\n" + "2: Fire\n" + "3: Remain bullets\n" + "4: Reload\n" + "5: Change fire mode\n" + "6: Exit\n" + "7: Edit weapons specs\n-----------------------------";
                Console.WriteLine("Choose the command\nType 0 to get information about commands");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine(commands);
                        break;
                    case 1:
                        if (weapon.BulletCount != 0)
                        {
                            Console.WriteLine("-----------------------------\nPew!\nOne bullet shoted\n-----------------------------");
                        }
                        else
                        {
                            Console.WriteLine("-----------------------------\nYou haven't any bullets in magazine\nTo reload the gun type '4'\n-----------------------------");
                        }
                        weapon.Shoot();
                        break;
                    case 2:
                        if (weapon.FireMode == false)
                        {
                            if (weapon.BulletCount != 0)
                            {
                                Console.WriteLine("-----------------------------\nPew-Pew-Pew! Pew-Pew! Pew! Pew-Pew-Pew-Pew!\nall bullets shoted\n-----------------------------");
                            }
                            else
                            {
                                Console.WriteLine("-----------------------------\nYou haven't any bullets in magazine\nTo reload the gun type '4'\n-----------------------------");
                            }
                        }
                        else
                        {
                            if (weapon.BulletCount != 0)
                            {
                                Console.WriteLine("-----------------------------\nPew!\nOne bullet left\n-----------------------------");
                            }
                            else
                            {
                                Console.WriteLine("-----------------------------\nYou haven't any bullets in magazine\nTo reload the gun type '4'\n-----------------------------");
                            }
                        }
                        weapon.Fire();
                        break;
                    case 3:
                        Console.WriteLine("-----------------------------\nBullets remain: " + weapon.BulletCount + "\nBullets remain to reload: " + weapon.GetRemainBulletCount() + "\n-----------------------------");
                        break;
                    case 4:
                        if (weapon.Magazine == weapon.BulletCount)
                        {
                            Console.WriteLine("-----------------------------\nWeapon is already full\n-----------------------------");
                            break;
                        }
                        weapon.Reload();
                        Console.WriteLine("-----------------------------\nYour gun is reloaded\n-----------------------------");
                        break;
                    case 5:
                        weapon.ChangeFireMode();
                        Console.WriteLine("-----------------------------\nFire mode has been changed\n-----------------------------");
                        break;
                    case 7:
                        Console.WriteLine("-----------------------------\n8: Change magazine capacity\n9: Change bullet count\n-----------------------------");
                        break;
                    case 8:
                    TryNewMagazineCapacity:
                        Console.Write("-----------------------------\nWrite the new magazine capacity: ");
                        magazine = Convert.ToInt32(Console.ReadLine());
                        if ((magazine > 500 || magazine < 0) || magazine < weapon.BulletCount)
                        {
                            Console.WriteLine("This magazine capacity is impossible");
                            goto TryNewMagazineCapacity;
                        }
                        Console.WriteLine("-----------------------------\n");
                        weapon = new Weapon(magazine, bulletCount, fireMode);
                        break;
                    case 9:
                    TryNewBulletCount:
                        Console.Write("-----------------------------\nWrite the new bullet count: ");
                        bulletCount = Convert.ToInt32(Console.ReadLine());
                        if (bulletCount > weapon.Magazine || bulletCount < 0)
                        {
                            Console.WriteLine("This bullet count can't be in the magazine");
                            goto TryNewBulletCount;
                        }
                        Console.WriteLine("-----------------------------\n");
                        weapon = new Weapon(magazine, bulletCount, fireMode);
                        break;
                    default:
                        break;
                }
            } while (choice != 6);
        }
    }
}
