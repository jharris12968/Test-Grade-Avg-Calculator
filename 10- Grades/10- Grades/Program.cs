namespace _10__Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input for users name. The string stores the input for the output at the end of the code
            Console.Write("Enter your name here: ");
            string name = "";
            bool validName = false;
            while (!validName)
            {
                try //Tests the information in this container to see if its true.
                {
                    name = Console.ReadLine();
                    if (name.All(c => char.IsLetter(c))) //Defines the string "name" to be alphabetic characters only
                        validName = true; //Bool holds the while statement together. If true this moves to the next while statement below
                    else
                        throw new Exception("Please enter alphabetic characters only."); //
                }
                catch (Exception ex) //If the information is not true, the Exception statement listed above will prompt.
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //Input for the class the test scores will be for
            Console.WriteLine("Enter your class here: ");
            string className = "";
            bool validClassName = false;
            while (!validClassName)
            {
                try //Tests the information in this container to see if its true.
                {
                    className = Console.ReadLine();
                    if (className.All(c => char.IsLetter(c))) //Defines the string "className" to be alphabetic characters only
                        validClassName = true;
                    else
                        throw new Exception("Please enter alphabetic characters only.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //Reference Pg. 421 "Prelude To Programming" - List is used to store the users inputs as a declared "int"
            List<int> scores = new List<int>();
            Console.WriteLine("Enter all test scores for " + className + " here:");
            Console.WriteLine("When you are finished, type 'done' for your average test grade");
            string input;
            while ((input = Console.ReadLine()) != "done")
            {
                try
                {
                    if (int.TryParse(input, out int score) && score >= 0 && score <= 100) //Sets integer input range at 0 - 100
                    {
                        scores.Add(score); //Adds all inputs from the user in this section of the code
                    }
                    else
                    {
                        throw new Exception("Enter a value 0-100 or type 'done' to complete the test average"); //Error Statement for incorrcet inputs
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //Clears prior inputs from console but keeps the information stored for the output.
            Console.Clear();

            //Reference Pg. 421 "Prelude To Programming" - "Average" is used to calculate all inputs put into the array by the user.
            double avgScore = scores.Count > 0 ? scores.Average() : 0; //Uses ternary operator to specify the range for the if else statement
            int roundedAvg = (int)Math.Round(avgScore); //Rounds the Average to a whole number.

            //Char or "Character" links the range denoted in the if else statement to the specified character. i.e the letter grade
            char grade;
            if (roundedAvg >= 90)
                grade = 'A';
            else if (roundedAvg >= 80)
                grade = 'B';
            else if (roundedAvg >= 70)
                grade = 'C';
            else if (roundedAvg >= 60)
                grade = 'D';
            else
                grade = 'F';

            //Final Output with Student Information
            Console.WriteLine("Student Information");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Class: " + className);
            Console.WriteLine("Test Average: " + roundedAvg);
            Console.WriteLine("Final Grade: " + grade);
        }
    }
}
