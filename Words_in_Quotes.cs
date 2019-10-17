using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rachel1
{
    public partial class Words_in_Quotes : Form
    {
        List<record> list_of_records;
        list_of_terms lft = new list_of_terms();
        public Words_in_Quotes()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            string[] a = comboBox1.Text.Split('.');
            int q = int.Parse(a[0]);
            string quote=list_of_records[q].quotes;
            string str="";
            foreach (term t in lft.terms_list)
            {
                t.count_Phrase_inText_and_pluggin_Phrase_instances(quote);
                if (t.Phrase_instances > 0)
                {
                    str += t.Show_Me();
                    str += "\r\n\t";
                }
            }
            textBox1.Text = str;
        }

        private void Words_in_Quotes_Load(object sender, EventArgs e)
        {
            list_of_records = Texts_Anaysis.CCCL("Final List.csv");
            lft.Csv_into_this_list_of_terms(Texts_Anaysis.Main_path+"words_list.csv");
            foreach (record r in list_of_records)
            {
                string sss = "" + r.index + ". " + r.acq_full_name + " " + r.target_fullname;
                comboBox1.Items.Add(sss);
                
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string str = Texts_Anaysis.AllPhrasesForAllRecords(list_of_records, lft, Texts_Anaysis.Main_path + "Phrases.txt");
             str = Texts_Anaysis.AllPhrasesForAllRecords_for_CSV(list_of_records, lft, Texts_Anaysis.Main_path + "PhrasesCSV.txt");
             str = Texts_Anaysis.AllPhrasesForAllRecords_for_CSV(list_of_records, lft, Texts_Anaysis.Main_path + "PhrasesCSV.csv");
        }
    }
}
