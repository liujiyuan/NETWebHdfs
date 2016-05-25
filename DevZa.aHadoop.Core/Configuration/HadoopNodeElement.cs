using System;
using System.Configuration;
using System.Net;
using DevZa.aHadoop.Resources;

namespace DevZa.aHadoop.Configuration
{
    public class HadoopNodeElement : ConfigurationElement
    {


        [ConfigurationProperty(HadoopConfigurationConstants.NameNode.Ip, IsKey = true)]
        public string Ip
        {
            get { return (String)this[HadoopConfigurationConstants.NameNode.Ip]; }
            set { this[HadoopConfigurationConstants.NameNode.Ip] = value.ToString(); }
        }

        [ConfigurationProperty(HadoopConfigurationConstants.NameNode.Name, IsKey = true)]
        public string Name
        {
            get { return (string)this[HadoopConfigurationConstants.NameNode.Name]; }
            set { this[HadoopConfigurationConstants.NameNode.Name] = value; }
        }

        [ConfigurationProperty(HadoopConfigurationConstants.NameNode.Type)]
        public NodeStatus Status
        {
            get
            {
                return (NodeStatus)this[HadoopConfigurationConstants.NameNode.Type];
            }
            set { this[HadoopConfigurationConstants.NameNode.Type] = value; }
        }

        public IPAddress IpAddress
        {
            get { return IPAddress.Parse(this.Ip); }
        }

    }
}