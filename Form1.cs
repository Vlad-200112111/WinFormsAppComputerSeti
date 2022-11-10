namespace WinFormsAppComputerSeti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            var selectedType = comboBox1.SelectedItem;
            if (selectedType.ToString() == "����� ����")
            {

                list.Clear();
                list.Add("4 ����");
                list.Add("8 ���");
            }
            if (selectedType.ToString() == "������")
            {
                list.Clear();
                list.Add("��1");
                list.Add("��2");
                list.Add("��3");
                list.Add("��4");
            }
            if (selectedType.ToString() == "Wi-Fi")
            {
                list.Clear();
                list.Add("802.11� (5 ���)");
                list.Add("802.11b (2.4 ���)");
                list.Add("802.11g (2.4 ���)");
                list.Add("802.11n (2.4 ���)");
                list.Add("802.11n (5 ���)");
                list.Add("802.11�c (5 ���)");
            }
            comboBox2.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = "����������, ��������� ��� ����";
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && 
                comboBox3.SelectedItem != null && textBox1.Text != "")
            {
                var selectedType=comboBox1.SelectedItem.ToString;
                var selectedCharacterType = comboBox2.SelectedItem.ToString;
                var selectedCadrType = comboBox3.SelectedItem.ToString;
                var inputWidth = float.Parse(textBox1.Text);
                if (selectedType == "����� ����".ToString && inputWidth<=100) 
                {
                    if (selectedCharacterType == "4 ����".ToString &&
                        (selectedCadrType == "Gigabit Ethernet(1)".ToString||
                         selectedCadrType == "Gigabit Ethernet(10)".ToString))
                    {
                        result = "�� ����� �������� (�� �������)";
                    }
                    else
                    {
                        result = "����� �������� (������ �� ������� ����)";
                    }
                }

                else if (selectedType == "������".ToString)
                {
                    if (selectedCharacterType == "��1".ToString) 
                    {
                        if (selectedCadrType == "Ethernet DIX".ToString &&
                            inputWidth > 2000)
                        {
                            result = "�� ����� �������� (�� �������)";
                        }
                        else if (selectedCadrType == "Fast Ethernet".ToString &&
                            inputWidth > 10000)
                        {
                            result = "�� ����� �������� (�� �������)";
                        }
                        else 
                        {
                            result = "����� �������� (������ �� ������� ����)";
                        }
                    }

                    else if(selectedCharacterType == "��2".ToString &&
                            inputWidth <= 550)
                    {
                        if (selectedCadrType == "Gigabit Ethernet(10)".ToString)
                        {
                            result = "�� ����� �������� (�� �������)";
                        }
                        else
                        {
                            result = "����� �������� (������ �� ������� ����)";
                        }
                    }

                    else if(selectedCharacterType == "��3".ToString &&
                            inputWidth <= 300)
                    {
                            result = "����� �������� (������ �� ������� ����)";
                    }

                    else if (selectedCharacterType == "��4".ToString &&
                            inputWidth <= 125)
                    {
                            result = "����� �������� (������ �� ������� ����)";
                    }
                    else
                    {
                        result = "�� ����� �������� (�� �������)";
                    }
                }

                else if (selectedType == "Wi-Fi".ToString && inputWidth <= 60)
                {
                    if ((selectedCharacterType == "802.11� (5 ���)".ToString ||
                         selectedCharacterType == "802.11g (2.4 ���)".ToString ) &&
                         selectedCadrType == "Ethernet DIX".ToString)
                    {
                        result = "����� �������� (������ �� ������� ����)";
                    }
                    else if (selectedCharacterType == "802.11n (2.4 ���)".ToString)
                    {
                        result = "����� ��������, �� �� 110 ����/�";
                    }
                    else if (selectedCharacterType == "802.11n (5 ���)".ToString)
                    {
                        result = "����� ��������, �� �� 220 ����/�";
                    }
                    else if (selectedCharacterType == "802.11�c (5 ���)".ToString)
                    {
                        result = "����� ��������, �� ����� 200 ����/�";
                    }
                    else
                    {
                        result = "�� ����� �������� (�� �������)";
                    }
                }

                else
                {
                    result = "�� ����� �������� (�� �������)";
                }

            };

            label7.Text = result;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {   
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // �����, ������� BackSpace � �������
            {
                e.Handled = true;
            }
        }
    }
}