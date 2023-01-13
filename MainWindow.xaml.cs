﻿using System;
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
using BacenClasses;

namespace DadosPublicosBacen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

              

        private async void buscar_dados_Click(object sender, RoutedEventArgs e)


        {
            BacenRequests busca_dados = new BacenRequests();

            if (data_inicial.Text == "" && data_final.Text =="")            {

                var registros = await busca_dados.ConsultaBacen(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"));


                DI_GRID.ItemsSource = registros;

            } else if (data_inicial.Text!= "" && data_final.Text == "")
            {

                var registros = await busca_dados.ConsultaBacen(data_inicial.Text, data_inicial.Text);

                DI_GRID.ItemsSource = registros;
            } else
            {

                var registros = await busca_dados.ConsultaBacen(data_inicial.Text, data_final.Text);


                DI_GRID.ItemsSource = registros;
            }




        }

        private void exportar_dados_Click(object sender, RoutedEventArgs e)
        {

            foreach (Registro registro in DI_GRID.Items)
            {

                MessageBox.Show(registro.fatorDiario.ToString());

            }
        }
    }
}
