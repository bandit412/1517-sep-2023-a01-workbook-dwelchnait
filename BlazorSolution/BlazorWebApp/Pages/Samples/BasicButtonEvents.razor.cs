namespace BlazorWebApp.Pages.Samples
{
    public partial class BasicButtonEvents
    {
        //variables that are used on your html content
        //  MUST be declared in this C# coding block
        private string feedback;
        private Random rnd = new Random();

        //if you have a variable that is bound to an control on your page
        //  you will need to declare that variable in this coding block
        private string inputValue;

        //there are points in the staging to render your work as a page
        //  that you can add your own code to execute along with
        //  the code in that stage

        //Initialize stage
        protected override void OnInitialized()
        {
            feedback = "on initialization";
            base.OnInitialized();
        }

        void OnFirstButtonClick()
        {
            int oddeven = rnd.Next(1, 101);
            if (oddeven % 2 == 0)
            {
                feedback = $"the value {oddeven} is even";
            }
            else
            {
                feedback = $"the value {oddeven} is odd";
            }
        }

        void DataInput()
        {
            //the data entered into the input control will be place
            //  for me into the local variable mention with the bind
            //  attributes
            feedback = $"you entered >{inputValue}<";
        }
    }
}
