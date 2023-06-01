﻿using System;
using System.Collections.Generic;

namespace Pelnomocnik
{
    public class User
    {
        private bool HasAdminPrivilages;

        // konstruktor? jak jest tworzony obiekt?
        public User(bool hasAdminPrivilages)
        {
            HasAdminPrivilages = hasAdminPrivilages;
        }

        public void MakeAdmin()
        {
            // co robi?
            HasAdminPrivilages = true;
        }

        public bool IsAdmin()
        {
            // co zwraca?
            return HasAdminPrivilages;
        }
    }

    public interface Information
    {
        public abstract void DisplayData();
        public abstract void DisplayRestrictedData();
    }

    public class Database : Information
    {
        private Dictionary<string, double> Map;

        public Database()
        {
            // stworzenie bazy użytkowników
            // i uzupełnienie wartości
            Map = new Dictionary<string, double>();
            Map.Add("Zyzio MacKwacz", 2500);
            Map.Add("Scooby Doo", 11.4);
            Map.Add("Adam Mackiewicz", 15607.95);
            Map.Add("Rick Morty", 429.18);
        }

        // wyświetlenie listy użytkowników
        public void DisplayData()
        {
            Console.WriteLine("Użytkownicy:");
            foreach (var item in Map)
            {
                Console.WriteLine(item.Key);
            }
        }

        // wyświetlenie ujawniające zarobki
        public void DisplayRestrictedData()
        {
            foreach (var item in Map)
            {
                Console.WriteLine(item.Key + " zarabia " + item.Value + " zł miesięcznie");
            }
        }
    }

    public class DatabaseGuard : Information
    {
        private Database DB;
        private User user;

        public DatabaseGuard(User u)
        {
            // stworzenie obiektu DB i przypisanie do pola
            // u? pewnie pole ;)
            DB = new Database();
            user = u;
        }

        public void DisplayData()
        {
            DB.DisplayData();
        }

        public void DisplayRestrictedData()
        {
            // sprawdzenie uprawnień i odpowienie działanie
            if (user.IsAdmin())
                DB.DisplayRestrictedData();
            else
                Console.WriteLine("Nie masz wystarczających uprawnień");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var Zbyszek = new User(false);
            var db = new DatabaseGuard(Zbyszek);

            db.DisplayData();

            Console.WriteLine("---------------------------------------------------------");

            db.DisplayRestrictedData();

            Console.WriteLine("---------------------------------------------------------");

            Zbyszek.MakeAdmin();
            db.DisplayRestrictedData();
        }
    }
}