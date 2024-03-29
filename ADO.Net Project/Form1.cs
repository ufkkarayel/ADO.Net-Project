﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.Net_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB; initial Catalog=MyPortfolioDb; integrated Security=true");
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Project", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Project (Title, Description, ProjectCategory, CompleteDay, Price) values (@p1, @p2, @p3, @p4, @p5)", connection);
            command.Parameters.AddWithValue("@p1", txtTitle.Text);
            command.Parameters.AddWithValue("@p2", rchDetail.Text);
            command.Parameters.AddWithValue("@p3", cmdCategory.Text);
            command.Parameters.AddWithValue("@p4", txtProcessValue.Text);
            command.Parameters.AddWithValue("@p5", txtPrice.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Proje bilgisi başarıyla eklendi");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete From Project Where ProjectID=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Proje Başarıyla Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Update Project Set Title=@p1, Description=@p2, ProjectCategory=@p3, CompleteDay=@p4, Price=@p5 where ProjectID=@p6", connection);
            command.Parameters.AddWithValue("@p1", txtTitle.Text);
            command.Parameters.AddWithValue("@p2", rchDetail.Text);
            command.Parameters.AddWithValue("@p3", cmdCategory.Text);
            command.Parameters.AddWithValue("@p4", txtProcessValue.Text);
            command.Parameters.AddWithValue("@p5", txtPrice.Text);
            command.Parameters.AddWithValue("@p6", txtID.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Proje bilgisi başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btngetir_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Project Where Title=@p1", connection);
            command.Parameters.AddWithValue("@p1",txtTitle.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Category", connection);
            cmdCategory.DisplayMember = "CategoryName";
            cmdCategory.ValueMember = "CategoryID";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmdCategory.DataSource = dt;
            connection.Close();
        }
    }
}
