using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp2
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            using (var context = new ProdContext())
            {
                context.Categories.Load();
                this.categoryBindingSource.DataSource = context.Categories.Local.ToBindingList();
            }
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            List<Category> categories = new List<Category>();
            List<DataGridViewRow> list = categoryDataGridView.Rows.Cast<DataGridViewRow>().ToList();
            foreach (var CategoryRow in list)
            {
                var CategoryFormGridView = new Category()
                {
                    CategoryId = Convert.ToInt32(CategoryRow.Cells[0].Value),
                    Name = CategoryRow.Cells[1].Value as string,
                    Description = CategoryRow.Cells[2].Value as string
                };
                categories.Add(CategoryFormGridView);
            }
            using (var context = new ProdContext())
            {
                foreach (var Category in context.Categories)
                {
                    Category newCategory = categories.Find(c => c.CategoryId == Category.CategoryId);
                    Category.Name = newCategory.Name;
                    Category.Description = newCategory.Description;
                }
                context.SaveChanges();

            }
        }

        private void CategoryDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var rowList = categoryDataGridView.Rows.Cast<DataGridViewRow>().ToList();
            var selectedRow = rowList[rowIndex];
            var categoryId = Convert.ToInt32(selectedRow.Cells[0].Value);
            using (var context = new ProdContext())
            {
                var products = context.Products
                    .Where(p => p.CategoryId == categoryId);

                this.productsBindingSource.DataSource = new BindingList<Product>(products.ToList());

            }
        }
    }
}
