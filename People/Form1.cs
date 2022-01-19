using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People
{
    public partial class Form1 : Form
    {

        // the form manages a birthdays Object
        Birthdays birthdays;
        public Form1()
        {
            InitializeComponent();
        }

        public void AddPeople()
        {
            // In a real application, this would be
            // read-in from a database, a file or some
            // other source...

            birthdays.AddPerson("Sam", "Hook", 01, 01, 2000);
            birthdays.AddPerson("Joe", "Bloggs", 11, 05, 1997);
            birthdays.AddPerson("Ed", "Sheeran", 17, 02, 1991);
            birthdays.AddPerson("Bill", "Gates", 25, 10, 1955);
            birthdays.AddPerson("Steve", "Jobs", 24, 02, 1955);
            birthdays.AddPerson("Mark ", "Zuckerberg", 15, 05, 1984);
            birthdays.AddPerson("Yester ", "Day", 21, 10, 1984);
            birthdays.AddPerson("To ", "Day", 22, 10, 1984);
            birthdays.AddPerson("Tomorrow ", "Day", 23, 10, 1984);
            birthdays.AddPerson("Pierrick ", "Njiki", 22, 01, 1999);
        }
        public void DisplayPerson()
        {
            textBoxFirstName.Text = birthdays.GetPersonsFirstName();
            textBoxLastName.Text = birthdays.GetPersonsLastName();
            textBoxDateOfBirth.Text = birthdays.GetPersonsDateOfBirth();
            // add this
            textBoxDaysToBirthday.Text = string.Format("{0} Days",
           birthdays.GetPersonsDaysTillNextBirthday());
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // birthdays object is created
            birthdays = new Birthdays();
            AddPeople();
            // now we are ready to show the data on the form
            DisplayPerson();

        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            birthdays.StepToPreviousPerson();
            //and update the display
            DisplayPerson();
            buttonPrevious.Enabled = birthdays.IsPreviousPerson();
            buttonNext.Enabled = birthdays.IsNextPerson();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            birthdays.StepToNextPerson();
            // need to update the display here
            DisplayPerson();
            buttonNext.Enabled = birthdays.IsNextPerson();
            buttonPrevious.Enabled = birthdays.IsPreviousPerson();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelInNext_Click(object sender, EventArgs e)
        {

        }

        private void buttonFindBirthdays_Click(object sender, EventArgs e)
        {
            /* get the window we are looking at */
            int days = (int)numericUpDownDays.Value;
            /* the caption will appear in the message box title bar */
            string caption = string.Format("Birthdays in next {0} days", days);
            /* ask the birthdays object for a list of names as a string */
            string message = birthdays.UpcomingBirthdays(days);
            /* the list might be empty*/
            if (message == "")
            {
                message = "No birthdays found!";
            }
            // infom the user with the upcoming birthdays
            MessageBox.Show(message, caption, MessageBoxButtons.OK,
           MessageBoxIcon.Information);

        }

        private void buttonFindOldest_Click(object sender, EventArgs e)
        {
            // the caption will appear in the message box title bar
            string caption = "The oldest person (or people)";
            // ask the birthdays object for the oldest person or people
            string message = birthdays.FindOldestPeople();
            // the list might be empty 
            if (message == "")
            {
                message = "No person or people!";
            }
            // inform the user
            MessageBox.Show(message, caption, MessageBoxButtons.OK,
MessageBoxIcon.Information);
        }
    }
}
