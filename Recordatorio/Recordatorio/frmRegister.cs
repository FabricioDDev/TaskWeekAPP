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
    public partial class frmRegister : Form
    {
        private Activity activity = null;
        public frmRegister()
        {
            InitializeComponent();
        }
        public frmRegister(Activity PreCharge)
        {
            InitializeComponent();
            activity = PreCharge;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            DataState StateD = new DataState();
            DataFrequency FrequencyD = new DataFrequency();
            cbxState.DataSource = StateD.Listing();
            cbxState.ValueMember = "Id";
            cbxState.DisplayMember = "Description";

            cbxFrequency.DataSource = FrequencyD.Listing();
            cbxFrequency.ValueMember = "Id";
            cbxFrequency.DisplayMember = "Description";
            try
            {
                if(activity != null)
                {
                    txtTitle.Text = activity.Name;
                    txtDescription.Text = activity.Description;
                    cbxFrequency.SelectedValue = activity.FrequencyType.Id;
                    cbxState.SelectedValue = activity.StateType.Id;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataActivity actD = new DataActivity();
            if (activity == null)
                activity = new Activity();

            try
            {
                
                activity.Name = txtTitle.Text;
                activity.Description = txtDescription.Text;
                activity.FrequencyType = (Frequency)cbxFrequency.SelectedItem;
                activity.StateType = (State)cbxState.SelectedItem;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            if(activity.Id == 0)
                actD.Add(activity);
            else
                actD.Modificate(activity);
                






        }
    }
}
