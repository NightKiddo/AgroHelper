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
            labelName.Text = note.Name;
            richTextBox1.Text = note.Description;
            dateTimePicker1.Value = note.Start_date;
            dateTimePicker2.Value = note.Finish_date;
            label4.Text = "Pole: " + note.Field.Name;
            labelType.Text = note.Type.Type;            
            labelValue.Text = "Ilość: " + note.Value.ToString();
            if (note.Type.Type == "Opady")
            {
                labelValue.Text += " l/ha";
            }
        }

        private void buttonShowField_Click(object sender, EventArgs e)
        {
            FormShowField formShowField = new FormShowField(note.Field);
            formShowField.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteQuery query = new DeleteQuery("Notes", "id", note.Id);
            dboperator.delete(query);
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Farm farm = null;
            foreach (Farm f in dboperator.getFarms())
            {
                foreach (Note n in f.Journal.NotesList)
                {
                    if (n.Id == note.Id)
                    {
                        farm = f; break;
                    }
                }
            }
            FormAddNote formAddNote = new FormAddNote(farm, note.Id);
            formAddNote.ShowDialog();

            foreach (Farm f in dboperator.getFarms())
            {
                if (farm.Id == f.Id)
                {
                    farm = f; break;
                }
            }

            foreach (Note n in farm.Journal.NotesList)
            {
                if (note.Id == n.Id)
                {
                    note = n;
                }
            }

            loadNote();
        }
    }
}
