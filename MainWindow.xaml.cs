using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.IO;

namespace BrianGrassiChallengeM8
{
    public partial class MainWindow : Window
    {
        private TextDocument textDocument;

        public MainWindow()
        {
            InitializeComponent();
            textDocument = new TextDocument();
        }

        private void NewClick(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            textDocument.Content = "";
            textDocument.FilePath = "";
        }

        private void OpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                textDocument.Open(openFileDialog.FileName);
                textBox.Text = textDocument.Content;
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textDocument.FilePath))
            {
                SaveAsClick(sender, e);
            }
            else
            {
                textDocument.Content = textBox.Text;
                textDocument.Save();
            }
        }

        private void SaveAsClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                textDocument.FilePath = saveFileDialog.FileName;
                textDocument.Content = textBox.Text;
                textDocument.Save();
            }
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("              ~Text Editor~\n\nCreated by: Brian Grassi 2024 \n\nHello there :)", "About");
        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            textDocument.Content = textBox.Text;
        }
    }
    public class TextDocument
    {
        public string FilePath
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }

        public void Open(string filePath)
        {
            FilePath = filePath;
            Content = File.ReadAllText(filePath);
        }

        public void Save()
        {
            File.WriteAllText(FilePath, Content);
        }
    }
}