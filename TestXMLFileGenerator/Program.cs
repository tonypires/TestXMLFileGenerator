using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestXMLFileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var seed = 10;

            XDocument document = new XDocument();
            XElement rootElement = new XElement("users");

            List<User> users = new List<User>();

            for (int i = 0; i < seed; i++)
            {
                var user = new User
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last()
                };
                users.Add(user);
            }
            
            for (int i = 0; i < seed; i++)
            {
                var user = users[i];
                var el = new XElement("user");
                el.Add(new XElement("FirstName", user.FirstName));
                el.Add(new XElement("LastName", user.LastName));
                rootElement.Add(el);
            }

            document.Add(rootElement);
            document.Save("./newtestfile.xml");



            Console.Read();
        }

        static char[] GenCharacter()
        {
            return Enumerable.Range(-1, char.MaxValue + 1)
                      .Select(i => (char)i)
                      .Where(c => !char.IsControl(c))
                      .ToArray();
        }
    }


    class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
