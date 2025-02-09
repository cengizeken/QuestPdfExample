using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestPdfExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
            /*     
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.Header().Text("kubilay").Bold().FontSize(96).FontColor(Colors.LightBlue.Lighten1);
                });
            }).GeneratePdf("HelloWorld.pdf");   */

            Document.Create(container =>
                {
                    container.Page(page =>
                    {
                    page.Margin(1, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.Header().Text("Let`s Math")
                    .Bold().FontSize(36).FontColor(Colors.LightGreen.Lighten3);

                    page.Content().Column(column =>

                    {
                        column.Spacing(20);
                        column.Item().Text("Solvere sequenti quaestione");
                        //column.Item().Image(Placeholders.Image(200, 100));
                        byte[] fenomen5BSorusu = File.ReadAllBytes("fenomen5Bsoru.png");
                        column.Item().Image(fenomen5BSorusu);
                        column.Item().Text("Çözüm:").Underline();
                        column.Item().Text("2688/48 = " + (2688/48) +" => 784/56 = " + (784/56) + " cevap (B) şıkkı");

                        column.Item().Row(row =>
                        {
                              row.Spacing(20);
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                byte[] imageData = File.ReadAllBytes("fenomen5Bsoru.png");
                                c.Item().Image(imageData);    
                            });

                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                c.Item().Image(Placeholders.Image(200, 100));
                            });
                            
                        });
                        column.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                c.Item().Image(Placeholders.Image(200, 100));
                            });

                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                c.Item().Image(Placeholders.Image(200, 100));
                            });
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                c.Item().Image(Placeholders.Image(200, 100));
                            });
                        });

                    } );

                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.CurrentPageNumber();
                            x.Span(" / ");
                            x.TotalPages();
                        }
                        );
                    });
                }).GeneratePdf("Obayana.pdf");
        }
    }
}
                                                                        