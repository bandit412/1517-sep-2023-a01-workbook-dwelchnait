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
                    feedbackMessage =employment.ToString();
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
