using Microsoft.SharePoint.Client;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace AddlistToSharepoint
{
    public class SharePoint
    {
        internal void SPUploader(Stream fs, string fn)
        {

            //Copy WebService Settings
            string webUrl = "https://YouSiteHere";
            MoveCopyUtil.CopyFolder()
            WSCopy.Copy copyService = new WSCopy.Copy();
            copyService.Url = webUrl + "/_vti_bin/copy.asmx";
            copyService.Credentials = System.Net.CredentialCache.DefaultCredentials;

            //Declare and initiates the Copy WebService members for uploading
            string sourceUrl = @"C:\MyFile.pdf";
            string[] destinationUrl = { "https://YourSiteHere/DocumentLibrary/MyFile.pdf" };
            WSCopy.CopyResult cResult1 = new WSCopy.CopyResult();
            WSCopy.CopyResult cResult2 = new WSCopy.CopyResult();
            WSCopy.CopyResult[] cResultArray = { cResult1, cResult2 };
            WSCopy.FieldInformation fFiledInfo = new WSCopy.FieldInformation();
            //fFiledInfo.DisplayName = "Title";
            //fFiledInfo.Type = WSCopy.FieldType.Text;
            //fFiledInfo.Value = "Sample Description";
            WSCopy.FieldInformation[] fFiledInfoArray = { fFiledInfo };

            //Reading the document contents in to stream
            FileStream strm = new FileStream(sourceUrl, FileMode.Open, FileAccess.Read);
            byte[] fileContents = new Byte[strm.Length];
            byte[] r = new Byte[strm.Length];
            int ia = strm.Read(fileContents, 0, Convert.ToInt32(strm.Length));
            strm.Close();

            //Copy the document from SourceUrl to destinationUrl with metadatas
            uint copyresult = copyService.CopyIntoItems(sourceUrl, destinationUrl, fFiledInfoArray, fileContents, out cResultArray);

            if (copyresult == 0)
                Console.WriteLine("Document uploaded successfully from " + sourceUrl + " to " + destinationUrl[0]);
            else
                Console.WriteLine("Document gets failed on uploading..");

            Console.Write("Press any key to exit...");
            Console.Read();

            //ClientContext context = new ClientContext("http://Sharepointsite");///SitePages/Home.aspx");
            //System.Net.ICredentials creds = System.Net.CredentialCache.DefaultCredentials;

            //context.Credentials = creds;
            //context.RequestTimeout = 60000000; // Time in milliseconds

            //string url = "/Members/";
            //string fileName = Path.GetFileName(fn);

            //string fnUrl = url + fn;

            //Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, fnUrl, fs, true);

            //string uniqueRefNo = GetNextDocRefNo();

            //SP.Web web = context.Web;

            //Microsoft.SharePoint.Client.File newFile = web.GetFileByServerRelativeUrl(fnUrl);
            //context.Load(newFile);
            //context.ExecuteQuery();

            //Web site = context.Web;
            //List docList = site.Lists.GetByTitle("Members");

            //context.Load(docList);
            //context.ExecuteQuery();


            //context.Load(docList.Fields.GetByTitle("Workflow Number"));
            //context.Load(docList.Fields.GetByTitle("Agreement Number"));
            //context.Load(docList.Fields.GetByTitle("First Name"));
            //context.Load(docList.Fields.GetByTitle("Surname"));
            //context.Load(docList.Fields.GetByTitle("ID Number"));
            //context.Load(docList.Fields.GetByTitle("Date of Birth"));
            //context.Load(docList.Fields.GetByTitle("Country"));
            //context.Load(docList.Fields.GetByTitle("Document Description"));
            //context.Load(docList.Fields.GetByTitle("Document Type"));
            //context.Load(docList.Fields.GetByTitle("Document Group"));

            //context.ExecuteQuery();

            ////*********NEED TO GET THE INTERNAL COLUMN NAMES FROM SHAREPOINT************
            //var name = docList.Fields.GetByTitle("Workflow Number").InternalName;
            //var name2 = docList.Fields.GetByTitle("Agreement Number").InternalName;
            //var name3 = docList.Fields.GetByTitle("First Name").InternalName;
            //var name4 = docList.Fields.GetByTitle("Surname").InternalName;
            //var name5 = docList.Fields.GetByTitle("ID Number").InternalName;
            //var name6 = docList.Fields.GetByTitle("Date of Birth").InternalName;
            //var name7 = docList.Fields.GetByTitle("Country").InternalName;
            //var name8 = docList.Fields.GetByTitle("Document Description").InternalName;
            //var name9 = docList.Fields.GetByTitle("Document Type").InternalName;
            //var name10 = docList.Fields.GetByTitle("Document Group").InternalName;
            //var name11 = docList.Fields.GetByTitle("Unique Document Ref No").InternalName;

            ////**********NOW SAVE THE METADATA TO SHAREPOINT**********
            //newFile.ListItemAllFields[name] = "927015";
            //newFile.ListItemAllFields[name2] = "1234565";
            //newFile.ListItemAllFields[name3] = "Joe";
            //newFile.ListItemAllFields[name4] = "Soap";
            //newFile.ListItemAllFields[name5] = "7502015147852";
            //newFile.ListItemAllFields[name6] = "1975-02-01";
            //newFile.ListItemAllFields[name7] = "ZA";
            //newFile.ListItemAllFields[name8] = "Test";
            //newFile.ListItemAllFields[name9] = "Requirements";
            //newFile.ListItemAllFields[name10] = "Requirements";
            //newFile.ListItemAllFields[name11] = uniqueRefNo;

            //newFile.ListItemAllFields.Update();
            //context.Load(newFile);
            //context.ExecuteQuery();
        }
    }
}