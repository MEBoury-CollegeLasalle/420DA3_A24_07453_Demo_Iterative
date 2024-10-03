using _420DA3_Demo_Iterative.Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _420DA3_Demo_Iterative.Presentation.Views;
public partial class CoursView : Form {
    private readonly CoursService service;

    public CoursView(CoursService service) {
        this.service = service;
        this.InitializeComponent();
        this.dataGridView1.DataSource = this.service.GetCoursDataTable();
    }

    private void ButtonReload_Click(object sender, EventArgs e) {
        this.service.ReloadTableData();
    }

    private void ButtonSaveChanges_Click(object sender, EventArgs e) {
        this.service.SaveChanges();
    }

    private void BoutonQuitter_Click(object sender, EventArgs e) {
        this.DialogResult = DialogResult.OK;
    }
}
