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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Classes;
using InRealLife_2;

namespace Running_Scenarios
{
    /// <summary>
    /// Interaction logic for Running.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        int ScenarioId = 1;
        int StageId = 1;
        int Answer1 = 1;
        int Answer2 = 2;



        public MainWindow()
        {
            InitializeComponent();
            Start();
            ImageBlock.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "mediaFiles\\flat-tire-white-background-43344622.jpg", UriKind.Absolute));
        }



        public void Start()
        {
            Scenario scenario =  new Scenario();
            Stage stage = new Stage();
            Answer answer = new Answer();
            DBComm Dbase = new DBComm();
            scenario.ScenarioID  = 1;
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
            ImageBlock.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "mediaFiles\\good.png", UriKind.Absolute));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Answer = 2;

            DBComm Dbase = new DBComm();

            StageId = Dbase.getNextStageID(Answer, StageId);
            Update(ScenarioId, StageId);
            ImageBlock.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "mediaFiles\\x.png", UriKind.Absolute));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

    }
}
