using FirebaseBookStore.Abstract;
using FirebaseBookStore.Concrete;
using FirebaseBookStore.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirebaseBookStore
{
    public partial class BaseForm : Form
    {
        IBookRepository _bookRepository;
        
        public BaseForm()
        {
            InitializeComponent();
            _bookRepository = new BookRepository();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Id = Convert.ToInt32(textBox1.Text),
                Name = textBox2.Text,
                Writer = textBox3.Text,
                Publisher = textBox4.Text,
                Price = Convert.ToDecimal(textBox5.Text),
                UnitsInStock = Convert.ToInt32(textBox6.Text)
            };
            _bookRepository.Add(book);
            MessageBox.Show("Kitap eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Book book = new Book()
                {
                    Id = Convert.ToInt32(row.Cells[0].Value)
                };
                _bookRepository.Delete(book);
            }
            MessageBox.Show("Kitaplar silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var book in _bookRepository.GetAll())
            {
                dataGridView1.Rows.Add(book.Id, book.Name, book.Writer, book.Publisher, book.Price, book.UnitsInStock);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Id = Convert.ToInt32(textBox1.Text),
                Name = textBox2.Text,
                Writer = textBox3.Text,
                Publisher = textBox4.Text,
                Price = Convert.ToDecimal(textBox5.Text),
                UnitsInStock = Convert.ToInt32(textBox6.Text)
            };
            _bookRepository.Update(book);
            MessageBox.Show("Kitap güncellendi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();
        }
    }
}
