using Microsoft.AspNetCore.Components;
using OOPsReview; //Employment, SupervisoryLevel, Utilities


namespace BlazorWebApp.Pages.Samples
{
    public partial class DataCollection
    {
        private string feedbackMessage = ""; //default of a string is null

        //used to hold a collection of keyed values
        //we will hold the errors messages of your validation
        //the dictionary entry has two item: a key value and associate string validation
        //one can serach the dictionary collection using the method .Contains(keyvalue of interest)
        // in our example Key : error and associate string: message
        private Dictionary<string, string> errorDictionary = new Dictionary<string, string>();

        private string employmentTitle;
        private double employmentYears;
        private DateTime employmentStartDate;
        private SupervisoryLevel employmentLevel;

        //One COULD possible use the properties of a class DIRECTLY on the
        //  component control bind IF and ONLY IF the properties' set is public
        //Since our version of Employment has private sets for some properties
        //  we COULD NOT directly use the employment instance link to our controls
        Employment employment = new Employment();

        //this property will be used as an injection variable to hold
        //  the access point to the service I will use in the example
        [Inject]
        public IWebHostEnvironment webHostEnvironment { get; set; } = default;

        protected override Task OnInitializedAsync()
        {
            employmentStartDate = DateTime.Today;
            return base.OnInitializedAsync();
        }

        public void DataProcessing()
        {
            //clear out any old displayed messages
            feedbackMessage = "";
            errorDictionary.Clear();

            //validate the incoming data
            //errorDictionary will hold any message with regard to invalid data
            //   key: field value: message
            //assume as fields required
            //year is a positive value
            //start date cannot be in the future
            if (string.IsNullOrWhiteSpace(employmentTitle))
            {
                errorDictionary.Add("Title", "Title is required");
            }
            if (employmentStartDate >= DateTime.Today.AddDays(1))
            {
                errorDictionary.Add("StartDate", "Start date is in the future. Not allowed");
            }
            if (!Utilities.IsZeroOrPositive(employmentYears))
            {
                errorDictionary.Add("Years", "Years needs to be a positive number (eg. 3.5)");
            }
            if (errorDictionary.Count == 0)
            {
                

                //to demonstrate that you can use class defintions on a component
                //  this event will create an instance of Employment and use its
                //  ToString behaviour to create a csv line for writing to a file

                //we need to remember that the class has the ability to throw exceptions
                //we need to use user friendly error handling on these exceptions
                try
                {
                    employment = new Employment(employmentTitle,
                                                employmentLevel,
                                                employmentStartDate,
                                                employmentYears);

                    //write the class data as a string to a csv text file
                    // required:
                    // a) know the location of the file (name)
                    // b) the technique to use in writing to the file
                    //    there are serveral ways to write to the file
                    //      a) StreamWriter/StreamReader
                    //      b) using the System.IO.File methods
                    //           (handles the streaming of the data)

                    //WARNING: when you use the System.IO.File you MUST use the
                    //          fully qualified naming to the class method you wish\
                    //          to use.
                    //         you can not get by just usinng a reference to the
                    //          namespace at the top of your code (using System.IO;)

                    //there are a couple of ways to refer to your file and its path
                    //  i) obtain the root path of your application using an injection
                    //      service called IWebHostEnvironment via property injection
                    //  ii) use relative addressing starting a the top of your application

                    //in this example we will demonstrate property onjection
                    //the method that will be use will return the path from the
                    //  top of your drive to the top of your application
                    //append the remainder part of the file path to this result (via concentation)

                    //WARNING: the folder slash for your path can be both a forward or back slash
                    //              on a PC BUT for an Apple machine, you must use the forwardslash (/)
                    string csvFilePathName = $@"{webHostEnvironment.ContentRootPath}/Data/Employments.csv";

                    //write the data from the employment instance (ToString) as a line to the csv file
                    //since the string does not contain a line feed character, we will need to concatenate
                    //  the character (\n)
                    //the System.IO.File method will be AppendAllText(string)
                    // AppendAllText will
                    //   a) create the file if it does not exist
                    //   b) opens
                    //   c) writes the text
                    //   d) closes

                    string line = $"{employment.ToString()}\n";
                    System.IO.File.AppendAllText(csvFilePathName, line);

                    feedbackMessage = "Data has be saved to file";
                }
                catch(FormatException ex)
                {
                    errorDictionary.Add("Format", ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    errorDictionary.Add("OutOfRange", ex.Message);
                }
                catch (ArgumentNullException ex)
                {
                    errorDictionary.Add("ArgumentNull", ex.Message);
                }
                catch (ArgumentException ex)
                {
                    errorDictionary.Add("Argument", ex.Message);
                }
                catch (Exception ex)
                {
                    errorDictionary.Add("Exception", ex.Message);
                }
            }
        }
        public void Clear()
        {
            feedbackMessage = "";
            errorDictionary.Clear();
            employmentTitle="";
            employmentLevel =SupervisoryLevel.Entry;
            employmentStartDate = DateTime.Today;
            employmentYears = 0;
        }

        public Exception GetInnerException(Exception ex)
        {
            //drilldown into your exception message until you hit the actual
            //  real exception message
            while(ex.InnerException !=null)
            {
                ex = ex.InnerException;
            }
            //return the real actual message
            return ex;
        }
    }
}
