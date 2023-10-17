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
        private string employmentYears;
        private DateTime employmentStartDate;
        private SupervisoryLevel employmentLevel;

        protected override Task OnInitializedAsync()
        {
            employmentStartDate = DateTime.Today;
            return base.OnInitializedAsync();
        }

        public void DataProcessing()
        {
            feedbackMessage = "Collecting";
        }
        public void Clear()
        {
            feedbackMessage = "";
            errorDictionary.Clear();
            employmentTitle="";
            employmentLevel =SupervisoryLevel.Entry;
            employmentStartDate = DateTime.Today;
            employmentYears = "0";
        }
    }
}
