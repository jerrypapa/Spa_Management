using System;
using System.Linq;
using System.Threading.Tasks;
//using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using iText.Barcodes;
using iText.Kernel.Pdf.Xobject;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Geom;
using Path = System.IO.Path;
using iText.Kernel.Colors;
using System.Text;
using iText.IO.Image;
using System.IO;

namespace Spa_Management.Autogen
{
    public class AutoGen : IAutoGen
    {
        private readonly IEmailSender _emailSender;
        private readonly IDatabaseErrorLogger _databaseErrorLogger;
        private readonly ISystemParameters _systemParameters;
        private readonly ApplicationDbContext _context;
        private readonly ISMSSender _sMSSender;
        private static IHostingEnvironment _env;
        private readonly IDbOperations _dbOps;
        public AutoGen(ApplicationDbContext context, IEmailSender emailSender,
        IDatabaseErrorLogger databaseErrorLogger, ISystemParameters systemParameters,
        ISMSSender sMSSender, IHostingEnvironment env,IDbOperations dbOperations)
        {
            _context = context;
            _emailSender = emailSender;
            _databaseErrorLogger = databaseErrorLogger;
            _systemParameters = systemParameters;
            _sMSSender = sMSSender;
            _env = env;
            _dbOps = dbOperations;
        }


    
    public async Task<(bool,string,string,string)> AutoGenerateBond(Guid applicationId, bool bankAccess)
        {
            try
            {
                //var appid = "F52675D5-98C2-498B-846C-207F2674A528";
                //applicationId =Guid.Parse(appid);
                var applicationDetails = _context.TbApplications.FirstOrDefault(c => c.CRBGuid == applicationId);

                var BankDetails = _context.TbSystemBanks.FirstOrDefault(c => c.SystemBanksGuid == applicationDetails.SystemBanksGuid);
                var BeneficiaryDetails = _context.TbBeneficialies.FirstOrDefault(k => k.benGuid == Guid.Parse(applicationDetails.Purchaser));
                var companyDetails = _context.TbCompanies.FirstOrDefault(v => v.compGuid == applicationDetails.compGuid);

                var currAmount = applicationDetails.amount;

                var regionInfo = new RegionInfo("sw-KE");
                var currencySymbol = regionInfo.ISOCurrencySymbol;
                var formattedCurrency = String.Format(new System.Globalization.CultureInfo("sw-KE"), "{0:c}", currAmount);

                //1get Bank Details
                //BankName
                //Bank Params...........AUTH SIG, LETTER HEAD, LOGO
                //GET APPLICATION DETAILS
                //

                var bonds = Path.Combine(_env.WebRootPath, "BidBonds", applicationId.ToString());

                if (!BankDetails.bankName.Contains("FAMILY")/*!String.Equals("FAMILY BANK KENYA LIMITED", BankDetails.bankName)*/)
                {
                   

                    //using (var strea = new FileStream(bonds, FileMode.Create))
                    //{
                    //    await BoardResolution.CopyToAsync(strea);
                    //}

                    string fileName = applicationId.ToString();
                    var fullDocPath = bonds + fileName + ".pdf";
                    PdfWriter writer = new PdfWriter(fullDocPath);

                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    // Header
                    Paragraph header = new Paragraph("TENDER SECURITY FORM")
                       .SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(20);

                    // New line
                    Paragraph newline = new Paragraph(new Text("\n"));

                    document.Add(newline);
                    document.Add(header);

                    // Add sub-header
                    Paragraph subheader = new Paragraph(BankDetails.bankName)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(12);
                    document.Add(subheader);

                    // Line separator
                    LineSeparator ls = new LineSeparator(new SolidLine());
                    document.Add(ls);

                    // Add paragraph1
                    Paragraph paragraph1 = new Paragraph("Whereas " + companyDetails.compName.ToUpper() + " " + "(hereinafter called “the tenderer”) " + " has submitted its tender dated" + " " +
                        applicationDetails.appDate.ToString() + " " + "for " + applicationDetails.Details.ToLower() + ". " + companyDetails.compName.ToUpper() + " " + "KNOW ALL PEOPLE by these presents that WE "
                        + BankDetails.bankName.ToUpper() + " " + "(hereinafter called “the Guarantor”)" + " " + "are bound unto" + " " + BeneficiaryDetails.FirstName.ToUpper() + " (hereinafter called “the Procuring entity”) in the sum of  " +
                        formattedCurrency +
                        " for which payment well and truly to be made to the said Procuring entity, the Bank binds itself, its " +
                        "successors, and assigns by these presents.Sealed with the Common Seal of the said Bank this day " +
                        applicationDetails.appDate.ToString());

                    document.Add(paragraph1);

                    Paragraph paragraph2 = new Paragraph("THE CONDITIONS OF THIS OBLIGATION").SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(12);
                    document.Add(paragraph2);
                    LineSeparator ls22 = new LineSeparator(new SolidLine());
                    document.Add(ls22);

                    Paragraph paragraph33 = new Paragraph("1. If the tenderer withdraws its Tender during the period of" +
                                                            "tender validity specified by the tenderer on the Tender Form;");
                    document.Add(paragraph33);

                    Paragraph paragraph34 = new Paragraph("2. If the tenderer, having been notified" +
                                                            "of the acceptance of its Tender by the Procuring entity during the period of tender validity: (a)fails or " +
                                                            "refuses to execute the Contract Form, if required; or(b) fails or refuses to furnish the performance " +
                                                            "security in accordance with the Instructions to tenderers;");
                    document.Add(paragraph34);

                    Paragraph paragraph3 = new Paragraph("3. We undertake to pay to the Procuring entity up to the above amount upon receipt of its first written " +
                                                            "demand, without the Procuring entity having to substantiate its demand, provided that in its demand " +
                                                            "the Procuring entity will note that the amount claimed by it is due to it, owing to the occurrence of one " +
                                                            "or both of the two conditions, specifying the occurred condition or conditions. ");
                    document.Add(paragraph3);

                    Paragraph paragraph4 = new Paragraph("4. This tender guarantee will remain in force up to and including thirty (30) days after the period of tender " +
                                                            "validity, and any demand in respect thereof should reach the Bank not later than the above date.");
                    document.Add(paragraph4);

                    Paragraph paragraph5 = new Paragraph("NOW THIS AGREEMENT WITNESSETH AS FOLLOWS:").SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(12);
                    document.Add(paragraph5);
                    LineSeparator ls2 = new LineSeparator(new SolidLine());
                    document.Add(ls2);

                    Paragraph paragraph6 = new Paragraph("1. In this Agreement words and expressions shall have the same meanings as are respectively assigned to them in the Conditions of Contract referred to: ");
                    document.Add(paragraph6);

                    Paragraph paragraph7 = new Paragraph("2. The following documents shall be deemed to form and be read and construed as part of this " +
                                                            "Agreement viz: (a)the Tender Form and the Price Schedule submitted by the tenderer(b) the Schedule " +
                                                            "of Requirements(c) the Technical Specifications(d) the General Conditions of Contract(e) the Special " +
                                                            "Conditions of contract; and(f) the Procuring entity’s Notification of Award");
                    document.Add(paragraph7);

                    Paragraph paragraph8 = new Paragraph("3. In consideration of the payments to be made by the Procuring entity to the tenderer as hereinafter " +
                                                            "mentioned, the tender hereby covenants with the Procuring entity to provide the goods and to remedy " +
                                                            "defects therein in conformity in all respects with the provisions of the Contract ");
                    document.Add(paragraph8);


                    Paragraph paragraph88 = new Paragraph();
                    document.Add(paragraph8);


                    Paragraph paragraph9 = new Paragraph("4. The Procuring entity hereby covenants to pay the tenderer in consideration of the provisions of the " +
                                                            "goods and the remedying of defects therein, the Contract Price or such other sum as may become " +
                                                            "payable under the provisions of the Contract at the times and in the manner prescribed by the contract");
                    document.Add(paragraph9);

                    Paragraph paragraph10 = new Paragraph("IN WITNESS whereof the parties hereto have caused this Agreement to be executed in accordance withtheir respective laws the day and year first above written.");
                    document.Add(paragraph10);
                    //  document.SetBackgroundColor()

                    // Add image
                    //Image img = new Image(ImageDataFactory
                    //   //.Create(@"..\..\image.jpg"))
                    //   .Create(path))
                    //   .SetTextAlignment(TextAlignment.CENTER);
                    //document.Add(img);

                    // Table
                    Table table = new Table(2, false);
                    Cell cell11 = new Cell(1, 1)
                       .SetBackgroundColor(ColorConstants.GRAY)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("APPLICATION SUMMARY DETAILS"));
                    Cell cell12 = new Cell(1, 1)
                       .SetBackgroundColor(ColorConstants.GRAY)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("VALUE"));

                    Cell cell21 = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("TENDER NUMBER"));
                    Cell cell22 = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph(applicationDetails.tenderNo ?? ""));

