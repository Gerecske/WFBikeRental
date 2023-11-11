namespace WFBikeRental
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Costumer costumer = new Costumer(tbName.Text, tbPhone.Text, tbEmail.Text, tbAddres.Text);
            if (costumer.AddToDB(costumer.GetId()))
            {
                frmBike bikeRental = new frmBike(costumer.GetId());
                bikeRental.Show();
            }
        }
    }
}