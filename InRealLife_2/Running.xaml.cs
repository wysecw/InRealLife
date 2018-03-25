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
            string fileLoc = "C:\\Users\\Wyse\\Source\\Repos\\InRealLife_2\\InRealLife_2\\mediaFiles\\flat.tire.10.jpg";
            InitializeComponent();
            Start();
            ImageBlock.Source = new BitmapImage(new Uri(fileLoc, UriKind.Absolute));
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
