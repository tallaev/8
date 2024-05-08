using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_8._2
{
    public partial class Form1 : Form
    {
        private Dictionary<string, double> answers = new Dictionary<string, double>()
        {
            { "Да, определенно", 0.2 }, //x<0.2
            { "Нет, ни в коем случае", 0.1 }, //0.2<=x<0.3
            { "Может быть", 0.3 }, //0.3<=x<0.6
            { "Попробуйте снова позже", 0.2 }, //0.6<=x<0.8
            { "Сомнительно", 0.2 } //x>=0.8
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAsk_Click(object sender, EventArgs e)
        {
            string question = txtQuestion.Text;

            if (!string.IsNullOrEmpty(question))
            {
                string answer = GetRandomAnswer();
                MessageBox.Show(answer, "Ответ шара предсказаний");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите вопрос.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetRandomAnswer()
        {
            double totalProbability = answers.Values.Sum();
            
            double randomValue = new Random().NextDouble() * totalProbability;

            double cumulative = 0;

            foreach (var pair in answers)
            {
                cumulative += pair.Value;
                if (randomValue < cumulative)
                    return pair.Key;
            }

            return answers.Keys.Last();
        }
    }
}
