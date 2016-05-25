using System.Configuration;
using System.Linq;
using DevZa.aHadoop.Resources;
using DevZa.Configuration;

namespace DevZa.aHadoop.Configuration
{


    public class AHadoopConfig : BaseConfigurationSection
    {
        [ConfigurationProperty(HadoopConfigurationConstants.NameNodesElement)]
        [ConfigurationCollection(typeof(NameNodesCollectionElement), AddItemName = "add")]
        public NameNodesCollectionElement NameNodesCollection
        {
            get { return (NameNodesCollectionElement)this[HadoopConfigurationConstants.NameNodesElement]; }
            set { this[HadoopConfigurationConstants.NameNodesElement] = value; }
        }


        [ConfigurationProperty(HadoopConfigurationConstants.DataNodesElement)]
        [ConfigurationCollection(typeof(DataNodesCollectionElement), AddItemName = "add")]
        public DataNodesCollectionElement DataNodesCollection
        {
            get { return (DataNodesCollectionElement)this[HadoopConfigurationConstants.DataNodesElement]; }
            set { this[HadoopConfigurationConstants.DataNodesElement] = value; }
        }


        

        [ConfigurationProperty(HadoopConfigurationConstants.WebHDFSElement)]
        public WebHDFSElement WebHdfs
        {
            get { return (WebHDFSElement)this[HadoopConfigurationConstants.WebHDFSElement]; }
            set { this[HadoopConfigurationConstants.WebHDFSElement] = value; }
        }


        public HadoopNodeElement ActiveHadoopNode
        {
            get
            {
                var namenode = from HadoopNodeElement s in NameNodesCollection
                               where s.Status.Equals(NodeStatus.Active)
                               select s;
                return namenode.FirstOrDefault();
            }
        }

        public HadoopNodeElement FirstDataNode
        {
            get
            {
                var nodeElements = from HadoopNodeElement s in DataNodesCollection
                               where s.Status.Equals(NodeStatus.Active)
                               select s;
                return nodeElements.FirstOrDefault();
            }
        }
    }
}