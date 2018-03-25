using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Classes;

/*
 * This GUI is the main menu for the scenario builder which allows the user to create a scenario form, edit a scenario form, 
 * delete an entire scenario, or preview a scenario.
 *
 * author: Group 7 (Stephen Bailey, Omar Garcia, Craig Wyse, Matthew Harris)
 * course: SEII
 * assignment: InRealLife (Group Project Spring 2018)
 * date: 03/20/2018
 * file name: Running.xaml.cs
 * version: 1.0
 */
namespace InRealLife_2
{
    /// <summary>
    /// Interaction logic for Running.xaml
    /// </summary>
    public partial class Running : Window
    {
        DataHandler data = new DataHandler();
        public Running(int Scenario)
        {
           
            InitializeComponent();
            Start(Scenario);
            ImageBlock.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\MediaFiles\\flat.tire.10.jpg", UriKind.Absolute));
        }



        public void Start(int ScenarioId)
        {
            data.Intetialize(ScenarioId);
            ScenarioName.Text = data.scenario.ScenarioName;

            Button1.Content = data.answer1.AnswerDescription;
            Button2.Content = data.answer2.AnswerDescription;
            StageDescription.Text = data.stage.StageDescription;

        }



        public void Update(int AnswerNumber)
        {
            if (AnswerNumber == 1)
            {
                if (data.answer2.NextStageID == 0)
                {
                    Button1.Content = "Done";
                    Button2.Content = "Done";
                }
                else
                {
                    data.Update(AnswerNumber);

                    Button1.Content = data.answer1.AnswerDescription;
                    Button2.Content = data.answer2.AnswerDescription;
                    StageDescription.Text = data.stage.StageDescription;
                }
            }
            else if (AnswerNumber == 2)
            {
                if (data.answer2.NextStageID == 0)
                {
                    Button1.Content = "Done";
                    Button2.Content = "Done";
                }
                else
                {
                    data.Update(AnswerNumber);

                    Button1.Content = data.answer1.AnswerDescription;
                    Button2.Content = data.answer2.AnswerDescription;
                    StageDescription.Text = data.stage.StageDescription;
                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Update(1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Update(2);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
