using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Svg;
using System.Drawing.Imaging;

namespace BBBImageSaver
{
    public partial class BBBImageSaverForm : Form
    {
        private readonly string _extensionImage = ".png";
        private int _imageIndex = 1;
        private string _path;

        private bool _successDownload;

        private StringBuilder _pathBuilder;

        public BBBImageSaverForm()
        {
            InitializeComponent();
            _pathBuilder = new StringBuilder();
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            var fileDialog = new SaveFileDialog();

            fileDialog.Filter = $"PNG File | *{_extensionImage}";
            var result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                _path = fileDialog.FileName;
                _path = GetStartPath();
                Application.UseWaitCursor = true;
                await Task.Run(() => Download(tb_uri.Text));
                Application.UseWaitCursor = false;
                if (_successDownload)
                {
                    MessageBox.Show("Скачивание завершено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        private async Task Download(string uri)
        {
            try
            {
                var client = new HttpClient();
                uri = GetStartUri(uri);
                var response = await client.GetAsync(uri);
                while (response.StatusCode != HttpStatusCode.NotFound)
                {
                    var bytes = await response.Content.ReadAsByteArrayAsync();
                    using (var stream = new MemoryStream(bytes))
                    {
                        var svgDocument = SvgDocument.Open<SvgDocument>(stream);
                        var bitmap = svgDocument.Draw();
                  
                        bitmap.Save(_path, ImageFormat.Png);

                        _path = UpdatePath();
                        uri = UpdateUri(uri);

                        response = await client.GetAsync(uri);
                    }
                }
                _successDownload = true;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStartUri(string uri)
        {
            var index = uri.LastIndexOf('/');

            return $"{uri.Remove(index, uri.Length - index)}/{1}";
        }

        private string GetStartPath()
        {
            var index = _path.LastIndexOf('.');

            return $"{_path.Remove(index)}_{1}{_extensionImage}";
        }

        private string UpdateUri(string uri)
        {
            var index = uri.LastIndexOf('/');
            var numberStr = uri.Substring(index + 1);
            var currentNumberPage = int.Parse(numberStr);

            return $"{uri.Remove(index, uri.Length - index)}/{currentNumberPage + 1}";
        }

        private string UpdatePath()
        {
            var index = _path.LastIndexOf('_') + 1;

            _imageIndex++;

            _pathBuilder.Append(_path);
            _pathBuilder.Remove(index, _path.Length - index);
            _pathBuilder.Append($"{_imageIndex}{_extensionImage}");     

            _path = _pathBuilder.ToString();
            _pathBuilder.Clear();

            return _path;
        }
    }
}
