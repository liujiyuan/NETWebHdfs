using System;
using System.Configuration;
using DevZa.aHadoop.Resources;

namespace DevZa.aHadoop.Configuration
{
    public class WebHDFSElement : ConfigurationElement
    {
        [ConfigurationProperty(HadoopConfigurationConstants.WebHdfs.NameNodePort)]
        public int NameNodePort
        {
            get { return (int)this[HadoopConfigurationConstants.WebHdfs.NameNodePort]; }
            set { this[HadoopConfigurationConstants.WebHdfs.NameNodePort] = value; }
        }


        [ConfigurationProperty(HadoopConfigurationConstants.WebHdfs.DataNodePort)]
        public int DataNodePort
        {
            get { return (int)this[HadoopConfigurationConstants.WebHdfs.DataNodePort]; }
            set { this[HadoopConfigurationConstants.WebHdfs.DataNodePort] = value; }
        }

        [ConfigurationProperty(HadoopConfigurationConstants.WebHdfs.SaveMode)]
        public Boolean SaveMode
        {
            get { return (Boolean)this[HadoopConfigurationConstants.WebHdfs.SaveMode]; }
            set { this[HadoopConfigurationConstants.WebHdfs.SaveMode] = value; }
        }

        [ConfigurationProperty(HadoopConfigurationConstants.WebHdfs.ApiPrefix)]
        public string ApiPrefix
        {
            get { return (string) this[HadoopConfigurationConstants.WebHdfs.ApiPrefix]; }

            set { this[HadoopConfigurationConstants.WebHdfs.ApiPrefix] = value; }
        }
    }
}