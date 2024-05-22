using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;


namespace NpProjectTempServera
{
    public partial class Form1 : Form
    {
        Socket server, client;
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;


        byte[] buffer;
        int len;

        Socket file_server, file_client;
        NetworkStream file_ns;
        StreamReader file_sr;
        StreamWriter file_sw;

        public Form1()
        {
            InitializeComponent();

        }

        private async void listen_Click(object sender, EventArgs e)
        {
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

                server.Bind(ep);
                server.Listen(10);
                richTextBox1.Text += "Server: start listening.....\n";

                client = await Task.Run(() => server.Accept());
                richTextBox1.Text += "Server: connected\n";

                send_msg.Enabled = true;
                send_dir_contant.Enabled = true;
                send_file.Enabled = true;

                ns = new NetworkStream(client);
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);

                file_sever_start_listen();

                recive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void file_sever_start_listen()
        {
            try
            {
                file_server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint file_ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9051);
                file_server.Bind(file_ep);
                file_server.Listen(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void recive()
        {
            string dir_key = "A^*y$36V@<8H4v$#";
            string file_key = "A^*y$36V6b%j_k%4:G#";
            try
            {
                while (true)
                {
                    string msg;

                    msg = await Task.Run(() => sr.ReadLine());

                    if (msg == dir_key)
                    {
                        string dir = await Task.Run(() => sr.ReadLine());
                        richTextBox1.Text += $"Clent: what in this dir \"{dir}\"" + "\n";
                        textBox2.Text = dir;

                    }
                    else if (msg == file_key)
                    {
                        string path = await Task.Run(() => sr.ReadLine());
                        richTextBox1.Text += $"Clent: send me this file \"{path}\"" + "\n";
                        textBox3.Text = path;
                    }
                    else
                    {
                        richTextBox1.Text += "Clent: " + msg + "\n";
                    }

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



        private void send_dir_contant_Click(object sender, EventArgs e)
        {
            string path = textBox2.Text;
            try
            {
                StringBuilder listing = new StringBuilder();
                if (Directory.Exists(path))
                {
                    foreach (string file in Directory.GetFiles(path))
                    {
                        listing.AppendLine(Path.GetFileName(file));
                    }
                    foreach (string directory in Directory.GetDirectories(path))
                    {
                        listing.AppendLine(directory);
                    }

                    string contant = listing.ToString();
                    sw.WriteLine(contant);
                    sw.Flush();
                    richTextBox1.Text += "Me:\n" + contant + "\n";
                    textBox2.Text = "";
                }
                else
                {
                    sw.WriteLine("that is not a dir");
                    sw.Flush();
                    richTextBox1.Text += "Me: " + "that is not a dir" + "\n";
                    textBox2.Text = "";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private async void send_file_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBox3.Text;

                file_client = await Task.Run(() => file_server.Accept());
                file_ns = new NetworkStream(file_client);
                file_sr = new StreamReader(file_ns);
                file_sw = new StreamWriter(file_ns);
                if (File.Exists(path))
                {

                    buffer = File.ReadAllBytes(path);
                    len = buffer.Length;

                    file_sw.WriteLine(len);
                    file_sw.Flush();

                    file_ns.Write(buffer, 0, len);
                    file_ns.Flush();

                    sw.WriteLine("file sent");
                    sw.Flush();
                    richTextBox1.Text += "Me: " + "file sent" + "\n";
                    textBox3.Text = "";
                }
                else
                {
                    sw.WriteLine("file not found");
                    sw.Flush();
                    richTextBox1.Text += "Me: " + "file not found" + "\n";
                    textBox3.Text = "";
                }
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
                if (sr != null) sr.Close();
                if (sw != null) sw.Close();
                if (ns != null) ns.Close();
                if (client != null && client.Connected) client.Close();
                if (server != null) server.Close();

                if (file_sr != null) file_sr.Close();
                if (file_sw != null) file_sw.Close();
                if (file_ns != null) file_ns.Close();
                if (file_client != null && file_client.Connected) file_client.Close();
                if (file_server != null) file_server.Close();

                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void compress(string path)
        {
            try
            {
                string directory = Path.GetDirectoryName(path);
                string fileName = Path.GetFileName(path);

                string compressedFilePath = Path.Combine(directory, fileName + ".QZip.BCompressed");

                using (FileStream dest = new FileStream(compressedFilePath, FileMode.Create, FileAccess.Write))
                {
                    using (GZipStream gz = new GZipStream(dest, CompressionMode.Compress))
                    {
                        using (BinaryWriter sr = new BinaryWriter(gz))
                        {
                            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                            {
                                using (BinaryReader dd = new BinaryReader(fs))
                                {
                                    byte[] _da = dd.ReadBytes((int)dd.BaseStream.Length);

                                    sr.Write(_da);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void decompress(string path)
        {
            try
            {
                string directory = Path.GetDirectoryName(path);
                string fileName = Path.GetFileName(path);

                string decompressedFileName = fileName.Replace(".QZip.BCompressed", "");
                string decompressedFilePath = Path.Combine(directory, decompressedFileName);

                using (FileStream source = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (GZipStream gz = new GZipStream(source, CompressionMode.Decompress))
                    {
                        using (FileStream dest = new FileStream(decompressedFilePath, FileMode.Create, FileAccess.Write))
                        {
                            using (BinaryWriter bw = new BinaryWriter(dest))
                            {
                                byte[] buffer = new byte[4096];
                                int bytesRead;
                                while ((bytesRead = gz.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    bw.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
       
        private void SerializeCar(Car car, string filePath)
        {
            try
            {
                using (FileStream stream = File.Create(filePath))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, car);
                }
                Console.WriteLine("Car serialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during serialization: {ex.Message}");
            }
        }
        private Car DeserializeCar(string filePath)
        {
            Car car = null;
            try
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    car = (Car)formatter.Deserialize(stream);
                }
                Console.WriteLine("Car deserialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during deserialization: {ex.Message}");
            }
            return car;
        }
    }
    [Serializable]
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Year} {Make} {Model}";
        }
    }
}