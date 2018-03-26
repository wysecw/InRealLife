using Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    public partial class MainWindow : Window
    {
        // create new database object
        DBComm newDBComm = new DBComm();

        public MainWindow()
        {
            InitializeComponent();
            InitializeForm();
        }

        // initialize the form
        private void InitializeForm()
        {
            // reset list box
            lstvwScenarios.Items.Clear();

            // enable create button
            // ***** change btnCreateScenario, and btnEditScenario(below) control back to true when edit scenario is incorporated ***********
            btnCreateScenario.IsEnabled = false;
            btnDeleteScenario.IsEnabled = false;
            btnPerformScenario.IsEnabled = false;

            // data table containing  data from scenario table
            DataTable returnedScenarioTable = newDBComm.displayAllScenarios();

            // if data table has rows
            if (returnedScenarioTable.Rows.Count > 0)
            {
                // enable proper buttons
                ScenarioListHasValues();
                    
                // then add data to listbox
                AddDataToListBox(returnedScenarioTable);
            }
            else
            {
                // else scenario list is empty
                ScenarioListIsEmpty();
            }
        }

        // exit builder button click event UNDER DEVELOPMENT
        private void BtnExitBuilder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // create scenario button click event
        private void BtnCreateScenario_Click(object sender, RoutedEventArgs e)
        {
            // hide current form
            // this.Hide();

            // load form to edit scenario
            // .show();
        }

        // delete scenario button click event
        private void BtnDeleteScenario_Click(object sender, RoutedEventArgs e)
        {
            // CONSTANT used when comparing to the number 
            const int EMPTY_DB_RESULT = 0;

            int scenarioRowsDeleted = 0;

            // grab selected scenario and put into variable
            Scenario selectedScenario = (Scenario)lstvwScenarios.SelectedItem;

            // run query to delete selected scenario from DB
            scenarioRowsDeleted = newDBComm.DeleteSelectedScenario(selectedScenario.ScenarioID);

            // if scenario was deleted
            if (scenarioRowsDeleted > EMPTY_DB_RESULT)
            {
                // Show user which scenario was deleted
                MessageBox.Show("The scenario called " + selectedScenario.ScenarioName + " was deleted");

                // reset form
                InitializeForm();
            }
            else
            {
                // Show user error while scenario was deleted
                MessageBox.Show("Error deleting scenario");

                // reset form
                InitializeForm();
            }
        }

        // preview scenario button click event
        private void BtnPerformScenario_Click(object sender, RoutedEventArgs e)
        {
            Running run = new Running(1);
            run.Show();

            // hide main menu form form
            this.Hide();
        }

        // method for form behaviors if list is empty
        private void ScenarioListIsEmpty()
        {
            btnEditScenario.IsEnabled = false;
            btnDeleteScenario.IsEnabled = false;
            btnPerformScenario.IsEnabled = false;
        }

        // method for form behaviors if list has data
        private void ScenarioListHasValues()
        {
            // ***** change this btnEditScenario control back to true when edit scenario is incorporated ***********
            btnEditScenario.IsEnabled = false;
        }

        // method to add scenario data to scenario list box
        private void AddDataToListBox(DataTable returnedScenarioTable)
        {
            // loop to put scenario names from data table into scenario listbox items
            for (int i = 0; i < returnedScenarioTable.Rows.Count; i++)
            {
                // add data table results to list view
                lstvwScenarios.Items.Add(new Scenario { ScenarioID = Int32.Parse(returnedScenarioTable.Rows[i][0].ToString()), ScenarioName = returnedScenarioTable.Rows[i][1].ToString() });
            }
        }

        // has scenarios listbox selection changed
        private void LstvwScenarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            enableButtonsWhenScenarioSelected();
        }

        private void enableButtonsWhenScenarioSelected()
        {
            // enable buttons
            ScenarioListHasValues();

            // enable perform scenario button
            btnPerformScenario.IsEnabled = true;

            btnDeleteScenario.IsEnabled = true;
        }
    }
}