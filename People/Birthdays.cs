using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    class Birthdays
    {
        // attributes
        private List<Person> people = new List<Person>();
        private int currentPerson = 0;
        //we need access to a person’s data
        /*To get current person's first name*/
        public string GetPersonsFirstName()
        {
            return people[currentPerson].FirstName;
        }

        /*To get current person's Last name*/
        public string GetPersonsLastName()
        {
            return people[currentPerson].LastName;
        }
        public string GetPersonsDateOfBirth() /*To get current persons's DOB*/
        {
            return people[currentPerson].DateOfBirth();
        }
        public int GetPersonsDaysTillNextBirthday()
        {
            return people[currentPerson].HowManyDaysTillBirthday();
        }

        public bool IsNextPerson() /*To view if there is a next person*/
        {
            if (currentPerson < (people.Count - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
            // we could just write
            //return (currentPerson < (people.Count - 1));
        }

        public bool IsPreviousPerson() /*To check if there is a previous person*/
        {
            if (currentPerson > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            // again we could write
            // return (currentPerson > 0);
        }
        public void StepToNextPerson() /*To view next person*/
        {
            if (IsNextPerson())
            {
                currentPerson++;
            }
        }
        public void StepToPreviousPerson() /*To view previous person*/
        {
            if (IsPreviousPerson())
            {
                currentPerson--;
            }
        }
        /*Method to Add new person to the people list*/
        public void AddPerson(string firstName, string lastName, int dayBorn, int
       monthBorn, int yearBorn)
        {
            Person person = new Person(firstName, lastName, dayBorn, monthBorn, yearBorn);
            people.Add(person);
        }
        public string UpcomingBirthdays(int days)
        {
            // we create a string containing the names and dates for
            // all the people whose birthdays are within the next number of days
            // we start with no names
            string names = "";
            // now we look through the list of people
            // we can use a foreach loop here.
            foreach (Person person in people)
            {
                if (person.HowManyDaysTillBirthday() <= days)
                {
                    // here we add the person to the list
                    //
                    // we want the name to be on separate lines so if
                    // the list is not empty, we start a new line
                    if (names != "")
                    {
                        names = names + Environment.NewLine;
                    }
                    names = names + person.FirstName + " " + person.LastName + " " +
                    person.DateOfBirth();
                }
            }
            return names;
        }
        public string ConvertListToStrings(List<Person> sourceList)
        {
            string result = "";
            foreach (Person person in sourceList)
            {
                if (result != "")
                {
                    result = result + Environment.NewLine;
                }
                result = result + person.FirstName + " " + person.LastName;
            }
            return result;
        }
        public string FindOldestPeople()
        {
            // If there are no people in the list, we will return just an empty string
            string result = "";

            if (people.Count > 0)
            {


                // there must be an oldest person here 
                List<Person> oldestPeople = new List<Person>();
                // assume its the first person in the list
                oldestPeople.Add(people[0]);
                // now look at each other person on the list
                for (int i = 1; i < people.Count; i++)
                {
                    if (people[i].IsOlderThan(oldestPeople[0]))
                    {
                        // This person is the new oldest person
                        oldestPeople = new List<Person>(); //New list object to hold new oldest
                        oldestPeople.Add(people[i]);
                    }
                    else if (people[i].IsSameAgeAs(oldestPeople[0]))
                    {
                        // we have more than one oldest person at this point
                        oldestPeople.Add(people[i]);
                    }
                }
                result = ConvertListToStrings(oldestPeople);
                // for neatness we add the age to the string on a new line
                result = result + Environment.NewLine + "Born on " +
               oldestPeople[0].DateOfBirth();
            }

            return result;
        }
    }
}
