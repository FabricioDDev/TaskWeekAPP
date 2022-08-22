using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomainModel;
using DataModel;

namespace Recordatorio
{
    public partial class frmMain : Form
    {
        private List<Activity> ListActivities;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmRegister frmAdd = new frmRegister();
            frmAdd.ShowDialog();
            Charge();
        }

        private void btnModificate_Click(object sender, EventArgs e)
        {
            Activity Selected = (Activity)dgvActivity.CurrentRow.DataBoundItem;
            frmRegister frmModificate = new frmRegister(Selected);
            frmModificate.ShowDialog();
            Charge();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Charge();
        }
        private void Charge()
        {
            DataActivity dataActivity = new DataActivity();
            ListActivities = dataActivity.Listing();
            dgvActivity.DataSource = ListActivities;
            dgvActivity.Columns["Id"].Visible = false;
            dgvActivity.Columns["Active"].Visible = false;
        }

        private void btnMoveTrash_Click(object sender, EventArgs e)
        {
            DataActivity actD = new DataActivity();
            Activity Selected = (Activity)dgvActivity.CurrentRow.DataBoundItem;
            try
            {
                actD.LDelete(Selected);
                MessageBox.Show("El elemento seleccionado fue llevado exitosamente a la papelera");
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error. Intentelo mas tarde.");
            }

            Charge();
        }

        

        
    }
}
