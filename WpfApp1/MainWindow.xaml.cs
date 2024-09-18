using System.Collections.Generic;
using System.Windows;
using System;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> prime; // List to store prime numbers

        public MainWindow()
        {
            InitializeComponent();
            prime = new List<int>(); // Initialize the list
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            int number;
            bool success = int.TryParse(MyTextBox.Text, out number);

            if (!success)
            {
                ResultTextBlock.Text = "請輸入整數";
            }
            else if (number < 2)
            {
                ResultTextBlock.Text = $"輸入的數值為 {number} 小於 2 請重新輸入";
            }
            else
            {
                prime.Clear(); // Clear previous results
                for (int i = 2; i <= number; i++)
                {
                    if (IsPrime(i))
                    {
                        prime.Add(i);
                    }
                }

                // Create a string of prime numbers
                string primeList = string.Join(", ", prime);
                ResultTextBlock.Text = $"找到的質數為: {primeList}";
            }
        }

        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true; // 2 is a prime number
            if (n % 2 == 0) return false; // Any even number greater than 2 is not prime

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
