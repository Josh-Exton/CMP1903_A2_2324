﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Serialization;

namespace CMP1903_A2_2324
{
    internal class Game
    {

        private string _mode;

        protected string Mode
        {
            get { return _mode; }
            set { _mode = value; } 
        }

        public Game() 
        { 
            Menu menu = new Menu();
        }

        protected Die[] DiceArray(int length)
        {
            Die[] array = new Die[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = new Die();
            }
            return array;
        }
    }
}