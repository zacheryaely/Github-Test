using System;
using System.Security;
using Microsoft.SharePoint.Client;


namespace AddlistToSharepoint
{
    public class Addlist
    {
        public static string SendToSharepoint(string sharepointListName, string listParamName, string listParamValues)
         //public static int SendToSharepoint(string sharepointWebserverURL, string sharepointusername, string sharepointpassword,
         //         string sharepointListName, string listParamName, string listParamValues)
        {

            try
            {
                #region Connexion to SharePoint
                string WebUrl = "https://ilcomptroller.sharepoint.com/spotestsite/"; //sharepointWebserverURL;
                string login = "cfsp@illinoiscomptroller.gov"; //sharepointusername;
                string password = "X3rV,cmh!E9D,t'"; // sharepointpassword;
                var securePassword = new SecureString();
                foreach (char c in password)
                { securePassword.AppendChar(c); }
                var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
                #endregion

                #region Insert the data
                string[] sParamNames = listParamName.Split(',');
                string[] sParamValues = listParamValues.Split(',');

                using (ClientContext CContext = new ClientContext(WebUrl))
                {
                    CContext.Credentials = onlineCredentials;
                    List announcementsList = CContext.Web.Lists.GetByTitle(sharepointListName);//CContext.Web.Lists.GetByTitle("SAMSTestList");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    Microsoft.SharePoint.Client.ListItem newItem = announcementsList.AddItem(itemCreateInfo);
                    for (int i = 0; i < sParamNames.Length; i++)
                    {
                        newItem[sParamNames[i]] = sParamValues[i];
                    }
                    //newItem["Title"] = "Ms.";
                    //newItem["First_x0020_Name"] = "R";
                    //newItem["Last_x0020_Name"] = "S";
                    newItem.Update();
                    CContext.ExecuteQuery();
                }
                #endregion
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            return "Sucessfully saved Informataion";
        }

        public static int SendSTaticDataToSharePoint()
        {
            #region Connexion to SharePoint
            string WebUrl = "https://ilcomptroller.sharepoint.com/spotestsite/";
            string login = "cfsp@illinoiscomptroller.gov";
            string password = "X3rV,cmh!E9D,t'";
            var securePassword = new SecureString();
            foreach (char c in password)
            { securePassword.AppendChar(c); }
            var onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
            #endregion
            #region Insert the data
            using (ClientContext CContext = new ClientContext(WebUrl))
            {
                CContext.Credentials = onlineCredentials;
                List announcementsList = CContext.Web.Lists.GetByTitle("SAMSTestList");
                ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                Microsoft.SharePoint.Client.ListItem newItem = announcementsList.AddItem(itemCreateInfo);

                newItem["Title"] = "Ms.";
                newItem["First_x0020_Name"] = "R";
                newItem["Last_x0020_Name"] = "S";
                newItem.Update();
                CContext.ExecuteQuery();
            }
            #endregion

            return 0;
        }
    }
}
