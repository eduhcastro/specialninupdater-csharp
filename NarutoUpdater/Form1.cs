using NarutoUpdater.Controllers;


namespace NarutoUpdater
{
    public partial class Form1 : Form
    {
        private static string? Version;
 
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sourcedialog.ShowDialog() == DialogResult.OK)
            {
                button1.Text = sourcedialog.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (exportdialog.ShowDialog() == DialogResult.OK)
            {
                if (sourcedialog.SelectedPath == exportdialog.SelectedPath)
                {
                    MessageBox.Show("As pastas não podem ser iguais");
                    return;
                }
                button2.Text = exportdialog.SelectedPath;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            bool isNumber = int.TryParse(versioninput.Text, out _);
            if(!isNumber)
            {
                MessageBox.Show("Invalid Version!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(sourcedialog.SelectedPath == "" || exportdialog.SelectedPath == "")
            {
                MessageBox.Show("Invalid Path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Version = versioninput.Text;
            Lua.SetVersion(Version);
        //  MessageBox.Show("Mensagem");
            
            Files.Copy(sourcedialog.SelectedPath, exportdialog.SelectedPath);

        }

    }
}

