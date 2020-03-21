using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Sprite_Plist_Extractor
{
    public partial class Extractor : Form
    {
        string fileName;
        string imageName;
        List<Item> listUnrotated = new List<Item>();
        List<Item> listRotated = new List<Item>();

        public Extractor()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = Image.FromFile(imageName);
            }
            catch
            {
                MessageBox.Show("Please put your image in same directory with plist file!");
                return;
            }
            listUnrotated.Clear();
            listRotated.Clear();
            if (fileName != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNode dicts = doc.DocumentElement.ChildNodes[0].ChildNodes[1];
                string name = "";
                Rectangle frame;
                Point offset = new Point();
                Rectangle sourceColorRect;
                Point sourceSize;
                string[] str;
                foreach (XmlNode node in dicts)
                {
                    if (node.Name == "key")
                    {
                        name = node.InnerText;
                    }
                    else
                    {
                        if (node.ChildNodes[5].Name == "true")
                        {
                            str = node.ChildNodes[1].InnerText.Split('{', '}', ',');
                            frame = new Rectangle(Convert.ToInt16(str[2]), Convert.ToInt16(str[3]), Convert.ToInt16(str[7]), Convert.ToInt16(str[6]));
                            str = node.ChildNodes[7].InnerText.Split('{', '}', ',');
                            sourceColorRect = new Rectangle(Convert.ToInt16(str[3]), Convert.ToInt16(str[2]), Convert.ToInt16(str[7]), Convert.ToInt16(str[6]));
                            str = node.ChildNodes[9].InnerText.Split('{', '}', ',');
                            sourceSize = new Point(Convert.ToInt16(str[2]), Convert.ToInt16(str[1]));
                            sourceColorRect.X = sourceSize.X - sourceColorRect.X - sourceColorRect.Width;
                            listRotated.Add(new Item(name, frame, offset, sourceColorRect, sourceSize));
                        }
                        else
                        {
                            str = node.ChildNodes[1].InnerText.Split('{', '}', ',');
                            frame = new Rectangle(Convert.ToInt16(str[2]), Convert.ToInt16(str[3]), Convert.ToInt16(str[6]), Convert.ToInt16(str[7]));
                            str = node.ChildNodes[7].InnerText.Split('{', '}', ',');
                            sourceColorRect = new Rectangle(Convert.ToInt16(str[2]), Convert.ToInt16(str[3]), Convert.ToInt16(str[6]), Convert.ToInt16(str[7]));
                            str = node.ChildNodes[9].InnerText.Split('{', '}', ',');
                            sourceSize = new Point(Convert.ToInt16(str[1]), Convert.ToInt16(str[2]));
                            listUnrotated.Add(new Item(name, frame, offset, sourceColorRect, sourceSize));
                        }
                    }
                }
                export();
            }
            else
            {
                MessageBox.Show("Please choose file first!");
            }
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            fileName = openFileDialog.FileName;
            imageName = fileName.Replace(".plist", ".png");
        }

        private void export()
        {
            bool exists = System.IO.Directory.Exists("Output");
            if (!exists)
                System.IO.Directory.CreateDirectory("Output");
            Bitmap imgSprite = (Bitmap)Image.FromFile(imageName);
            Bitmap imgSource;
            Bitmap imgFull;
            Graphics g;
            PixelFormat pixelFormat = imgSprite.PixelFormat;
            foreach (Item item in listUnrotated)
            {
                imgSource = imgSprite.Clone(item.frame, pixelFormat);
                imgFull = new Bitmap(item.sourceSize.X, item.sourceSize.Y);
                g = Graphics.FromImage(imgFull);
                g.DrawImage(imgSource, item.sourceColorRect);
                imgFull.Save("Output/" + item.name + ".png");
                g.Dispose();
                imgSource.Dispose();
                imgFull.Dispose();
            }
            foreach (Item item in listRotated)
            {
                imgSource = imgSprite.Clone(item.frame, pixelFormat);
                imgFull = new Bitmap(item.sourceSize.X, item.sourceSize.Y);
                g = Graphics.FromImage(imgFull);
                g.DrawImage(imgSource, item.sourceColorRect);
                imgFull.RotateFlip(RotateFlipType.Rotate270FlipNone);
                imgFull.Save("Output/" + item.name + ".png");
                g.Dispose();
                imgSource.Dispose();
                imgFull.Dispose();
            }
            imgSprite.Dispose();
            MessageBox.Show("Done");
        }

    }
}
