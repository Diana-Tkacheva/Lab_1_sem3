using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Lab_5_sem3;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        List<string> words;

        public Form1()
        {
            InitializeComponent();
            words = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                words = new List<string>();
                listBox1.Items.Clear();
                var watcher = new Stopwatch();
                watcher.Start();
                var fileContent = File.ReadAllText(openFileDialog1.FileName);
                char[] sep = new char[] { ' ', '.', ',', ':', ';', '!', '?', '/', '\t', '\r', '\n' };
                foreach (var word in fileContent.Split(sep))
                {
                    if (!string.IsNullOrEmpty(word) && !words.Contains(word))
                    {
                        words.Add(word);
                    }
                }
                watcher.Stop();
                textBox1.Text = watcher.Elapsed.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (words.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать файл");
            }
            var sample = textBox2.Text;
            if (string.IsNullOrWhiteSpace(sample))
            {
                MessageBox.Show("Не введено слово для поиска!");
                return;
            }
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            var watcher = new Stopwatch();
            watcher.Start();

            foreach (var item in words)
            {
                if (item.ToUpper().Contains(sample.ToUpper()))
                {
                    listBox1.Items.Add(item);
                }
            }
            watcher.Stop();
            listBox1.EndUpdate();
            label1.Text = watcher.Elapsed.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (words.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать файл");
            }
            var sample = textBox2.Text.ToUpper();
            if (string.IsNullOrWhiteSpace(sample))
            {
                MessageBox.Show("Не введено слово для поиска!");
                return;
            }
            int maxDistance;
            if (!int.TryParse(textBox3.Text, out maxDistance))
            {
                MessageBox.Show("Введите максимальное расстояние поиска!");
            }
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            var watcher = new Stopwatch();
            watcher.Start();
            foreach (var item in words)
            {
                int curDistance = LevDistance.GetDistance(sample, item.ToUpper());
                if (curDistance <= maxDistance)
                {
                    listBox1.Items.Add($"{item} (расстояние: {curDistance})");
                }
            }
            watcher.Stop();
            listBox1.EndUpdate();
            label1.Text = watcher.Elapsed.ToString();

        }
    }
}
