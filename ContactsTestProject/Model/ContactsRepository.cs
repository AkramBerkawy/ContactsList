using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using ContactsTestProject.Common;
namespace ContactsTestProject.Model
{
    /// <summary>
    /// ContactsRepository implements IRepository
    /// 
    /// </summary>
    class ContactsRepository : IRepository<Contact>
    {
       
        #region fields
       
        private  XDocument XMLDocument;
        //the xml file path
        //TODO: make as applicaiton configuration
        const String XmlFilePath = "Contacts.xml";
        #endregion //fields
          
        #region Contructors

        public ContactsRepository()
        {
            //load the xml file
            //TODO: show error to user when file is not found or failed to open (invalid) and handle FileNotFoundException
            this.XMLDocument = XDocument.Load(XmlFilePath);
        }

        #endregion


        #region Members

        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <returns>All contacts</returns>
        public IEnumerable<Contact> GetAll()
        {
            var r = from a in XMLDocument.Root.Elements()
                    select new Contact(a.Attribute("Id").Value)
                    {
                        FirstName = a.Element("FirstName").Value,
                        LastName = a.Element("LastName").Value,
                        DOB = DateTime.Parse(a.Element("DOB").Value)
                    };
            return r;
        }

        /// <summary>
        /// Find Contacts the match the provided expression
        /// </summary>
        /// <param name="expression">The expression to evaluate</param>
        /// <returns>list of contact match the expression</returns>
        public IEnumerable<Contact> Find(System.Linq.Expressions.Expression<Func<Contact, object>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add new Contact to the repository
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Contact Add(Contact c)
        {
            var newContact = new XElement("Contact",
                new XElement("FirstName", c.FirstName),
                new XElement("LastName", c.LastName),
                new XElement("DOB", c.DOB));
            newContact.SetAttributeValue("Id", c.Id);
            XMLDocument.Root.Add(newContact);
            //save to xml file, actually this should be done in explicit call to Save operation in the repository
            XMLDocument.Save(XmlFilePath);
            return c;
        }


        /// <summary>
        /// Delete Contact from repository
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public bool Delete(Contact contact)
        {
            var c = XMLDocument.Root.Elements().SingleOrDefault(a => a.Attribute("Id").Value == contact.Id);
            if (c != null)
            {
                c.Remove();
                XMLDocument.Save(XmlFilePath);
            }
            return true;
        }


        /// <summary>
        /// Get Contact by primary key (ID) 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Contact GetById(String Id)
        {
            var contact = XMLDocument.Root.Elements().SingleOrDefault(a => a.Attribute("Id").Value == Id);
            return contact == null ?
                null :
                new Contact(Id)
                    {
                        FirstName = contact.Element("FirstName").Value,
                        LastName = contact.Element("LastName").Value,
                        DOB = DateTime.Parse(contact.Element("DOB").Value)
                    };
        }

        /// <summary>
        /// Update the Contact
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update(Contact contact)
        {
            var xContact = XMLDocument.Root.Elements().SingleOrDefault(a => a.Attribute("Id").Value == contact.Id);
            xContact.Element("FirstName").Value = contact.FirstName;
            xContact.Element("LastName").Value = contact.LastName;
            xContact.Element("DOB").Value = contact.DOB.ToString();
            XMLDocument.Save(XmlFilePath);
            return true;
        }
        #endregion //Members

    }
}
