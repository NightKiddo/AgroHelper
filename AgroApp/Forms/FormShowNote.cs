using AgroApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp.Forms
{
    public partial class FormShowNote : Form
    {
        int noteId;
        DBOperator dboperator = new DBOperator();
        object[] note;
        public FormShowNote(int activityId)
        {
            InitializeComponent();
            this.noteId = activityId;
            loadNote();
        }
        private void loadNote()
        {
            string name, description, fieldName;
            DateTime startDate, finishDate;

            note = dboperator.getNote(noteId);

            name = note[0].ToString();
            description = note[1].ToString();
            DateTime.TryParse(note[2].ToString(), out startDate);
            DateTime.TryParse(note[3].ToString(), out finishDate);

            fieldName = dboperator.select("SELECT name FROM Fields WHERE id = " + note[4]).ToString();

            label1.Text = name;
            richTextBox1.Text = description;
            dateTimePicker1.Value = startDate;
            dateTimePicker2.Value = finishDate;
            label4.Text = "Pole: " + fieldName;
        }

        private void buttonShowField_Click(object sender, EventArgs e)
        {
            int fieldId;
            Int32.TryParse(note[4].ToString(), out fieldId);
            FormShowField formShowField = new FormShowField(fieldId);
            formShowField.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Notes", "id", noteId);
            dboperator.delete(query);
            this.Close();
        }
    }
}
