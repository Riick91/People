using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    class Person
    {
        // attributes for this class
        // we make these private now
        private string firstName;
        private string lastName;
        private int dayBorn;
        private int monthBorn;
        private int yearBorn;
        // helper method - return date of birth as a string

        // constructor
        // we copy across all the attributes passed as parameters
        public Person(string firstName, string lastName, int dayBorn, int monthBorn, int
        yearBorn)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dayBorn = dayBorn;
            this.monthBorn = monthBorn;
            this.yearBorn = yearBorn;
        }
      
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int DayBorn
        {
            get { return dayBorn; }
            set { dayBorn = value; }
        }
        public int MonthBorn
        {
            get { return monthBorn; }
            set { monthBorn = value; }
        }
        public int YearBorn
        {
            get { return yearBorn; }
            set { yearBorn = value; }
        }
        public string DateOfBirth()
        {
            return string.Format("{0}/{1}/{2}", dayBorn, monthBorn, yearBorn);
        }
        public bool HadThisYearsBirthday() /*To check if person has had birthday*/
        {
            // get todays date
            DateTime today = DateTime.Today;
            // We assume you have not had this years birthday yet
            bool returnValue = false;
            // but if this month is AFTER you birthday month you have
            if (today.Month > monthBorn)
            {
                returnValue = true;
            }
            // if this is your birthday month we look at the days 
            else if (today.Month == monthBorn)
            {
                // if today is on or after your birthday then you have
                if (today.Day >= dayBorn)
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
        /*To get next birthday*/
        public DateTime GetNextBirthday()
        {
            // we calculate the date for your next birthday
            DateTime today = DateTime.Today;
            // assume your birthday is this year
            int birthdayYear = today.Year;
            // if you've already had your birthday then
            // its a year later
            if (HadThisYearsBirthday())
            {
                birthdayYear++;
            }
            // now we create the right dateTime
            DateTime nextBirthday =
            new DateTime(birthdayYear, monthBorn, dayBorn);
            return nextBirthday;
        }
        public int HowManyDaysTillBirthday()
        {
            // we work out the difference between your next birthday
            // and today's date
            DateTime nextBirthday = GetNextBirthday();
            DateTime today = DateTime.Today;
            TimeSpan difference =
            nextBirthday.Subtract(today);
            // From the timespan object, we are only interested in the
            // number of days
            int daysToBirthday = difference.Days;
            return daysToBirthday;
        }
        public bool IsOlderThan(Person otherPerson)
        {
            if (yearBorn < otherPerson.YearBorn)
            {
                return true;
            }
            else if (yearBorn == otherPerson.yearBorn)
            {
                if (monthBorn < otherPerson.monthBorn)
                {
                    return true;
                }
                else if (monthBorn == otherPerson.monthBorn)
                {
                    if (dayBorn < otherPerson.DayBorn)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsSameAgeAs(Person otherPerson)
        {
            if ((yearBorn == otherPerson.YearBorn) &&
            (monthBorn == otherPerson.MonthBorn) &&
            (dayBorn == otherPerson.DayBorn))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
