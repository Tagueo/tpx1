using System;
using System.IO;

namespace Polynomial
{
    public class IO
    {
        public static string ReadFile(string path)
        {
            string result = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                string line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //Append the line to the result
                    result += line + '\n';
                    
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Exception: " + e.Message);
            }
            
            return result;
        }

        public static void WriteFile(string path, string content)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(path);
                
                //Write the passed content to the file
                sw.WriteLine(content);
                
                //Close the file
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}