using System;

namespace URLEncoder
{
    class Program
    {
        static string UrlFormat = "https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf";

        static void Main(string[] args)
        {
            a:
            Console.WriteLine("Please enter a project name:\n");
            string project_name = Console.ReadLine();
            if (IsValid(project_name) is false)
            {
                goto a;
            }
            project_name = CheckInput(project_name);

            b:
            Console.WriteLine("Please enter an activity name:\n");
            string activity_name = Console.ReadLine();
            if (IsValid(activity_name) is false)
            {
                goto b;
            }
            activity_name = CheckInput(activity_name);

            Console.WriteLine(CreateUrl(project_name, activity_name));

            c:
            Console.WriteLine("Would you like to create another URL? (Y/N) ");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "Y":
                    goto a;
                case "N":
                    break;
                default:
                    Console.WriteLine("You made an invalid choice.\n");
                    goto c;
            }
        }


        static bool IsValid(string input)
        {
            foreach (char character in input)
            {
                if (character <= 0x1F || character == 0x7F)
                {
                    Console.WriteLine("Invalid input. Contains a control character. ");
                    return false;
                }
            }
            return true;
        }


        static string CheckInput(string input)
        {
            string[] illegal = new string[] { "%", " ", "<", ">", "#", "\"", ";", "/", "?", ":", "@", "&", "=", "+", "$", ",", "{", "}", "|", "\\", "^", "[", "]", "`" };
            string[] replacement = new string[] { "%25", "%20", "%3C", "%3E", "%23", "%22", "%3B", "%2F", "%3F", "%3A", "%40", "%26", "%3D", "%2B", "%24", "%2C", "%7B", "%7D", "%7C", "%5C", "%5E", "%5B", "%5D", "%60" };

            foreach (string element in illegal)
            {
                int index = Array.IndexOf(illegal, element);

                if (input.Contains(element))
                {
                    input = input.Replace(element, replacement[index]);
                }
            }
            return String.Format(input);
        }


        static string CreateUrl(string project_name, string activity_name)
        {
            return String.Format(UrlFormat, project_name, activity_name);
        }


    }
}

