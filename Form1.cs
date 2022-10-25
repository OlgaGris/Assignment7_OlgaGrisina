namespace Assignment7_OlgaGrisina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void check_Click(object sender, EventArgs e)
        {
            string[] answers = { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B", "C", "D", "A", "D", "C", "C", "B", "D", "A" };

            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    StreamReader reader = new StreamReader(fileStream);

                    string[] tests = new string[20];
                    int i = 0;

                    while (i < tests.Length && !reader.EndOfStream)
                    {
                        tests[i] = reader.ReadLine();
                     
                        i++;
                        
                    }
                    reader.Close();

                    int cor = 0;
                    int incor = 0;
                    int[] wrong = new int[20];


                    for (int index = 0; index < tests.Length; index++)
                    {
                        if (tests[index] == answers[index])
                        {
                            cor++;
                            
                        }
                        else
                        {
                            int ir = index + 1;
                            wrong[incor]=ir;
                            incor++;
                            

                            
                        }
                    }

                    result.Text = result.Text + "Correctly answers: " + cor.ToString() +"\nIncorrectly answers: "+incor.ToString()+ "\nIncorrectly answered questions:\n";
                    for(int index = 0; index < wrong.Length; index++)
                    {
                        if (wrong[index] != 0)
                        {
                            result.Text = result.Text + wrong[index].ToString() + " ";
                        }
                    }
                    
                    if(cor >= 15)
                    {
                        MessageBox.Show("Student passed the exam");
                    }
                    else
                    {
                        MessageBox.Show("Student failed the exam");
                    }
                   

                }
            }

           
        }

        


        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}