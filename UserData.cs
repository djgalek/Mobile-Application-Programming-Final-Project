using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;

namespace FinalProject
{
    class UserData
    {
        public string Name { get; set; }
        public string Money { get; set; }

        public UserData(string name, string money)
        {
            Name = name;
            Money = money;
        }

        public UserData()
        {

        }

        public override string ToString()
        {
            return Name + "   " + Money;
        }
    }
}