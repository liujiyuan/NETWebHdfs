using System.Configuration;
using DevZa.Logger;

namespace DevZa.aHadoop.Configuration
{
    public class DataNodesCollectionElement : ConfigurationElementCollection
    {
        private static IZaLogger _logger = LoggerFactory.GetLogger<DataNodesCollectionElement>();

        public DataNodesCollectionElement()
        {

        }

        public HadoopNodeElement this[int index]
        {
            get { return (HadoopNodeElement)BaseGet(index); }
        }



        public void Add(HadoopNodeElement namenode)
        {
            BaseAdd(namenode);
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new HadoopNodeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((HadoopNodeElement)element).Name;
        }
    }
}