                    Cell cell31 = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("BOND VALUE"));
                    Cell cell32 = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph(formattedCurrency));
                    Cell cell41 = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph("BENEFICIARY"));
                    Cell cell42 = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph(BeneficiaryDetails.FirstName ?? ""));
                    Cell cell51 = new Cell(1, 1)
                     .SetTextAlignment(TextAlignment.CENTER)
                     .Add(new Paragraph("COREBANKING REF NO."));
                    Cell cell52 = new Cell(1, 1)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .Add(new Paragraph(applicationDetails.CoreBankingReferenceNumber.ToUpper() ?? ""));
                    table.AddCell(cell11);
                    table.AddCell(cell12);
                    table.AddCell(cell21);
                    table.AddCell(cell22);
                    table.AddCell(cell31);
                    table.AddCell(cell32);
                    table.AddCell(cell41);
                    table.AddCell(cell42);
                    table.AddCell(cell51);
                    table.AddCell(cell52);

                    document.Add(newline);
                    document.Add(table);

                    // Page numbers
                    int n = pdf.GetNumberOfPages();
                    for (int i = 1; i <= n; i++)
                    {
                        document.ShowTextAligned(new Paragraph(String
                           .Format("page" + i + " of " + n)),
                           559, 806, i, TextAlignment.RIGHT,
                           VerticalAlignment.BOTTOM, 0);


                    }
                    Paragraph paragraph55 = new Paragraph("");
                    document.Add(paragraph55);
                    LineSeparator ls222 = new LineSeparator(new SolidLine());
                    document.Add(ls222);

                    Paragraph paragraph555 = new Paragraph();
                    document.Add(paragraph55);

                    //Bar Code 1
                    //var bar = new BarcodeInter25(pdf);
                    //bar.FitWidth(10);
                    //bar.SetCode(applicationDetails.CoreBankingReferenceNumber);

                    ////Here's how to add barcode to PDF with IText7
                    //var barcodeImg = new Image(bar.CreateFormXObject(pdf));
                    //document.Add(barcodeImg);

                    //BardCode2
                    string prodCode = GetProdCode();
                    Barcode39 barcode = new Barcode39(pdf);
                    barcode.SetGuardBars(true);
                    barcode.SetBarHeight(40);
                    barcode.SetX(40);
                    barcode.SetGenerateChecksum(false);
                    barcode.FitWidth(60);
                    // barcode.SetCodeType(Barcode39);
                    barcode.SetCode("TP" + prodCode);


                    // Create barcode object to put it to the cell as image
                    PdfFormXObject barcodeObject = barcode.CreateFormXObject(null, null, pdf);
                    Cell cell = new Cell().Add(new Image(barcodeObject));
                    cell.SetPaddingTop(10);
                    cell.SetPaddingRight(10);
                    cell.SetPaddingBottom(10);
                    cell.SetPaddingLeft(10);
                    document.Add(cell);

                    //BarCode3




                    Paragraph paragraph565 = new Paragraph("");
                    document.Add(paragraph565);
                    Paragraph paragraph5665 = new Paragraph("");
                    document.Add(paragraph5665);
                    // Hyper link

                    Paragraph paragraph525 = new Paragraph("");
                    document.Add(paragraph525);
                    Paragraph paragraph585 = new Paragraph(" ***This Document Is System generated and does not require Signature Verification***").SetTextAlignment(TextAlignment.LEFT).SetFontColor(ColorConstants.RED)
                     .SetFontSize(13);
                    document.Add(paragraph585);
                    Paragraph paragraph505 = new Paragraph("");
                    document.Add(paragraph505);
                    Paragraph paragraph5005 = new Paragraph("");
                    document.Add(paragraph5005);
                    Paragraph paragraph50105 = new Paragraph("");
                    document.Add(paragraph50105);
                    Paragraph paragraph50205 = new Paragraph("");
                    document.Add(paragraph50205);
                    Paragraph paragraph50305 = new Paragraph("");
                    document.Add(paragraph50305);
                    Paragraph paragraph50405 = new Paragraph("");
                    document.Add(paragraph50405);
                    Paragraph paragraph50505 = new Paragraph("");
                    document.Add(paragraph50505);
                    //Link link = new Link("click here",
                    //PdfAction.CreateURI("https://www."""));
                    //Paragraph hyperLink = new Paragraph("Please ")
                    //   .Add(link.SetBold().SetUnderline()
                    //   .SetItalic().SetFontColor(ColorConstants.BLUE)).SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(" to go """);

                   // document.Add(newline);
                  //  document.Add(hyperLink);


                    //Papa start watermarking here

                    float watermarkTrimmingRectangleWidth = 420;
                    float watermarkTrimmingRectangleHeight = 420;

                    float formWidth = 420;
                    float formHeight = 420;
                    float formXOffset = 0;
                    float formYOffset = 0;

                    float xTranslation = 50;
                    float yTranslation = 25;

                    double rotationInRads = Math.PI / 3;

                    PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);

                    // Font f = new Font(baseFont, 80, Font.NORMAL, BaseColor.LIGHT_GRAY);
                    float fontSize = 80;
                    // PdfDocument pdfDoc = new PdfDocument(new PdfReader(sourceFile), new PdfWriter(destinationPath));
                    var numberOfPages = pdf.GetNumberOfPages();
                    PdfPage page = null;

                    for (var i = 1; i <= numberOfPages; i++)
                    {
                        page = pdf.GetPage(i);
                        Rectangle ps = page.GetPageSize();

                        //Center the annotation
                        float bottomLeftX = ps.GetWidth() / 2 - watermarkTrimmingRectangleWidth / 2;
                        float bottomLeftY = ps.GetHeight() / 2 - watermarkTrimmingRectangleHeight / 2;
                        Rectangle watermarkTrimmingRectangle = new Rectangle(bottomLeftX, bottomLeftY, watermarkTrimmingRectangleWidth, watermarkTrimmingRectangleHeight);

                        PdfWatermarkAnnotation watermark = new PdfWatermarkAnnotation(watermarkTrimmingRectangle);

                        //Apply linear algebra rotation math
                        //Create identity matrix
                        AffineTransform transform = new AffineTransform();//No-args constructor creates the identity transform
                                                                          //Apply translation
                        transform.Translate(xTranslation, yTranslation);
                        //Apply rotation
                        transform.Rotate(rotationInRads);

                        PdfFixedPrint fixedPrint = new PdfFixedPrint();
                        watermark.SetFixedPrint(fixedPrint);
                        //Create appearance
                        Rectangle formRectangle = new Rectangle(formXOffset, formYOffset, formWidth, formHeight);

                        //Observation: font XObject will be resized to fit inside the watermark rectangle
                        PdfFormXObject form = new PdfFormXObject(formRectangle);
                        PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.6f);
                        PdfCanvas canvas = new PdfCanvas(form, pdf);
                        // new Canvas(canvas,)


                        float[] transformValues = new float[6];
                        transform.GetMatrix(transformValues);
                        _ = canvas.SaveState()
                            .BeginText().SetFillColor(ColorConstants.LIGHT_GRAY).SetExtGState(gs1)
                            .SetTextMatrix(transformValues[0], transformValues[1], transformValues[2], transformValues[3], transformValues[4], transformValues[5])
                            .SetFontAndSize(font, fontSize)
                            .ShowText(applicationDetails.CoreBankingReferenceNumber.ToUpper())
                            .EndText()
                            .RestoreState();

                        canvas.Release();

                        watermark.SetAppearance(PdfName.N, new PdfAnnotationAppearance(form.GetPdfObject()));
                        watermark.SetFlags(PdfAnnotation.PRINT);

                        page.AddAnnotation(watermark);

                    }
                    page?.Flush();




                    document.Close();
                    //try
                    //{
                    //    WatermarkPDF(fullDocPath, fullDocPath);
                    //}
                    //catch (Exception ex)
                    //{
                    //    await _dbOps.LogError("Applications/BondGeneration", "WaterMarkingBond", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                    //    throw;
                    //}
                    return (true, "sucess", fullDocPath, "TP" + prodCode);
                }
                else
                {
                    string fileName = applicationId.ToString();
                    var fullDocPath = bonds + fileName + ".pdf";
                    PdfWriter writer = new PdfWriter(fullDocPath);

                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf);

                    var path = Path.Combine(
                          Directory.GetCurrentDirectory(),
                          "wwwroot/BankDocs/logo.jpeg");

                    String imFile = path;//"C:/Users/jbrad/Desktop/FamilyDemo/logo.jpeg";
                    ImageData data = ImageDataFactory.Create(imFile);

                    // Creating an Image object        
                    Image image = new Image(data);

                    // Setting the position of the image to the center of the page    

                    image.ScaleToFit(140, 140);
                    image.SetFixedPosition(450, 720);

                    //image.SetFixedPosition(100, 250);
                    //image.ScaleAbsolute(60, 57);

                    // Adding image to the document       
                    document.Add(image);
                    Paragraph paragraph323 = new Paragraph(new Text("\n"));
                    document.Add(paragraph323);
                    Paragraph paragraph343 = new Paragraph(new Text("\n"));
                    document.Add(paragraph343);
                

                    Paragraph posterDetails = new Paragraph(DateTime.Now.ToString("dd MMM yyyy")+",").SetBold()
                        .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                    document.Add(posterDetails);

                    Paragraph ourRef = new Paragraph("Our ref : " + applicationDetails.CoreBankingReferenceNumber.ToUpper() +","?? "")
                       .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold();
                    document.Add(ourRef);

                    //Paragraph postmasterGeneral = new Paragraph("THE POSTMASTER GENERAL,")
                    //  .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold();
                    //document.Add(postmasterGeneral);

                    Paragraph posalCorpor = new Paragraph(BeneficiaryDetails.FirstName.ToUpper()+",")
                      .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold();
                    document.Add(posalCorpor);

                    Paragraph postmasterGeneral = new Paragraph(BeneficiaryDetails.adrress.ToUpper()+".")
                      .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold();
                    document.Add(postmasterGeneral);

                    Paragraph paragraph3443 = new Paragraph(new Text("\n"));
                    document.Add(paragraph3443);

                    Paragraph Dear = new Paragraph("Dear Sir/Madam,")
                  .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                    document.Add(Dear);



                    Paragraph RE = new Paragraph("RE: TENDER NO, " + applicationDetails.tenderNo + " ;" + applicationDetails.Details)
                 .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold().SetUnderline();
                    document.Add(RE);
                 

                    // Add paragraph1
                    Paragraph paragraph1 = new Paragraph("WHEREAS " + companyDetails.compName.ToUpper() + " of " + companyDetails.postalAddress.ToUpper() + " " + "(hereinafter called “the Tenderer”) " + " has submitted its tender dated" + " " +
                        applicationDetails.appDate.ToString("dd MMM yyyy") + " " + "FOR " + applicationDetails.Details.ToUpper() + ". TENDER NO; " + applicationDetails.tenderNo.ToUpper() + "(Hereinafter called 'The Contract and Number' )").SetFontSize(8);

                    document.Add(paragraph1);

                    Paragraph paragraph111 = new Paragraph(
                        "KNOW ALL PEOPLE by these presents that WE "
                        + BankDetails.bankName.ToUpper() + " of P.O. Box 74145-00200, Nairobi having our registered office at FAMILY BANK TOWERS, 6th Floor, Muindi Mbingu Street" + "(hereinafter called “the Guarantor”)" + " " + "are bound unto" + " " + BeneficiaryDetails.FirstName.ToUpper() + " (hereinafter called “the Procuring entity”) in the sum of  " +
                        formattedCurrency +
                        " for which payment well and truly to be made to the said Procuring entity, the Bank binds itself, its " +
                        "successors, and assigns by these presents.Sealed with the Common Seal of the said Bank this day " +
                        applicationDetails.appDate.ToString("dd MMM yyyy")).SetFontSize(8); ;

                    document.Add(paragraph111);

                    Paragraph paragraph2 = new Paragraph("THE CONDITIONS OF THIS OBLIGATION").SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(9).SetUnderline().SetBold();
                    document.Add(paragraph2);

                    Paragraph paragraph733 = new Paragraph("1. If after tender withdraws its tender during the period of" +
                                                            "tender validity specified by the procuring entity on the Tender Form; or").SetFontSize(8); 
                    document.Add(paragraph733);

                    Paragraph paragraph34 = new Paragraph("2. If the tenderer, having been notified" +
                                                            "of the acceptance of its Tender by the Procuring entity during the period of tender validity: (a)fails or " +
                                                            "refuses to execute the Contract Form, if required; or(b) fails or refuses to furnish the performance " +
                                                            "security in accordance with the Instructions to tenderers;").SetFontSize(8); 
                    document.Add(paragraph34);

                    Paragraph paragraph3 = new Paragraph("We undertake to pay to the Procuring entity up to the above amount upon receipt of its first written " +
                                                            "demand, without the Procuring entity having to substantiate its demand, provided that in its demand " +
                                                            "the Procuring entity will note that the amount claimed by it is due to it, owing to the occurrence of one " +
                                                            "or both of the two conditions, specifying the occurred condition or conditions. ").SetFontSize(8); 
                    document.Add(paragraph3);
                   
                    Paragraph paragraph4 = new Paragraph("This tender guarantee will remain in force up to and including Thirty(30) days after the period of tender " +
                                                            "validity,and any demand in respect thereof should reach the Bank not later than the above date after which the guarantee shall become null and void whether the original is returned to the Bank or not").SetFontSize(8);
                    document.Add(paragraph4);

                    var path1 = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/BankDocs/sig2.jpg");
                    var path2 = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/BankDocs/Hillary.jpg");

                    String imFile2 = path1; //"C:/Users/jbrad/Desktop/FamilyDemo/sig2.jpg";
                    ImageData data2 = ImageDataFactory.Create(imFile2);
  
                    Image image2 = new Image(data2);
  

                    image2.ScaleToFit(80, 80);
                    image2.SetFixedPosition(20, 280);
   
                    document.Add(image2);



                    String imFile3 = path2; //"C:/Users/jbrad/Desktop/FamilyDemo/Hillary.jpg";
                    ImageData data3 = ImageDataFactory.Create(imFile3);

                    // Creating an Image object        
                    Image image3 = new Image(data3);

                    // Setting the position of the image to the center of the page    

                    image3.ScaleToFit(80, 80);
                    image3.SetFixedPosition(470, 280);
      
                    document.Add(image3);

                    Paragraph paragraph1101 = new Paragraph(new Text("\n"));
                    document.Add(paragraph1101);
                    Paragraph paragraph2101 = new Paragraph(new Text("\n"));
                    document.Add(paragraph2101);
                    Paragraph paragraph11011 = new Paragraph(new Text("\n"));
                    document.Add(paragraph11011);
                    //Paragraph paragraph21011 = new Paragraph(new Text("\n"));
                    //document.Add(paragraph21011);
                    //Paragraph paragraph3101 = new Paragraph(new Text("\n"));
                    //document.Add(paragraph3101);

                    //Paragraph paragraph12101 = new Paragraph(new Text("\n"));
                    //document.Add(paragraph12101);


                    Paragraph p = new Paragraph("AUTHORISED SIGNATORY 1").SetFontSize(7);
                    p.Add(new Tab());
                    p.AddTabStops(new TabStop(1000, TabAlignment.CENTER));
                    p.Add("AUTHORISED SIGNATORY 2").SetFontSize(7); 
                    document.Add(p);

                    //Table table = new Table(1);
                    //Paragraph p = new Paragraph()
                    //        .Add(new Text("AUTHORISED SIGNATORY 1"))
                    //        .AddTabStops(new TabStop(1000, TabAlignment.RIGHT))
                    //        .Add(new Tab())
                    //        .Add(new Text("AUTHORISED SIGNATORY 2"));
                    //table.AddCell(new Cell().Add(p));
                    //document.Add(table);



                    //Paragraph paragraph101 = new Paragraph(new Text("AUTHORISED SIGNATORY 1").SetBold().SetTextAlignment(TextAlignment.LEFT).SetFontSize(8) + "" + new Text("AUTHORISED SIGNATORY 1").SetBold().SetTextAlignment(TextAlignment.RIGHT).SetFontSize(8));/*SetBold().SetTextAlignment(TextAlignment.LEFT).SetFontSize(8); ;*/
                    //document.Add(paragraph101);
                    //  document.SetBackgroundColor()

                    // Add image
                    //Image img = new Image(ImageDataFactory
                    //   //.Create(@"..\..\image.jpg"))
                    //   .Create(path))
                    //   .SetTextAlignment(TextAlignment.CENTER);
                    //document.Add(img);

                    // Table
                    //Table table = new Table(2, false);
                    //Cell cell11 = new Cell(1, 1)
                    //   .SetBackgroundColor(ColorConstants.GRAY)
                    //   .SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(new Paragraph("APPLICATION SUMMARY DETAILS"));
                    //Cell cell12 = new Cell(1, 1)
                    //   .SetBackgroundColor(ColorConstants.GRAY)
                    //   .SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(new Paragraph("VALUE"));

                    //Cell cell21 = new Cell(1, 1)
                    //   .SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(new Paragraph("TENDER NUMBER"));
                    //Cell cell22 = new Cell(1, 1)
                    //   .SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(new Paragraph(applicationDetails.tenderNo ?? ""));

                    //Cell cell31 = new Cell(1, 1)
                    //   .SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(new Paragraph("BOND VALUE"));
                    //Cell cell32 = new Cell(1, 1)
                    //   .SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(new Paragraph(formattedCurrency));
                    //Cell cell41 = new Cell(1, 1)
                    //   .SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(new Paragraph("BENEFICIARY"));
                    //Cell cell42 = new Cell(1, 1)
                    //   .SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(new Paragraph(BeneficiaryDetails.FirstName ?? ""));
                    //Cell cell51 = new Cell(1, 1)
                    // .SetTextAlignment(TextAlignment.CENTER)
                    // .Add(new Paragraph("COREBANKING REF NO."));
                    //Cell cell52 = new Cell(1, 1)
                    //   .SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(new Paragraph(applicationDetails.CoreBankingReferenceNumber.ToUpper() ?? ""));
                    //table.AddCell(cell11);
                    //table.AddCell(cell12);
                    //table.AddCell(cell21);
                    //table.AddCell(cell22);
                    //table.AddCell(cell31);
                    //table.AddCell(cell32);
                    //table.AddCell(cell41);
                    //table.AddCell(cell42);
                    //table.AddCell(cell51);
                    //table.AddCell(cell52);

                    //document.Add(newline);
                    //document.Add(table);

                    // Page numbers
                    int n = pdf.GetNumberOfPages();
                    for (int i = 1; i <= n; i++)
                    {
                        document.ShowTextAligned(new Paragraph(String
                           .Format("page" + i + " of " + n)),
                           559, 806, i, TextAlignment.RIGHT,
                           VerticalAlignment.BOTTOM, 0);


                    }

                    //Paragraph paragraph31013 = new Paragraph(new Text("\n"));
                    //document.Add(paragraph31013);
                    LineSeparator ls222 = new LineSeparator(new SolidLine());
                    document.Add(ls222);

                    //Bar Code 1
                    //var bar = new BarcodeInter25(pdf);
                    //bar.FitWidth(10);
                    //bar.SetCode(applicationDetails.CoreBankingReferenceNumber);

                    ////Here's how to add barcode to PDF with IText7
                    //var barcodeImg = new Image(bar.CreateFormXObject(pdf));
                    //document.Add(barcodeImg);

                    //BardCode2
                    string prodCode = GetProdCode();
                    Barcode39 barcode = new Barcode39(pdf);
                    barcode.SetGuardBars(true);
                    barcode.SetBarHeight(40);
                    barcode.SetX(40);
                    barcode.SetGenerateChecksum(false);
                    barcode.FitWidth(60);
                    // barcode.SetCodeType(Barcode39);
                    barcode.SetCode("TP" + prodCode);


                    // Create barcode object to put it to the cell as image
                    PdfFormXObject barcodeObject = barcode.CreateFormXObject(null, null, pdf);
                    Cell cell = new Cell().Add(new Image(barcodeObject));
                    cell.SetPaddingTop(10);
                    cell.SetPaddingRight(10);
                    cell.SetPaddingBottom(10);
                    cell.SetPaddingLeft(10);
                    document.Add(cell);

                    //BarCode3




                    Paragraph paragraph565 = new Paragraph("");
                    document.Add(paragraph565);

                    Paragraph paragraph585 = new Paragraph(" ***This Document Is System generated ,To Verify,please scan the above Bar Code***").SetTextAlignment(TextAlignment.LEFT).SetFontColor(ColorConstants.RED)
                     .SetFontSize(8);
                    document.Add(paragraph585);
                    Paragraph paragraph505 = new Paragraph("");
                    document.Add(paragraph505);



                    Paragraph paragraph50 = new Paragraph("Family Bank Ltd. Head Office, Family Bank Towers").SetBold().SetTextAlignment(TextAlignment.LEFT).SetFontColor(ColorConstants.BLUE).SetFontSize(8);
                    document.Add(paragraph50);
                    Paragraph paragraph510 = new Paragraph("P.O.Box 74145 - 00200 Nairobi, Muindi Mbingu Street").SetTextAlignment(TextAlignment.LEFT).SetFontColor(ColorConstants.BLUE).SetFontSize(8);
                    document.Add(paragraph510);
                    Paragraph paragraph520 = new Paragraph("Tel: 020 325 2000 Cell :+254 703 095 000").SetTextAlignment(TextAlignment.LEFT).SetFontColor(ColorConstants.BLUE).SetFontSize(8);
                    document.Add(paragraph520);
                    Paragraph paragraph530 = new Paragraph("Email: info@familybank.co.ke, www.familybank.co.ke").SetTextAlignment(TextAlignment.LEFT).SetFontColor(ColorConstants.BLUE).SetFontSize(8);
                    document.Add(paragraph530);






                    //Link link = new Link("click here",
                    //PdfAction.CreateURI("https://www."""));
                    //Paragraph hyperLink = new Paragraph("Please ")
                    //   .Add(link.SetBold().SetUnderline()
                    //   .SetItalic().SetFontColor(ColorConstants.BLUE)).SetTextAlignment(TextAlignment.CENTER)
                    //   .Add(" to go """);

                    //document.Add(newline);
                    //document.Add(hyperLink);


                    //Papa start watermarking here

                    //float watermarkTrimmingRectangleWidth = 420;
                    //float watermarkTrimmingRectangleHeight = 420;

                    //float formWidth = 420;
                    //float formHeight = 420;
                    //float formXOffset = 0;
                    //float formYOffset = 0;

                    //float xTranslation = 50;
                    //float yTranslation = 25;

                    //double rotationInRads = Math.PI / 3;

                    //PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);

                    //// Font f = new Font(baseFont, 80, Font.NORMAL, BaseColor.LIGHT_GRAY);
                    //float fontSize = 80;
                    //// PdfDocument pdfDoc = new PdfDocument(new PdfReader(sourceFile), new PdfWriter(destinationPath));
                    //var numberOfPages = pdf.GetNumberOfPages();
                    //PdfPage page = null;

                    //for (var i = 1; i <= numberOfPages; i++)
                    //{
                    //    page = pdf.GetPage(i);
                    //    Rectangle ps = page.GetPageSize();

                    //    //Center the annotation
                    //    float bottomLeftX = ps.GetWidth() / 2 - watermarkTrimmingRectangleWidth / 2;
                    //    float bottomLeftY = ps.GetHeight() / 2 - watermarkTrimmingRectangleHeight / 2;
                    //    Rectangle watermarkTrimmingRectangle = new Rectangle(bottomLeftX, bottomLeftY, watermarkTrimmingRectangleWidth, watermarkTrimmingRectangleHeight);

                    //    PdfWatermarkAnnotation watermark = new PdfWatermarkAnnotation(watermarkTrimmingRectangle);

                    //    //Apply linear algebra rotation math
                    //    //Create identity matrix
                    //    AffineTransform transform = new AffineTransform();//No-args constructor creates the identity transform
                    //                                                      //Apply translation
                    //    transform.Translate(xTranslation, yTranslation);
                    //    //Apply rotation
                    //    transform.Rotate(rotationInRads);

                    //    PdfFixedPrint fixedPrint = new PdfFixedPrint();
                    //    watermark.SetFixedPrint(fixedPrint);
                    //    //Create appearance
                    //    Rectangle formRectangle = new Rectangle(formXOffset, formYOffset, formWidth, formHeight);

                    //    //Observation: font XObject will be resized to fit inside the watermark rectangle
                    //    PdfFormXObject form = new PdfFormXObject(formRectangle);
                    //    PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.6f);
                    //    PdfCanvas canvas = new PdfCanvas(form, pdf);
                    //    // new Canvas(canvas,)


                    //    float[] transformValues = new float[6];
                    //    transform.GetMatrix(transformValues);
                    //    _ = canvas.SaveState()
                    //        .BeginText().SetFillColor(ColorConstants.LIGHT_GRAY).SetExtGState(gs1)
                    //        .SetTextMatrix(transformValues[0], transformValues[1], transformValues[2], transformValues[3], transformValues[4], transformValues[5])
                    //        .SetFontAndSize(font, fontSize)
                    //        .ShowText(applicationDetails.CoreBankingReferenceNumber.ToUpper())
                    //        .EndText()
                    //        .RestoreState();

                    //    canvas.Release();

                    //    watermark.SetAppearance(PdfName.N, new PdfAnnotationAppearance(form.GetPdfObject()));
                    //    watermark.SetFlags(PdfAnnotation.PRINT);

                    //    page.AddAnnotation(watermark);

                    //  }
                    // page?.Flush();




                    document.Close();
                    //try
                    //{
                    //    WatermarkPDF(fullDocPath, fullDocPath);
                    //}
                    //catch (Exception ex)
                    //{
                    //    await _dbOps.LogError("Applications/BondGeneration", "WaterMarkingBond", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                    //    throw;
                    //}
                    return (true, "sucess", fullDocPath, "TP" + prodCode);
                }
               

            }
            catch (Exception ex)
            {

                await _dbOps.LogError("Applications/BondGeneration", "BondGeneration", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                return (false, "Error Creating Bid Bond,Please contact system admin",string.Empty,string.Empty);
            }
        }

        public void WatermarkPDF(string sourceFile, string destinationPath)
        {
            float watermarkTrimmingRectangleWidth = 300;
            float watermarkTrimmingRectangleHeight = 300;

            float formWidth = 300;
            float formHeight = 300;
            float formXOffset = 0;
            float formYOffset = 0;

            float xTranslation = 50;
            float yTranslation = 25;

            double rotationInRads = Math.PI / 3;

            PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);
            float fontSize = 50;

            PdfDocument pdfDoc = new PdfDocument(new PdfReader(sourceFile), new PdfWriter(destinationPath));
            var numberOfPages = pdfDoc.GetNumberOfPages();
            PdfPage page = null;

            for (var i = 1; i <= numberOfPages; i++)
            {
                page = pdfDoc.GetPage(i);
                Rectangle ps = page.GetPageSize();

                //Center the annotation
                float bottomLeftX = ps.GetWidth() / 2 - watermarkTrimmingRectangleWidth / 2;
                float bottomLeftY = ps.GetHeight() / 2 - watermarkTrimmingRectangleHeight / 2;
                Rectangle watermarkTrimmingRectangle = new Rectangle(bottomLeftX, bottomLeftY, watermarkTrimmingRectangleWidth, watermarkTrimmingRectangleHeight);

                PdfWatermarkAnnotation watermark = new PdfWatermarkAnnotation(watermarkTrimmingRectangle);

                //Apply linear algebra rotation math
                //Create identity matrix
                AffineTransform transform = new AffineTransform();//No-args constructor creates the identity transform
                                                                  //Apply translation
                transform.Translate(xTranslation, yTranslation);
                //Apply rotation
                transform.Rotate(rotationInRads);

                PdfFixedPrint fixedPrint = new PdfFixedPrint();
                watermark.SetFixedPrint(fixedPrint);
                //Create appearance
                Rectangle formRectangle = new Rectangle(formXOffset, formYOffset, formWidth, formHeight);

                //Observation: font XObject will be resized to fit inside the watermark rectangle
                PdfFormXObject form = new PdfFormXObject(formRectangle);
                PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.6f);
                PdfCanvas canvas = new PdfCanvas(form, pdfDoc);

                float[] transformValues = new float[6];
                transform.GetMatrix(transformValues);
                _ = canvas.SaveState()
                    .BeginText()/*.SetFillColor(Color.MakeColor(), true)*/.SetExtGState(gs1)
                    .SetTextMatrix(transformValues[0], transformValues[1], transformValues[2], transformValues[3], transformValues[4], transformValues[5])
                    .SetFontAndSize(font, fontSize)
                    .ShowText("watermark text")
                    .EndText()
                    .RestoreState();

                canvas.Release();

                watermark.SetAppearance(PdfName.N, new PdfAnnotationAppearance(form.GetPdfObject()));
                watermark.SetFlags(PdfAnnotation.PRINT);

                page.AddAnnotation(watermark);

            }
            page?.Flush();
            pdfDoc.Close();
        }

        public string GetProdCode()
        {
            return RandomPassword(); // var data= OtpGen(0, 1000);

        }
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
          //  builder.Append(RandomString(1, true));
            builder.Append(OtpGen(1000, 9999));
          //  builder.Append(RandomString(1, false));
            return builder.ToString();
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public int OtpGen(int min, int max)
        {

            Random random = new Random();
            return random.Next(min, max);
        }

        public async Task<(bool, string, string, string)> AutoGenerateBondFamily(Guid applicationId, bool bankAccess)
        {
            try
            {
                //var appid = "F52675D5-98C2-498B-846C-207F2674A528";
                //applicationId =Guid.Parse(appid);
                var applicationDetails = _context.TbApplications.FirstOrDefault(c => c.CRBGuid == applicationId);

                var BankDetails = _context.TbSystemBanks.FirstOrDefault(c => c.SystemBanksGuid == applicationDetails.SystemBanksGuid);
                var BeneficiaryDetails = _context.TbBeneficialies.FirstOrDefault(k => k.benGuid == Guid.Parse(applicationDetails.Purchaser));
                var companyDetails = _context.TbCompanies.FirstOrDefault(v => v.compGuid == applicationDetails.compGuid);

                var currAmount = applicationDetails.amount;

                var regionInfo = new RegionInfo("sw-KE");
                var currencySymbol = regionInfo.ISOCurrencySymbol;
                var formattedCurrency = String.Format(new System.Globalization.CultureInfo("sw-KE"), "{0:c}", currAmount);

                //1get Bank Details
                //BankName
                //Bank Params...........AUTH SIG, LETTER HEAD, LOGO
                //GET APPLICATION DETAILS
                //

                var bonds = Path.Combine(_env.WebRootPath, "BidBonds", applicationId.ToString());

                //using (var strea = new FileStream(bonds, FileMode.Create))
                //{
                //    await BoardResolution.CopyToAsync(strea);
                //}

                string fileName = applicationId.ToString();
                var fullDocPath = bonds + fileName + ".pdf";
                PdfWriter writer = new PdfWriter(fullDocPath);

                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                // Header
                Paragraph header = new Paragraph("TENDER SECURITY FORM")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(20);

                // New line
                Paragraph newline = new Paragraph(new Text("\n"));

                document.Add(newline);
                document.Add(header);

                // Add sub-header
                Paragraph subheader = new Paragraph(BankDetails.bankName)
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(12);
                document.Add(subheader);


                Paragraph posterDetails = new Paragraph(DateTime.Now.ToString())
                    .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                document.Add(posterDetails);

                Paragraph ourRef = new Paragraph("Our ref: "+ applicationDetails.CoreBankingReferenceNumber.ToUpper() ?? "")
                   .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold();
                document.Add(ourRef);

                Paragraph postmasterGeneral = new Paragraph("THE POSTMASTER GENERAL,")
                  .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold();
                document.Add(postmasterGeneral);

                Paragraph posalCorpor = new Paragraph(BeneficiaryDetails.FirstName.ToUpper())
                  .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold();
                document.Add(posalCorpor);

                Paragraph box = new Paragraph(BeneficiaryDetails.adrress)
                 .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold();
                document.Add(box);


                Paragraph NRB = new Paragraph("NAIROBI, KENYA.")
                .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8).SetBold();
                document.Add(NRB);


                Paragraph Dear = new Paragraph("Dear Sir/Madam,")
              .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                document.Add(Dear);

               

                Paragraph RE = new Paragraph("RE: TENDER NO, "+applicationDetails.tenderNo +" ;"+applicationDetails.Details )
             .SetTextAlignment(TextAlignment.LEFT).SetFontSize(8);
                document.Add(RE);
                // Line separator
                LineSeparator ls = new LineSeparator(new SolidLine());
                document.Add(ls);

                // Add paragraph1
                Paragraph paragraph1 = new Paragraph("WHEREAS " + companyDetails.compName.ToUpper()+"of "+ companyDetails.postalAddress.ToUpper()+ " " + "(hereinafter called “the Tenderer”) " + " has submitted its tender dated" + " " +
                    applicationDetails.appDate.ToString() + " " + "FOR " + applicationDetails.Details.ToUpper()+". TENDER NO; "+applicationDetails.tenderNo.ToUpper() +"(Hereinafter called 'The Contract and Number' )");

                document.Add(paragraph1);

                Paragraph paragraph111 = new Paragraph(
                    "KNOW ALL PEOPLE by these presents that WE "
                    + BankDetails.bankName.ToUpper() + " of P.O. Box 74145-00200, Nairobi having our registered office at FAMILY BANK TOWERS, 6th Floor, Muindi Mbingu Street" + "(hereinafter called “the Guarantor”)" + " " + "are bound unto" + " " + BeneficiaryDetails.FirstName.ToUpper() + " (hereinafter called “the Procuring entity”) in the sum of  " +
                    formattedCurrency +
                    " for which payment well and truly to be made to the said Procuring entity, the Bank binds itself, its " +
                    "successors, and assigns by these presents.Sealed with the Common Seal of the said Bank this day " +
                    applicationDetails.appDate.ToString());

                document.Add(paragraph111);

                Paragraph paragraph2 = new Paragraph("THE CONDITIONS OF THIS OBLIGATION").SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(12).SetBold();
                document.Add(paragraph2);
                LineSeparator ls22 = new LineSeparator(new SolidLine());
                document.Add(ls22);

                Paragraph paragraph33 = new Paragraph("1. If after tender withdraws its tender during the period of" +
                                                        "tender validity specified by the procuring entity on the Tender Form; or");
                document.Add(paragraph33);

                Paragraph paragraph34 = new Paragraph("2. If the tenderer, having been notified" +
                                                        "of the acceptance of its Tender by the Procuring entity during the period of tender validity: (a)fails or " +
                                                        "refuses to execute the Contract Form, if required; or(b) fails or refuses to furnish the performance " +
                                                        "security in accordance with the Instructions to tenderers;");
                document.Add(paragraph34);

                Paragraph paragraph3 = new Paragraph("We undertake to pay to the Procuring entity up to the above amount upon receipt of its first written " +
                                                        "demand, without the Procuring entity having to substantiate its demand, provided that in its demand " +
                                                        "the Procuring entity will note that the amount claimed by it is due to it, owing to the occurrence of one " +
                                                        "or both of the two conditions, specifying the occurred condition or conditions. ");
                document.Add(paragraph3);

                Paragraph paragraph4 = new Paragraph("This tender guarantee will remain in force up to and including Thirty (30) days after the period of tender " +
                                                        "validity, and any demand in respect thereof should reach the Bank not later than the above date after which the guarantee shall become null and void whether the original is returned to us or not");
                document.Add(paragraph4);

                //Paragraph paragraph5 = new Paragraph("NOW THIS AGREEMENT WITNESSETH AS FOLLOWS:").SetTextAlignment(TextAlignment.CENTER)
                //   .SetFontSize(12);
                //document.Add(paragraph5);
                //LineSeparator ls2 = new LineSeparator(new SolidLine());
                //document.Add(ls2);

                //Paragraph paragraph6 = new Paragraph("1. In this Agreement words and expressions shall have the same meanings as are respectively assigned to them in the Conditions of Contract referred to: ");
                //document.Add(paragraph6);

                //Paragraph paragraph7 = new Paragraph("2. The following documents shall be deemed to form and be read and construed as part of this " +
                //                                        "Agreement viz: (a)the Tender Form and the Price Schedule submitted by the tenderer(b) the Schedule " +
                //                                        "of Requirements(c) the Technical Specifications(d) the General Conditions of Contract(e) the Special " +
                //                                        "Conditions of contract; and(f) the Procuring entity’s Notification of Award");
                //document.Add(paragraph7);

                //Paragraph paragraph8 = new Paragraph("3. In consideration of the payments to be made by the Procuring entity to the tenderer as hereinafter " +
                //                                        "mentioned, the tender hereby covenants with the Procuring entity to provide the goods and to remedy " +
                //                                        "defects therein in conformity in all respects with the provisions of the Contract ");
                //document.Add(paragraph8);


                //Paragraph paragraph88 = new Paragraph();
                //document.Add(paragraph8);


                //Paragraph paragraph9 = new Paragraph("4. The Procuring entity hereby covenants to pay the tenderer in consideration of the provisions of the " +
                //                                        "goods and the remedying of defects therein, the Contract Price or such other sum as may become " +
                //                                        "payable under the provisions of the Contract at the times and in the manner prescribed by the contract");
                //document.Add(paragraph9);

                Paragraph paragraph10 = new Paragraph("AUTHORISED SIGNATORY 1").SetBold().SetUnderline();
                document.Add(paragraph10);


                Paragraph paragraph101 = new Paragraph("AUTHORISED SIGNATORY 2").SetBold().SetUnderline();
                document.Add(paragraph101);
                //  document.SetBackgroundColor()

                // Add image
                //Image img = new Image(ImageDataFactory
                //   //.Create(@"..\..\image.jpg"))
                //   .Create(path))
                //   .SetTextAlignment(TextAlignment.CENTER);
                //document.Add(img);

                // Table
                //Table table = new Table(2, false);
                //Cell cell11 = new Cell(1, 1)
                //   .SetBackgroundColor(ColorConstants.GRAY)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("APPLICATION SUMMARY DETAILS"));
                //Cell cell12 = new Cell(1, 1)
                //   .SetBackgroundColor(ColorConstants.GRAY)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("VALUE"));

                //Cell cell21 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("TENDER NUMBER"));
                //Cell cell22 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph(applicationDetails.tenderNo ?? ""));

                //Cell cell31 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("BOND VALUE"));
                //Cell cell32 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph(formattedCurrency));
                //Cell cell41 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("BENEFICIARY"));
                //Cell cell42 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph(BeneficiaryDetails.FirstName ?? ""));
                //Cell cell51 = new Cell(1, 1)
                // .SetTextAlignment(TextAlignment.CENTER)
                // .Add(new Paragraph("COREBANKING REF NO."));
                //Cell cell52 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph(applicationDetails.CoreBankingReferenceNumber.ToUpper() ?? ""));
                //table.AddCell(cell11);
                //table.AddCell(cell12);
                //table.AddCell(cell21);
                //table.AddCell(cell22);
                //table.AddCell(cell31);
                //table.AddCell(cell32);
                //table.AddCell(cell41);
                //table.AddCell(cell42);
                //table.AddCell(cell51);
                //table.AddCell(cell52);

                //document.Add(newline);
                //document.Add(table);

                // Page numbers
                int n = pdf.GetNumberOfPages();
                for (int i = 1; i <= n; i++)
                {
                    document.ShowTextAligned(new Paragraph(String
                       .Format("page" + i + " of " + n)),
                       559, 806, i, TextAlignment.RIGHT,
                       VerticalAlignment.BOTTOM, 0);


                }
                Paragraph paragraph55 = new Paragraph("");
                document.Add(paragraph55);
                LineSeparator ls222 = new LineSeparator(new SolidLine());
                document.Add(ls222);

                Paragraph paragraph555 = new Paragraph();
                document.Add(paragraph55);

                //Bar Code 1
                //var bar = new BarcodeInter25(pdf);
                //bar.FitWidth(10);
                //bar.SetCode(applicationDetails.CoreBankingReferenceNumber);

                ////Here's how to add barcode to PDF with IText7
                //var barcodeImg = new Image(bar.CreateFormXObject(pdf));
                //document.Add(barcodeImg);

                //BardCode2
                string prodCode = GetProdCode();
                Barcode39 barcode = new Barcode39(pdf);
                barcode.SetGuardBars(true);
                barcode.SetBarHeight(40);
                barcode.SetX(40);
                barcode.SetGenerateChecksum(false);
                barcode.FitWidth(60);
                // barcode.SetCodeType(Barcode39);
                barcode.SetCode("TP" + prodCode);


                // Create barcode object to put it to the cell as image
                PdfFormXObject barcodeObject = barcode.CreateFormXObject(null, null, pdf);
                Cell cell = new Cell().Add(new Image(barcodeObject));
                cell.SetPaddingTop(10);
                cell.SetPaddingRight(10);
                cell.SetPaddingBottom(10);
                cell.SetPaddingLeft(10);
                document.Add(cell);

                //BarCode3




                Paragraph paragraph565 = new Paragraph("");
                document.Add(paragraph565);
                Paragraph paragraph5665 = new Paragraph("");
                document.Add(paragraph5665);
                // Hyper link

                Paragraph paragraph525 = new Paragraph("");
                document.Add(paragraph525);
                //Paragraph paragraph585 = new Paragraph(" ***This Document Is System generated and does not require Signature Verification***").SetTextAlignment(TextAlignment.LEFT).SetFontColor(ColorConstants.RED)
                // .SetFontSize(13);
                //document.Add(paragraph585);
                Paragraph paragraph505 = new Paragraph("");
                document.Add(paragraph505);
                Paragraph paragraph5005 = new Paragraph("");
                document.Add(paragraph5005);
                Paragraph paragraph50105 = new Paragraph("");
                document.Add(paragraph50105);
                Paragraph paragraph50205 = new Paragraph("");
                document.Add(paragraph50205);


                Paragraph paragraph50 = new Paragraph("Family Bank Ltd. Head Office, Family Bank Towers").SetBold().SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
                document.Add(paragraph50);

                Paragraph paragraph510 = new Paragraph("P.O.Box 74145 - 00200 Nairobi, Muindi Mbingu Street").SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
                document.Add(paragraph510);
                Paragraph paragraph520 = new Paragraph("Tel: 020 325 2000 Cell :+254 703 095 000").SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
                document.Add(paragraph520);
                Paragraph paragraph530 = new Paragraph("Email: info@familybank.co.ke, www.familybank.co.ke").SetTextAlignment(TextAlignment.LEFT).SetFontSize(12);
                document.Add(paragraph530);


                Paragraph paragraph50305 = new Paragraph("");
                document.Add(paragraph50305);
                Paragraph paragraph50405 = new Paragraph("");
                document.Add(paragraph50405);
                Paragraph paragraph50505 = new Paragraph("");
                document.Add(paragraph50505);



                //Link link = new Link("click here",
                //PdfAction.CreateURI("https://www."""));
                //Paragraph hyperLink = new Paragraph("Please ")
                //   .Add(link.SetBold().SetUnderline()
                //   .SetItalic().SetFontColor(ColorConstants.BLUE)).SetTextAlignment(TextAlignment.CENTER)
                //   .Add(" to go """);

                //document.Add(newline);
                //document.Add(hyperLink);


                //Papa start watermarking here

                float watermarkTrimmingRectangleWidth = 420;
                float watermarkTrimmingRectangleHeight = 420;

                float formWidth = 420;
                float formHeight = 420;
                float formXOffset = 0;
                float formYOffset = 0;

                float xTranslation = 50;
                float yTranslation = 25;

                double rotationInRads = Math.PI / 3;

                PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);

                // Font f = new Font(baseFont, 80, Font.NORMAL, BaseColor.LIGHT_GRAY);
                float fontSize = 80;
                // PdfDocument pdfDoc = new PdfDocument(new PdfReader(sourceFile), new PdfWriter(destinationPath));
                var numberOfPages = pdf.GetNumberOfPages();
                PdfPage page = null;

                for (var i = 1; i <= numberOfPages; i++)
                {
                    page = pdf.GetPage(i);
                    Rectangle ps = page.GetPageSize();

                    //Center the annotation
                    float bottomLeftX = ps.GetWidth() / 2 - watermarkTrimmingRectangleWidth / 2;
                    float bottomLeftY = ps.GetHeight() / 2 - watermarkTrimmingRectangleHeight / 2;
                    Rectangle watermarkTrimmingRectangle = new Rectangle(bottomLeftX, bottomLeftY, watermarkTrimmingRectangleWidth, watermarkTrimmingRectangleHeight);

                    PdfWatermarkAnnotation watermark = new PdfWatermarkAnnotation(watermarkTrimmingRectangle);

                    //Apply linear algebra rotation math
                    //Create identity matrix
                    AffineTransform transform = new AffineTransform();//No-args constructor creates the identity transform
                                                                      //Apply translation
                    transform.Translate(xTranslation, yTranslation);
                    //Apply rotation
                    transform.Rotate(rotationInRads);

                    PdfFixedPrint fixedPrint = new PdfFixedPrint();
                    watermark.SetFixedPrint(fixedPrint);
                    //Create appearance
                    Rectangle formRectangle = new Rectangle(formXOffset, formYOffset, formWidth, formHeight);

                    //Observation: font XObject will be resized to fit inside the watermark rectangle
                    PdfFormXObject form = new PdfFormXObject(formRectangle);
                    PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.6f);
                    PdfCanvas canvas = new PdfCanvas(form, pdf);
                    // new Canvas(canvas,)


                    float[] transformValues = new float[6];
                    transform.GetMatrix(transformValues);
                    _ = canvas.SaveState()
                        .BeginText().SetFillColor(ColorConstants.LIGHT_GRAY).SetExtGState(gs1)
                        .SetTextMatrix(transformValues[0], transformValues[1], transformValues[2], transformValues[3], transformValues[4], transformValues[5])
                        .SetFontAndSize(font, fontSize)
                        .ShowText(applicationDetails.CoreBankingReferenceNumber.ToUpper())
                        .EndText()
                        .RestoreState();

                    canvas.Release();

                    watermark.SetAppearance(PdfName.N, new PdfAnnotationAppearance(form.GetPdfObject()));
                    watermark.SetFlags(PdfAnnotation.PRINT);

                    page.AddAnnotation(watermark);

                }
                page?.Flush();




                document.Close();
                //try
                //{
                //    WatermarkPDF(fullDocPath, fullDocPath);
                //}
                //catch (Exception ex)
                //{
                //    await _dbOps.LogError("Applications/BondGeneration", "WaterMarkingBond", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                //    throw;
                //}
                return (true, "sucess", fullDocPath, "TP" + prodCode);

            }
            catch (Exception ex)
            {

                await _dbOps.LogError("Applications/BondGeneration", "BondGeneration", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                return (false, "Error Creating Bid Bond,Please contact system admin", string.Empty, string.Empty);
            }
        }
    }
}
 
