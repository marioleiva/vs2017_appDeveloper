using Shop.Services.implementation;
using Shop.Services.Interfaces.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.Presentation.Desktop
{
    public partial class Form1 : Form
    {
        private IProductHandler _productHandler;

        public Form1()
        {
            this._productHandler = new EFProductHandler();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this._productHandler.GetProductByCategoryId(1)
                .ToList()
                .ForEach(x => {
                    this.dataGridView1.Rows.Add(x.Id, x.Name, x.Description, x.CategoryName);
                });
        }
    }
}
