using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace COM_Port
{
    public partial class Form1 : Form
    {
        string dataOut;
        string dataIn;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOMPORT.Items.AddRange(ports);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cBoxCOMPORT.Text;
                serialPort1.BaudRate = Convert.ToInt32(cBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(cBoxDataBits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxPartyBit.Text);

                serialPort1.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            } 
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                dataOut = tBoxWrite.Text;
                //serialPort1.Write(dataOut);
                serialPort1.WriteLine(dataOut);
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataIn = serialPort1.ReadLine();
            //this.Invoke(new EventHandler(ShowData));
            tBoxRead.Text = dataIn;
            
        }

        //private void ShowData(object sender, EventArgs e)
        //{
        //    tBoxRead.Text = dataIn;
        //}
    }
}
