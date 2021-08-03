using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMen
{
    public class Player
    {
        private static Random rnd = new Random();
        private String name;
        private int power;
        private double HP;
        private double HPbar;
        private int attack;
        private int deffense;
        private int speed;
        private int poke_id;
        private ArrayList crit = new ArrayList();
        private ArrayList absd = new ArrayList();
        public Player(String name, int power, int HP, int attack, int deffense, int spatk, int spdef, int speed, int poke_id)
        {
            this.name = name;
            this.power = power;
            this.HP = HP;
            this.attack = attack;
            this.deffense = deffense;
            this.speed = speed;
            this.HPbar = HP;
            this.poke_id = poke_id;

            double px = spatk / 4;
            int pax = (int)Math.Round(px);
            for (int i = 0; i < pax; i++)
            {
                crit.Add(3);
            }
            for (int i = 0; i < 100-pax; i++)
            {
                crit.Add(1);
            }

            double pxs = spdef / 4;
            int pdx = (int)Math.Round(pxs);
            for (int i = 0; i < pdx; i++)
            {
                absd.Add(3);
            }
            for (int i = 0; i < 100 - pdx; i++)
            {
                absd.Add(1);
            }
        }
        public int getChanceCrit()
        {
            return (int)crit[rnd.Next(crit.Count)];
        }
        public int getChanceAbsd()
        {
            return (int)absd[rnd.Next(absd.Count)];
        }
        public int getSpeed()
        {
            return speed;
        }
        public void attacked(double dmg)
        {
            HP -= dmg;
        }
        public double getHP()
        {
            return HP;
        }
        public double getHPBar()
        {
            return HPbar;
        }
        public int getAtk()
        {
            return attack;
        }
        public int getDef()
        {
            return deffense;
        }
        public int getPokeid()
        {
            return poke_id;
        }
        public String getName()
        {
            return name;
        }
    }
}
