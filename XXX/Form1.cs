using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XXX
{
    public partial class Form1 : Form
    {
        private SQLiteConnection connection;
        private SQLiteDataAdapter dataAdapter;
        private DataTable dataTable;
        private SQLiteCommand command;
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Data Source=XXX.db;Version=3;";
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            command = connection.CreateCommand();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            string query = "SELECT * FROM AnimalEnclosure";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void LoadData2()
        {
            string query = "SELECT * FROM Animals";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void LoadData3()
        {
            string query = "SELECT * FROM Enclosures";
            dataAdapter = new SQLiteDataAdapter(query, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command.CommandText = "SELECT SUM(daily_feed_consumption) AS total_feed_consumption\r\nFROM Animals \r\nWHERE id IN (SELECT animal_id FROM AnimalEnclosure WHERE enclosure_id = (SELECT id FROM Enclosures WHERE complex_name = 'Приматы'));";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            command.CommandText = "SELECT ae.*\r\nFROM AnimalEnclosure ae\r\nJOIN Enclosures e ON ae.enclosure_id = e.id\r\nWHERE ae.animal_id = (SELECT id FROM Animals WHERE species = 'Карликовый гиппопотам')\r\nAND e.has_waterbody = FALSE;";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            command.CommandText = "SELECT SUM(animal_count) AS total_dogs_family\r\nFROM Enclosures \r\nWHERE id IN (SELECT enclosure_id FROM AnimalEnclosure WHERE animal_id IN (SELECT id FROM Animals WHERE family = 'Псовые'));";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            command.CommandText = "SELECT \r\n    a1.species AS species_1, \r\n    a2.species AS species_2,\r\n    e.room_number AS room_number\r\nFROM \r\n    AnimalEnclosure ae1\r\nJOIN \r\n    AnimalEnclosure ae2 ON ae1.enclosure_id = ae2.enclosure_id AND ae1.animal_id < ae2.animal_id\r\nJOIN \r\n    Animals a1 ON ae1.animal_id = a1.id\r\nJOIN \r\n    Animals a2 ON ae2.animal_id = a2.id\r\nJOIN \r\n    Enclosures e ON ae1.enclosure_id = e.id;  -- Добавляем соединение с таблицей Enclosures";
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
