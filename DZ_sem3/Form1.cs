using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Lab_5_sem3;
using System.Threading.Tasks;
using System.Text;

namespace DZ_sem3
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
        // Exact find
        private void button2_Click(object sender, EventArgs e)
        {
            if (words.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать файл");
                return;
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

        // Approximate find
        private void button3_Click(object sender, EventArgs e)
        {
            if (words.Count == 0)
            {
                MessageBox.Show("Необходимо выбрать файл");
                return;
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
                return;
            }
            int threadsCount;
            if (!int.TryParse(textBox4.Text, out threadsCount))
            {
                MessageBox.Show("Введите количество потоков");
                return;
            }
            var watcher = new Stopwatch();
            watcher.Start();
            Task<List<SearchResult>>[] tasks = new Task<List<SearchResult>>[threadsCount];
            int wordsPerThread = words.Count / threadsCount;
            int current = 0;
            for (int i = 1; i <= threadsCount; i++)
            {
                List<string> threadWords = words.GetRange(current, wordsPerThread);
                current += wordsPerThread;
                if (i == threadsCount)
                {
                    if (words.Count > current)
                    {
                        threadWords.AddRange(words.GetRange(current, words.Count - current));
                    }
                }
                tasks[i-1] = new Task<List<SearchResult>>(
                    ThreadTaskWorker,
                    new SearchParam() {Words=threadWords, Distance=maxDistance, Sample=sample, ThreadNumber=i}
                );
                tasks[i - 1].Start();
            }

            Task.WaitAll(tasks);
            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            foreach (var task in tasks)
            {
                foreach(var res in task.Result)
                {
                    listBox1.Items.Add($"{res.Word} (расстояние: {res.Distance} поток: {res.ThreadNumber})");
                }
            }
            watcher.Stop();
            listBox1.EndUpdate();
            label1.Text = watcher.Elapsed.ToString();

        }

        private List<SearchResult> ThreadTaskWorker(object searchParams)
        {
            SearchParam pr = (SearchParam)searchParams;
            List<SearchResult> result = new List<SearchResult>();
            foreach (var word in pr.Words)
            {
                int distance = LevDistance.GetDistance(pr.Sample, word.ToUpper());
                if (distance <= pr.Distance)
                {
                    result.Add(new SearchResult() {Distance=distance, ThreadNumber=pr.ThreadNumber, Word=word });
                }
            }
            return result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string TempReportFileName = "Report_" + DateTime.Now.ToString("dd_MM_yyyy_hhmmss") + ".html";
            SaveFileDialog fd = new SaveFileDialog();
            fd.FileName = TempReportFileName;
            fd.DefaultExt = ".html";
            fd.Filter = "HTML|*.html";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder b = new StringBuilder();
                b.AppendLine("<html>");
                b.AppendLine("<head>");
                b.AppendLine("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'/>");
                b.AppendLine("<title>" + "Отчет: " + fd.FileName + "</title>");
                b.AppendLine("</head>");
                b.AppendLine("<body>");
                b.AppendLine("<h1>" + "Отчет: " + fd.FileName + "</h1>");
                b.AppendLine("<table border='1'>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Время чтения из файла</td>");
                b.AppendLine("<td>" + textBox4.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Слово для поиска</td>");
                b.AppendLine("<td>" + textBox2.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Максимальное расстояние для нечеткого поиска</td>");
                b.AppendLine("<td>" + textBox3.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr>");
                b.AppendLine("<td>Время поиска</td>");
                b.AppendLine("<td>" + label1.Text + "</td>");
                b.AppendLine("</tr>");
                b.AppendLine("<tr valign='top'>");
                b.AppendLine("<td>Результаты поиска</td>");
                b.AppendLine("<td>");
                b.AppendLine("<ul>");
                foreach (var x in listBox1.Items)
                {
                    b.AppendLine("<li>" + x.ToString() + "</li>");
                }
                b.AppendLine("</ul>");
                b.AppendLine("</td>");
                b.AppendLine("</tr>");
                b.AppendLine("</table>");
                b.AppendLine("</body>");
                b.AppendLine("</html>");
                File.AppendAllText(fd.FileName, b.ToString());
                MessageBox.Show("Отчет сформирован. Файл: " + fd.FileName);
            }
        }
    }
}
