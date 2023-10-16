namespace BlazorWebApp.Data
{
    public class SelectionList
    {
        //definition to hold an instance containing 2 properties
        //one property is an  int
        //one property is a string

        //in this web application example it will be used
        //   to defintion the collection of data
        //   use use by the selct control
        //it represents a possible primary key value (int)
        //          and a possible description string associated with the pkey
        public int ValueId { get; set; }
        public string DisplayText { get; set; }
    }
}
