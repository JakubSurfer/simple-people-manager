using System.Xml;
using System.Xml.Linq;
using Project.Infrastructure.Configuration;

namespace Project.Infrastructure.Store
{
    public abstract class XmlDataStoreBase<TEntity> : DataStore<TEntity>
        where TEntity : class
    {
        private readonly IXmlConfiguration _xmlConfiguration;

        protected XmlDataStoreBase(IXmlConfiguration xmlConfiguration)
        {
            _xmlConfiguration = xmlConfiguration;
        }


        protected XDocument GetXDocument()
        {
            try
            {
                var path = GetFilePath();
                return XDocument.Load(path);
            }
            catch (XmlException e)
            {
                return CreateNewXDocument();
            }
            
        }

        protected abstract XDocument CreateNewXDocument();
        
        protected string GetFilePath()
        {
            return _xmlConfiguration.XmlFilePath;
        }

        protected override void Save(TEntity entity)
        {
            var xmlDoc = GetXDocument();
            var newNode = CreateNewNode(entity);
            AddNode(xmlDoc, newNode);
            Save(xmlDoc);
        }

        private void Save(XDocument xmlDoc)
        {
            var path = GetFilePath();
            xmlDoc.Save(path);
        }

        protected abstract XElement CreateNewNode(TEntity entity);

        protected abstract void AddNode(XDocument xmlDoc, XElement newNode);

    }
}