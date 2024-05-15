using System;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        private int score = 0;
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            startButton.Click += StartButton_Click;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Reset score
            score = 0;

            // Start the quiz
            for (int i = 1; i <= 5; i++)
            {
                // Generate random numbers for the question
                int num1 = rand.Next(1, 11); // Random number between 1 and 10
                int num2 = rand.Next(1, 11); // Random number between 1 and 10
                string op = GetOperatorSymbol(); // Random operator

                // Present the question based on operation selected
                double answer = 0;
                switch (op)
                {
                    case "+":
                        answer = num1 + num2;
                        break;
                    case "-":
                        answer = num1 - num2;
                        break;
                    case "*":
                        answer = num1 * num2;
                        break;
                    case "÷":
                        if (num2 != 0)
                            answer = (double)num1 / num2;
                        else
                            continue; // Skip this question if dividing by zero
                        break;
                }

                // Ask the user for the answer
                string question = $"{num1} {op} {num2} = ?";
                string userAnswerString = Microsoft.VisualBasic.Interaction.InputBox(question, "Math Quiz", "");
                if (double.TryParse(userAnswerString, out double userAnswer))
                {
                    if (Math.Abs(userAnswer - answer) < 0.0001)
                    {
                        MessageBox.Show("Correct!");
                        score++;
                    }
                    else
                    {
                        MessageBox.Show($"Incorrect. The correct answer is {answer}.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid number.");
                }
            }

            // Display final score
            MessageBox.Show($"Quiz complete! Your score is {score}/5.");
        }

        private string GetOperatorSymbol()
        {
            switch (rand.Next(1, 5))
            {
                case 1: return "+";
                case 2: return "-";
                case 3: return "*";
                case 4: return "÷";
                default: return "+";
            }
        }
    }
}