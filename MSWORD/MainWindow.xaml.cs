using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSWORD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBox2.Cut();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox2.Copy();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox2.Paste();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            textBox2.SelectAll();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(textbox1.Text, textBox2.Text);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;
            if (choofdlog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                textbox1.Text = sFileName;
                textBox2.Text = File.ReadAllText(sFileName);
            }
        }

        private void textchanged(object sender, TextChangedEventArgs e)
        {
            if (Toggle2.IsChecked == true)
            {
                System.Windows.Automation.Peers.ButtonAutomationPeer peer = new System.Windows.Automation.Peers.ButtonAutomationPeer(savebtn);
                IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProv.Invoke();
            }
        }

       
    }
}
