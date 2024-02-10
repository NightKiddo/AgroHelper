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
        DBOperator dboperator = FormBase.dboperator;
        Note note;
        public FormShowNote(Note note)
        {
            InitializeComponent();
            this.note = note;
            loadNote();
        }
        private void loadNote()
        {
            label1.Text = note.Name;
            richTextBox1.Text = note.Description;
            dateTimePicker1.Value = note.Start_date;
            dateTimePicker2.Value = note.Finish_date;
            label4.Text = "Pole: " + note.Field.Name;
        }

        private void buttonShowField_Click(object sender, EventArgs e)
        {            
            FormShowField formShowField = new FormShowField(note.Field.Id);
            formShowField.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Notes", "id", note.Id);
            dboperator.delete(query);
            this.Close();
        }
    }
}
