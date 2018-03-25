using System;
using System.Collections.Generic;
using System.Linq;
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
        int ScenarioId = 1;
        int StageId = 1;
        int Answer1 = 1;
        int Answer2 = 2;



        public Running()
        {
            InitializeComponent();
            Start();
            ImageBlock.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "mediaFiles\\flat.tire.10.jpg", UriKind.Absolute));
        }



        public void Start()
        {
            Scenario scenario = new Scenario();
            Stage stage = new Stage();
            Answer answer = new Answer();
            DBComm Dbase = new DBComm();
            scenario.ScenarioID = 1;
            scenario.ScenarioName = Dbase.getScenarioName(1);
            ScenarioName.Text = scenario.ScenarioName;

            Button1.Content = Dbase.getAnswer(Answer1, StageId);
            Button2.Content = Dbase.getAnswer(Answer2, StageId);
        }



        public void Update(int ScenarioId, int StageId)
        {
            Answer1 = 1;
            Answer2 = 2;

            DBComm Dbase = new DBComm();

            if (ScenarioId == -1)
            {

            }
            else
            {
                ScenarioName.Text = Dbase.getScenarioName(ScenarioId);
                Button1.Content = Dbase.getAnswer(Answer1, StageId);
                Button2.Content = Dbase.getAnswer(Answer2, StageId);
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Answer = 1;

            DBComm Dbase = new DBComm();

            StageId = Dbase.getNextStageID(Answer, StageId);
            Update(ScenarioId, StageId);
            //ImageBlock.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "mediaFiles\\good.png", UriKind.Absolute));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Answer = 2;

            DBComm Dbase = new DBComm();

            StageId = Dbase.getNextStageID(Answer, StageId);
            Update(ScenarioId, StageId);
            //ImageBlock.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "mediaFiles\\x.png", UriKind.Absolute));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // show main menu form
            MainWindow newMainWindow = new MainWindow();
            newMainWindow.Show();

            // hide main menu form form
            this.Hide();
        }
    }
}
