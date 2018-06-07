﻿//
// ADefHelpDesk.com
// Copyright (c) 2017
// by Michael Washington
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
//
//
using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AdefHelpDeskBase.Models;
using AdefHelpDeskBase.Models.DataContext;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace ADefHelpDeskApp.Classes
{
    public class GeneralSettings
    {
        string _SMTPServer;
        string _SMTPAuthendication;
        bool _SMTPSecure;
        string _SMTPUserName;
        string _SMTPPassword;
        string _SMTPFromEmail;
        string _FileUploadPath;
        string _StorageFileType;
        string _AzureStorageConnection;
        string _UploadPermission;
        bool _AllowRegistration;
        bool _VerifiedRegistration;
        string _ApplicationName;
        string _ApplicationGUID;

        #region Public Properties
        public string SMTPServer
        {
            get { return _SMTPServer; }
        }

        public string SMTPAuthendication
        {
            get { return _SMTPAuthendication; }
        }

        public bool SMTPSecure
        {
            get { return _SMTPSecure; }
        }

        public string SMTPUserName
        {
            get { return _SMTPUserName; }
        }

        public string SMTPPassword
        {
            get { return _SMTPPassword; }
        }

        public string SMTPFromEmail
        {
            get { return _SMTPFromEmail; }
        }

        public string FileUploadPath
        {
            get { return _FileUploadPath; }
        }

        public string StorageFileType
        {
            get { return _StorageFileType; }
        }

        public string AzureStorageConnection
        {
            get { return _AzureStorageConnection; }
        }

        public string UploadPermission
        {
            get { return _UploadPermission; }
        }

        public bool AllowRegistration
        {
            get { return _AllowRegistration; }
        }

        public bool VerifiedRegistration
        {
            get { return _VerifiedRegistration; }
        }

        public string ApplicationName
        {
            get { return _ApplicationName; }
        }

        public string ApplicationGUID
        {
            get { return _ApplicationGUID; }
        }
        #endregion

        public GeneralSettings() { }

        #region public GeneralSettings(string DefaultConnection)
        public GeneralSettings(string DefaultConnection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             select Settings;

                _SMTPServer = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "SMTPServer").SettingValue);
                _SMTPAuthendication = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "SMTPAuthendication").SettingValue);
                _SMTPSecure = Convert.ToBoolean(resuts.FirstOrDefault(x => x.SettingName == "SMTPSecure").SettingValue);
                _SMTPUserName = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "SMTPUserName").SettingValue);
                _SMTPPassword = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "SMTPPassword").SettingValue);
                _SMTPFromEmail = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "SMTPFromEmail").SettingValue);

                _FileUploadPath = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "FileUploadPath").SettingValue);
                _StorageFileType = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "StorageFileType").SettingValue);
                _AzureStorageConnection = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "AzureStorageConnection").SettingValue);
                _UploadPermission = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "UploadPermission").SettingValue);

                _AllowRegistration = Convert.ToBoolean(resuts.FirstOrDefault(x => x.SettingName == "AllowRegistration").SettingValue);
                _VerifiedRegistration = Convert.ToBoolean(resuts.FirstOrDefault(x => x.SettingName == "VerifiedRegistration").SettingValue);

                _ApplicationName = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "ApplicationName").SettingValue);
                _ApplicationGUID = Convert.ToString(resuts.FirstOrDefault(x => x.SettingName == "ApplicationGUID").SettingValue);
            }
        }
        #endregion

        #region UpdateSMTPServer
        public void UpdateSMTPServer(string DefaultConnection, string SMTPServer)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "SMTPServer"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(SMTPServer);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateSMTPAuthentication
        public void UpdateSMTPAuthentication(string DefaultConnection, string SMTPAuthendication)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "SMTPAuthendication"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(SMTPAuthendication);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateSMTPSecure
        public void UpdateSMTPSecure(string DefaultConnection, bool SMTPSecure)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "SMTPSecure"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(SMTPSecure);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateSMTPUserName
        public void UpdateSMTPUserName(string DefaultConnection, string SMTPUserName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "SMTPUserName"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(SMTPUserName);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateSMTPPassword
        public void UpdateSMTPPassword(string DefaultConnection, string SMTPPassword)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "SMTPPassword"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(SMTPPassword);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateSMTPFromEmail
        public void UpdateSMTPFromEmail(string DefaultConnection, string SMTPFromEmail)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "SMTPFromEmail"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(SMTPFromEmail);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateFileUploadPath
        public void UpdateFileUploadPath(string DefaultConnection, string FileUploadPath)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "FileUploadPath"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(FileUploadPath);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateStorageFileType
        public void UpdateStorageFileType(string DefaultConnection, string StorageFileType)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "StorageFileType"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(StorageFileType);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateAzureStorageConnection
        public void UpdateAzureStorageConnection(string DefaultConnection, string AzureStorageConnection)
        {

            // Ensure there is a AdefHelpDesk Container
            // Retrieve the connection string for use with the application. 
            string storageConnectionString = AzureStorageConnection;

            // Check whether the connection string can be parsed.
            CloudStorageAccount storageAccount = null;
            CloudBlobContainer cloudBlobContainer = null;
            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                cloudBlobContainer = cloudBlobClient.GetContainerReference("adefhelpdesk-files");
                cloudBlobContainer.CreateIfNotExistsAsync().Wait();
            }
            else
            {
                throw new Exception("Cannot create Azure Storage folder using this connection!");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "AzureStorageConnection"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(AzureStorageConnection);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateUploadPermission
        public void UpdateUploadPermission(string DefaultConnection, string UploadPermission)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "UploadPermission"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(UploadPermission);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateAllowRegistration
        public void UpdateAllowRegistration(string DefaultConnection, bool AllowRegistration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "AllowRegistration"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(AllowRegistration);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateVerifiedRegistration
        public void UpdateVerifiedRegistration(string DefaultConnection, bool VerifiedRegistration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "VerifiedRegistration"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(VerifiedRegistration);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateApplicationName
        public void UpdateApplicationName(string DefaultConnection, string ApplicationName)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "ApplicationName"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(ApplicationName);
                context.SaveChanges();
            }
        }
        #endregion

        #region UpdateApplicationGUID
        public void UpdateApplicationGUID(string DefaultConnection, string ApplicationGUID)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ADefHelpDeskContext>();
            optionsBuilder.UseSqlServer(DefaultConnection);

            using (var context = new ADefHelpDeskContext(optionsBuilder.Options))
            {
                var resuts = from Settings in context.AdefHelpDeskSettings
                             where Settings.SettingName == "ApplicationGUID"
                             select Settings;

                resuts.FirstOrDefault().SettingValue = Convert.ToString(ApplicationGUID);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
