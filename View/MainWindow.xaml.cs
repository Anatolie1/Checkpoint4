using Nancy.Hosting.Self;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Checkpoint3
{
    public partial class MainWindow : Window
    {
        private Show _selectectShow;
        private DataGenerator _dataGenerator;

        public MainWindow()
        {
            _dataGenerator = new DataGenerator();
            //_dataGenerator.GetCommentsDB();

            InitializeComponent();
            Shows.ItemsSource = _dataGenerator.shows;
            AnimalList.ItemsSource = _dataGenerator.animals;

            var host = new NancyHost(new Uri("http://localhost:1234"));
            host.Start();
        }

        private void Shows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectectShow = (Show)Shows.SelectedItem;
            PriceList.DataContext = _selectectShow.Price;
        }

        private void Send_Button_Click(object sender, RoutedEventArgs e)
        {
            bool filledLines = (Name_txt.Text != String.Empty) && (Email_txt.Text != String.Empty) && (Message_txt.Text != String.Empty);

            if(filledLines)
            {
                _dataGenerator.PutMessage(Name_txt.Text, Email_txt.Text, Message_txt.Text);
                MessageBox.Show("Thank you for your comment !", "Message");
                Name_txt.Text = String.Empty;
                Email_txt.Text = String.Empty;
                Message_txt.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Please fill the requered fields !", "Message");
            }
        }
    }
}