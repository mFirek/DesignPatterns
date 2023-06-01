using System;
using System.Collections.Generic;

namespace Obserwator
{
    public enum Genre
    {
        Sport,
        Politics,
        Economy,
        Science
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    public class NewsAgency : ISubject
    {
        public string NewsHeadline;
        public Genre State;

        public void SetNewsHeadline(Genre state, string news)
        {
            State = state;
            NewsHeadline = news;
            Notify();
        }

        private List<IObserver> Observers = new List<IObserver>();

        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(this);
            }
        }

        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    class DailyEconomy : IObserver
    {
        public void Update(ISubject subject)
        {
            var s = subject as NewsAgency;
            if (s.State == Genre.Economy)
            {
                Console.WriteLine($"DailyEconomy publikuje artykuł \"{(subject as NewsAgency).NewsHeadline}\"");
            }
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    class NewYorkTimes : IObserver
    {
        public void Update(ISubject subject)
        {
            var s = subject as NewsAgency;
            if (s.State == Genre.Politics || s.State == Genre.Sport || s.State == Genre.Economy || s.State == Genre.Science)
            {
                Console.WriteLine($"NewYorkTimes publikuje artykuł \"{(subject as NewsAgency).NewsHeadline}\"");
            }
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    class NationalGeographic : IObserver
    {
        public void Update(ISubject subject)
        {
            var s = subject as NewsAgency;
            if (s.State == Genre.Science)
            {
                Console.WriteLine($"NationalGeographic publikuje artykuł \"{(subject as NewsAgency).NewsHeadline}\"");
            }
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////
    class Program
    {
        static void Main(string[] args)
        {
            var newsAgency = new NewsAgency();

            var dailyEconomy = new DailyEconomy();
            var newYork = new NewYorkTimes();
            var nationalGeographic = new NationalGeographic();

            newsAgency.Attach(dailyEconomy);
            newsAgency.Attach(newYork);
            newsAgency.Attach(nationalGeographic);

            newsAgency.SetNewsHeadline(Genre.Economy, "USA is going bancrupt!");
            newsAgency.SetNewsHeadline(Genre.Science, "Life on Alpha Centauri");
            newsAgency.SetNewsHeadline(Genre.Sport, "Adam Małysz is the greatest sportsman in the history of mankind");
            newsAgency.SetNewsHeadline(Genre.Economy, "CD Project RED value has grown by 500% in 2020");
            newsAgency.SetNewsHeadline(Genre.Science, "Kirkendall effect causing airplanes' engine deteriorate");

            newsAgency.Detach(dailyEconomy);

            newsAgency.SetNewsHeadline(Genre.Economy, "Texas is going bancrupt!");

            newsAgency.Detach(newYork);
            newsAgency.Detach(nationalGeographic);
        }
    }
}