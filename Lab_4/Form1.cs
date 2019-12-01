using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

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
                foreach(var word in fileContent.Split(' '))
                {
                    if (!words.Contains(word))
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
            var sample = textBox2.Text;
            if (string.IsNullOrWhiteSpace(sample))
            {
                MessageBox.Show("search string not set");
                return;
            }
            var watcher = new Stopwatch();
            watcher.Start();
            if (words.Contains(sample))
            {
                listBox1.BeginUpdate();
                listBox1.Items.Add(sample);
                listBox1.EndUpdate();
            }
            watcher.Stop();
            label1.Text = watcher.Elapsed.ToString();
        }
    }
}
