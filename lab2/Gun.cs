using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public partial class Gun
    {
        bool yourGun = false;
        public Gun()
        {
            yourGun = true;
        }
        public void Shoot()
        {
            if (yourGun)
            {
                Console.WriteLine("Бах!!");
                yourGun = false;
                Console.WriteLine("Ваше оружие выстрелило");
            }
            else
            {
                Console.WriteLine("Орижие не заряжено чтобы выстрелить");
            }

        }
        public void Reload()
        {
            if (!yourGun)
            {
                Console.WriteLine("Перезарядка");
                yourGun = true;
                Console.WriteLine("Оружие заряжено");
            }
            else
            {
                Console.WriteLine("Оружие уже заряжено");
            }   
        }
    }
