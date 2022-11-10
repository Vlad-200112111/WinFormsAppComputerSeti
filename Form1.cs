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
            if (selectedType.ToString() == "Витая пара")
            {

                list.Clear();
                list.Add("4 Жилы");
                list.Add("8 Жил");
            }
            if (selectedType.ToString() == "Оптика")
            {
                list.Clear();
                list.Add("ОМ1");
                list.Add("ОМ2");
                list.Add("ОМ3");
                list.Add("ОМ4");
            }
            if (selectedType.ToString() == "Wi-Fi")
            {
                list.Clear();
                list.Add("802.11а (5 ГГц)");
                list.Add("802.11b (2.4 ГГц)");
                list.Add("802.11g (2.4 ГГц)");
                list.Add("802.11n (2.4 ГГц)");
                list.Add("802.11n (5 ГГц)");
                list.Add("802.11аc (5 ГГц)");
            }
            comboBox2.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = "Пожалуйста, заполните все поля";
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && 
                comboBox3.SelectedItem != null && textBox1.Text != "")
            {
                var selectedType=comboBox1.SelectedItem.ToString;
                var selectedCharacterType = comboBox2.SelectedItem.ToString;
                var selectedCadrType = comboBox3.SelectedItem.ToString;
                var inputWidth = float.Parse(textBox1.Text);
                if (selectedType == "Витая пара".ToString && inputWidth<=100) 
                {
                    if (selectedCharacterType == "4 Жилы".ToString &&
                        (selectedCadrType == "Gigabit Ethernet(1)".ToString||
                         selectedCadrType == "Gigabit Ethernet(10)".ToString))
                    {
                        result = "Не будет работать (не обязано)";
                    }
                    else
                    {
                        result = "Будет работать (должно по крайней мере)";
                    }
                }

                else if (selectedType == "Оптика".ToString)
                {
                    if (selectedCharacterType == "ОМ1".ToString) 
                    {
                        if (selectedCadrType == "Ethernet DIX".ToString &&
                            inputWidth > 2000)
                        {
                            result = "Не будет работать (не обязано)";
                        }
                        else if (selectedCadrType == "Fast Ethernet".ToString &&
                            inputWidth > 10000)
                        {
                            result = "Не будет работать (не обязано)";
                        }
                        else 
                        {
                            result = "Будет работать (должно по крайней мере)";
                        }
                    }

                    else if(selectedCharacterType == "ОМ2".ToString &&
                            inputWidth <= 550)
                    {
                        if (selectedCadrType == "Gigabit Ethernet(10)".ToString)
                        {
                            result = "Не будет работать (не обязано)";
                        }
                        else
                        {
                            result = "Будет работать (должно по крайней мере)";
                        }
                    }

                    else if(selectedCharacterType == "ОМ3".ToString &&
                            inputWidth <= 300)
                    {
                            result = "Будет работать (должно по крайней мере)";
                    }

                    else if (selectedCharacterType == "ОМ4".ToString &&
                            inputWidth <= 125)
                    {
                            result = "Будет работать (должно по крайней мере)";
                    }
                    else
                    {
                        result = "Не будет работать (не обязано)";
                    }
                }

                else if (selectedType == "Wi-Fi".ToString && inputWidth <= 60)
                {
                    if ((selectedCharacterType == "802.11а (5 ГГц)".ToString ||
                         selectedCharacterType == "802.11g (2.4 ГГц)".ToString ) &&
                         selectedCadrType == "Ethernet DIX".ToString)
                    {
                        result = "Будет работать (должно по крайней мере)";
                    }
                    else if (selectedCharacterType == "802.11n (2.4 ГГц)".ToString)
                    {
                        result = "Будет работать, но до 110 Мбит/с";
                    }
                    else if (selectedCharacterType == "802.11n (5 ГГц)".ToString)
                    {
                        result = "Будет работать, но до 220 Мбит/с";
                    }
                    else if (selectedCharacterType == "802.11аc (5 ГГц)".ToString)
                    {
                        result = "Будет работать, но более 200 Мбит/с";
                    }
                    else
                    {
                        result = "Не будет работать (не обязано)";
                    }
                }

                else
                {
                    result = "Не будет работать (не обязано)";
                }

            };

            label7.Text = result;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {   
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }
    }
}