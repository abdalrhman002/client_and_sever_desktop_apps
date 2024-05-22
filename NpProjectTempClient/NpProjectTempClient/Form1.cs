using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Drawing.Drawing2D;

namespace NpProjectTempClient
{
    public partial class Form1 : Form
    {
        Socket client;
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;

        byte[] buffer;
        int len;
        string extention;

        Socket file_client;
        NetworkStream file_ns;
        StreamReader file_sr;
        StreamWriter file_sw;
        public Form1()
        {
            InitializeComponent();
        }

        private async void connect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
                richTextBox1.Text += "clent: connecting....\n";

                await Task.Run( ()=> client.Connect(ep));
                richTextBox1.Text += "clent: connected\n";

                send_msg.Enabled = true;
                browse_dir.Enabled = true;
                get_file.Enabled = true;

                ns = new NetworkStream(client);
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);

                recive();

            }
            catch (Exception ex) { 

                Console.WriteLine(ex.ToString());   
            }
        }

        private async void recive()
        {
            try
            {
                while (true)
                {
                    string msg;
                    
                    msg = await Task.Run(() => sr.ReadLine());
                    richTextBox1.Text += "Server: " + msg + "\n";
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void send_msg_Click(object sender, EventArgs e)
        {
            try
            {
                string msg;
                msg = textBox1.Text;

                if (msg != "")
                {
                    sw.WriteLine(msg);
                    sw.Flush();
                    richTextBox1.Text += "Me: " + msg + "\n";
                    textBox1.Text = "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void browse_dir_Click(object sender, EventArgs e)
        {
            string dir_key = "A^*y$36V@<8H4v$#";
            try
            {
                string path;
                path = textBox2.Text;

                if (path != "")
                {
                    sw.WriteLine(dir_key);
                    sw.Flush();
                    sw.WriteLine(path);
                    sw.Flush();
                    richTextBox1.Text += $"Me: You asked for the content of this dir \"{path}\" from the server\n";
                    textBox2.Text = "";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        private void get_file_Click(object sender, EventArgs e)
        {
            string file_key = "A^*y$36V6b%j_k%4:G#";
            try
            {
                string path;
                path = textBox3.Text;

                if (path != "")
                {
                    extention = Path.GetExtension(path);
                    sw.WriteLine(file_key);
                    sw.Flush();
                    sw.WriteLine(path);
                    sw.Flush();
                    richTextBox1.Text += $"Me: You asked the server to send you that file \"{path}\"\n";
                    textBox3.Text = "";

                    receive_file();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private async void  receive_file()
        {
            try
            {
                file_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint file_ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9051);
                await Task.Run(() => file_client.Connect(file_ep));

                file_ns = new NetworkStream(file_client);
                file_sr = new StreamReader(file_ns);
                file_sw = new StreamWriter(file_ns);

                String temp = await Task.Run(() => file_sr.ReadLine());
                len = int.Parse(temp);
                buffer = new byte[len];

                await Task.Run(() => file_ns.Read(buffer, 0, len));

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "received_file" + extention );
                File.WriteAllBytes(filePath, buffer);

                sw.WriteLine("file received");
                sw.Flush();
                richTextBox1.Text += "Me: " + "file received" + "\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Clean up
                if (file_sr != null) file_sr.Close();
                if (file_sw != null) file_sw.Close();
                if (file_ns != null) file_ns.Close();
                if (file_client != null && file_client.Connected) file_client.Close();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            try
            {
                // Clean up network resources
                if (sr != null) sr.Close();
                if (sw != null) sw.Close();
                if (ns != null) ns.Close();
                if (client != null && client.Connected) client.Close();

                if (file_sr != null) file_sr.Close();
                if (file_sw != null) file_sw.Close();
                if (file_ns != null) file_ns.Close();
                if (file_client != null && file_client.Connected) file_client.Close();

                // Close the form/application
                this.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
