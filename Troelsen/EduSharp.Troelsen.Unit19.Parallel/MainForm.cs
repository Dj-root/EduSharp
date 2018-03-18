using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduSharp.Troelsen.Unit19.Parallel
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => { ProcessFiles(); }
            );
        }

        private void ProcessFiles()
        {
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;



            string[] files = Directory.GetFiles
                (@"C:\Temp\Images", "*.jpg", SearchOption.AllDirectories);
            string newDir = @"C:\Temp\ModifiedImages";
            Directory.CreateDirectory(newDir);



            try
            {
                System.Threading.Tasks.Parallel.ForEach(files, parOpts, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();

                    string filename = Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, filename));

                        this.Invoke((Action)delegate
                           {
                               this.Text = string.Format("Processing {0} on thread {1}", filename,
                                   Thread.CurrentThread.ManagedThreadId);
                           });
                    }

                });

                this.Invoke((Action) delegate { this.Text = "Done!"; });
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate { this.Text = ex.Message; });
            }


            //foreach (string currentFile in files)
            //{
            //    string filename = Path.GetFileName(currentFile);

            //    using (Bitmap bitmap = new Bitmap(currentFile))
            //    {
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(Path.Combine(newDir, filename));

            //        this.Text = string.Format("Processing {0} on thread {1}", filename,
            //            Thread.CurrentThread.ManagedThreadId);
            //    }
            //}

            //System.Threading.Tasks.Parallel.ForEach(files, currentFile =>
            //    {
            //        string filename = Path.GetFileName(currentFile);

            //        using (Bitmap bitmap = new Bitmap(currentFile))
            //        {
            //            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //            bitmap.Save(Path.Combine(newDir, filename));
            //        }

            //        this.Invoke((Action)delegate
            //       {
            //           this.Text = string.Format("Processing {0} on thread {1}", filename,
            //                       Thread.CurrentThread.ManagedThreadId);
            //       });
            //    }
            //);
        }

        private void ProcessIntData()
        {
            int[] source = Enumerable.Range(1, 100000000).ToArray();

            int[] modThreeIsZero = null;
            try
            {
                modThreeIsZero = (from num in source.AsParallel()
                    where num % 3 == 0 orderby num descending
                    select num).ToArray();

                MessageBox.Show(string.Format("Found {0} numbers that match query!", modThreeIsZero.Length));
            }
            catch (Exception e)
            {
                this.Invoke((Action)delegate { this.Text = e.Message; });
            }



        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void btnExecuteDemo_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => { ProcessIntData(); });
        }
    }
}
