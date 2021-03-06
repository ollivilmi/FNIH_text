﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public abstract class Player
    {
        public int drunkLevel { get; set; }
        protected int likability;
        protected int funLevel;
        public double money { get; set; }
        public List<string> items { get; set; }
        public string name { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }

        public Player (string name, int likability, double money, int drunkLevel, int funLevel)
        {
            this.likability = likability;
            this.money = money;
            this.drunkLevel = drunkLevel;
            this.funLevel = funLevel;
            this.items = new List<string>();
            this.name = name;
        }

        public void dropWallet()
        {
            this.money = 0;
        }

        public void haveFun(int fun)
        {
            funLevel += fun + (int)drunkFun();      //Have fun increases fun level and takes drunkLevel into
            if (funLevel > 50)
            {                   //consideration as well
                funLevel = 50;
            }
            else if (funLevel < -50)
            {
                funLevel = -50;
            }
        }

        public void drink(int amount)
        {
            drunkLevel += amount;
            if (drunkLevel > 100)
            {  //Drink is used to set your drunkLevel 0-100
                drunkLevel = 100;
                Console.WriteLine("Drunk level 100: this would lose you the game.");
            }
            if (drunkLevel < 0)
            {
                drunkLevel = 0;
            }
        }


        public int getfunLevel()
        {
            return funLevel;
        }

        public double drunkFun()
        {
            return 0.1 * (double)drunkLevel; //A simple math equation used in fun calculation
        }

        public bool useMoney(double sum)
        {                                               //Used to spend and gain money
            if ((money + sum) >= 0)
            {                                            //When sum is negative spend money and vice versa 
                money += sum;                            //If sum is more than you can spend, return false
                return true;
            }
            else
                return false;
        }

        public int getLikability()
        {
            return likability - (drunkLevel / 3); //Return likability, which is affected by drunkLevel
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }
        public void PrintItems()
        {
            Console.WriteLine("Your items:");
            foreach (string item in items)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
        public abstract void Think();
        public abstract void PlayGuitar();
    }
}
