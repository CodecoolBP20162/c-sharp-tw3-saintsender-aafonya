using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using System.IO;

namespace SaintSender
{
    class DataManager
    {
        public static OrderedDictionary emailList = new OrderedDictionary();

        public static void ProcessingSavedData(MimeMessage message)
        {
            Email tempEmail = new Email(message);
            string outputFileName = Serialize.serialize(tempEmail);
            emailList.Add(tempEmail, outputFileName);
        }

        public static void FullFillEmailListByFolder(string folderName)
        {

            //Email tempEmail = new Email(message);
            //string outputFileName = Serialize.serialize(tempEmail);
            //emailList.Add(tempEmail, outputFileName);
        }

        public static Email ProcessingDeserialization(int index)
        {
            string actualItem = emailList[index].ToString();
            FileInfo fileinfo = new FileInfo(actualItem);
            if (fileinfo == null)
            {
                throw new NullReferenceException();
            }

            Email deserializedObject = Serialize.Deserialize(fileinfo);

            return deserializedObject;
        }

        
        public static void FullFillEmaillistByLoadForm()
        {
            string path = @"C:\Users\Judit\Source\Repos\c-sharp-tw3-saintsender-aafonya\SaintSender\SaintSender\bin\Debug";
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] fileinfos = directory.GetFiles();

            foreach (FileInfo file in fileinfos)
            {
                if (file.Name.Substring(0, 5).Equals("email"))
                {
                    Email deserializedObject = Serialize.Deserialize(file);
                    emailList.Add(deserializedObject, file.FullName);
                }
            }
        }
    }
}
