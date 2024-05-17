using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Kernel.Colors;

namespace CreateCert
{
    public partial class CreateCert : Form
    {
        public CreateCert()
        {
            InitializeComponent();
        }

        private void btn_url_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_url.Text = fbd.SelectedPath;
            }
        }

        private void btn_template_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tb_template.Text = ofd.FileName;
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                string path = tb_template.Text;

                var SourceFileStream = File.OpenRead(path);
                var outputStream = new MemoryStream();
                var pdf = new PdfDocument(new PdfReader(SourceFileStream), new PdfWriter(outputStream));

                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, false);

                IDictionary<string, PdfFormField> fields = form.GetAllFormFields();
                PdfFormField toset;

                fields.TryGetValue("Text Box 1", out toset);
                toset.SetValue(tb_ten.Text);
                toset.SetFontSize(35);
                toset.SetColor(ColorConstants.RED);

                fields.TryGetValue("Text Box 2", out toset);
                toset.SetValue(tb_mssv.Text);
                toset.SetFontSize(23);
                toset.SetColor(ColorConstants.DARK_GRAY);

                fields.TryGetValue("Text Box 2_2", out toset);
                toset.SetValue(tb_hedaotao.Text);
                toset.SetFontSize(23);
                toset.SetColor(ColorConstants.DARK_GRAY);

                fields.TryGetValue("Text Box 2_3", out toset);
                toset.SetValue(tb_nganh.Text);
                toset.SetFontSize(23);
                toset.SetColor(ColorConstants.DARK_GRAY);

                fields.TryGetValue("Text Box 2_4", out toset);
                toset.SetValue(tb_xeploai.Text);
                toset.SetFontSize(23);
                toset.SetColor(ColorConstants.DARK_GRAY);

                fields.TryGetValue("Text Box 3", out toset);
                toset.SetValue("Hồ Chí Minh, ngày " + tb_ngay.Text + " tháng " + tb_thang.Text + " năm " + tb_nam.Text);
                toset.SetFontSize(10);
                toset.SetColor(ColorConstants.DARK_GRAY);

                pdf.Close();
                string url = tb_url.Text + @"\" + tb_mssv.Text + ".pdf";
                File.WriteAllBytes(url, outputStream.ToArray());
                MessageBox.Show("ĐÃ TẠO THÀNH CÔNG CHỨNG CHỈ CHO SINH VIÊN " + tb_mssv.Text, "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }
}
