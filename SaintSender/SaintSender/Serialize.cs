using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SaintSender
{
    class Serialize
    {
        public static string serialize(Email tempEmail)
        {
            // Create file to save the data 
            // Create and use a BinaryFormatter object to perform the serialization 
            // Close the file
            string formattedFileName = "email" + tempEmail.messageId + ".dat";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(formattedFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, tempEmail);
            stream.Close();

            return formattedFileName;
        }

        public static Email Deserialize(FileInfo fileToDeserialize)
        {
            // Declare the object reference.
            Email deserializedObj;

            // Open the file containing the data that want to deserialize.
            FileStream fs = new FileStream(fileToDeserialize.FullName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the object from the file and 
                // assign the reference to the local variable.
                deserializedObj = (Email)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            return deserializedObj;
        }
    }
}
